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
using System.Security.Cryptography;
namespace DoAn
{
    public partial class QLyNhanVien : Form
    {
       
        string oldID;
        string text = "aAbBcCdDeEfFgGhHiIjJhHkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ01234567890123456789";
        bool modeNew;
        bool check = false;
        bool check1 = false;
        bool check2 = false;
        bool check3 = false;
        bool check4 = false;
        int idLength = 3;
        string sqlStr3 = "";
        string sqlStr4 = "";
        int lastrow;
        int newStt;
        public static string EncryptPassword(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                key.Append(hash[i].ToString("x2"));
            }
            return key.ToString();
        }
        private void SetControls(bool edit)
        {
            txtName.Enabled = edit;
            txtAddress.Enabled = edit;
            txtEmail.Enabled = edit;
            txtSDT.Enabled = edit;
            rbtnFemale.Enabled = edit;
            rbtnMale.Enabled = edit;
            dtBirthday.Enabled = edit;
            cbxChucvu.Enabled = edit;
            btnSave.Enabled = edit;
            btnAdd.Enabled = !edit;
            btnUpdate.Enabled = !edit;
            btnRetry.Enabled = edit;
            btnDelete.Enabled = !edit;
        }
        ConnectSQL conn = new ConnectSQL();
        private string sqlStr = "";
        int pos;
        public QLyNhanVien()
        {
            InitializeComponent();
        }

        void SetLock(bool edit)
        {
            btnAdd.Enabled = edit;
            btnDelete.Enabled = edit;
            btnRetry.Enabled = edit;
            btnCancel.Enabled = edit;
            btnSave.Enabled = edit;
            btnUpdate.Enabled = edit;

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
                //SqlConnection conn1 = new SqlConnection();
                //conn1.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                sqlStr = "SELECT * FROM TableNV ORDER BY[STT]";
                dgvNV.DataSource = conn.GetData(sqlStr, "TableNV");
                PhanQuyen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void QLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadTable();
            SetControls(false);
            conn.Connect();
            picTrue.Hide();
            picTrue1.Hide();
            picFalse.Hide();
            picFalse1.Hide();
            cbxChucvu.DropDownStyle = ComboBoxStyle.DropDownList;
            PhanQuyen();
        }

