export class ItemType {
    public id: string;
    public name: string;
    public group: string;

    constructor(id: string, name: string, group: string) 
    {
        this.id = id;
        this.name  = name;
        this.group = group;
    }
}