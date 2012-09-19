using System;
using System.Collections.Generic;
using System.Linq;
using OpenPhoto.Model;
using RestSharp;

namespace OpenPhoto.Endpoints
{
    public class PhotoEndpoint
    {
        public PhotoEndpoint(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public ResponseEnvelope<Photo> Get(string id)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/" + id + "/view.json", Method.GET);
            var response = this.restClient.Execute<ResponseEnvelope<Photo>>(request);

            return response.Data;
        }

        public ResponseEnvelope<List<Photo>> GetList()
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlPlural + "/list.json", Method.GET);
            var response = this.restClient.Execute<ResponseEnvelope<List<Photo>>>(request);

            return response.Data;
        }

        public ResponseEnvelope<PhotoNextPreviousCollection> NextPrevious(string id)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/" + id + "/nextprevious.json", Method.GET);
            var response = this.restClient.Execute<ResponseEnvelope<PhotoNextPreviousCollection>>(request);

            return response.Data;
        }

        public ResponseEnvelope<Photo> Delete(string id)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/" + id + "/delete.json", Method.POST);
            var response = this.restClient.Execute<ResponseEnvelope<Photo>>(request);

            return response.Data;
        }

        public const string EndpointUrlPlural = "/photos";
        public const string EndpointUrlSingular = "/photo";

        private RestClient restClient;
    }
}
