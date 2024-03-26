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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:C:\Users\Joohyun\Downloads\term_project.accdb";
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Joohyun\\Downloads\\term_project.accdb;Jet OLEDB:Engine Type=5";
        //string connectionString = @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=C:\Users\Joohyun\Downloads\term_project.accdb";
        // string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Joohyun\Downloads\term_project.accdb";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCoordinates();
        }
        private void LoadCoordinates()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Latitude, Longitude FROM YourTableName";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double latitude = (double)reader["Latitude"];
                            double longitude = (double)reader["Longitude"];

                            chart1.Series["Coordinates"].Points.AddXY(latitude, longitude);
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
    }
}

