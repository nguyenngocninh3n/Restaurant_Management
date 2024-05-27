using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace DoAn
{
    public partial class QLyCTTD : Form
    {
        string updateDateHD   = "Update TableTD SET NgayXuatHD = '" + DateTime.Now.ToString() +"'";
        string oldMaMon;
        string oldSoLuong;
        string oldMaCTHD;
        bool modeNew;
        bool check = false;
        bool check3 = false;
        bool check4 = false;
        bool check5 = false;
        string varMaHD;
        Double soluong;
        Double dongia;
        bool isUpdate = false;
        private void SetControls(bool edit)
        {
           
           
            txtMaMon.Enabled = edit;
            txtSoLuong.Enabled = edit;
            btnSave.Enabled = edit;
            btnAdd.Enabled = !edit;
            btnUpdate.Enabled = !edit;
            btnRetry.Enabled = edit;
            btnDelete.Enabled = !edit;
        }
        ConnectSQL conn = new ConnectSQL();
        ConnectSQL conn2 = new ConnectSQL();
        private string sqlStr = "";
        private string sqlStr2 = "";

        int pos;
        public QLyCTTD()
        {
            InitializeComponent();
        }
       
        public QLyCTTD(string maHD)
        {
            InitializeComponent();
            varMaHD = maHD;
        }

       

        private void LoadTable(string MaHD)
        {
            try
            {              
                string sqlStr2 = "SELECT * FROM [dbo].[TableCTTD] Where MaHD = '" + MaHD.ToString() + "'";
                DataTable dt = new DataTable();
                dt = conn.ViewData(sqlStr2);
                if (dt.Rows.Count > 0)
                {
                    dgvCTHD.Visible = true;
                    dgvCTHD.DataSource = dt;
                }                    
                else
                {
                    dgvCTHD.Visible = false;
                    erase();
                }    
            }
            catch (Exception)
            {
            }
        }

        private void QLyCTHD_Load(object sender, EventArgs e)
        {
         
            LoadTable(varMaHD);
            SetControls(false);
            conn.Connect();
        }

        private void dgvCTHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCTHD.RowCount >= 0)
            {
                pos = e.RowIndex;
                if (pos != -1)
                {
                    txtMaCTHD.Text = dgvCTHD.Rows[pos].Cells[1].Value.ToString();
                    txtMaHD.Text = dgvCTHD.Rows[pos].Cells[2].Value.ToString();
                    txtMaMon.Text = dgvCTHD.Rows[pos].Cells[3].Value.ToString();
                    txtTenMon.Text = dgvCTHD.Rows[pos].Cells[4].Value.ToString();
                    txtSoLuong.Text = dgvCTHD.Rows[pos].Cells[6].Value.ToString();
                    txtDonGia.Text = dgvCTHD.Rows[pos].Cells[5].Value.ToString();
                    txtThanhTien.Text = dgvCTHD.Rows[pos].Cells[7].Value.ToString();
                }
            }
            else LoadTable(varMaHD);
        }

       private void setMaCTHD()
        {
            string sqls = "select * from CapPhatID";
            DataTable dtid = new DataTable();
            dtid = conn.ViewData(sqls);
            string maso = dtid.Rows[0][3].ToString();
            int num = Convert.ToInt32(maso);
            if (num < 10) txtMaCTHD.Text = "CT00" + num.ToString();
            else if (num < 100) txtMaCTHD.Text = "CT0" + num.ToString();
            else txtMaCTHD.Text = "CT" + num.ToString();         
        }
        private void setCapPhatID(int num)
        {
            string sqls = "Update [dbo].[CapPhatID] SET IDCTHD =IDCTHD + " + num.ToString();
            conn.Excute(sqls);
        }
        private void updateTongTienHD()
        {
            conn.Connect();
            string strud = "select Sum(ThanhTien) as tien from [dbo].[TableCTTD] where MaHD = '" + txtMaHD.Text + "'";
            DataTable dt1 = new DataTable();
            dt1 = conn.ViewData(strud);
            string tongtin = dt1.Rows[0][0].ToString();         
            string sqls = "Update [dbo].[TableTD] set TongTien = " + tongtin + "Where MaHD = '" + txtMaHD.Text +"'";
            conn.Excute(sqls);

        }
        private void updateTongTienHD(string oldmahd)
        {
           
            string sqls = "Update [dbo].[TableTD] set TongTien = 0 Where MaHD = '" + oldmahd + "'";
            conn.Excute(sqls);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            oldSoLuong = txtSoLuong.Text;
            check = true;
            isUpdate = true;
            oldMaCTHD = txtMaCTHD.Text;
            modeNew = false;
            SetControls(true);
            txtMaCTHD.Focus();
            dgvCTHD.Enabled = false;
            btnRetry.Enabled = false;
        }

        private void ThanhTien()
        {
            if (txtSoLuong.Text == "") txtThanhTien.Text = "";
            else txtThanhTien.Text = (Convert.ToDouble(txtSoLuong.Text) * Convert.ToDouble(txtDonGia.Text)).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            modeNew = true;
            SetControls(true);
            setMaCTHD();
            txtMaHD.Text = varMaHD;
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
            txtMaMon.Focus();
            dgvCTHD.Enabled = false;
            conn2.Connect();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           oldSoLuong = txtSoLuong.Text;
            oldMaMon = txtMaMon.Text;
            int n = dgvCTHD.Rows.Count;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
                string sqlStr1 = "SELECT * FROM TableCTTD";
                DataTable dt = new DataTable();
                dt = conn.GetData(sqlStr1, "TableCTTD");
                if (dt.Rows.Count == 0) return;
                string sqlStr2 = "DELETE FROM TableCTTD WHERE MaCTHD ='" + txtMaCTHD.Text + "'";
                conn.Excute(sqlStr2);

                if (n>2) updateTongTienHD();
                else updateTongTienHD(varMaHD);
                conn.Excute(updateDateHD);
                LoadTable(varMaHD);                          
            }
            else { return; }

        }
        void erase()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            erase();  
            btnAdd_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
            dgvCTHD.Enabled = true;

        }
        
        private void txtMaMon_KeyUp(object sender, KeyEventArgs e)
        { 
            if (txtMaMon.Text != null) check3 = true;
            sqlStr2 = "select * from TbChiTietMon where MaMon like '" + txtMaMon.Text + "%'";
            DataTable dtt = new DataTable();
            dtt = conn2.ViewData(sqlStr2);

            if (dtt.Rows.Count > 0)
            {            
                txtTenMon.Text = dtt.Rows[0][2].ToString();
                dongia = Convert.ToDouble(dtt.Rows[0][3].ToString());
                txtDonGia.Text = dongia.ToString(); 
                if (txtSoLuong.Text != "")
                {
                    soluong = Convert.ToDouble(txtSoLuong.Text);
                    txtThanhTien.Text = (soluong * dongia).ToString();
                }
            }
            else txtTenMon.PlaceholderText = "Món không tồn tại!";

        }

        private void txtSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSoLuong.Text != null) check4 = true;

            if (txtSoLuong.Text != "")
            {
                double soluong2 = Convert.ToDouble(txtSoLuong.Text);
                txtThanhTien.Text = (soluong2 * dongia).ToString();
                conn.Connect();
              
            }
        }

        private void txtTenMon_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenMon.Text != null) check5 = true;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadTable(varMaHD);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            dgvCTHD.Enabled = false;
            string sqlStr3 = "";
            oldMaMon = txtMaMon.Text;             
                
            if(txtTenMon.Text=="")
            {
                MessageBox.Show("Món không tồn tại!");
                return;
            }

            if (txtSoLuong.Text == "" || txtSoLuong.Text == "0")
            {
                MessageBox.Show("Hãy nhập số lượng!");
                return;
            }

            if (modeNew == true && check3 == true && check4 == true)
            {
                ThanhTien();
                sqlStr3 = "INSERT INTO [dbo].[TableCTTD]([MaCTHD],[MaHD],[MaMon],[TenMon],[SoLuong],[DonGia],[ThanhTien]) VALUES ('" + txtMaCTHD.Text + "','" + txtMaHD.Text + "', '" + txtMaMon.Text + "', N'" + txtTenMon.Text + "','" + txtSoLuong.Text + "','" + txtDonGia.Text + "','" + txtThanhTien.Text + "')";
                MessageBox.Show("Thêm thành công");
                isAdd = true;
            }
            else if (txtTenMon.Text == "Món không tồn tại!")
            {
                MessageBox.Show("Không có món này.");
                return;
            }
            else
            {              
                ThanhTien();
                MessageBox.Show("Đã cập nhật chi tiết thực đơn");
                sqlStr3 = "UPDATE [dbo].[TableCTTD] SET  MaMon = '" + txtMaMon.Text +
               "',TenMon = N'" + txtTenMon.Text +
               "',SoLuong = '" + txtSoLuong.Text +
               "',ThanhTien ='" + txtThanhTien.Text + "'"

               + "Where MaCTHD = '" + txtMaCTHD.Text + "'";
                isUpdate = true;
            }
            try
            {
                conn.Excute(sqlStr3);
                LoadTable(txtMaHD.Text);
                conn.Excute(updateDateHD);

            }
            catch (Exception)
            {
                isAdd = false;
                isUpdate = false;
                

            }
            finally
            {
                if (isAdd)
                {
                    setCapPhatID(1);
                    updateTongTienHD();
                }
                if(isUpdate)
                {
                    updateTongTienHD();
                }    
                SetControls(false);
                dgvCTHD.Enabled = true;
                LoadTable(txtMaHD.Text);

            }
        }

        private void QLyCTHD_FormClosed(object sender, FormClosedEventArgs e)
        {
            QLyHoaDon qlhd = new QLyHoaDon();
            qlhd.LoadTable();

        }
    }
}
