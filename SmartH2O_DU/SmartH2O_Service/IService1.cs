using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmartH2O_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<string> GetSumInformationAtDay(string day, string elem);

        [OperationContract]
        Dictionary<DateTime, List<double>> GetSumInformationBetweenDates(DateTime firstDate, DateTime secondDate, string elem);

        [OperationContract]
        Dictionary<int, List<double>> GetSumInformationByWeek(string elem);
        // TODO: Add your service operations here

        [OperationContract]
        List<string> GetRaisedAlarms(List<string> elements);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class SensorData
    {
        [DataMember]
        public int SensorId { get; set; }

        [DataMember]
        public string parameter { get; set; }



        [DataMember]
        public double minVal { get; set; }

        [DataMember]
        public double avgVal { get; set; }

        [DataMember]
        public double maxVal { get; set; }
    }
}
