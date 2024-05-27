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
namespace DoAn
{
    public partial class Main : Form
    {
  
        ConnectSQL conn = new ConnectSQL();
        public static char chucVu;
        public static string manhanvien;
        public string tenban;



        public Main()
        {
            InitializeComponent();
        }


        private  Form currentFromChild;
        private  void OPenChildform(Form childForm)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            currentFromChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /* private void btSanpham_Click(object sender, EventArgs e)
         {
             OPenChildform(new Register());
             label1.Text = btSanpham.Text;
         }*/
        private void ActivateButton(object senderBtn, EventArgs e)
        {
            Button btn = (Button)senderBtn;
            btn.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn.BackColor = Color.SlateBlue;
            btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Bold);
        }
        private void DisableButton(object senderBtn, EventArgs e)
        {
            Button btn = (Button)senderBtn;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.BackColor = Color.FromArgb(128, 128, 255);
            btn.Font = new Font(btn.Font.Name, btn.Font.Size, FontStyle.Regular);
        }
        private void btTrangchu_Click(object sender, EventArgs e)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            UpdateDoanhThu();
            if (Convert.ToInt32(lbCur.Text) < Convert.ToInt32(lbFinal.Text))
            {
                lbCur.ForeColor = Color.Red;
            }
            else
            {
                lbCur.ForeColor = Color.Green;
            }
            if (Convert.ToDouble(lbCur1.Text) < 100000000.0)
            {
                lbCur1.ForeColor = Color.Red;
            }
            else
            {
                lbCur1.ForeColor = Color.Green;
            }
            if (Convert.ToInt32(lbCur2.Text) < Convert.ToInt32(lbFinal2.Text))
            {
                lbCur2.ForeColor = Color.Red;
            }
            else
            {
                lbCur2.ForeColor = Color.Green;
            }
       
