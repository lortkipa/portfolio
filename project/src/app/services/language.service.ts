import { Injectable } from '@angular/core';
import {Language} from '../models/language';
import {LocalStorageService} from './local-storage.service';

@Injectable({
  providedIn: 'root'
})

export class LanguageService {

  constructor(private localStorage : LocalStorageService) {
    this.language = this.localStorage.get("language") ? this.localStorage.get("language") : Language.English
    console.log(this.language)
  }

  language : Language = Language.English;

  get() : Language {
    return this.language;
  }

  swich() : void {
    this.language = this.language == Language.English ? Language.Georgian : Language.English
    this.localStorage.set("language", this.language)
  }
}
