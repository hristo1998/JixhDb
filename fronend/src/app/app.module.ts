import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { routing } from './app.routing';
import { HttpModule } from '@angular/http';

import { appModuleComponents, AppComponent } from './components/index';
import { ServiceModule } from './core/services/service.module';
import { GuardsModule } from './core/guards/guards.module';
import { AdminUserComponent } from './components/admin/admin-user/admin-user.component';
import { AddMovieComponent } from './components/moviemoderator/add-movie/add-movie.component';
import { AddCategoryComponent } from './components/moviemoderator/add-category/add-category.component';
import { MovieComponent } from './components/home/movie/movie.component';


@NgModule({
  declarations: [
    ...appModuleComponents,
    AdminUserComponent,
    AddMovieComponent,
    AddCategoryComponent,
    MovieComponent,
  ],
  imports: [
    routing,
    ServiceModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    HttpModule,
    GuardsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
