import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { Router, RouterLink, RouterModule } from "@angular/router";

@Component({
  selector: 'app-header',
  imports: [CommonModule, RouterModule],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  @Output() menuClick = new EventEmitter<void>();

  constructor(private router: Router) { }

  openPortfolio() {
    const url = this.router.serializeUrl(
      this.router.createUrlTree(['/home'])
    );

    window.open(url, '_blank');
  }
}
