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
    public partial class AddProductForm : Form
    {
        ShipmentForm form;
        public AddProductForm(ShipmentForm form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {

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

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("stock.uspAddProduct", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Quantity", 0);

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

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Failed to add the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }



                }

                ResetTextBoxes();
                this.Close();
                this.form.UpdateBox(brand, model);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void ResetTextBoxes()
        {
            

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

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxProcessor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
