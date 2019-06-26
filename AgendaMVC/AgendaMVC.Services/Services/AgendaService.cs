using AgendaMVC.Models.ServiceModel;
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
        //Delete
        public bool Delete(int idContacto)
        {
            bool deleted = false;
            try
            {
                HttpWebResponse httpWebResponse = base.ExecuteMethod("DELETE", ConfigurationManager.AppSettings["DeleteUrlWebApi"], idContacto.ToString());
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    return !deleted;
                }
                return deleted;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(ContactoServiceModel contactoServiceModel)
        {
            bool added = false;
            try
            {
                HttpWebResponse httpWebResponse = base.ExecuteMethod("POST", ConfigurationManager.AppSettings["CreateUrlWebApi"], SerializeObjectToJson(contactoServiceModel));
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    return !added;
                }
                return added;
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

        private string SerializeObjectToJson(ContactoServiceModel contactoServiceModel)
        {
            return JsonConvert.SerializeObject(contactoServiceModel, Formatting.None);
        }
        #endregion
    }
}
