import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { RegisterUser } from '../../core/models/auth/RegisterUser';
import { AuthService } from '../../core/services/auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: RegisterUser;
  formGroup: FormGroup;

  constructor(private authService: AuthService) { }

  register() {
    let result = this.authService.register(this.user);
  }

  ngOnInit() {
    this.user = new RegisterUser();

    this.formGroup = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.pattern(/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/)
      ]),
      password: new FormControl('', [
        Validators.required
      ]),
      username: new FormControl('', [
        Validators.required
      ]),
      repeatPassword: new FormControl('', [
        Validators.required,
        Validators.pattern(this.user.Password)
      ])
    });
  }

}
