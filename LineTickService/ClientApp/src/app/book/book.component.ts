import { Component } from '@angular/core';
import { BookHttpService } from '../../HttpServices/BookHttpService';
import { BookDto } from '../../dto/BookDto';

@Component({
  selector: 'app-book-component',
  templateUrl: './book.component.html',
  providers: [BookHttpService]
})
export class BookComponent {

  private readonly _bookHttpService: BookHttpService;
  public books: BookDto[];

  public constructor(bookHttpService: BookHttpService) {
    this._bookHttpService = bookHttpService;

    this._bookHttpService.getBooks().subscribe(values => {
      this.books = values;
    });
  }

  public getDate(date: Date) {
    return new Date(date).toLocaleDateString();
  }

  public deleteBook(bookId: number): void {
    this._bookHttpService.deleteBook(bookId).subscribe(() => {
      this.reloadBooks();
    });
  }

  private reloadBooks(): void {
    this._bookHttpService.getBooks().subscribe(values => {
      this.books = values;
    });
  }
}
