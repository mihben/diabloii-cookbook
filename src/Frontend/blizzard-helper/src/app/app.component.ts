import { Component } from '@angular/core';
import { LoadingScreen } from './shared/models/loading-screen.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'blizzard-helper';

  images: Array<LoadingScreen> = [
    { name: "Andariel", message: "Die, maggot!" },
    { name: "Duriel", message: "Looking for Baal!?" },
    { name: "Mephisto", message: "Cursed am I to lead an army of the blind; they do not perceive that the angels are fleeing this realm, and the ones they find are merely trapped or lost! A great change is upon us; withdraw from the fields, my brothers... ... some battles can only won with words..." },
    { name: "Diablo", message: "Not even death can save you from me!" },
    { name: "Baal", message: "Enough of your idle speculation, Mephisto! I breached the fortress and saw it firsthand: the Worldstone is GONE! The angels I killed knew nothing about it. But since you are so perceptive, maybe you remember who else has been missing: Lilith - we must find her, rip her limb from limb, take the Worldstone BACK!" }
  ]

}