using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class IdScoreResult
    {
        /// <summary>
        /// product ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// match percentage
        /// </summary>
        public double Score { get; set; }
    }
}