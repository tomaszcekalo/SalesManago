using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public interface ISalesManagoService
    {
        Task<GetMessagesResponse> GetEmailMessagesAsync(CancellationToken cancellationToken);
        Task<SendEmailResponse> SendEmailAsync(
            Guid emailId,
            SendEmailContact[] contacts,
            CancellationToken cancellationToken);
        Task<HasContactResponse> HasContactAsync(string email, CancellationToken cancellationToken);
    }
}