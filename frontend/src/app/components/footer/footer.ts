import { Component, effect, ElementRef, inject, signal } from '@angular/core';
import { Globals } from '../../services/globals';
import { UserProfileModel } from '../../models/user';
import { UserService } from '../../services/user-service';

@Component({
  standalone: true,
  selector: 'app-footer',
  imports: [],
  templateUrl: './footer.html',
  styleUrl: './footer.scss',
})
export class Footer {
  
  year = signal<number>(0)

  profile = signal<UserProfileModel | null>(null);

  constructor(private userServ: UserService){
    this.year.set(new Date().getFullYear())

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
}
