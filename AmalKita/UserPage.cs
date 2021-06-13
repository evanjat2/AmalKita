using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmalKita2
{
    public partial class UserPage : Form
    {
        private string Password;
        public string Username;
        private bool admin;
        public UserPage()
        {
            InitializeComponent();
        }
        
        public UserPage(string nama,string password)
        {
            InitializeComponent();
            Password = password;
            Username = nama;
            lblUsername.Text = nama;
            lblPenjelasanadmin.Hide();
            btnManage.Hide();
        }

        public UserPage(bool isadmin)
        {
            InitializeComponent();
            this.admin = isadmin;
            btnDompet.Hide();
            lblUsername.Hide();
            label1.Hide();
            lblPenjelasanuser.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UserPage_Load(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMakedonation_Click(object sender, EventArgs e)
        {
            Dompet donate = new Dompet(this.Username, this.Password);
            this.Close();
            donate.Show();
        }

        private void pbArticle1_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                updatearticle update = new updatearticle("1");
                update.Show();
                this.Hide();
            }
            else
            {
                viewarticle view = new viewarticle("1");
                view.Show();
            }
        }

        private void UserPage_Shown(object sender, EventArgs e)
        {

            //Menampilkan Data Grid View
            dgvDonation.ColumnCount = 6;
            dgvDonation.Columns[0].Name = "ID";
            dgvDonation.Columns[1].Name = "Nama";
            dgvDonation.Columns[2].Name = "Jenis Sumbangan";
            dgvDonation.Columns[3].Name = "Harga Per Item";
            dgvDonation.Columns[4].Name = "Target";
            dgvDonation.Columns[5].Name = "Kurang";
            dgvDonation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Selection mode
            dgvDonation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonation.MultiSelect = false;
            dgvDonation.Rows.Clear();
            string conString = "server=localhost;port=3306;username=root;password=;database=amalkita;";
            MySqlConnection con = new MySqlConnection(conString);

            string sql = "SELECT * FROM `donation`";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {

                con.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }
                con.Close();
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }


            //Menampilkan Artikel

            DB db = new DB();
            string article1 = "1";
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(article1));
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            byte[] img = (byte[])table.Rows[0][3];
            MemoryStream ms = new MemoryStream(img);
            pbArticle1.Image = Image.FromStream(ms);
            db.closeConnection();


            string article2 = "2";
            db.openConnection();
            command = new MySqlCommand("SELECT * FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(article2));
            da = new MySqlDataAdapter(command);
            table = new DataTable();
            da.Fill(table);
            img = (byte[])table.Rows[0][3];
            ms = new MemoryStream(img);
            pbArticle2.Image = Image.FromStream(ms);
            db.closeConnection();

            string article3 = "3";
            db.openConnection();
            command = new MySqlCommand("SELECT * FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(article3));
            da = new MySqlDataAdapter(command);
            table = new DataTable();
            da.Fill(table);
            img = (byte[])table.Rows[0][3];
            ms = new MemoryStream(img);
            pbArticle3.Image = Image.FromStream(ms);
            db.closeConnection();

            string article4 = "4";
            db.openConnection();
            command = new MySqlCommand("SELECT * FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(article4));
            da = new MySqlDataAdapter(command);
            table = new DataTable();
            da.Fill(table);
            img = (byte[])table.Rows[0][3];
            ms = new MemoryStream(img);
            pbArticle4.Image = Image.FromStream(ms);
            db.closeConnection();
        }

        private void pbArticle2_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                updatearticle update = new updatearticle("2");
                update.Show();
                this.Hide();
            }
            else
            {
                viewarticle view = new viewarticle("2");
                view.Show();
            }
        }

        private void pbArticle3_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                updatearticle update = new updatearticle("3");
                update.Show();
                this.Hide();
            }
            else
            {
                viewarticle view = new viewarticle("3");
                view.Show();
            }
        }

        private void pbArticle4_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                updatearticle update = new updatearticle("4");
                update.Show();
                this.Hide();
            }
            else
            {
                viewarticle view = new viewarticle("4");
                view.Show();
            }
        }

        private void populate(string id, string nama, string jenis, string harga, string target, string kurang)
        {
            dgvDonation.Rows.Add(id, nama, jenis, harga, target, kurang);
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            managedonation manage = new managedonation();
            this.Hide();
            manage.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Donatedlist page = new Donatedlist();
            page.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
