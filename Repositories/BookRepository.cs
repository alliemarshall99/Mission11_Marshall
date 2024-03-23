using Mission11_Marshall.Data;
using Mission11_Marshall.Models;

namespace Mission11_Marshall.Repositories
{
    public class BookRepository
    {
        private readonly BookstoreDbContext _context;

        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public int GetTotalCount()
        {
            return _context.Books.Count();
        }

        public List<Book> GetBooks(int currentPage, int pageSize)
        {
            return _context.Books.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
