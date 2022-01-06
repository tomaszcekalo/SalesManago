using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class TagsResponse : BaseResponse
    {
        public ContactTag[] Tags { get; set; }
    }
}