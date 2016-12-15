using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;

namespace SmartH2O_DU
{
    class DU_Program
    {

        static void Main(string[] args)
        {

            SensorNodeDll.SensorNodeDll dll = new SensorNodeDll.SensorNodeDll();
            dll.Initialize(NewValue, SmartH2O_DU.Properties.Settings.Default.Delay);
        }

        private static void NewValue(string message)
        {
            HandlerXML handlerXML = new SmartH2O_DU.HandlerXML();

            XmlElement sensor = handlerXML.CreateXMLSensorFile(message);
            
            if (handlerXML.ValidateXML(sensor.OuterXml))
            {
                SendValue(sensor);
            }

        }

        private static void SendValue(XmlElement sensor)
       { 
            MqttClient m_cClient = new MqttClient(SmartH2O_DU.Properties.Settings.Default.BrokerIP);
            string topic = sensor.GetAttribute("element");

            m_cClient.Connect(Guid.NewGuid().ToString());

            if (!m_cClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            m_cClient.Publish(topic, Encoding.UTF8.GetBytes(sensor.OuterXml));
            Console.WriteLine("Sent");
        }
    }
}
