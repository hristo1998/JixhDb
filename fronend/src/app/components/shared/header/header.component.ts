import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth/auth.service';
import { Configs } from '../../../core/shared/configs';
import { UserService } from '../../../core/services/user/user.service';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';
import { MovieService } from '../../../core/services/movie/movie.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnChanges {
  username: string;
  categories: any;

  constructor(private authService: AuthService,
    private userService: UserService,
    private movieService: MovieService) { }

  ngOnInit() {
    this.movieService.GetAllCategories()
      .subscribe(
        res => this.categories = res
      );
  }

  ngOnChanges() {
    this.username = this.userService.getUsername();
    console.log(this.username);
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  isAdmin(): boolean {
    return this.authService.isInRole(Configs.administratorRoleName);
  }

  isMovieModerator(): boolean {
    return this.authService.isInRole(Configs.movieModeratorRoleName);
  }

  logout() {
    this.authService.logout();
  }

}
