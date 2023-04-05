using FirstTryDDD.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.BookAggregate
{
    public class BookCategory : ParentEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set;}

    }
}
