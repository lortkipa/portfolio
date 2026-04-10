import { Component, AfterViewInit, ElementRef, inject, signal } from '@angular/core';
import { Globals } from '../../../services/globals';

@Component({
  selector: 'app-hero',
  standalone: true,
  imports: [],
  templateUrl: './hero.html',
  styleUrl: './hero.scss',
})
export class Hero implements AfterViewInit {
  role = signal<string>('Full‑Stack Developer')
  bio = signal<string>(`I design and build thoughtful digital products — from responsive
          interfaces to robust backend systems. Passionate about clean code,
          great UX, and technology that actually matters.`);
  badge1 = signal<string>('Open to work')
  badge2 = signal<string>('☕ Building cool things')

  constructor(public globals: Globals) {
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