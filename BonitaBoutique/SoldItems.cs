using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace BonitaBoutique
{
    public partial class SoldItems : Form
    {
        public SoldItems()
        {
            InitializeComponent();
            Populate();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=BonitaBoutique;Integrated Security=True");

        private void Populate()
        {
            con.Open();
            string query = "SELECT * FROM BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            sda.Fill(ds);
            SoldDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Customers obj = new Customers();
            obj.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void ItLogoutBtn_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ExportCSVBtn_Click(object sender, EventArgs e)
        {
            if (SoldDGV.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = SoldDGV.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[SoldDGV.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += SoldDGV.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < SoldDGV.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += SoldDGV.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No bills to export!", "Info");
            }
        }
    }
}

