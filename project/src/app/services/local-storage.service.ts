import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  set (key : string, value : any) : void {
    localStorage.setItem(key,value)
  }

  get(key : string) : any {
    return localStorage.getItem(key)
  }
}
