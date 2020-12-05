﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                this.Close();
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Open_Scheduler));
                thread.Start();
            }
            else if(textBox1.Text == "user" && textBox2.Text == "user")
            {
                this.Close();
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Open_Attendee));
                thread.Start();
            }
            else
            {
                MessageBox.Show("Please enter correct username and password", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Open_Scheduler() {
            Application.Run(new Scheduler());
        }
        public void Open_Attendee() {
            Application.Run(new Attendee());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
