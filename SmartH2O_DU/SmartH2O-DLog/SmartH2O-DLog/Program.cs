using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartH2O_DLog
{
    class Program
    {

        static void Main(string[] args)
        {
            MqttClient m_cClient = new MqttClient("127.0.0.1");
            string[] m_strTopicsInfo = { "PH", "NH3", "CI2", "alarms" }; //canais a subscrever

            m_cClient.Connect(Guid.NewGuid().ToString());
            if (!m_cClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }

            //Specify events we are interest on
            //New Msg Arrived
            m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            //Subscribe to topics
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};//QoS
            m_cClient.Subscribe(m_strTopicsInfo, qosLevels);


            Console.ReadKey();

            if (m_cClient.IsConnected)
            {
                m_cClient.Unsubscribe(m_strTopicsInfo); //Put this in a button to see notif!
                m_cClient.Disconnect(); //Free process and process's resources
            }


        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            Console.WriteLine("Received = " + Encoding.UTF8.GetString(e.Message) +
            " on topic " + e.Topic);
            organizeXML(e);
        }


        private static void organizeXML(MqttMsgPublishEventArgs e)
        {

            String topic = e.Topic;
            String xml = Encoding.UTF8.GetString(e.Message);
            XmlDocument doc = new XmlDocument();

            try
            {

                if (!(e.Topic).Equals("alarms"))
                {


                    if (!File.Exists("param-data.xml"))
                    {

                        doc.AppendChild(doc.CreateElement("sensors"));
                        doc.Save("param-data.xml");

                       

                    }
                    

                        doc.Load("param-data.xml");

                        XmlNode root = doc.DocumentElement;

                        XmlDocumentFragment xmlDocFragment = doc.CreateDocumentFragment();
                        xmlDocFragment.InnerXml = xml;

                        root.AppendChild(xmlDocFragment);

                        doc.Save("param-data.xml");

                } else { 

                        if (!File.Exists("alarms-data.xml"))
                        {
                            
                            doc.AppendChild(doc.CreateElement("alarms"));
                            doc.Save("alarms-data.xml");
                        }
                    

                        /*doc.Load("alarms-data.xml");

                        XmlNode root = doc.DocumentElement;
                        XmlDocument aux = new XmlDocument();
                        aux.InnerXml = xml;
                        XmlNodeList alarms = aux.SelectNodes("/alarm");

                        foreach(XmlNode alarm in alarms)
                        {
                            root.AppendChild(alarm);
                        }

                        doc.Save("alarms-data.xml");
                        */
                   
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }








        }
    }
}