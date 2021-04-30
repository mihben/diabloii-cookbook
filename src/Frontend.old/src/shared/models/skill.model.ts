export class Skill {
    name: string;
    description: string;
    class: string;

    constructor(name: string, description: string, _class: string) {
        this.name = name;
        this.description = description;
        this.class = _class;
    }
}