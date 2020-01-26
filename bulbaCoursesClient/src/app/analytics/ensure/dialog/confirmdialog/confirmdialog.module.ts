import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessagesModule } from 'primeng/messages';
import { TabViewModule } from 'primeng/tabview';
import { CodeHighlighterModule } from 'primeng/codehighlighter';
import { ButtonModule} from 'primeng/button';

@NgModule({
  imports: [
    CommonModule,
    ConfirmDialogModule,
    ButtonModule,
    MessagesModule,
    TabViewModule,
    CodeHighlighterModule
  ]
})
export class ConfirmationDialogModule {}
