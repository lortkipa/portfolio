import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { AdminPanel } from './components/admin-panel/admin-panel';
import { Authorization } from './components/authorization/authorization';
import { Dashboard } from './components/admin-panel/dashboard/dashboard';
import { AboutMe } from './components/admin-panel/about-me/about-me';
import { Tags } from './components/admin-panel/tags/tags';
import { Skills } from './components/admin-panel/skills/skills';
import { Projects } from './components/admin-panel/projects/projects';
import { Messages } from './components/admin-panel/messages/messages';
import { Settings } from './components/admin-panel/settings/settings';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: Home
    },
    {
        path: 'authorization',
        component: Authorization
    },
    {
        path: 'admin-panel',
        component: AdminPanel,
        children: [
            {
                path: '',
                redirectTo: 'dashboard',
                pathMatch: 'full'
            },
            {
                path: 'dashboard',
                component: Dashboard
            },
            {
                path: 'about-me',
                component: AboutMe
            },
            {
                path: 'tags',
                component: Tags
            },
            {
                path: 'skills',
                component: Skills
            },
            {
                path: 'projects',
                component: Projects
            },
            {
                path: 'messages',
                component: Messages
            },
            {
                path: 'settings',
                component: Settings
            }
        ]
    },
];
