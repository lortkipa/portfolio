import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { AboutModel, ContactModel, LoginUserModel, UserProfileModel } from '../models/user';
import { Observable } from 'rxjs';
import { AuthResponseModel } from '../models/auth-response';
import { AboutMe } from '../components/admin-panel/about-me/about-me';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private globals: Globals, private http: HttpClient) { }

  getProfile(): Observable<UserProfileModel> {
    return this.http.get<UserProfileModel>(`${this.globals.apiUrl()}/User/Profile`)
  }

  Login(data: LoginUserModel): Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.globals.apiUrl()}/User/Login`, data)
  }

  updateContact(token: string, contactId: number, data: ContactModel): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/User/UpdateProfileContact/${contactId}`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  updateAbout(token: string, aboutId: number, data: AboutModel): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/User/UpdateProfileAbout/${aboutId}`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }
}
