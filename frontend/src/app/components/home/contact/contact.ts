import {
  Component,
  ElementRef,
  inject,
  signal,
  effect
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserProfileModel } from '../../../models/user';
import { UserService } from '../../../services/user-service';
import { MsgModel } from '../../../models/message';
import { single } from 'rxjs';
import { MsgService } from '../../../services/msg-service';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.html',
  styleUrls: ['./contact.scss']
})
export class Contact {

  private el = inject(ElementRef);

  isSubmitting = signal<boolean>(false);
  showSuccess = signal<boolean>(false);
  showError = signal<boolean>(false);

  msg = signal<MsgModel>({
    id: 0,
    fullName: '',
    email: '',
    subject: '',
    content: ''
  })

  profile = signal<UserProfileModel | null>(null);

  constructor(private userServ: UserService, private msgServ: MsgService) {

    this.userServ.getProfile().subscribe(data => {
      this.profile.set(data);
    });

    effect(() => {
      const currentProfile = this.profile();

      if (currentProfile) {
        setTimeout(() => this.setupObserver(), 0);
      }
    });
  }

  private setupObserver(): void {
    const revealElements =
      this.el.nativeElement.querySelectorAll('.reveal');

    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('visible');
          observer.unobserve(entry.target);
        }
      });
    }, { threshold: 0.1 });

    revealElements.forEach((el: HTMLElement) =>
      observer.observe(el)
    );
  }

  sendMsg(): void {
    this.isSubmitting.set(true);

    this.msgServ.send(this.msg()).subscribe({
      next: () => {
        this.showSuccess.set(true)
        this.msg.set({
          id: 0,
          fullName: '',
          email: '',
          subject: '',
          content: ''
        })
        setTimeout(() => {
          this.isSubmitting.set(false)
          this.showSuccess.set(false);
        }, 5000);
      },
      error: () => {
        this.showError.set(true)
         this.msg.set({
          id: 0,
          fullName: '',
          email: '',
          subject: '',
          content: ''
        })
        setTimeout(() => {
          this.isSubmitting.set(false)
          this.showError.set(false);
        }, 5000);
      }
    })
  }
}