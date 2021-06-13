using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmalKita2
{
    public partial class Donatedlist : Form
    {
        private string Username;
        private string Password;
        public Donatedlist()
        {
            InitializeComponent();
            dgvDonation.ColumnCount = 4;
            dgvDonation.Columns[0].Name = "ID";
            dgvDonation.Columns[1].Name = "Penyumbang";
            dgvDonation.Columns[2].Name = "Jumlah Donasi";
            dgvDonation.Columns[3].Name = "Tujuan Donasi";
            dgvDonation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Selection mode
            dgvDonation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonation.MultiSelect = false;

            dgvDonation.Rows.Clear();
            string conString = "server=localhost;port=3306;username=root;password=;database=amalkita;";
            MySqlConnection con = new MySqlConnection(conString);

            string sql = "SELECT * FROM `donated`";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {

                con.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
                }
                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        

        private void populate(string id, string nama, string amount, string destinasi)
        {
            dgvDonation.Rows.Add(id, nama, amount, destinasi);
        }

        private void dgvDonation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
