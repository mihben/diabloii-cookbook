import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.scss']
})
export class ConfirmationComponent implements OnInit {

  message: string = '';
  yes: Function = () => { };
  no: Function = () => { };

  constructor() { }

  ngOnInit(): void {
  }

}
