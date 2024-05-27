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
    public partial class QLyHoaDon : Form
    {
        string oldMa;
        string varMaHD;

        bool modeNew;
        bool check = false;
        
        bool check2 = false;
        bool check3 = false;
       
        private void SetControls(bool edit)
        {
            
            cbBoxBan.Enabled = edit;
            cbBoxMaNV.Enabled = edit;          
            mtDatetime.Enabled = edit;
            btnSave.Enabled = edit;
            btnAdd.Enabled = !edit;
            btnUpdate.Enabled = !edit;
            btnRetry.Enabled = edit;
            btnDelete.Enabled = !edit;
        }
        ConnectSQL conn = new ConnectSQL();
        ConnectSQL conn2 = new ConnectSQL();
        public string sqlStr = "";
        int pos;
        public QLyHoaDon()
        {
            InitializeComponent();
        }

        public void LoadTable()
        {
            try
            {
                sqlStr = "SELECT * FROM TableHD";
                DataTable dt = new DataTable();
                dt= conn.GetData(sqlStr, "TableHD");
                if(dt.Rows.Count>=0) dgvHD.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         void QLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadTable();
            SetControls(false);
            conn.Connect();
            conn2.Connect();
            cbBoxMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            string sqlStrcb = "SELECT * FROM TableNV";
            cbBoxMaNV.DataSource = conn2.GetData(sqlStrcb, "TableNV");
            cbBoxMaNV.DisplayMember = "MaNV";
            cbBoxMaNV.ValueMember = "MaNV";
            cbBoxMaNV.Text = "";
            varMaHD = txtMaHD.Text;
        }

        private void dgvHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHD.RowCount >= 0)
            {
                pos = e.RowIndex;
                if (pos != -1)
                {
                    
                    txtMaHD.Text     = dgvHD.Rows[pos].Cells[1].Value.ToString();                                                       
                    cbBoxMaNV.Text   = dgvHD.Rows[pos].Cells[2].Value.ToString();
                    cbBoxBan.Text    = dgvHD.Rows[pos].Cells[3].Value.ToString();
                    txtTongTien.Text = dgvHD.Rows[pos].Cells[4].Value.ToString();
                    mtDatetime.Value = Convert.ToDateTime(dgvHD.Rows[pos].Cells[5].Value);
                }
                else
                {
                    txtMaHD.Text = "";
                    cbBoxMaNV.Text = null;
                    cbBoxBan.Text = "";
                    txtTongTien.Text = "";
                    mtDatetime.Text = DateTime.Now.ToString();
                }    
            }
            else LoadTable();
        }

        private void Enable_Search(bool edit)
        {
            txtSearch.Enabled = edit;
            btnSearch.Enabled = edit;
            btnHuy.Enabled = edit;
            btnXemCTHD.Enabled = edit;
            dgvHD.Enabled = edit;
            txtMaHD.Enabled = edit;
        }

        private void setMaHD()
        {
            string sqls = "select * from CapPhatID";
            DataTable dtid = new DataTable();
            dtid = conn.ViewData(sqls);
            string maso = dtid.Rows[0][2].ToString();
            int num = Convert.ToInt32(maso);
            if (num < 10) txtMaHD.Text = "HD00" + num.ToString();
            else if (num < 100) txtMaHD.Text = "HD0" + num.ToString();
            else txtMaHD.Text = "HD" + num.ToString();

        }
        private void setCapPhatID(int num)
        {
            string sqls = "Update [dbo].[CapPhatID] SET IDHD =IDHD + " + num.ToString();
            conn.Excute(sqls);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Enable_Search(false);
            oldMa = txtMaHD.Text;
            modeNew = false;
            SetControls(true);
            txtMaHD.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Enable_Search(false);
            modeNew = true;
            SetControls(true);
            setMaHD();
            cbBoxBan.Text = "";
            cbBoxMaNV.Text = null; 
            txtTongTien.Text = "";
            mtDatetime.Text =  DateTime.Now.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
                string sqlStr1 = "SELECT * FROM TableHD";
                DataTable dt = new DataTable();
                dt = conn.GetData(sqlStr1, "TableHD");
                if (dt.Rows.Count == 0) return;
                string sqlStr2 = "DELETE FROM TableHD WHERE MaHD ='" + txtMaHD.Text + "'";
                conn.Excute(sqlStr2);
                QLyHoaDon_Load(sender, e);
            }
            else { return; }
            
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            cbBoxBan.Text = "";
            cbBoxMaNV.Text = null;
            txtTongTien.Text = "";
            mtDatetime.Value = Convert.ToDateTime(DateTime.Now.ToString());
            LoadTable();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
            Enable_Search(true);
            int t = dgvHD.SelectedRows.Count;
            txtMaHD.Text = dgvHD.Rows[t-1].Cells[1].Value.ToString();

        }

        private void cbBoxMaNV_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbBoxMaNV.Text != null) check2 = true;
        }

      

        private void cbBoxBan_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbBoxBan.Text != null) check3 = true;
        }
     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlStr1 = "SELECT * FROM TableHD Where MaHD like N'%" +txtSearch.Text + "%'";
            DataTable dt = new DataTable();
            dt = conn.ViewData(sqlStr1);
            if (dt.Rows.Count <= 0)
            {
                string sqlStr2 = "SELECT * FROM TableHD Where MaNV like '%" + txtSearch.Text + "%'";
                dt = conn.ViewData(sqlStr2);
            }
            if (dt.Rows.Count <= 0)
            {
                string sqlStr3 = "SELECT * FROM TableHD Where TenBan like N'%" + txtSearch.Text + "%'";
                dt = conn.ViewData(sqlStr3);
            }
            dgvHD.DataSource = dt;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private  void reload()
        {
            this.Refresh();
        }    

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            if(dgvHD.SelectedRows.Count <=0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem chi tiết");
            } 
            else
            {
                   QLyCTHD qLyCTHD = new QLyCTHD(txtMaHD.Text);
                   qLyCTHD.Show();
                   
     
            }    
        }

      

        private void cbBoxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (cbBoxMaNV.Text != null) check2 = true;
        }

        private void cbBoxBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxBan.Text != null) check3 = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            Enable_Search(true);
            SetControls(false);
            string sqlStr3 = "";
            if (txtMaHD.Text == null || cbBoxBan.Text == "" || cbBoxMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                Enable_Search(true);
                return;
            }
            if (modeNew == true && check2 == true && check3 == true)
            {
                varMaHD = txtMaHD.Text;
                sqlStr3 = "INSERT INTO [dbo].[TableHD]([MaHD],[MaNV],[TenBan],[TongTien],[NgayXuatHD]) VALUES ('" + txtMaHD.Text + "','" + cbBoxMaNV.SelectedValue + "', N'" + cbBoxBan.Text + "'," + 0 + ",'" + mtDatetime.Text + "')";
                
                isAdd = true;
            }
            else
            {

                sqlStr3 = "UPDATE [dbo].[TableHD] SET MaNV = '" + cbBoxMaNV.SelectedValue +
               "',TenBan = N'" + cbBoxBan.Text +
               "',NgayXuatHD = '" + mtDatetime.Text + "' WHERE MaHD = '" + oldMa + "'";

            }
            try
            {
                conn.Excute(sqlStr3);
                MessageBox.Show("Thêm thành công");
                LoadTable();

            }
            catch (Exception)
            {
                isAdd = false;
                MessageBox.Show("Lỗi");

            }
            finally
            {
                SetControls(false);
                LoadTable();
                if (isAdd)
                {
                    setCapPhatID(1);
                    QLyCTHD qLyCTHD = new QLyCTHD(varMaHD);
                    qLyCTHD.Show();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            QLyHoaDon_Load(sender, e);
            
        }

        private void cbBoxBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
