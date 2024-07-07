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
                        });
                }
                
            }
        }
    }
}
