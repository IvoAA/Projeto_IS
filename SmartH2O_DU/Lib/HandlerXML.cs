using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace Lib
{
    public class HandlerXML
    {
        public string XSDFilePath { get; set; }

        public HandlerXML()
        {
            XSDFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"sensor.xsd";
        }

        public XmlElement CreateXMLSensorFile(string message)
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


        private bool isValid = true;
        public string ValidationMessage { get; set; }

        public bool ValidateXML(string XML)
        {
            ValidationMessage = "Document Valid!";
            isValid = true;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(XML);
                ValidationEventHandler eventH = new ValidationEventHandler(MyEvent);
                doc.Schemas.Add(null, XSDFilePath);
                doc.Validate(eventH);
            }
            catch (XmlException ex)
            {
                isValid = false;
                ValidationMessage = string.Format("Error{0}", ex.ToString());
            }

            return isValid;
        }

        private void MyEvent(object sender, ValidationEventArgs args)
        {
            isValid = false;
            ValidationMessage = string.Format("Document not valid! {0}", args.Message);
        }

    }
}
