using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class BookAuthorsVM
    {
        public string BookName { get; set; }
        public IEnumerable<string> BookAuthors { get; set;}
    }
}
