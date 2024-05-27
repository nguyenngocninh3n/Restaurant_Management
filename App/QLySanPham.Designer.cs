namespace DoAn
{
    partial class QLySanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLySanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grInfo = new System.Windows.Forms.GroupBox();
            this.txtMaLoaiMon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NgayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboTenLoaiMon = new System.Windows.Forms.ComboBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.txtMaMon = new System.Windows.Forms.TextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.lbPrices = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbIDProduct = new System.Windows.Forms.Label();
            this.grButton = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvChiTietMon = new System.Windows.Forms.DataGridView();
            this.colIDProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanhmuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbDanhmuc1 = new System.Windows.Forms.Label();
            this.cboCategory1 = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grInfo.SuspendLayout();
            this.grButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMon)).BeginInit();
            this.SuspendLayout();
            // 
            // grInfo
            // 
            this.grInfo.Controls.Add(this.txtMaLoaiMon);
            this.grInfo.Controls.Add(this.label1);
            this.grInfo.Controls.Add(this.NgayCapNhat);
            this.grInfo.Controls.Add(this.lblDate);
            this.grInfo.Controls.Add(this.cboTenLoaiMon);
            this.grInfo.Controls.Add(this.txtDonGia);
            this.grInfo.Controls.Add(this.txtTenMon);
            this.grInfo.Controls.Add(this.txtMaMon);
            this.grInfo.Controls.Add(this.lbCategory);
            this.grInfo.Controls.Add(this.lbPrices);
            this.grInfo.Controls.Add(this.lbName);
            this.grInfo.Controls.Add(this.lbIDProduct);
            this.grInfo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grInfo.ForeColor = System.Drawing.SystemColors.Window;
            this.grInfo.Location = new System.Drawing.Point(14, 49);
            this.grInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grInfo.Name = "grInfo";
            this.grInfo.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grInfo.Size = new System.Drawing.Size(384, 492);
            this.grInfo.TabIndex = 0;
            this.grInfo.TabStop = false;
            this.grInfo.Text = "Thông tin món";
            // 
            // txtMaLoaiMon
            // 
            this.txtMaLoaiMon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaLoaiMon.Location = new System.Drawing.Point(161, 220);
            this.txtMaLoaiMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaLoaiMon.Name = "txtMaLoaiMon";
            this.txtMaLoaiMon.Size = new System.Drawing.Size(142, 32);
            this.txtMaLoaiMon.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã loại món";
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.CustomFormat = "";
            this.NgayCapNhat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NgayCapNhat.Location = new System.Drawing.Point(161, 434);
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Size = new System.Drawing.Size(217, 32);
            this.NgayCapNhat.TabIndex = 6;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDate.Location = new System.Drawing.Point(6, 440);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(140, 25);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Ngày cập nhật";
            // 
            // cboTenLoaiMon
            // 
            this.cboTenLoaiMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTenLoaiMon.FormattingEnabled = true;
            this.cboTenLoaiMon.Items.AddRange(new object[] {
            "Đồ chay",
            "Đồ uống",
            "Khai vị",
            "Món chính",
            "Món Súp",
            "Rượu bia",
            "Tráng Miệng"});
            this.cboTenLoaiMon.Location = new System.Drawing.Point(157, 51);
            this.cboTenLoaiMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTenLoaiMon.Name = "cboTenLoaiMon";
            this.cboTenLoaiMon.Size = new System.Drawing.Size(221, 33);
            this.cboTenLoaiMon.TabIndex = 0;
            this.cboTenLoaiMon.SelectedIndexChanged += new System.EventHandler(this.cboTenLoaiMon_SelectedIndexChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDonGia.Location = new System.Drawing.Point(161, 364);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(142, 32);
            this.txtDonGia.TabIndex = 4;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrices_KeyPress);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenMon.Location = new System.Drawing.Point(161, 295);
            this.txtTenMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(217, 32);
            this.txtTenMon.TabIndex = 3;
            // 
            // txtMaMon
            // 
            this.txtMaMon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaMon.Location = new System.Drawing.Point(161, 141);
            this.txtMaMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(142, 32);
            this.txtMaMon.TabIndex = 2;
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCategory.Location = new System.Drawing.Point(26, 54);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(102, 25);
            this.lbCategory.TabIndex = 0;
            this.lbCategory.Text = "Danh mục";
            // 
            // lbPrices
            // 
            this.lbPrices.AutoSize = true;
            this.lbPrices.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbPrices.Location = new System.Drawing.Point(26, 367);
            this.lbPrices.Name = "lbPrices";
            this.lbPrices.Size = new System.Drawing.Size(84, 25);
            this.lbPrices.TabIndex = 0;
            this.lbPrices.Text = "Đơn Giá";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbName.Location = new System.Drawing.Point(23, 295);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(89, 25);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Tên món";
            // 
            // lbIDProduct
            // 
            this.lbIDProduct.AutoSize = true;
            this.lbIDProduct.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbIDProduct.Location = new System.Drawing.Point(29, 141);
            this.lbIDProduct.Name = "lbIDProduct";
            this.lbIDProduct.Size = new System.Drawing.Size(86, 25);
            this.lbIDProduct.TabIndex = 0;
            this.lbIDProduct.Text = "Mã món";
            // 
            // grButton
            // 
            this.grButton.Controls.Add(this.btnReset);
            this.grButton.Controls.Add(this.btnCancel);
            this.grButton.Controls.Add(this.btnXoa);
            this.grButton.Controls.Add(this.btnSave);
            this.grButton.Controls.Add(this.btnSua);
            this.grButton.Controls.Add(this.btnThem);
            this.grButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grButton.ForeColor = System.Drawing.SystemColors.Window;
            this.grButton.Location = new System.Drawing.Point(14, 549);
            this.grButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grButton.Name = "grButton";
            this.grButton.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grButton.Size = new System.Drawing.Size(384, 191);
            this.grButton.TabIndex = 0;
            this.grButton.TabStop = false;
            this.grButton.Text = "Chức năng";
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(257, 111);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(107, 49);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(29, 111);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 49);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(257, 51);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(107, 52);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(142, 111);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 49);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(144, 51);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(106, 52);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(29, 51);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(106, 52);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvChiTietMon
            // 
            this.dgvChiTietMon.AllowUserToAddRows = false;
            this.dgvChiTietMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietMon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietMon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvChiTietMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIDProduct,
            this.MaLoaiMon,
            this.colName,
            this.colGia,
            this.colDanhmuc,
            this.colUpdate});
            this.dgvChiTietMon.Location = new System.Drawing.Point(405, 148);
            this.dgvChiTietMon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvChiTietMon.Name = "dgvChiTietMon";
            this.dgvChiTietMon.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietMon.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChiTietMon.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvChiTietMon.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChiTietMon.RowTemplate.Height = 25;
            this.dgvChiTietMon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietMon.Size = new System.Drawing.Size(968, 592);
            this.dgvChiTietMon.TabIndex = 1;
            this.dgvChiTietMon.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietMon_RowEnter);
            // 
            // colIDProduct
            // 
            this.colIDProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colIDProduct.DataPropertyName = "MaMon";
            this.colIDProduct.FillWeight = 121.2692F;
            this.colIDProduct.HeaderText = "Mã món";
            this.colIDProduct.MinimumWidth = 6;
            this.colIDProduct.Name = "colIDProduct";
            this.colIDProduct.ReadOnly = true;
            // 
            // MaLoaiMon
            // 
            this.MaLoaiMon.DataPropertyName = "MaLoaiMon";
            this.MaLoaiMon.HeaderText = "Mã loại món";
            this.MaLoaiMon.MinimumWidth = 6;
            this.MaLoaiMon.Name = "MaLoaiMon";
            this.MaLoaiMon.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "TenMon";
            this.colName.FillWeight = 121.2692F;
            this.colName.HeaderText = "Tên Món";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colGia
            // 
            this.colGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGia.DataPropertyName = "DonGia";
            this.colGia.FillWeight = 121.2692F;
            this.colGia.HeaderText = "Đơn giá";
            this.colGia.MinimumWidth = 6;
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            // 
            // colDanhmuc
            // 
            this.colDanhmuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDanhmuc.DataPropertyName = "TenLoaiMon";
            this.colDanhmuc.FillWeight = 121.2692F;
            this.colDanhmuc.HeaderText = "Danh mục";
            this.colDanhmuc.MinimumWidth = 6;
            this.colDanhmuc.Name = "colDanhmuc";
            this.colDanhmuc.ReadOnly = true;
            // 
            // colUpdate
            // 
            this.colUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUpdate.DataPropertyName = "NgayCapNhat";
            this.colUpdate.HeaderText = "Ngày cập nhật";
            this.colUpdate.MinimumWidth = 6;
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.ReadOnly = true;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lbTitle.Location = new System.Drawing.Point(704, 49);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(280, 41);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "DANH SÁCH MÓN";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(1266, 103);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 40);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_True_Click);
            // 
            // lbDanhmuc1
            // 
            this.lbDanhmuc1.AutoSize = true;
            this.lbDanhmuc1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbDanhmuc1.ForeColor = System.Drawing.SystemColors.Window;
            this.lbDanhmuc1.Location = new System.Drawing.Point(405, 107);
            this.lbDanhmuc1.Name = "lbDanhmuc1";
            this.lbDanhmuc1.Size = new System.Drawing.Size(108, 28);
            this.lbDanhmuc1.TabIndex = 2;
            this.lbDanhmuc1.Text = "Danh mục";
            // 
            // cboCategory1
            // 
            this.cboCategory1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCategory1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboCategory1.FormattingEnabled = true;
            this.cboCategory1.Items.AddRange(new object[] {
            "Tất cả",
            "Đồ chay",
            "Đồ uống",
            "Khai vị",
            "Món chính",
            "Món Súp",
            "Rượu bia",
            "Tráng Miệng"});
            this.cboCategory1.Location = new System.Drawing.Point(522, 101);
            this.cboCategory1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCategory1.Name = "cboCategory1";
            this.cboCategory1.Size = new System.Drawing.Size(219, 36);
            this.cboCategory1.TabIndex = 14;
            this.cboCategory1.SelectedValueChanged += new System.EventHandler(this.cboCategory1_SelectedValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.Location = new System.Drawing.Point(1110, 103);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(149, 34);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // QLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1385, 809);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboCategory1);
            this.Controls.Add(this.lbDanhmuc1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvChiTietMon);
            this.Controls.Add(this.grButton);
            this.Controls.Add(this.grInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLySanPham";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.QLySanPham_Load);
            this.grInfo.ResumeLayout(false);
            this.grInfo.PerformLayout();
            this.grButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grInfo;
        private GroupBox grButton;
        private Label lbTitle;
        private TextBox txtDonGia;
        private TextBox txtTenMon;
        private TextBox txtMaMon;
        private Label lbCategory;
        private Label lbPrices;
        private Label lbName;
        private Label lbIDProduct;
        private Button btnCancel;
        private Button btnXoa;
        private Button btnSave;
        private Button btnSua;
        private Button btnThem;
        private Button btnSearch;
        private Label lbDanhmuc1;
        private ComboBox cboCategory1;
        private TextBox txtSearch;
        private ComboBox cboTenLoaiMon;
        private Button btnReset;
        public DataGridView dgvChiTietMon;
        private Label lblDate;
        private DateTimePicker NgayCapNhat;
        private TextBox txtMaLoaiMon;
        private Label label1;
        private DataGridViewTextBoxColumn colIDProduct;
        private DataGridViewTextBoxColumn MaLoaiMon;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colGia;
        private DataGridViewTextBoxColumn colDanhmuc;
        private DataGridViewTextBoxColumn colUpdate;
    }
}