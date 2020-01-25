import { Component } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { Message } from 'primeng/api';

@Component({
  selector: 'app-confirmationdialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: [ './confirm-dialog.component.scss' ],
  providers: [ ConfirmationService ]
})
export class ConfirmationDialogComponent {

msgs: Message[] = [];

constructor(private confirmationService: ConfirmationService) {}

confirm(
  cHeader: string,
  cMessage: string,
  cAccept: CallableFunction,
  cReject: CallableFunction = null) {
    this.confirmationService.confirm({
        header: cHeader,
        message: cMessage,
        icon: 'pi pi-info-circle',
        accept: () => {
          cAccept();
          this.msgs = [{severity: 'info', summary: 'Confirmed', detail:'Record deleted'}];
        },
        reject: () => {
           cReject();
           this.msgs = [{severity: 'info', summary: 'Rejected', detail:'You have rejected'}];
        }
    });
}
}
