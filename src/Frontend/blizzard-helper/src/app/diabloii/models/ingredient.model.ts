import { Rune } from "src/app/shared/models/rune.model";

export class Ingredient {
    public id: string;
    public order: number;
    public rune: Rune;

    constructor(id: string, order: number, rune: Rune) {
        this.id = id;
        this.order = order;
        this.rune = rune;
    }
}