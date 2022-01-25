
namespace BasicWebServer.Demo.Controllers
{

    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    //using System;

    public class HomeController : Controller
    {

        private const string HtmlForm =
           @"<form action='/HTML' method='POST'>
                Name: <input type='text' name='Name'/>
                Age: <input type='number' name ='Age'/>
                <input type='submit' value ='Save' />
            </form>";

        private const string DownloadForm =
           @"<form action='/Content' method='POST'>
                <input type='submit' value ='Download Sites Content' /> 
            </form>";


        private const string FileName = "content.txt";


        public HomeController(Request request)
            : base(request)
        {
        }




        public Response Index()
            => Text("Hello from the server!");


        public Response Redirect()
            => Redirect("https://softuni.org");


        public Response Html()
            => Html(HomeController.HtmlForm);


        public Response HtmlFormPost()
        {
            string formData = string.Empty;

            foreach (var (key, value) in this.Request.Form)
            {
                formData += $"{key} - {value}";
                formData += Environment.NewLine;
            }

            return Text(formData);
        }


        public Response Content()
            => Html(HomeController.DownloadForm);



        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(HomeController.FileName,
                new string[] { "https://judge.softuni.org/", "https://softuni.org/" })
               .Wait();


            return File(HomeController.FileName);
        }




        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(
                Environment.NewLine + new String('-', 100), responses);

            await System.IO.File.WriteAllTextAsync(fileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);
                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

    }
}
