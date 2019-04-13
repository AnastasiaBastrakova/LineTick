import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookHttpService } from '../../HttpServices/BookHttpService';
import { BookDto } from '../../dto/BookDto';

@Component({
  selector: 'app-book-component',
  templateUrl: './EditBook.Component.html',
  providers: [BookHttpService]
})
export class EditBookComponent {

  private readonly _bookHttpService: BookHttpService;

  public editingBookId: number;
  public bookToEdit: BookDto;
  public books: BookDto[];

  public constructor(bookHttpService: BookHttpService, route: ActivatedRoute) {
    this._bookHttpService = bookHttpService;

    route.params.subscribe(params => {
      const paramsBookId: number | undefined = params['bookId'] !== undefined
        ? Number(params['bookId'])
        : 0;
      this.editingBookId = paramsBookId;
      this.loadBook();
    });
  }

  public getDate(date: Date) {
    return new Date(date).toLocaleDateString();
  }

  private loadBook(): void {
    this._bookHttpService.getBook(this.editingBookId).subscribe(book => {
      this.bookToEdit = book;
    });
  }

  public saveBook(): void {
    this._bookHttpService.saveBook(this.bookToEdit).subscribe(value => {
      this.editingBookId = value.bookId;
      this.loadBook();
    });
    this.reloadBooks();
  }

  private reloadBooks(): void {
    this._bookHttpService.getBooks().subscribe(values => {
      this.books = values;
    });
  }
}
