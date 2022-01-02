using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class GetMessagesResponse : BaseResponse
    {
        public StandardMessage[] StandardMessages { get; set; }
    }

    public class StandardMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public long CreatedOn { get; set; }
        public bool Shared { get; set; }
        public Guid EmailAccountId { get; set; }
        public Guid UserAccountId { get; set; }
        public long ModifiedOn { get; set; }
        public string Campaign { get; set; }
        public long NotVisibleOnList { get; set; }
        public long Dynamic { get; set; }
        public long IgnoreLimits { get; set; }
        public long EmailCreator { get; set; }
    }
}