import { Component, signal } from '@angular/core';
import { MsgService } from '../../../services/msg-service';
import { LocalStorageService } from '../../../services/local-storage-service';
import { single } from 'rxjs';
import { MsgModel } from '../../../models/message';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-messages',
  imports: [CommonModule],
  templateUrl: './messages.html',
  styleUrl: './messages.scss',
})
export class Messages {
  messages = signal<MsgModel[]>([])

  constructor(private localStorageServ: LocalStorageService, private msgServ: MsgService){
    this.msgServ.getAll(this.localStorageServ.getItem('token')).subscribe({
      next: (data) => { this.messages.set(data.reverse()) },
      error: (err) => {}
    })
  }
}
