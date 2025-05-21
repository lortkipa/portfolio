import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';
import {Skill} from '../models/skill';
import {CommonModule} from '@angular/common';
import {project} from '../models/project';
import {LanguageService} from '../services/language.service';
import {Language} from '../models/language';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  constructor(public language : LanguageService){}

  names : string[] = []
  infos : string[] = []
  contactMes : string[] = []
  abilities : string[] = []
  projects : string[] = []
  viewWebs : string [] = []

  ngOnInit() {
    this.names[Language.English] = "Nikoloz Lortkipanidze"
    this.names[Language.Georgian] = "ნიკოლოზ ლორთქიფანიძე"

    this.infos[Language.English] =
    "I am Frontend and Graphics Developer, <br> Currently Studying in It Step Academy."
    this.infos[Language.Georgian] =
    "მე ვარ ფრონტენდ და გრაფიკული დეველოპერი, <br> და ამჟამინდელად ვსწავლობ It Step Academy-იაში."

    this.contactMes[Language.English] = "Contact Me"
    this.contactMes[Language.Georgian] = "დამეკონტაქტე"

    this.abilities[Language.English] = "Abilities"
    this.abilities[Language.Georgian] = "შესაძლებლობები"

    this.projects[Language.English] = "Projects"
    this.projects[Language.Georgian] = "პროექტები"

    this.viewWebs[Language.English] = "View Website"
    this.viewWebs[Language.Georgian] = "საიტის ნახვა"
  }

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

  projectsArr : project[] = [
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
