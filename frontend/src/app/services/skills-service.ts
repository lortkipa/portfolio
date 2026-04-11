import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SkillModel } from '../models/skill';
import { AuthResponseModel } from '../models/auth-response';

@Injectable({
  providedIn: 'root',
})
export class SkillsService {
  constructor(private globals: Globals, private http: HttpClient) { }

  getAll(): Observable<SkillModel[]> {
    return this.http.get<SkillModel[]>(`${this.globals.apiUrl()}/Skill/GetAll`)
  }

  add(token: string, data: SkillModel): Observable<SkillModel> {
    return this.http.post<SkillModel>(`${this.globals.apiUrl()}/Skill/Add`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  update(token: string, id: number, data: SkillModel): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Skill/Update/${id}`, data,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  addTag(token: string, skillId: number, tagId: number): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Skill/AddTag/${skillId}`, tagId,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  removeTag(token: string, skillId: number, tagId: number): Observable<AuthResponseModel> {
    return this.http.put<AuthResponseModel>(`${this.globals.apiUrl()}/Skill/RemoveTag/${skillId}`, tagId,
      { headers: { Authorization: `Bearer ${token}` } })
  }

  delete(token: string, id: number): Observable<AuthResponseModel> {
    return this.http.delete<AuthResponseModel>(`${this.globals.apiUrl()}/Skill/Delete/${id}`,
      { headers: { Authorization: `Bearer ${token}` } })
  }
}
