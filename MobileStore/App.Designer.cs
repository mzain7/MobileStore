namespace MobileStore
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.Shipment = new FontAwesome.Sharp.IconButton();
            this.Employee = new FontAwesome.Sharp.IconButton();
            this.Product = new FontAwesome.Sharp.IconButton();
            this.Order = new FontAwesome.Sharp.IconButton();
            this.DashBoard = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.Shipment);
            this.panelMenu.Controls.Add(this.Employee);
            this.panelMenu.Controls.Add(this.Product);
            this.panelMenu.Controls.Add(this.Order);
            this.panelMenu.Controls.Add(this.DashBoard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 1033);
            this.panelMenu.TabIndex = 0;
            // 
            // Shipment
            // 
            this.Shipment.Dock = System.Windows.Forms.DockStyle.Top;
            this.Shipment.FlatAppearance.BorderSize = 0;
            this.Shipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Shipment.ForeColor = System.Drawing.Color.White;
            this.Shipment.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.Shipment.IconColor = System.Drawing.Color.Gainsboro;
            this.Shipment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Shipment.IconSize = 32;
            this.Shipment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Shipment.Location = new System.Drawing.Point(0, 316);
            this.Shipment.Name = "Shipment";
            this.Shipment.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Shipment.Size = new System.Drawing.Size(220, 60);
            this.Shipment.TabIndex = 5;
            this.Shipment.Text = "Shipment";
            this.Shipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Shipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Shipment.UseVisualStyleBackColor = true;
            this.Shipment.Click += new System.EventHandler(this.Shipment_Click);
            // 
            // Employee
            // 
            this.Employee.Dock = System.Windows.Forms.DockStyle.Top;
            this.Employee.FlatAppearance.BorderSize = 0;
            this.Employee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Employee.ForeColor = System.Drawing.Color.White;
            this.Employee.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.Employee.IconColor = System.Drawing.Color.Gainsboro;
            this.Employee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Employee.IconSize = 32;
            this.Employee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Employee.Location = new System.Drawing.Point(0, 256);
            this.Employee.Name = "Employee";
            this.Employee.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Employee.Size = new System.Drawing.Size(220, 60);
            this.Employee.TabIndex = 4;
            this.Employee.Text = "Employees";
            this.Employee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Employee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Employee.UseVisualStyleBackColor = true;
            this.Employee.Click += new System.EventHandler(this.Employee_Click);
            // 
            // Product
            // 
            this.Product.Dock = System.Windows.Forms.DockStyle.Top;
            this.Product.FlatAppearance.BorderSize = 0;
            this.Product.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Product.ForeColor = System.Drawing.Color.White;
            this.Product.IconChar = FontAwesome.Sharp.IconChar.MobileScreenButton;
            this.Product.IconColor = System.Drawing.Color.Gainsboro;
            this.Product.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Product.IconSize = 32;
            this.Product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Product.Location = new System.Drawing.Point(0, 196);
            this.Product.Name = "Product";
            this.Product.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Product.Size = new System.Drawing.Size(220, 60);
            this.Product.TabIndex = 3;
            this.Product.Text = "Product";
            this.Product.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Product.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Product.UseVisualStyleBackColor = true;
            this.Product.Click += new System.EventHandler(this.Product_Click);
            // 
            // Order
            // 
            this.Order.Dock = System.Windows.Forms.DockStyle.Top;
            this.Order.FlatAppearance.BorderSize = 0;
            this.Order.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Order.ForeColor = System.Drawing.Color.White;
            this.Order.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.Order.IconColor = System.Drawing.Color.Gainsboro;
            this.Order.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Order.IconSize = 32;
            this.Order.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Order.Location = new System.Drawing.Point(0, 136);
            this.Order.Name = "Order";
            this.Order.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.Order.Size = new System.Drawing.Size(220, 60);
            this.Order.TabIndex = 2;
            this.Order.Text = "Order";
            this.Order.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Order.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Click += new System.EventHandler(this.Order_Click);
            // 
            // DashBoard
            // 
            this.DashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.DashBoard.FlatAppearance.BorderSize = 0;
            this.DashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashBoard.ForeColor = System.Drawing.Color.White;
            this.DashBoard.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.DashBoard.IconColor = System.Drawing.Color.Gainsboro;
            this.DashBoard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.DashBoard.IconSize = 32;
            this.DashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBoard.Location = new System.Drawing.Point(0, 76);
            this.DashBoard.Name = "DashBoard";
            this.DashBoard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.DashBoard.Size = new System.Drawing.Size(220, 60);
            this.DashBoard.TabIndex = 1;
            this.DashBoard.Text = "Dashboard";
            this.DashBoard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DashBoard.UseVisualStyleBackColor = true;
            this.DashBoard.Click += new System.EventHandler(this.DashBoard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 76);
            this.panelLogo.TabIndex = 0;
            // 
            // panelDesktop
            // 
            this.panelDesktop.AutoSize = true;
            this.panelDesktop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1682, 1033);
            this.panelDesktop.TabIndex = 1;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MobileStore";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton DashBoard;
        private FontAwesome.Sharp.IconButton Shipment;
        private FontAwesome.Sharp.IconButton Employee;
        private FontAwesome.Sharp.IconButton Product;
        private FontAwesome.Sharp.IconButton Order;
        private System.Windows.Forms.Panel panelDesktop;
    }
}

