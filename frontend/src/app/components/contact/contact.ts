import { Component, ElementRef } from '@angular/core';
import { ScrollAnimService } from '../../services/scroll-anim-service';

@Component({
  standalone: true,
  selector: 'app-contact',
  imports: [],
  templateUrl: './contact.html',
  styleUrl: './contact.scss',
})
export class Contact {
  constructor(private el: ElementRef, private scrollAnimService: ScrollAnimService) { }

  ngAfterViewInit() {
    this.scrollAnimService.init(this.el)
  }
}
