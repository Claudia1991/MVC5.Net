using AgendaMVC.Models.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;

namespace AgendaMVC.Services.Services
{
    public class AgendaService : BaseServiceApi
    {
        //GetAll
        #region Public Methods
        public List<ContactoViewModel> GetList()
        {
            try
            {
                List<ContactoViewModel> contactos = null;
                HttpWebResponse httpWebResponse = base.ExecuteMethod("GET", ConfigurationManager.AppSettings["GetAllUrlWebApi"], "");
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    contactos = DeserializeApiResponse<List<ContactoViewModel>>(httpWebResponse);
                    return contactos;
                }
                return contactos;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Private Methods
        private TOutput DeserializeApiResponse<TOutput>(HttpWebResponse response) where TOutput : new()
        {
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            var result = streamReader.ReadToEnd();
            stream.Close();
            streamReader.Close();
            return JsonConvert.DeserializeObject<TOutput>(result);
        }
        #endregion
    }
}
