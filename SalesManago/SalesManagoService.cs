using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using SalesManago.Responses;
using System.Collections.Specialized;
using SalesManago.Common;

namespace SalesManago
{
    public class SalesManagoService : ISalesManagoService
    {
        private SalesManagoSettings _settings;
        private HttpClient _client;
        public JsonSerializerSettings Settings { get; init; }

        public SalesManagoService(SalesManagoSettings settings, HttpClient httpClient)
        {
            _settings = settings;
            _client = httpClient;
            _client.BaseAddress = new Uri(settings.Endpoint);
            _client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
            Settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public (string apiKey, string sha, long requestTime) GetSalesManagoBase()
        {
            var apiKey = Guid.NewGuid().ToString().ToLower();
            var sha = GetSHA(apiKey);
            var requestTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (apiKey, sha, requestTime);
        }

        public async Task<T> SendSalesManagoRequest<T>(
            string url,
            object? content,
            CancellationToken cancellationToken = default,
            string contentType = "application/json")
        {
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                url);
            var serialized = JsonConvert.SerializeObject(content, Formatting.Indented);
            request.Content = new StringContent(
                serialized,
                Encoding.UTF8,
                contentType);

            var response = await _client.SendAsync(request, cancellationToken);
            using (HttpContent responseContent = response.Content)
            {
                var json = await responseContent.ReadAsStringAsync(cancellationToken);
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<ContactIdsResponse> ContactUpsertAsync(
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
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email,
                contactId,
                contact,
                forceOptIn,
                forceOptOut,
                forcePhoneOptIn,
                forcePhoneOptOut,
                tags,
                removeTags,
                properties,
                dictionaryProperties,
                birthday,
                province,
                consentDetails
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/upsert", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdsResponse> ContactInsertAsync(
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
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email,
                contactId,
                contact,
                forceOptIn,
                forceOptOut,
                forcePhoneOptIn,
                forcePhoneOptOut,
                tags,
                removeTags,
                properties,
                dictionaryProperties,
                birthday,
                province,
                consentDetails
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/insert", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdsResponse> ContactUpdateAsync(
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
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email,
                contactId,
                contact,
                forceOptIn,
                forceOptOut,
                forcePhoneOptIn,
                forcePhoneOptOut,
                tags,
                removeTags,
                properties,
                dictionaryProperties,
                birthday,
                province,
                consentDetails
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/update", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdsResponse> ContactBatchUpsertAsync(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn,
            string lang,
            bool fireEvents,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                upsertDetails,
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/batchupsert", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> ContactBatchUpsertV2Async(
            UpsertDetail[] upsertDetails,
            bool useApiDoubleOptIn,
            string lang,
            bool fireEvents,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                upsertDetails,
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/contact/batchupsertv2", content, cancellationToken);
            return result;
        }

        public async Task<ResultResponse> ContactBatchDeleteAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contacts,
            };
            var result = await this.SendSalesManagoRequest<ResultResponse>(
                "api/contact/batchDelete", content, cancellationToken);
            return result;
        }

