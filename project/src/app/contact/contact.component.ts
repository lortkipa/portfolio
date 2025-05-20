import { Component } from '@angular/core';
import {ApiService} from '../services/api.service';
import {User} from '../models/user';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {

  constructor(private api : ApiService) {}

  name ?: string;
  email ?: string;
  tel ?: number;

  registerContact() {

    if (this.name && this.email && this.tel) {
      let newUser : User = {
        name : this.name,
        email : this.email,
        telephone : this.tel
      }

      this.api.post("https://682ca1d04fae188947535444.mockapi.io/portfolio/Contact", newUser).subscribe(
        data => console.log(data)
      )
    }

  }
}
