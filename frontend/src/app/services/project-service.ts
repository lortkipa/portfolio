import { Injectable } from '@angular/core';
import { Globals } from './globals';
import { HttpClient } from '@angular/common/http';
import { ProjectModel } from '../models/project';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  constructor(private globals : Globals, private http : HttpClient){}

  getAll() : Observable<ProjectModel[]> {
    return this.http.get<ProjectModel[]>(`${this.globals.apiUrl()}/Project/GetAll`)
  }
}