        private void dgvNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNV.RowCount >= 0)
            {
                pos = e.RowIndex;
                if(pos != -1)
                {
                    txtId.Text = dgvNV.Rows[pos].Cells[1].Value.ToString();
                    txtName.Text = dgvNV.Rows[pos].Cells[2].Value.ToString();
                    txtAddress.Text = dgvNV.Rows[pos].Cells[3].Value.ToString();
                    dtBirthday.Text = dgvNV.Rows[pos].Cells[4].Value.ToString();
                    if (string.Compare(dgvNV.Rows[pos].Cells[5].Value.ToString(), rbtnMale.Text, true) == 0)
                    {
                        rbtnMale.Checked = true;
                    }
                    else
                    {
                        rbtnFemale.Checked = true;
                    }
                    txtSDT.Text = dgvNV.Rows[pos].Cells[6].Value.ToString();
                    txtEmail.Text = dgvNV.Rows[pos].Cells[7].Value.ToString();
                    cbxChucvu.Text = dgvNV.Rows[pos].Cells[8].Value.ToString();
                }
              
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            oldID = txtId.Text;
            modeNew = false;
            SetControls(true);
            txtId.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtId.Text = "VME00" + Shuffle(text).Remove(idLength);
            modeNew = true;
            SetControls(true);
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            rbtnFemale.Checked = false;
            rbtnMale.Checked = true;
            dtBirthday.Text = "";
            cbxChucvu.Text = "";
            dgvNV.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công");
                string sqlStr1 = "SELECT * FROM TableNV";
                DataTable dt = new DataTable();
                dt = conn.GetData(sqlStr1, "TableNV");
                if (dt.Rows.Count == 0) return;
                string sqlStr2 = "DELETE FROM TableNV WHERE MaNV ='" + txtId.Text + "'";
                conn.Excute(sqlStr2);
                LoadTable();
            }
            else { return; }
            
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            rbtnFemale.Checked = true;
            rbtnMale.Checked = false;
            dtBirthday.Text = "";
            cbxChucvu.Text = "";
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
            dgvNV.Enabled = true;

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtEmail.Text == "")
            {
                picTrue.Hide();
                picFalse.Hide();
            }
            else
            {
                {
                    string format = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    Regex reg = new Regex(format);
                    if (!reg.IsMatch(txtEmail.Text))
                    {
                        picTrue.Hide();
                        picFalse.Show();
                        check = false;
                        return;

                    }
                    else
                    {
                        picTrue.Show();
                        picFalse.Hide();
                        check = true;
                    }
                }
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

        private void cbxChucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChucvu.SelectedIndex != -1) check4 = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             lastrow = dgvNV.Rows.Count - 1;
             newStt = Convert.ToInt32(dgvNV.Rows[lastrow - 1].Cells[0].Value.ToString()) + 1;
            if (modeNew && check == true && check1 == true && check2 == true && check3 == true && check4 == true)
            {
                if (rbtnMale.Checked)
                {
                    sqlStr3 = "INSERT INTO [dbo].[TableNV]([MaNV],[HoTen] ,[DiaChi],[NgaySinh] ,[GioiTinh],[SDT],[Email],[Chucvu],[NgayCapNhat]) VALUES ('" + txtId.Text + "', N'" + txtName.Text + "', N'" + txtAddress.Text + "','" + dtBirthday.Text + "','" + rbtnMale.Text + "','" + txtSDT.Text + "','" + txtEmail.Text + "', N'" + cbxChucvu.Text + "'," + "GetDate()" + ")";
                    if(String.Compare(cbxChucvu.SelectedItem.ToString(),"Quản lý",true)==0)
                    {
                        string pass = EncryptPassword("Vmql_00" + newStt);
                        sqlStr4 = "INSERT INTO [dbo].[TableUser] ([MaNV],[Username],[Password],[IDPer]) VALUES ('" + txtId.Text + "','Vmql_00" + newStt + "', '" + pass + "', 2)";
                        MessageBox.Show("Account của bạn là (Lưu ý: Đổi mật khẩu trước khi sử dụng): Tài khoản : Vmql_00" + newStt.ToString() + "   Mật khẩu :   Vmql_00" + newStt.ToString());
                    }
                    if(String.Compare(cbxChucvu.SelectedItem.ToString(), "Nhân viên", true) == 0)
                    {
                        string pass = EncryptPassword("Vmnv_00" + newStt);
                        sqlStr4 = "INSERT INTO [dbo].[TableUser] ([MaNV],[Username],[Password],[IDPer]) VALUES ('" + txtId.Text + "','Vmnv_00" + newStt + "', '" + pass + "', 1)";
                        MessageBox.Show("Account của bạn là (Lưu ý: Đổi mật khẩu trước khi sử dụng): Tài khoản : Vmnv_00" + newStt.ToString() + "   Mật khẩu :   Vmnv_00" + newStt.ToString());
                    }
                   
                }
                else
                {               
                    sqlStr3 = "INSERT INTO [dbo].[TableNV]([MaNV],[HoTen] ,[DiaChi],[NgaySinh] ,[GioiTinh],[SDT],[Email],[Chucvu],[NgayCapNhat]) VALUES ('" + txtId.Text + "', N'" + txtName.Text + "', N'" + txtAddress.Text + "','" + dtBirthday.Text + "', N'" + rbtnFemale.Text + "','" + txtSDT.Text + "','" + txtEmail.Text + "', N'" + cbxChucvu.Text + "'," + "GetDate()" + ")";
                    if (String.Compare(cbxChucvu.SelectedItem.ToString(), "Quản lý", true) == 0)
                    {
                        string pass = EncryptPassword("Vmql_00" + newStt);
                        sqlStr4 = "INSERT INTO [dbo].[TableUser] ([MaNV],[Username],[Password],[IDPer]) VALUES ('" + txtId.Text + "','Vmql_00" + newStt + "', '" + pass + "', 2)";
                        MessageBox.Show("Account của bạn là (Lưu ý: Đổi mật khẩu trước khi sử dụng): Tài khoản : Vmql_00" + newStt.ToString() + "   Mật khẩu :   Vmql_00" + newStt.ToString());
                    }
                    if(String.Compare(cbxChucvu.SelectedItem.ToString(), "Nhân viên", true) == 0)
                    {
                        string pass = EncryptPassword("Vmnv_00" + newStt);
                        sqlStr4 = "INSERT INTO [dbo].[TableUser] ([MaNV],[Username],[Password],[IDPer]) VALUES ('" + txtId.Text + "','Vmnv_00" + newStt + "', '" + pass + "', 1)";
                        MessageBox.Show("Account của bạn là (Lưu ý: Đổi mật khẩu trước khi sử dụng): Tài khoản : Vmnv_00" + newStt.ToString() + "   Mật khẩu :   Vmnv_00" + newStt.ToString());
                    }       
                }      
                MessageBox.Show("Thêm thành công.");
                dgvNV.Enabled = true;
            }
            else
            {
                if (rbtnMale.Checked)
                    sqlStr3 = "UPDATE [dbo].[TableNV] SET HoTen = N'" + txtName.Text +
                    "',DiaChi = N'" + txtAddress.Text +
                    "',NgaySinh ='" + dtBirthday.Text +
                    "',GioiTinh ='" + rbtnMale.Text +
                    "',SDT ='" + txtSDT.Text +
                    "',Email ='" + txtEmail.Text +
                    "',Chucvu = N'" + cbxChucvu.Text +
                    "',NgayCapNhat = " + "GetDate()" + " WHERE MaNV = '" + oldID + "'";
                else
                    sqlStr3 = "UPDATE [dbo].[TableNV] SET HoTen = N'" + txtName.Text +
                   "',DiaChi = N'" + txtAddress.Text +
                   "',NgaySinh ='" + dtBirthday.Text +
                   "',GioiTinh = N'" + rbtnFemale.Text +
                   "',SDT ='" + txtSDT.Text +
                   "',Email ='" + txtEmail.Text +
                   "',Chucvu = N'" + cbxChucvu.Text +
                   "',NgayCapNhat = " + "GetDate()" + " WHERE MaNV = '" + oldID + "'";

            }
            try
            {
                conn.Excute(sqlStr3);
                conn.Excute(sqlStr4);
                LoadTable();

            }
            catch (Exception)
            { }
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
