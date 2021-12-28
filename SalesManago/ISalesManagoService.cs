using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManago
{
    public interface ISalesManagoService
    {
        /// <summary>
        /// https://docs.salesmanago.pl/#pobieranie-stworzonych-wiadomo-ci
        /// </summary>
        /// <returns></returns>
        Task<GetMessagesResponse> GetEmailMessagesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.pl/#wysy-anie-wiadomo-ci-email-zalecana
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="contacts"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SendEmailResponse> SendEmailAsync(
            Guid emailId,
            SendEmailContact[] contacts,
            CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#checking-if-a-contact-is-already-recorded
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<HasContactResponse> HasContactAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#export-basic-contacts-39-data-by-email-address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#export-basic-contacts-39-data-by-contact-id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByIdAsync(string id, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#export-based-on-email-address-for-the-owner
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#export-based-on-email-address
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByEmailAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#export-based-on-contact-39-s-id
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByIdAsync(string contactId, CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#exporting-the-list-of-recently-created-contacts
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CreatedContactsResponse> CreatedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#exporting-the-list-of-recently-modified-contacts
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ModifiedContactsResponse> ModifiedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#paginated-modified-contacts-list
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaginatedModifiedContactsResponse> PaginatedModifiedContactsAsync(
            long from,
            long to,
            int page,
            int size,
            CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#contacts-39-activity
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="allVisits"></param>
        /// <param name="ipDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactRecentActivityResponse> ContactRecentActivityAsync(
            long from,
            long to,
            bool allVisits,
            bool ipDetails,
            CancellationToken cancellationToken);

        Task<PaginatedContactsListExportResponse> PaginatedContactListExportAsync(
            int page,
            int size,
            CancellationToken cancellationToken);
    }
}