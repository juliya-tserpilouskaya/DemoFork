import { Component, OnInit, SkipSelf } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(@SkipSelf() private authService: AuthService, fb: FormBuilder) {
    this.loginForm = fb.group({
      name: [''],
      password: ['']
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const data = this.loginForm.value;
      this.authService.login(data.name, data.password);
    }
  }

}
