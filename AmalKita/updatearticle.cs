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
    public partial class updatearticle : Form
    {
        public updatearticle()
        {
            InitializeComponent();
        }
        string ID;
        public updatearticle(string articleid)
        {
            this.ID = articleid;
            InitializeComponent();
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT `Title`,`Content` FROM `article` WHERE `ID` = @ID", db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(articleid));
            MySqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                tbTitle.Text = dr.GetValue(0).ToString();
                tbContent.Text = dr.GetValue(1).ToString();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            pbArticle.Image = null;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter= "Choose Image( *.png;|*.png;)";
            if(opf.ShowDialog() == DialogResult.OK)
            {
                pbArticle.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MemoryStream ms = new MemoryStream();
            pbArticle.Image.Save(ms,pbArticle.Image.RawFormat);
            byte[] img = ms.ToArray();
            string insertQuery = "UPDATE `article` SET `Title`=@title,`Content`=@content,`Images`=@img WHERE `ID` = @ID";
            db.openConnection();
            MySqlCommand command = new MySqlCommand(insertQuery, db.GetConnection());
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(ID));
            command.Parameters.Add("@title", MySqlDbType.VarChar).Value = tbTitle.Text;
            command.Parameters.Add("@content", MySqlDbType.Text).Value = tbContent.Text;
            command.Parameters.Add("@img", MySqlDbType.Blob);
            command.Parameters["@img"].Value = img;
            if(command.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Article Updated!");
            }
            db.closeConnection();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bool isAdmin = true;
            UserPage page = new UserPage(isAdmin);
            this.Close();
            page.Show();
        }
    }
}
