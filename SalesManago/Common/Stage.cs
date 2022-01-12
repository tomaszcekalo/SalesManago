using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class Stage
    {
        /// <summary>
        /// funnel stage name (min. 3 characters, max 255 characters)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the sequence of stages (min. value 1, the values of the sequence should form a sequence of 1,2,3…number of stages)
        /// </summary>
        public int Order { get; set; }
    }
}