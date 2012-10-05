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

        public ResponseEnvelope<bool> Delete(string id)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/" + id + "/delete.json", Method.POST);
            var response = this.restClient.Execute<ResponseEnvelope<bool>>(request);

            return response.Data;
        }

        public ResponseEnvelope<Photo> Update(string id, Photo newPhoto)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/" + id + "/update.json", Method.POST);

            request.Parameters.Add(new Parameter() { Name = "permission", Value = newPhoto.Permission, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "title", Value = newPhoto.Title, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "description", Value = newPhoto.Description, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "dateUploaded", Value = newPhoto.DateUploaded, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "dateTaken", Value = newPhoto.DateTaken, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "license", Value = newPhoto.License, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "latitude", Value = newPhoto.Latitude, Type = ParameterType.GetOrPost });
            request.Parameters.Add(new Parameter() { Name = "longitude", Value = newPhoto.Longitude, Type = ParameterType.GetOrPost });

            var response = this.restClient.Execute<ResponseEnvelope<Photo>>(request);

            return response.Data;
        }

        public ResponseEnvelope<Photo> Upload(byte[] photoData, string fileName)
        {
            var request = new RestRequest(PhotoEndpoint.EndpointUrlSingular + "/upload.json", Method.POST);

            var fileToUpload = FileParameter.Create("photo", photoData, fileName);
            request.Files.Add(fileToUpload);

            var response = this.restClient.Execute<ResponseEnvelope<Photo>>(request);
            return response.Data;
        }

        public const string EndpointUrlPlural = "/photos";
        public const string EndpointUrlSingular = "/photo";

        private RestClient restClient;
    }
}
