import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { database } from 'src/data/db';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  id?: string | null;
  title?: string;
  photoCover?: string;
  publicationDate?: string;
  description?: string;
  content?: string;
  cardsData: any = database;

  constructor(
    private route:ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(value =>
      this.id = value.get("id")
    )
    this.setValuesToComponent(this.id)
  }

  private _checkValues() {
    if (this.title && this.photoCover && this.content && this.description && this.publicationDate){
      return;
    }
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
  setValuesToComponent(id?:string | null){
    if (id){
      const result = database.filter(article => article.id == id)[0]

      this.title = result.title
      this.description = result.description
      this.photoCover = result.photo
      this.content = result.content
      this.publicationDate = result.publicationDate
      this._checkValues();
    }
  }
}
