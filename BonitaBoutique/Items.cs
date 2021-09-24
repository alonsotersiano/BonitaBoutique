using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BonitaBoutique
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Populate();
        }

        readonly SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=BonitaBoutique;Integrated Security=True");
        private int selectedItemId = 0;

        private void Populate()
        {
            con.Open();
            string query = "SELECT * FROM ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemDGV.DataSource = ds.Tables[0];
            this.selectedItemId = 0;
            con.Close();
        }

        private bool PriceChecker(String field)
        {
            Regex rgx = new Regex("^[0-9.]+$");
            return rgx.IsMatch(field);
        }
        private bool QtyChecker(String field)
        {
            Regex rgx = new Regex("^[0-9]+$");
            return rgx.IsMatch(field);
        }
        private bool BarcodeChecker(String field)
        {
            Regex rgx = new Regex("^[A-Za-z0-9]+$");
            return rgx.IsMatch(field);
        }

        private bool FieldsChecker(TextBox name, ComboBox cat, ComboBox type, TextBox price, TextBox qty, TextBox barcode)
        {
            if (name.Text == "" || cat.SelectedIndex == -1 || type.SelectedIndex == -1 || price.Text == "" || qty.Text == "" || barcode.Text == "")
            {
                MessageBox.Show("You must fill out all the fields");
                return false;
            }
            else if (!PriceChecker(price.Text))
            {
                MessageBox.Show("Price field can only have numbers. Please use dot '.' for decimal numbers.");
                return false;
            }
            else if (!QtyChecker(qty.Text) || qty.Text.Contains("."))
            {
                MessageBox.Show("Qty field can only have numbers.");
                return false;
            }
            else if (!BarcodeChecker(barcode.Text))
            {
                MessageBox.Show("Barcode field can only have letters or numbers");
                return false;
            }
            else
            {
                return true;
            }

        }
        private void Reset()
        {
            ItName.Text = "";
            CatCb.SelectedIndex = -1;
            TypeCb.SelectedIndex = -1;
            PriceTb.Text = "";
            QtyTb.Text = "";
            BarcodeTb.Text = "";
            this.selectedItemId = 0;
            Populate();
        }

        private void Search()
        {
            con.Open();
            List<string> varQuery = new List<string>();

            if (ItName.Text != "")
            {
                varQuery.Add("Name LIKE '%" + ItName.Text + "%'");
            }
            if (CatCb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Category LIKE '%" + CatCb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Category LIKE '%" + CatCb.Text + "%'");
                }
            }
            if (TypeCb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Type LIKE '%" + TypeCb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Type LIKE '%" + TypeCb.Text + "%'");
                }
            }
            if (PriceTb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Price LIKE '%" + PriceTb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Price LIKE '%" + PriceTb.Text + "%'");
                }
            }
            if (QtyTb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Quantity LIKE '%" + QtyTb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Quantity LIKE '%" + QtyTb.Text + "%'");
                }
            }
            if (BarcodeTb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Barcode LIKE '%" + BarcodeTb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Barcode LIKE '%" + BarcodeTb.Text + "%'");
                }
            }

            string query = "SELECT * FROM ItemTbl;";
            if (varQuery.Count > 0)
            {
                query = "SELECT * FROM ItemTbl WHERE ";

                for (int i = 0; i < varQuery.Count; i++)
                {
                    query += varQuery[i];
                }
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemDGV.DataSource = ds.Tables[0];
            con.Close();
            varQuery.Clear();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FieldsChecker(ItName, CatCb, TypeCb, PriceTb, QtyTb, BarcodeTb))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO ItemTbl values ('"
                        + ItName.Text + "','"
                        + CatCb.Text + "','"
                        + TypeCb.Text + "','"
                        + PriceTb.Text + "','"
                        + QtyTb.Text + "','"
                        + BarcodeTb.Text.ToString() + "');";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Populate();
                    MessageBox.Show("Item was saved successfully!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId > 0)
            {
                if (FieldsChecker(ItName, CatCb, TypeCb, PriceTb, QtyTb, BarcodeTb))
                {
                    DialogResult = MessageBox.Show("Are you sure you want to update this item?", "Update Confirmation", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            string query = "UPDATE ItemTbl SET Name='" + ItName.Text + "', Category='" + CatCb.Text + "', Type='" + TypeCb.Text + "', Price='" + PriceTb.Text + "', Quantity='" + QtyTb.Text + "', Barcode='" + BarcodeTb.Text + "' WHERE Id=" + this.selectedItemId + ";";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Reset();
                            Populate();
                            MessageBox.Show("Item was updated successfully!");
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message);
                            con.Close();
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select an item to be updated");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId > 0)
            {
                DialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM ItemTbl WHERE Id=" + this.selectedItemId + ";";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Reset();
                        Populate();
                        MessageBox.Show("Item deleted succesfully");
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        con.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select an item to be deleted");
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ItLogoutBtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void ItemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ItemDGV.Rows[e.RowIndex];
                this.selectedItemId = int.Parse(row.Cells[0].Value.ToString());

                ItName.Text = row.Cells[1].Value.ToString();
                CatCb.SelectedItem = row.Cells[2].Value.ToString();
                TypeCb.SelectedItem = row.Cells[3].Value.ToString();
                PriceTb.Text = row.Cells[4].Value.ToString();
                QtyTb.Text = row.Cells[5].Value.ToString();
                BarcodeTb.Text = row.Cells[6].Value.ToString();
            }
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

        private void ExportProductsBtn_Click(object sender, EventArgs e)
        {
            if (ItemDGV.Rows.Count > 0)
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
                            int columnCount = ItemDGV.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[ItemDGV.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += ItemDGV.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < ItemDGV.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += ItemDGV.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
                MessageBox.Show("No products to export!", "Info");
            }
        }
    }
}
