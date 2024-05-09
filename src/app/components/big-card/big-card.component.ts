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
  public title?: string;
  @Input()
  public description?: string;
  @Input()
  public publicationDate?: string;
  @Input()
  public id?: string;
  
  constructor() {}

  ngOnInit() {
    this._checkValues();
  }

  private _checkValues() {
    if (!this.photoCover) {
      this.photoCover = 'https://via.placeholder.com/980x600';
    }
    if (!this.title) {
      this.title = 'Title';
    }
    if (!this.description) {
      this.description = 'Description';
    }
    if (!this.publicationDate) {
      this.publicationDate = 'Publication Date';
    }
  }
}
