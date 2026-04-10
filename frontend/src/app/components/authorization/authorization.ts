import { Component, Renderer2, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from "@angular/router";
import { UserService } from '../../services/user-service';
import { LocalStorageService } from '../../services/local-storage-service';

@Component({
  standalone: true,
  selector: 'app-authorization',
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './authorization.html',
  styleUrl: './authorization.scss',
})
export class Authorization {
  email = '';
  password = '';
  showPassword = false;
  showWarning = false;
  errorMessage = 'Please enter both email and password!';

  constructor(
    private renderer: Renderer2,
    private userServ: UserService,
    private cdr: ChangeDetectorRef,
    private localStorageServ : LocalStorageService,
    private router : Router
  ) {}

  ngOnInit() {
    this.renderer.addClass(document.body, 'auth-page');
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'auth-page');
  }

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  attemptLogin() {
    if (!this.email || !this.password) {
      this.errorMessage = 'Please enter both email and password!';
      this.triggerWarning();
      return;
    }

    const data = { email: this.email, password: this.password };

    this.userServ.Login(data).subscribe({
      next: (res) => {
        this.localStorageServ.setItem('token', res.message)
        this.router.navigate(['/admin-panel'])
      },
      error: (err) => {
        console.log('Login failed', err.error);
        this.errorMessage = 'Invalid email or password!';
        this.triggerWarning();
      }
    });
  }

  triggerWarning() {
    this.showWarning = true;
    this.cdr.detectChanges(); // <-- forces UI to update immediately

    setTimeout(() => {
      this.showWarning = false;
      this.cdr.detectChanges(); // <-- update again after timeout
    }, 5000);
  }
}