import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  private isLight = false;
  constructor() {
    this.initTheme();
  }

  initTheme() {
    const saved = localStorage.getItem('theme')
    this.isLight = saved === 'light'
    this.applyTheme()
  }

  toggleTheme() {
    this.isLight = !this.isLight;
    this.applyTheme();
    localStorage.setItem('theme', this.isLight ? 'light' : 'dark')
  }

  private applyTheme() {
    const body = document.body

    if (this.isLight) {
      body.classList.add('light-mode')
    } else {
      body.classList.remove('light-mode')
    }
  }

  get currentTheme() {
    return this.isLight ? 'light' : 'dark'
  }

}
