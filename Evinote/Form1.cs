using Isopoh.Cryptography.Argon2;
using Konscious.Security.Cryptography;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace Evinote
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {

            InitializeComponent();
            PassInput.UseSystemPasswordChar = true;
            Theme.Apply(this);

            Theme.StyleTextBox(UserInput);
            Theme.StyleTextBox(PassInput);

            Theme.StyleDeleteButton(LoginBtn);
        }


        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            var username = UserInput.Text;
            var password = PassInput.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!");
                return;
            }

            var loginData = new LoginRequest(username, password);

            var json = JsonSerializer.Serialize(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://localhost:5173/api/auth/login", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Sikeres bejelentkezés!");

                    DashboardForm dashboard = new DashboardForm(client);

                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hiba: " + responseBody);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}