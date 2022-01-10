using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class ResultResponse : BaseResponse
    {
        /// <summary>
        /// result of request
        /// additional information enabling error identification
        /// </summary>
        public string Result { get; set; }
    }
}