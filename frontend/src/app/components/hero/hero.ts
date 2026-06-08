import { Component, ElementRef } from '@angular/core';

@Component({
  standalone: true,
  selector: 'app-hero',
  imports: [],
  templateUrl: './hero.html',
  styleUrl: './hero.scss',
})
export class Hero {
  constructor(private el: ElementRef) { }

  ngAfterViewInit() {
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('visible');
        }
      });
    }, { threshold: 0.1 });

    this.el.nativeElement
      .querySelectorAll('.animate-on-scroll')
      .forEach((el: HTMLElement) => observer.observe(el));

    const glitch = this.el.nativeElement.querySelector('.glitch');

    if (glitch) {
      setInterval(() => {
        glitch.style.setProperty(
          '--glitch-translate',
          `${Math.random() * 10 - 5}px`
        );
      }, 200);
    }
  }
}
