using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class Vision
    {
        /// <summary>
        /// search status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// the url of the searched image
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// the number of incorrect matches
        /// </summary>
        public int Bq_errors { get; set; }
    }
}