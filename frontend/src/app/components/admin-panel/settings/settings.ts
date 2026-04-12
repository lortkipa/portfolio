import { Component, signal } from '@angular/core';
import { UserService } from '../../../services/user-service';
import { LocalStorageService } from '../../../services/local-storage-service';
import { ToastService } from '../../../services/toast-service';
import { ContactModel } from '../../../models/user';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-settings',
  imports: [CommonModule, FormsModule],
  templateUrl: './settings.html',
  styleUrl: './settings.scss',
})
export class Settings {
  contact = signal<ContactModel>({
    id: 0,
    email: '',
    location: '',
    phoneNumber: '',
    githubLink: '',
    linkedinLink: ''
  })

  constructor(private localStorageServ: LocalStorageService, private toastServ: ToastService, private userServ: UserService) {
    this.userServ.getProfile().subscribe({
      next: (data) => { this.contact.set(data.contact) },
      error: (err) => { }
    })
  }

  saveSettings() {
    if (!this.contact().email) { this.toastServ.show('Email is empty', 'error'); return; }
    if (!this.contact().phoneNumber) { this.toastServ.show('Phone number is empty', 'error'); return; }
    if (!this.contact().linkedinLink) { this.toastServ.show('Linkedin link is empty', 'error'); return; }
    if (!this.contact().githubLink) { this.toastServ.show('Github link is empty', 'error'); return; }
    if (!this.contact().location) { this.toastServ.show('Location is empty', 'error'); return; }

    this.userServ.updateContact(this.localStorageServ.getItem('token'), this.contact().id, this.contact()).subscribe({
      next: (data) => { this.toastServ.show('Contact info updated', 'success') },
      error: (err) => { this.toastServ.show('Failed to update contact info', 'error') }
    })
  }
}
