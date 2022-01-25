
namespace BasicWebServer.Server.Controllers
{
    using HTTP;
    using Routing;


    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable, string path, Func<TController, Response> controllerFunction)
            where TController : Controller
        {
            return routingTable.MapGet(path, request => controllerFunction(
                                        CreateController<TController>(request)));
        }

        public static IRoutingTable MapPost<TController>(
           this IRoutingTable routingTable, string path, Func<TController, Response> controllerFunction)
           where TController : Controller
        {
            return routingTable.MapPost(path, request => controllerFunction(
                                        CreateController<TController>(request)));
        }


        private static TController CreateController<TController>(Request request)
        {
            return (TController)Activator.CreateInstance(typeof(TController), new[] { request });
        }

    }
}
