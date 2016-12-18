using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Alarm
{
    public partial class Form : System.Windows.Forms.Form
    {

        public class Trigger
        {
            public string condition { get; set; }
            public double value { get; set; }
            public string errorMessage { get; set; }
        }

        Dictionary<string, List<Trigger>> triggers;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            OnOff.Text = "Turn Alarms OFF";

            //Abrir xml e ver alarmes a detetar
            ReadXmlTriggers();

            //Comecar a receber dados dos sensores
            ReceiveData();
           
        }

        void ReadXmlTriggers()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("trigger-rules.xml");
                XmlNodeList nodes = doc.SelectNodes("/triggers/sensorode");
                foreach (XmlNode node in nodes)
                {

                }

                doc.SelectNodes("/ triggers / sensor[@node = "PH"] / alarm[@active = "true"]")

            }
            catch (Exception)
            {

                throw;
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String data = Encoding.UTF8.GetString(e.Message);
            /*this.Invoke((MethodInvoker)delegate
            {
                textBoxNotifications.Text += "Received = " + data + " on topic " + e.Topic + Environment.NewLine;
            });
            */

        }

        void ReceiveData()
        {
            MqttClient m_cClient = new MqttClient(Properties.Settings.Default.BrokerIP);
            string[] topics = new string[Properties.Settings.Default.Topics.Count];

            int i = 0;
            foreach (String topic in Properties.Settings.Default.Topics)
            {
                topics[i++] = topic;
            }

            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };//QoS

            m_cClient.Connect(Guid.NewGuid().ToString());
            if (!m_cClient.IsConnected)
            {
                //Console.WriteLine("Error connecting to message broker...");
                return;
            }
            //Specify events we are interest on
            //New Msg Arrived
            m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //Subscribe to topics
            m_cClient.Subscribe(topics, qosLevels);
        }
        
    }
}
