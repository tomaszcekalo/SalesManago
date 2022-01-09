using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class ConversationListResponse : BaseResponse
    {
        private Guid[] ConversationList { get; set; }
    }
}