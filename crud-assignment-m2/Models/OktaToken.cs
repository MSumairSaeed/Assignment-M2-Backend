using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace crud_assignment_m2.models
{
    public class OktaToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string? AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string? Scope { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string? TokenType { get; set; }

        public bool IsValidAndNotExpiring
        {
            get
            {
                return !String.IsNullOrEmpty(this.AccessToken) &&
          this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
            }
        }
    }

}

