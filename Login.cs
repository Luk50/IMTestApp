using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BEL_DLL;
using BAL_DLL;

namespace IMTestApp
{
    public partial class Login : Form
    {
        public BEL info = new BEL();
        public BAL opr = new BAL();
        DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            info.UserName = textBoxUserName.Text;
            info.UserPassword = textBoxUserPass.Text;
            dt = opr.Login(info);
            if (dt.Rows.Count > 0)
                MessageBox.Show("You are successfully logged in!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Login failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
