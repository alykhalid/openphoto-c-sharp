using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPhoto;

namespace ConsoleSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // to test this API client, you need to specify values for the following properties for your particular
            // OpenPhoto instance. You can view them by going to /manage/apps in the browser

            var testApiKey = "put your consumer key here";
            var testApiSecret = "put your consumer secret here";
            var oauthToken = "put your oauth token here";
            var oauthSecret = "put your oauth secret here";

            var client = new OpenPhotoClient("http://yourdomain.com", testApiKey, testApiSecret, oauthToken, oauthSecret);
            var photoList = client.Photos.GetList();
            var singlePhoto = client.Photos.Get("id-of-photo");
        }
    }
}
