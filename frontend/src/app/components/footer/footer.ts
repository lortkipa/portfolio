import { Component, signal } from '@angular/core';
import { Globals } from '../../services/globals';

@Component({
  standalone: true,
  selector: 'app-footer',
  imports: [],
  templateUrl: './footer.html',
  styleUrl: './footer.scss',
})
export class Footer {
  
  year = signal<number>(0)

  constructor(public globals : Globals){
    this.year.set(new Date().getFullYear())
  }
}
