using System;
using System.Windows.Forms;
using offareaDashboard.Helper;

namespace offareaDashboard
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var flag = InitiateLogin();
            if (!flag)
                Application.Exit();
            else
                this.Show();
        }

        private bool InitiateLogin()
        {
            this.Hide();
            Views.LoginForm login = new Views.LoginForm();
            DialogResult dialogResult = login.ShowDialog();
            if (dialogResult == DialogResult.OK)
                return true;
            else
                return false;
        }
    }
}
