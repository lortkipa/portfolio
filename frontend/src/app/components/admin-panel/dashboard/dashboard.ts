import { Component, signal } from '@angular/core';
import { single } from 'rxjs';
import { LocalStorageService } from '../../../services/local-storage-service';
import { UserService } from '../../../services/user-service';
import { TagService } from '../../../services/tag-service';
import { ProjectService } from '../../../services/project-service';
import { SkillsService } from '../../../services/skills-service';
import { MsgService } from '../../../services/msg-service';
import { MsgModel } from '../../../models/message';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-dashboard',
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {
  tagCount = signal<number>(0)
  skillCount = signal<number>(0)
  projectCount = signal<number>(0)
  msgCount = signal<number>(0)

  messages = signal<MsgModel[]>([])

  constructor(
    private localStorageServ: LocalStorageService,
    private userServ: UserService,
    private tagServ: TagService,
    private projectServ: ProjectService,
    private skillServ: SkillsService,
    private msgServ: MsgService) {
    const token = this.localStorageServ.getItem('token')

    this.tagServ.GetAll(token).subscribe({
      next: (data) => { this.tagCount.set(data.length) },
      error: () => { }
    })
    this.projectServ.getAll().subscribe({
      next: (data) => { this.projectCount.set(data.length) },
      error: () => { }
    })
    this.skillServ.getAll().subscribe({
      next: (data) => { this.skillCount.set(data.length) },
      error: () => { }
    })
    this.msgServ.getAll(token).subscribe({
      next: (data) => {
        this.msgCount.set(data.length);
        const last3 = [...data].reverse().slice(0, 3);
        this.messages.set(last3);
      },
      error: () => { }
    })
  }
}
