import { Component, ElementRef } from '@angular/core';
import { ScrollAnimService } from '../../services/scroll-anim-service';

@Component({
  standalone: true,
  selector: 'app-projects',
  imports: [],
  templateUrl: './projects.html',
  styleUrl: './projects.scss',
})
export class Projects {
  constructor(private el: ElementRef, private scrollAnimService: ScrollAnimService) { }

  ngAfterViewInit() {
    this.scrollAnimService.init(this.el)
  }
}
