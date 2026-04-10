import { CommonModule } from '@angular/common';
import { Component, AfterViewInit, ElementRef, inject, signal, effect } from '@angular/core';
import { ProjectModel, ProjectThemes } from '../../../models/project';
import { ProjectService } from '../../../services/project-service';
import { ProjectThemeService } from '../../../services/project-theme-service';

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

  constructor(public projectThemeServ : ProjectThemeService, private projectServ: ProjectService) {
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