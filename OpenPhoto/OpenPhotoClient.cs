using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using RestSharp.Contrib;

namespace OpenPhoto
{
    public class OpenPhotoClient
    {
        public OpenPhotoClient(string apiBaseUrl, string apiKey, string apiSecret, string oauthToken, string oauthSecret)
        {
            this.apiBaseUrl = apiBaseUrl;
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            this.oauthToken = oauthToken;
            this.oauthSecret = oauthSecret;
        }

        public string HelloApiTest()
        {
            var request = new RestRequest("/hello.json", Method.GET);
            var response = this.RestClient.Execute(request);

            return response.Content;
        }

        private RestClient RestClient
        {
            get
            {
                if (this.restClient == null)
                {
                    this.restClient = new RestClient(this.apiBaseUrl);
                    // setup OAuth
                    var oauthAuthenticator = OAuth1Authenticator
                        .ForProtectedResource(this.apiKey, this.apiSecret, this.oauthToken, this.oauthSecret);
                    oauthAuthenticator.ParameterHandling = OAuthParameterHandling.UrlOrPostParameters;
                    this.restClient.Authenticator = oauthAuthenticator;
                }
                return this.restClient;
            }
        }

        private RestClient restClient;

        private string apiKey;
        private string apiSecret;
        private string apiBaseUrl;
        private string oauthToken;
        private string oauthSecret;
    }
}
