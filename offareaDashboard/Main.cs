using System;
using System.Windows.Forms;
using offareaDashboard.Helper;
using offareaDashboard.Models;
using System.Net;
using Newtonsoft.Json;
using offareaDashboard.Models.Collections;
using System.Collections.Generic;

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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            getAllVendors();
            MessageBox.Show("Test");
        }

        private void getAllVendors()
        {
            using (WebClient client = new WebClient())
            {
                string rawJSON = client.DownloadString(new Helper.ApiRoutes().AllVendors);
                List<VendorFinancialInfo> vendors = JsonConvert.DeserializeObject<List<VendorFinancialInfo>>(rawJSON);
                gvVendorFinancialInfo.DataSource = vendors;
                gvVendorFinancialInfo.Refresh();
            }

        }
    }
}
