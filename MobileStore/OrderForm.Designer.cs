namespace MobileStore
{
    partial class OrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BrandCombo = new System.Windows.Forms.ComboBox();
            this.ModelCombo = new System.Windows.Forms.ComboBox();
            this.quantityBox = new System.Windows.Forms.NumericUpDown();
            this.submit = new System.Windows.Forms.Button();
            this.total = new System.Windows.Forms.Label();
            this.discountBox = new System.Windows.Forms.NumericUpDown();
            this.customerName = new System.Windows.Forms.TextBox();
            this.customerContract = new System.Windows.Forms.TextBox();
            this.customerAddress = new System.Windows.Forms.TextBox();
            this.customerCity = new System.Windows.Forms.TextBox();
            this.customerEmail = new System.Windows.Forms.TextBox();
            this.customerCNIC = new System.Windows.Forms.TextBox();
            this.OrderTable = new System.Windows.Forms.DataGridView();
            this.employeeCombo = new System.Windows.Forms.ComboBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.customerID = new System.Windows.Forms.TextBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.customerLName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BrandCombo
            // 
            this.BrandCombo.AllowDrop = true;
            this.BrandCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.BrandCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.BrandCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BrandCombo.Location = new System.Drawing.Point(1240, 229);
            this.BrandCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrandCombo.Name = "BrandCombo";
            this.BrandCombo.Size = new System.Drawing.Size(188, 33);
            this.BrandCombo.Sorted = true;
            this.BrandCombo.TabIndex = 1;
            this.BrandCombo.Enter += new System.EventHandler(this.brand_focus);
            // 
            // ModelCombo
            // 
            this.ModelCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ModelCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ModelCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ModelCombo.FormattingEnabled = true;
            this.ModelCombo.Location = new System.Drawing.Point(921, 229);
            this.ModelCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ModelCombo.Name = "ModelCombo";
            this.ModelCombo.Size = new System.Drawing.Size(188, 33);
            this.ModelCombo.TabIndex = 2;
            this.ModelCombo.Enter += new System.EventHandler(this.model_focus);
            // 
            // quantityBox
            // 
            this.quantityBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.quantityBox.Location = new System.Drawing.Point(927, 388);
            this.quantityBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(109, 30);
            this.quantityBox.TabIndex = 3;
            this.quantityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // submit
            // 
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.submit.ForeColor = System.Drawing.SystemColors.Control;
            this.submit.Location = new System.Drawing.Point(1534, 410);
            this.submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(117, 53);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.total.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.total.Location = new System.Drawing.Point(1389, 528);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(39, 29);
            this.total.TabIndex = 5;
            this.total.Text = "00";
            // 
            // discountBox
            // 
            this.discountBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.discountBox.Location = new System.Drawing.Point(1240, 388);
            this.discountBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.discountBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.discountBox.Name = "discountBox";
            this.discountBox.Size = new System.Drawing.Size(117, 30);
            this.discountBox.TabIndex = 6;
            // 
            // customerName
            // 
            this.customerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerName.Location = new System.Drawing.Point(221, 190);
            this.customerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(145, 30);
            this.customerName.TabIndex = 7;
            // 
            // customerContract
            // 
            this.customerContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerContract.Location = new System.Drawing.Point(63, 315);
            this.customerContract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerContract.Name = "customerContract";
            this.customerContract.Size = new System.Drawing.Size(207, 30);
            this.customerContract.TabIndex = 8;
            this.customerContract.Leave += new System.EventHandler(this.customerContract_Leave);
            // 
            // customerAddress
            // 
            this.customerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerAddress.Location = new System.Drawing.Point(399, 315);
            this.customerAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.Size = new System.Drawing.Size(220, 30);
            this.customerAddress.TabIndex = 9;
            // 
            // customerCity
            // 
            this.customerCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCity.Location = new System.Drawing.Point(45, 431);
            this.customerCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerCity.Name = "customerCity";
            this.customerCity.Size = new System.Drawing.Size(100, 30);
            this.customerCity.TabIndex = 10;
            // 
            // customerEmail
            // 
            this.customerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerEmail.Location = new System.Drawing.Point(489, 427);
            this.customerEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerEmail.Name = "customerEmail";
            this.customerEmail.Size = new System.Drawing.Size(117, 30);
            this.customerEmail.TabIndex = 11;
            // 
            // customerCNIC
            // 
            this.customerCNIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCNIC.Location = new System.Drawing.Point(253, 430);
            this.customerCNIC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerCNIC.Name = "customerCNIC";
            this.customerCNIC.Size = new System.Drawing.Size(145, 30);
            this.customerCNIC.TabIndex = 12;
            // 
            // OrderTable
            // 
            this.OrderTable.AllowUserToAddRows = false;
            this.OrderTable.AllowUserToResizeColumns = false;
            this.OrderTable.AllowUserToResizeRows = false;
            this.OrderTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrderTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.OrderTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OrderTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.OrderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.OrderTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.OrderTable.Location = new System.Drawing.Point(-3, 586);
            this.OrderTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OrderTable.Name = "OrderTable";
            this.OrderTable.RowHeadersVisible = false;
            this.OrderTable.RowHeadersWidth = 51;
            this.OrderTable.RowTemplate.Height = 35;
            this.OrderTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrderTable.Size = new System.Drawing.Size(2225, 649);
            this.OrderTable.TabIndex = 14;
            this.OrderTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderTable_CellContentClick);
            this.OrderTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderTable_CellContentClick);
            // 
            // employeeCombo
            // 
            this.employeeCombo.AllowDrop = true;
            this.employeeCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.employeeCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.employeeCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.employeeCombo.Location = new System.Drawing.Point(682, 29);
            this.employeeCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.employeeCombo.Name = "employeeCombo";
            this.employeeCombo.Size = new System.Drawing.Size(187, 33);
            this.employeeCombo.Sorted = true;
            this.employeeCombo.TabIndex = 15;
            // 
            // addBtn
            // 
            this.addBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addBtn.Location = new System.Drawing.Point(1534, 112);
            this.addBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(117, 42);
            this.addBtn.TabIndex = 16;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteBtn.Location = new System.Drawing.Point(1533, 210);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(119, 52);
            this.deleteBtn.TabIndex = 17;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.updateBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.updateBtn.Location = new System.Drawing.Point(1534, 315);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(119, 49);
            this.updateBtn.TabIndex = 18;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // customerID
            // 
            this.customerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerID.Location = new System.Drawing.Point(45, 190);
            this.customerID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerID.Name = "customerID";
            this.customerID.Size = new System.Drawing.Size(88, 30);
            this.customerID.TabIndex = 19;
            // 
            // ResetBtn
            // 
            this.ResetBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ResetBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.ResetBtn.Location = new System.Drawing.Point(1534, 511);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(117, 46);
            this.ResetBtn.TabIndex = 39;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // customerLName
            // 
            this.customerLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerLName.Location = new System.Drawing.Point(469, 190);
            this.customerLName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customerLName.Name = "customerLName";
            this.customerLName.Size = new System.Drawing.Size(149, 30);
            this.customerLName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(56, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 36);
            this.label1.TabIndex = 54;
            this.label1.Text = "Customer Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(40, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 55;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(216, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 56;
            this.label3.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(464, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 25);
            this.label4.TabIndex = 57;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(57, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 58;
            this.label5.Text = "Contact";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(484, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 59;
            this.label6.Text = "E-Mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(393, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 60;
            this.label7.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(40, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 25);
            this.label8.TabIndex = 61;
            this.label8.Text = "City";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(248, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 25);
            this.label9.TabIndex = 62;
            this.label9.Text = "CNIC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label10.Location = new System.Drawing.Point(901, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 36);
            this.label10.TabIndex = 63;
            this.label10.Text = "Phone Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(916, 171);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 64;
            this.label11.Text = "Brand";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(1235, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 25);
            this.label12.TabIndex = 65;
            this.label12.Text = "Model";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(537, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 25);
            this.label13.TabIndex = 66;
            this.label13.Text = "Employee";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(922, 327);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 25);
            this.label14.TabIndex = 67;
            this.label14.Text = "Quantity";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(1235, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 25);
            this.label15.TabIndex = 68;
            this.label15.Text = "Discount";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(1296, 532);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 25);
            this.label16.TabIndex = 69;
            this.label16.Text = "Total";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1664, 986);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.customerLName);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.customerID);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.employeeCombo);
            this.Controls.Add(this.OrderTable);
            this.Controls.Add(this.customerCNIC);
            this.Controls.Add(this.customerEmail);
            this.Controls.Add(this.customerCity);
            this.Controls.Add(this.customerAddress);
            this.Controls.Add(this.customerContract);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.discountBox);
            this.Controls.Add(this.total);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.ModelCombo);
            this.Controls.Add(this.BrandCombo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.discountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox BrandCombo;
        private System.Windows.Forms.ComboBox ModelCombo;
        private System.Windows.Forms.NumericUpDown quantityBox;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.NumericUpDown discountBox;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox customerContract;
        private System.Windows.Forms.TextBox customerAddress;
        private System.Windows.Forms.TextBox customerCity;
        private System.Windows.Forms.TextBox customerEmail;
        private System.Windows.Forms.TextBox customerCNIC;
        private System.Windows.Forms.DataGridView OrderTable;
        private System.Windows.Forms.ComboBox employeeCombo;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TextBox customerID;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.TextBox customerLName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}