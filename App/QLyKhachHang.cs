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
    public partial class QLyKhachHang : Form
    {
        string oldSDT;
        string text = "aAbBcCdDeEfFgGhHiIjJhHkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ01234567890123456789";
        bool modeNew;
        bool check = false;
        bool check1 = false;
        bool check2 = false;
        bool check3 = false;
        bool check4 = false;
        private void SetControls(bool edit)
        {
            txtName.Enabled = edit;
            txtAddress.Enabled = edit;
            txtSDT.Enabled = edit;
            rbtnFemale.Enabled = edit;
            rbtnMale.Enabled = edit;
            btnSave.Enabled = edit;
            btnAdd.Enabled = !edit;
            btnUpdate.Enabled = !edit;
            btnRetry.Enabled = edit;
            btnDelete.Enabled = !edit;
        }
        ConnectSQL conn = new ConnectSQL();
        public string sqlStr = "";
        int pos;
        public QLyKhachHang()
        {
            InitializeComponent();
        }

        public void LoadTable()
        {
            try
            {
                //SqlConnection conn1 = new SqlConnection();
                //conn1.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                sqlStr = "SELECT * FROM TableCustomer";
                dgvKH.DataSource = conn.GetData(sqlStr, "TableCustomer");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadTable();
            SetControls(false);
            conn.Connect();
            picTrue.Hide();
            picTrue1.Hide();
            picFalse.Hide();
            picFalse1.Hide();
           
        }

        private void dgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKH.RowCount >= 0)
            {
                pos = e.RowIndex;
                if (pos != -1)
                {
                    txtName.Text = dgvKH.Rows[pos].Cells[1].Value.ToString();
                    txtAddress.Text = dgvKH.Rows[pos].Cells[3].Value.ToString();
                    if (string.Compare(dgvKH.Rows[pos].Cells[4].Value.ToString(), rbtnMale.Text, true) == 0)
                    {
                        rbtnMale.Checked = true;
                    }
                    else
                    {
                        rbtnFemale.Checked = true;
                    }
                    txtSDT.Text = dgvKH.Rows[pos].Cells[2].Value.ToString();
                }

            }
            else LoadTable();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Enable_Search(false);
            oldSDT = txtSDT.Text;
            modeNew = false;
            SetControls(true);
            txtSDT.Enabled = false;
            txtName.Focus();
            
        }

        private void Enable_Search(bool edit)
        {
            txtSearch.Enabled = edit;
            btnSearch.Enabled = edit;
            btnHuy.Enabled = edit;
            dgvKH.Enabled = edit;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Enable_Search(false);
            modeNew = true;
            SetControls(true);
            txtName.Text = "";
            txtAddress.Text = "";
            txtSDT.Text = "";
            rbtnFemale.Checked = false;
            rbtnMale.Checked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
                string sqlStr1 = "SELECT * FROM TableCustomer";
                DataTable dt = new DataTable();
                dt = conn.GetData(sqlStr1, "TableCustomer");
                if (dt.Rows.Count == 0) return;
                string sqlStr2 = "DELETE FROM TableCustomer WHERE SDT ='" + txtSDT.Text + "'";
                conn.Excute(sqlStr2);
                LoadTable();
            }
            else { return; }
            
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtAddress.Text = null;
            txtSDT.Text = null;
            rbtnFemale.Checked = true;
            rbtnMale.Checked = false;
            LoadTable();
        }
 
        static string Shuffle(string input)
        {
            var q = from c in input.ToCharArray()
                    orderby Guid.NewGuid()
                    select c;
            string s = string.Empty;
            foreach (var r in q)
                s += r;
            return s;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControls(false);
            Enable_Search(true);

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        
        private bool ValidPN(string pn)
        {
            {
                string formatpn = @"^(0(\d){9})$";
                Regex regex = new Regex(formatpn);
                if (regex.IsMatch(pn.Trim()))
                {
                    return true;
                }
            }
            return false;
        }
        private void txtSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                picTrue1.Hide();
                picFalse1.Hide();
            }
            else
            {
                if (ValidPN(txtSDT.Text))
                {
                    picTrue1.Show();
                    picFalse1.Hide();
                    check1 = true;
                }
                else
                {
                    check1 = false;
                    picTrue1.Hide();
                    picFalse1.Show();
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtName.Text != null) check2 = true;
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAddress.Text != null) check3 = true;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sqlStr1 = "SELECT * FROM TableCustomer Where Name like N'%" +txtSearch.Text + "%'";
            DataTable dt = new DataTable();
            dt = conn.ViewData(sqlStr1);
            if (dt.Rows.Count <= 0)
            {
                string sqlStr2 = "SELECT * FROM TableCustomer Where SDT like '%" + txtSearch.Text + "%'";
                dt = conn.ViewData(sqlStr2);
            }  
            dgvKH.DataSource = dt;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Enable_Search(true);
            SetControls(false);
            string sqlStr3 = "";

            if (txtName.Text == "" || txtSDT.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                Enable_Search(true);
                return;
            }
            else if (txtSDT.TextLength != 10)
            {
                MessageBox.Show("SDT phải đủ 10 số và bắt đầu bằng số 0");
                Enable_Search(true);
                return;
            }
            else if (modeNew == true && check1 == true && check2 == true && check3 == true)
            {
                if (rbtnMale.Checked)
                    sqlStr3 = "INSERT INTO [dbo].[TableCustomer]([Name],[SDT],[Address],[GT],[DateUpdated]) VALUES (N'" + txtName.Text + "','" + txtSDT.Text + "', N'" + txtAddress.Text + "','" + rbtnMale.Text + "'," + "GetDate()" + ")";
                else
                    sqlStr3 = "INSERT INTO [dbo].[TableCustomer]([Name],[SDT],[Address],[GT],[DateUpdated]) VALUES (N'" + txtName.Text + "','" + txtSDT.Text + "', N'" + txtAddress.Text + "', N'" + rbtnFemale.Text + "'," + "GetDate()" + ")";
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                if (rbtnMale.Checked)
                    sqlStr3 = "UPDATE [dbo].[TableCustomer] SET Name = N'" + txtName.Text +
                    "',Address = N'" + txtAddress.Text +
                    "',GT ='" + rbtnMale.Text +
                    "',SDT ='" + txtSDT.Text +
                    "',DateUpdated = " + "GetDate()" + " WHERE SDT = '" + oldSDT + "'";
                else
                    sqlStr3 = "UPDATE [dbo].[TableCustomer] SET Name = N'" + txtName.Text +
                   "',Address = N'" + txtAddress.Text +
                   "',GT = N'" + rbtnFemale.Text +
                   "',SDT ='" + txtSDT.Text +
                   "',DateUpdated = " + "GetDate()" + " WHERE SDT = '" + oldSDT + "'";

            }
            try
            {
                conn.Excute(sqlStr3);
                LoadTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                SetControls(false);
                LoadTable();
                picTrue.Hide();
                picTrue1.Hide();
                picFalse.Hide();
                picFalse1.Hide();
            }
        }
    }
}
