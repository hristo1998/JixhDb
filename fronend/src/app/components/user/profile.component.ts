import { Component, OnInit } from '@angular/core';

import { UserService } from '../../core/services/user/user.service';
import { User } from '../../core/models/auth/User';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {

  user: User;

  constructor(private userService: UserService) { }

  ngOnInit() {
   this.userService.getUser()
    .subscribe(res => this.user = res);
  }  

}
