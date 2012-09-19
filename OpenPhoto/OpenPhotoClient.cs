using System;
using System.Linq;
using OpenPhoto.Endpoints;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;

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

        public PhotoEndpoint Photos 
        {
            get
            {
                if (this.photoEndpoint == null)
                    this.photoEndpoint = new PhotoEndpoint(this.RestClient);
                return this.photoEndpoint;
            }
        }

        public TagEndpoint Tags
        {
            get
            {
                if (this.tagEndpoint == null)
                    this.tagEndpoint = new TagEndpoint(this.RestClient);
                return this.tagEndpoint;
            }
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
        private PhotoEndpoint photoEndpoint;
        private TagEndpoint tagEndpoint;

        private string apiKey;
        private string apiSecret;
        private string apiBaseUrl;
        private string oauthToken;
        private string oauthSecret;
    }
}
