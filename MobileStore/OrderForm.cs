using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Windows.Controls.Primitives;
using System.Xml;

namespace MobileStore
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Discount", typeof(string));
            dt.Columns.Add("Total", typeof(string));


            OrderTable.DataSource = dt;
            OrderTable.ReadOnly = true;

            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.CommandText = "Select employeeid, firstname from staff.employees";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employeeCombo.Items.Add(reader[0].ToString() + ", " + reader[1].ToString());
                    }
                    reader.Close();
                }

            }
        }

        private void brand_focus(object sender, EventArgs e)
        {
            ResetForm();
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

        private void model_focus(object sender, EventArgs e)
        {
            if(BrandCombo.SelectedItem == null)
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

        private void submit_Click(object sender, EventArgs e)
        {
            if(employeeCombo.SelectedItem == null && string.IsNullOrEmpty(customerName.Text) && string.IsNullOrEmpty(customerContract.Text))
            {
                MessageBox.Show("Please fill the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string FirstName = customerName.Text;
            string cnic = customerCNIC.Text;
            string lastName = customerLName.Text;

            string address = customerAddress.Text;
            string city = customerCity.Text;
            string contact = customerContract.Text;
            string email = customerEmail.Text;
            int customer = -1;
            

            int employeeid = int.Parse(employeeCombo.SelectedItem.ToString().Split(',')[0]);
            using (var connection = DbConnection.GetConnection())
            {
                SqlDataReader reader;

                connection.Open();
                using (var command = new SqlCommand())
                {

                    command.Connection = connection;

                    if (string.IsNullOrEmpty(customerID.Text))
                    {
                        //command.CommandText = "INSERT INTO sales.Customers(FirstName, CNIC, Address, City, Contact, EMail) output inserted.customerID VALUES (@Name, @CNIC, @Address, @City, @Contact, @Email)";
                        command.CommandText = "sales.uspAddCustomer";
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@FirstName", FirstName);
                        command.Parameters.AddWithValue("@CNIC", cnic);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Email", email);  


                        customer = (int) command.ExecuteScalar();

                    }
                    else
                    {
                        customer = int.Parse(customerID.Text.ToString());
                    }

                    //command.CommandText = "insert into sales.orders output inserted.orderid values(@customerID,@employeeId, @date)";
                    command.CommandText = "sales.uspInsertOrder";
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Clear(); 
                    command.Parameters.AddWithValue("@employeeID", employeeid);
                    command.Parameters.AddWithValue("@customerID", customer);
                    command.Parameters.Add("@date", SqlDbType.DateTime).Value = DateTime.Now;//.ToString("yyyy-MM-dd");

                    int orderId = (int)command.ExecuteScalar();
                
                    int rowsAffected = 0;

                    string brand, model;
                    int quantity, discount, productID=0;

                    foreach (DataRow row in dt.Rows)
                    {
                        brand = row["brand"].ToString();
                        model = row["model"].ToString();
                        quantity = int.Parse(row["quantity"].ToString());
                        discount = int.Parse(row["discount"].ToString());


                        //command.CommandText = "Select productID from stock.products where brand=@brand and model=@model";
                        command.CommandText = "sales.uspGetProductId";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@model", model);
                        reader = command.ExecuteReader();
                        command.Parameters.Clear();
                        if (reader.Read())
                        {
                            productID = int.Parse(reader[0].ToString());
                        }
                        reader.Close ();

                        //command.CommandText = "insert into sales.orderDetails values(@orderID, @productID, @quantity, @discount)";
                        command.CommandText = "sales.uspInsertOrderDetails";
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@orderID", orderId);
                        command.Parameters.AddWithValue("@productID", productID);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@discount", discount);

                        rowsAffected = command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        if (rowsAffected <= 0)
                        {
                            MessageBox.Show("Failed to place the Shipment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dt.Clear();
            OrderTable.Update();


        }

        private void ResetForm()
        {
            BrandCombo.SelectedIndex = -1;
            ModelCombo.SelectedIndex = -1;
            quantityBox.Value = 1;
            discountBox.Value = 0;

        }

        

        private void OrderForm_Load(object sender, EventArgs e)
        {

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

            int discount = (int)discountBox.Value;

            float price=0;

            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    command.CommandText = "Select price, quantity from stock.products where brand=@brand and model=@model";
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    Console.WriteLine(brand + model);
                    reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        if(quantity >int.Parse(reader["quantity"].ToString()))
                        {
                            MessageBox.Show("Not enough Stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        price = float.Parse(reader[0].ToString());
                    }
                    reader.Close();
                }

            }

            dt.Rows.Add(brand,model,price,quantity,discount, (price * quantity) - (price * quantity * ((float)discount / 100)));

            OrderTable.Update();

            ResetForm();
            updateTotal();
        }
        int rowIndex = -1;
        private void OrderTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                DataGridViewRow row = OrderTable.Rows[e.RowIndex];
                BrandCombo.SelectedIndex = BrandCombo.Items.IndexOf(row.Cells["brand"].Value.ToString());
                load_model(row.Cells["brand"].Value.ToString());
                ModelCombo.SelectedIndex = ModelCombo.Items.IndexOf(row.Cells["model"].Value.ToString());
                quantityBox.Value = Decimal.Parse( row.Cells["quantity"].Value.ToString());
                discountBox.Value = Decimal.Parse(row.Cells["discount"].Value.ToString());
                total.Text = row.Cells["total"].Value.ToString();
            }

            total.Text = rowIndex.ToString();
     
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
                    command.CommandText = "Select model from stock.Products where brand=@brand";
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
            if(rowIndex== -1)
            {
                MessageBox.Show("Please select a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dt.Rows.RemoveAt(rowIndex);
            OrderTable.Update();
            updateTotal();
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
                total +=  float.Parse( row["total"].ToString());
            }

            this.total.Text = total.ToString();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void customerContract_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(customerContract.Text))
            {
                string contract = customerContract.Text.ToString();
                using (var connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        SqlDataReader reader;
                        command.Connection = connection;
                        command.CommandText = "Select * from sales.Customers where contact=@contact";
                        command.Parameters.AddWithValue("@contact", contract);
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            customerID.Text = reader[0].ToString();
                            customerName.Text= reader[1].ToString();
                            customerLName.Text= reader[2].ToString();
                            customerCNIC.Text = reader[3].ToString();
                            customerAddress.Text = reader[4].ToString();
                            customerCity.Text = reader[5].ToString();
                            customerEmail.Text = reader[7].ToString();
                        }
                        reader.Close();
                    }

                }
            }
        }
    }

}
