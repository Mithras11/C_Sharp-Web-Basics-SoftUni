
namespace BasicWebServer.Server.Responses
{
    using HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string text)
            : base(text, ContentType.Html)
        {
        }
    }
}
     