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
            comboBoxLogs.SelectedIndex = 0;
<<<<<<< HEAD
            groupBoxLogsDaily.Location = new Point(54, 44);
=======
            groupBoxLogsDaily.Location = new Point(54,44);
>>>>>>> origin/master
            groupBoxLogsWeekly.Location = new Point(54, 44);
        }

        private void buttonLogsBetweenDates_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            /*Service1Client serviceClient = new Service1Client();

=======
<<<<<<< HEAD
            /*Service1Client serviceClient = new Service1Client();
=======
            Service1Client serviceClient = new Service1Client();
            // -----------------------------------------------------------------------------------GetSumInformationByWeek
            /*Dictionary<int, double[]> dict = serviceClient.GetSumInformationByWeek("PH");

            string result = "";
            foreach (var week in dict.Keys)
            {
                double[] sums = dict[week];
                result += "[" + week + "] Min: " + sums[0] + " Max: " + sums[1] + " Avg: " + sums[2] + Environment.NewLine;
            }
            */
            /*// -----------------------------------------------------------------------------------GetSumInformationAtDay            
>>>>>>> origin/master
>>>>>>> origin/master
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePickerLogsStartingDate.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, "PH");

            int i = 0;
            foreach (var hour in sum)
            {
                this.dataGridViewLogs.Rows.Add();
                string[] sums = hour.Split(';');
                dataGridViewLogs.Rows[i].Cells[0].Value = "PH";//Exemplo
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[0];
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[1];
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[2];
                dataGridViewLogs.Rows[i].Cells[4].Value = sums[3];
                i++;
            }*/
<<<<<<< HEAD

=======
<<<<<<< HEAD
>>>>>>> origin/master
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked == false)
            {
                checkedListBox1.Enabled = true;
<<<<<<< HEAD
            }
            else
            {
                checkedListBox1.Enabled = false;

            }
        }

        private void comboBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxLogsBetweenDates.Visible = false;
            groupBoxLogsDaily.Visible = false;
            groupBoxLogsWeekly.Visible = false;

            if (comboBoxLogs.SelectedIndex == 0)
            {
                groupBoxLogsDaily.Visible = true;
            }
            else if (comboBoxLogs.SelectedIndex == 1)
            {
                groupBoxLogsBetweenDates.Visible = true;
            }
            else if (comboBoxLogs.SelectedIndex == 2)
            {
                groupBoxLogsWeekly.Visible = true;
            }
        }

        private void buttonLogsDaily_Click(object sender, EventArgs e)
        {
            dataGridViewLogs.Rows.Clear();
            Service1Client serviceClient = new Service1Client();
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePickerLogsDaily.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, "PH");

           /* Dictionary<DateTime, double[]> dict = serviceClient.GetSumInformationBetweenDates(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "PH");
=======
            }else
            {
                checkedListBox1.Enabled = false;
=======
            Dictionary<DateTime, double[]> dict = serviceClient.GetSumInformationBetweenDates(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "PH");
>>>>>>> origin/master

            string result = "";
            foreach (var week in dict.Keys)
            {
                double[] sums = dict[week];
                result += "[" + week + "] Min: " + sums[0] + " Max: " + sums[1] + " Avg: " + sums[2] + Environment.NewLine;
            }

            if (result.Length == 0)
            {
                result = "No Data Found";
>>>>>>> origin/master
            }
        }

<<<<<<< HEAD
            textBox1.Text = result;*/
=======
        private void comboBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxLogsBetweenDates.Visible = false;
            groupBoxLogsDaily.Visible = false;
            groupBoxLogsWeekly.Visible = false;

            if (comboBoxLogs.SelectedIndex == 0)
            {
                groupBoxLogsDaily.Visible = true;
            }
            else if (comboBoxLogs.SelectedIndex == 1)
            {
                groupBoxLogsBetweenDates.Visible = true;
            }
            else if (comboBoxLogs.SelectedIndex == 2)
            {
                groupBoxLogsWeekly.Visible = true;
            }
        }

        private void buttonLogsDaily_Click(object sender, EventArgs e)
        {
            dataGridViewLogs.Rows.Clear();
            Service1Client serviceClient = new Service1Client();
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePickerLogsDaily.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, "PH");
>>>>>>> origin/master

            int i = 0;
            foreach (var hour in sum)
            {
                this.dataGridViewLogs.Rows.Add();
                string[] sums = hour.Split(';');
                dataGridViewLogs.Rows[i].Cells[0].Value = "PH";//Exemplo
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[0];
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[1];
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[2];
                dataGridViewLogs.Rows[i].Cells[4].Value = sums[3];
                i++;
            }
        }
    }
}

