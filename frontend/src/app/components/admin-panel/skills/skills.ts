import { Component, computed, signal } from '@angular/core';
import { SkillsService } from '../../../services/skills-service';
import { SkillModel } from '../../../models/skill';
import { forkJoin, of, single, switchMap } from 'rxjs';
import { signalGetFn } from '@angular/core/primitives/signals';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TagModel } from '../../../models/tag';
import { TagService } from '../../../services/tag-service';
import { ToastService } from '../../../services/toast-service';
import { LocalStorageService } from '../../../services/local-storage-service';

@Component({
  standalone: true,
  selector: 'app-skills',
  imports: [CommonModule, FormsModule],
  templateUrl: './skills.html',
  styleUrl: './skills.scss',
})
export class Skills {
  tagSearch = signal('');
  filteredTags = computed(() => {
    const q = this.tagSearch().toLowerCase().trim();

    if (!q) return this.tags();

    return this.tags().filter(tag =>
      tag.name.toLowerCase().includes(q)
    );
  });

  visibleSelectedTags = computed(() => {
    return this.tags().filter(tag =>
      (
        this.selectedSkill().tags.some(t => t.id === tag.id) ||
        this.shouldAddTagIds().includes(tag.id)
      ) &&
      !this.shouldRemoveTagIds().includes(tag.id)
    );
  });

  addMode = signal<boolean>(false)
  editMode = signal<boolean>(false)

  tags = signal<TagModel[]>([])
  shouldAddTagIds = signal<number[]>([])
  shouldRemoveTagIds = signal<number[]>([])

  skills = signal<SkillModel[]>([])
  selectedSkill = signal<SkillModel>({
    id: 0,
    icon: '',
    title: '',
    tags: []
  })

  constructor(private localStorageServ: LocalStorageService, private skillServ: SkillsService, private tagServ: TagService, private toastServ: ToastService) {
    this.load()
  }

  load() {
    this.skillServ.getAll().subscribe((data) => {
      this.skills.set(data)
    })
    this.tagServ.GetAll(this.localStorageServ.getItem('token')).subscribe((data) => {
      this.tags.set(data)
    })
  }

  saveSkill() {
    const token = this.localStorageServ.getItem('token');
    const skill = this.selectedSkill();

    if (this.editMode()) {
      const updateReq = this.skillServ.update(token, skill.id, skill);
      const addTagReqs = this.shouldAddTagIds().map(id =>
        this.skillServ.addTag(token, skill.id, id)
      );
      const removeTagReqs = this.shouldRemoveTagIds().map(id =>
        this.skillServ.removeTag(token, skill.id, id)
      );

      forkJoin([updateReq, ...addTagReqs, ...removeTagReqs]).subscribe({
        next: () => {
          this.toastServ.show('Skill updated', 'success');
          this.finalizeSave(); // ✅ MOVE HERE
        },
        error: () => this.toastServ.show('Failed to update skill', 'error')
      });

    } else {
      this.skillServ.add(token, skill).pipe(
        switchMap((newSkill) => {
          const tagReqs = this.shouldAddTagIds().map(id =>
            this.skillServ.addTag(token, newSkill.id, id)
          );

          return tagReqs.length > 0 ? forkJoin(tagReqs) : of(newSkill);
        })
      ).subscribe({
        next: () => {
          this.toastServ.show('Skill added', 'success');
          this.finalizeSave(); // ✅ MOVE HERE
        },
        error: () => this.toastServ.show('Failed to add skill', 'error')
      });
    }
  }

  removeSkill(id: number) {
    this.skillServ.delete(this.localStorageServ.getItem('token'), id).subscribe({
      next: () => {
        this.toastServ.show('Skill removed', 'success');
        this.finalizeSave();
      },
      error: () => this.toastServ.show('Failed to remove skill', 'error')
    });
  }

  toggleTag(tagId: number) {
    const isOriginallySelected = this.selectedSkill().tags.some(t => t.id === tagId);

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

  finalizeSave() {
    this.addMode.set(false);
    this.editMode.set(false);
    this.shouldAddTagIds.set([]);
    this.shouldRemoveTagIds.set([]);
    this.load();
  }
}
