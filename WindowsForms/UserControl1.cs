using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System.Diagnostics;

namespace WindowsForms
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (fname.Text == ""|| lname.Text == "" || mobile.Text == "" || email.Text == "" )
            {
                // display popup box  
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fname.Focus(); // set focus to lastNameTextBox  
                return;
            }
            if (!Regex.Match(fname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                // first name was incorrect  
                MessageBox.Show("Invalid first name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fname.Focus();
                return;
            }
            if (!Regex.Match(lname.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                // first name was incorrect  
                MessageBox.Show("Invalid Last Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mname.Focus();
                return;
            }
            if (!Regex.Match(mobile.Text, @"^[0-9]{10}$").Success)
            {
                // phone number was incorrect  
                MessageBox.Show("Invalid phone number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mobile.Focus();
                return;
            }
            if (!Regex.Match(email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                // phone number was incorrect  
                MessageBox.Show("Invalid Email Id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                email.Focus();
                return;
            }
            string value = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                value = radioButton1.Text;
            else
                value = radioButton1.Text;

            bool isChecked1 = radioButton2.Checked;
            if (isChecked1)
                value = radioButton2.Text;
            else
                value = radioButton2.Text;

            bool isChecked2 = radioButton3.Checked;
            if (isChecked2)
                value = radioButton3.Text;
            else
                value = radioButton3.Text;

            
            bool isChecked3 = radioButton4.Checked;
            if (isChecked3)
                value = radioButton4.Text;
            else
                value = radioButton4.Text;

            bool isChecked4 = radioButton5.Checked;
            if (isChecked4)
                value = radioButton5.Text;
            else
                value = radioButton5.Text;


            //Database Mysql
            string constring="datasource=localhost;port=3306;username=root;password= ";
            string query = "insert into info.customer1(fname,mname,lname,mobile,email,gender,dob, address1,address2,address3,flag1) values ('"+this.fname.Text+ "','" + this.mname.Text + "','" + this.lname.Text + "','" + this.mobile.Text + "','" + this.email.Text + "','" + this.gender  + "','" + this.dob.Text + "','" + this.address1.Text + "','" + this.address2.Text + "','" + this.address3.Text + "','" + this.flag1.Text + "')";
            MySqlConnection conn = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Data Saved");
                while (myReader.Read())
                {

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }
        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start(@"C:\Users\Neer\Desktop\DotNet\TnC_Files\DummyTerms.txt");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                button1.Enabled = true;
            }
            if (checkBox3.Checked == false)
            {
                button1.Enabled = false;
            }
        }

        private void gender_Enter(object sender, EventArgs e) 
        {
            
        }

        private void flag1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fname.Text = string.Empty;

            mname.Text = string.Empty;

            lname.Text = string.Empty;
            mobile.Text = string.Empty;
            email.Text = string.Empty;
            radioButton1.Checked=false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            dob.Text = string.Empty;
            address1.Text = string.Empty;
            address2.Text = string.Empty;
            address3.Text = string.Empty;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            checkBox1.Checked = false;
            checkBox3.Checked = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                this.Activate();
            }
        }

        private void Activate()
        {
            throw new NotImplementedException();
        }
    }
}
