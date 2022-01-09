using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class UsersResponse : BaseResponse
    {
        public string[] Users { get; set; }
    }
}