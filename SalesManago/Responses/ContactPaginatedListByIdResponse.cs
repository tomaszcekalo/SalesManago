namespace SalesManago
{
    public class ContactPaginatedListByIdResponse
    {
        public bool Success { get; set; }
        public string[] Message { get; set; }
        public Contact[] Contacts { get; set; }
    }
}