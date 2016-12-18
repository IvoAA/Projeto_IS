using Lib;
using System;
using System.Text;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;

namespace Data_Uploader
{
    class DU_Program
    {

        static void Main(string[] args)
        {

            SensorNodeDll.SensorNodeDll dll = new SensorNodeDll.SensorNodeDll();
            dll.Initialize(NewValue, Properties.Settings.Default.Delay);
        }

        private static void NewValue(string message)
        {
            
            XmlElement sensor = DataToXml(message);


            Console.WriteLine("Channel: " + sensor.GetAttribute("element"));
            Console.WriteLine("Data = " + sensor.OuterXml);
            SendValue(sensor);
            

        }

        public static XmlElement DataToXml(string message)
        {

            string[] s = message.Split(';');
            string date = DateTime.Now.ToString();

            XmlDocument doc = new XmlDocument();

            XmlElement sensor = doc.CreateElement("sensor");
            sensor.SetAttribute("element", s[1]);

            XmlElement i = doc.CreateElement("id");
            i.InnerText = s[0];
            sensor.AppendChild(i);

            XmlElement v = doc.CreateElement("value");
            v.InnerText = s[2];
            sensor.AppendChild(v);

            XmlElement d = doc.CreateElement("date");
            d.InnerText = date;
            sensor.AppendChild(d);

            return sensor;
        }

        private static void SendValue(XmlElement sensor)
        {
            MqttClient m_cClient = new MqttClient(Properties.Settings.Default.BrokerIP);
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
