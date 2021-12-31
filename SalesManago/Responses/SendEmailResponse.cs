using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class SendEmailResponse
    {
        public bool Success { get; set; }
        public string[] Message { get; set; }
        public string ConversationId { get; set; }
    }
}