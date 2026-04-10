import { Injectable } from '@angular/core';
import { ProjectThemes } from '../models/project';

@Injectable({
  providedIn: 'root',
})
export class ProjectThemeService {
  public gradients: Record<ProjectThemes, string> = {
    [ProjectThemes.Orange]: 'linear-gradient(135deg,#FDE8D8,#F9C4A1)',
    [ProjectThemes.Blue]: 'linear-gradient(135deg,#D4EAF9,#A8D4F5)',
    [ProjectThemes.Green]: 'linear-gradient(135deg,#D5F5E3,#A9DFC7)',
  };
}
