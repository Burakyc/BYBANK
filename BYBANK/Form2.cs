using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BYBANK
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Server=ANCLATHES;Database=DBBYBANK;Trusted_Connection=True;");
        

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

                    MessageBox.Show("Turkey Code added automatically");

                    number = "+90" + number;

                }

                number = number.Replace(" ", "");



                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);

            }

            catch (Exception ex)

            {

            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void ONLY_NUMBER_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Random rnd = new Random();
    string birlesik = "";

    for (int i = 0; i < 5; i++)
    {
        int rastgeleSayi = rnd.Next(0, 9);
        birlesik += rastgeleSayi.ToString();
    }

    MessageBox.Show(birlesik);

    MessageBox.Show("HESAP OLUŞTURULMUŞTUR ŞİFRE SMS OLARAK GELECEKTİR.");
          
           
          sendWhatsApp(textBox4.Text, birlesik);
         

            conn.Open();

    string komut = "INSERT INTO CUSTOMERS (NAME, LASTNAME, IDNUMBER, PHONE, PASSWORD) VALUES (@name, @LastName, @IdNumber, @Phone, @passwd)";

    using (SqlCommand command = new SqlCommand(komut, conn))
    {
        command.Parameters.AddWithValue("@Name", textBox1.Text);
        command.Parameters.AddWithValue("@LastName", textBox2.Text);
        command.Parameters.AddWithValue("@IdNumber", textBox3.Text);
        command.Parameters.AddWithValue("@Phone", textBox4.Text);
        command.Parameters.AddWithValue("@passwd", birlesik);

        command.ExecuteNonQuery();
    }

    conn.Close();
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
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
    }


}


