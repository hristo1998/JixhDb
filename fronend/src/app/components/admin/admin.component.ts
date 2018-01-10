import { Component, OnInit } from '@angular/core';

import { UserService } from '../../core/services/user/user.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  users: any;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAll().subscribe(
      res => {
        this.users = res;
        console.log(res);
      }
    );
  }

}
