import { TagModel } from "./tag";

export enum ProjectThemes {
    Orange = 1,
    Blue,
    Green
}

export interface ProjectModel {
    id: number,
    icon: string,
    title: string,
    desc: string,
    theme: ProjectThemes,
    githubLink: string,
    demoLink: string,
    tags: TagModel[]
}