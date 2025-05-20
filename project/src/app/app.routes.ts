import { Routes } from '@angular/router';

export const routes: Routes = [

  { path: "", pathMatch: "full", redirectTo: "home" },

  {
    title: "home",
    path: "home",
    loadComponent: () => import("./home/home.component").then(m => m.HomeComponent)
  },

  {
    title: "contact",
    path: "contact",
    loadComponent: () => import("./contact/contact.component").then(m => m.ContactComponent)
  }

];
