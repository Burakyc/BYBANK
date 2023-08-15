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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BYBANK
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Server=ANCLATHES;Database=DBBYBANK;Trusted_Connection=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            
           

            string komut = "UPDATE CUSTOMERS SET MONEY = @BALANCE WHERE IDNUMBER= @userId"; ;

            using (SqlCommand command = new SqlCommand(komut, conn))
            {
                command.Parameters.AddWithValue("@BALANCE",textBox1.Text);
                command.Parameters.AddWithValue("@userıd",label9.Text);
                
                command.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
