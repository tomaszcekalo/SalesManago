using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class ConsentDetail
    {
        /// <summary>
        /// name of the agreement (WARNING - agreement should exist in the system),
        /// </summary>
        public string ConsentName { get; set; }

        /// <summary>
        /// boolean value of consent (true or false),
        /// </summary>
        public bool ConsentAccept { get; set; }

        /// <summary>
        /// time in ms of agreement date (in case of absence a current timestamp will be used),
        /// </summary>
        public long AgreementDate { get; set; }

        /// <summary>
        /// IP address of contact,
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// the boolean value of the withheld consent (true or false)
        /// </summary>
        public bool OptOut { get; set; }

        /// <summary>
        /// consent description identifier
        /// </summary>
        public long ConsentDescriptionId { get; set; }
    }
}