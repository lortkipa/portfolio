import { TagModel } from "./tag";

export interface SkillModel {
    id: number;
    icon: string;
    title: string;
    tags: TagModel[];
}