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
        private bool isValid;
        private String validateMessage;
        public String ValidateMessage
        {
            get { return validateMessage; }
        }
        private String xsdFilePath;
        private String xmlFilePath;

        public HandlerXML(String xmlFile, String xsdFile)
        {
            xmlFilePath = xmlFile;
            xsdFilePath = xsdFile;
        }
               
        public bool ValidateXML(bool file)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            try
            {
                if (file)
                {
                    doc.Load(xmlFilePath);
                }
                else
                {
                    doc.LoadXml(xmlFilePath);
                }
                ValidationEventHandler eventH = new ValidationEventHandler(MyEvent);
                doc.Schemas.Add(null, xsdFilePath);
                doc.Validate(eventH);
            }
            catch (XmlException ex)
            {
                isValid = false;
                validateMessage = string.Format("Error{0}", ex.ToString());
            }

            return isValid;
        }

        private void MyEvent(object sender, ValidationEventArgs args)
        {
            isValid = false;
            validateMessage += string.Format("Error: {0}", args.Message);
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

    }
}
