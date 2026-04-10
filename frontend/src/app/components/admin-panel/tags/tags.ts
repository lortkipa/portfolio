import { Component, signal } from '@angular/core';
import { Globals } from '../../../services/globals';
import { HttpClient } from '@angular/common/http';
import { TagModel } from '../../../models/tag';
import { Observable } from 'rxjs';
import { Authorization } from '../../authorization/authorization';
import { TagService } from '../../../services/tag-service';
import { LocalStorageService } from '../../../services/local-storage-service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-tags',
  imports: [CommonModule, FormsModule],
  templateUrl: './tags.html',
  styleUrl: './tags.scss',
})
export class Tags {
  tags = signal<TagModel[]>([])

  constructor(private tagServ: TagService, private localStorageServ: LocalStorageService) {
    this.tagServ.GetAll(this.localStorageServ.getItem('token')).subscribe((data) => {
      this.tags.set(data)
    })
  }
}
