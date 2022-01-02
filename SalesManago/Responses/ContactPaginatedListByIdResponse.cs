namespace SalesManago
{
    public class ContactPaginatedListByIdResponse : BaseResponse
    {
        public Contact[] Contacts { get; set; }
    }
}