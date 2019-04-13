using System.Collections.Generic;
using LineTickService.Dto;

namespace LineTickService.Service
{
    public interface IBookService
    {
        List<BookDto> GetBooks();          //получение списка пользователей
        BookDto GetBook(int bookId);       //получение пользователя по id
        BookDto SaveBook(BookDto bookDto); //сохранение пользователя
        void RemoveBook(int bookId);     //удаление пользователя
    }
}