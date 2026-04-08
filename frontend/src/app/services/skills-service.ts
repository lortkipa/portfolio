import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SkillModel } from '../models/skill';

@Injectable({
  providedIn: 'root',
})
export class SkillsService {
  constructor(private globals : Globals, private http : HttpClient){}

  getAll() : Observable<SkillModel[]> {
    return this.http.get<SkillModel[]>(`${this.globals.apiUrl()}/Skill/GetAll`)
  }
}
