using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class ContactVisit
    {
        public string ConversationId { get; set; }
        public string Host { get; set; }
        public long Time { get; set; }
        public string Duration { get; set; }
        public string VisitSource { get; set; }
        public string VisitSourceHost { get; set; }
        public string VisitSourceKeywords { get; set; }
        public string VisitScore { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
    }
}