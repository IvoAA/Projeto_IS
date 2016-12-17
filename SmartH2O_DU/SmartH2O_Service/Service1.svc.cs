using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace SmartH2O_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /*IMPORTANTE*************
        alguem que se dê ao trabalho de ver como se faz o caminho relativo a partir do diretorio solution
        mas se nao vos apetecer façam o caminho absoluto como eu depois de o adaptarem.*/
        string FILEPATH =  @"C:\Users\ASUS\Documents\Projeto_IS\SmartH2O_DU\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml";
        //devolve string agora para testar
        public string GetSumInformationAtDay(string day)
        {
            //SensorData s = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            //usem o select nodes depois
            XmlNode node = (doc.SelectSingleNode("/sensors/sensor[contains(date,'" + day + " 17:58:13')]"));
           



            return node != null ? node.InnerXml : "Not found" ;

        }
    }
}
