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
    public partial class donate : Form
    {
        private string Username;
        private string Password;
        private int totalharga;
        private int Saldo;
        private int Kekurangan;
        static string conString = "server=localhost;port=3306;username=root;password=;database=amalkita;";
        MySqlConnection con = new MySqlConnection(conString);
        public donate()
        {
            InitializeComponent();
        }
        
        public donate(string password, string username , int saldo)
        {
            InitializeComponent();
            this.Username = username;
            this.Password = password;
            this.Saldo = saldo;
        }

        private void tbTujuan_TextChanged(object sender, EventArgs e)
        {
            DB db = new DB();
            string sqlquery = "SELECT `Nama Penerima` FROM `donation`";
            MySqlCommand command = new MySqlCommand(sqlquery, db.GetConnection());
            db.openConnection();
            MySqlDataReader datareader = command.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (datareader.Read())
            {
                autotext.Add(datareader.GetString(0));
            }
            tbTujuan.AutoCompleteCustomSource = autotext;
            db.closeConnection();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserPage page = new UserPage(Username, Password);
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            int item = 0;
            int harga = 0;
            MySqlCommand command = new MySqlCommand("SELECT `Harga Per Item` FROM `donation` WHERE `Nama Penerima` = @nama", db.GetConnection());
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = tbTujuan.Text;
            try
            {
                db.openConnection();
                harga = (int)command.ExecuteScalar();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            item = Convert.ToInt32(tbJumlah.Text);

            totalharga = item * harga;
            
            string showtotalharga = Convert.ToString(totalharga);

            //Menghitung kekurangan penerima donasi

            int kekurangan = 0;
            command = new MySqlCommand("SELECT `Kurang` FROM `donation` WHERE `Nama Penerima` = @nama", db.GetConnection());
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = tbTujuan.Text;
            try
            {
                db.openConnection();
                kekurangan = (int)command.ExecuteScalar();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            hitungkekurangan(kekurangan, item);
            string showKekurangan = Convert.ToString(Kekurangan);

            //Eksekusi

            if (!checkmoney())
            {
                if (MessageBox.Show("Apakah anda yakin ingin donasi sebesar " + showtotalharga + " ?", "Yakin", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    updatekekurangan();
                }
            }
            else
            {
                MessageBox.Show("Saldo pada DompetKita tidak cukup");
            }
        }




        private void hitungkekurangan(int kurang, int item)
        {
            kurang = kurang - item;
            if(kurang < 0)
            {
                kurang = 0;
            }
            this.Kekurangan = kurang;
        }

        private void updatekekurangan()
        {
            string sql = "UPDATE `donation` SET `Kurang` = @kurang WHERE `Nama Penerima` = @nama";
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = tbTujuan.Text;
            command.Parameters.Add("@kurang", MySqlDbType.Int32).Value = Kekurangan;
            con.Open();
            if(command.ExecuteNonQuery() > 0)
            {
                updatesaldo();
            }
            con.Close();
        }

        private void updatesaldo()
        {
            Saldo = Saldo - totalharga;
            string sql = "UPDATE `users` SET `saldo` = @sisa WHERE `username` = @nama";
            MySqlCommand command = new MySqlCommand(sql, con);
            command.Parameters.Add("@nama", MySqlDbType.VarChar).Value = Username;
            command.Parameters.Add("@sisa", MySqlDbType.Int32).Value = Saldo;
            
            if (command.ExecuteNonQuery() > 0)
            {
                updatedonatedlist();
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        private void updatedonatedlist()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `donated`(`username`, `amount`, `destination`) VALUES ( @usn, @amount, @dest)", db.GetConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Username;
            command.Parameters.Add("@amount", MySqlDbType.Int32).Value = totalharga;
            command.Parameters.Add("@dest", MySqlDbType.VarChar).Value = tbTujuan.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Berhasil melakukan donasi");
                UserPage page = new UserPage(Username, Password);
                page.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        //Mengecek apakah jumlah uang pada wallet cukup
        private bool checkmoney()
        { 
            if (totalharga > Saldo)
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
