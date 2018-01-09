import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from "@angular/router";

import { LoginUser } from '../../core/models/auth/LoginUser';
import { UserService } from '../../core/services/users/user.service';
import { Response } from '@angular/http/src/static_response';
import { Observable } from 'rxjs/Observable';
import { error } from 'util';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  user: LoginUser;
  formGroup: FormGroup;
  error: string;

  constructor(private userService: UserService,
    private router: Router) { }

  login() {
    var result = this.userService.login(this.user);
    if (result) {
      this.router.navigate(['/home']);
    }
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
