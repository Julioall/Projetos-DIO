import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-big-card',
  templateUrl: './big-card.component.html',
  styleUrls: ['./big-card.component.css'],
})
export class BigCardComponent implements OnInit {
  @Input()
  public photoCover?: string;
  @Input()
  public cardTitle?: string;
  @Input()
  public cardDescription?: string;
  @Input()
  public publicationDate?: string;
  constructor() {}

  ngOnInit() {
    this._checkValues();
  }

  private _checkValues() {
    if (!this.photoCover) {
      this.photoCover = 'https://via.placeholder.com/980x600';
    }
    if (!this.cardTitle) {
      this.cardTitle = 'Title';
    }
    if (!this.cardDescription) {
      this.cardDescription = 'Description';
    }
    if (!this.publicationDate) {
      this.publicationDate = 'Publication Date';
    }
  }
}
