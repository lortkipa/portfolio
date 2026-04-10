import { Component, Renderer2 } from '@angular/core';
import { Skills } from "./skills/skills";
import { Projects } from "./projects/projects";
import { Hero } from './hero/hero';
import { Contact } from './contact/contact';
import { Footer } from './footer/footer';
import { Header } from './header/header';


@Component({
  standalone: true,
  selector: 'app-home',
  imports: [Skills, Projects, Contact, Hero, Footer, Header],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {
  constructor(private renderer: Renderer2){}

  ngOnInit() {
    this.renderer.addClass(document.body, 'home-page')
  }

  ngOnDestroy() {
    this.renderer.removeClass(document.body, 'home-page')
  }
}
