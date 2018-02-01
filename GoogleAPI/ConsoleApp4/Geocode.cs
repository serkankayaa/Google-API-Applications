using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleGeocoder
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
    // Lokasyon verilerini web api ile çekmek için kullanýlýr.
    public class Geocode
    {
        private const string _googleUri = "https://maps.googleapis.com/maps/api/geocode/";
        private const string _googleKey = "AIzaSyBqypLrzaFYvf4QB0PtFp4eJFiPfgcK8Rc"; 
        private const string _outputType = "json"; //xml, csv
        public static Uri GetGeocodeUri(string address)
        {
            address = HttpUtility.UrlEncode(address);
            return new Uri(String.Format("{0}{1}?address={2}&key={3}", _googleUri, _outputType , address, _googleKey));
        }
        //
        public static Uri GetCoordinates(string address)
        {
            WebClient client = new WebClient();
            Uri uri = GetGeocodeUri(address);
            return uri;
        }
    }
    //trafik bilgilerini web api yoluyla çekmek için kullanýlýr.
    public class Directions
    {
        private const string _googleUri = "https://maps.googleapis.com/maps/api/directions/";
        private const string _googleKey = "AIzaSyBqypLrzaFYvf4QB0PtFp4eJFiPfgcK8Rc";
        private const string _outputType = "json"; //xml, csv

        public static Uri GetGeocodeUri(string originAddress, string destAdress)
        {
            originAddress = HttpUtility.UrlEncode(originAddress);
            destAdress = HttpUtility.UrlEncode(destAdress);
            return new Uri(String.Format("{0}{1}?origin={2}&destination={3}&key={4}", _googleUri, _outputType, originAddress, destAdress, _googleKey));
        }
        public static Uri GetCoordinates(string originAdress,string destAdress)
        {
            WebClient client = new WebClient();
            Uri uri = GetGeocodeUri(originAdress,destAdress);
            return uri;
        }
    }
}
