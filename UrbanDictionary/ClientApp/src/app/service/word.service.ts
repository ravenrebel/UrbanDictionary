import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Empty } from '../model/empty';
import { WordDTO } from '../model/word-dto';

@Injectable({
  providedIn: 'root'
})
export class WordService {

  constructor(private http: HttpClient) { }
  baseUrl: string = 'http://localhost:4200/words/';

  getRandom(id: number): Observable<WordDTO>{
    return this.http.get<WordDTO>(this.baseUrl + "id/" + id);
  }
}