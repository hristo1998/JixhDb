import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../core/services/common/http.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private httpService: HttpService) { }

  ngOnInit() {
    this.httpService.get('home/user').subscribe(res => console.log(res));
  }

}
