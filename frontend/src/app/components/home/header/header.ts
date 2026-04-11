import { CommonModule } from '@angular/common';
import { Component, effect, ElementRef, inject, OnInit, signal } from '@angular/core';
import { Globals } from '../../../services/globals';
import { UserService } from '../../../services/user-service';
import { UserProfileModel } from '../../../models/user';

@Component({
  standalone: true,
  selector: 'app-header',
  templateUrl: './header.html',
  styleUrls: ['./header.scss'],
  imports: [CommonModule], // note: 'styleUrls' plural
})
export class Header {

  firstName = signal<string>(' ')
  profile = signal<UserProfileModel | null>(null);

  constructor(private userServ: UserService) {
    this.userServ.getProfile().subscribe(data => {
      this.profile.set(data);
      this.firstName.set(data.about.fullName.split(' ')[0])
    });

    effect(() => {
      const currentProfile = this.profile();

      if (currentProfile) {
        setTimeout(() => this.setupObserver(), 0);
      }
    });
  }

  private el = inject(ElementRef);
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

  showMobileNavigation = signal<boolean>(false)

  toggleMobileNavigation() {
    this.showMobileNavigation.set(!this.showMobileNavigation());
  }

  // Close mobile navigation
  closeMenu() {
    this.showMobileNavigation.set(false);
  }
}