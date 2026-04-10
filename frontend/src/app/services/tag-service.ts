import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TagModel } from '../models/tag';

@Injectable({
  providedIn: 'root',
})
export class TagService {
  constructor(private globals: Globals, private http: HttpClient) { }

  GetAll(token: string): Observable<TagModel[]> {
    return this.http.get<TagModel[]>(`${this.globals.apiUrl()}/Tag/GetAll`,
      { headers: { Authorization: `Bearer ${token}` } })
  }
}
