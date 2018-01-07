import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { routing } from 'app/app.routing';

import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { HttpService } from './core/services/common/http.service';
import { HttpModule } from '@angular/http';
import { StorageService } from './core/services/common/storage.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    routing,
    BrowserModule,
    HttpModule
  ],
  providers: [HttpService, StorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
