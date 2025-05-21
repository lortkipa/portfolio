import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive} from '@angular/router';
import {LanguageService} from '../services/language.service';
import {Language} from '../models/language';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

  constructor(public language : LanguageService) {}

  home : string[] = []
  contact : string[] = []

  ngOnInit() {
    this.flag_paths[Language.Georgian] = "georgia.png"
    this.flag_paths[Language.English] = "britain.webp"

    this.home[Language.Georgian] = "მთავარი"
    this.home[Language.English] = "Home"

    this.contact[Language.Georgian] = "კონტაქტი"
    this.contact[Language.English] = "Contact"
  }

  flag_paths : string[] = [];

  changeLanguage() {
    this.language.swich()
  }

}
