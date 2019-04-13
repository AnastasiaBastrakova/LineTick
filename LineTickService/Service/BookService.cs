using System.Collections.Generic;
using System.Linq;
using System;
using LineTick.EntityFramework;
using LineTick.EntityFramework.Entities;
using LineTickService.Dto;

namespace LineTickService.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //получение списка пользователей
        public List<BookDto> GetBooks()
        {
            List<Book> books = _bookRepository.All.ToList();

            return books.ConvertAll(Convert);
        }

        //получение пользователя по id
        public BookDto GetBook(int bookId)
        {
            if (bookId == 0)
            {
                return CreateBook();
            }

            Book book = _bookRepository.All.FirstOrDefault(item => item.Id == bookId);

            if (book != null)
            {
                return Convert(book);
            }

            return null;
        }

        public BookDto CreateBook()
        {
            return new BookDto
            {
                BookId = 0,
                Title = string.Empty,
                Description = string.Empty
            };
        }

        //сохранение пользователя
        public BookDto SaveBook(BookDto bookDto)
        {
            Book book = _bookRepository.GetItem(bookDto.BookId) ?? new Book { };

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;

            book = _bookRepository.Save(book);

            return Convert(book);
        }

        private BookDto Convert(Book book)
        {
            return new BookDto
            {
                BookId = book.Id,
                Title = book.Title,
                Description = book.Description
            };
        }

        //удаление пользователя
        public void RemoveBook(int bookId)
        {
            _bookRepository.Delete(bookId);
        }
    }
}