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
    public partial class LoginPage : Form
    {
        /*MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=amalkita;");*/
        public LoginPage()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.White;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Crimson;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string username = tbusername.Text;
            string password = tbpassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count>0)
            {
                MessageBox.Show("Login Berhasil");
                User user = new User(tbusername.Text, tbpassword.Text);
                UserPage usermenu = new UserPage(user.Username, user.Password);
                usermenu.Show();
                this.Hide();
            }
            else
            {
                if (checkadmin())
                {
                    MessageBox.Show("Admin login Berhasil");
                    Admin admin = new Admin(tbusername.Text, tbpassword.Text);
                    bool isadmin = true;
                    UserPage adminmenu = new UserPage(isadmin);
                    adminmenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau password salah");
                }
            }
        }
        public Boolean checkadmin()
        {
            DB db = new DB();
            string username = tbusername.Text;
            string password = tbpassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `admin` WHERE `username` = @usn and `password` = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm form = new RegisterForm();
            form.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
