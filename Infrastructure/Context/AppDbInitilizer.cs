using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class AppDbInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Books Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https\\....",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Title = "2st Books Title",
                        Description = "2st Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https\\....",
                        DateAdded = DateTime.Now,
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
