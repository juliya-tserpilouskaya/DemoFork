import { Injectable } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { Message } from 'primeng/api';

@Injectable()
export class ConfirmationDialogService {

  constructor(private confirmationService: ConfirmationService) {
  }

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
          },
          reject: () => {
             cReject();
          }
      });
    }
}
