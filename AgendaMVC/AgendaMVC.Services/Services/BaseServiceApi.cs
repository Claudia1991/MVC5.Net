using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace AgendaMVC.Services.Services
{
    public abstract class BaseServiceApi
    {
        #region Protected Methods
        protected HttpWebResponse ExecuteMethod(string method, string uri, string request)
        {
            HttpWebResponse httpWebResponse = null;
            //GetAll
            //Lista de contactos
            if (method.ToUpper() == "GET" && string.IsNullOrEmpty(request))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["BaseUrlWebApi"] + uri);
                httpWebRequest.Method = method;
                httpWebRequest.ContinueTimeout = 360000;
                httpWebRequest.KeepAlive = true;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            //GetById
            if (method.ToUpper() == "GET" && !string.IsNullOrEmpty(request))
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["BaseUrlWebApi"] + uri);
                httpWebRequest.Method = method;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            //Create
            //Ojo con el request que tiene que se un json
            if (method.ToUpper() == "POST" && !string.IsNullOrEmpty(request))
            {
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["BaseUrlWebApi"] + uri);
                httpWebRequest.Method = method;
                httpWebRequest.ContentType = "application/json";
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Close();
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            //Edit
            //Ojo con el request que tiene que se un json
            if (method.ToUpper() == "PUT" && !string.IsNullOrEmpty(request))
            {
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["BaseUrlWebApi"] + uri);
                httpWebRequest.Method = method;
                httpWebRequest.ContentType = "application/json";
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Close();
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
            }
            //Delete
            //Ojo con el request que tiene que se un json
            if (method.ToUpper() == "DELETE" && !string.IsNullOrEmpty(request))
            {
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["BaseUrlWebApi"] + uri);
                httpWebRequest.Method = method;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            return httpWebResponse;
        }
        #endregion
    }
}