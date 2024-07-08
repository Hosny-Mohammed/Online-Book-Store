using Microsoft.AspNetCore.Mvc;
using Online_Book_Store.Models;
using Online_Book_Store.Services;

namespace Online_Book_Store.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices bookServices;
        private readonly IAuthorServices authorServices;
        public BookController(IBookServices _bookServices, IAuthorServices _authorServices) 
        {
            bookServices = _bookServices;
            authorServices = _authorServices;
        }
        public async Task<IEnumerable<dynamic>> List() 
        {
            var Books = await bookServices.GetAllBooks();
            var Authors = await authorServices.GetAllAuthors();
            var Query = from b in Books
                        join a in Authors
                        on b.AuthorId equals a.AuthorId
                        select new
                        {
                            b.AuthorId,
                            b.PublicationDate,
                            b.Title,
                            b.Genre,
                            b.BookId,
                            b.Price,
                            b.ImgURL,
                            a.AuthorName
                        };
            return Query.ToList();

        }
        public async Task<IEnumerable<dynamic>> GetOne(int id)
        {
            var Books = await bookServices.GetAllBooks();
            var Authors = await authorServices.GetAllAuthors();
            var Query = from b in Books
                        where b.BookId == id
                        join a in Authors
                        on b.AuthorId equals a.AuthorId
                        select new
                        {
                            b.AuthorId,
                            b.PublicationDate,
                            b.Title,
                            b.Genre,
                            b.BookId,
                            b.Price,
                            b.ImgURL,
                            a.AuthorName
                        };
            return Query.ToList();

        }
        public async Task<IActionResult> Index()
        {
            return View(await List());
        }
        public async Task<IActionResult> Details(int id)
        {
            var Book = await GetOne(id);
            if(Book == null) 
                return NotFound();

            return View(Book);
        }
        public  IActionResult ToCreatePage()
        {
           // var Authors = await authorServices.GetAllAuthors();
            return View("Create");
        }
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid) 
            {
                await bookServices.Add(book);
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await bookServices.GetBookById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await bookServices.Delete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Search(string query)
        {
            if (query == null)
                return RedirectToAction("Index");
            var Books = await List();
            Books = Books.Where(x => x.Title.ToLower().Contains(query.ToLower()));
            return View("Index", Books);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Book = await bookServices.GetBookById(id);
            if (Book == null)
                NotFound();
            return View(Book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await bookServices.Update(book);
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        public async Task<IActionResult> SortByPrice()
        {
            var Books = await List();
            Books = Books.OrderBy(x => x.Price);
            return View("Index",Books);
        }

        public async Task<IActionResult> SortByTitle()
        {
            var Books = await List();
            Books = Books.OrderBy(x => x.Title);
            return View("Index", Books);
        }

        public async Task<IActionResult> SortByDate()
        {
            var Books = await List();
            Books = Books.OrderBy(x => x.PublicationDate);
            return View("Index", Books);
        }
    }
}
