import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponentComponent } from './components/home-page-component/home-page-component.component';
import { RandomWordComponentComponent } from './components/random-word-component/random-word-component.component';
import { SignInComponentComponent } from './components/sign-in-component/sign-in-component.component';
import { SignUpComponentComponent } from './components/sign-up-component/sign-up-component.component';
import { AddNewWordComponentComponent } from './components/add-new-word-component/add-new-word-component.component';
import { NotFoundPageComponentComponent } from './components/not-found-page-component/not-found-page-component.component';
import { WordComponentComponent } from './components/word-component/word-component.component';



const routes: Routes = [

  { path: '', component: HomePageComponentComponent },
  { path: 'word', component: WordComponentComponent },//I will do the right thing later
  { path: 'signIn', component: SignInComponentComponent },
  { path: 'signUp', component: SignUpComponentComponent },
  { path: 'addNewWord', component: AddNewWordComponentComponent },
  { path: 'words/getRandomWord', component: RandomWordComponentComponent },

  { path: '**', component: NotFoundPageComponentComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule],
})
export class AppRoutingModule { }
