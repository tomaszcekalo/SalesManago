using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class AuthoriseResponse : BaseResponse
    {
        /// <summary>
        /// is a temporary token that may be used for authorization in exchange for apiSecret
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// client ID required for further operations
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// valid date
        /// </summary>
        public long ValidTo { get; set; }
    }
}