            lbMainTitle.Text = "TRANG CHỦ";
            progressBar1.Value = 0;
            timer1.Start();
            
        }

        private void UpdateDoanhThu()
        {
            
       
            String sqlStr1 = "Select ISNULL(Count(*),0),ISNULL(SUM(TongTien),0) From TableHD";
            String sqlStr2 = "Select ISNULL(SUM(SoLuong),0) From TableCTHD";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            conn.Connect();
            dt1 = conn.ViewData(sqlStr1);
            conn.Connect();
            dt2 = conn.ViewData(sqlStr2);
            if (dt1.Rows.Count <= 0)
                lblTongDoanhThu.Text = lblTongDonHang.Text = lbCur.Text = lbCur1.Text = "0";
            else
            {
                lblTongDonHang.Text = lbCur.Text = dt1.Rows[0][0].ToString();
                lblTongDoanhThu.Text = lbCur1.Text = dt1.Rows[0][1].ToString();
            }
            if ( Convert.ToInt32( dt2.Rows[0][0].ToString()) == 0 )
                lblTongSP.Text = lbCur2.Text = "0";
            else
                lblTongSP.Text = lbCur2.Text = dt2.Rows[0][0].ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Close();
             string Str = "SELECT TableNV.Hoten,TableNV.MaNV FROM TableNV INNER JOIN TableUser ON TableNV.MaNV = TableUser.MaNV WHERE(TableUser.Username = '" + frmLogin.UserName + "')";
             string Str2 = "SELECT Chucvu FROM TableNV INNER JOIN TableUser ON TableNV.MaNV = TableUser.MaNV WHERE(TableUser.Username = '" + frmLogin.UserName + "')";
             DataTable dt = new DataTable();
             DataTable dt1 = new DataTable();
             DataTable dt2 = new DataTable();
             dt = conn.ViewData(Str);
             dt2 = conn.ViewData(Str2);
             lbName.Text = dt.Rows[0][0].ToString();
             manhanvien = dt.Rows[0][1].ToString();
             lbChucvu1.Text = dt2.Rows[0][0].ToString();
            string cv = lbChucvu1.Text;
            chucVu = cv[0];
            /*string Str1 = "SELECT * FROM TableHD";
            dt1 = conn.ViewData(Str1);
            lbAmount1.Text = dt1.Rows.Count.ToString();
            lbCur.Text = dt1.Rows.Count.ToString();*/

            UpdateDoanhThu();
           
            if(Convert.ToInt32(lbCur.Text) < Convert.ToInt32(lbFinal.Text))
            {
                lbCur.ForeColor = Color.Red;
            }
            else
            {
                lbCur.ForeColor = Color.Green;
            }
            if (Convert.ToDouble(lbCur1.Text) < 100000000.0)
            {
                lbCur1.ForeColor = Color.Red;
            }
            else
            {
                lbCur1.ForeColor = Color.Green;
            }
            
            if (Convert.ToInt32(lbCur2.Text) < Convert.ToInt32(lbFinal2.Text))
            {
                lbCur2.ForeColor = Color.Red;
            }
      
            else
            {
                lbCur2.ForeColor = Color.Green;
            }
      
            btTrangchu.PerformClick();
            timerMain.Start();
            timer1.Start();
        
        }
 
        private void frmLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                IconMinimize.Visible = true;
            }
        }

         public void PerformClickMenu(string tenBan)
        {
            tenban = tenBan;
            btnMenu.PerformClick();            
        }
        public void PerformClickThucDon(string tenBan)
        {
            tenban = tenBan;
            btnThucDon.PerformClick();
        }

        private void phóngToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            IconMinimize.Visible = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Close", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                IconMinimize.Visible = false;
                Application.Exit();
            }
            else { }
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            IconMinimize.Visible = true;
        }


        private void btNhanvien_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;  
            timer1.Start();
            QLyNhanVien qLyNhanVien = new QLyNhanVien();
            OPenChildform(qLyNhanVien);
            lbMainTitle.Text = "QUẢN LÝ NHÂN VIÊN";
        }

        private void btDangxuat_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            DialogResult choice = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không ?", "Thông báo", btn, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
                this.Close();
            }
            else { }
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lbDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
            lbDay.Text = DateTime.Now.ToString("dddd");
            lbKPI1.Text = DateTime.Now.ToString("MM");    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (lbMove.Left < 0 && (Math.Abs(lbMove.Left) > lbMove.Width))
               // lbMove.Left = this.Width;
         
           // lbMove.Left -= 1;
            lbMove.Text = lbMove.Text.Substring(1) + lbMove.Text[0];
            progressBar1.PerformStep(); 
        }

        private void btSanpham_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            QLySanPham qLySanPham = new QLySanPham();
            OPenChildform(qLySanPham);
            lbMainTitle.Text = "QUẢN LÝ SẢN PHẨM";
        }

        public void btHoadon_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            QLyHoaDon qLyHoaDon = new QLyHoaDon();
            OPenChildform(qLyHoaDon);
            lbMainTitle.Text = "QUẢN LÝ HÓA ĐƠN";
        }

        private  void btnMenu_Click(object sender, EventArgs e)
        {       
            progressBar1.Value = 0;
            timer1.Start();
            Menu menu= new Menu(tenban);
            OPenChildform(menu);
            lbMainTitle.Text = "MENU";
        }

        private void btThongke_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            QLyThongKe qLyThongKe = new QLyThongKe();
            OPenChildform(qLyThongKe);
            lbMainTitle.Text = "QUẢN LÝ THỐNG KÊ";
        }

      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCur1_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassWord_Click(object sender, EventArgs e)
        {
            frmChangePasscs change = new frmChangePasscs();
            change.Show();
        }

        private void btSoDoQuan_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            SoDoQuan qLySoDoQuan = new SoDoQuan();    
            OPenChildform(qLySoDoQuan);
            lbMainTitle.Text = "QUẢN LÝ SƠ ĐỒ QUÁN";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Start();
            QLyThucDon qLyThucDon = new QLyThucDon(tenban);
            OPenChildform(qLyThucDon);
            lbMainTitle.Text = "QUẢN LÝ THỰC ĐƠN";
        }
    }
}
