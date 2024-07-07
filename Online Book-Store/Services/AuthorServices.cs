using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Models;

namespace Online_Book_Store.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly AppDbContext _context;
        public AuthorServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Author author)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }

        public async Task Delete(int id)
        {
            try
            {
                var Author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
                _context.Authors.Remove(Author);
                _context.SaveChanges();
            }
            catch (Exception) { throw;}
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            try
            {
                return await _context.Authors.ToListAsync();
            }
            catch (Exception) { throw; }

        }

        public async Task<Author> GetAuthorById(int id)
        {
            try
            {
                var Author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
                return Author;
            }
            catch (Exception) { throw; }

        }

        public async Task Update(Author author)
        {
            try
            {
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
