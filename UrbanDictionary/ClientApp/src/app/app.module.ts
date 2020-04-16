import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponentComponent } from './components/header-component/header-component.component';
import { FooterComponentComponent } from './components/footer-component/footer-component.component';
import { HomePageComponentComponent } from './components/home-page-component/home-page-component.component';
import { SignInComponentComponent } from './components/sign-in-component/sign-in-component.component';
import { SignUpComponentComponent } from './components/sign-up-component/sign-up-component.component';
import { AddNewWordComponentComponent } from './components/add-new-word-component/add-new-word-component.component';
import { TopWordsComponentComponent } from './components/top-words-component/top-words-component.component';
import { RandomWordComponentComponent } from './components/random-word-component/random-word-component.component';
import { WordComponentComponent } from './components/word-component/word-component.component';
import { NotFoundPageComponentComponent } from './components/not-found-page-component/not-found-page-component.component';
import {WordService} from './service/word.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponentComponent,
    FooterComponentComponent,
    HomePageComponentComponent,
    SignInComponentComponent,
    SignUpComponentComponent,
    AddNewWordComponentComponent,
    TopWordsComponentComponent,
    RandomWordComponentComponent,
    WordComponentComponent,
    NotFoundPageComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    WordService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
