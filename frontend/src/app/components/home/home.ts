import { Component } from '@angular/core';
import { Hero } from "../hero/hero";
import { Skills } from "../skills/skills";
import { Projects } from "../projects/projects";
import { Contact } from "../contact/contact";

@Component({
  standalone: true,
  selector: 'app-home',
  imports: [Hero, Skills, Projects, Contact],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {}
