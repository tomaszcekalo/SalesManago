using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace SalesManago
{
    public class SalesManagoService : ISalesManagoService
    {
        private SalesManagoSettings _settings;
        private HttpClient _client;

        public SalesManagoService(SalesManagoSettings settings, HttpClient httpClient)
        {
            _settings = settings;
            _client = httpClient;
            _client.BaseAddress = new Uri(settings.Endpoint);
            _client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<GetMessagesResponse> GetEmailMessagesAsync(CancellationToken cancellationToken)
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

        public async Task<SendEmailResponse> SendEmailAsync(
            Guid emailId,
            SendEmailContact[] contacts,
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
                contacts
            };
            var result = await this.SendSalesManagoRequest<SendEmailResponse>(
                "api/email/sendEmail", content, cancellationToken);
            return result;
        }

        public async Task<HasContactResponse> HasContactAsync(string email, CancellationToken cancellationToken)
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
            var result = await this.SendSalesManagoRequest<HasContactResponse>(
                "api/contact/hasContact", content, cancellationToken);
            return result;
        }

        public (string apiKey, string sha, long requestTime) GetSalesManagoBase()
        {
            var apiKey = Guid.NewGuid().ToString().ToLower();
            var sha = GetSHA(apiKey);
            var requestTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return (apiKey, sha, requestTime);
        }

        public async Task<T> SendSalesManagoRequest<T>(string url, object? content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                url);
            var serialized = JsonConvert.SerializeObject(content, Formatting.Indented);
            request.Content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");//CONTENT-TYPE header

            var response = await _client.SendAsync(request, cancellationToken);
            using (HttpContent responseContent = response.Content)
            {
                var json = await responseContent.ReadAsStringAsync(cancellationToken);
                var result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<ContactBasicExportResponse> ContactBasicByEmailAsync(string email, CancellationToken cancellationToken)
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
                email = new string[] { email }
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

        public async Task<ContactBasicExportResponse> ContactBasicByIdAsync(string id, CancellationToken cancellationToken)
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
                id = new string[] { id }
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/basicById", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListByEmailAsync(string email, CancellationToken cancellationToken)
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
                email = new string[] { email }
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/list", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListByIdAsync(string contactId, CancellationToken cancellationToken)
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
                icontactId = new string[] { contactId }
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/basicById", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListAllByEmailAsync(string email, CancellationToken cancellationToken)
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
                email = new string[] { email }
            };
            var result = await this.SendSalesManagoRequest<ContactBasicExportResponse>(
                "api/contact/listAll", content, cancellationToken);
            return result;
        }

        public async Task<ContactBasicExportResponse> ContactListAllByIdAsync(string contactId, CancellationToken cancellationToken)
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
                contactId = new string[] { contactId }
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

        public async Task<PaginatedContactsListExportResponse> PaginatedContactListExportAsync(
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
            var result = await this.SendSalesManagoRequest<PaginatedContactsListExportResponse>(
                "api/contact/paginatedContactList/export", content, cancellationToken);
            return result;
        }
    }
}