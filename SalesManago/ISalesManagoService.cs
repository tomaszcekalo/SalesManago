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
        /// <see href="https://docs.salesmanago.com/#downloading-email-messages">docs</see>
        /// </summary>
        /// <summary xml:lang="pl">
        /// <see href="https://docs.salesmanago.pl/#pobieranie-stworzonych-wiadomo-ci">docs</see>
        /// </summary>
        /// <returns></returns>
        Task<GetMessagesResponse> GetEmailMessagesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.pl/#wysy-anie-wiadomo-ci-email-zalecana">docs</see>
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="subject"></param>
        /// <param name="campaign"></param>
        /// <param name="html"></param>
        /// <param name="contacts"></param>
        /// <param name="excludeContacts"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SendEmailResponse> SendEmailAsync(
            Guid emailId,
            string subject,
            string campaign,
            string html,
            Addressee[] contacts,
            Addressee[] excludeContacts,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#checking-if-a-contact-is-already-recorded">docs</see>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<HasContactResponse> HasContactAsync(
            string email,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-basic-contacts-39-data-by-email-address">docs</see>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByEmailAsync(
            string[] email,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-basic-contacts-39-data-by-contact-id">docs</see>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByIdAsync(
            string[] id,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-email-address-for-the-owner">docs</see>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListByEmailAsync(
            string[] email,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-basic-contacts-39-data-by-contact-id">docs</see>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListByIdAsync(
            string[] contactId,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-email-address">docs</see>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByEmailAsync(
            string[] email,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-contact-39-s-id">docs</see>
        /// </summary>
        /// <param name="contactId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByIdAsync(
            string[] contactId,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#exporting-the-list-of-recently-created-contacts">docs</see>
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
        /// <see href="https://docs.salesmanago.com/#exporting-the-list-of-recently-modified-contacts">docs</see>
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
        /// <see href="https://docs.salesmanago.com/#paginated-modified-contacts-list">docs</see>
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
        /// <see href="https://docs.salesmanago.com/#contacts-39-activity">docs</see>
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

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#paginated-contacts-list-export">docs</see>
        /// </summary>
        /// <param name="page">current page</param>
        /// <param name="size">the number of returned lines (up to 1000)</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PaginatedContactsListExportResponse> PaginatedContactListExportAsync(
            int page,
            int size,
            CancellationToken cancellationToken);
    }
}