import { Component, computed, signal, ViewChild } from '@angular/core';
import { LocalStorageService } from '../../../services/local-storage-service';
import { ProjectService } from '../../../services/project-service';
import { ProjectModel, ProjectThemes } from '../../../models/project';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Observable, single } from 'rxjs';
import { TagService } from '../../../services/tag-service';
import { TagModel } from '../../../models/tag';
import { ProjectThemeService } from '../../../services/project-theme-service';
import { ToastService } from '../../../services/toast-service';
import { forkJoin } from 'rxjs';

@Component({
  standalone: true,
  selector: 'app-projects',
  imports: [CommonModule, FormsModule],
  templateUrl: './projects.html',
  styleUrl: './projects.scss',
})
export class Projects {

  editMode = signal<boolean>(false)
  addMode = signal<boolean>(false)

  tags = signal<TagModel[]>([])
  shouldAddTagIds = signal<number[]>([])
  shouldRemoveTagIds = signal<number[]>([])

  projects = signal<ProjectModel[]>([])
  selectedProject = signal<ProjectModel>({
    id: 0,
    icon: '',
    title: '',
    desc: '',
    theme: ProjectThemes.Orange,
    githubLink: '',
    demoLink: '',
    tags: []
  })

  themes: any

  constructor(private toastServ: ToastService, public projectThemeServ: ProjectThemeService, private localStorageServ: LocalStorageService, private projectServ: ProjectService, private tagServ: TagService) {
    this.load()
    this.themes = Object.keys(ProjectThemes)
      .filter(key => isNaN(Number(key))) // Get 'Orange', 'Blue', etc.
      .map(name => ({
        name: name,
        value: ProjectThemes[name as keyof typeof ProjectThemes] // This will be 0, 1, 2...
      }));
  }

  load() {
    this.projectServ.getAll().subscribe((data) => {
      this.projects.set(data)
    })
    this.tagServ.GetAll(this.localStorageServ.getItem('token')).subscribe((data) => {
      this.tags.set(data)
    })
  }

  toggleTag(tagId: number) {
    const isOriginallySelected = this.selectedProject().tags.some(t => t.id === tagId);

    if (isOriginallySelected) {
      if (this.shouldRemoveTagIds().includes(tagId)) {
        this.shouldRemoveTagIds.update(ids => ids.filter(id => id !== tagId));
      } else {
        this.shouldRemoveTagIds.update(ids => [...ids, tagId]);
      }
    } else {
      if (this.shouldAddTagIds().includes(tagId)) {
        this.shouldAddTagIds.update(ids => ids.filter(id => id !== tagId));
      } else {
        this.shouldAddTagIds.update(ids => [...ids, tagId]);
      }
    }
  }

  visibleSelectedTags = computed(() => {
    return this.tags().filter(tag =>
      (
        this.selectedProject().tags.some(t => t.id === tag.id) ||
        this.shouldAddTagIds().includes(tag.id)
      ) &&
      !this.shouldRemoveTagIds().includes(tag.id)
    );
  });

  saveProject() {
    const token = this.localStorageServ.getItem('token');
    const requests: Observable<any>[] = [];

    if (this.editMode()) {
      // 1. Add the main project update (title, theme, etc.) to the queue
      requests.push(this.projectServ.update(token, this.selectedProject().id, this.selectedProject()))

      // 2. Add tag additions
      this.shouldAddTagIds().forEach(tagId => {
        requests.push(this.projectServ.addTag(token, this.selectedProject().id, tagId));
      });

      // 3. Add tag removals
      this.shouldRemoveTagIds().forEach(tagId => {
        requests.push(this.projectServ.removeTag(token, this.selectedProject().id, tagId));
      });
    }

    if (requests.length === 0) {
      this.finalizeSave();
      return;
    }

    // Execute everything in parallel and wait for all to finish
    forkJoin(requests).subscribe({
      next: (res) => {
        this.toastServ.show('Project and tags updated successfully', 'success');
        this.finalizeSave();
      },
      error: (err) => {
        const msg = err.error?.message || 'Failed to update project';
        this.toastServ.show(msg, 'error');
        this.finalizeSave();
      }
    });
  }

  finalizeSave() {
    this.addMode.set(false);
    this.editMode.set(false);
    this.shouldAddTagIds.set([]);
    this.shouldRemoveTagIds.set([]);
    this.load();
  }
}
