using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
=======
using System.Globalization;
>>>>>>> origin/master
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;

namespace SmartH2O_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        /*IMPORTANTE*************
        alguem que se dê ao trabalho de ver como se faz o caminho relativo a partir do diretorio solution
        mas se nao vos apetecer façam o caminho absoluto como eu depois de o adaptarem.*/

<<<<<<< HEAD
        //string FILEPATH = @"D:\Desktop\Ivo\Escola\3ano\5_IS\Projeto\SmartH2O_DU\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml";
        //string FILEPATH = @"C:\Users\ASUS\Documents\Projeto_IS\SmartH2O_DU\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml";
        //string FILEPATH = @"D:\Alex\Documentos\Projeto_IS\SmartH2O_DU\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml";
        string FILEPATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml");
        
=======
       
        string FILEPATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\SmartH2O-DLog\SmartH2O-DLog\bin\Debug\param-data.xml");
        

>>>>>>> origin/master
        //devolve string agora para testar
        public List<string> GetSumInformationAtDay(string day, string elem)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
<<<<<<< HEAD
            //usem o select nodes depois
            XmlNodeList nodes = (doc.SelectNodes(" / sensors/sensor[@element='" + elem + "'][contains(date,'" + day + "')]"));
=======

            XmlNodeList nodes = (doc.SelectNodes("/sensors/sensor[@element='" + elem + "'][contains(date,'" + day + "')]"));
>>>>>>> origin/master
            List<double>[] values = new List<double>[24];
            List<string> result = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                values[i] = new List<double>();
            }


            foreach (XmlNode node in nodes)
            {
                int hour = int.Parse(node.ChildNodes[2].InnerText.Split(' ')[1].Substring(0, 2));

                string value = node.ChildNodes[1].InnerText.Replace(".", ",");
                values[hour - 1].Add(double.Parse(value));
            }

            for (int i = 0; i < 24; i++)
            {
                if (values[i].Count > 0)
                {
                    double min = values[i].Min(), max = values[i].Max(), avg = values[i].Average();
                    result.Add(i + ";" + min + ";" + max + ";" + avg);

                }
            }

            return result;

        }

        public Dictionary<DateTime, List<double>> GetSumInformationBetweenDates(DateTime firstDate, DateTime secondDate, string elem)
        {
            //SensorData s = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);
            //usem o select nodes depois
            XmlNodeList nodes = (doc.SelectNodes("/sensors/sensor[@element='PH']"));
            Dictionary<DateTime, List<double>> filteredNodes = new Dictionary<DateTime, List<double>>();
        
            foreach (XmlNode node in nodes)
            {
                DateTime date = (Convert.ToDateTime(node.ChildNodes[2].InnerText.Split(' ')[0]));
                if (date >= firstDate &&
                    (date <= secondDate))
                {

                    double value = double.Parse(node.ChildNodes[1].InnerText.Replace(".", ","));
                    if (filteredNodes.ContainsKey(date))
                    {
                        List<double> vals = filteredNodes[date];

                        vals.Add(value);

                        filteredNodes[date] = vals;
                    }
                    else
                    {
                        List<double> newList = new List<double>();
                        newList.Add(value);
                        filteredNodes.Add(date, newList);
                    }
                    filteredNodes[date].Add(value);
                }   

            }

            foreach (var day in filteredNodes.Keys.ToList())
            {
                List<double> vals = filteredNodes[day];
                double min = vals.Min(), max = vals.Max(), avg = vals.Average();
                vals.Clear();
                vals.Add(min);
                vals.Add(max);
                vals.Add(avg);

                filteredNodes[day] = vals;
            }

            return filteredNodes;


        }

        public Dictionary<int, List<double>> GetSumInformationByWeek(string elem)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            XmlDocument doc = new XmlDocument();
            doc.Load(FILEPATH);

            XmlNodeList nodes = (doc.SelectNodes("/sensors/sensor[@element='" + elem + "']"));

            Dictionary<int, List<double>> dict = new Dictionary<int, List<double>>();

            foreach (XmlNode node in nodes)
            {
                DateTime day = Convert.ToDateTime(node.ChildNodes[2].InnerText.Split(' ')[0]);
                int week = cal.GetWeekOfYear(day, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                double value = double.Parse(node.ChildNodes[1].InnerText.Replace(".", ","));
                if (dict.ContainsKey(week))
                {
                    List<double> vals = dict[week];

                    vals.Add(value);

                    dict[week] = vals;
                }
                else
                {
                    List<double> newList = new List<double>();
                    newList.Add(value);
                    dict.Add(week, newList);
                }

            }

            foreach (int week in dict.Keys.ToList())
            {
                List<double> vals = dict[week];
                double min = vals.Min(), max = vals.Max(), avg = vals.Average();
                vals.Clear();
                vals.Add(min);
                vals.Add(max);
                vals.Add(avg);

                dict[week] = vals;
            }

            return dict;
        }
    }
}
