using SalesManago.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class Addressee : AddresseeBase
    {
        /// <summary>
        /// additional attributes of email messages defined by the user. It is not advised to use diacritical marks and spaces in names, but it is allowed.
        /// In an e-mail message the construction $cst.parameterName$ should be used in order to substitute the proper value.
        /// </summary>
        public NameValue[] Properties { get; set; }

        /// <summary>
        /// for the STAGE type we can provide as an option names of stages in the funnel to which the mailing is addressed; each name is separated by a comma.
        /// </summary>
        public string OptValue { get; set; }
    }
}