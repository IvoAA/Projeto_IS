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
            public double valueMax { get; set; }
            public string errorMessage { get; set; }
            public DateTime date { get; set; }
        }

        Dictionary<string, List<Trigger>> triggers;
        bool on = false;
        int counter;

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

            // Abrir xml e ver alarmes a detetar
            ReadXmlTriggers();

            // Mostrar Triggers no Form
            FillTreeView();
            counter = 0;

            // Comecar a receber dados dos sensores
            ReceiveData();
           
        }

        private void FillTreeView()
        {
            TreeNode parentnode = new TreeNode();

            this.treeViewTriggers.BeginUpdate();
            foreach (string node in triggers.Keys)
            {

                parentnode = new TreeNode(node);
                foreach (Trigger t in triggers[node])
                {
                    if (!t.condition.Equals("between"))
                    {
                        parentnode.Nodes.Add(t.condition + " " + t.value);
                    }
                    else
                    {
                        parentnode.Nodes.Add(t.condition + " " + t.value + " and " + t.valueMax);
                    }
                        
                }
                treeViewTriggers.Nodes.Add(parentnode);
            }
            this.treeViewTriggers.EndUpdate();
            

        }

        void ReadXmlTriggers()
        {
            XmlDocument doc = new XmlDocument();
            triggers = new Dictionary<string, List<Trigger>>();
            try
            {
                doc.Load("trigger-rules.xml");
                XmlNodeList nodes = doc.SelectNodes("/triggers/sensor[@active='true']");
                foreach (XmlNode node in nodes)
                {
                    List<Trigger> t = new List<Trigger>();
                    string nodeName = node.Attributes["node"].Value;
                    foreach (XmlNode trig in node.ChildNodes)
                    {
                        if (trig.Attributes["active"].InnerText == "true")
                        {
                            t.Add(new Trigger
                            {
                                condition = trig.FirstChild.InnerText,
                                value = double.Parse(trig.ChildNodes[1].InnerText),
                                valueMax = trig.FirstChild.InnerText == "between" ? double.Parse(trig.ChildNodes[2].InnerText) : -1,
                                errorMessage = trig.LastChild.InnerText
                            });
                           
                        }
                    
                        
                    }
                    if (triggers.ContainsKey(node.Attributes["node"].InnerText))
                    {
                        triggers[nodeName] = t;
                    }else
                    {
                        triggers.Add(nodeName, t);
                    }
                }
                on = true;
                OnOff.Text = "Turn Alarms OFF";

            }
            catch (Exception)
            {

                throw;
            }
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            String data = Encoding.UTF8.GetString(e.Message);

            checkTriggers(data);

        }

        private void checkTriggers(string data)
        {
            if (on)
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.LoadXml(data);
                    List<Trigger> fired = new List<Trigger>();
                    List<Trigger> nodeTriggers = new List<Trigger>();
                    XmlNode sensor = doc.SelectSingleNode("/sensor");
                    string node = sensor.Attributes["element"].Value;
                    double val = double.Parse(sensor["value"].InnerText.Replace('.', ','));
                    nodeTriggers = triggers[node];
                    foreach (var trigger in nodeTriggers)
                    {
                        trigger.date = DateTime.Parse( sensor["date"].InnerText);
                        switch (trigger.condition)
                        {
                            case "equals":
                                if (val == trigger.value)
                                {
                                    trigger.condition += " " + trigger.value;
                                    trigger.value = val;
                                    fired.Add(trigger);
                                }

                                break;
                            case "less than":
                                if (val < trigger.value)
                                {
                                    trigger.condition += " " + trigger.value;
                                    trigger.value = val;
                                    fired.Add(trigger);
                                }

                                break;
                            case "greater than":
                                if (val > trigger.value)
                                {
                                    trigger.condition += " " + trigger.value;
                                    trigger.value = val;
                                    fired.Add(trigger);
                                }

                                break;
                            case "between":
                                if (val > trigger.value && val < trigger.valueMax)
                                {
                                    trigger.condition += " " + trigger.value + " and " + trigger.valueMax;
                                    trigger.value = val;
                                    fired.Add(trigger);
                                }

                                break;
                        }
                        
                        if(fired.Count > 0)
                        {
                            fireTriggers(fired, node);
                            counter += fired.Count; //será que está a concatenar? nao, no debug fez bem
                            //  \/ dá erro aqui \/ wtff XD fuck 
                            this.labelAlarms.BeginInvoke((MethodInvoker)delegate () { this.labelAlarms.Text = this.counter.ToString(); ; });
                        }

                    }
                }
                catch (Exception)
                {

                    throw new Exception("Error in checkTriggers()");
                }
            }
        }

        private void fireTriggers(List<Trigger> fired, string node)
        {

            XmlDocument doc = new XmlDocument();
            
            foreach (Trigger t in fired)
            {

                XmlElement alarm = doc.CreateElement("alarm");
                alarm.SetAttribute("node", node);

                XmlElement val = doc.CreateElement("value");
                val.InnerText = t.value.ToString();
                alarm.AppendChild(val);

                XmlElement cond = doc.CreateElement("condition");
                cond.InnerText = t.condition;
                alarm.AppendChild(cond);

                XmlElement err = doc.CreateElement("error-message");
                err.InnerText = t.errorMessage;
                alarm.AppendChild(err);

                XmlElement date = doc.CreateElement("date");
                date.InnerText = t.date.ToString();
                alarm.AppendChild(date);

                doc.AppendChild(alarm);
            }
            
            SendData(doc);
           
        }

        private static void SendData(XmlDocument triggers)
        {
            MqttClient m_cClient = new MqttClient(Properties.Settings.Default.BrokerIP);

            m_cClient.Connect(Guid.NewGuid().ToString());

            if (!m_cClient.IsConnected)
            {
                Console.WriteLine("Error connecting to message broker...");
                return;
            }
            m_cClient.Publish("alarms", Encoding.UTF8.GetBytes(triggers.OuterXml));
            Console.WriteLine("Sent");
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

        private void OnOff_Click(object sender, EventArgs e)
        {
            if (on)
            {
                on = false;
                OnOff.Text = "Turn Alarms ON";
            } else
            {
                on = true;
                OnOff.Text = "Turn Alarms OFF";
            }
        }
    }
}
