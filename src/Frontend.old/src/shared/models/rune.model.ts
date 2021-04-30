export class Rune{
    id: string;
    name: string;
    order: number;
    level: number;
    inWeapon: string;
    inHelm: string;
    inArmor: string;
    inShield: string;

    constructor(id: string, name: string, order: number, level: number, inWeapon: string, inHelm: string, inArmor: string, inShield: string) {
        this.id = id;
        this.name = name;
        this.order = order;
        this.level = level;
        this.inWeapon = inWeapon;
        this.inHelm = inHelm;
        this.inArmor = inArmor;
        this.inShield = inShield;
    }
}