import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TagModel } from '../models/tag';
import { ToastService } from './toast-service';
import { LocalStorageService } from './local-storage-service';
import { AuthResponseModel } from '../models/auth-response';

@Injectable({
  providedIn: 'root',
})
export class TagService {
  constructor(private globals: Globals, private http: HttpClient) { }

  GetAll(token: string): Observable<TagModel[]> {
    return this.http.get<TagModel[]>(`${this.globals.apiUrl()}/Tag/GetAll`,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  add(token: string, data: TagModel) {
    return this.http.post<TagModel>(`${this.globals.apiUrl()}/Tag/Add`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  update(token: string, id: number, data: TagModel): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Tag/Update/${id}`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  remove(token: string, id: number): Observable<AuthResponseModel> {
    return this.http.delete<AuthResponseModel>(`${this.globals.apiUrl()}/Tag/Delete/${id}`,
      { headers: { Authorization: `Bearer ${token}` } })
  }
}
