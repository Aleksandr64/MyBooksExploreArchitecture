using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public IEnumerable<BookAuthorsVM> BookAuthors { get; set; }
    }

    
}
