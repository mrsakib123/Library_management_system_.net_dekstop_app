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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
         

        }
        int p;
         

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            MessageBox.Show("Are you Sure ??\nPlease Click 'Yes' or 'No' and Press 'click' ");
        }

        private void fndelete()
        {
            connection con = new connection();
            con.thisConnection.Open();
            SqlCommand thisCommand1 = con.thisConnection.CreateCommand();
            thisCommand1.CommandText ="delete BookList where bookid= '" + textBox1.Text + "'";
            thisCommand1.Connection = con.thisConnection;
            thisCommand1.CommandType = CommandType.Text;


            try
            {
                thisCommand1.ExecuteNonQuery();
                MessageBox.Show("Delete Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            con.thisConnection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;



        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                connection ab = new connection();
                ab.thisConnection.Open();
                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BookList", ab.thisConnection);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataTable dtbl = new DataTable();
                thisAdapter.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                ab.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 m = new Form9();
            m.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (p == 1)
            {
                fndelete();
            }
            else if(p==2)
            {
                MessageBox.Show("Delete Cancel");
            }
            else
            {
                MessageBox.Show("Something Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                comboBox1.Items.Add(textBox1.Text);
                connection sv = new connection();
                sv.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = sv.thisConnection;
                thisCommand.CommandText = " SELECT * FROM BookList WHERE bookid='" + textBox1.Text + "' ";
                SqlDataReader thisReader = thisCommand.ExecuteReader();

                if (thisReader.Read())
                {
                    MessageBox.Show("Book Found");
                }
                else
                {
                    MessageBox.Show(" Not Found");
                }

                sv.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            p = 1;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            p = 2;
        }
    }
}
