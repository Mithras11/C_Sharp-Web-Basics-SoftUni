
namespace BasicWebServer.Server.Common
{
    public class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{name} cannot be null.");
            }
        }
    }
}
