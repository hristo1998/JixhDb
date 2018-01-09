import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { routing } from './app.routing';
import { HttpModule } from '@angular/http';

import { appModuleComponents, AppComponent } from './components/index';
import { ServiceModule } from './core/services/service.module';
import { AdminComponent } from './components/admin/admin.component';


@NgModule({
  declarations: [
    ...appModuleComponents,
    AdminComponent
  ],
  imports: [
    routing,
    ServiceModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    HttpModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
