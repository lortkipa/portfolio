import { Component } from '@angular/core';
import {ApiService} from '../services/api.service';
import {User} from '../models/user';
import {FormsModule} from '@angular/forms';
import {AlertService} from '../services/alert.service';
import {Router} from '@angular/router';
import {LanguageService} from '../services/language.service';
import {Language} from '../models/language';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent {

  link_linkedIn : string = "https://www.linkedin.com/in/nikoloz-lortkipanidze-2b4263329/"
  link_instagram : string = "https://www.instagram.com/nikolozlortki/"
  link_facebook : string = "https://www.facebook.com/nikas.channel/"

  contactForms : string[] = []
  submits : string[] = []
  placeholder_name : string[] = []
  placeholder_email : string[] = []
  placeholder_tel : string[] = []

  constructor(private api : ApiService, private alert : AlertService, private route : Router,
             public language : LanguageService) {}

  ngOnInit() {
    this.contactForms[Language.English] = "Contact Form"
    this.contactForms[Language.Georgian] = "საკონტაქტო ფორმა"

    this.submits[Language.English] = "Submit"
    this.submits[Language.Georgian] = "გაგზავნა"

    this.placeholder_name[Language.English] = "Name"
    this.placeholder_name[Language.Georgian] = "სახელი"

    this.placeholder_email[Language.English] = "Email"
    this.placeholder_email[Language.Georgian] = "ელ. ფოსტა"

    this.placeholder_tel[Language.English] = "Telephone Number"
    this.placeholder_tel[Language.Georgian] = "ტელეფონის ნომერი"
  }

  name ?: string;
  email ?: string;
  tel ?: number;

  isValidEmail(): boolean {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return this.email ? emailRegex.test(this.email) : false;
  }


  registerContact() {

    if (this.name && this.email && this.tel) {
      // create user interface
      let newUser : User = {
        name : this.name,
        email : this.email,
        telephone : this.tel
      }

      // post the data
      this.api.post("https://682ca1d04fae188947535444.mockapi.io/portfolio/Contact", newUser).subscribe()

      // alert for success
      this.alert.success("Contact Has Been Sent")

      // cleanup
      this.name = undefined
      this.email = undefined
      this.tel = undefined

      // navigate to home page
      this.route.navigate(["/home"])
    }

  }
}
