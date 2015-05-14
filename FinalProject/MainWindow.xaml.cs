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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Windows.Media.Brush;
using System.Drawing;
using System.Data.SQLite;
using GalaSoft.MvvmLight;


namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void edit_button(object sender, RoutedEventArgs e)
        {
            Checkbookedit check = new Checkbookedit();
            check.ShowDialog();
        }
        private void add_button(object sender, RoutedEventArgs e)
        {
            Checkbookadd check = new Checkbookadd();
            check.ShowDialog();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoginWindow loginWindow = new LoginWindow();
            

            String dbConnectionString = @"Data Source =  y2kg1t6wb0.checkbook.dbo;Integrated Security=True";
            SQLiteConnection sqllite = new SQLiteConnection(dbConnectionString);
            try
            {
                sqllite.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "select Account,Date,Amount,Tag,Payee from CB;";
                command.Connection = sqllite;
                command.ExecuteNonQuery();

                SQLiteDataAdapter adap = new SQLiteDataAdapter(command);
                DataSet set = new DataSet("CB");
                adap.Fill(set);
                dataGrid.ItemsSource = set.Tables[0].DefaultView;

                SQLiteDataReader reader = command.ExecuteReader();
                sqllite.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

           
        }
        private void action(object sender, RoutedEventArgs e)
        {
            String dbConnectionString = @"Data Source =  y2kg1t6wb0.checkbook.dbo;Integrated Security=True";
            SQLiteConnection sqllite = new SQLiteConnection(dbConnectionString);
            try
            {
                sqllite.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "select Amount,Payee from CB as X;";
                command.Connection = sqllite;
                command.ExecuteNonQuery();

                SQLiteDataAdapter adap = new SQLiteDataAdapter(command);
                DataSet set = new DataSet("CB");
                adap.Fill(set);
                dataGrid.ItemsSource = set.Tables[0].DefaultView;

                SQLiteDataReader reader = command.ExecuteReader();
                sqllite.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        public Brush Brush
        {
            get;
        }
        private void refersh_Click(object sender, RoutedEventArgs e)
        {
            String dbConnectionString = @"Data Source =  y2kg1t6wb0.checkbook.dbo;Integrated Security=True";
            SQLiteConnection sqllite = new SQLiteConnection(dbConnectionString);
            try
            {
                sqllite.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.CommandText = "select Account,Date,Amount,Tag,Payee from CB;";
                command.Connection = sqllite;
                command.ExecuteNonQuery();

                SQLiteDataAdapter adap = new SQLiteDataAdapter(command);
                DataSet set = new DataSet("CB");
                adap.Fill(set);
                dataGrid.ItemsSource = set.Tables[0].DefaultView;

                SQLiteDataReader reader = command.ExecuteReader();
                sqllite.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
            Graphics g = this.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Red);
            g.FillEllipse(myBrush, ClientRectangle);
            
        }

      /*  public IEnumerable<string> tagsel
        {
            get
            {
                return dataGrid.s(t=>t.Tag).Distinct();
            }
        }*/
        
        }
    }

