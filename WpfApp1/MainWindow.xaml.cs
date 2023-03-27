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
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace WpfApp1
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Windows Presentation Foundation!");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bank;Integrated Security=True"; // строка подключения к базе данных
            string query = "SELECT TOP 1 id FROM Card ORDER BY id DESC"; // запрос на выборку последней записи из таблицы Card  

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int lastId = reader.GetInt32(0); // получаем значение id из первого стол,бца
                    MessageBox.Show("Последняя запись в таблице: " + lastId.ToString()); // выводим значение на экран
                }

                reader.Close();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string NumText, PinText;

            NumText = NumTextBox.Text;
            PinText = PinTextBox.Text;
            int HelloUser;

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bank;Integrated Security=True"; // строка подключения к базе данных
            string query = "SELECT card_num, card_pin FROM Card WHERE card_num =  '" + NumTextBox.Text+ "'AND card_pin = '"+ PinTextBox.Text+"'"; // проверка номера карты и пина
            

            
            DataTable dtbl = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query, connectionString);
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                
                string userdbr = "SELECT id_client = @HelloUser User FROM Card WHERE card_num =  '" + NumTextBox.Text + "'AND card_pin = '" + PinTextBox.Text + "'";
                MessageBox.Show("Здравствуйте " ); // выводим значение на экран
                //frmMain objFrmMain = new frmMain();
                this.Hide();
                //objFrmMain.Show();
            }
            else
            {
                
                MessageBox.Show("Check your username and password");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
    }


