using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYBANK
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        
        private void sendWhatsApp(string number, string message)

        {

            try

            {

                if (number == "")

                {

                    MessageBox.Show("No number added");

                }

                if (number.Length <= 10)

                {

                    number = "+90" + number;

                }

                number = number.Replace(" ", "");



                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);

            }

            catch (Exception ex)

            {

            }

        }
        SqlConnection conn = new SqlConnection(@"Server=ANCLATHES;Database=DBBYBANK;Trusted_Connection=True;");

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        string birlesik;

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            

            for (int i = 0; i < 5; i++)
            {
                int rastgeleSayi = rnd.Next(0, 9);
                birlesik += rastgeleSayi.ToString();
            }
            conn.Open();


            string sql = "SELECT * FROM CUSTOMERS WHERE IDNUMBER ='" + textBox1.Text + "'AND PHONE='" + textBox2.Text + "'";




            using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader2 = sqlCommand.ExecuteReader();

                if (reader2.Read()) // Verileri okuyun
                {
                    sendWhatsApp(textBox2.Text,birlesik);
                }
                else
                {
                    label4.Text = "Müşteri bulunamadı!";
                }

                reader2.Close(); // Veritabanı okuyucusunu kapatın
            }

            conn.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sec = 0;
            sec += 1;
            if (sec == 20)
            {
                SendKeys.Send("{ENTER}");
                SendKeys.Send("'a'");
                timer1.Stop();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            

            string sql = "SELECT * FROM CUSTOMERS WHERE IDNUMBER ='" + textBox1.Text + "'AND PHONE='" + textBox2.Text + "'";




            using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader2 = sqlCommand.ExecuteReader();

                if (reader2.Read() && textBox3.Text==birlesik) // Verileri okuyun
                {
                    sendWhatsApp(textBox2.Text,reader2.GetString(5) );
                }
                else
                {
                    label4.Text = "Onay kodu yanlış!";
                }

                reader2.Close(); // Veritabanı okuyucusunu kapatın
            }

            conn.Close();

        }
    }
}
