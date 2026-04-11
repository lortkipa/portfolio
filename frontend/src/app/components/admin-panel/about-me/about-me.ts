import { Component, signal } from '@angular/core';
import { UserService } from '../../../services/user-service';
import { UserProfileModel } from '../../../models/user';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastService } from '../../../services/toast-service';
import { LocalStorageService } from '../../../services/local-storage-service';

@Component({
  standalone: true,
  selector: 'app-about-me',
  imports: [CommonModule, FormsModule],
  templateUrl: './about-me.html',
  styleUrl: './about-me.scss',
})
export class AboutMe {
  profile = signal<UserProfileModel>({
    id: 0,
    contact: {
      id: 0,
      email: '',
      location: '',
      phoneNumber: '',
      githubLink: '',
      linkedinLink: ''
    },
    about: {
      id: 0,
      fullName: '',
      jobTitle: '',
      bio: '',
      statusBadge: '',
      funBadge: ''
    }
  });

  constructor(private userServ : UserService, private toastServ: ToastService, private localStorage: LocalStorageService) {
    this.userServ.getProfile().subscribe((data) => {
      this.profile.set(data)
    })
  }

  save() {
    if (!this.profile().about.fullName) {this.toastServ.show('Full name is empty', 'error'); return;}
    if (!this.profile().about.jobTitle) {this.toastServ.show('Job title is empty', 'error'); return;}
    if (!this.profile().about.bio) {this.toastServ.show('Bio is empty', 'error'); return;}
    if (!this.profile().about.statusBadge) {this.toastServ.show('Status badge is empty', 'error'); return;}
    if (!this.profile().about.funBadge) {this.toastServ.show('Fun badge is empty', 'error'); return;}

    this.userServ.updateAbout(this.localStorage.getItem('token'), this.profile().about.id, this.profile().about).subscribe({
      next: (res) => { this.toastServ.show('About info updated', 'success') },
      error: (err) => {this.toastServ.show('About info not updated', 'error')}
    })
  }
}
