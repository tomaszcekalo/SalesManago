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

        /// <summary>
        /// https://docs.salesmanago.pl/#pobieranie-stworzonych-wiadomo-ci
        /// </summary>
        /// <returns></returns>
        public async Task<GetMessagesResponse> GetEmailMessagesAsync(CancellationToken cancellationToken)
        {
            var apiKey = Guid.NewGuid().ToString().ToLower();
            var sha = GetSHA(apiKey);
            var requestTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "api/email/messages");
            var content = new
            {
                clientId = _settings.ClientId,
                apiKey,
                requestTime,
                sha,
                owner = _settings.Owner
            };
            var serialized = JsonConvert.SerializeObject(content, Formatting.Indented);
            request.Content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");//CONTENT-TYPE header

            var response = await _client.SendAsync(request, cancellationToken);
            using (HttpContent responseContent = response.Content)
            {
                var json = await responseContent.ReadAsStringAsync(cancellationToken);
                var result = JsonConvert.DeserializeObject<GetMessagesResponse>(json);
                return result;
            }
        }

        /// <summary>
        /// https://docs.salesmanago.pl/#wysy-anie-wiadomo-ci-email-zalecana
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="contacts"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SendEmailResponse> SendEmailAsync(
            Guid emailId,
            SendEmailContact[] contacts,
            CancellationToken cancellationToken)
        {
            var apiKey = Guid.NewGuid().ToString().ToLower();
            var sha = GetSHA(apiKey);
            var requestTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "api/email/sendEmail");
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                apiKey,
                requestTime,
                sha,
                user = _settings.Owner,
                emailId,
                date = requestTime,
                contacts
            };
            var serialized = JsonConvert.SerializeObject(content, Formatting.Indented);
            request.Content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");//CONTENT-TYPE header

            var response = await _client.SendAsync(request, cancellationToken);
            using (HttpContent responseContent = response.Content)
            {
                var json = await responseContent.ReadAsStringAsync(cancellationToken);
                var result = JsonConvert.DeserializeObject<SendEmailResponse>(json);
                return result;
            }
        }

        public async Task<HasContactResponse> HasContactAsync(string email, CancellationToken cancellationToken)
        {
            var apiKey = Guid.NewGuid().ToString().ToLower();
            var sha = GetSHA(apiKey);
            var requestTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            HttpRequestMessage request = new HttpRequestMessage(
                HttpMethod.Post,
                "api/contact/hasContact");
            var content = new
            {
                owner = _settings.Owner,
                clientId = _settings.ClientId,
                apiKey,
                requestTime,
                sha,
                user = _settings.Owner,
                email
            };
            var serialized = JsonConvert.SerializeObject(content, Formatting.Indented);
            request.Content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json");//CONTENT-TYPE header

            var response = await _client.SendAsync(request, cancellationToken);
            using (HttpContent responseContent = response.Content)
            {
                var json = await responseContent.ReadAsStringAsync(cancellationToken);
                var result = JsonConvert.DeserializeObject<HasContactResponse>(json);
                return result;
            }
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
    }
}