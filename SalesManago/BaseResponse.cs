using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class BaseResponse
    {
        /// <summary>
        /// boolean value informing about the result of request (successful/not successful)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// array of additional information enabling error identification
        /// </summary>
        public string[] Message { get; set; }
    }
}