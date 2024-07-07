using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Models;

namespace Online_Book_Store.Services
{
    public class BookServices : IBookServices
    {
        private readonly AppDbContext _context;
        public BookServices(AppDbContext context) 
        {
            _context = context;
        }
        public async Task Add(Book book)
        {
            try
            {
                 await _context.Books.AddAsync(book);
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public async Task Delete(int id)
        {
            try
            {
                var Book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
                _context.Books.Remove(Book);
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Book> GetBookById(int id)
        {
            try
            {
                var Book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);
                return Book;
            }
            catch (Exception) { throw; }
        }

        public async Task Update(Book book)
        {
            try
            {
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
