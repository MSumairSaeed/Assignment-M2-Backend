using System;
using System.Net.Http.Headers;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace crud_assignment_m2.services
{
	public class OktaTokenService : IOktaToken
    {

              private OktaToken token = new OktaToken();
        private readonly IOptions<OktaSettings> oktaSettings;

        public OktaTokenService(IOptions<OktaSettings> oktaSettings)
        {
            this.oktaSettings = oktaSettings;
        }

        public async Task<string> GetToken()
        {
            if (!this.token.IsValidAndNotExpiring)
            {
                this.token = await this.GetNewAccessToken();
            }
            return token.AccessToken;
        }
        private async Task<OktaToken> GetNewAccessToken()
        {
            var token = new OktaToken();
            var client = new HttpClient();
            var client_id = "0oa9qfhshpTaCBr4b5d7";
            var client_secret = "40ROgL1U7q2EFlcR8IikQolftPT0D7YF8ovjq1vj";
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));

            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "access_token");
            var request = new HttpRequestMessage(HttpMethod.Post, "https://dev-38914505.okta.com/oauth2/default/v1/token")
            {
                Content = new FormUrlEncodedContent(postMessage)
            };

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                this.token = JsonConvert.DeserializeObject<OktaToken>(json);
                this.token.ExpiresAt = DateTime.UtcNow.AddSeconds(this.token.ExpiresIn);
            }
            else
            {
                throw new ApplicationException("Unable to retrieve access token from Okta");
            }
            return this.token;
        }
	}
}

