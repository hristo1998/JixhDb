import { Routes, RouterModule } from '@angular/router';

import {
  LoginComponent,
  RegisterComponent,
  Error404Component,
  AdminComponent,
  HomeComponent,
  ProfileComponent,
  EditProfileComponent,
  AdminUserComponent,
  AddMovieComponent,
  AddCategoryComponent,
  MovieComponent
} from './components';

import {
  GuestGuard,
  AuthGuard,
  AdminGuard,
  ModeratorGuard,
  MovieModeratorGuard
} from './core/guards';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home/:category', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'movies/:id', component: MovieComponent },
  { path: 'moderator/movie/add', component: AddMovieComponent, canActivate: [MovieModeratorGuard] },
  { path: 'moderator/category/add', component: AddCategoryComponent, canActivate: [MovieModeratorGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AdminGuard] },
  { path: 'admin/user/:id', component: AdminUserComponent, canActivate: [AdminGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'profile/edit', component: EditProfileComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [GuestGuard] },
  { path: 'login', component: LoginComponent, canActivate: [GuestGuard] },
  { path: '404', component: Error404Component },
  { path: '**', redirectTo: '404', pathMatch: 'full' }
];

export const routing = RouterModule.forRoot(appRoutes);
