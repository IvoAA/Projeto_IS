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
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string s = serviceClient.GetSumInformationAtDay(date);

            textBox1.Text = s;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
