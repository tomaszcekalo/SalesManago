using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class Customer
    {
        public long Uuid { get; set; }
        public long Time { get; set; }
        public int Duration { get; set; }
        public string VisitSource { get; set; }
        public string VisitSourceHost { get; set; }
        public string VisitSourceKeywords { get; set; }
        public string VisitSourceDetails { get; set; }
        public int VisitScore { get; set; }
        public string Client { get; set; }
        public string Email { get; set; }
        public Guid ContactId { get; set; }
        public string Url { get; set; }
        public string IpOrganisation { get; set; }
        public int Vid { get; set; }
        public string Cid { get; set; }
        public IpDetail[] IpDetails { get; set; }
        public ContactVisit[] ContactVisits { get; set; }
    }
}