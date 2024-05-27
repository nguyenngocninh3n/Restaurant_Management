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
using System.Security.Cryptography;
namespace DoAn
{
    public partial class frmLogin : Form
    {
        public static string UserName = "";
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\DoAn\DoAn\DB_VinMart.mdf;Integrated Security=True");
        public frmLogin()
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
        private void btnHide_Click(object sender, EventArgs e)
        {


            btnUnhide.Show();
            btnHide.Hide();
            txtPass.UseSystemPasswordChar = true;
           
            
        }

        private void btnUnhide_Click(object sender, EventArgs e)
        {
            btnUnhide.Hide();
            btnHide.Show();
            txtPass.UseSystemPasswordChar = false;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnHide.FlatAppearance.BorderSize = 0;
            btnUnhide.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.BorderSize = 0;
            txtPass.UseSystemPasswordChar = true;
            string sqlStr = "SELECT * FROM TableUser";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStr,conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cbUsername.DataSource = dt;
                cbUsername.DisplayMember = "UserName";
                //cbUsername.ValueMember = "Password";
                cbUsername.SelectedIndex = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Close", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes) Application.Exit();
            else { }
            
        }

       /* private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;    
        }*/

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //IconMinimize.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //IconMinimize.Visible = false;
        }

        private void txtAcc_MouseDown(object sender, MouseEventArgs e)
        {
            ComboBox TB = (ComboBox)sender;
            int VisibleTime = 1000; 

            ToolTip tt = new ToolTip();
            tt.Show("Enter your username !", TB, 40, 40, VisibleTime);
        }

        private void txtPass_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;

            ToolTip tt = new ToolTip();
            tt.Show("Enter your password !", TB, 40, 40, VisibleTime);
        }

        private void lbRegister_MouseEnter(object sender, EventArgs e)
        {
            lbRegister.Font = new Font(lbRegister.Font.Name, lbRegister.Font.Size, lbRegister.Font.Style ^ FontStyle.Bold);
        }

        private void lbRegister_MouseLeave(object sender, EventArgs e)
        {
            lbRegister.Font = new Font(lbRegister.Font.Name, lbRegister.Font.Size, lbRegister.Font.Style ^ FontStyle.Bold);
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            if (cbUsername.Text == "" || txtPass.Text == "")
            {
                lbError.Text = " Vui lòng nhập tài khoản mật khẩu !"; lbError.Show(); return;

            }
            else
            {
                try
                {
                    if (String.Compare(cbUsername.Text, txtPass.Text, true) == 0)
                    {
                        MessageBox.Show("Tài khoản và mật khẩu giống nhau dễ lộ thông tin. Đây có thể là account mặc định bạn nên đổi lại mật khẩu trước khi sử dụng", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }          
                        conn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Autho_Login";
                        cmd.Parameters.AddWithValue("@UserName", cbUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", EncryptPassword(txtPass.Text));
                        cmd.Connection = conn;
                        UserName = cbUsername.Text;
                        object kq = cmd.ExecuteScalar();
                        int code = Convert.ToInt32(kq);
                        if (code == 1)
                        {
                            MessageBox.Show("Chào mừng Nhân viên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lbError.Text = " ";
                            Main main = new Main();
                            main.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else if (code == 0)
                        {
                            MessageBox.Show("Chào mừng Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lbError.Text = " ";
                            Main main = new Main();
                            main.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else if (code == 2)
                        {
                            MessageBox.Show("Chào mừng Quản lý đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lbError.Text = " ";
                            Main main = new Main();
                            main.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else if (code == 3)
                        {
                            lbError.Text = "Tài khoản hoặc mật khẩu không đúng !!";
                            lbError.Show();
                            txtPass.Text = "";
                            cbUsername.Focus();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPass.Text = "";
                            cbUsername.Text = "";
                            cbUsername.Focus();
                            conn.Close();
                        }       
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Close", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes) Application.Exit();
            else { }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void phóngToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //IconMinimize.Visible = false;
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Close", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes) Application.Exit();
            else { }
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Show();
        }

        private void đăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.Show();
        }
    }
}