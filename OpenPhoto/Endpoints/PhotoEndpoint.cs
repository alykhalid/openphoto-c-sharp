using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //public Photo Get(string id)
        //{
            
        //}

        public ResponseEnvelope<IList<Photo>> GetList()
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrl + "/list.json", Method.GET);
            var response = this.restClient.Execute<ResponseEnvelope<IList<Photo>>>(request);

            return response.Data;
        }

        public const string EndpointUrl = "/photos";

        private RestClient restClient;
    }
}
