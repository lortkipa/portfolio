import { Component, Renderer2, signal } from '@angular/core';
import { Router, RouterOutlet, RouterLink } from "@angular/router";
import { Sidebar } from "./sidebar/sidebar";
import { Header } from "./header/header";
import { LocalStorageService } from '../../services/local-storage-service';
import { Footer } from "../home/footer/footer";
import { Toast } from './toast/toast';
import { ToastService } from '../../services/toast-service';

@Component({
  standalone: true,
  selector: 'app-admin-panel',
  imports: [Sidebar, Header, RouterOutlet, RouterLink, Footer, Toast],
  templateUrl: './admin-panel.html',
  styleUrl: './admin-panel.scss',
})
export class AdminPanel {
  pageTitle = 'Dashboard';
  
  sidebarOpen = false;

  constructor(private toastServ: ToastService, private localStorage: LocalStorageService, private renderer: Renderer2, private router: Router) {
    if (!this.localStorage.getItem('token'))
      this.router.navigate(['/authorization'])
  }

  ngOnInit() {
    this.renderer.addClass(document.body, 'dashboard-page');
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'dashboard-page');
  }

  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }

  closeSidebar() {
    this.sidebarOpen = false;
  }
}