using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class UpsertDetail
    {
        private string NewEmail { get; set; }
        public ContactBase Contact { get; set; }
        public string[] Tags { get; set; }
        public string[] RemoveTags { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public DictionaryProperty[] DictionaryProperties { get; set; }

        /// <summary>
        /// date of contact companybirth, sent as a string of signs in the form:
        /// yyyyMMdd or Mmdd (yyyy – a 4-digit year, MM – a two-digit month, dd – a two-digit day)
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// contact’s province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// forcing opt-in after adding/modification (if the previous option has not been chosen)
        /// </summary>
        public bool ForceOptIn { get; set; }

        /// <summary>
        /// forcing opt-out after adding/modification
        /// </summary>
        public bool ForceOptOut { get; set; }

        /// <summary>
        /// forcing opt-in to a phone after adding/modification (if the previous option has not been chosen)
        /// </summary>
        public bool ForcePhoneIn { get; set; }

        /// <summary>
        /// forcing opt-out from a phone after adding/modification
        /// </summary>
        public bool ForcePhoneOut { get; set; }
    }
}