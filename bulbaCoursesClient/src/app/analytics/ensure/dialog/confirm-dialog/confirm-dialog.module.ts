import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ConfirmationDialogComponent} from './confirm-dialog.component';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ButtonModule} from 'primeng/button';
import {MessagesModule} from 'primeng/messages';
import {TabViewModule} from 'primeng/tabview';
import {CodeHighlighterModule} from 'primeng/codehighlighter';
import {RouterModule} from '@angular/router';
import {SplitButtonModule} from 'primeng/splitbutton';

@NgModule({
  imports: [
        CommonModule,
        ConfirmDialogModule,
        ButtonModule,
        MessagesModule,
        TabViewModule,
        CodeHighlighterModule,
        SplitButtonModule,
        RouterModule.forChild([
          {path: '', component: ConfirmationDialogComponent}
        ])
  ],
  exports: [
    RouterModule
  ],
  declarations: [
    ConfirmationDialogComponent
  ]
})
export class ConfirmationDialogModule {}
