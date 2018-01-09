import { Routes, RouterModule } from '@angular/router';

import {
  LoginComponent,
  RegisterComponent,
  Error404Component,
  AdminComponent
} from './components';

const appRoutes: Routes = [
  { path: 'admin', component: AdminComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '404', component: Error404Component },
  { path: '**', redirectTo: '404', pathMatch: 'full' }
];

export const routing = RouterModule.forRoot(appRoutes);
