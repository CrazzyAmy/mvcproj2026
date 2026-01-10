using WebMVC.Interface;

namespace WebMVC.Models
{
    public class BookService
    {
        private List<BookViewModel> _books;

        public BookService()
        {
            _books = new List<BookViewModel>
            {
                new BookViewModel { Id = 1, Title = "ChatGPT", Price = 590 },
                new BookViewModel { Id = 2, Title = "ASP.NET MVC", Price = 680 },
                new BookViewModel { Id = 3, Title = "Azure AI Service", Price = 499 }
            };
        }

        public List<BookViewModel> GetAllBooks() => _books;

    }


    public class BookService_V1: IBookService
    {
        private List<BookViewModel> _books;

        public BookService_V1()
        {
            _books = new List<BookViewModel>
            {
                new BookViewModel { Id = 1, Title = "GJ_ChatGPT", Price = 590 },
                new BookViewModel { Id = 2, Title = "GJ_ASP.NET MVC", Price = 680 },
                new BookViewModel { Id = 3, Title = "GJ_Azure AI Service", Price = 499 }
            };
        }

        public void AddBook(BookViewModel book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void UpdateBook(BookViewModel book)
        {
            var sourceBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (sourceBook != null)
            {
                sourceBook.Title = book.Title;
                sourceBook.Price = book.Price;
            }
        }

        public void DeleteBook(int id)
        {
            _books.RemoveAll(b => b.Id == id);
        }

        public List<BookViewModel> GetAllBooks() => _books;
        public BookViewModel GetBook(int id) => _books.FirstOrDefault(b => b.Id == id);

    }

    //public class BookService_V2: IBookService
    //{
    //    private List<BookViewModel> _books;

    //    public BookService_V2()
    //    {
    //        _books = new List<BookViewModel>
    //        {
    //            new BookViewModel { Id = 1, Title = "Online_ChatGPT", Price = 590 },
    //            new BookViewModel { Id = 2, Title = "Online_ASP.NET MVC", Price = 680 },
    //            new BookViewModel { Id = 3, Title = "Online_Azure AI Service", Price = 499 }
    //        };
    //    }

    //    public void AddBook(BookViewModel book)
    //    {
    //        book.Id = _books.Max(b => b.Id) + 1;
    //        _books.Add(book);
    //    }

    //    public List<BookViewModel> GetAllBooks() => _books;

    //}

}
