namespace SalesManago
{
    public class ContactIdsResponse : BaseResponse
    {
        /// <summary>
        /// unique IDs of updated contacts
        /// </summary>
        private Dictionary<string, Guid> ContactIds { get; set; }
    }
}