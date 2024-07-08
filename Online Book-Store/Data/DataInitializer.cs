using Online_Book_Store.Models;
using System.Collections.Generic;

namespace Online_Book_Store.Data
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var Scope = app.ApplicationServices.CreateScope())
            {
                var context = Scope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>() 
                    {
                        new Author()
                        {
                            AuthorName = "Jane Doe",
                            AuthorBio = "Jane Doe is a prolific writer known for her work in modern fiction. She has won numerous awards for her novels.",
                            DateOfBirth =  new(2021, 1, 31),
                        },
                        new Author
                        {
                            AuthorName = "Jane Austen",
                            AuthorBio = "An English novelist known primarily for her six major novels.",
                            DateOfBirth = new DateOnly(1775, 12, 16),
                        },
                        new Author
                        {
                            AuthorName = "Mark Twain",
                            AuthorBio = "An American writer, humorist, entrepreneur, publisher, and lecturer.",
                            DateOfBirth = new DateOnly(1835, 11, 30),
                        },
                        new Author
                        {
                            AuthorName = "George Orwell",
                            AuthorBio = "An English novelist, essayist, journalist, and critic.",
                            DateOfBirth = new DateOnly(1903, 6, 25),
                        }
                        
                    });
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>() 
                    {
                        new Book
                    {
                        Title = "Pride and Prejudice",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/81OthjkJBuL.jpg",
                        Genre = "Romance",
                        Price = 9.99f,
                        PublicationDate = new DateOnly(1813, 1, 28),
                        AuthorId = 1
                    },
                    new Book
                    {
                        Title = "Sense and Sensibility",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/91hhCXj9dbL.jpg",
                        Genre = "Romance",
                        Price = 8.99f,
                        PublicationDate = new DateOnly(1811, 10, 30),
                        AuthorId = 1
                    },
                    new Book
                    {
                        Title = "Adventures of Huckleberry Finn",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/81AHt4HQdSL.jpg",
                        Genre = "Adventure",
                        Price = 7.99f,
                        PublicationDate = new DateOnly(1884, 12, 10),
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "The Adventures of Tom Sawyer",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/81H3x8ydwUL.jpg",
                        Genre = "Adventure",
                        Price = 6.99f,
                        PublicationDate = new DateOnly(1876, 6, 1),
                        AuthorId = 2
                    },
                    new Book
                    {
                        Title = "1984",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
                        Genre = "Dystopian",
                        Price = 10.99f,
                        PublicationDate = new DateOnly(1949, 6, 8),
                        AuthorId = 3
                    },
                    new Book
                    {
                        Title = "Animal Farm",
                        ImgURL = "https://images-na.ssl-images-amazon.com/images/I/81lEPx91WlL.jpg",
                        Genre = "Political satire",
                        Price = 5.99f,
                        PublicationDate = new DateOnly(1945, 8, 17),
                        AuthorId = 3
                    }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
