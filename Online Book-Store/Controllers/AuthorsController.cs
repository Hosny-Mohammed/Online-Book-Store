using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Book_Store.Data;
using Online_Book_Store.Models;
using Online_Book_Store.Services;

namespace Online_Book_Store.Controllers
{
    public class AuthorsController : Controller
    {

        private readonly IAuthorServices services;

        public AuthorsController(IAuthorServices _services)
        {
            services = _services;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await services.GetAllAuthors());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var author = await services.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName,AuthorBio,DateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                await services.Add(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var author = await services.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName,AuthorBio,DateOfBirth")] Author author)
        {
            if (id != author.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await services.Update(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.AuthorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var author = await services.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await services.GetAuthorById(id);
            if (author != null)
            {
                await services.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            var author = services.GetAuthorById(id);
            if(author == null)
                return false;
            return true;
        }

    }
}
