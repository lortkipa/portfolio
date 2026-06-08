import { Component, ElementRef } from '@angular/core';
import { ScrollAnimService } from '../../services/scroll-anim-service';

@Component({
  standalone: true,
  selector: 'app-services',
  imports: [],
  templateUrl: './services.html',
  styleUrl: './services.scss',
})
export class Services {
  constructor(private el: ElementRef, private scrollAnimService: ScrollAnimService) { }

  ngAfterViewInit() {
    this.scrollAnimService.init(this.el)
  }
}
