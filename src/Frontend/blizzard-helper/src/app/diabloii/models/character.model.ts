import { Rune } from "src/app/shared/models/rune.model";
import { Filter } from "./filter.model";

export class Character {
    public id: string;
    public class: string;
    public name: string;
    public level: number;
    public isExpansion: boolean;
    public isLadder: boolean;
    public runes: Array<Rune>;
    public filter: Filter; 

    constructor(id: string, _class: string, name: string, level: number, isExpansion: boolean, isLadder: boolean, runes: Array<Rune>, filter: Filter) {
        this.id = id;
        this.class = _class
        this.name = name;
        this.level = level;
        this.isExpansion = isExpansion;
        this.isLadder = isLadder;
        this.runes = runes;
        this.filter = filter;
    }
}