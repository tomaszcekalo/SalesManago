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
        /// <param name="birthday">date of contact companybirth, sent as a string of signs in the form: yyyyMMdd or Mmdd (yyyy – a 4-digit year, MM – a two-digit month, dd – a two-digit day)</param>
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
        /// <param name="birthday">date of contact companybirth, sent as a string of signs in the form: yyyyMMdd or Mmdd (yyyy – a 4-digit year, MM – a two-digit month, dd – a two-digit day)</param>
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
        /// <see href="https://docs.salesmanago.com/#adding-or-modifying-many-contacts-simultaneously"/>
        /// </summary>
        /// <param name="upsertDetails"></param>
        /// <param name="useApiDoubleOptIn">use double opt-in option, default true</param>
        /// <param name="lang">contact language</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactBatchUpsertAsync(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn = true,
            string? lang = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#asynchronous-adding-or-modifying-many-contacts-simultaneously"/>
        /// </summary>
        /// <param name="upsertDetails"></param>
        /// <param name="useApiDoubleOptIn">use double opt-in option, default true</param>
        /// <param name="lang">contact language</param>
        /// <param name="fireEvents">If the method is set to “false” it prevents the rules and Workflows triggered by events created during the contact upsert (import with overwriting and modification of existing contacts) from launching</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> ContactBatchUpsertV2Async(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn = true,
            string? lang = null,
            bool? fireEvents = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#deleting-many-contacts-simultaneously"/>
        /// </summary>
        /// <param name="contacts">array of contacts to delete</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ResultResponse> ContactBatchDeleteAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#deleting-a-contact"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ResultResponse> DeleteContactAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#checking-if-a-contact-is-already-recorded"/>
        /// </summary>
        /// <param name="email">contact’s email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> HasContactAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-basic-contacts-39-data-by-email-address"/>
        /// </summary>
        /// <param name="email">array of contacts email for the exported contacts</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByEmailAsync(
            string[] email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-basic-contacts-39-data-by-contact-id"/>
        /// </summary>
        /// <param name="id">array of identifiers for the exported contacts</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactBasicByIdAsync(
            string[] id,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-email-address-for-the-owner"/>
        /// </summary>
        /// <param name="email">array of contacts email for the exported contacts (** up to 50 contacts at once **)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListByEmailAsync(
            string[] email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-contact-39-s-id-for-the-owner"/>
        /// </summary>
        /// <param name="contactId">array of identifiers for the exported contacts (** up to 50 contacts at once **)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListByIdAsync(
            string[] contactId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-email-address"/>
        /// </summary>
        /// <param name="email">array of contacts email for the exported contacts (** up to 50 contacts at once **)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByEmailAsync(
            string[] email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-based-on-contact-39-s-id"/>
        /// </summary>
        /// <param name="contactId">array of identifiers for the exported contacts (** up to 50 contacts at once **)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactBasicExportResponse> ContactListAllByIdAsync(
            string[] contactId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#exporting-the-list-of-recently-created-contacts"/>
        /// </summary>
        /// <param name="from">beginning range of creation dates</param>
        /// <param name="to">ending range of creation dates</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<CreatedContactsResponse> CreatedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#exporting-the-list-of-recently-modified-contacts"/>
        /// </summary>
        /// <param name="from">beginning range of modification dates</param>
        /// <param name="to">ending range of modification dates</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ModifiedContactsResponse> ModifiedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#paginated-modified-contacts-list"/>
        /// </summary>
        /// <param name="from">modification date (ms), from which contacts will be searched</param>
        /// <param name="to">modification date (ms), to which contacts will be searcged</param>
        /// <param name="page">currently returned result page</param>
        /// <param name="size">size of returned result page</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<PaginatedModifiedContactsResponse> PaginatedModifiedContactsAsync(
            long from,
            long to,
            int page,
            int size,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#contacts-39-activity"/>
        /// </summary>
        /// <param name="from">beginning date (timestamp, i.e. time in milliseconds that passed from midnight 1 January 1970 UTC)</param>
        /// <param name="to">ending date (timestamp, i.e. time in milliseconds that passed from midnight 1 January 1970 UTC)</param>
        /// <param name="allVisits">if set at true, SALESmanago will return in visit details information about all pages opened by the customer in a given period</param>
        /// <param name="ipDetails">if set at true, SALESmanago will return in visit details additional information searched for client IP</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactRecentActivityResponse> ContactRecentActivityAsync(
            long from,
            long to,
            bool? allVisits = null,
            bool? ipDetails = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#paginated-contacts-list-export"/>
        /// </summary>
        /// <param name="page">current page</param>
        /// <param name="size">the number of returned lines (up to 1000)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> PaginatedContactListExportAsync(
            int page,
            int size,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#paginated-contacts-list-for-provided-owner"/>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactPaginatedListByIdResponse> ContactPaginatedListByIdAsync(
            int page,
            int size,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///
        /// </summary>
        /// <param name="contact">contact’s email</param>
        /// <param name="owner">contact’s owner</param>
        /// <param name="newOwner">new contact’s owner (SALESmanago user account email)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactPaginatedListByIdResponse> ContactSetMainOwnerAsync(
            string contact,
            string owner,
            string newOwner,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#stop-contacts-39-monitoring"/>
        /// </summary>
        /// <param name="contacts">array of contacts</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> ContactStopMonitoringAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#restore-contacts-39-monitoring"/>
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> ContactRestoreMonitoringAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://www.salesmanago.pl/api/contact/useContactCoupon"/>
        /// </summary>
        /// <param name="email">contact email</param>
        /// <param name="coupon">coupon name</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> UseContactCouponAsync(
            string email,
            string coupon,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// https://www.salesmanago.pl/api/contact/addContactCoupon
        /// </summary>
        /// <param name="name">coupon name</param>
        /// <param name="email">contact email</param>
        /// <param name="length">length of coupon in case of automatic generation (the value from 5 to 64)</param>
        /// <param name="coupon">value of coupon in case of manual input (5 characters minimum)</param>
        /// <param name="valid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BaseResponse> AddContactCouponAsync(
           string name,
           string email,
           string coupon,
           long? valid = null,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// https://www.salesmanago.pl/api/contact/addContactCoupon
        /// </summary>
        /// <param name="name">coupon name</param>
        /// <param name="email">contact email</param>
        /// <param name="length">length of coupon in case of automatic generation (the value from 5 to 64)</param>
        /// <param name="coupon">value of coupon in case of manual input (5 characters minimum)</param>
        /// <param name="valid"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BaseResponse> AddContactCouponAsync(
           string name,
           string email,
           int length,
           long? valid = null,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-funnel"/>
        /// </summary>
        /// <param name="funnel">name of funnel</param>
        /// <param name="stages">list of funnel stages</param>
        /// <param name="potValue">default value of contacts</param>
        /// <param name="group">group funnel</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> AddFunnel(
            string funnel,
            Stage[] stages,
            int? potValue = null,
            string? group = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-contacts-to-the-funnel"/>
        /// </summary>
        /// <param name="funnel">name of funnel</param>
        /// <param name="stage">name of stage</param>
        /// <param name="contacts">the email address of the contact, its ID, tag or funnel</param>
        /// <param name="potValue">default value of contacts</param>
        /// <param name="modify"></param>
        /// <param name="cancellationToken">(boolean value) the contact is to be marked as modified when added to the funnel default false</param>
        /// <returns></returns>
        Task<AddContactsToFunnelResponse> AddContactsToFunnelAsync(
            string funnel,
            string stage,
            Addressee[] contacts,
            int? potValue = null,
            bool? modify = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#deleting-funnel-stage"/>
        /// </summary>
        /// <param name="funnel">name of funnel</param>
        /// <param name="stage">name of stage
        /// - optional parameter
        /// - when empty, the method removes the entire funnel when the completed deletes the selected stage in the funnel</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> DeleteFunnelOrStageAsync(
            string funnel,
            string? stage = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#getting-the-number-of-contacts-in-the-funnel-stage"/>
        /// </summary>
        /// <param name="funnel">name of funnel</param>
        /// <param name="stage">name of stage
        /// - optional parameter
        /// - when empty, the method removes the entire funnel when the completed deletes the selected stage in the funnel</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<CountResponse> CountContactsInFunnelOrStageAsync(
            string funnel,
            string? stage = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#unsubscribing-a-contact-from-the-list-opt-out"/>
        /// </summary>
        /// <param name="email">contact’s email (can be used as alternative for contactId)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactOptOutAsync(
           string email,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#unsubscribing-a-contact-from-the-list-opt-out"/>
        /// </summary>
        /// <param name="contactId">contact’s identifier (can be used as alternative for contact email)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactOptOutAsync(
            Guid contactId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-a-contact-to-the-list-opt-in"/>
        /// </summary>
        /// <param name="email">contact’s email (can be used as alternative for contactId)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactOptInAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-a-contact-to-the-list-opt-in"/>
        /// </summary>
        /// <param name="contactId">contact’s identifier (can be used as alternative for contact email)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactOptInAsync(
            Guid contactId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#mass-unsubscribing-contacts-from-the-list-opt-out"/>
        /// </summary>
        /// <param name="emails">array of contacts email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactBatchOptOutAsync(
            string[] emails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-mass-contacts-to-the-list-opt-in"/>
        /// </summary>
        /// <param name="emails">array of contacts email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdsResponse> ContactBatchOptInAsync(
            string[] emails,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-a-contact-to-the-phone-list-opt-in-phone"/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactPhoneOptInAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#unsubscribing-a-contact-from-the-phone-list-opt-out-phone"/>
        /// </summary>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactPhoneOptOutAsync(
            string email,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#unsubscribing-a-contact-from-the-phone-list-opt-out-phone"/>
        /// </summary>
        /// <param name="contactId">contact’s identifier (can be used as alternative for contact email)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ContactIdResponse> ContactPhoneOptOutAsync(
            Guid contactId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-an-external-event-recommended"/>
        /// </summary>
        /// <param name="contactEvent">contactEvent</param>
        /// <param name="contactId">contact id from SALESmanago system (can be used as alternative for contact email)</param>
        /// <param name="forceOptIn">value true will create contact as opt-in</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<EventIdResponse> AddContactExternalEventAsync(
            ContactEvent contactEvent,
            Guid contactId,
            bool forceOptIn = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-an-external-event-recommended"/>
        /// </summary>
        /// <param name="contactEvent">contactEvent</param>
        /// <param name="email">contact’s email for which the event is added</param>
        /// <param name="forceOptIn">value true will create contact as opt-in</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<EventIdResponse> AddContactExternalEventAsync(
            ContactEvent contactEvent,
            string email,
            bool forceOptIn = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-many-contact-external-events-simultaneously"/>
        /// </summary>
        /// <param name="events">external events list (list cannot be empty and it’s limited to 1000)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BatchAddContactExtEventResponse> BatchAddContactExternalEventAsync(
            ContactExternalEvent[] events,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#modifying-external-event-recommended"/>
        /// </summary>
        /// <param name="contactEvent">contactEvent</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<EventIdResponse> UpdateContactExternalEventAsync(
            ContactEvent contactEvent,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#removing-an-event"/>
        /// </summary>
        /// <param name="eventId">event ID (returned by the add method)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ResultResponse> DeleteContactExternalEventAsync(
            Guid eventId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-of-tag-list"/>
        /// </summary>
        /// <param name="showSystemTags">when set at true, SALESmanago will also return system tags</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<TagsResponse> ExportTagListAsync(
            bool showSystemTags,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#sending-email-recommended"/>
        /// </summary>
        /// <param name="emailId">message ID from the SALESmanago system</param>
        /// <param name="contacts">array of contacts to which email will be sent</param>
        /// <param name="excludeContacts">array of contacts which will be excluded from dispatch</param>
        /// <param name="html">HTML email body (if not provided – a default will be used). An opt-out link ($opt-out$) is required</param>
        /// <param name="subject">mailing subject (if not provided – a default will be used)</param>
        /// <param name="campaign">campaign for tracing Google UTM (if not provided – a default will be used)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConversationIdResponse> SendEmailAsync(
            Guid emailId,
            Addressee[] contacts,
            Addressee[]? excludeContacts = null,
            string? html = null,
            string? subject = null,
            string? campaign = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#sending-email-with-attachment"/>
        /// </summary>
        /// <param name="emailId">message ID from the SALESmanago system</param>
        /// <param name="contacts">array of contacts to which email will be sent</param>
        /// <param name="excludeContacts">array of contacts which will be excluded from dispatch</param>
        /// <param name="html">HTML email body (if not provided – a default will be used)</param>
        /// <param name="subject">mailing subject (if not provided – a default will be used)</param>
        /// <param name="campaign">campaign for tracing Google UTM (if not provided – a default will be used)</param>
        /// <param name="immediate">attributing a true value will cause immediate dispatch of mail</param>
        /// <param name="rule">attributing a true value will cause message mark as rule email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConversationIdResponse> SendEmailWithAttachmentAsync(
           Guid emailId,
           Addressee[] contacts,
           Addressee[]? excludeContacts = null,
           string? html = null,
           string? subject = null,
           string? campaign = null,
           bool? immediate = null,
           bool? rule = null,
           CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-email-messages"/>
        /// </summary>
        /// <param name="subject">email message subject</param>
        /// <param name="contentBoxMap">map containing the names and values of specific fields</param>
        /// <param name="EmailAccountId">email account ID</param>
        /// <param name="TemplateId">email template ID</param>
        /// <param name="campaign">campaign name</param>
        /// <param name="shared">boolean value that indicates whether the template is shared</param>
        /// <param name="dynamic">boolean value that indicates whether the template is dynamic</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<EmailIdResponse> AddEmailAsync(
            string subject,
            Dictionary<string, string> contentBoxMap,
            Guid EmailAccountId,
            Guid TemplateId,
            string? campaign = null,
            bool? shared = null,
            bool? dynamic = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-or-modifying-email-message"/>
        /// </summary>
        /// <param name="subject">email message subject</param>
        /// <param name="EmailAccountId">email account ID</param>
        /// <param name="TemplateId">email template ID</param>
        /// <param name="campaign">campaign name</param>
        /// <param name="shared">boolean value that indicates whether the template is shared</param>
        /// <param name="dynamic">boolean value that indicates whether the template is dynamic</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<EmailIdResponse> UpsertEmailByNameAsync(
            Guid EmailAccountId,
            Guid TemplateId,
            string? subject = null,
            bool? shared = null,
            bool? dynamic = null,
            string? campaign = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-email-template"/>
        /// </summary>
        /// <param name="urlTemplate">template url</param>
        /// <param name="emailContent">html email content</param>
        /// <param name="shared">boolean value that indicates whether the template is shared</param>
        /// <param name="dynamic">boolean value that indicates whether the template is dynamic</param>
        /// <param name="parametrized">boolean value that indicates whether the template accepts parameters before sending</param>
        /// <param name="fromUrl">boolean value that indicates whether the template is to use a template from the link html</param>
        /// <param name="titleUrl">boolean value that indicates whether the template is to use the title of the e-mail link</param>
        /// <param name="customFields">additional template fields</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<TemplateIdResponse> EmailAddTemplateAsync(
            string urlTemplate,
            string? emailContent = null,
            bool? shared = null,
            bool? dynamic = null,
            bool? parametrized = null,
            bool? fromUrl = null,
            bool? titleUrl = null,
            string? customFields = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-or-modifying-email-template"/>
        /// </summary>
        /// <param name="emailContent">html email content</param>
        /// <param name="urlTemplate">template url</param>
        /// <param name="shared">boolean value that indicates whether the template is shared</param>
        /// <param name="dynamic">boolean value that indicates whether the template is dynamic</param>
        /// <param name="parametrized">boolean value that indicates whether the template accepts parameters before sending</param>
        /// <param name="fromUrl">boolean value that indicates whether the template is to use a template from the link html</param>
        /// <param name="titleUrl">boolean value that indicates whether the template is to use the title of the e-mail link</param>
        /// <param name="customFields">additional template fields</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<TemplateIdResponse> EmailUpsertTemplateAsync(
            string emailContent,
            string urlTemplate,
            bool? shared = null,
            bool? dynamic = null,
            bool? parametrized = null,
            bool? fromUrl = null,
            bool? titleUrl = null,
            string? customFields = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-email-messages">docs</see>
        /// </summary>
        /// <summary xml:lang="pl">
        /// <see href="https://docs.salesmanago.pl/#pobieranie-stworzonych-wiadomo-ci">docs</see>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<GetMessagesResponse> DownloadEmailMessagesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-mass-conversation"/>
        /// </summary>
        /// <param name="from">beginning range of conversations creation dates</param>
        /// <param name="to">ending range of conversations creation dates</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConversationListResponse> DownloadMassConversationAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default
            );

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-mass-conversation-direct-emails"/>
        /// </summary>
        /// <param name="from">beginning range of conversations creation dates</param>
        /// <param name="to">ending range of conversations creation dates</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConversationListResponse> DownloadMassConversationDirectEmailsAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-conversation-statistics"/>
        /// </summary>
        /// <param name="conversationId">conversation ID</param>
        /// <param name="user">e-mail address of user</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>In response, you will receive “requestId”, which is the export id.</returns>
        Task<RequestIdResponse> DownloadConversationStatisticsAsync(
            Guid conversationId,
            string user,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// To check the process status, you need to send a POST request to: https://www.salesmanago.pl/api/job/status
        /// You need to give requestId(output of previous method), which contains number to check the status of export.
        /// In response, you will receive either the message about the progress of the export or a link to the file with exported contacts.
        /// </summary>
        /// <param name="requestId">contains number to check the status of export</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>you will receive either the message about the progress of the export or a link to the file</returns>
        Task<FileUrlResponse> JobStatusAsync(
            int requestId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-contacts-to-whom-email-was-sent"/>
        /// </summary>
        /// <param name="conversationId">conversation identifier</param>
        /// <param name="user">e-mail address of user</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> DownloadMessageStatisticsAsync(
            Guid conversationId,
            string user,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#sending-your-subscription-confirmation"/>
        /// </summary>
        /// <param name="email">contact’s email</param>
        /// <param name="apiDoubleOptInEmailTemplateId">optional template ID for double-opt-in</param>
        /// <param name="apiDoubleOptInEmailAccountId">optional email account ID for double-opt-in</param>
        /// <param name="apiDoubleOptInEmailSubject">optional email subject for double-opt-in</param>
        /// <param name="tag">optional parameter defining tag which must have email contacts for confirmation purpose</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> SendSubscriptionConfirmationAsync(
            string email,
            string apiDoubleOptInEmailTemplateId,
            string apiDoubleOptInEmailAccountId,
            string apiDoubleOptInEmailSubject,
            string? tag = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#sending-your-subscription-confirmation"/>
        /// </summary>
        /// <param name="email">contact’s email</param>
        /// <param name="lang">language of sent email</param>
        /// <param name="tag">optional parameter defining tag which must have email contacts for confirmation purpose</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> SendSubscriptionConfirmationAsync(
            string email,
            string lang,
            string? tag = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#sms-sending"/>
        /// </summary>
        /// <param name="user">user email</param>
        /// <param name="text">message text</param>
        /// <param name="contacts">contact object list</param>
        /// <param name="gateway">gateway name</param>
        /// <param name="name">campaign name</param>
        /// <param name="date">current timestamp (ms)</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<BaseResponse> SendSmsAsync(
            string user,
            string text,
            Recipient[] contacts,
            string? gateway = null,
            string? name = null,
            long? date = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-statistics-of-sms-campaigns-by-conversation-id"/>
        /// </summary>
        /// <param name="conversationId">conversation ID</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<SmsConversationStatisticsResponse> StatisticsOfSmsCampaignsByConversationIdAsync(
            Guid conversationId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#dowloading-statistics-of-sms-campaigns-by-conversation-name"/>
        /// </summary>
        /// <param name="name">conversation name</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<SmsConversationStatisticsResponse> StatisticsOfSmsCampaignsByNameAsync(
            string name,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-sms-conversation-statistics"/>
        /// </summary>
        /// <param name="conversationId">conversation identifier</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<SmsConversationStatisticsResponse> DownloadSmsConversationStatisticsAsync(
            Guid conversationId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-mass-conversation76"/>
        /// </summary>
        /// <param name="from">beginning range of conversations creation dates</param>
        /// <param name="to">ending range of conversations creation dates</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConversationListResponse> SmsDownloadMassConversationListAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#contacts-39-tasks"/>
        /// </summary>
        /// <param name="smContactTaskReq">smContactTaskReq</param>
        /// <param name="finished">attributing a true value will cause deletion of task and then only an additional ID parameter is required.
        /// When adding and updating a task, a false value should be attributed</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>
        /// </returns>
        Task<TaskIdResponse> ContactUpdateTaskAsync(
            SmsContactTask smContactTaskReq,
            bool? finished = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-note"/>
        /// </summary>
        /// <param name="contactId">contact’s identifier for which the note is added (can be used as alternative for contact email)</param>
        /// <param name="email">contact’s email for which the note is added</param>
        /// <param name="note">note content</param>
        /// <param name="priv">defines whether the note should be private, i.e. visible only by the adder (default false)</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> AddNoteAsync(
            string contactId,
            string email,
            string note,
            bool priv = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#getting-list-of-user-accounts-for-a-client"/>
        /// </summary>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<UsersResponse> ListUserAccountsByClientAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#temporary-authorization"/>
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="password">password</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<AuthoriseResponse> AuthoriseAsync(
            string userName,
            string password,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-the-list-of-workflow-2-0"/>
        /// </summary>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns>
        /// </returns>
        Task<WorkflowListResponse> DownloadWorkflowListAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-statistics-of-sending-web-push-notifications"/>
        /// </summary>
        /// <param name="wizardId">mailing identifier</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<WebPushStatsResponse> WebPushStatsAsync(
            long wizardId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#downloading-the-list-of-web-push-notification-identifiers"/>
        /// </summary>
        /// <param name="from">the beginning of the date range of sent web push notifications</param>
        /// <param name="to">the end of the range date of sent web push notifications</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<WebPushIdsResponse> WebPushIdsAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#web-push-notification-id-list"/>
        /// </summary>
        /// <param name="from">modification date (ms), from which contacts will be searched</param>
        /// <param name="to">modification date (ms), to which contacts will be searched</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PushConversationIdsResponse> WebPushNotificationIdListAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-consent-forms-statistics-to-a-file-accessible-from-the-repository"/>
        /// </summary>
        /// <param name="inId">form id</param>
        /// <param name="user">user email</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> ExportConsentFormsStatisticsAsync(
            int inId,
            string user,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#export-web-push-notifications-statistics-to-a-file-accessible-from-the-repository"/>
        /// </summary>
        /// <param name="itemId">user email</param>
        /// <param name="user">user email</param>
        /// <param name="webPushSourceType">webpush type</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<RequestIdResponse> ExportWebPushNotificationStatisticsAsync(
            int itemId,
            string user,
            string webPushSourceType,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#name-and-id-of-a-consent-form"/>
        /// </summary>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ConsentFormListResponse> ConsentFormDataAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-contact-to-loyalty-program"/>
        /// </summary>
        /// <param name="contacts">array of contacts to adding</param>
        /// <param name="loyaltyProgram">name of loyalty program</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<PointsResponse> AddContactToLoyaltyProgramAsync(
            AddresseeBase[] contacts,
            string loyaltyProgram,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#removing-contact-from-loyalty-program"/>
        /// </summary>
        /// <param name="contacts">array of contacts to adding</param>
        /// <param name="loyaltyProgram">name of loyalty program</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<PointsResponse> RemoveContactFromLoyaltyProgramAsync(
            AddresseeBase[] contacts,
            string loyaltyProgram,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#adding-removing-contact-points-to-loyalty-program"/>
        /// </summary>
        /// <param name="contacts">list of Contacts to have the number of points changed (in accordance to other API methods with addresseeType)</param>
        /// <param name="loyaltyProgram">name of loyalty program</param>
        /// <param name="points">number of points</param>
        /// <param name="modificationType">modification type</param>
        /// <param name="comment">comment of modification</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<BaseResponse> ModifyPointsInLoyaltyProgramAsync(
            AddresseeBase[] contacts,
            string loyaltyProgram,
            int points,
            ModificationType modificationType,
            string? comment = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#last-viewed-products"/>
        /// </summary>
        /// <param name="shopName">data source name</param>
        /// <param name="contactUuid">smuuid cookie value</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ProductIdsResponse> LastViewedProducstsAsync(
            string shopName,
            Guid contactUuid,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#most-purchased-products"/>
        /// </summary>
        /// <param name="shopName">data source name</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ProductIdsResponse> MostPurchasedProductsAsync(
            string shopName,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#products-purchased-by-contact-only-for-monitored-contacts"/>
        /// </summary>
        /// <param name="shopName">data source name</param>
        /// <param name="smClient">smclient cookie value</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ProductIdsResponse> ProductsPurchasedByContactAsync(
            string shopName,
            Guid smClient,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#products-purchased-with-the-product-being-viewed"/>
        /// </summary>
        /// <param name="shopName">data source name</param>
        /// <param name="productId">product id</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<ProductIdsResponse> PurchasedTogetherAsync(
            string shopName,
            int productId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// <see href="https://docs.salesmanago.com/#product-recommendations-based-on-salesmanago-cinderella-ai"/>
        /// </summary>
        /// <param name="urlImg">the url of the searched image</param>
        /// <param name="vendorDataSourceIntId">product feed ID - is available in settings -> integration -> product feeds</param>
        /// <param name="cancellationToken">cancellationToken</param>
        /// <returns></returns>
        Task<VisionResponse> VisionAsync(
            string urlImg,
            int vendorDataSourceIntId,
            CancellationToken cancellationToken = default);
    }
}