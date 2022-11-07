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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM BookList", sv.thisConnection);
            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "BookList");
            DataRow thisRow = thisDataSet.Tables["BookList"].NewRow();
            try
            {

                thisRow["bookid"] = textBox6.Text;
                thisRow["bookname"] = textBox1.Text;
                thisRow["publishyear"] = textBox2.Text;
                thisRow["writtername"] = textBox3.Text;
                thisRow["qunatity"] = textBox4.Text;
                thisRow["categoryname"] = textBox5.Text;
                thisRow["entrydate"] = dateTimePicker1.Text;
                thisDataSet.Tables["BookList"].Rows.Add(thisRow);
                thisAdapter.Update(thisDataSet, "BookList");
                MessageBox.Show("Submitted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 m = new Form9();
            m.Show();
            this.Close();
        }
    }
}
