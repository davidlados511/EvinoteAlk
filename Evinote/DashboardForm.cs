using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evinote
{
    public partial class DashboardForm : Form
    {
        private HttpClient _client;

        public DashboardForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
            this.Load += DashboardForm_Load;
            Theme.Apply(this);

            Theme.StyleDeleteButton(DeleteBtn);

            Theme.StyleDataGrid(dataGridView1);
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            await LoadUsers();
        }

        private async System.Threading.Tasks.Task LoadUsers()
        {
            try
            {
                var response = await _client.GetAsync("http://localhost:5173/api/users");
<<<<<<< HEAD
                // táblák számához /api/boards betoltese, user.id == board.owner

                int tablakszama = 1; // szamolja meg irja ezt at
=======
>>>>>>> 4d6507c4a0d539618162f70e01a13d1c5ca41d1c

                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Hiba az API hívásnál");
                    return;
                }

                var users = JsonSerializer.Deserialize<List<UserDto>>(json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                dataGridView1.Rows.Clear();

                if (users == null)
                {
                    MessageBox.Show("Null a users lista");
                    return;
                }

                foreach (var user in users)
                {
                    var rowIndex = dataGridView1.Rows.Add(
<<<<<<< HEAD
                        user.id,
                        user.username,
                        user.email,
                        user.created_at.ToString("yyyy-MM-dd"),
                        user.updated_at.ToString("yyyy-MM-dd"),
                        $"{tablakszama} tabla"
                        
=======
                        user.username,
                        user.email,
                        user.created_at.ToString("yyyy-MM-dd"),
                        user.updated_at.ToString("yyyy-MM-dd")
>>>>>>> 4d6507c4a0d539618162f70e01a13d1c5ca41d1c
                    );
                    dataGridView1.Rows[rowIndex].Tag = user; // Store the UserDto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public async Task DeleteUser(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"http://localhost:5173/api/users/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Felhasználó törölve!");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Hiba: " + error + "\n" + "id: " + id);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

<<<<<<< HEAD
        //ha bele klikkelek a táblák száma nevű oszlopba nyissa meg a UserBoardFormot a kiválasztott user adataival


=======
>>>>>>> 4d6507c4a0d539618162f70e01a13d1c5ca41d1c
        private async void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Nincs kiválasztott felhasználó!");
                return;
            }

            var selectedUser = (UserDto)dataGridView1.CurrentRow.Tag;

                var confirm = MessageBox.Show(
                $"Biztosan törölni szeretnéd ezt a felhasználót?\n\n{selectedUser.username}",
                "Megerősítés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            await DeleteUser(selectedUser.id);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
<<<<<<< HEAD
            //ha a TableCountszáma nevű oszlopra kattintok akkor nyissa meg a UserBoardFormot
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // TableCount oszlop indexe
            {
                var dashboards = new UserBoards("user");
                dashboards.Show();
                Hide();
            }
=======
>>>>>>> 4d6507c4a0d539618162f70e01a13d1c5ca41d1c

        }
    }
}