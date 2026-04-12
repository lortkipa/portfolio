import { Component, signal } from '@angular/core';
import { MsgService } from '../../../services/msg-service';
import { LocalStorageService } from '../../../services/local-storage-service';
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
  messages = signal<MsgModel[]>([]);
  selectedMsg = signal<MsgModel | null>(null);
  isOpen = signal(false);

  constructor(
    private localStorageServ: LocalStorageService,
    private msgServ: MsgService
  ) {
    this.msgServ.getAll(this.localStorageServ.getItem('token')).subscribe({
      next: (data) => this.messages.set(data.reverse()),
      error: () => {}
    });
  }

  openMsg(msg: MsgModel) {
  const updated = {
    ...msg,
    isSeen: true
  };

  // 1. update list immutably (IMPORTANT for Angular signals)
  this.messages.update(list =>
    list.map(m => m.id === msg.id ? updated : m)
  );

  // 2. set selected AFTER update
  this.selectedMsg.set(updated);

  // 3. open modal AFTER state sync
  queueMicrotask(() => {
    this.isOpen.set(true);
  });
}

  close() {
    this.isOpen.set(false);
    this.selectedMsg.set(null);
  }
}