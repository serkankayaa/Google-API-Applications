using GoogleGeocoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //verilen parametrelere göre geocode ve directions api kullanımı
            Uri uriGeocode = Geocode.GetCoordinates("1600 Amphitheatre Parkway Mountain View, CA 94043");
            Uri uriDirections = Directions.GetCoordinates("Chicago, IL", "Los Angeles, CA");

            //Geocoding api
            using (WebClient webclient = new System.Net.WebClient())
            {
                //JSON verisinin string  e dönüşümü
                WebClient n = new WebClient();
                var json = n.DownloadString(uriGeocode);
                string valueOriginal = Convert.ToString(json);
                //parsing JSON
                JObject result = JObject.Parse(json);
                string locationLatitude = (string)result["results"][0]["geometry"]["location"]["lat"].ToString();
                string locationLongtidute = (string)result["results"][0]["geometry"]["location"]["lng"].ToString();
                Console.WriteLine(locationLatitude);
                Console.WriteLine(locationLongtidute);
            }

            //Directions api
            using (WebClient webclient = new System.Net.WebClient())
            {
                //jSON Verisinin string e dönüşümü
                WebClient n = new WebClient();
                var json = n.DownloadString(uriDirections);
                string valueOriginal = Convert.ToString(json);
                Console.WriteLine(json);
            }
            Console.ReadKey();
        }
    }
}
