using SalesManago.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class ConsentFormListResponse : BaseResponse
    {
        /// <summary>
        /// array of object with intId and form name
        /// </summary>
        public ConsentForm[] ConsentFormList { get; set; }
    }
}