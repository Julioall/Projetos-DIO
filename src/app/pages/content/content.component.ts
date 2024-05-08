import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  title?: string;
  photoCover?: string;
  cardTitle?: string;
  publicationDate?: string;
  content?: string;

  constructor() { }

  ngOnInit() {
    this._checkValues();
  }
  private _checkValues() {
    if (this.title === undefined) {
      this.title = 'Titulo do conteúdo da página';
    }
    if (this.photoCover === undefined) {
      this.photoCover = 'https://via.placeholder.com/1150X480';
    }
    if (this.publicationDate === undefined) {
      this.publicationDate = 'Publication Date';
    }
    if (this.content === undefined) {
      this.content = 'Conteúdo da página';
    }
  }
}
