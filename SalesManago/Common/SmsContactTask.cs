using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Common
{
    public class SmsContactTask
    {
        /// <summary>
        /// contact email to which the task will be assigned
        /// </summary>
        public string ContactEmail { get; set; }

        /// <summary>
        /// task ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// task note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// date of task execution
        /// </summary>
        public long Date { get; set; }

        /// <summary>
        /// list of emails where a reminder will be sent (emails should be separated with commas)
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// reminder about the task. It defines when the reminder should be sent.
        /// Allowed values:
        /// 15_MIN – 15 minutes before,
        /// 30_MIN – 30 minutes before,
        /// 1_HOUR – an hour before,
        /// 12_HOUR – 12 hours before,
        /// 1_DAY – 1 day before,
        /// 1_WEEK – 1 week before
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// assigning the value true will mark the task as completed
        /// </summary>
        public bool? Realized { get; set; }
    }
}