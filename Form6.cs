using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace LibrararyManagement
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                comboBox1.Items.Add(textBox1.Text);
                connection cn = new connection();
                cn.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = cn.thisConnection;
                thisCommand.CommandText = "SELECT * FROM BookList WHERE bookid='" + textBox1.Text + "' ";
                SqlDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    MessageBox.Show("Bookfound");
                }
                else
                {
                    MessageBox.Show("Book Not Found");
                }
                cn.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            SqlCommand thisCommand = sv.thisConnection.CreateCommand();
            thisCommand.CommandText ="update BookList set bookname = '" + textBox6.Text + "'  , publishyear='" + textBox2.Text + "'  , writtername='" + textBox3.Text + "' ,categoryname='" + textBox4.Text + "'  , qunatity='" + textBox7.Text + "'   where bookid= '" + textBox8.Text + "'      ";
            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sv.thisConnection.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 m = new Form9();
            m.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
