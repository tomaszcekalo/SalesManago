using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class Delivery
    {
        public string Email { get; set; }
        public Guid Od { get; set; }
        public long? DateTimeStamp { get; set; }
    }
}