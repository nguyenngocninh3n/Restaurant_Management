using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace DoAn
{
    public partial class frmChangePasscs : Form
    {
        public frmChangePasscs()
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
                key.Append(hash[i].ToString("x2"));
            }
            return key.ToString();
        }

        public bool KiemTra()
        {

            if (txtCurPass.Text == "")
            {
                lblShowInfor.ForeColor = System.Drawing.Color.White;
                lblShowInfor.Text = "Vui lòng nhập mật khẩu hiện tại !!";
                txtCurPass.Focus();
                return false;
            }
            else if (txtNewPass.Text == "")
            {
                lblShowInfor.ForeColor = System.Drawing.Color.White;
                lblShowInfor.Text = "Vui lòng nhập mật khẩu mới !!";
                txtNewPass.Focus();
                return false;
            }
            else if (txtConfirmPass.Text == "")
            {
                lblShowInfor.ForeColor = System.Drawing.Color.White;
                lblShowInfor.Text = "Vui lòng xác nhận mật khẩu !!";
                txtConfirmPass.Focus();
                return false;
            }
            else if (txtNewPass.Text != txtConfirmPass.Text)
            {
                lblShowInfor.ForeColor = System.Drawing.Color.White;
                lblShowInfor.Text = "Mật khẩu mới và mật khẩu xác nhận không trùng khớp";
                txtConfirmPass.Focus();
                txtConfirmPass.SelectAll();
                return false;
            }
            return true;
        }

        private void btXacnhan_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\DoAn\DoAn\DB_VinMart.mdf;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Update_Pass";
                    cmd.Parameters.Add("@User", SqlDbType.NVarChar).Value = txtUsername.Text;
                    cmd.Parameters.Add("@OldPass", SqlDbType.NVarChar).Value = EncryptPassword(txtCurPass.Text);
                    cmd.Parameters.Add("@NewPass", SqlDbType.NVarChar).Value = EncryptPassword( txtNewPass.Text);
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.GetInt32(0) == 1)
                    {
                        lblShowInfor.ForeColor = System.Drawing.Color.Blue;
                        lblShowInfor.Text = dr.GetString(1);
                        txtConfirmPass.Text = "";
                        txtCurPass.Text = "";
                        txtNewPass.Text = "";
                        txtCurPass.Focus();
                        
                    }
                    else
                    {
                        lblShowInfor.ForeColor = System.Drawing.Color.Red;
                        lblShowInfor.Text = dr.GetString(1);
                        txtCurPass.Focus();
                        txtCurPass.SelectAll();
                    }
                    dr.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void chkHMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHMK.Checked)
            {
                txtCurPass.PasswordChar = (char)0;
                txtNewPass.PasswordChar = (char)0;
                txtConfirmPass.PasswordChar = (char)0;
            }
            else
            {
                txtCurPass.PasswordChar = '*';
                txtNewPass.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePasscs_Load(object sender, EventArgs e)
        {
            txtUsername.Text = frmLogin.UserName.ToString();
            txtUsername.Enabled = false;
        }
    }
}
