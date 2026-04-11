import { Component, Renderer2 } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-not-found',
  imports: [RouterModule],
  templateUrl: './not-found.html',
  styleUrl: './not-found.scss',
})
export class NotFound {
   constructor(private renderer: Renderer2) {
  }

  ngOnInit() {
    this.renderer.addClass(document.body, 'error-page');
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'error-page');
  }
}
