using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmalKita2
{
    class Donatur : User
    {

        private int _saldo;
        public int Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Saldo tidak boleh kurang dari 0");
                else _saldo = value;
            }
        }
        public Donatur(string username, string password, int saldo)
        {
            _saldo = saldo;
            this.Username = username;
            this.Password = password;
        }

        public void topup(int jumlah)
        {
            Saldo += jumlah;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `saldo`= @saldo WHERE `username`= @usn and `password` = @pass", db.GetConnection());
            command.Parameters.Add("@saldo", MySqlDbType.VarChar).Value = Saldo;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public void tarik(int jumlah)
        {
            Saldo -= jumlah;
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `saldo`= @saldo WHERE `username`= @usn and `password` = @pass", db.GetConnection());
            command.Parameters.Add("@saldo", MySqlDbType.VarChar).Value = Saldo;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = Username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;
            db.openConnection();
            command.ExecuteNonQuery();
        }
        public bool PasswordTervalidasi(string password)
        {
            if (this.Password == password)
                return true;
            else
                return false;
        }

    }
}
