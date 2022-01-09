using SalesManago.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago.Responses
{
    public class WorkflowListResponse : BaseResponse
    {
        /// <summary>
        /// list of undeleted workflow 2.0
        /// </summary>
        public Workflow[] Workflows { get; set; }
    }
}