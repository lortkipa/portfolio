import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  message = signal('');
  type = signal<'success' | 'error' | 'info'>('success');
  visible = signal(false);

  show(
    message: string,
    type: 'success' | 'error' | 'info' = 'success'
  ) {
    this.message.set(message);
    this.type.set(type);
    this.visible.set(true);

    setTimeout(() => {
      this.visible.set(false);
    }, 3000);
  }

  hide() {
    this.visible.set(false);
  }
}