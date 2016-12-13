using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartH2O_Teste
{
    class Alarm_Program
    {

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String data = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine("Received = " + data + " on topic " + e.Topic);

            /*
            if(!Validate(data))
                sendAlarm(data);
            */
        }

        static void ReceiveData()
        {
            MqttClient m_cClient = new MqttClient(SmartH2O_Teste.Properties.Settings.Default.BrokerIP);
            string[] topics = new string[Properties.Settings.Default.Topics.Count]; 

            int i = 0;
            foreach (String topic in Properties.Settings.Default.Topics)
            {
                topics[i++] = topic;
            }

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};//QoS

            m_cClient.Connect(Guid.NewGuid().ToString());
            if (!m_cClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return ;
            }
            //Specify events we are interest on
            //New Msg Arrived
            m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //Subscribe to topics
            m_cClient.Subscribe(topics, qosLevels);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            ReceiveData();
        }


        static private bool isValid;
        static public string ValidationMessage { get; set; }

        static void Validate(string data)
        {
            isValid = true;
            String XSDFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"alarm.xsd";

            ValidationMessage = "Document Valid!";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(data);
                ValidationEventHandler eventH = new ValidationEventHandler(MyEvent);
                doc.Schemas.Add(null, XSDFilePath);
                doc.Validate(eventH);
            }
            catch (XmlException ex)
            {
                isValid = false;
                ValidationMessage = string.Format("Error{0}", ex.ToString());
            }

        }

        static void MyEvent(object sender, ValidationEventArgs args)
        {
            isValid = false;
            ValidationMessage = string.Format("Document not valid! {0}", args.Message);
        }

        private static void SendAlarm(XmlElement sensor)
        {
            MqttClient m_cClient = new MqttClient(SmartH2O_Teste.Properties.Settings.Default.BrokerIP);
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
