using System.Collections.Generic;
using LineTickService.Dto;

namespace LineTickService.Service
{
    public interface IBookService
    {
        List<BookDto> GetBooks();          //��������� ������ �������������
        BookDto GetBook(int bookId);       //��������� ������������ �� id
        BookDto SaveBook(BookDto bookDto); //���������� ������������
        void RemoveBook(int bookId);     //�������� ������������
    }
}