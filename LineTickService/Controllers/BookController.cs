using System;
using System.Collections.Generic;
using LineTickService.Dto;
using LineTickService.Service;
using Microsoft.AspNetCore.Mvc;

namespace LineTickService.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("books")]
        public List<BookDto> GetBooks()
        {
            return _bookService.GetBooks();
        }

        [HttpGet("book")]
        public BookDto GetBook(int bookId)
        {
            return _bookService.GetBook(bookId);
        }

        [HttpPost("save")]
        public BookDto SaveBook([FromBody] BookDto newBook)
        {
            BookDto savedBookDto = _bookService.SaveBook(newBook);

            return new BookDto
            {
                BookId = savedBookDto.BookId,
                Title = savedBookDto.Title,
                Description = savedBookDto.Description
            };
        }

        [HttpPost("remove")]
        public void RemoveBook(int bookId)
        {
            _bookService.RemoveBook(bookId);
        }
    }
}