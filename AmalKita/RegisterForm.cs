using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AmalKita2
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage form = new LoginPage();
            form.Show();
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.White;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.Crimson;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label2;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`Nama`, `Email`, `username`, `password`) VALUES (@name , @email, @usn, @pass)", db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = tbNama.Text;
            command.Parameters.Add("@email", MySqlDbType.Text).Value = tbEmail.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = tbUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = tbPassword.Text;
            db.openConnection();
          
            if(checktb())
            {
                MessageBox.Show("Mohon isi semua data");
            }
            else
            {
                if (checkusn())
                {
                    MessageBox.Show("Username telah dipakai, mohon pakai username lain");
                }
                else
                {
                    if (checkpw())
                    {
                        MessageBox.Show("Periksa kembali password anda");
                    }
                    else
                    {
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Akun berhasil dibuat");
                            LoginPage form = new LoginPage();
                            this.Hide();
                            form.Show();
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                }
            }
            
        }

        public Boolean checkusn()
        {
            DB db = new DB();
            string username = tbUsername.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
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
        public Boolean checktb()
        {
            string name = tbNama.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            string username = tbUsername.Text;
            if(name.Trim().Equals("") || email.Trim().Equals("") || password.Trim().Equals("") || username.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkpw()
        {
            string pass = tbPassword.Text;
            string confirm = tbConfirm.Text;
            if(pass != confirm)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
