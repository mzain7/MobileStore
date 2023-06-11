using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MobileStore
{
    public partial class EmployeeForm : Form
    {
        DataTable dataTable = new DataTable();
        int rowIndex = -1;

        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployees();
            EmployeeTable.ReadOnly = true;


        }

        private void LoadEmployees()
        {
            dataTable.Clear();

            using (SqlConnection connection = DbConnection.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM staff.employees", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        connection.Open();

                        adapter.Fill(dataTable);

                        EmployeeTable.DataSource = dataTable;
                    }
                }
            }
        }

            private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = textBoxFirstName.Text.Trim();
                string lastName = textBoxLastName.Text.Trim();

                string cnic = textBoxCNIC.Text.Trim();
                string title = textBoxTitle.Text.Trim();
                decimal salary = decimal.Parse(textBoxSalary.Text.Trim());
                DateTime dob = DOB.Value;
                DateTime hireDate = HireDate.Value;
                string address = textBoxAddress.Text.Trim();
                string city = textBoxCity.Text.Trim();
                string contact = textBoxContact.Text.Trim();
                string email = textBoxEmail.Text.Trim();

                //string query = @"INSERT INTO dbo.Employees (FirstName, LastName, CNIC, Title, Salary, DOB,
                  //  HireDate, [Address], City, Contact, EMail)
                    //VALUES (@FirstName, @LastName, @CNIC, @Title, @Salary, @DOB, @HireDate,
                     //@Address, @City, @Contact, @Email)";

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand("staff.uspAddEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        command.Parameters.AddWithValue("@CNIC", cnic);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@DOB", dob);
                        command.Parameters.AddWithValue("@HireDate", hireDate);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Email", email);

                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Employee added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add the employee.");
                        }
                    }
                }

                LoadEmployees();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (rowIndex == -1 || rowIndex >= dataTable.Rows.Count)
            {
                MessageBox.Show("Please select a row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int employeeID = int.Parse(dataTable.Rows[rowIndex]["employeeid"].ToString());


            using (var connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("staff.uspDeleteEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    try
                    {
                        command.ExecuteReader();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Can not delete this Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dataTable.Rows.RemoveAt(rowIndex);
                    EmployeeTable.Update();

                }

            }
        }
        private void ClearTextboxes()
        {
            textBoxId.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxCNIC.Clear();
            textBoxTitle.Clear();
            textBoxSalary.Clear();
            DOB.Value = DateTime.Now;
            HireDate.Value = DateTime.Now;
            textBoxAddress.Clear();
            textBoxCity.Clear();
            textBoxContact.Clear();
            textBoxEmail.Clear();
        }

        private void ClearTextboxes(object sender, MouseEventArgs e)
        {
            ClearTextboxes();
        }

        private void EmployeeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                DataGridViewRow row = EmployeeTable.Rows[e.RowIndex];

                textBoxId.Text = row.Cells["employeeID"].Value.ToString();
                textBoxFirstName.Text = row.Cells["FirstName"].Value.ToString();
                textBoxLastName.Text = row.Cells["LastName"].Value.ToString();
                textBoxCNIC.Text = row.Cells["CNIC"].Value.ToString();
                textBoxTitle.Text = row.Cells["Title"].Value.ToString();
                textBoxSalary.Text = row.Cells["Salary"].Value.ToString();
                DOB.Text = row.Cells["DOB"].Value.ToString();
                HireDate.Text = row.Cells["HireDate"].Value.ToString();
                textBoxAddress.Text = row.Cells["Address"].Value.ToString();
                textBoxCity.Text = row.Cells["City"].Value.ToString();
                textBoxContact.Text = row.Cells["Contact"].Value.ToString();
                textBoxEmail.Text = row.Cells["EMail"].Value.ToString();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                SqlCommand command = new SqlCommand("staff.uspSearchEmployee", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", (!string.IsNullOrWhiteSpace(textBoxId.Text) ? "%" + textBoxId.Text + "%" : null));
                command.Parameters.AddWithValue("@FirstName", (!string.IsNullOrWhiteSpace(textBoxFirstName.Text) ? "%" + textBoxFirstName.Text + "%" : "%"));
                command.Parameters.AddWithValue("@LastName", (!string.IsNullOrWhiteSpace(textBoxLastName.Text) ? "%" + textBoxLastName.Text + "%" : "%"));
                command.Parameters.AddWithValue("@CNIC", (!string.IsNullOrWhiteSpace(textBoxCNIC.Text) ? "%" + textBoxCNIC.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Title", (!string.IsNullOrWhiteSpace(textBoxTitle.Text) ? "%" + textBoxTitle.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Salary", (!string.IsNullOrWhiteSpace(textBoxSalary.Text) ? "%" + textBoxSalary.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Address", (!string.IsNullOrWhiteSpace(textBoxAddress.Text) ? "%" + textBoxAddress.Text + "%" : "%"));
                command.Parameters.AddWithValue("@City", (!string.IsNullOrWhiteSpace(textBoxCity.Text) ? "%" + textBoxCity.Text + "%" : "%"));
                command.Parameters.AddWithValue("@Contact", (!string.IsNullOrWhiteSpace(textBoxContact.Text) ? "%" + textBoxContact.Text + "%" : "%"));
                command.Parameters.AddWithValue("@EMail", (!string.IsNullOrWhiteSpace(textBoxEmail.Text) ? "%" + textBoxEmail.Text + "%" : "%"));

                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    dataTable.Clear();

                    adapter.Fill(dataTable);


                    EmployeeTable.Update();

                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int employeeID = int.Parse(textBoxId.Text.Trim());

                string firstName = textBoxFirstName.Text.Trim();
                string lastName = textBoxLastName.Text.Trim();

                string cnic = textBoxCNIC.Text.Trim();
                string title = textBoxTitle.Text.Trim();
                decimal salary = decimal.Parse(textBoxSalary.Text.Trim());
                DateTime dob = DOB.Value;
                DateTime hireDate = HireDate.Value;
                string address = textBoxAddress.Text.Trim();
                string city = textBoxCity.Text.Trim();
                string contact = textBoxContact.Text.Trim();
                string email = textBoxEmail.Text.Trim();

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("staff.uspUpdateEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", employeeID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        command.Parameters.AddWithValue("@CNIC", cnic);
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Salary", salary);
                        command.Parameters.AddWithValue("@DOB", dob);
                        command.Parameters.AddWithValue("@HireDate", hireDate);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Contact", contact);
                        command.Parameters.AddWithValue("@Email", email);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Failed to update the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        LoadEmployees();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
