import { HttpService } from './HttpService';
import { Injectable, Inject } from '@angular/core';

import { HttpParams } from '@angular/common/http';
import { BookDto } from '../dto/BookDto';
import { Observable } from 'rxjs';

@Injectable()
export class BookHttpService {
  private readonly _httpService: HttpService;

  public constructor(httpService: HttpService) {
    this._httpService = httpService;
  }

  public getBooks(): Observable<BookDto[]> {
    return this._httpService.get<BookDto[]>('api/book/books');
  }

  public getBook(bookId: number): Observable<BookDto> {
    const params: HttpParams = new HttpParams()
      .set('bookId', bookId.toString());
    return this._httpService.get<BookDto>('api/book/book', params);
  }

  public saveBook(book: BookDto): Observable<BookDto> {
    return this._httpService.post<BookDto, BookDto>('api/book/save', book);
  }

  public deleteBook(bookId: number): Observable<void> {
    const params: HttpParams = new HttpParams().set('bookId', bookId.toString());
    return this._httpService.post('api/book/remove', params);
  }
}
