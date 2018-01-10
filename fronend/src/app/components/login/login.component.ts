import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from "@angular/router";
import { Observable } from 'rxjs/Observable';

import { LoginUser } from '../../core/models/auth/LoginUser';
import { AuthService } from '../../core/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: LoginUser;
  formGroup: FormGroup;
  error: string;

  constructor(private authService: AuthService,
    private router: Router) { }

  login() {
    var result = this.authService.login(this.user);
    console.log(result);
  }

  ngOnInit() {
    this.user = new LoginUser();

    this.formGroup = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.pattern(/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/)
      ]),
      password: new FormControl('', [
        Validators.required
      ])
    });
  }

}
