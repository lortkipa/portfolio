import { CommonModule } from '@angular/common';
import { Component, OnInit, signal } from '@angular/core';
import { Globals } from '../../services/globals';

@Component({
  standalone: true,
  selector: 'app-header',
  templateUrl: './header.html',
  styleUrls: ['./header.scss'],
  imports: [CommonModule], // note: 'styleUrls' plural
})
export class Header {

  firstName = signal<string>(' ')

  constructor(private globals: Globals) {
    this.firstName.set(globals.fullName().split(' ')[0])
  }

  showMobileNavigation = signal<boolean>(false)

  toggleMobileNavigation() {
    this.showMobileNavigation.set(!this.showMobileNavigation());
  }

  // Close mobile navigation
  closeMenu() {
    this.showMobileNavigation.set(false);
  }
}