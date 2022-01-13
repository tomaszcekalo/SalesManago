using System;

namespace SalesManago
{
    public class ContactIdResponse : BaseResponse
    {
        /// <summary>
        /// unique ID of the contact
        /// </summary>
        public Guid ContactId { get; set; }
    }
}