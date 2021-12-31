using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public class PaginatedContactsListExportResponse
    {
        public bool Success { get; set; }
        public string[] Message { get; set; }
        public int RequestId { get; set; }
    }
}