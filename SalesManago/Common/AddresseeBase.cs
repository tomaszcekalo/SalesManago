using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class AddresseeBase
    {
        /// <summary>
        /// addressing emails type ( EMAIL, CONTACT_ID, TAGS)
        /// </summary>
        public AddresseeType AddresseeType { get; set; }

        /// <summary>
        /// optional – contact email address, contact identifier, tag or funnel
        /// </summary>
        public string Value { get; set; }
    }
}