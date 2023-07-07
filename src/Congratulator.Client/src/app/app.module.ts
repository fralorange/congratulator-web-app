import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { EditComponent } from './edit/edit.component';
import { AppRoutingModule } from './app-routing.module';
import { MainComponent } from './main/main.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [
    AppComponent,
    EditComponent,
    MainComponent,
    AddComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
