using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class CreatedContactsResponse : BaseResponse
    {
        public IdEmail[] CreatedContacts { get; set; }
    }
}