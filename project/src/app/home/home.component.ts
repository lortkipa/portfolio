import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';
import {Skill} from '../models/skill';
import {CommonModule} from '@angular/common';
import {project} from '../models/project';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  skills : Skill[] = [
    {
      name: "C",
      percentage: 96,
    },
    {
      name: "C++",
      percentage: 44,
    },
    {
      name: "JavaScript",
      percentage: 94,
    },
    {
      name: "TypeScript",
      percentage: 94,
    },
    {
      name: "Angular",
      percentage: 96,
    },
    {
      name: "Lua",
      percentage: 88,
    }
  ];

  projects : project[] = [
    {
      name : "Railway Tickets",
      photo : "railway.jpg",
      link : "https://effulgent-semifreddo-481d1c.netlify.app/home"
    },
    {
      name : "Ocean Pets",
      photo : "ocean.jpg",
      link : "https://unrivaled-creponne-532c0d.netlify.app"
    },
    {
      name : "Chef Dimitri 1",
      photo : "chef1.jpg",
      link : "https://resplendent-platypus-e623ee.netlify.app"
    },
    {
      name : "Chef Dimitri 2",
      photo : "chef2.jpg",
      link : "https://keen-tulumba-3d1d0c.netlify.app"
    },
    {
      name : "Calculator",
      photo : "calculator.jpg",
      link : "https://admirable-kulfi-c28586.netlify.app"
    },
  ];

  getSkillLevel(percentage : number) : string {
    if (percentage > 90)
      return "expert"
    else if (percentage > 80)
      return "advanced"
    else
      return "intermediate"
  }
}
