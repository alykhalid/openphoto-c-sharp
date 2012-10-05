using System;
using System.Drawing;
using System.IO;
using System.Linq;
using OpenPhoto;

namespace ConsoleSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // to test this API client, you need to specify values for the following properties for your particular
            // OpenPhoto instance. You can view them by going to /manage/apps in the browser

            var testApiKey = "your_api_key";
            var testApiSecret = "your_api_secret";
            var oauthToken = "your_oauth_token";
            var oauthSecret = "your_oauth_secret";

            var client = new OpenPhotoClient("http://yourdomain.com", testApiKey, testApiSecret, oauthToken, oauthSecret);

            var photoList = client.Photos.GetList();
            foreach (var photo in photoList.Result)
            {
                Console.WriteLine("Photo ID: " + photo.Id + "\tPath: " + photo.PathBase);
            }

            var singlePhoto = client.Photos.Get(photoList.Result.First().Id);
            Console.WriteLine();
            Console.WriteLine("The first photo from the list is: " + singlePhoto.Result.Id);

            var deleteResult = client.Photos.Delete(singlePhoto.Result.Id);
            Console.WriteLine();
            Console.WriteLine("Tried to delete first photo. Result: " + deleteResult.Result);

            var secondPhoto = photoList.Result.Skip(1).Take(1).First();
            var updateSecondPhoto = client.Photos.Update(secondPhoto.Id, new OpenPhoto.Model.Photo()
            {
                Title = "Updated title"
            });

            Image imageContent = Image.FromFile("C:\\local\\path\\to\\your\\photo.jpg");
            MemoryStream stream = new MemoryStream();
            imageContent.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            var uploadResult = client.Photos.Upload(stream.ToArray(), "photo.jpg");
            
            Console.ReadLine();
        }
    }
}
