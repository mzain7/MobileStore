using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileStore
{
    public partial class ShipmentForm : Form
    {
        public ShipmentForm()
        {
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Total", typeof(string));


            InitializeComponent();
            ShipTable.DataSource = dt;
            ShipTable.ReadOnly = true;


            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.CommandText = "Select supplierid, CompanyName from stock.Suppliers";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        supplierCombo.Items.Add(reader[0].ToString() + " | " + reader[1].ToString());
                    }
                    reader.Close();
                }

            }

            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 products
                    command.CommandText = "Select employeeid, firstname from staff.employees";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employeeCombo.Items.Add(reader[0].ToString() + " | " + reader[1].ToString());
                    }
                    reader.Close();
                }

            }

        }
        public void UpdateBox(string brand, string model)
        {
            BrandCombo.Items.Clear();
            ModelCombo.Items.Clear();
            BrandCombo_Enter(new Object(), new EventArgs());
            BrandCombo.SelectedIndex = BrandCombo.Items.IndexOf(brand);
            ModelCombo_Enter(new Object(), new EventArgs());
            ModelCombo.SelectedIndex = ModelCombo.Items.IndexOf(model);
        }
        

        public void UpdateSupplierBox(string supplier)
        {
            supplierCombo.Items.Clear();
            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.CommandText = "Select supplierid, CompanyName from stock.Suppliers";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        supplierCombo.Items.Add(reader[0].ToString() + " | " + reader[1].ToString());
                    }
                    reader.Close();
                }

            }

            supplierCombo.SelectedIndex = supplierCombo.Items.IndexOf(supplier);
        }

        private void BrandCombo_Enter(object sender, EventArgs e)
        {
            ModelCombo.Items.Clear();
            quantityBox.Value = 1;
            BrandCombo.Items.Clear();
            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.CommandText = "Select DISTINCT brand from stock.products";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BrandCombo.Items.Add(reader[0].ToString());
                    }
                    reader.Close();
                }

            }
        }

        private void ModelCombo_Enter(object sender, EventArgs e)
        {
            ModelCombo.Items.Clear();
            if (BrandCombo.SelectedItem == null)
            {
                MessageBox.Show("Please fill the Brand.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ModelCombo.Items.Clear();
            string brand = BrandCombo.SelectedItem.ToString();
            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //command.CommandText = "Select model from stock.Products where brand=@brand";
                    command.CommandText = "sales.uspGetModel";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@brand", brand);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ModelCombo.Items.Add(reader[0].ToString());
                    }
                    reader.Close();
                }

            }
        }
        DataTable dt = new DataTable();

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (BrandCombo.SelectedItem == null || ModelCombo.SelectedItem == null)
            {
                MessageBox.Show("Please fill the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string brand = BrandCombo.SelectedItem.ToString();
            string model = ModelCombo.SelectedItem.ToString();
            int quantity = (int)quantityBox.Value;

            float price = float.Parse(priceBox.Text.ToString());

            dt.Rows.Add(brand, model, price, quantity, price * quantity);
            ShipTable.Update();
            ResetForm();
            updateTotal();


        }

        private void ResetForm()
        {
            BrandCombo.SelectedIndex = -1;
            ModelCombo.SelectedIndex = -1;
            quantityBox.Value = 1;
            priceBox.Text= string.Empty;
        }

        int rowIndex = -1;

        private void ShipTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                DataGridViewRow row = ShipTable.Rows[e.RowIndex];
                BrandCombo.SelectedIndex = BrandCombo.Items.IndexOf(row.Cells["brand"].Value.ToString());
                load_model(row.Cells["brand"].Value.ToString());
                ModelCombo.SelectedIndex = ModelCombo.Items.IndexOf(row.Cells["model"].Value.ToString());
                quantityBox.Value = Decimal.Parse(row.Cells["quantity"].Value.ToString());
                priceBox.Text = row.Cells["price"].Value.ToString();
            }

        }

        private void load_model(string brand)
        {
            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //command.CommandText = "Select model from stock.Products where brand=@brand";
                    command.CommandText = "sales.uspGetModel";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@brand", brand);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ModelCombo.Items.Add(reader[0].ToString());
                    }
                    reader.Close();
                }

            }
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (rowIndex == -1)
            {
                MessageBox.Show("Please select a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dt.Rows.RemoveAt(rowIndex);
            ShipTable.Update();
            updateTotal();
            rowIndex = -1;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            deleteBtn_Click(sender, e);
            addBtn_Click(sender, e);
        }


        private void updateTotal()
        {
            float total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += float.Parse(row["total"].ToString());
            }

            this.total.Text = total.ToString();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void addProduct_Click(object sender, EventArgs e)
        {
            Form childForm = new AddProductForm(this);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            panel.Show();
        }

        private void addSupplier_Click(object sender, EventArgs e)
        {
            Form childForm = new AddSupplierForm(this);

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            panel.Show();
        }

        private void submit_Click(object sender, EventArgs e)
        {

            int employeeid = int.Parse(employeeCombo.SelectedItem.ToString().Split(' ')[0]);
            int supplierid = int.Parse(supplierCombo.SelectedItem.ToString().Split(' ')[0]);

            using (var connection = DbConnection.GetConnection())
            {
                SqlDataReader reader;

                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;


                    //command.CommandText = "insert into stock.shipment output inserted.shipmentID values(@supplierID,@employeeId, @date)";
                    command.CommandText = "stock.uspInsertShipment";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@employeeID", employeeid);
                    command.Parameters.AddWithValue("@supplierID", supplierid);
                    command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd");

                    int shipId = (int)command.ExecuteScalar();



                    int rowsAffected = 0;

                    string brand, model;
                    int quantity, price, productID = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        brand = row["brand"].ToString();
                        model = row["model"].ToString();
                        quantity = int.Parse(row["quantity"].ToString());
                        price = int.Parse(row["price"].ToString());

                        command.Parameters.Clear();
                        //command.CommandText = "Select productID from stock.products where brand=@brand and model=@model";
                        command.CommandText = "sales.uspGetProductId";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@model", model);
                        reader = command.ExecuteReader();
                        command.Parameters.Clear();
                        if (reader.Read())
                        {
                            productID = int.Parse(reader[0].ToString());
                        }
                        reader.Close();

                        //command.CommandText = "insert into stock.shipmentDetails values(@ShipmentID, @productID, @quantity, @UnitPrice)";
                        command.CommandText = "stock.uspInsertShipmentDetails";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ShipmentID", shipId);
                        command.Parameters.AddWithValue("@productID", productID);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@UnitPrice", price);

                        rowsAffected = command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show("Failed to place the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        /*
                        command.CommandText = "UPDATE stock.Products SET Quantity = Quantity + @quantity WHERE ProductID = @ProductID";
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@productID", productID);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        */

                    }

                }

            }
            MessageBox.Show("Submitted Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm();
            supplierCombo.SelectedIndex = -1;
            total.Text = "0.00";
            dt.Clear();
            ShipTable.Update();
        }
    }
}
