import { Component } from '@angular/core';
import { ThemeService } from '../../services/theme-service';

@Component({
  standalone: true,
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  constructor(public themeService: ThemeService){}
}
