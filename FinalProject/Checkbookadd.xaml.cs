using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using FinalProject;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Checkbookadd.xaml
    /// </summary>
    public partial class Checkbookadd : Window
    {
        public Checkbookadd()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Add("Checkings");
            comboBox.Items.Add("Savings");
        }

        private void save_button(object sender, RoutedEventArgs e)
        {
            String amount = Amt.Text;
            String date = datepick.SelectedDate.ToString();
            String tag = Tagadd.Text;
            String payee = Payeeadd.Text;
            String account = comboBox.SelectedItem.ToString();
            //var username = "sample";

            if (account == null || date == null || amount == null || tag == null || payee == null)
            {
                MessageBox.Show("Enter all fields");
            }
            else
            {
                string dbConnectionString = @"Data Source = y2kg1t6wb0.checkbook.dbo; Integrated Security=True";
                SQLiteConnection data = new SQLiteConnection(dbConnectionString);
                //SqlConnection data = new SqlConnection(dbConnectionString);
                try
                {
                    data.Open();
                    SQLiteCommand insert = new SQLiteCommand();
                    //SqlCommand insert = new SqlCommand();
                    insert.CommandText = "INSERT INTO CB  Values('" + account + "','" + date + "','" + amount + "','" + tag + "','" + payee + "')";
                    insert.Connection = data;
                    insert.ExecuteNonQuery();
                    MessageBox.Show("Values are Inserted");
                    data.Close();
                    this.Close();
                   
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
    }
}
