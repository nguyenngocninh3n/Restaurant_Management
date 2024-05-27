using System.Data;
namespace DoAn
{
    public partial class QLySanPham : Form
    {

        private string sqlStr = "";
        string oldID;
        string sqlStr3 = "";
        bool modeNew;
        int pos, newStt, lastrow;
        ConnectSQL conn = new ConnectSQL();
        public QLySanPham()
        {
            InitializeComponent(); 
        }
        private void SetControls(bool edit)
        {
            txtMaMon.Enabled = edit;
            txtMaLoaiMon.Enabled = false;
            txtTenMon.Enabled = edit;
            cboTenLoaiMon.Enabled = edit;
            txtDonGia.Enabled = edit;
            NgayCapNhat.Enabled = edit;
            btnSave.Enabled = edit;
            btnThem.Enabled = !edit;
            btnSua.Enabled = !edit;
            btnReset.Enabled = edit;
            btnXoa.Enabled = !edit;
        }


        void SetLock(bool edit)
        {
            btnThem.Enabled = edit;
            btnSua.Enabled = edit;
            btnXoa.Enabled = edit;
            btnCancel.Enabled = edit;
            btnReset.Enabled = edit;
            btnSave.Enabled = edit;
        }

        void PhanQuyen()
        {
            if (Main.chucVu != 'Q' && Main.chucVu != 'A')
                SetLock(false);
        }
        public void LoadTable()
        {
            try
            {
                ViewDGV("Tất cả");
                PhanQuyen();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QLySanPham_Load(object sender, EventArgs e)
        {
            LoadTable();
            SetControls(false);
            conn.Connect();
            cboTenLoaiMon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory1.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory1.SelectedIndex = 0;
            PhanQuyen();
        }

        private void dgvChiTietMon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietMon.RowCount >= 0)
            {
                pos = e.RowIndex;
                if (pos != -1)
                {                  
                    txtMaMon.Text = dgvChiTietMon.Rows[pos].Cells[0].Value.ToString();
                    txtMaLoaiMon.Text = dgvChiTietMon.Rows[pos].Cells[1].Value.ToString();
                    txtTenMon.Text = dgvChiTietMon.Rows[pos].Cells[2].Value.ToString();
                    txtDonGia.Text = dgvChiTietMon.Rows[pos].Cells[3].Value.ToString();
                    cboTenLoaiMon.Text = dgvChiTietMon.Rows[pos].Cells[6].Value.ToString();
                    NgayCapNhat.Value = Convert.ToDateTime(dgvChiTietMon.Rows[pos].Cells[5].Value);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            oldID = txtMaMon.Text;
            if (dgvChiTietMon.Rows.Count == 1)
            {
                newStt = 1;
            }
            else
            {
                lastrow = dgvChiTietMon.Rows.Count - 1;
            }
            txtMaMon.Text = "";
            txtMaLoaiMon.Text = GetMaLoaiMon(cboTenLoaiMon.Text);
            modeNew = true;
            SetControls(true);
            txtTenMon.Text = "";
            cboTenLoaiMon.Text = "";
            txtDonGia.Text = "";
            NgayCapNhat.Value = DateTime.Now;
            dgvChiTietMon.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            oldID = txtMaMon.Text;
            modeNew = false;
            SetControls(true);
            cboTenLoaiMon.Enabled = true;
            txtMaMon.Focus();
            dgvChiTietMon.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
                string sqlStr1 = "SELECT * FROM TbChiTietMon";
                DataTable dt = new DataTable();
                dt = conn.GetData(sqlStr1, "TbChiTietMon");
                if (dt.Rows.Count == 0) return;
                string sqlStr2 = "DELETE FROM TbChiTietMon WHERE MaMon ='" + txtMaMon.Text + "'";
                conn.Excute(sqlStr2);
                LoadTable();

            }
            else { return; }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = "";
            txtMaLoaiMon.Text = "";
            txtTenMon.Text = "";
            txtDonGia.Text = "";
            cboTenLoaiMon.Text = "";
            NgayCapNhat.Text = "";
            cboTenLoaiMon.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
            dgvChiTietMon.Enabled = true;
        }

        private void txtPrices_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private string GetMaLoaiMon(string text)
        {
            string sqlStr1 = "SELECT MaLoaiMon FROM TbPhanLoaiMon WHERE(TenLoaiMon = N'" + text + "')";
            DataTable dt1 = conn.ViewData(sqlStr1);
            string maloaimon = dt1.Rows[0][0].ToString();
            return maloaimon;
        }

        private void ViewSearch(string text)
        {
           DataTable dt2 = new DataTable();
            string sqlStr2;
            sqlStr2 = "SELECT TbChiTietMon.*, TbPhanLoaiMon.TenLoaiMon FROM TbChiTietMon inner join TbPhanLoaiMon on TbChiTietMon.MaLoaiMon = TBPhanLoaiMon.MaLoaiMon WHERE( TbChiTietMon.MaLoaiMon = '" + text + "')";
            dt2 = conn.ViewData(sqlStr2);
            if(dt2.Rows.Count > 0)
                dgvChiTietMon.DataSource = dt2;
            else
            {
                 sqlStr2 = "SELECT TbChiTietMon.*, TbPhanLoaiMon.TenLoaiMon FROM TbChiTietMon inner join TbPhanLoaiMon on TbChiTietMon.MaLoaiMon = TBPhanLoaiMon.MaLoaiMon WHERE( TbChiTietMon.MaMon = '" + text + "')";
                dt2 = conn.ViewData(sqlStr2);
                dgvChiTietMon.DataSource = dt2;
            }
        }
        private void ViewDGV(string text)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            if (text == "Tất cả")
            {
                string sqlStr2 = "SELECT TbChiTietMon.*,TenLoaiMon FROM TbChiTietMon,TbPhanLoaiMon WHERE TbChiTietMon.MaLoaiMon = TBPhanLoaiMon.MaLoaiMon";
                dt2 = conn.ViewData(sqlStr2);
                dgvChiTietMon.DataSource = dt2;
            }  
            else
            {
                
                string maloaimon = GetMaLoaiMon(text);
                string sqlStr2 = "SELECT TbChiTietMon.*, TbPhanLoaiMon.TenLoaiMon FROM TbChiTietMon inner join TbPhanLoaiMon on TbChiTietMon.MaLoaiMon = TBPhanLoaiMon.MaLoaiMon WHERE( TbChiTietMon.MaLoaiMon = '" + maloaimon + "')";
                dt2 = conn.ViewData(sqlStr2);
                dgvChiTietMon.DataSource = dt2;

            }    
        }

