import { Component, OnInit } from '@angular/core';
import { WordDTO } from 'src/app/model/word-dto';
import { WordService } from 'src/app/service/word.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-random-word-component',
  templateUrl: './random-word-component.component.html',
  styleUrls: ['./random-word-component.component.css']
})
export class RandomWordComponentComponent implements OnInit {

  randomWord: WordDTO;

  constructor(
    private route: ActivatedRoute,
    private wordService: WordService,
    private router: Router) { }

  ngOnInit(): void {
    this.wordService.getRandom().subscribe(word =>
    {
      this.randomWord = word[0];
    });
  }

}
