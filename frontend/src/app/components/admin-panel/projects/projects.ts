import { Component, computed, signal, ViewChild } from '@angular/core';
import { LocalStorageService } from '../../../services/local-storage-service';
import { ProjectService } from '../../../services/project-service';
import { ProjectModel, ProjectThemes } from '../../../models/project';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Observable, of, single, switchMap } from 'rxjs';
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
    const project = this.selectedProject();

    if (this.editMode()) {
      // 1. Update Project and Manage Tags in parallel
      const updateReq = this.projectServ.update(token, project.id, project);
      const addTagReqs = this.shouldAddTagIds().map(id => this.projectServ.addTag(token, project.id, id));
      const removeTagReqs = this.shouldRemoveTagIds().map(id => this.projectServ.removeTag(token, project.id, id));

      forkJoin([updateReq, ...addTagReqs, ...removeTagReqs]).subscribe({
        next: () => this.toastServ.show('Project updated', 'success'),
        error: (err) => this.toastServ.show('Failed to update project', 'error')
      });

    } else {
      // 2. Create Project FIRST, then add tags using the new ID
      this.projectServ.add(token, project).pipe(
        switchMap((newProject) => {
          const tagReqs = this.shouldAddTagIds().map(id =>
            this.projectServ.addTag(token, newProject.id, id)
          );
          // If no tags, just return the project
          return tagReqs.length > 0 ? forkJoin(tagReqs) : of(newProject);
        })
      ).subscribe({
        next: (data) => this.toastServ.show('Project added', 'success'),
        error: (err) => this.toastServ.show('Failed to add project', 'error')
      });
    }

    this.finalizeSave()
  }

  removeProject(id: number) {
    this.projectServ.remove(this.localStorageServ.getItem('token'), id).subscribe({
      next: () => {
        this.toastServ.show('Project removed', 'success')
        this.finalizeSave()
      },
      error: () => this.toastServ.show('Failed to remove project', 'error')
    })
  }

  finalizeSave() {
    this.addMode.set(false);
    this.editMode.set(false);
    this.shouldAddTagIds.set([]);
    this.shouldRemoveTagIds.set([]);
    this.load();
  }
}
