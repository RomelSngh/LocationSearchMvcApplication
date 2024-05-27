using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace LocationSearchApplicationAPI.Helper
{
    public static class ImageHelper
    {
        private static bool DownloadRemoteImageFile(string uri, string fileName)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return false;
            }

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download it
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
                return true;
            }
            
            return false;
        }

        public static Byte [] GetImageFromUrl(string url)
        {
            var buffer = 4096;// = 1024;
            Image image = null;
            Byte[] bytes;
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return null;
            using (var ms = new MemoryStream())
            {
                var req = WebRequest.Create(url);
                using (var resp = req.GetResponse())
                {
                    using (var stream = resp.GetResponseStream())
                    {
                        bytes = new byte[buffer];
                        var n = 0;
                        while ((n = stream.Read(bytes, 0, buffer)) != 0)
                            ms.Write(bytes, 0, n);
                    }
                }
                //image = Bitmap.FromStream(ms) as Bitmap;
                //image = Image.FromStream(ms);
            }
            
            return bytes;
        }

        public static Byte[] GetWebImageFromDownloadUrl(string url)
        {
            if (String.IsNullOrEmpty(url))
                return null;
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(url);
            return imageBytes;
        }

        public static string GetFlickrUrl(Models.Flickr.PhotoDetails.Photo photoDetail)
        {
            //https://farm{farm-id}.staticflickr.com/{server-id}/{id}_{secret}.jpg
            string url = "https://farm{0}.staticflickr.com/{1}/{2}_{3}_m.jpg";
            if (photoDetail != null)
            {
                url = String.Format(url, photoDetail.Farm.ToString(), photoDetail.Server, photoDetail.Id, photoDetail.Secret);
                return url;
            }
            return "";
        }

    }
}