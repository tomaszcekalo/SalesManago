using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class ContactEvent
    {
        /// <summary>
        /// event date (timestamp, i.e. time in milliseconds that passed from midnight 1 January 1970 UTC)
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// event description
        /// (max length 2048 characters)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// optional list of products separated by commas
        /// (max length 512 characters)
        /// </summary>
        public string Products { get; set; }

        /// <summary>
        /// E-shop ID (location)
        /// unique shop identifier – this identifier is used to connect information about the product sent in the external event with a particular product feed.
        /// Maximum number of characters without spaces is 36 (possible characters: letters a-z, numbers 1-9, /_-.).
        /// Unique shop identifier has to be exactly the same as the value in the LOCATION field in external events sent from a particular shop.
        /// IMPORTANT: If you have only one product feed, the system will connect an external event and the product feed that you have in the system automatically.
        /// When you use multistore option, remember about coherence in sending external events with a unique identifier.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// optional event value eg. amount spent (max 19 digits + 2 after the decimal point)
        /// </summary>
        public float? Value { get; set; }

        /// <summary>
        /// event type, possible values:
        /// PURCHASE, CART,
        /// VISIT, PHONE_CALL,
        /// OTHER, RESERVATION,
        /// CANCELLED, ACTIVATION,
        /// MEETING, OFFER,
        /// DOWNLOAD, LOGIN,
        /// TRANSACTION, CANCELLATION,
        /// RETURN, SURVEY,
        /// APP_STATUS, APP_TYPE_WEB,
        /// APP_TYPE_MANUAL, APP_TYPE_RETENTION,
        /// APP_TYPE_UPSALE, LOAN_STATUS,
        /// LOAN_ORDER, FIRST_LOAN,
        /// REPEATED_LOAN
        /// </summary>
        public ContactExtEventType ContactExtEventType { get; set; }

        /// <summary>
        /// optional event ID, eg. ID from a teller system, etc.
        /// (max length 255 characters)
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// optional shop domain
        /// </summary>
        public string ShopDomain { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail1 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail2 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail3 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail4 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail5 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail6 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail7 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail8 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail9 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail10 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail11 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail12 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail13 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail14 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail15 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail16 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail17 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail18 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail19 { get; set; }

        /// <summary>
        /// optional event details
        /// </summary>
        public string Detail20 { get; set; }
    }
}