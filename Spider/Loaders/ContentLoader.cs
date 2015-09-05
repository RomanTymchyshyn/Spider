using System.Net;

namespace Spider.Loaders
{
    class ContentLoader: IContentLoader
    {
        public string LoadContent(string url)
        {
            string htmlContent;
            using (WebClient client = new WebClient())
            {
                htmlContent = client.DownloadString(url);
            }
            return htmlContent;
        }
    }
}
