using SalesManago.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class ContactExternalEvent
    {
        /// <summary>
        /// contact id from SALESmanago system (can be used as alternative for contact email)
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// contact’s email for which the event is added
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// external event object ( read more - Adding Event at https://docs.salesmanago.com/#addingEvent)
        /// </summary>
        public ContactEvent ContactEvent { get; set; }
    }
}