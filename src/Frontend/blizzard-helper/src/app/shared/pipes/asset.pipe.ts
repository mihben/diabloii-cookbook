import {  Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'asset'
})
export class AssetPipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    return `..\\..\\..\\assets\\${args[0]}\\${value.toLowerCase()}.${args[1]}`;
  }

}
