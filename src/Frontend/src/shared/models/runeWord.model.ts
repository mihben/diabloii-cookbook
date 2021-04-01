import { Ingredient } from "./ingredient.model";
import { ItemType } from "./itemType.model";
import { Property } from "./property.model";

export class RuneWord {
    name: string;
    level: number;
    ingredients: Ingredient[];
    properties: Property[];
    itemTypes: ItemType[];

    constructor(name: string, level: number, ingredients: Ingredient[], properties: Property[], itemTypes: ItemType[]) {
        this.name = name;
        this.level = level;
        this.ingredients = ingredients;
        this.properties = properties;
        this.itemTypes = itemTypes;
    }
}