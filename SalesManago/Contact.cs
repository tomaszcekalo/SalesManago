namespace SalesManago
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int Score { get; set; }
        public ContactState State { get; set; }
        public bool OptedOut { get; set; }
        public bool OptedOutPhone { get; set; }
        public bool Deleted { get; set; }
        public bool Invalid { get; set; }
        public string Company { get; set; }
        public ContactAddress Address { get; set; }
        public Guid ContactId { get; set; }
        public long ModifiedOn { get; set; }
        public long CreatedOn { get; set; }
        public long? LastVisit { get; set; }
    }
}