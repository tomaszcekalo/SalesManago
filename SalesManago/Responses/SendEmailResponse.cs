using SalesManago.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class ConversationIdResponse : BaseResponse
    {
        /// <summary>
        /// conversation ID
        /// </summary>
        public string ConversationId { get; set; }

        /// <summary>
        /// conversation name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// number of messages to send
        /// </summary>
        public int Messages { get; set; }

        /// <summary>
        /// number of messages sent
        /// </summary>
        public int SentMessages { get; set; }

        /// <summary>
        /// number of messages delivered
        /// </summary>
        public int DeliveredCount { get; set; }

        public Delivery[] Delivered { get; set; }

        /// <summary>
        /// number of messages to which a reply was sent
        /// </summary>
        public int RepliedCount { get; set; }

        /// <summary>
        /// list of contacts to whom a message was delivered.
        /// </summary>
        public Delivery[] Replied { get; set; }

        /// <summary>
        /// number of not delivered messages
        /// </summary>
        public int NotDeliveredCount { get; set; }

        /// <summary>
        /// list of contacts to whom a message was delivered.
        /// </summary>
        public Delivery[] NotDelivered { get; set; }
    }
}