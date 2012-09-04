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

            var consumerKey = "put your consumer key here";
            var consumerSecret = "put your consumer secret here";
            var oauthToken = "put your oauth token here";
            var oauthSecret = "put your oauth secret here";

            var client = new OpenPhotoClient("http://yourdomain.com", consumerKey, consumerSecret, oauthToken, oauthSecret);
            var requestToken = client.HelloApiTest();
        }
    }
}
