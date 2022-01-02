namespace SalesManago
{
    public class AddContactsToFunnelResponse : BaseResponse
    {
        public Dictionary<Guid, bool> AddedContacts { get; set; }
    }
}