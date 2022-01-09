using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class WebPushStatsResponse : BaseResponse
    {
        /// <summary>
        /// name of web push notification
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// send date of web push
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// number of web push notifications sent
        /// </summary>
        public int TotalSent { get; set; }

        /// <summary>
        /// number of web push notifications sent to anonymous contacts
        /// </summary>
        public int AnonymousSent { get; set; }

        /// <summary>
        /// number of openings
        /// </summary>
        public int TotalOpened { get; set; }

        /// <summary>
        /// number of clicks
        /// </summary>
        public int TotalClicked { get; set; }

        /// <summary>
        /// number of openings of rich web push notifications
        /// </summary>
        public int RichWebPushOpened { get; set; }

        /// <summary>
        /// number of clicks in rich web push notifications
        /// </summary>
        public int RichWebPushClicked { get; set; }

        /// <summary>
        /// list of contacts to whom web push notifications were sent
        /// </summary>
        public string[] Sent { get; set; }

        /// <summary>
        /// list of contacts who opened web push notification
        /// </summary>
        public string[] Opened { get; set; }

        /// <summary>
        /// list of contacts who clicked web push notification
        /// </summary>
        public string[] Clicked { get; set; }
    }
}