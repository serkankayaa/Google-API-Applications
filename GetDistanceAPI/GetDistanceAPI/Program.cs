using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetDistanceAPI
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Uri uriGeocode = Geocode.GetCoordinates("40.759617, -73.961975", "40.803364, -73.955");
            Geocode geo = new Geocode();
            using (WebClient webclient = new System.Net.WebClient())
            {
                float distanceValue = 0;
                WebClient n = new WebClient();
                var json = n.DownloadString(uriGeocode);
                string valueOriginal = Convert.ToString(json);
                JObject result = JObject.Parse(json);
                string distance = (string)result["rows"][0]["elements"][0]["distance"]["text"].ToString();
                distanceValue = geo.ClearDistance(distance);
                Console.WriteLine(distanceValue);
            }
            Console.ReadKey();

        }
        
    }
}
