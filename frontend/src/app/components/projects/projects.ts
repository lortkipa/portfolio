import { CommonModule } from '@angular/common';
import { Component, AfterViewInit, ElementRef, inject, signal, effect } from '@angular/core';
import { ProjectModel, ProjectThemes } from '../../models/project';
import { ProjectService } from '../../services/project-service';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './projects.html',
  styleUrls: ['./projects.scss'],
})
export class Projects {
  projects = signal<ProjectModel[]>([]);
  private el = inject(ElementRef);

  gradients: Record<ProjectThemes, string> = {
    [ProjectThemes.Orange]: 'linear-gradient(135deg,#FDE8D8,#F9C4A1)',
    [ProjectThemes.Blue]: 'linear-gradient(135deg,#D4EAF9,#A8D4F5)',
    [ProjectThemes.Green]: 'linear-gradient(135deg,#D5F5E3,#A9DFC7)',
  };

  constructor(private projectServ: ProjectService) {
    // Fetch projects
    this.projectServ.getAll().subscribe((data) => this.projects.set(data));

    // Run observer after projects are set
    effect(() => {
      const currentProjects = this.projects();
      if (currentProjects.length > 0) {
        // Wait for DOM update
        setTimeout(() => this.setupObserver(), 0);
      }
    });
  }

  private setupObserver(): void {
    const revealElements = this.el.nativeElement.querySelectorAll('.reveal');
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            (entry.target as HTMLElement).classList.add('visible');
            observer.unobserve(entry.target);
          }
        });
      },
      { threshold: 0.1 }
    );

    revealElements.forEach((el: HTMLElement) => observer.observe(el));
  }
}