import { Component, OnInit } from '@angular/core';
import { SampleService } from '../../services/sample.service';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-sample',
  templateUrl: './sample.component.html',
  styleUrls: ['./sample.component.scss']
})
export class SampleComponent implements OnInit {
  isAuthenticated: boolean;

  constructor(private sampleService: SampleService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((flag) => this.isAuthenticated = flag);
  }

}
