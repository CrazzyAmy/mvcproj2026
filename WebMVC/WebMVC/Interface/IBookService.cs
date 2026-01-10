using WebMVC.Models;

namespace WebMVC.Interface
{
    public interface IBookService
    {
        List<BookViewModel> GetAllBooks();
        void AddBook(BookViewModel book);
        BookViewModel GetBook(int id);
        void UpdateBook(BookViewModel book);
        void DeleteBook(int id);
    }
}
