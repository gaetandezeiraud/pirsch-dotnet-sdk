using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pirsch.DotNet.SDK
{
    public class Client
    {
        // Static
        static readonly string defaultBaseURL = "https://api.pirsch.io";
        static readonly int defaultTimeout = 5000;
        static readonly string authenticationEndpoint = "/api/v1/token";
        static readonly string hitEndpoint = "/api/v1/hit";

        // Variables
        private readonly string clientID;
        private readonly string clientSecret;
        private readonly HttpClient client;
        private string accessToken;

        // Constructor
        public Client(ClientConfig config)
        {
            if (string.IsNullOrEmpty(config.BaseURL))
            {
                config.BaseURL = defaultBaseURL;
            }

            if (config.Timeout == null)
            {
                config.Timeout = defaultTimeout;
            }

            clientID = config.ClientID;
            clientSecret = config.ClientSecret;

            client = new HttpClient
            {
                BaseAddress = new Uri(config.BaseURL)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMilliseconds(defaultTimeout);
        }

        // Methods
        public async Task Hit(Hit hit, bool retry = true)
        {
            HttpResponseMessage response = await client.PostAsync(hitEndpoint, hit, new JsonMediaTypeFormatter());
            if (response.StatusCode == HttpStatusCode.Unauthorized
                && retry == true)
            {
                await RefreshToken();
                await Hit(hit, false); // One more try
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(response.ReasonPhrase);
            }
        }

        public async Task RefreshToken()
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(authenticationEndpoint, new AuthenticationEndpoint(this.clientID, this.clientSecret));
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(response.ReasonPhrase);
            }

            AuthenticationResponse authenticationResponse = await response.Content.ReadAsAsync<AuthenticationResponse>();
            accessToken = authenticationResponse.Access_token;
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", accessToken));
        }
    }
}
