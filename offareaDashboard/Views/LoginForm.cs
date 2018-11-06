using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using offareaDashboard.Helper;

namespace offareaDashboard.Views
{
    public partial class LoginForm : Form
    {
        ApiRoutes api;

        public LoginForm()
        {
            InitializeComponent();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async Task CheckifUserLoggedinAsync()
        {
            offareaDashboard.Models.Login login = await PostRequest(api.LoginRoute(), txtUsername.Text, txtPassword.Text);
            if (login != null)
            {
                DialogResult = DialogResult.OK;
                return;
            }
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
