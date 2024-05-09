import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-small-card',
  templateUrl: './small-card.component.html',
  styleUrls: ['./small-card.component.css'],
})
export class SmallCardComponent implements OnInit {
  @Input()
  photoCover?: string;
  @Input()
  publicationDate?: string;
  @Input()
  title?: string;
  @Input()
  public id?: string;
  @Input() 
  orientation: 'horizontal' | 'vertical' = 'horizontal';
  
  constructor() {}

  ngOnInit() {
    this._checkValues();
  }

  private _checkValues() {
    if (!this.photoCover) {
      this.photoCover = 'https://via.placeholder.com/490x300';
    }
    if (!this.title) {
      this.title = 'Title';
    }
    if (!this.publicationDate) {
      this.publicationDate = 'Publication Date';
    }
  }
}
