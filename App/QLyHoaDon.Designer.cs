namespace DoAn
{
    partial class QLyHoaDon
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLyHoaDon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbHoaDon = new System.Windows.Forms.GroupBox();
            this.cbBoxBan = new System.Windows.Forms.ComboBox();
            this.mtDatetime = new System.Windows.Forms.DateTimePicker();
            this.cbBoxMaNV = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnXemCTHD = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lbSDT = new System.Windows.Forms.Label();
            this.lblChonBan = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayXuatHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbList = new System.Windows.Forms.Label();
            this.connectSQLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectSQLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbHoaDon
            // 
            this.grbHoaDon.Controls.Add(this.cbBoxBan);
            this.grbHoaDon.Controls.Add(this.mtDatetime);
            this.grbHoaDon.Controls.Add(this.cbBoxMaNV);
            this.grbHoaDon.Controls.Add(this.txtSearch);
            this.grbHoaDon.Controls.Add(this.btnXemCTHD);
            this.grbHoaDon.Controls.Add(this.btnHuy);
            this.grbHoaDon.Controls.Add(this.btnSearch);
            this.grbHoaDon.Controls.Add(this.btnCancel);
            this.grbHoaDon.Controls.Add(this.btnAdd);
            this.grbHoaDon.Controls.Add(this.btnSave);
            this.grbHoaDon.Controls.Add(this.btnRetry);
            this.grbHoaDon.Controls.Add(this.btnDelete);
            this.grbHoaDon.Controls.Add(this.btnUpdate);
            this.grbHoaDon.Controls.Add(this.lbSDT);
            this.grbHoaDon.Controls.Add(this.lblChonBan);
            this.grbHoaDon.Controls.Add(this.lbEmail);
            this.grbHoaDon.Controls.Add(this.txtTongTien);
            this.grbHoaDon.Controls.Add(this.label2);
            this.grbHoaDon.Controls.Add(this.label1);
            this.grbHoaDon.Controls.Add(this.txtMaHD);
            this.grbHoaDon.Controls.Add(this.lbName);
            this.grbHoaDon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grbHoaDon.ForeColor = System.Drawing.Color.White;
            this.grbHoaDon.Location = new System.Drawing.Point(110, 16);
            this.grbHoaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbHoaDon.Name = "grbHoaDon";
            this.grbHoaDon.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbHoaDon.Size = new System.Drawing.Size(978, 356);
            this.grbHoaDon.TabIndex = 0;
            this.grbHoaDon.TabStop = false;
            this.grbHoaDon.Text = "Thông tin hóa đơn";
            // 
            // cbBoxBan
            // 
            this.cbBoxBan.FormattingEnabled = true;
            this.cbBoxBan.Items.AddRange(new object[] {
            "Bàn 01",
            "Bàn 02",
            "Bàn 03",
            "Bàn 04",
            "Bàn 05",
            "Bàn 06",
            "Bàn 07",
            "Bàn 08",
            "Bàn 09",
            "Bàn 10",
            "Bàn 11",
            "Bàn 12",
            "Bàn 13",
            "Bàn 14",
            "Bàn 15",
            "Bàn 16"});
            this.cbBoxBan.Location = new System.Drawing.Point(647, 101);
            this.cbBoxBan.Name = "cbBoxBan";
            this.cbBoxBan.Size = new System.Drawing.Size(167, 33);
            this.cbBoxBan.TabIndex = 27;
            this.cbBoxBan.SelectedIndexChanged += new System.EventHandler(this.cbBoxBan_SelectedIndexChanged);
            // 
            // mtDatetime
            // 
            this.mtDatetime.CustomFormat = "yyyy-MM-dd";
            this.mtDatetime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mtDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mtDatetime.Location = new System.Drawing.Point(162, 160);
            this.mtDatetime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mtDatetime.Name = "mtDatetime";
            this.mtDatetime.Size = new System.Drawing.Size(130, 32);
            this.mtDatetime.TabIndex = 26;
            // 
            // cbBoxMaNV
            // 
            this.cbBoxMaNV.FormattingEnabled = true;
            this.cbBoxMaNV.Location = new System.Drawing.Point(647, 45);
            this.cbBoxMaNV.Name = "cbBoxMaNV";
            this.cbBoxMaNV.Size = new System.Drawing.Size(278, 33);
            this.cbBoxMaNV.TabIndex = 25;
            this.cbBoxMaNV.SelectedIndexChanged += new System.EventHandler(this.cbBoxMaNV_SelectedIndexChanged);
            this.cbBoxMaNV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbBoxMaNV_KeyUp);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(29, 227);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Nhập Mã HD/ Mã NV/Mã KH bất kì";
            this.txtSearch.Size = new System.Drawing.Size(369, 32);
            this.txtSearch.TabIndex = 20;
            // 
            // btnXemCTHD
            // 
            this.btnXemCTHD.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnXemCTHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemCTHD.Image = ((System.Drawing.Image)(resources.GetObject("btnXemCTHD.Image")));
            this.btnXemCTHD.Location = new System.Drawing.Point(297, 275);
            this.btnXemCTHD.Name = "btnXemCTHD";
            this.btnXemCTHD.Size = new System.Drawing.Size(101, 43);
            this.btnXemCTHD.TabIndex = 19;
            this.btnXemCTHD.Text = "Chi tiết";
            this.btnXemCTHD.UseVisualStyleBackColor = false;
            this.btnXemCTHD.Click += new System.EventHandler(this.btnXemCTHD_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.Location = new System.Drawing.Point(162, 275);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(101, 43);
            this.btnHuy.TabIndex = 19;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(29, 276);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 43);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Tra cứu";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(823, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 44);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(523, 179);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 44);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(823, 276);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 44);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetry.Image = ((System.Drawing.Image)(resources.GetObject("btnRetry.Image")));
            this.btnRetry.Location = new System.Drawing.Point(676, 276);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(102, 44);
            this.btnRetry.TabIndex = 13;
            this.btnRetry.Text = "Khởi tạo";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(676, 179);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 44);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(523, 276);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 44);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lbSDT
            // 
            this.lbSDT.AutoSize = true;
            this.lbSDT.Location = new System.Drawing.Point(523, 51);
            this.lbSDT.Name = "lbSDT";
            this.lbSDT.Size = new System.Drawing.Size(78, 25);
            this.lbSDT.TabIndex = 0;
            this.lbSDT.Text = "Mã NV:";
            // 
            // lblChonBan
            // 
            this.lblChonBan.AutoSize = true;
            this.lblChonBan.Location = new System.Drawing.Point(522, 104);
            this.lblChonBan.Name = "lblChonBan";
            this.lblChonBan.Size = new System.Drawing.Size(51, 25);
            this.lblChonBan.TabIndex = 0;
            this.lblChonBan.Text = "Bàn:";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(523, 101);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(0, 25);
            this.lbEmail.TabIndex = 0;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTongTien.Location = new System.Drawing.Point(162, 107);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.PlaceholderText = "Tổng giá trị hóa đơn";
            this.txtTongTien.Size = new System.Drawing.Size(277, 32);
            this.txtTongTien.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày xuất HD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng tiền";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaHD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaHD.Location = new System.Drawing.Point(162, 49);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.PlaceholderText = "Nhập mã hóa đơn";
            this.txtMaHD.Size = new System.Drawing.Size(277, 32);
            this.txtMaHD.TabIndex = 2;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(21, 56);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(79, 25);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Mã HD:";
            // 
            // dgvHD
            // 
            this.dgvHD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvHD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvHD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHD.ColumnHeadersHeight = 40;
            this.dgvHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaHD,
            this.colMaNV,
            this.colTenBan,
            this.colTongTien,
            this.colNgayXuatHD});
            this.dgvHD.Location = new System.Drawing.Point(110, 420);
            this.dgvHD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHD.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHD.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHD.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHD.RowTemplate.Height = 25;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.Size = new System.Drawing.Size(978, 433);
            this.dgvHD.TabIndex = 1;
            this.dgvHD.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHD_RowEnter);
            // 
            // colSTT
            // 
            this.colSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSTT.DataPropertyName = "ID";
            this.colSTT.FillWeight = 42.90066F;
            this.colSTT.HeaderText = "STT";
            this.colSTT.MinimumWidth = 6;
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Visible = false;
            // 
            // colMaHD
            // 
            this.colMaHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaHD.DataPropertyName = "MaHD";
            this.colMaHD.FillWeight = 114.606F;
            this.colMaHD.HeaderText = "Mã hóa đơn";
            this.colMaHD.MinimumWidth = 6;
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            // 
            // colMaNV
            // 
            this.colMaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.FillWeight = 114.606F;
            this.colMaNV.HeaderText = "Mã nhân viên";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.ReadOnly = true;
            // 
            // colTenBan
            // 
            this.colTenBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenBan.DataPropertyName = "TenBan";
            this.colTenBan.FillWeight = 114.606F;
            this.colTenBan.HeaderText = "Tên bàn";
            this.colTenBan.MinimumWidth = 6;
            this.colTenBan.Name = "colTenBan";
            this.colTenBan.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTongTien.DataPropertyName = "TongTien";
            this.colTongTien.FillWeight = 82.5465F;
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colNgayXuatHD
            // 
            this.colNgayXuatHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNgayXuatHD.DataPropertyName = "NgayXuatHD";
            this.colNgayXuatHD.HeaderText = "Ngày xuất hóa đơn";
            this.colNgayXuatHD.MinimumWidth = 6;
            this.colNgayXuatHD.Name = "colNgayXuatHD";
            this.colNgayXuatHD.ReadOnly = true;
            // 
            // lbList
            // 
            this.lbList.AutoSize = true;
            this.lbList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbList.ForeColor = System.Drawing.SystemColors.Window;
            this.lbList.Location = new System.Drawing.Point(470, 376);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(259, 37);
            this.lbList.TabIndex = 2;
            this.lbList.Text = "Danh sách hóa đơn";
            // 
            // connectSQLBindingSource
            // 
            this.connectSQLBindingSource.DataSource = typeof(DoAn.ConnectSQL);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(407, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // QLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(1218, 861);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbList);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.grbHoaDon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QLyHoaDon";
            this.Text = "Quản lý hóa đơn";
            this.Load += new System.EventHandler(this.QLyHoaDon_Load);
            this.grbHoaDon.ResumeLayout(false);
            this.grbHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connectSQLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grbHoaDon;
        private Label lbSDT;
        private Label lbEmail;
        private TextBox txtMaHD;
        private Label lbName;
        private Button btnRetry;
        private Button btnDelete;
        private Button btnUpdate;
        private Label lbList;
        private Label lblChonBan;
        private Button btnAdd;
        private Button btnCancel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnHuy;
        private TextBox txtTongTien;
        private Label label1;
        private Label label2;
        private Button btnXemCTHD;
        private ComboBox cbBoxMaNV;
        private BindingSource connectSQLBindingSource;
        public DataGridView dgvHD;
        private Button btnSave;
        private DateTimePicker mtDatetime;
        private PictureBox pictureBox1;
        private ComboBox cbBoxBan;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colMaHD;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colTenBan;
        private DataGridViewTextBoxColumn colTongTien;
        private DataGridViewTextBoxColumn colNgayXuatHD;
    }
}