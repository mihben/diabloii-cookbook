import { Skill } from "./skill.model";

export class Property {
    public description: string;
    public skill: Skill;

    constructor(description: string, skill: Skill) {
        this.description = description;
        this.skill = skill;
    }
}