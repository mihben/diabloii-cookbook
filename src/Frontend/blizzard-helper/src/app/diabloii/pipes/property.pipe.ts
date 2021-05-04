import { Pipe, PipeTransform } from '@angular/core';
import { Property } from '../models/property.model';

@Pipe({
  name: 'property',
  pure: true
})
export class PropertyPipe implements PipeTransform {

  transform(value: Property, ...args: unknown[]): string {
    if (value.skill) {
      return value.description.replace('{skill}', `<span class="skill">${value.skill.name}</span>`);
    }
    return value.description;
  }
}
