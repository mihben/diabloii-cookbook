export class Character {
    id: string;
    class: string;
    name: string;
    level: number;
    isLadder: boolean;
    isExpansion: boolean;
    
    constructor(id: string, _class: string, name: string, level: number, isLadder: boolean, isExpansion: boolean) {
        this.id = id;
        this.class = _class;
        this.name = name;
        this.level = level;
        this.isLadder = isLadder;
        this.isExpansion = isExpansion;
     }
}