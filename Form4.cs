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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int x;

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void fndelete()
        {
            connection con = new connection();
            con.thisConnection.Open();
            SqlCommand thisCommand1 = con.thisConnection.CreateCommand();
            thisCommand1.CommandText = "delete manager_info where username= '" + textBox3.Text + "'";
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


        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM manager_info", sv.thisConnection);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "manager_info");
            DataRow thisRow = thisDataSet.Tables["manager_info"].NewRow();

            try
            {

                thisRow["username"] = textBox1.Text;
                thisRow["password"] = textBox2.Text;
                thisDataSet.Tables["manager_info"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "manager_info");
                MessageBox.Show("Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 obback = new Form2();
            obback.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection sv = new connection();
                sv.thisConnection.Open();
                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM manager_info", sv.thisConnection);
                SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
                DataTable dtbl = new DataTable();
                thisAdapter.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                sv.thisConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you Sure ??\nPlease Click 'Yes' or 'No' and Press 'click' ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (x == 1)
            {
                fndelete();
            }
            else
            {
                MessageBox.Show("Delete Cancel");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            x = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            x = 2;
        }
    }
}
