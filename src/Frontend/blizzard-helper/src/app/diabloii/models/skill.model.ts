export class Skill {
    public name: string;
    public class: string;
    public description: string;

    constructor(name: string, _class: string, description: string) {
        this.name = name;
        this.class = _class;
        this.description = description;
    }
}