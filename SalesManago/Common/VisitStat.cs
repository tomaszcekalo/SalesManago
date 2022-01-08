using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class VisitStat
    {
        public long Date { get; set; }
        public int PartnersVisits { get; set; }
        public int ProspectsVisits { get; set; }
        public int CustomersVisits { get; set; }
        public int OtherVisits { get; set; }
    }
}