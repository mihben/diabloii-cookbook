import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'diabloiiClassicCharacterLevel'
})
export class DiabloiiClassicCharacterLevelPipe implements PipeTransform {

  transform(value: string, ...args: string[]): string {
    do {
      var level = value.match('\\d[.]?[\\d]*[*][C][l][v][l]');
      if (level) {
        level.forEach(l => value = value.replace(`(${l})`, Math.floor(eval(l.replace('Clvl', args[0])) as number).toString()));
      }
    } while (level)

    return value;
  }

}
