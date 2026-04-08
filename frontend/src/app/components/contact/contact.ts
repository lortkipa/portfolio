import { Component, AfterViewInit, ElementRef, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.html',
  styleUrl: './contact.scss',
})
export class Contact implements AfterViewInit {
  private el = inject(ElementRef);

  // Status signals
  public isSubmitting = signal(false);
  public showSuccess = signal(false);

  ngAfterViewInit(): void {
    const revealElements = this.el.nativeElement.querySelectorAll('.reveal');
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          (entry.target as HTMLElement).classList.add('visible');
          observer.unobserve(entry.target);
        }
      });
    }, { threshold: 0.1 });

    revealElements.forEach((el: HTMLElement) => observer.observe(el));
  }

  onSubmit(form: any): void {
    if (form.valid) {
      this.isSubmitting.set(true);

      // Simulate API call
      setTimeout(() => {
        this.isSubmitting.set(false);
        this.showSuccess.set(true);
        form.reset();

        // Hide success message after 5 seconds
        setTimeout(() => this.showSuccess.set(false), 5000);
      }, 1500);
    }
  }
}