import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { ProjectModel } from '../models/project';
import { Observable } from 'rxjs';
import { AuthResponseModel } from '../models/auth-response';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  constructor(private globals: Globals, private http: HttpClient) { }

  getAll(): Observable<ProjectModel[]> {
    return this.http.get<ProjectModel[]>(`${this.globals.apiUrl()}/Project/GetAll`)
  }

  update(token: string, id: number, data : ProjectModel): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Project/Update/${id}`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  addTag(token: string, projectId: number, tagId: number): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Project/AddTag/${projectId}`, tagId,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  removeTag(token: string, projectId: number, tagId: number): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Project/RemoveTag/${projectId}`, tagId,
      { headers: { Authorization: `Bearer ${token}` } })
  }
}
