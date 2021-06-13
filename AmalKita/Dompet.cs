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
    public partial class Dompet : Form
    {
        private string Password;
        private string Username;
        private int Saldo;
        Donatur donatur;
        public Dompet()
        {
            InitializeComponent();
        }
        public Dompet(string username , string password)
        {
            InitializeComponent();

            DB db = new DB();
            int saldo = 0;
            MySqlCommand command = new MySqlCommand("SELECT `saldo` FROM `users` WHERE `username` = @usn and `password` = @pass", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            
            try
            {
                db.openConnection();
                saldo = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            this.Saldo = saldo;
            this.Username = username;
            this.Password = password;
            donatur = new Donatur(Username, Password, Saldo);
            lblWallet.Text = donatur.Saldo.ToString();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            UserPage page = new UserPage(this.Username, this.Password);
            this.Close();
            page.Show();
        }
        private void Topup(int total)
        {
            donatur.topup(total);
            lblWallet.Text = donatur.Saldo.ToString();
        }
        private void Tarik(int total)
        {
            donatur.tarik(total);
            lblWallet.Text = donatur.Saldo.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (donatur.PasswordTervalidasi(tbPassword.Text))
            {
                UserPage page;
                if (rbSetor.Checked)
                {
                    Topup(int.Parse(tbUang.Text));
                    page = new UserPage(Username, Password);
                    MessageBox.Show("Top Up Berhasil");
                    this.Close();
                    page.Show();
                }
                else if (rbTarik.Checked)
                {
                    Tarik(int.Parse(tbUang.Text));
                    page = new UserPage(Username, Password);
                    MessageBox.Show("Tarik Uang Berhasil");
                    this.Close();
                    page.Show();
                }
            }
            else
            {
                MessageBox.Show("Password Salah");
            }
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblWallet_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            donate donate = new donate(Password, Username, Saldo);
            this.Hide();
            donate.Show();
        }

        private void Dompet_Load(object sender, EventArgs e)
        {

        }
    }
}
