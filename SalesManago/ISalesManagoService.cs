using SalesManago.Common;
using SalesManago.Responses;
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
        ///
        /// </summary>
        /// <typeparam name="T">Type of response that gets returned </typeparam>
        /// <param name="url">url to the endpoint</param>
        /// <param name="content">object to be serialized into request body</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <param name="contentType">contentType of request,
        /// application/json is default used for most of them</param>
        /// <returns></returns>
        Task<T> SendSalesManagoRequest<T>(
            string url,
            object? content,
            CancellationToken cancellationToken = default,
            string contentType = "application/json");

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-email-messages">docs</see>
        /// </summary>
        /// <summary xml:lang="pl">
        /// <see href="https://docs.salesmanago.pl/#pobieranie-stworzonych-wiadomo-ci">docs</see>
        /// </summary>
        /// <returns></returns>
        Task<GetMessagesResponse> DownloadEmailMessagesAsync(CancellationToken cancellationToken);

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
        Task<ConversationIdResponse> SendEmailAsync(
            Guid emailId,
            Addressee[] contacts,
            Addressee[] excludeContacts = null,
            string? html = null,
            string? subject = null,
            string? campaign = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-a-new-contact-or-modifying-the-existing-contact"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="contactId"></param>
        /// <param name="contact"></param>
        /// <param name="forceOptIn">forcing opt-in after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forceOptOut">forcing opt-out after adding/modification</param>
        /// <param name="forcePhoneOptIn">forcing opt-in to a phone after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forcePhoneOptOut">forcing opt-out from a phone after adding/modification</param>
        /// <param name="tags">array of contact’s tags</param>
        /// <param name="removeTags">array of tags to be removed</param>
        /// <param name="properties">contact attributes defined by the user. It is advised not to use special characters and spaces in the name, but it is allowed</param>
        /// <param name="dictionaryProperties">user-defined attributes of the dictionary, the first to add a particular attribute can be used for the remaining contacts through re-enter the same name and type of the assigned another value.</param>
        /// <param name="birthday"></param>
        /// <param name="province"></param>
        /// <param name="consentDetails"></param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactUpsertAsync(
            string email,
            string contactId,
            ContactBase contact,
            bool forceOptIn,
            bool forceOptOut,
            bool forcePhoneOptIn,
            bool forcePhoneOptOut,
            string[] tags,
            string removeTags,
            Dictionary<string, string> properties,
            DictionaryProperty[] dictionaryProperties,
            string birthday,
            string province,
            ConsentDetail[] consentDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-a-new-contact"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="contactId"></param>
        /// <param name="contact"></param>
        /// <param name="forceOptIn">forcing opt-in after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forceOptOut">forcing opt-out after adding/modification</param>
        /// <param name="forcePhoneOptIn">forcing opt-in to a phone after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forcePhoneOptOut">forcing opt-out from a phone after adding/modification</param>
        /// <param name="tags">array of contact’s tags</param>
        /// <param name="removeTags">array of tags to be removed</param>
        /// <param name="properties">contact attributes defined by the user. It is advised not to use special characters and spaces in the name, but it is allowed</param>
        /// <param name="dictionaryProperties">user-defined attributes of the dictionary, the first to add a particular attribute can be used for the remaining contacts through re-enter the same name and type of the assigned another value.</param>
        /// <param name="birthday"></param>
        /// <param name="province"></param>
        /// <param name="consentDetails"></param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactInsertAsync(
            string email,
            string contactId,
            ContactBase contact,
            bool forceOptIn,
            bool forceOptOut,
            bool forcePhoneOptIn,
            bool forcePhoneOptOut,
            string[] tags,
            string removeTags,
            Dictionary<string, string> properties,
            DictionaryProperty[] dictionaryProperties,
            string birthday,
            string province,
            ConsentDetail[] consentDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#modifying-an-existing-contact"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="contactId"></param>
        /// <param name="contact"></param>
        /// <param name="forceOptIn">forcing opt-in after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forceOptOut">forcing opt-out after adding/modification</param>
        /// <param name="forcePhoneOptIn">forcing opt-in to a phone after adding/modification (if the previous option has not been chosen)</param>
        /// <param name="forcePhoneOptOut">forcing opt-out from a phone after adding/modification</param>
        /// <param name="tags">array of contact’s tags</param>
        /// <param name="removeTags">array of tags to be removed</param>
        /// <param name="properties">contact attributes defined by the user. It is advised not to use special characters and spaces in the name, but it is allowed</param>
        /// <param name="dictionaryProperties">user-defined attributes of the dictionary, the first to add a particular attribute can be used for the remaining contacts through re-enter the same name and type of the assigned another value.</param>
        /// <param name="birthday"></param>
        /// <param name="province"></param>
        /// <param name="consentDetails"></param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactUpdateAsync(
            string email,
            string contactId,
            ContactBase contact,
            bool forceOptIn,
            bool forceOptOut,
            bool forcePhoneOptIn,
            bool forcePhoneOptOut,
            string[] tags,
            string removeTags,
            Dictionary<string, string> properties,
            DictionaryProperty[] dictionaryProperties,
            string birthday,
            string province,
            ConsentDetail[] consentDetails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// https://docs.salesmanago.com/#adding-or-modifying-many-contacts-simultaneously
        /// </summary>
        /// <param name="upsertDetails"></param>
        /// <param name="useApiDoubleOptIn"></param>
        /// <param name="lang"></param>
        /// <param name="fireEvents"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactBatchUpsertAsync(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn,
            string lang,
            bool fireEvents,
            CancellationToken cancellationToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="upsertDetails"></param>
        /// <param name="useApiDoubleOptIn">use double opt-in option, default true</param>
        /// <param name="lang">contact language</param>
        /// <param name="fireEvents">If the method is set to “false” it prevents the rules and Workflows triggered by events created during the contact upsert (import with overwriting and modification of existing contacts) from launching</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> ContactBatchUpsertV2Async(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn,
            string lang,
            bool fireEvents,
            CancellationToken cancellationToken);

        /// <summary>
        /// https://docs.salesmanago.com/#deleting-many-contacts-simultaneously
        /// </summary>
        /// <param name="contacts">array of contacts to delete</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ResultResponse> ContactBatchDeleteAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#deleting-a-contact"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ResultResponse> DeleteContactAsync(
            string email,
            CancellationToken cancellationToken);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#checking-if-a-contact-is-already-recorded">docs</see>
        /// </summary>
        /// <param name="email">contact’s email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> HasContactAsync(
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
        Task<RequestIdResponse> PaginatedContactListExportAsync(
            int page,
            int size,
            CancellationToken cancellationToken);
    }
}