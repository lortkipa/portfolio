import { Component, AfterViewInit, ElementRef, inject, signal } from '@angular/core';
import { Globals } from '../../../services/globals';
import { UserService } from '../../../services/user-service';
import { UserProfileModel } from '../../../models/user';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [],
  templateUrl: './hero.html',
  styleUrl: './hero.scss',
})
export class Hero implements AfterViewInit {
  profile = signal<UserProfileModel>({
    id: 0,
    contact: {
      id: 0,
      email: '',
      location: '',
      phoneNumber: '',
      githubLink: '',
      linkedinLink: ''
    },
    about: {
      id: 0,
      fullName: '',
      jobTitle: '',
      bio: '',
      statusBadge: '',
      funBadge: ''
    }
  })

  constructor(private userServ: UserService) {
    this.userServ.getProfile().subscribe((data) => {
      this.profile.set(data)
    })
  }

  // Inject ElementRef to safely access the component's DOM
  private el = inject(ElementRef);

  ngAfterViewInit(): void {
    this.initRevealObserver();
  }

  private initRevealObserver(): void {
    const revealElements = this.el.nativeElement.querySelectorAll('.reveal');

    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            entry.target.classList.add('visible');
            observer.unobserve(entry.target);
          }
        });
      },
      { threshold: 0.12 }
    );

    revealElements.forEach((element: HTMLElement) => observer.observe(element));
  }
}