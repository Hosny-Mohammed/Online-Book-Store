using Online_Book_Store.Models;

namespace Online_Book_Store.Services
{
    public interface IAuthorServices
    {
        public Task<IEnumerable<Author>> GetAllAuthors();
        public Task<Author> GetAuthorById(int id);
        public Task Add(Author author);
        public Task Update(Author author);
        public Task Delete(int id);
    }
}
