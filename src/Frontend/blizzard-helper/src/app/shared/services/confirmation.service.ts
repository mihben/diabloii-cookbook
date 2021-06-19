import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { ConfirmationComponent } from '../components/confirmation/confirmation.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmationService {

  constructor(private dialog: MatDialog) { }

  confirm(message: string) : Observable<boolean> {
    let dialogReference = this.dialog.open(ConfirmationComponent);

    dialogReference.componentInstance.message = message;
    dialogReference.componentInstance.yes = () => dialogReference.close(true);
    dialogReference.componentInstance.no = () => dialogReference.close(false);

    return dialogReference.afterClosed();
  }
}