using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace PlaceHolderProject.Repositories.JsonHelpers
{
    internal static class  Serializer
    {
        internal static StringContent GetStringContentFor<T>(this T instance)
        where T : class
        {
            var userJson = JsonConvert.SerializeObject(instance);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
