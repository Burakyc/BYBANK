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
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Configuration;

namespace BYBANK
{
    public partial class Form3 : Form
    {
        Form4 form4;
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Server=ANCLATHES;Database=DBBYBANK;Trusted_Connection=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            form4 = new Form4();
            
            conn.Open();

            
            string sql = "SELECT * FROM CUSTOMERS WHERE IDNUMBER ='" + textBox1.Text + "'AND PASSWORD='" + textBox2.Text + "'";

      


            using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
            {
                SqlDataReader reader2 = sqlCommand.ExecuteReader();

                if (reader2.Read()) // Verileri okuyun
                {
                    form4.label6.Text = reader2.GetString(0);
                    form4.label7.Text = reader2.GetString(1);
                    form4.label8.Text = reader2.GetSqlMoney(4).ToString();
                    form4.label9.Text = reader2.GetString(2);
                    form4.Show();
                }
                else
                {
                    label3.Text = "Müşteri bulunamadı!";
                }

                reader2.Close(); // Veritabanı okuyucusunu kapatın
            }

            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
    }
}
