namespace SalesManago
{
    public class HasContactResponse
    {
        public bool Success { get; set; }

        //public string Message { get; set; }
        public bool Result { get; set; }

        public Guid ContactId { get; set; }
    }
}