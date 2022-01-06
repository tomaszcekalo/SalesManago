using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class BatchAddContactExtEventResponse : BaseResponse
    {
        /// <summary>
        /// array of contacts with event creation fail
        /// </summary>
        public string[] FailedContacts { get; set; }

        /// <summary>
        /// amount of created events
        /// </summary>
        public int CreatedAmount { get; set; }

        /// <summary>
        /// amount of failed events
        /// </summary>
        public int FailedAmount { get; set; }
    }
}