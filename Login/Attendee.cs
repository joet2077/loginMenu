using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Attendee : Form {

        private string username;
        private Dictionary<string, int> users = new Dictionary<string, int> { {"adam", 0 }, {"nathan", 1 }, { "joe", 2 }, { "niche", 3 }, { "john", 4 }, { "bob", 5 }, { "emran", 6 }, { "alex", 7 }, { "savina", 8 }, { "marcus", 9 }, { "morningstar", 10 } };
        private Dictionary<string, int> days = new Dictionary<string, int> { {"Monday", 0 }, { "Tuesday", 1 },{ "Wednesday", 2 },{ "Thursday", 3 },{ "Friday", 4 } };
        private Dictionary<string, int> time = new Dictionary<string, int> { {"9-10 am", 0 }, {"10-11 am", 1 }, {"11-12 am", 2 }, { "12-1 pm", 3 }, { "1-2 pm", 4 }, { "2-3 pm", 5 }, { "3-4 pm", 6 }, { "4-5 pm", 7 }, { "5-6 pm", 8 } };

        public Attendee(string username) {
            InitializeComponent();
            this.username = username.ToLower();
            
        }

        private void Logout_Click(object sender, EventArgs e) {
            Application.Exit();
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenLoginForm));
            thread.Start();
        }

        public void OpenLoginForm() {
            Application.Run(new Form1());
        }

        private void button2_Click(object sender, EventArgs e) {
            dynamic array;
            using (StreamReader r = new StreamReader("people.json")) {
                string json = r.ReadToEnd();
                array = JsonConvert.DeserializeObject(json);
                if (comboBox2.Text != "Please Select a Date") {
                    JArray data = array["data"][users[username]][this.username][days[comboBox2.Text]];
                    if (comboBox1.Text != "Please Select a Time") {
                        data[time[comboBox1.Text]] = 1;
                    }
                }
            }
            using (StreamWriter file = new StreamWriter("people.json")) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, array);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            dynamic array;
            using (StreamReader r = new StreamReader("people.json")) {
                string json = r.ReadToEnd();
                array = JsonConvert.DeserializeObject(json);
                if (comboBox2.Text != "Please Select a Date") {
                    JArray data = array["data"][users[username]][this.username][days[comboBox2.Text]];
                    if (comboBox1.Text != "Please Select a Time") {
                        data[time[comboBox1.Text]] = 0;
                    }
                }
            }
            using (StreamWriter file = new StreamWriter("people.json")) {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, array);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            using (StreamReader r = new StreamReader("people.json")) {
                string json = r.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json);
                var data = JsonConvert.SerializeObject(array["data"][users[username]][this.username][days[comboBox3.Text]]);
                if (comboBox3.Text != "Please Select a Date") {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(data);
                } else {
                    label6.Text = "Please select a date";
                }
            }
           
        }

        
    }

}

