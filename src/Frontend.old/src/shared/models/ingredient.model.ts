import { Rune } from "./rune.model";

export class Ingredient {
    order: number;
    rune: Rune;

    constructor(order: number, rune: Rune) {
        this.order = order;
        this.rune = rune;
    }
}