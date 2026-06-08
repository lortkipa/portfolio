import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GridOverlay } from "./components/grid-overlay/grid-overlay";
import { Header } from "./components/header/header";
import { Hero } from "./components/hero/hero";
import { Services } from "./components/services/services";
import { Projects } from "./components/projects/projects";
import { Contact } from "./components/contact/contact";
import { Footer } from "./components/footer/footer";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, GridOverlay, Header, Hero, Services, Projects, Contact, Footer],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Nikoloz Lortkipanidze');
}
