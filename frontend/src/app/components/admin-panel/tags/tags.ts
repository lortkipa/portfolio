import { Component, computed, signal } from '@angular/core';
import { Globals } from '../../../services/globals';
import { HttpClient } from '@angular/common/http';
import { TagModel } from '../../../models/tag';
import { Observable, single } from 'rxjs';
import { Authorization } from '../../authorization/authorization';
import { TagService } from '../../../services/tag-service';
import { LocalStorageService } from '../../../services/local-storage-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastService } from '../../../services/toast-service';

@Component({
  standalone: true,
  selector: 'app-tags',
  imports: [CommonModule, FormsModule],
  templateUrl: './tags.html',
  styleUrl: './tags.scss',
})
export class Tags {
  searchInput = signal('');
  filteredTags = computed(() => {
    const q = this.searchInput().toLowerCase().trim();

    return !q
      ? this.tags()
      : this.tags().filter(tag =>
        tag.name.toLowerCase().includes(q)
      );
  });

  editMode = signal<boolean>(false)

  tags = signal<TagModel[]>([])
  addTagData = signal<TagModel>({
    id: 0,
    name: ''
  })
  updateTagData = signal<TagModel>({
    id: 0,
    name: ''
  })
  updateTagId = signal<number>(0)

  constructor(private tagServ: TagService, private localStorageServ: LocalStorageService, private toastServ: ToastService) {
    this.tagServ.GetAll(this.localStorageServ.getItem('token')).subscribe((data) => {
      this.tags.set(data)
    })
  }

  addTag() {
    if (!this.addTagData().name) {
      this.toastServ.show('Tag name is required', 'error')
      return;
    }

    this.tagServ.add(this.localStorageServ.getItem('token'), this.addTagData()).subscribe({
      next: (data) => {
        this.toastServ.show('Tag added', 'success');
        this.tags.update(tags => [...tags, data].sort((a, b) => a.name.localeCompare(b.name)));
      },
      error: (err) => { this.toastServ.show('Failed to add tag', 'error') }
    })
  }

  updateTag() {
    if (!this.updateTagData().name) {
      this.toastServ.show('Tag name is required', 'error')
      return;
    }

    this.tagServ.update(this.localStorageServ.getItem('token'), this.updateTagId(), this.updateTagData()).subscribe({
      next: (data) => {
        this.toastServ.show('Tag deleted', 'success')
        this.tags.update(tags =>
          tags.map(tag =>
            tag.id === this.updateTagId()
              ? { ...tag, ... { id: this.updateTagId(), name: this.updateTagData().name } }
              : tag
          )
        );
      },
      error: (err) => { this.toastServ.show('Failed to update tag', 'error') }
    })

    this.editMode.set(false)
  }

  removeTag(index: number) {
    this.tagServ.remove(this.localStorageServ.getItem('token'), this.tags()[index].id).subscribe({
      next: (data) => {
        this.toastServ.show('Tag deleted', 'success')
        this.tags.update(tags => tags.filter((_, i) => i !== index));
      },
      error: (err) => { this.toastServ.show('Failed to delete tag', 'error') }
    })
  }
}
