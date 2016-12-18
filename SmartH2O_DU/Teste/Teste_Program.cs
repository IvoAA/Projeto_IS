using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Teste
{
    class Teste_Program
    {

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String data = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine("Received = " + data + " on topic " + e.Topic);

        }

        static void ReceiveData()
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
                Console.WriteLine("Error connecting to message broker...");
                return;
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



    }

}

