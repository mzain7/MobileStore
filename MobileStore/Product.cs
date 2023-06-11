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
    public partial class Product : Form
    {
        private DataTable dataTable = new DataTable();
        int rowIndex = -1;

        public Product()
        {
            InitializeComponent();
            LoadProducts();
            ProductTable.ReadOnly = true;

        }
        private void LoadProducts()
        {
            dataTable.Clear();

            using (SqlConnection connection = DbConnection.GetConnection())
            {
                string query = "SELECT * FROM stock.products_info";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }

            ProductTable.DataSource = dataTable;

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (rowIndex == -1 || rowIndex >= dataTable.Rows.Count)
            {
                MessageBox.Show("Please select a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int productID = int.Parse(dataTable.Rows[rowIndex]["productid"].ToString());


            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //command.CommandText = "DELETE FROM dbo.Products WHERE ProductID = @ProductID";
                    command.CommandText = "stock.uspDeleteProduct";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", productID);
                    try
                    {
                        command.ExecuteReader();
                    }
                    catch (SqlException )
                    {
                        MessageBox.Show("Can not delete this Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dataTable.Rows.RemoveAt(rowIndex);
                    ProductTable.Update();

                }

            }
        }

        private void ProductTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                DataGridViewRow row = ProductTable.Rows[e.RowIndex];

                textBoxQuantity.Text = row.Cells["Quantity"].Value.ToString();
                textBoxPrice.Text = row.Cells["Price"].Value.ToString();
                textBoxBrand.Text = row.Cells["Brand"].Value.ToString();
                textBoxModel.Text = row.Cells["Model"].Value.ToString();
                textBoxOS.Text = row.Cells["OS"].Value.ToString();
                textBoxRAM.Text = row.Cells["RAM"].Value.ToString();
                textBoxStorage.Text = row.Cells["Storage"].Value.ToString();
                textBoxCamera.Text = row.Cells["Camera"].Value.ToString();
                textBoxBatteryCapacity.Text = row.Cells["BatteryCapacity"].Value.ToString();
                textBoxDisplay.Text = row.Cells["Display"].Value.ToString();
                textBoxProcessor.Text = row.Cells["Processor"].Value.ToString();
                //checkBoxUsed.Checked = (bool)row.Cells["Used"].Value;
                textBoxDescription.Text = row.Cells["Description"].Value.ToString();

            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try { 

            int quantity = int.Parse(textBoxQuantity.Text.Trim());
            decimal price = decimal.Parse(textBoxPrice.Text.Trim());
            string brand = textBoxBrand.Text.Trim();
            string model = textBoxModel.Text.Trim();
            string os = textBoxOS.Text.Trim();
            string ram = textBoxRAM.Text.Trim();
            string storage = textBoxStorage.Text.Trim();
            string camera = textBoxCamera.Text.Trim();
            string batteryCapacity = textBoxBatteryCapacity.Text.Trim();
            string display = textBoxDisplay.Text.Trim();
            string processor = textBoxProcessor.Text.Trim();
            bool used = checkBoxUsed.Checked;
            string description = textBoxDescription.Text.Trim();

            // Create the SQL query
            string query = @"INSERT INTO dbo.Products (Quantity, Price, Brand, Model, OS, RAM, Storage, Camera, 
                    BatteryCapacity, Display, Processor, Used, [Description])
                    VALUES (@Quantity, @Price, @Brand, @Model, @OS, @RAM, @Storage, @Camera, @BatteryCapacity,
                    @Display, @Processor, @Used, @Description)";

            // Create a SqlConnection object
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand("stock.uspAddProduct", connection))
                {
                        command.CommandType = CommandType.StoredProcedure;
                        // Add parameters for each column
                        command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@OS", os);
                    command.Parameters.AddWithValue("@RAM", ram);
                    command.Parameters.AddWithValue("@Storage", storage);
                    command.Parameters.AddWithValue("@Camera", camera);
                    command.Parameters.AddWithValue("@BatteryCapacity", batteryCapacity);
                    command.Parameters.AddWithValue("@Display", display);
                    command.Parameters.AddWithValue("@Processor", processor);
                    command.Parameters.AddWithValue("@Used", used);
                    command.Parameters.AddWithValue("@Description", description);

                    // Open the connection
                    connection.Open();

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check the number of rows affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Failed to add the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    LoadProducts();
                }



            }

            ResetTextBoxes();

        }
                    catch (Exception )
                    {
                        MessageBox.Show("Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


}

        private void ResetTextBoxes()
        {
            // Assuming you have text boxes for each column in the Products table,
            // replace the textBoxX with the actual name of each text box control

            textBoxQuantity.Text = string.Empty;
            textBoxPrice.Text = string.Empty;
            textBoxBrand.Text = string.Empty;
            textBoxModel.Text = string.Empty;
            textBoxOS.Text = string.Empty;
            textBoxRAM.Text = string.Empty;
            textBoxStorage.Text = string.Empty;
            textBoxCamera.Text = string.Empty;
            textBoxBatteryCapacity.Text = string.Empty;
            textBoxDisplay.Text = string.Empty;
            textBoxProcessor.Text = string.Empty;
            checkBoxUsed.Checked = false;
            textBoxDescription.Text = string.Empty;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetTextBoxes();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

            // Create a SqlConnection object
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                // Create a SqlCommand object
                //"SELECT * FROM dbo.Products WHERE Brand LIKE @Brand AND Model LIKE @Model AND OS LIKE @OS AND RAM LIKE @RAM AND Storage LIKE @Storage AND Camera LIKE @Camera AND BatteryCapacity LIKE @BatteryCapacity AND Display LIKE @Display AND Processor LIKE @Processor AND Used = @Used AND [Description] LIKE @Description"

                SqlCommand command = new SqlCommand("stock.uspSearchProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Brand", (!string.IsNullOrWhiteSpace(textBoxBrand.Text) ? "%" + textBoxBrand.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Model", (!string.IsNullOrWhiteSpace(textBoxModel.Text) ? "%" + textBoxModel.Text + "%" : "%"));
                command.Parameters.AddWithValue("@OS", (!string.IsNullOrWhiteSpace(textBoxOS.Text) ? "%" + textBoxOS.Text + "%" : "%"));
                command.Parameters.AddWithValue("@RAM", (!string.IsNullOrWhiteSpace(textBoxRAM.Text) ? "%" + textBoxRAM.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Storage", (!string.IsNullOrWhiteSpace(textBoxStorage.Text) ? "%" + textBoxStorage.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Camera", (!string.IsNullOrWhiteSpace(textBoxCamera.Text) ? "%" + textBoxCamera.Text + "%" : "%"));
                command.Parameters.AddWithValue("@BatteryCapacity", (!string.IsNullOrWhiteSpace(textBoxBatteryCapacity.Text) ? "%" + textBoxBatteryCapacity.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Display", (!string.IsNullOrWhiteSpace(textBoxDisplay.Text) ? "%" + textBoxDisplay.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Processor", (!string.IsNullOrWhiteSpace(textBoxProcessor.Text) ? "%" + textBoxProcessor.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Description", (!string.IsNullOrWhiteSpace(textBoxDescription.Text) ? "%" + textBoxDescription.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Used", (checkBoxUsed.Checked) ? 1 : 0);



                // Open the connection
                connection.Open();

                // Create a SqlDataAdapter to fill the DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // Create a DataTable to hold the search results
                    dataTable.Clear();

                    // Fill the DataTable with the data from the query
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    ProductTable.DataSource = dataTable;
                }

            }

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try { 
            int quantity = int.Parse(textBoxQuantity.Text.Trim());
            decimal price = decimal.Parse(textBoxPrice.Text.Trim());
            string brand = textBoxBrand.Text.Trim();
            string model = textBoxModel.Text.Trim();
            string os = textBoxOS.Text.Trim();
            string ram = textBoxRAM.Text.Trim();
            string storage = textBoxStorage.Text.Trim();
            string camera = textBoxCamera.Text.Trim();
            string batteryCapacity = textBoxBatteryCapacity.Text.Trim();
            string display = textBoxDisplay.Text.Trim();
            string processor = textBoxProcessor.Text.Trim();
            bool used = checkBoxUsed.Checked;
            string description = textBoxDescription.Text.Trim();
            int productId = 0;

            // Create the SQL query

            // Create a SqlConnection object
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                // Create a SqlCommand object
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT PRODUCTID FROM stock.PRODUCTS WHERE BRAND=@BRAND AND MODEL= @MODEL";
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);


                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        productId = int.Parse(reader[0].ToString());
                    }
                    else
                    {
                        MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    reader.Close();
                }
                using (SqlCommand command = new SqlCommand())
                { 
                    command.Connection= connection;
                    /*command.CommandText = @"UPDATE dbo.Products
                                            SET Brand = @Brand,
                                                Model = @Model,
                                                Quantity = @Quantity,
                                                Price = @Price,
                                                OS = @OS,
                                                RAM = @RAM,
                                                Storage = @Storage,
                                                Camera = @Camera,
                                                BatteryCapacity = @BatteryCapacity,
                                                Display = @Display,
                                                Processor = @Processor,
                                                Used = @Used,
                                                [Description] = @Description
                                            WHERE ProductID = @ProductID;
                                            ";*/

                        command.CommandText = "stock.uspUpdateProduct";
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for each column
                        command.Parameters.AddWithValue("@ProductID", productId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Brand", brand);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@OS", os);
                    command.Parameters.AddWithValue("@RAM", ram);
                    command.Parameters.AddWithValue("@Storage", storage);
                    command.Parameters.AddWithValue("@Camera", camera);
                    command.Parameters.AddWithValue("@BatteryCapacity", batteryCapacity);
                    command.Parameters.AddWithValue("@Display", display);
                    command.Parameters.AddWithValue("@Processor", processor);
                    command.Parameters.AddWithValue("@Used", used);
                    command.Parameters.AddWithValue("@Description", description);

                    // Open the connection

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check the number of rows affected
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Failed to update the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    LoadProducts();

                }
            }

            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


