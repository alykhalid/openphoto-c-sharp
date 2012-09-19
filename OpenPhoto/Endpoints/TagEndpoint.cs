using System.Collections.Generic;
using OpenPhoto.Model;
using RestSharp;

namespace OpenPhoto.Endpoints
{
    public class TagEndpoint
    {
        public TagEndpoint(RestClient client)
        {
            this.restClient = client;
        }

        public ResponseEnvelope<List<Tag>> GetList()
        {
            var request = new RestRequest(TagEndpoint.EndpointUrlPlural + "/list.json", Method.GET);
            var response = this.restClient.Execute<ResponseEnvelope<List<Tag>>>(request);

            return response.Data;
        }
        public ResponseEnvelope<Tag> Create(string name, int count = 0, string email = "", double latitude = 0, double longitude = 0)
        {
            var request = new RestRequest(TagEndpoint.EndpointUrlSingular + "/" + name + "/create.json", Method.POST);

            if (!string.IsNullOrEmpty(email))
                request.Parameters.Add(new Parameter() { Name = "email", Value = email });
            if (count != 0)
                request.Parameters.Add(new Parameter() { Name = "count", Value = count });
            if (latitude != 0)
                request.Parameters.Add(new Parameter() { Name = "latitude", Value = latitude });
            if (longitude != 0)
                request.Parameters.Add(new Parameter() { Name = "longitude", Value = longitude });
            
            var response = this.restClient.Execute<ResponseEnvelope<Tag>>(request);
            return response.Data;
        }

        private RestClient restClient;
        public const string EndpointUrlSingular = "/tag";
        public const string EndpointUrlPlural = "/tags";
    }
}
