using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class WebPushIdsResponse : BaseResponse
    {
        public int[] WebPushIds { get; set; }
    }
}