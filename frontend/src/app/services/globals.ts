import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Globals {
  public fullName = signal<string>('Nikoloz Lortkipanidze')
  public apiUrl = signal<string>('https://localhost:7067/api')
  
}
