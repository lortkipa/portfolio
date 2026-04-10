import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { LoginUserModel, UserProfileModel } from '../models/user';
import { Observable } from 'rxjs';
import { AuthResponseModel } from '../models/auth-response';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private globals : Globals, private http : HttpClient){}

  getProfile() : Observable<UserProfileModel> {
    return this.http.get<UserProfileModel>(`${this.globals.apiUrl()}/User/Profile`)
  }

  Login(data: LoginUserModel) : Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.globals.apiUrl()}/User/Login`, data)
  }
}
