import { Component, ViewChild } from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap';
 
@Component({
  selector: 'demo-tabs-disabled',
  templateUrl: './mainvideo.component.html'
})
export class MainvideoComponent {
  @ViewChild('staticTabs', { static: false }) staticTabs: TabsetComponent;
 
  disableEnable() {
    this.staticTabs.tabs[2].disabled = !this.staticTabs.tabs[2].disabled;
  }
}