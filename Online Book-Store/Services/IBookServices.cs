using Online_Book_Store.Models;

namespace Online_Book_Store.Services
{
    public interface IBookServices
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBookById(int id);
        public Task Add(Book book);
        public Task Update(Book book);
        public Task Delete(int id);
    }
}
