using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class ContactBase
    {
        /// <summary>
        /// contact name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// contact email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// fax number
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// contact company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// External contact ID
        /// </summary>
        public string ExternalId { get; set; }

        public ContactAddress Address { get; set; }
    }
}