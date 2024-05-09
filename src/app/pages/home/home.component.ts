import { Component, OnInit } from '@angular/core';
import { database } from 'src/data/db';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  cardsData = database;
  mainArticle = this.cardsData[0];
  constructor() {}

  ngOnInit() {}
}
