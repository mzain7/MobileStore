using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileStore
{
    public partial class DashboardForm : Form
    {
        private Dashboard model;

        public DashboardForm()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            btnLast7Days.Select();

            model = new Dashboard();
            LoadData();
        }

        


        private void LoadData()
        {
            var refreshData = model.LoadData(dtpStartDate.Value, dtpEndDate.Value);
            if (refreshData == true)
            {
                lblNumOrders.Text = model.NumOrders.ToString();
                
                lblTotalRevenue.Text = "Rs. " + (Math.Ceiling(model.TotalRevenue * 100) / 100).ToString();
                lblTotalProfit.Text = "Rs. " + (Math.Ceiling(model.TotalProfit * 100) / 100).ToString();

                lblNumCustomers.Text = model.NumCustomers.ToString();
                lblNumSuppliers.Text = model.NumSuppliers.ToString();
                lblNumProducts.Text = model.NumProducts.ToString();

                chartGrossRevenue.DataSource = model.GrossRevenueList;
                chartGrossRevenue.Series[0].XValueMember = "Date";
                chartGrossRevenue.Series[0].YValueMembers = "TotalAmount";
                chartGrossRevenue.DataBind();

                chartTopProducts.DataSource = model.TopProductsList;
                chartTopProducts.Series[0].XValueMember = "Key";
                chartTopProducts.Series[0].YValueMembers = "Value";
                chartTopProducts.DataBind();

                dgvUnderstock.DataSource = model.UnderstockList;
                dgvUnderstock.Columns[0].HeaderText = "Item";
                dgvUnderstock.Columns[1].HeaderText = "Units";
            }
        }
        private void DisableCustomDates()
        {
            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;
            btnOkCustomDate.Visible = false;
        }

        //Event methods
        private void btnToday_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnLast7Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadData();
            DisableCustomDates();
        }

        private void btnCustomDate_Click(object sender, EventArgs e)
        {
            dtpStartDate.Visible = true;
            dtpEndDate.Visible = true;
            btnOkCustomDate.Visible = true;
        }

        private void btnOkCustomDate_Click(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
