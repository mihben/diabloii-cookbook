import { Skill } from "./skill.model";

export class Property {
    description: string;
    skill: Skill | undefined;

    constructor(description: string, skill: Skill) {
        this.description = description;
        this.skill = skill;
    }
}