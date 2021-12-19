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
        /// <summary>
        /// https://docs.salesmanago.com/#export-basic-contacts-39-data-by-email-address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicExportAsync(string email, CancellationToken cancellationToken);
    }
}