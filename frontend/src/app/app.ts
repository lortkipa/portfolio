import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { GridOverlay } from "./components/grid-overlay/grid-overlay";
import { Header } from "./components/header/header";
import { Hero } from "./components/hero/hero";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, GridOverlay, Header, Hero],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Nikoloz Lortkipanidze');
}
