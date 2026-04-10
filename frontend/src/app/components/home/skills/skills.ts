import { CommonModule } from '@angular/common';
import { Component, AfterViewInit, ElementRef, inject, signal, effect } from '@angular/core';
import { SkillModel } from '../../../models/skill';
import { SkillsService } from '../../../services/skills-service';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './skills.html',
  styleUrls: ['./skills.scss'],
})

export class Skills {
  skills = signal<SkillModel[]>([]);
  private el = inject(ElementRef);

  constructor(private skillServ : SkillsService) {
    this.skillServ.getAll().subscribe((data) => {
      this.skills.set(data);
    });

    effect(() => {
      const currentSkills = this.skills(); 
      if (currentSkills.length > 0) {
        setTimeout(() => this.setupObserver(), 0);
      }
    });
  }

  private setupObserver(): void {
    const revealElements = this.el.nativeElement.querySelectorAll('.reveal');
    const observer = new IntersectionObserver((entries) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          (entry.target as HTMLElement).classList.add('visible');
          observer.unobserve(entry.target);
        }
      });
    }, { threshold: 0.12 });

    revealElements.forEach((el: HTMLElement) => observer.observe(el));
  }
}