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
using System.Windows.Forms.DataVisualization.Charting;

namespace MobileStore
{
    public partial class AddSupplierForm : Form
    {
        ShipmentForm form;
        public AddSupplierForm(ShipmentForm form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string address = textBoxAddress.Text.Trim();
                string city = textBoxCity.Text.Trim();
                string contact = textBoxContact.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string cname = textBoxCompanyName.Text.Trim();
                string country = textBoxCounry.Text.Trim();

                string query = @"INSERT INTO stock.Suppliers (CompanyName, [Address], City, Contact, EMail, Country) output inserted.supplierID
                    VALUES (@CompanyName, @Address, @City, @Contact, @Email, @Country)";

                int orderId;
                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CompanyName", cname);
                        command.Parameters.AddWithValue("@Country", country);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();

                        orderId = (int)command.ExecuteScalar();
                    }
                }

                this.Close();
                this.form.UpdateSupplierBox(orderId.ToString() + " | " + cname);

            }
            catch(Exception) {
                MessageBox.Show("Please Try Again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {

        }
    }
}
