import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { User } from '../../../core/models/auth/User';
import { UserService } from '../../../core/services/user/user.service';

@Component({
  selector: 'app-admin-user',
  templateUrl: './admin-user.component.html',
  styleUrls: ['./admin-user.component.css']
})
export class AdminUserComponent implements OnInit {
  
  user: User;

  constructor(private userService: UserService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    let id = this.route.snapshot.paramMap.get('id');
    this.userService.getUserById(id).subscribe(
      res => this.user = res
    );   
  }

  mark() {
    this.userService.markUser(this.user.id)
      .subscribe();
  }
  

  delete() {
    this.userService.delete(this.user.id)
      .subscribe();
    this.router.navigateByUrl('admin');
  }
}
