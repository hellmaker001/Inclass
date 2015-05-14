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
using System.Data.SQLite;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Checkbookedit.xaml
    /// </summary>
    public partial class Checkbookedit : Window
    {
        public Checkbookedit()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox.Items.Add("Checkings");
            comboBox.Items.Add("Savings");
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            String amount = Amont.Text;
            String date = datep.SelectedDate.ToString();
            String tag = Tagedit.Text;
            String payee = Payeeedit.Text;
            String account = comboBox.SelectedItem.ToString();
            var username = "sample";

            string dbConnectionString = @"Data Source = y2kg1t6wb0.checkbook.dbo; Integrated Security=True";
            SQLiteConnection data = new SQLiteConnection(dbConnectionString);
            //SqlConnection data = new SqlConnection(dbConnectionString);
            try
            {
                data.Open();
                SQLiteCommand insert = new SQLiteCommand();
                //SqlCommand insert = new SqlCommand();
                insert.CommandText = "UPDATE TABLE CB  Values('" + username + "','" + account + "','" + date + "','" + amount + "','" + tag + "','" + payee + "') ";
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
