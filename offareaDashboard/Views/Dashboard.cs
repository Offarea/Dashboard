﻿using Newtonsoft.Json;
using offareaDashboard.Models;
using offareaDashboard.Models.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offareaDashboard.Views
{
    public partial class Dashboard : Form
    {
        string fullname;
        string apiToken;
        public Dashboard(string fullname, string apiToken)
        {
            this.fullname = fullname;
            this.apiToken = apiToken;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.lblFullname.Text = fullname;
            this.lblApiToken.Text = apiToken;

           
        }

        private VendorFinancialInfo getAllVendors()
        {
            using (WebClient client = new WebClient())
            {
                string rawJSON = client.DownloadString(new Helper.ApiRoutes().AllVendors);
                //rawJSON = rawJSON.Replace("[", "").Replace("]", "");
                VendorFinancialInfo vendors = JsonConvert.DeserializeObject<VendorFinancialInfo>(rawJSON);
                return vendors;
            }
           
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            VendorFinancialInfo vendors = getAllVendors();
            MessageBox.Show("Test");

        }
    }
}
