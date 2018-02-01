using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetDistanceAPI
{
    public interface ISpatialCoordinate
    {
        decimal Latitude {get; set; } 
        decimal Longitude {get; set; } 
    }
    public struct Coordinate : ISpatialCoordinate
    {
        private decimal _latitude; 
        private decimal _longitude;

        public Coordinate(decimal latitude, decimal longitude)
        {
            _latitude = latitude;
            _longitude = longitude; 
        }
        #region ISpatialCoordinate Members
        public decimal  Latitude
        {
	        get 
	        { 
		        return _latitude; 
	        }
	        set 
	        { 
		        this._latitude = value; 
	        }
        }
        public decimal  Longitude
        {
	        get 
	        { 
		        return _longitude; 
	        }
	        set 
	        { 
		        this._longitude = value;
	        }
        }
        #endregion
    }
    public class Geocode
    {
        private const string _googleUri = "https://maps.googleapis.com/maps/api/distancematrix/";
        private const string _googleKey = "AIzaSyBqypLrzaFYvf4QB0PtFp4eJFiPfgcK8Rc"; 
        private const string _outputType = "json"; //xml, csv
        public static Uri GetGeocodeUri(string OriginCoor, string DestCoor)
        {
            OriginCoor = HttpUtility.UrlEncode(OriginCoor);
            DestCoor = HttpUtility.UrlEncode(DestCoor);      
            return new Uri(String.Format("{0}{1}?origins={2}&destinations={3}&key={4}", _googleUri, _outputType , OriginCoor, DestCoor , _googleKey));
        }
        //
        public static Uri GetCoordinates(string OriginCoor, string DestCoor)
        {
            WebClient client = new WebClient();
            Uri uri = GetGeocodeUri(OriginCoor,DestCoor);
            return uri;
        }
        public float ClearDistance(string distance)
        {
            distance = distance.Replace(" km", "");
            float clearDistanceValue = 0;
            if (distance.Contains("."))
            {
                distance = distance.Replace(".", ",");
                clearDistanceValue = Convert.ToSingle(distance);
            }

            return clearDistanceValue;
        }
    }
    
}
