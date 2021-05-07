import { Pipe, PipeTransform } from '@angular/core';
import { ItemType } from '../models/item-type.model';

@Pipe({
  name: 'itemType'
})
export class ItemTypePipe implements PipeTransform {

  transform(value: ItemType[], ...args: unknown[]): string {
    return `(${value.map(v => v.name).join(', ')})`;
  }

}
