using System;
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
        public ResponseEnvelope<bool> Create(string name, int count = 0, string email = "", double latitude = 0, double longitude = 0)
        {
            var request = new RestRequest(TagEndpoint.EndpointUrlSingular + "/create.json", Method.POST);

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("You have to supply a tag name");
            request.Parameters.Add(new Parameter() { Name = "tag", Value = name, Type = ParameterType.GetOrPost });

            if (!string.IsNullOrEmpty(email))
                request.Parameters.Add(new Parameter() { Name = "email", Value = email, Type = ParameterType.GetOrPost });
            if (count != 0)
                request.Parameters.Add(new Parameter() { Name = "count", Value = count, Type = ParameterType.GetOrPost });
            if (latitude != 0)
                request.Parameters.Add(new Parameter() { Name = "latitude", Value = latitude, Type = ParameterType.GetOrPost });
            if (longitude != 0)
                request.Parameters.Add(new Parameter() { Name = "longitude", Value = longitude, Type = ParameterType.GetOrPost });
            
            var response = this.restClient.Execute<ResponseEnvelope<bool>>(request);
            return response.Data;
        }

        public ResponseEnvelope<Tag> Update(string tag, int count = 0, string email = "", double latitude = 0, double longitude = 0)
        {
            var request = new RestRequest(TagEndpoint.EndpointUrlSingular + "/" + tag + "/update.json", Method.POST);

            if (!string.IsNullOrEmpty(email))
                request.Parameters.Add(new Parameter() { Name = "email", Value = email, Type = ParameterType.GetOrPost });
            if (count != 0)
                request.Parameters.Add(new Parameter() { Name = "count", Value = count, Type = ParameterType.GetOrPost });
            if (latitude != 0)
                request.Parameters.Add(new Parameter() { Name = "latitude", Value = latitude, Type = ParameterType.GetOrPost });
            if (longitude != 0)
                request.Parameters.Add(new Parameter() { Name = "longitude", Value = longitude, Type = ParameterType.GetOrPost });

            var response = this.restClient.Execute<ResponseEnvelope<Tag>>(request);
            return response.Data;
        }

        private RestClient restClient;
        public const string EndpointUrlSingular = "/tag";
        public const string EndpointUrlPlural = "/tags";
    }
}
