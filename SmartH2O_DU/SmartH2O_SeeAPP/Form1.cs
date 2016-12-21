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
            comboBoxStatisticsTime.SelectedIndex = 0;
            comboBoxStatisticsElement.SelectedIndex = 0;
            comboBoxStatisticsNaoSei.SelectedIndex = 0;
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

        private void printWeeklyData()
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
            string[] lista = new string[] { };
            if (checkBoxAll.Checked == false)
            {
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

        private void displayGraphBetweenDates(DateTime start_date, DateTime finish_date)
        {

            string element = comboBoxStatisticsElement.SelectedItem.ToString();
            Service1Client serviceClient = new Service1Client();

            
            Dictionary<DateTime, double[]> dict = serviceClient.GetSumInformationBetweenDates(start_date, finish_date, element);
            

            List<string> lista = new List<string>();

            int i = 0;
            foreach (var day in dict.Keys)
            {
                double[] sums = dict[day];
                
                if (sums.Length > 0)
                {

                    lista.Add((day.ToString("dd/MM/yyyy") + ";" + sums[0] + ";" + sums[1] + ";" + sums[2]));
                }
                i++;
            }

            //-----------------------------------------------------------------------------------------

            
            string[] result = lista.Select(x => x.ToString()).ToArray();
            createGraphWithMaxAvgMin(result, "Day", "Values", "Parameters Info on Days");

        }

        private bool createGraphWithMaxAvgMin (string[] paramVals, string XTitle, string YTitle, string Title)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            if (paramVals.Length <= 0) return false;
            
            //   START
            Series avg = new Series();
            Series max = new Series();
            Series min = new Series();
                

            foreach (string row in paramVals)
            {
                string[] sums = row.Split(';');

                min.Points.AddXY(sums[0], Convert.ToDouble(sums[1]));
                max.Points.AddXY(sums[0], Convert.ToDouble(sums[2]));
                avg.Points.AddXY(sums[0], Convert.ToDouble(sums[3]));

            }
            chart.Series.Add(max);
            chart.Series.Add(avg);
            chart.Series.Add(min);



            chart.Series[0].Name = "Max";
            chart.Series[1].Name = "Avg";
            chart.Series[2].Name = "Min";

            for (int i = 0; i < 3; i++)
            {
                chart.Series[i].ChartType = SeriesChartType.SplineArea;
            }
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Title = XTitle;
            chart.ChartAreas[0].AxisY.Title = YTitle;
            chart.Titles.Add(Title);

            return true;
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            
            string date = dateTimePickerStatistics.Value.ToString("dd/MM/yyyy");

            string element = comboBoxStatisticsElement.SelectedItem.ToString();


            if (comboBoxStatisticsElement.SelectedIndex == 3)
            {
                DateTime start_date = dateTimePickerStatistics.Value.Date;
                List<string> elements = new List<string>();
                List<string[]> all_elements_data = new List<string[]>();

                if (comboBoxStatisticsTime.SelectedIndex == 0)
                {
                    //CENAS A IMPLEMENTAR
                   /* foreach (string item in comboBoxStatisticsElement.Items)
                    {
                        if (item.ToString() != "All")
                        {
                            elements.Add(item.ToString());
                            //string[] one_element_data = adapterGraph(start_date, finish_date, item.ToString());
                            //all_elements_data.Add(one_element_data);
                        }
                    }

                    createGraphAll(all_elements_data, "Days", "Values", "Parameters Info", elements);*/
                }
                else 
                {
                    DateTime finish_date = new DateTime();
                    if (comboBoxStatisticsTime.SelectedIndex == 1)
                    {
                        finish_date = start_date.AddDays(7);
                    }else
                    {
                        finish_date = dateTimePickerStatisticsEndingDate.Value.Date;
                    }


                    foreach (string item in comboBoxStatisticsElement.Items)
                    {
                        if (item.ToString() != "All")
                        {
                            elements.Add(item.ToString());
                            string[] one_element_data = adapterGraph(start_date, finish_date, item.ToString());
                            all_elements_data.Add(one_element_data);
                        }
                    }

                    createGraphAll(all_elements_data, "Days", "Values", "Parameters Info", elements);
                }
                

                return;
            }

            if (comboBoxStatisticsTime.SelectedIndex == 0)
            {
                Service1Client serviceClient = new Service1Client();
                string[] paramVals = serviceClient.GetSumInformationAtDay(date, element);

                if ( !createGraphWithMaxAvgMin(paramVals, "Hours", "Values", "Parameters Info " + date) )
                    System.Windows.Forms.MessageBox.Show("No data found!");

            }
            else if (comboBoxStatisticsTime.SelectedIndex == 1)
            {

                DateTime start_date = dateTimePickerStatistics.Value.Date;
                DateTime finish_date = start_date.AddDays(7);
                displayGraphBetweenDates(start_date, finish_date);

            }
            else
            {

                DateTime start_date = dateTimePickerStatistics.Value.Date;
                DateTime finish_date = dateTimePickerStatisticsEndingDate.Value.Date;
                displayGraphBetweenDates(start_date, finish_date);

            }

        }

        private string[] adapterGraph(DateTime start_date, DateTime finish_date, string element)
        {
            Service1Client serviceClient = new Service1Client();
            Dictionary<DateTime, double[]> dict = serviceClient.GetSumInformationBetweenDates(start_date, finish_date, element);

            List<string> lista = new List<string>();

            int i = 0;
            foreach (var day in dict.Keys)
            {
                double[] sums = dict[day];

                if (sums.Length > 0)
                {

                    lista.Add((day.ToString("dd/MM/yyyy") + ";" + sums[0] + ";" + sums[1] + ";" + sums[2]));
                }
                i++;
            }
            
            return lista.Select(x => x.ToString()).ToArray();
        }

        private void comboBoxStatisticsTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStatisticsTime.SelectedIndex == 2)
            {
                dateTimePickerStatisticsEndingDate.Visible = true;
                buttonStatistics.Location = new Point(554, 14);

            }
            else
            {
                dateTimePickerStatisticsEndingDate.Visible = false;
                buttonStatistics.Location = new Point(348, 14);
            }
        }

        private void comboBoxStatisticsElement_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxStatisticsNaoSei.Visible = (comboBoxStatisticsElement.SelectedIndex == 3);
            
        }

        private bool createGraphAll(List<string[]> cenas_de_todos_elementos, string XTitle, string YTitle, string Title, List<string> elements)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            if (cenas_de_todos_elementos.Count <= 0) return false;

            //   START
            
            List<Series> series = new List<Series>();
            Dictionary<Series, string[]> valores = new Dictionary<Series, string[]>();
            int j = 0;
            foreach (string element in elements)
            {
                Series serie = new Series();
                serie.Name = element;
                serie.ChartType = SeriesChartType.Spline;
                series.Add(serie);
                chart.Series.Add(serie);
                valores[serie] = cenas_de_todos_elementos[j];
                j++;
            }

            foreach (Series serie in series)
            {
                //foreach (string[] paramVals in all_elements_data) { 

                    foreach (string row in valores[serie])
                    {
                        string[] sums = row.Split(';');


                        serie.Points.AddXY(sums[0], Convert.ToDouble(sums[comboBoxStatisticsNaoSei.SelectedIndex+1]));
                        //min.Points.AddXY(sums[0], Convert.ToDouble(sums[1]));
                        //max.Points.AddXY(sums[0], Convert.ToDouble(sums[2]));
                        //avg.Points.AddXY(sums[0], Convert.ToDouble(sums[3]));
                    }
                //}
            }
                        
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Title = XTitle;
            chart.ChartAreas[0].AxisY.Title = YTitle;
            chart.Titles.Add(Title);

            return true;
        }
    }   
}

