import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { Empty } from '../model/empty';
import { WordDTO } from '../model/word-dto';


@Injectable({
  providedIn: 'root'
})
export class WordService {
  private url = 'https://urbandictionary20200425161210.azurewebsites.net/api/words';
  constructor(private http: HttpClient) { }

  getRandom(): Observable<WordDTO[]>{
    return this.http.get<WordDTO[]>( this.url + '/randomWord');
  }
}
