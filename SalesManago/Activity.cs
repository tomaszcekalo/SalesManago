using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class Activity
    {
        public long From { get; set; }
        public long To { get; set; }
        public int MonitoredContacts { get; set; }
        public int TotalContacts { get; set; }
        public Customer[] Customers { get; set; }
        public Customer[] Partners { get; set; }
        public Customer[] Prospects { get; set; }
        public Customer[] Anonymous { get; set; }
        public Customer[] AllVisits { get; set; }
        public VisitStat[] VisitStats { get; set; }
    }
}