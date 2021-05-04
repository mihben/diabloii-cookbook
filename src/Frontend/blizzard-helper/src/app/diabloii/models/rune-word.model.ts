import { Ingredient } from './ingredient.model';
import { ItemType } from './item-type.model';
import { Property } from './property.model';

export class RuneWord {
    public id: string;
    public name: string;
    public level: number;
    public isLadder: boolean;
    public ingredients: Ingredient[];
    public properties: Property[];
    public itemTypes: ItemType[];

    constructor(id: string, name: string, level: number, isLadder: boolean, ingredients: Ingredient[], properties: Property[], itemTypes: ItemType[]) {
        this.id = id;
        this.name = name;
        this.level = level;
        this.isLadder = isLadder;
        this.ingredients = ingredients;
        this.properties = properties;
        this.itemTypes = itemTypes;
    }
}