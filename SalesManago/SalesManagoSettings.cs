using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class SalesManagoSettings
    {
        public string ClientId { get; set; }

        /// <summary>
        /// contact’s owner (SALESmanago user account email)
        /// </summary>
        public string Owner { get; set; }

        public string ApiSecret { get; set; }
        public string Endpoint { get; set; }
    }
}