        private void cboCategory1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox) sender;
            string h = cbo.Text;
            ViewDGV(h);
        }

        private void cboTenLoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)(sender);
            txtMaLoaiMon.Text = GetMaLoaiMon(cbo.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_True_Click(object sender, EventArgs e)
        {
            ViewSearch(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (modeNew && txtTenMon.Text != null && txtMaMon.Text != null && txtMaLoaiMon.Text != null && txtDonGia.Text != null && NgayCapNhat.Text != "" && cboTenLoaiMon.Text != null)
            {
                sqlStr3 = "INSERT INTO [dbo].[TbChiTietMon]([MaMon],[MaLoaiMon],[TenMon],[DonGia],[NgayCapNhat]) VALUES ('"
                    + txtMaMon.Text + "', '"
                    + txtMaLoaiMon.Text + "', N'"
                    + txtTenMon.Text + "', "
                    + txtDonGia.Text + ",'"
                    + NgayCapNhat.Text + "')";
               
                dgvChiTietMon.Enabled = true;
            }
            else
            {
                sqlStr3 = "UPDATE [dbo].[TbChiTietMon] SET " +
               " MaMon = '" + txtMaMon.Text +
               "',TenMon = N'" + txtTenMon.Text +
               "',MaLoaiMon = '" + txtMaLoaiMon.Text +
               "',DonGia ='" + txtDonGia.Text +
               "',NgayCapNhat = " + "GetDate()" + " WHERE MaMon = '" + oldID + "'";
            }
            try
            {
                conn.Excute(sqlStr3);
                LoadTable();
                if(modeNew) MessageBox.Show("Thêm thành công");
                else MessageBox.Show("Cập nhật thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                SetControls(false);
                LoadTable();
            }
        }
    }
}
