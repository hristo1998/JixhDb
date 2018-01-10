import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { UserService } from '../../core/services/user/user.service';
import { User } from '../../core/models/auth/User';

@Component({
    selector: 'app-edit-profile',
    templateUrl: './edit-profile.component.html',
})
export class EditProfileComponent implements OnInit {

    user: User = new User();
    showPasswordField: boolean = false;
    formGroup: FormGroup;

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.formGroup = new FormGroup({
            email: new FormControl('', [
              Validators.required,
              Validators.pattern(/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/)
            ]),
            userName: new FormControl('', [
              Validators.required
            ]),
            phoneNumber: new FormControl('', [
              Validators.required
            ]),
            age: new FormControl('', [
              Validators.required
            ]),
            gender: new FormControl('', [
              Validators.required
            ]),
            homeTown: new FormControl('', [
              Validators.required
            ]),
            password: new FormControl('', [
              Validators.required
            ])
          });
        this.userService.getUser()
            .subscribe(res => this.user = res);
    }

    edit() {
        console.log(this.showPasswordField);
        if (!this.showPasswordField) {
            this.showPasswordField = true;
        }
        else {
            this.userService.edit(this.user);
        }        
    }

}
