import { Component, OnInit } from '@angular/core';

import { RegisterUser } from '../../core/models/auth/RegisterUser';
import { UserService } from '../../core/services/users/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  user: RegisterUser;

  constructor(private userService: UserService) { }

  register() {
    console.log(this.user);
    this.userService.register(this.user)
    .subscribe(res => console.log(res),
    error=> console.log(error));
  }

  ngOnInit() {
    this.user = new RegisterUser();
  }

}
