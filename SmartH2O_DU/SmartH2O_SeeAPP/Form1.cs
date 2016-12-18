using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartH2O_SeeAPP.SmartH2O_Service;

namespace SmartH2O_SeeAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service1Client serviceClient = new Service1Client();
            // -----------------------------------------------------------------------------------GetSumInformationByWeek
            Dictionary<int, double[]> dict = serviceClient.GetSumInformationByWeek("PH");

            string result = "";
            foreach (var week in dict.Keys)
            {
                double[] sums = dict[week];
                result += "[" + week + "] Min: " + sums[0] + " Max: " + sums[1] + " Avg: " + sums[2] + Environment.NewLine;
            }

            /*// -----------------------------------------------------------------------------------GetSumInformationAtDay            
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, "PH");
            string result = "";

            int i = 0;
            foreach (var hour in sum)
            {
                string[] sums = hour.Split(';');
                result += "[" + sums[0] + "H - " + (int.Parse(sums[0])+1) + "H] Min: " + sums[1] + " Max: " + sums[2] + " Avg: " + sums[3] + Environment.NewLine;
                i++;
            }*/


            if(result.Length == 0)
            {
                result = "No Data Found";
            }

            textBox1.Text = result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
