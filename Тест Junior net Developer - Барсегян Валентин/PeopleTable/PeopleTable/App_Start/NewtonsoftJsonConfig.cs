using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace PeopleTable
{
    public class NewtonsoftJsonConfig
    {
        public static void JsonSttings()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            settings.Formatting = Formatting.Indented;
        }
    }
}
