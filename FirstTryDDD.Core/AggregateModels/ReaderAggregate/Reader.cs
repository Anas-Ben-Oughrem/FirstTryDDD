using FirstTryDDD.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTryDDD.Core.AggregateModels.ReaderAggregate
{
    public class Reader : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //*** other relationships
        public ICollection<ReaderBookList> ReaderBookList { get; set; }
    }
}
