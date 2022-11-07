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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            connection sv = new connection();
            sv.thisConnection.Open();
            

            SqlDataAdapter thisAdapter = new SqlDataAdapter(" SELECT * FROM BookList WHERE bookid='" + textBox1.Text + "' ", sv.thisConnection);

            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

            DataTable dtbl = new DataTable();
            thisAdapter.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            
            sv.thisConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            connection sv = new connection();
            sv.thisConnection.Open();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BookList", sv.thisConnection);

            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

            DataTable dtbl = new DataTable();
            thisAdapter.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            sv.thisConnection.Close();


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

        private void button5_Click(object sender, EventArgs e)
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
                MessageBox.Show("Not Found");
            }
            sv.thisConnection.Close();
        }
    }
}
