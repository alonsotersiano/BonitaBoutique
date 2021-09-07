using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace BonitaBoutique
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            Populate();
        }
        readonly SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=BonitaBoutique;Integrated Security=True");
        private int selectedItemId = 0;
        private void Populate()
        {
            con.Open();
            string query = "SELECT * FROM CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            this.selectedItemId = 0;
            con.Close();
        }

        private void Reset()
        {
            CustNameTb.Text = "";
            CustEmailTb.Text = "";
            CustPhoneTb.Text = "";
            this.selectedItemId = 0;
            Populate();
        }

        private bool NameChecker(String field)
        {
            if (field == "")
            {
                MessageBox.Show("You must fill out the customer name");
                return false;
            }
            else
            {
                Regex rgx = new Regex("^[A-Za-z ]+$");
                return rgx.IsMatch(field);
            }
        }
        private bool EmailChecker(String field)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(field);
                return addr.Address == field;
            }
            catch
            {
                return false;
            }
        }
        private bool PhoneChecker(String field)
        {
            Regex rgx = new Regex("^[0-9]+$");
            return rgx.IsMatch(field) && field.Length >= 7 && field.Length <= 13;
        }

        private bool FieldsChecker(TextBox name, TextBox email, TextBox phone)
        {
            if (name.Text == "")
            {
                MessageBox.Show("You must fill out the customer name");
                return false;
            }
            else if (!NameChecker(name.Text))
            {
                MessageBox.Show("Name field can only have letters.");
                return false;
            }
            else if (email.Text != null && email.Text != "" && !EmailChecker(email.Text))
            {
                MessageBox.Show("Email field is incorrect.");
                return false;
            }
            else if (phone.Text != null && phone.Text != "" && !PhoneChecker(phone.Text))
            {
                MessageBox.Show("Phone field can only have numbers and it must have less than 13 digits");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Search()
        {
            con.Open();
            List<string> varQuery = new List<string>();

            if (CustNameTb.Text != "")
            {
                varQuery.Add("Name LIKE '%" + CustNameTb.Text + "%'");
            }
            if (CustEmailTb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Email LIKE '%" + CustEmailTb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Email LIKE '%" + CustEmailTb.Text + "%'");
                }
            }
            if (CustPhoneTb.Text != "")
            {
                if (varQuery.Count < 1)
                {
                    varQuery.Add("Phone LIKE '%" + CustPhoneTb.Text + "%'");
                }
                else
                {
                    varQuery.Add(" AND Phone LIKE '%" + CustPhoneTb.Text + "%'");
                }
            }
            string query = "SELECT * FROM CustomerTbl;";
            if (varQuery.Count > 0)
            {
                query = "SELECT * FROM CustomerTbl WHERE ";

                for (int i = 0; i < varQuery.Count; i++)
                {
                    query += varQuery[i];
                }
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            con.Close();
            varQuery.Clear();
        }

            private void CustSaveBtn_Click(object sender, EventArgs e)
        {
            if (FieldsChecker(CustNameTb, CustEmailTb, CustPhoneTb))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO CustomerTbl values ('"
                        + CustNameTb.Text + "','"
                        + CustEmailTb.Text + "','"
                        + CustPhoneTb.Text + "');";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Populate();
                    MessageBox.Show("Customer was saved successfully!");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }
        }

        private void CustUpdateBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId > 0)
            {
                if (FieldsChecker(CustNameTb, CustEmailTb, CustPhoneTb))
                {
                    DialogResult = MessageBox.Show("Are you sure you want to update this Customer?", "Update Confirmation", MessageBoxButtons.YesNo);
                    if (DialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            string query = "UPDATE CustomerTbl SET Name='" + CustNameTb.Text + "', Phone='" + CustPhoneTb.Text + "', Email='" + CustEmailTb.Text + "' WHERE Id=" + this.selectedItemId + ";";
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

        private void CustDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId > 0)
            {
                DialogResult = MessageBox.Show("Are you sure you want to delete this Customer?", "Delete Confirmation", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM CustomerTbl WHERE Id=" + this.selectedItemId + ";";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Reset();
                        Populate();
                        MessageBox.Show("Customer deleted succesfully");
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
                MessageBox.Show("Please select a customer to be deleted");
            }
        }

        private void CustResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Items obj = new Items();
            obj.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Billing obj = new Billing();
            obj.Show();
            this.Hide();
        }

        private void CustLogoutBtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void CustomerDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = CustomerDGV.Rows[e.RowIndex];
                this.selectedItemId = int.Parse(row.Cells[0].Value.ToString());

                CustNameTb.Text = row.Cells[1].Value.ToString();
                CustEmailTb.Text = row.Cells[2].Value.ToString();
                CustPhoneTb.Text = row.Cells[3].Value.ToString();
            }
        }

        private void ResearchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ExportCustomersBtn_Click(object sender, EventArgs e)
        {

            if (CustomerDGV.Rows.Count > 0)
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
                            int columnCount = CustomerDGV.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[CustomerDGV.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += CustomerDGV.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < CustomerDGV.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCsv[i] += CustomerDGV.Rows[i - 1].Cells[j].Value.ToString() + ",";
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
