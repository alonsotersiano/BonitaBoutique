using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BonitaBoutique
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            Populate();
        }
        readonly SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=BonitaBoutique;Integrated Security=True");
        private int selectedItemId;
        private int selectedBillLine = -1;
        private int stock = 0, n = 0;
        private double GrdTotal = 0.00;
        private double total = 0.00;
        private String price;
        private String prodBarcode;
        private int prodId;
        private int CustId;
        private int stockBillingQty = 0;
        private int stockItemQty = 0;

        private void Populate()
        {
            con.Open();
            string queryItem = "SELECT * FROM ItemTbl";
            SqlDataAdapter sdaItem = new SqlDataAdapter(queryItem, con);
            var dsItem = new DataSet();
            sdaItem.Fill(dsItem);
            ItemDGV.DataSource = dsItem.Tables[0];

            string queryCust = "SELECT * FROM CustomerTbl";
            SqlDataAdapter sdaCust = new SqlDataAdapter(queryCust, con);
            var dsCust = new DataSet();
            sdaCust.Fill(dsCust);
            CustDGV.DataSource = dsCust.Tables[0];

            BillDGV.ColumnCount = 9;
            BillDGV.Columns[0].Name = "Id";
            BillDGV.Columns[1].Name = "Cust Id";
            BillDGV.Columns[2].Name = "Cust Name";
            BillDGV.Columns[3].Name = "Prod Id";
            BillDGV.Columns[4].Name = "Prod Name";
            BillDGV.Columns[5].Name = "Prod Barcode";
            BillDGV.Columns[6].Name = "Price";
            BillDGV.Columns[7].Name = "Qty";
            BillDGV.Columns[8].Name = "Total";
            totalPrice.Text = "Total $CAD " + GrdTotal;

            this.selectedItemId = 0;
            con.Close();
        }

        private void Reset()
        {
            this.selectedItemId = 0;
            ProdNameTb.Text = "";
            CustNameTb.Text = "";
            PriceTb.Text = "";
            QtyTb.Text = "";
            price = "";
            stock = 0;
        }

        private void ResetBill()
        {
            BillDGV.Rows.Clear();
            totalPrice.Text = "Total $CAD ";
        }

        private void Search(TextBox search, String typeOfSearch)
        {
            String query;
            con.Open();
            if (typeOfSearch == "ClientName")
            {
                query = "SELECT * FROM CustomerTbl;";
                if (search.ToString().Length > 0)
                {
                    query = "SELECT * FROM CustomerTbl WHERE Name LIKE '%" + search.Text + "%';";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    CustDGV.DataSource = ds.Tables[0];
                }else 
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    CustDGV.DataSource = ds.Tables[0];
                }
            }
            else if (typeOfSearch == "ProductBarcode")
            {
                query = "SELECT * FROM ItemTbl;";
                if (search.ToString().Length > 0)
                {
                    query = "SELECT * FROM ItemTbl WHERE Barcode LIKE '%" + search.Text + "%';";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    ItemDGV.DataSource = ds.Tables[0];
                }
                else 
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    var ds = new DataSet();
                    sda.Fill(ds);
                    ItemDGV.DataSource = ds.Tables[0];
                }
            }
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

        private void AddToBillBtn_Click(object sender, EventArgs e)
        {
            this.stock = Convert.ToInt32(ItemDGV.SelectedRows[0].Cells[5].Value.ToString());

            if (QtyTb.Text == "" || CustNameTb.Text == "" || ProdNameTb.Text == "")
            {
                MessageBox.Show("Please select a customer, a product and type a quantity to be billed");
            }
            else
            {
                try 
                {
                    if (Convert.ToInt32(QtyTb.Text) > stock)
                    {
                        MessageBox.Show("No available stock");

                    }
                    else if (Convert.ToInt32(QtyTb.Text) <= 0)
                    {
                        MessageBox.Show("Quantity must be higher than 0");
                    }
                    else
                    {
                        this.total = Convert.ToDouble(QtyTb.Text) * Convert.ToDouble(price);
                        DataGridViewRow newRow = new DataGridViewRow();

                        newRow.CreateCells(BillDGV);
                        newRow.Cells[0].Value = n + 1;
                        newRow.Cells[1].Value = CustId.ToString();
                        newRow.Cells[2].Value = CustNameTb.Text;
                        newRow.Cells[3].Value = prodId.ToString();
                        newRow.Cells[4].Value = ProdNameTb.Text;
                        newRow.Cells[5].Value = prodBarcode;
                        newRow.Cells[6].Value = price;
                        newRow.Cells[7].Value = QtyTb.Text;
                        newRow.Cells[8].Value = total;
                        BillDGV.Rows.Add(newRow);

                        n++;
                        GrdTotal += total;
                        totalPrice.Text = "Total $CAD " + GrdTotal;
                        PriceTb.Text = "";
                        ProdNameTb.Text = "";
                        CustNameTb.Text = "";
                        QtyTb.Text = "";
                        SearchClient.Text = "";
                        SearchProduct.Text = "";
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }
        }
        private bool StockChecker() 
        {
            DialogResult = MessageBox.Show("Are you sure you want to finish this bill? The billing process cannot be reversed", "Bill Confirmation", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                List<int> checkedIds = new List<int>();
                foreach (DataGridViewRow rows in BillDGV.Rows)
                {
                    prodId = Convert.ToInt32(rows.Cells[3].Value);
                    if (!checkedIds.Contains(prodId))
                    {
                        con.Open();
                        string queryItem = "SELECT * FROM ItemTbl WHERE Id=" + prodId + ";";
                        SqlDataAdapter sdaItem = new SqlDataAdapter(queryItem, con);
                        con.Close();
                        var dsItem = new DataSet();
                        sdaItem.Fill(dsItem);
                        stockItemQty = Convert.ToInt32(dsItem.Tables[0].Rows[0][5]);
                        this.stockBillingQty = 0;
                        foreach (DataGridViewRow rowsChecking in BillDGV.Rows)
                        {
                            if (prodId == Convert.ToInt32(rowsChecking.Cells[3].Value))
                            {
                                this.stockBillingQty += Convert.ToInt32(rowsChecking.Cells[7].Value);
                            }
                        }
                        if (this.stockBillingQty > this.stockItemQty)
                        {
                            MessageBox.Show("No available stock for product " + rows.Cells[4].Value + " as the quantity being billed is " + this.stockBillingQty + " and the quantity in stock is " + this.stockItemQty);
                            return false;
                        }         
                        checkedIds.Add(prodId);                    
                    }
                }
            }
            return true;
        }
        private void BillingPost() 
        {

            foreach (DataGridViewRow rows in BillDGV.Rows)
            {
                try
                {
                    con.Open();
                    prodId = Convert.ToInt32(rows.Cells[3].Value);
                    string queryItem = "SELECT * FROM ItemTbl WHERE Id=" + prodId + ";";
                    SqlDataAdapter sdaItem = new SqlDataAdapter(queryItem, con);
                    var dsItem = new DataSet();
                    sdaItem.Fill(dsItem);
                    stockItemQty = Convert.ToInt32(dsItem.Tables[0].Rows[0][5]);
                    this.stockBillingQty = Convert.ToInt32(rows.Cells[7].Value);
                    string query = "INSERT INTO BillTbl values (" + rows.Cells[1].Value + ", '" + rows.Cells[2].Value + "', " + rows.Cells[3].Value + ", '" + rows.Cells[4].Value + "', '" + rows.Cells[5].Value + "', " + this.stockBillingQty + ", " + rows.Cells[8].Value + ", GETDATE());";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "UPDATE ItemTbl SET Quantity=" + (stockItemQty - stockBillingQty) + " WHERE Id=" + rows.Cells[3].Value + ";";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }
            MessageBox.Show("Billing has been finished successfully!");
            Populate();
            ResetBill();
        }
        private void BillBtn_Click(object sender, EventArgs e)
        {
            if (StockChecker()) 
            {
                BillingPost();
            }
        }

        private void BillingLogoutBtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void CustDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = CustDGV.Rows[e.RowIndex];
                CustNameTb.Text = row.Cells[1].Value.ToString();
                CustId = Convert.ToInt32(row.Cells[0].Value.ToString());
            }
        }

        private void ItemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ItemDGV.Rows[e.RowIndex];
                this.selectedItemId = int.Parse(row.Cells[0].Value.ToString());
                ProdNameTb.Text = row.Cells[1].Value.ToString();
                PriceTb.Text = row.Cells[4].Value.ToString();
                price = row.Cells[4].Value.ToString();
                stock = Convert.ToInt32(row.Cells[5].Value.ToString());
                prodId = Convert.ToInt32(row.Cells[0].Value.ToString());
                prodBarcode = row.Cells[6].Value.ToString();
            }
        }

        private void QtyTb_TextChanged(object sender, EventArgs e)
        {
            if (QtyTb.Text != "" && PriceTb.Text != "")
            {
                try 
                {
                    PriceTb.Text = (Convert.ToDouble(QtyTb.Text) * Convert.ToDouble(price)).ToString();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            else if (QtyTb.Text == "" && ProdNameTb.Text == "")
            {
                PriceTb.Text = "";
            }
            else
            {
                PriceTb.Text = price;
            }
        }

        private void ResetBillBtn_Click(object sender, EventArgs e)
        {
            ResetBill();
        }

        private void SearchClient_TextChanged(object sender, EventArgs e)
        {
            Search(SearchClient, "ClientName");
        }

        private void SearchProduct_TextChanged(object sender, EventArgs e)
        {
            Search(SearchProduct, "ProductBarcode");
        }

        private void BillDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectedBillLine = e.RowIndex;
        }

        private void DeleteLineBtn_Click(object sender, EventArgs e)
        {
            if (selectedBillLine >= 0)
            {
                BillDGV.Rows.RemoveAt(selectedBillLine);
                this.selectedBillLine = -1;
            }
            else 
            {
                MessageBox.Show("Please select a line to be deleted");
            }
        }

        private void SoldItemsBtn_Click(object sender, EventArgs e)
        {
            SoldItems obj = new SoldItems();
            obj.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
