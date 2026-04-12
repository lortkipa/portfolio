import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { MsgModel } from '../models/message';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MsgService {
  constructor(private globals: Globals, private http: HttpClient) { }

  getAll(token: string): Observable<MsgModel[]> {
    return this.http.get<MsgModel[]>(`${this.globals.apiUrl()}/Message/GetAll`,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  send(data: MsgModel): Observable<MsgModel> {
    return this.http.post<MsgModel>(`${this.globals.apiUrl()}/Message/Send`, data)
  }
}
