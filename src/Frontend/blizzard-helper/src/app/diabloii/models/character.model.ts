export class Character {
    public $class: string;
    public name: string;
    public level: number;
    public isExpansion: boolean;
    public isLadder: boolean;

    constructor($class: string, name: string, level: number, isExpansion: boolean, isLadder: boolean) {
        this.$class = $class
        this.name = name;
        this.level = level;
        this.isExpansion = isExpansion;
        this.isLadder = isLadder;
    }
}