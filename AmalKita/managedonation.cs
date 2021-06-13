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
    public partial class managedonation : Form
    {
        static string conString = "server=localhost;port=3306;username=root;password=;database=amalkita;";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();


        public managedonation()
        {
            InitializeComponent();
            //Data grid view properties
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
            string sql = "SELECT * FROM `donation`";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
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
        }
        //Insert
        private void add(string nama, string jenis , string harga , string target )
        {
            string sql = "INSERT INTO `donation`(`Nama Penerima`, `Jenis Item`, `Harga Per Item` , `Target`, `Kurang`) VALUES (@Nama,@Jenis,@Harga,@Target, @Kurang)";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.Add("@Nama", MySqlDbType.VarChar).Value = nama;
            cmd.Parameters.Add("@Jenis", MySqlDbType.VarChar).Value = jenis;
            cmd.Parameters.Add("@Harga", MySqlDbType.VarChar).Value = harga;
            cmd.Parameters.Add("@Target", MySqlDbType.VarChar).Value = target;
            cmd.Parameters.Add("@Kurang", MySqlDbType.VarChar).Value = target;
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Berhasil menambah data");
                }
                con.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        //Retrieve
        private void retrieve()
        {
            dgvDonation.Rows.Clear();
            string sql = "SELECT * FROM `donation`";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                foreach(DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString());
                }
                con.Close();
                dt.Rows.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //Add to dgv
        private void populate(string id, string nama, string jenis, string harga , string target, string kurang)
        {
            dgvDonation.Rows.Add(id, nama, jenis, harga , target, kurang);
        }

        //Update
        private void update(int id, string nama, string jenis, string harga , string target)
        {
            string sql = "UPDATE `donation` SET `Nama Penerima`='" + nama + "',`Jenis Item`='" + jenis + "',`Harga Per Item`='" + harga + "', `Target`='" + target + "', `Kurang`='" + target + "' WHERE `ID`=" + id + "";
            cmd = new MySqlCommand(sql, con);   
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Berhasil diperbarui");
                }
                con.Close();

                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void delete(int id)
        {
            string sql = "DELETE FROM `donation` WHERE ID=" + id + "";
            cmd = new MySqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                if(MessageBox.Show("Anda Yakin? ", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    if(cmd.ExecuteNonQuery()>0)
                    {
                        clearTxts();
                        MessageBox.Show("Berhasil Dihapus");
                    }
                }
                con.Close();
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        private void clearTxts()
        {
            tbNama.Text = "";
            tbJenis.Text = "";
            tbHarga.Text = "";
            tbTarget.Text = "";
        }

        private void dgvDonation_MouseClick(object sender, MouseEventArgs e)
        {
            tbNama.Text = dgvDonation.SelectedRows[0].Cells[1].Value.ToString();
            tbJenis.Text = dgvDonation.SelectedRows[0].Cells[2].Value.ToString();
            tbHarga.Text = dgvDonation.SelectedRows[0].Cells[3].Value.ToString();
            tbTarget.Text = dgvDonation.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checknama())
            {
                MessageBox.Show("Nama Penerima sudah ada");
            }
            else
            {
                add(tbNama.Text, tbJenis.Text, tbHarga.Text, tbTarget.Text);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selected = dgvDonation.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            update(id, tbNama.Text, tbJenis.Text, tbHarga.Text ,tbTarget.Text);  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selected = dgvDonation.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDonation.Rows.Clear();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
            bool isadmin = true;
            UserPage page = new UserPage(isadmin);
            page.Show();
        }

        private bool checknama()
        {
            DB db = new DB();
            String nama = tbNama.Text;
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `donation` WHERE `Nama Penerima` = @Nama ", db.GetConnection());

            command.Parameters.Add("@Nama", MySqlDbType.VarChar).Value = nama;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            //Mengecek bahwa user sudah ada dalam database atau belum
            if (table.Rows.Count > 0)
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
