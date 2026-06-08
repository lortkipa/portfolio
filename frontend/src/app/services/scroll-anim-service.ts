import { ElementRef, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ScrollAnimService {
  init(el: ElementRef) {
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('visible');
        }
      });
    }, { threshold: 0.1 });

    el.nativeElement
      .querySelectorAll('.animate-on-scroll')
      .forEach((item: HTMLElement) => observer.observe(item));

    const glitch = el.nativeElement.querySelector('.glitch');

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