        public async Task<ResultResponse> DeleteContactAsync(
            string email,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email
            };
            var result = await this.SendSalesManagoRequest<ResultResponse>(
                "api/contact/delete", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdResponse> HasContactAsync(
            string email,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactIdResponse>(
                "api/contact/hasContact", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactBasicByEmailAsync(string[] email, CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/basic", content, cancellationToken);
            return result;
        }

        internal string GetSHA(string apiKey)
        {
            var input = apiKey + _settings.ClientId + _settings.ApiSecret;
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    // can be "X2" if you want uppercase
                    sb.Append(b.ToString("x2"));
                }
                var sha = sb.ToString();
                return sha;
            }
        }

        public async Task<ContactBasicExportResponse> ContactBasicByIdAsync(string[] id, CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                id
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/basicById", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListByEmailAsync(string[] email, CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/list", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListByIdAsync(
            string[] contactId,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                contactId
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/basicById", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListAllByEmailAsync(
            string[] email,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/listAll", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListAllByIdAsync(string[] contactId, CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                contactId
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/listAllById", content, cancellationToken);
            return result;
        }

        public async Task<CreatedContactsResponse> CreatedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<CreatedContactsResponse>(
                "api/contact/createdContacts", content, cancellationToken);
            return result;
        }

        public async Task<ModifiedContactsResponse> ModifiedContactsAsync(
            long from,
            long to,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<ModifiedContactsResponse>(
                "api/contact/modifiedContacts", content, cancellationToken);
            return result;
        }

        public async Task<PaginatedModifiedContactsResponse> PaginatedModifiedContactsAsync(
            long from,
            long to,
            int page,
            int size,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                from,
                to,
                page,
                size
            };
            var result = await this.SendSalesManagoRequest<PaginatedModifiedContactsResponse>(
                "api/contact/paginatedModifiedContacts", content, cancellationToken);
            return result;
        }

        public async Task<ContactRecentActivityResponse> ContactRecentActivityAsync(
            long from,
            long to,
            bool allVisits,
            bool ipDetails,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                from,
                to,
                allVisits,
                ipDetails
            };
            var result = await this.SendSalesManagoRequest<ContactRecentActivityResponse>(
                "api/contact/recentActivity", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> PaginatedContactListExportAsync(
            int page,
            int size,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                page,
                size
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/contact/paginatedContactList/export", content, cancellationToken);
            return result;
        }

        public async Task<ContactPaginatedListByIdResponse> ContactPaginatedListByIdAsync(
            int page,
            int size,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                page,
                size
            };
            var result = await this.SendSalesManagoRequest<ContactPaginatedListByIdResponse>(
                "api/contact/paginatedListById", content, cancellationToken);
            return result;
        }

        //https://www.salesmanago.pl/api/contact/setMainOwner

        //https://www.salesmanago.pl/api/contact/stopMonitoring
        public async Task<BaseResponse> ContactStopMonitoringAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contacts
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/contact/stopMonitoring", content, cancellationToken);
            return result;
        }

        //https://www.salesmanago.pl/api/contact/restoreMonitoring
        public async Task<BaseResponse> ContactRestoreMonitoringAsync(
            Addressee[] contacts,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contacts
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/contact/restoreMonitoring", content, cancellationToken);
            return result;
        }

        //https://www.salesmanago.pl/api/contact/useContactCoupon
        public async Task<BaseResponse> UseContactCouponAsync(
            string email,
            string coupon,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email,
                coupon
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/contact/useContactCoupon", content, cancellationToken);
            return result;
        }

        //https://www.salesmanago.pl/api/contact/addContactCoupon
        public async Task<BaseResponse> AddContactCouponAsync(
            string name,
            string email,
            int length,
            string coupon,
            long valid,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                name,
                email,
                length,
                valid,
                coupon
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/contact/addContactCoupon", content, cancellationToken);
            return result;
        }

        public async Task<BaseResponse> AddFunnel(
            string funnel,
            string group,
            int potValue,
            Stage[] stages,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                funnel,
                group,
                potValue,
                stages
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/funnel/add", content, cancellationToken);
            return result;
        }

