using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.IO;
namespace DoAn
{
    public partial class frmRegister : Form
    {
        bool check = false;
        bool check1 = false;
        bool check2 = false;
        bool check3 = false;
        bool check4 = false;
        bool check5 = false;
        string text = "aAbBcCdDeEfFgGhHiIjJhHkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ01234567890123456789";
        int idLength = 3;

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\DoAn\DoAn\DB_VinMart.mdf;Integrated Security=True");
        public frmRegister()
        {
            InitializeComponent();
        }

        public static string EncryptPassword(string pass)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder key = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                key.Append(hash[i].ToString("X2"));
            }
            return key.ToString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult thoat;
            thoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (thoat == DialogResult.Yes)
            {
                this.Close();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult thoat;
            thoat = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (thoat == DialogResult.Yes)
            {
                this.Close();
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
        private bool ValidPass(string pass)
        {
            bool passLength = false, hasDigit = false, hasUpper = false, hasLower = false, hasSpecialChar = false;

            if (pass.Length >= 8)
                passLength = true;

            foreach (char c in pass)
            {
                if (char.IsDigit(c))
                    hasDigit = true;


                else if (char.IsUpper(c))
                    hasUpper = true;

                else if (char.IsLower(c))
                    hasLower = true;
            }

            string specialChar = "\\/ ~!@#$%^&*()-_+={[]};:'\"|,<.>?";
            foreach (char c in specialChar)
            {
                if (pass.Contains(c))
                    hasSpecialChar = true;
            }
            // Đảm bảo một trong các điều kiện 
            if (passLength == false && hasDigit == false && (hasUpper == false || hasLower == false) && hasSpecialChar == false)
            {
                lbValid.Text = "Mật khẩu không thể sử dụng";
                lbValid.ForeColor = Color.DarkRed;
                picError2.Hide();
                return false;
            }
            // Đảm bảo độ dài và có chữ cái
            if (passLength && hasDigit == false)
            {
                lbValid.Text = "Mật khẩu trung bình.";
                lbValid.ForeColor = Color.Orange;
                picError2.Hide();
                return false;
            }
            // Đảm bảo số, kí tự đặc biệt và chữ cái
            if (passLength == false && hasDigit && hasSpecialChar && (hasUpper || hasLower))
            {
                lbValid.Text = "Mật khẩu khá.";
                lbValid.ForeColor = Color.Yellow;
                picError2.Show();
                return true;
            }
            // Đảm bảo chữ cái và kí tự đặc biệt
            if (passLength == false && hasDigit == false && (hasUpper || hasLower) && hasSpecialChar)
            {
                lbValid.Text = "Mật khẩu trung bình.";
                lbValid.ForeColor = Color.Orange;
                picError2.Hide();
                return false;
            }
            // Đảm bảo số và kí tự đặc biệt
            if (hasDigit && hasSpecialChar && (hasUpper == false || hasLower == false))
            {
                lbValid.Text = "Mật khẩu trung bình.";
                lbValid.ForeColor = Color.Orange;
                picError2.Hide();
                return false;
            }
            // Đảm bảo số, độ dài, chữ thường
            if (passLength && hasDigit && hasUpper == false && hasLower)
            {
                lbValid.Text = "Mật khẩu trung bình.";
                lbValid.ForeColor = Color.Orange;
                picError2.Hide();
                return false;
            }
            // Đảm bảo số, độ dài, chữ in hoa
            if (passLength && hasDigit && hasUpper && hasLower == false)
            {
                lbValid.Text = "Mật khẩu trung bình.";
                lbValid.ForeColor = Color.Orange;
                picError2.Hide();
                return false;
            }
            // Đảm bảo số, độ dài.
            if (passLength && hasDigit && hasUpper == false && hasLower == false)
            {
                lbValid.Text = "Mật khẩu yếu.";
                lbValid.ForeColor = Color.Red;
                picError2.Hide();
                return false;
            }
            // Đảm bảo độ dài, kí tự đặc biệt.
            if (passLength && hasSpecialChar == true && hasUpper == false && hasLower == false)
            {
                lbValid.Text = "Mật khẩu yếu.";
                lbValid.ForeColor = Color.Red;
                picError2.Hide();
                return false;
            }
            // Đảm bảo độ dài, số, chữ thường, hoa
            if (passLength && hasDigit && hasUpper && hasLower && hasSpecialChar == false)
            {
                lbValid.Text = "Mật khẩu khá.";
                lbValid.ForeColor = Color.Yellow;
                picError2.Show();
                return true;
            }
            //Đảm bảo hết điều kiện
            if (passLength && hasDigit && hasUpper && hasLower && hasSpecialChar)
            {
                lbValid.Text = "Có thể sử dụng mật khẩu này";
                lbValid.ForeColor = Color.Green;
                picError2.Show();
                return true;
            }

            return false;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            btnShow.Hide();
            btnHide.Show();
            txtPass.UseSystemPasswordChar = false;
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            btnHide.FlatAppearance.BorderSize = 0;
            btnShow.FlatAppearance.BorderSize = 0;
            txtPass.UseSystemPasswordChar = true;
            picError.Hide();
            picError1.Hide();
            picError2.Hide();
            picError3.Hide();
            picError4.Hide();
            picDup.Hide();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            btnShow.Show();
            btnHide.Hide();
            txtPass.UseSystemPasswordChar = true;
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
        private void label10_Click(object sender, EventArgs e)
        {
            string temp = "VME00" + Shuffle(text).Remove(idLength);
            if (check == true && check1 == true && check2 == true && check3 == true && check4 == true && check5 == true && txtName.Text != null && txtAddress.Text != null && txtEmail.Text != null && txtPass.Text != null && txtSDT.Text != null && txtUser.Text != null)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UserAdd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@password", EncryptPassword(txtPass.Text));
                    cmd.Parameters.AddWithValue("@Manv", temp);
                    cmd.Parameters.AddWithValue("@Hoten", txtName.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", Convert.ToDateTime(dateTimePicker1.Text));
                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButton1.Text);
                    }
                    if (radioButton2.Checked)
                    {
                        cmd.Parameters.AddWithValue("@GioiTinh", radioButton2.Text);
                    }
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Chucvu", "Admin");
                    cmd.Parameters.AddWithValue("@NgayCapNhat", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng kí thành công! ID của bạn là :" + temp, " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                    frmLogin.Refresh();
                    this.Close();
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai hoặc chưa điền thông tin", " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtSDT_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                picError3.Hide();
                label13.Text = " Vui lòng điền số điện thoại";
            }
            else
            {
                if (ValidPN(txtSDT.Text))
                {
                    picError3.Show();
                    label13.Text = " ";
                    check1 = true;
                }
                else
                {
                    label13.Text = "Số điện thoại gồm 10 chữ số và bắt đầu bằng 0!";
                    check1 = false;
                    picError3.Hide();
                }
            }
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            string password = txtPass.Text;
            if (password == "")
            {
                check = false;
                lbValid.Text = "Mật khẩu bỏ trống";
                lbValid.ForeColor = Color.Red;
                picError2.Hide();
            }
            else
            {
                ValidPass(password);
                if (ValidPass(password))
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
        }

        private void txtEmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtEmail.Text == "")
            {
                picError1.Hide();
                picError.Hide();
            }
            else
            {
                {
                    string format = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    Regex reg = new Regex(format);
                    if (!reg.IsMatch(txtEmail.Text))
                    {
                        picError.Show();
                        picError1.Hide();
                        check2 = false;
                        return;

                    }
                    else
                    {
                        picError1.Show();
                        picError.Hide();
                        check2 = true;
                    }
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtName.Text == "")
            {
                lbName.Text = " Vui lòng điền họ tên";
                check5 = false;
            }
            else
            {
                lbName.Text = "";
                check5 = true;
            }
        }

        private void txtAdress_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtAddress.Text == "")
            {
                lbAddress.Text = " Vui lòng điền địa chị";
                check4 = false;
            }
            else
            {
                lbAddress.Text = "";
                check4 = true;
            }

        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtUser.Text == "")
            {
                lbDup.Text = "Vui lòng điền tài khoản";
                picError4.Hide();
                picDup.Hide();
                check3 = false;
            }
            else
            {
                bool exists = false;
                try
                {
                    string qr = "select count(Username) from[TableUser] where Username = '" + txtUser.Text + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(qr, conn);
                    exists = (int)cmd.ExecuteScalar() > 0;
                    if (exists)
                    {
                        lbDup.Text = "Tên tài khoản này đã có người sử dụng";
                        picDup.Show();
                        picError4.Hide();
                        check3 = false;
                    }
                    else
                    {
                        picError4.Show();
                        picDup.Hide();
                        lbDup.Text = "";
                        check3 = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtPass_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1500;

            ToolTip tt = new ToolTip();
            tt.Show("Mật khẩu phải từ 8 kí tự trở lên và đảm bảo số, chữ hóa chữ ,thường và kí tự đặc biệt (Ví dụ: 123Abc!@)", TB, 30, 30, VisibleTime);
        }
    }
}
