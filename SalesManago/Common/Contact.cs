using SalesManago.Common;
using System;

namespace SalesManago
{
    public class Contact : ContactBase
    {
        public Guid Id { get; set; }

        public int Score { get; set; }
        public ContactState State { get; set; }
        public bool OptedOut { get; set; }
        public bool OptedOutPhone { get; set; }
        public bool Deleted { get; set; }
        public bool Invalid { get; set; }

        public Guid ContactId
        { get; set; }

        public long ModifiedOn { get; set; }
        public long CreatedOn { get; set; }
        public long? LastVisit { get; set; }
    }
}