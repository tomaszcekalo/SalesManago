using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class Recipient
    {
        /// <summary>
        /// contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// contact id
        /// </summary>
        public Guid? ContactId { get; set; }

        /// <summary>
        /// tag assigned to the SALESmanago contact group (in the “contacts” field you can use up to 10 “tag” objects)
        /// </summary>
        public string Tag { get; set; }
    }
}