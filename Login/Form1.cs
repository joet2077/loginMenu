using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Net.Security;
using System.Security.Permissions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

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

        private async void button2_ClickAsync(object sender, EventArgs e)
        {

            var user = new Dictionary<string, string>() { };
            user.Add("username", textBox1.Text);
            user.Add("password", textBox2.Text);

            HttpClient client = new HttpClient();
            var stringContent = new FormUrlEncodedContent(user);
            var response = await client.PostAsync("https://www.mightylordx.eu/api/v1/meeting/login", stringContent);
            var responseString = await response.Content.ReadAsStringAsync();

            var logged_in = (bool)JObject.Parse(responseString)["logged_in"];
            if (logged_in == true) {
                var admin = (bool)JObject.Parse(responseString)["role"];

                if (admin is true) {
                    this.Close();
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Open_Scheduler));
                    thread.Start();
                } else {
                    this.Close();
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(Open_Attendee));
                    thread.Start();
                }

            } else {
                error_label.Text = "Sorry that is not a valid username / password";
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
