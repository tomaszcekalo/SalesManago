using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class ModifiedContactsResponse
    {
        public bool Success { get; set; }

        public string[] Message { get; set; }
        public IdEmail[] CreatedContacts { get; set; }
    }
}