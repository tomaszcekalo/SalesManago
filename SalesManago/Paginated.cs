using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class Paginated<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public T Entity { get; set; }
    }
}