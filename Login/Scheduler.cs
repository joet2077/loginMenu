using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Scheduler : Form
    {
        public Scheduler()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e) {
            Application.Exit();
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(OpenLoginForm));
            thread.Start();
        }

        public void OpenLoginForm() {
            Application.Run(new Form1()); 
        }

    }
}