        public async Task<AddContactsToFunnelResponse> AddContactsToFunnelAsync(
            string funnel,
            string stage,
            int potValue,
            bool modify,
            Addressee[] contacts,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                funnel,
                stage,
                potValue,
                modify,
                contacts
            };
            var result = await this.SendSalesManagoRequest<AddContactsToFunnelResponse>(
                "api/funnel/add", content, cancellationToken);
            return result;
        }

        public async Task<BaseResponse> DeleteFunnelOrStageAsync(
            string funnel,
            string stage = "",
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                funnel,
                stage
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/funnel/delete", content, cancellationToken);
            return result;
        }

        public async Task<CountResponse> CountContactsInFunnelOrStageAsync(
            string funnel,
            string stage = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                funnel,
                stage
            };
            var result = await this.SendSalesManagoRequest<CountResponse>(
                "api/funnel/count", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdResponse> ContactOptOutAsync(
            Guid? contactId,
            string? email,
            CancellationToken cancellationToken)
        {
            if (!contactId.HasValue && email == null)
            {
                throw new ArgumentException($"At least one of parameters ({contactId} and {email}) should have a value.");
            }
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contactId,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactIdResponse>(
                "api/contact/optout", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdResponse> ContactOptInAsync(
            Guid? contactId,
            string? email,
            CancellationToken cancellationToken)
        {
            if (!contactId.HasValue && email == null)
            {
                throw new ArgumentException($"At least one of parameters ({contactId} and {email}) should have a value.");
            }
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contactId,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactIdResponse>(
                "api/contact/optin", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdsResponse> ContactBatchOptOutAsync(
            string[] emails,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                emails
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/batchoptout", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdsResponse> ContactBatchOptInAsync(
            string[] emails,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                emails
            };
            var result = await this.SendSalesManagoRequest<ContactIdsResponse>(
                "api/contact/batchoptin", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdResponse> ContactPhoneOptInAsync(
            string email,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactIdResponse>(
                "api/contact/phoneoptin", content, cancellationToken);
            return result;
        }

        public async Task<ContactIdResponse> ContactPhoneOptOutAsync(
            string email,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email
            };
            var result = await this.SendSalesManagoRequest<ContactIdResponse>(
                "api/contact/phoneoptout", content, cancellationToken);
            return result;
        }

        public async Task<EventIdResponse> AddContactExternalEventAsync(
            ContactEvent contactEvent,
            string email,
            Guid? contactId = null,
            bool forceOptIn = false,
            CancellationToken cancellationToken = default)
        {
            if (email is null && contactId is null)
            {
                throw new ArgumentException("Either email or contactId need to be provided. ");
            }
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                email,
                forceOptIn,
                contactEvent,
                contactId,
            };
            var result = await this.SendSalesManagoRequest<EventIdResponse>(
                "api/contact/addContactExtEvent", content, cancellationToken);
            return result;
        }

        public async Task<BatchAddContactExtEventResponse> BatchAddContactExternalEventAsync(
            ContactExternalEvent[] events,
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                events
            };
            var result = await this.SendSalesManagoRequest<BatchAddContactExtEventResponse>(
                "api/contact/batchAddContactExtEvent", content, cancellationToken);
            return result;
        }

        public async Task<EventIdResponse> UpdateContactExternalEventAsync(
            ContactEvent contactEvent,
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                contactEvent
            };
            var result = await this.SendSalesManagoRequest<EventIdResponse>(
                "api/v2/contact/updateContactExtEvent", content, cancellationToken);
            return result;
        }

        public async Task<ResultResponse> DeleteContactExternalEventAsync(
            Guid eventId,
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                eventId
            };
            var result = await this.SendSalesManagoRequest<ResultResponse>(
                "api/v2/contact/updateContactExtEvent", content, cancellationToken);
            return result;
        }

        public async Task<ResultResponse> ExportTagListAsync(
            bool showSystemTags,
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                showSystemTags
            };
            var result = await this.SendSalesManagoRequest<ResultResponse>(
                "api/v2/contact/tags", content, cancellationToken);
            return result;
        }

        public async Task<ConversationIdResponse> SendEmailAsync(
            Guid emailId,
            Addressee[] contacts,
            Addressee[]? excludeContacts = null,
            string? html = null,
            string? subject = null,
            string? campaign = null,
            CancellationToken cancellationToken = default)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                emailId,
                date = sm.requestTime,
                contacts,
                excludeContacts,
                subject,
                campaign,
                html,
            };
            var result = await this.SendSalesManagoRequest<ConversationIdResponse>(
                "api/email/sendEmail", content, cancellationToken);
            return result;
        }

        // TODO: add file transfer
        public async Task<ConversationIdResponse> SendEmailWithAttachmentAsync(
            Guid emailId,
            string subject,
            string campaign,
            string html,
            Addressee[] contacts,
            Addressee[] excludeContacts,
            bool immediate,
            bool rule,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                emailId,
                date = sm.requestTime,
                contacts,
                excludeContacts,
                subject,
                campaign,
                html,
            };
            var result = await this.SendSalesManagoRequest<ConversationIdResponse>(
                "api/email/sendWithAttachment", content, cancellationToken, "multipart/form-data");
            return result;
        }

        public async Task<EmailIdResponse> AddEmailAsync(
            string subject,
            string campaign,
            Dictionary<string, string> contentBoxMap,
            bool shared,
            bool dynamic,
            Guid EmailAccountId,
            Guid TemplateId,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                date = sm.requestTime,
                subject,
                campaign,
                contentBoxMap,
                shared,
                dynamic,
                EmailAccountId,
                TemplateId,
            };
            var result = await this.SendSalesManagoRequest<EmailIdResponse>(
                "api/email/addEmail", content, cancellationToken);
            return result;
        }

        public async Task<EmailIdResponse> UpsertEmailByNameAsync(
            string subject,
            string campaign,
            bool shared,
            bool dynamic,
            Guid EmailAccountId,
            Guid TemplateId,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                date = sm.requestTime,
                subject,
                campaign,
                shared,
                dynamic,
                EmailAccountId,
                TemplateId,
            };
            var result = await this.SendSalesManagoRequest<EmailIdResponse>(
                "api/email/addEmail", content, cancellationToken);
            return result;
        }

        public async Task<TemplateIdResponse> EmailAddTemplateAsync(
            string emailContent,
            string urlTemplate,
            bool shared,
            bool dynamic,
            bool parametrized,
            bool fromUrl,
            bool titleUrl,
            string customFields,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                user = _settings.Owner,
                date = sm.requestTime,
                emailContent,
                parametrized,
                shared,
                dynamic,
                fromUrl,
                titleUrl,
                urlTemplate,
                customFields
            };
            var result = await this.SendSalesManagoRequest<TemplateIdResponse>(
                "api/email/addTemplate", content, cancellationToken);
            return result;
        }

        public async Task<TemplateIdResponse> EmailUpsertTemplateAsync(
            string emailContent,
            string urlTemplate,
            bool shared,
            bool dynamic,
            bool parametrized,
            bool fromUrl,
            bool titleUrl,
            string customFields,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                date = sm.requestTime,
                emailContent,
                parametrized,
                shared,
                dynamic,
                fromUrl,
                titleUrl,
                urlTemplate,
                customFields
            };
            var result = await this.SendSalesManagoRequest<TemplateIdResponse>(
                "api/email/upsertTemplate", content, cancellationToken);
            return result;
        }

        public async Task<GetMessagesResponse> DownloadEmailMessagesAsync(CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner
            };
            var result = await this.SendSalesManagoRequest<GetMessagesResponse>(
                "api/email/messages", content, cancellationToken);
            return result;
        }

        public async Task<ConversationListResponse> DownloadMassConversationAsync(
            long from,
            long to,
            CancellationToken cancellationToken
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<ConversationListResponse>(
                "api/email/massConversationList", content, cancellationToken);
            return result;
        }

        public async Task<ConversationListResponse> DownloadMassConversationDirectEmailsAsync(
            long from,
            long to,
            CancellationToken cancellationToken
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<ConversationListResponse>(
                "api/email/massDirectConversationList", content, cancellationToken);
            return result;
        }

        public async Task<ConversationListResponse> DownloadConversationStatisticsAsync(
            Guid conversationId,
            string user,
            CancellationToken cancellationToken
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId,
                user
            };
            var result = await this.SendSalesManagoRequest<ConversationListResponse>(
                "api/email/massDirectConversationList", content, cancellationToken);
            return result;
        }

        public async Task<FileUrlResponse> JobStatusAsync(
            int requestId,
            CancellationToken cancellationToken)
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                requestId
            };

            var result = await this.SendSalesManagoRequest<FileUrlResponse>(
                "api/email/massDirectConversationList", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> DownloadMessageStatisticsAsync(
            Guid conversationId,
            string user,
            CancellationToken cancellationToken
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId,
                user
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/email/messageStatistics", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> SendSubscriptionConfirmationAsync(
            Guid conversationId,
            string email,
            string apiDoubleOptInEmailTemplateId,
            string apiDoubleOptInEmailAccountId,
            string apiDoubleOptInEmailSubject,
            string? tag = null,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId,
                email,
                apiDoubleOptInEmailTemplateId,
                apiDoubleOptInEmailAccountId,
                apiDoubleOptInEmailSubject,
                tag
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/email/sendConfirmation", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> SendSubscriptionConfirmationAsync(
            Guid conversationId,
            string email,
            string lang,
            string? tag = null,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId,
                email,
                lang,
                tag
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/email/sendConfirmation", content, cancellationToken);
            return result;
        }

        public async Task<BaseResponse> SendSmsAsync(
            string user,
            string text,
            Recipient[] contacts,
            string? gateway = null,
            string? name = null,
            long? date = null,
            string? tag = null,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                user,
                date,
                text,
                tag,
                gateway,
                name,
                contacts
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/sms/send", content, cancellationToken);
            return result;
        }

        public async Task<SmsConversationStatisticsResponse> StatisticsOfSmsCampaignsByConversationIdAsync(
            Guid conversationId,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId
            };
            var result = await this.SendSalesManagoRequest<SmsConversationStatisticsResponse>(
                "api/sms/conversationStatistics", content, cancellationToken);
            return result;
        }

        public async Task<SmsConversationStatisticsResponse> StatisticsOfSmsCampaignsByNameAsync(
            string name,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                name
            };
            var result = await this.SendSalesManagoRequest<SmsConversationStatisticsResponse>(
                "api/sms/conversationStatisticsByName", content, cancellationToken);
            return result;
        }

        public async Task<SmsConversationStatisticsResponse> DownloadSmsConversationStatisticsAsync(
            Guid conversationId,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                conversationId
            };
            var result = await this.SendSalesManagoRequest<SmsConversationStatisticsResponse>(
                "api/sms/smsConversationStatistics", content, cancellationToken);
            return result;
        }

        public async Task<ConversationListResponse> SmsDownloadMassConversationListAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<ConversationListResponse>(
                "api/sms/massConversationList", content, cancellationToken);
            return result;
        }

        public async Task<TaskIdResponse> ContactUpdateTaskAsync(
            SmsContactTask smContactTaskReq,
            bool? finished = null,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                smContactTaskReq,
                finished
            };
            var result = await this.SendSalesManagoRequest<TaskIdResponse>(
                "api/contact/updateTask", content, cancellationToken);
            return result;
        }

        public async Task<BaseResponse> AddNoteAsync(
            string contactId,
            string email,
            string note,
            bool priv = false,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                contactId,
                email,
                note,
                priv
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/contact/addNote", content, cancellationToken);
            return result;
        }

        public async Task<UsersResponse> ListUserAccountsByClientAsync(
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
            };
            var result = await this.SendSalesManagoRequest<UsersResponse>(
                "api/user/listByClient", content, cancellationToken);
            return result;
        }

        public async Task<AuthoriseResponse> AuthoriseAsync(
            string userName,
            string password,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                userName,
                password
            };
            var result = await this.SendSalesManagoRequest<AuthoriseResponse>(
                "api/system/authorise", content, cancellationToken);
            return result;
        }

        public async Task<WorkflowListResponse> DownloadWorkflowListAsync(
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
            };
            var result = await this.SendSalesManagoRequest<WorkflowListResponse>(
                "api/workflow/list", content, cancellationToken);
            return result;
        }

        public async Task<WebPushStatsResponse> WebPushStatsAsync(
            long wizardId,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                wizardId
            };
            var result = await this.SendSalesManagoRequest<WebPushStatsResponse>(
                "api/web/push/stats", content, cancellationToken);
            return result;
        }

        public async Task<WebPushIdsResponse> WebPushIdsAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<WebPushIdsResponse>(
                "api/web/push/ids", content, cancellationToken);
            return result;
        }

        public async Task<PushConversationIdsResponse> WebPushNotificationIdListAsync(
            long from,
            long to,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                from,
                to
            };
            var result = await this.SendSalesManagoRequest<PushConversationIdsResponse>(
                "api/notification/conversation/ids", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> ExportConsentFormsStatisticsAsync(
            int inId,
            string user,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                inId,
                user
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/notification/consent/form/stats", content, cancellationToken);
            return result;
        }

        public async Task<RequestIdResponse> ExportWebPushNotificationsAsync(
            int inId,
            string user,
            string webPushSourceType,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                inId,
                user,
                webPushSourceType
            };
            var result = await this.SendSalesManagoRequest<RequestIdResponse>(
                "api/notification/push/stats", content, cancellationToken);
            return result;
        }

        public async Task<ConsentFormListResponse> ConsentFormDataAsync(
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
            };
            var result = await this.SendSalesManagoRequest<ConsentFormListResponse>(
                "api/consent/form/data", content, cancellationToken);
            return result;
        }

        public async Task<PointsResponse> AddContactToLoyaltyProgramAsync(
            AddresseeBase[] contacts,
            string loyaltyProgram,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                contacts,
                loyaltyProgram
            };
            var result = await this.SendSalesManagoRequest<PointsResponse>(
                "api/loyalty/program/v1/addContact", content, cancellationToken);
            return result;
        }

        public async Task<BaseResponse> ModifyPointsInLoyaltyProgramAsync(
            AddresseeBase[] contacts,
            string loyaltyProgram,
            int points,
            ModificationType modificationType,
            string? comment = null,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                contacts,
                loyaltyProgram
            };
            var result = await this.SendSalesManagoRequest<BaseResponse>(
                "api/loyalty/program/v1/modifyPoints", content, cancellationToken);
            return result;
        }

        public async Task<ProductIdsResponse> LastViewedProducstsAsync(
            string shopName,
            Guid contactUuid,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                shopName,
                contactUuid
            };
            var result = await this.SendSalesManagoRequest<ProductIdsResponse>(
                "api/recommendation/lastViewed", content, cancellationToken);
            return result;
        }

        public async Task<ProductIdsResponse> MostPurchasedProducstsAsync(
            string shopName,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                shopName,
            };
            var result = await this.SendSalesManagoRequest<ProductIdsResponse>(
                "api/recommendation/mostPurchased", content, cancellationToken);
            return result;
        }

        public async Task<ProductIdsResponse> ProductsPurchasedByContactAsync(
            string shopName,
            Guid smClient,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                shopName,
                smClient
            };
            var result = await this.SendSalesManagoRequest<ProductIdsResponse>(
                "api/recommendation/purchasedByContact", content, cancellationToken);
            return result;
        }

        public async Task<ProductIdsResponse> PurchasedTogetherAsync(
            string shopName,
            int productId,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                shopName,
                productId
            };
            var result = await this.SendSalesManagoRequest<ProductIdsResponse>(
                "api/recommendation/purchasedTogether", content, cancellationToken);
            return result;
        }

        public async Task<VisionResponse> VisionAsync(
            string urlImg,
            int vendorDataSourceIntId,
            CancellationToken cancellationToken = default
            )
        {
            var sm = GetSalesManagoBase();

            var content = new
            {
                clientId = _settings.ClientId,
                sm.apiKey,
                sm.requestTime,
                sm.sha,
                owner = _settings.Owner,
                urlImg,
                vendorDataSourceIntId
            };
            var result = await this.SendSalesManagoRequest<VisionResponse>(
                "api/vision", content, cancellationToken);
            return result;
        }
    }
}