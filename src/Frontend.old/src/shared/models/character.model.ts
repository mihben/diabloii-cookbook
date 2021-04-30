import { Rune } from "./rune.model";

export class Character {
    id: string| undefined;
    class: string;
    name: string| undefined;
    level: number;
    isLadder: boolean;
    isExpansion: boolean;
    runes: Rune[];
    
    constructor(id: string, _class: string, name: string, level: number, isLadder: boolean, isExpansion: boolean, runes: Rune[]) {
        this.id = id;
        this.class = _class;
        this.name = name;
        this.level = level;
        this.isLadder = isLadder;
        this.isExpansion = isExpansion;
        this.runes = runes
     }
}