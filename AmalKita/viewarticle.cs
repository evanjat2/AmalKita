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
    public partial class viewarticle : Form
    {
        public viewarticle()
        {
            InitializeComponent();
        }
        public viewarticle(string articleid)
        {
            InitializeComponent();
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT `Title`,`Content` FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(articleid));
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                lblTitle.Text = dr.GetValue(0).ToString();
                lblContent.Text = dr.GetValue(1).ToString();
            }
            db.closeConnection();

            db.openConnection();
            command = new MySqlCommand("SELECT * FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(articleid));
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            byte[] img = (byte[])table.Rows[0][3];
            MemoryStream ms = new MemoryStream(img);
            pbArticle.Image = Image.FromStream(ms);
            db.closeConnection();
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
