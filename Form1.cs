using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\eclas\\Documents\\term_project.accdb";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void LoadCoordinatesFromSheet(string seriesName, string tableName)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 100;  // X축의 최소값을 100으로 설정
            chart1.ChartAreas[0].AxisY.Minimum = 20;   // Y축의 최대값을 20으로 설정
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT latitude, longitude FROM {tableName}";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        var series = chart1.Series.Add(seriesName);
                        StringBuilder sb = new StringBuilder();

                        series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
                        series.BackSecondaryColor = System.Drawing.Color.Transparent;
                        while (reader.Read())
                        {
                            double latitude = (double)reader[0]; // 1열(latitude)의 데이터를 가져옵니다.
                            double longitude = (double)reader[1]; // 2열(longitude)의 데이터를 가져옵니다.

                            DataPoint dataPoint = new DataPoint(longitude, latitude);
                            series.Points.Add(dataPoint);

                            double xValue = dataPoint.XValue;
                            double yValue = dataPoint.YValues[0];

                            sb.AppendLine($"X: {xValue}, Y: {yValue}");
                            textBox1.Text = sb.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadCoordinatesFromSheet("부표1", "Sheet1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadCoordinatesFromSheet("부표2", "Sheet2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadCoordinatesFromSheet("부표3", "Sheet3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LoadCoordinatesFromSheet("부표4", "Sheet4");
        }
        private void chart2_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
