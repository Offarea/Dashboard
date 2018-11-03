using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using offareaDashboard.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using offareaDashboard.Models.Collections;
using System.Net.Http.Headers;
using offareaDashboard.Helper;
using System.Threading.Tasks;

namespace offareaDashboard
{
    public partial class Login : Form
    {
        ApiRoutes api;
        public Login()
        {
            InitializeComponent();
            api = new ApiRoutes();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {          
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("You must enter valid data!");
            }
            else
            {                
                CheckifUserLoggedinAsync();
               
            }
        }

        private async Task CheckifUserLoggedinAsync()
        {
            offareaDashboard.Models.Login login = await PostRequest(api.LoginRoute(), txtUsername.Text, txtPassword.Text);
            if(login != null)
            {
                Views.Dashboard dashboard = new Views.Dashboard(login.Result.User.Name, login.Result.User.ApiToken);
                dashboard.ShowDialog();
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public async Task<offareaDashboard.Models.Login> PostRequest(string url, string username, string password)
        {          
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };
            HttpContent q = new FormUrlEncodedContent(queries);
            using (HttpClient client = new HttpClient())
            {                
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                using (HttpResponseMessage response = await client.PostAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {                 
                        string data = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        data = data.Replace("]", "").Replace("[", "");
                        offareaDashboard.Models.Login login = JsonConvert.DeserializeObject<offareaDashboard.Models.Login>(data);
                        return login;
                    }
                }

            }
        }       
    }
}
