import { isNull } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { Property } from 'src/shared/models/property.model';
import { RuneWord } from 'src/shared/models/runeWord.model';

@Component({
  selector: 'app-rune-word',
  templateUrl: './rune-word.component.html',
  styleUrls: ['./rune-word.component.scss']
})
export class RuneWordComponent {
  @Input() runeWord: RuneWord | undefined;
  @Input() targetLevel: number = 0;

  constructor() { }

  isAdaptable() : string {
    if (this.runeWord != undefined && this.targetLevel >= this.runeWord?.level) return "white";
    else return "red"
  }

  getPropertyDescription(property: Property)
  {
    var description = property.description;
    if (property.skill != null)
    {
      description = description.replace('{skill}', `<span class="skill">${property.skill.name}</span>`);
      console.log(description);
    }

    return description;
  }

  getItemTypesDisplayString(): string | undefined{
    return this.runeWord?.itemTypes.map(it => it.name).join(', ');
  }
}
