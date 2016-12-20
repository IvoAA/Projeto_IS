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
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartH2O_SeeAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxLogsTime.SelectedIndex = 0;
            comboBoxLogsElement.SelectedIndex = 0;
            comboBoxStatistics.SelectedIndex = 0;
            groupBoxLogsHourly.Location = new Point(54, 44);
        }

        private void buttonLogsBetweenDates_Click(object sender, EventArgs e)
        {
            dataGridViewLogs.Rows.Clear();
            string element = comboBoxLogsElement.SelectedItem.ToString();
            Service1Client serviceClient = new Service1Client();

            Dictionary<DateTime, double[]> dict = serviceClient.GetSumInformationBetweenDates(dateTimePickerLogsStartingDate.Value.Date, dateTimePickerLogsEndingDate.Value.Date, element);

            int i = 0;
            foreach (var day in dict.Keys)
            {
                double[] sums = dict[day];
                this.dataGridViewLogs.Rows.Add();
                dataGridViewLogs.Rows[i].Cells[0].Value = day.ToString("dd/MM/yyyy");
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[0];
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[2];
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[1];
                i++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxAlarms.Enabled = !checkBoxAll.Checked;
        }

        private void comboBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxLogsBetweenDates.Visible = false;
            groupBoxLogsHourly.Visible = false;

            if (comboBoxLogsTime.SelectedIndex == 0)
            {
                groupBoxLogsHourly.Visible = true;
            }
            else if (comboBoxLogsTime.SelectedIndex == 1)
            {
                groupBoxLogsBetweenDates.Visible = true;
            }
            else if (comboBoxLogsTime.SelectedIndex == 2)
            {
                printWeeklyData();
            }
        }

        private void buttonLogsHourly_Click(object sender, EventArgs e)
        {
            dataGridViewLogs.Rows.Clear();
            string element = comboBoxLogsElement.SelectedItem.ToString();
            Service1Client serviceClient = new Service1Client();
            
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto
            string date = dateTimePickerLogsDaily.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, element);

            int i = 0;
            foreach (var hour in sum)
            {
                this.dataGridViewLogs.Rows.Add();
                string[] sums = hour.Split(';');
                dataGridViewLogs.Rows[i].Cells[0].Value = sums[0] + "h00";
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[1];
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[3];
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[2];
                i++;
            }
        }

        private void printWeeklyData ()
        {
            dataGridViewLogs.Rows.Clear();
            string element = comboBoxLogsElement.SelectedItem.ToString();
            Service1Client serviceClient = new Service1Client();
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto

            Dictionary<int, double[]> dict = serviceClient.GetSumInformationByWeek(element);

            int i = 0;
            foreach (var week in dict.Keys)
            {
                double[] sums = dict[week];
                dataGridViewLogs.Rows.Add();
                dataGridViewLogs.Rows[i].Cells[0].Value = "Week " + week.ToString();
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[0];
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[2];
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[1];
                i++;
            }
            
        }

        private void comboBoxLogsElement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLogsTime.SelectedIndex == 2)
            {
                printWeeklyData();
            }
        }

        private void buttonAlarmsPrint_Click(object sender, EventArgs e)
        {
            dataGridViewAlarms.Rows.Clear();
            //string element = "PH";
            string[] lista = new string[] { };
            if (checkBoxAll.Checked == false) { 
                lista = checkedListBoxAlarms.CheckedItems.OfType<string>().ToArray();
            }
            Service1Client serviceClient = new Service1Client();
            //escolham dia 15 de dezembro porque só temos registos nesse dia por enquanto

            string[] sum = serviceClient.GetRaisedAlarms(lista);

            int i = 0;
            foreach (string alarm in sum)
            {
                this.dataGridViewAlarms.Rows.Add();
                string[] sums = alarm.Split(';');
                dataGridViewAlarms.Rows[i].Cells[0].Value = sums[0]; //data
                dataGridViewAlarms.Rows[i].Cells[1].Value = sums[3]; //value
                dataGridViewAlarms.Rows[i].Cells[2].Value = sums[1]; //description
                dataGridViewAlarms.Rows[i].Cells[3].Value = sums[2]; //description
                i++;
            }
            
        }

        private void comboBoxStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBoxStatisticsHourly.Visible = false;

            if (comboBoxStatistics.SelectedIndex == 0)
            {
                groupBoxStatisticsHourly.Visible = true;
            }
            else if (comboBoxStatistics.SelectedIndex == 1)
            {
                ;//cenas
            }
            
        }

        private void buttonStatisticsDaily_Click(object sender, EventArgs e)
        {
            //chart.Titles;
            //chart.Series;
            Service1Client serviceClient = new Service1Client();

            string date = dateTimePickerStatisticsDaily.Value.ToString("dd/MM/yyyy");
            string[] sum = serviceClient.GetSumInformationAtDay(date, "PH");

            Series[] avg = new Series[24];

            for (int j = 0; j < 23; j++)
            {
                avg[j] = new Series();
                
                avg[j].Points.Add(j, j);

                chart.Series.Add(avg[j]);
            }

            /*int i = 0;
            foreach (var hour in sum)
            {
                //this.dataGridViewLogs.Rows.Add();
                string[] sums = hour.Split(';');
                avg[i].Points.Add(i, double.Parse(sums[3]));

                /*dataGridViewLogs.Rows[i].Cells[0].Value = sums[0] + "h00"; //time
                dataGridViewLogs.Rows[i].Cells[1].Value = sums[1]; //minimum
                dataGridViewLogs.Rows[i].Cells[2].Value = sums[3]; //average
                dataGridViewLogs.Rows[i].Cells[3].Value = sums[2]; //maximum
                chart.Series.Add(avg[i]);
                i++;
            }*/

            chart.ChartAreas[0].AxisX.Minimum = 1;
            chart.ChartAreas[0].AxisX.Maximum = 24;
            chart.ChartAreas[0].AxisY.Minimum = 1;
            chart.ChartAreas[0].AxisY.Maximum = 15;

        }
    }
}

