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

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.html',
  styleUrls: ['./contact.scss']
})
export class Contact {

  private el = inject(ElementRef);

  isSubmitting = signal(false);
  showSuccess = signal(false);

  profile = signal<UserProfileModel | null>(null);

  constructor(private userServ: UserService) {

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

  onSubmit(form: any): void {
    if (!form.valid) return;

    this.isSubmitting.set(true);

    setTimeout(() => {
      this.isSubmitting.set(false);
      this.showSuccess.set(true);

      form.reset();

      setTimeout(() => {
        this.showSuccess.set(false);
      }, 5000);

    }, 1500);
  }
}