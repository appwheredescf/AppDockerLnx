using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using AppDockerLnx.Models;

namespace AppDockerLnx.Services
{
    public class PersonasServices
    {
        public List<PersonaResp> getPersonas(string urlPersonServ, ReqPerson person)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(urlPersonServ);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string str = JsonConvert.SerializeObject(person);
                    streamWriter.Write(str);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                string str1 = string.Empty;
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    str1 = streamReader.ReadToEnd();
                //string str1 = 
                //    "{'Resultado': {'fila': [{'ICVEPERSONA': 1,'CNOMBRE': 'JONATHAN','CAPPATERNO': 'TORRES','CAPMATERNO': 'CENDEJAS','LACTIVO': 0,'ESTATUS': 1},{'ICVEPERSONA': 2,'CNOMBRE': 'JONATHAN','CAPPATERNO': 'TORRES','CAPMATERNO': 'CENDEJAS','LACTIVO': 1,'ESTATUS': 1},{'ICVEPERSONA': 3,'CNOMBRE': 'JONATHAN','CAPPATERNO': 'TORRES','CAPMATERNO': 'CENDEJAS','LACTIVO': 1,'ESTATUS': 1}]}}";
                List<PersonaResp> resp = new List<PersonaResp>();
                if (str1.Contains("["))
                {
                    resp = JsonConvert.DeserializeObject<RespPerson>(str1).Resultado.fila;
                }
                else
                {
                    resp.Add( JsonConvert.DeserializeObject<RespPersonUnique>(str1).Resultado.fila);
                }
                
                return resp;

                //List<Persona> lsPersonas = new List<Persona>();
                //lsPersonas.Add(new Persona() { ID = '1', name = 'test', apPat = 'test', apMat = 'test' });
                //return lsPersonas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
