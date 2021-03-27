namespace Pirsch.DotNet.SDK
{
    /**
     * ClientConfig contains the configuration parameters for the Client.
     */
    public struct ClientConfig
    {
        public ClientConfig(string baseUrl, int timeout, string clientID, string clientSecret)
        {
            BaseURL = baseUrl;
            Timeout = timeout;
            ClientID = clientID;
            ClientSecret = clientSecret;
        }

        public ClientConfig(string baseUrl, string clientID, string clientSecret)
        {
            BaseURL = baseUrl;
            Timeout = null;
            ClientID = clientID;
            ClientSecret = clientSecret;
        }

        public ClientConfig(int timeout, string clientID, string clientSecret)
        {
            BaseURL = string.Empty;
            Timeout = timeout;
            ClientID = clientID;
            ClientSecret = clientSecret;
        }

        public ClientConfig(string clientID, string clientSecret)
        {
            BaseURL = string.Empty;
            Timeout = null;
            ClientID = clientID;
            ClientSecret = clientSecret;
        }

        public string BaseURL { get; set; }
        public int? Timeout { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }

    /**
     * AuthenticationEndpoint is the authentication request for the API
     */
    public struct AuthenticationEndpoint
    {
        public AuthenticationEndpoint(string client_id, string client_secret)
        {
            Client_id = client_id;
            Client_secret = client_secret;
        }

        public string Client_id { get; set; }
        public string Client_secret { get; set; }
    }

    /**
     * AuthenticationResponse is the authentication response for the API and returns the access token.
     */
    public struct AuthenticationResponse
    {
        public string Access_token { get; set; }
    }

    /**
     * Hit contains all required fields to send a hit to Pirsch. The URL, IP, and User-Agent are mandatory,
     * all other fields can be left empty, but it's highly recommended to send all fields to generate reliable data.
     * The fields can be set from the request headers.
     */
    public struct Hit
    {
        public string Url { get; set; }
        public string Ip { get; set; }
        public string Cf_connecting_ip { get; set; }
        public string X_forwarded_for { get; set; }
        public string Forwarded { get; set; }
        public string X_real_ip { get; set; }
        public string User_agent { get; set; }
        public string Accept_language { get; set; }
        public string Referrer { get; set; }
    }
}
