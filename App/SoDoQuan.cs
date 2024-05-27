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
using System.Net;
using System.Net.Mail;
using Excel = Microsoft.Office.Interop.Excel;
namespace DoAn
{
    public partial class SoDoQuan : Form
    {
        ConnectSQL con = new ConnectSQL();
        private Button btn = new Button();
        private Button[] btnArray = new Button[16]; private bool[] isOderArray = new bool[16];
        private bool IsActiveBtn = false;
        private bool isOrderedBan1st = false;
        private bool isOrderedBan2nd = false;
        private bool isDatMon = false;
        public SoDoQuan()
        {
            InitializeComponent();
            SetBtnArray();
            btnDatMon.Enabled = false;
            btnXemThucDon.Enabled = false;
        }

        private void SetActiveBan(bool edit)
        {
            IsActiveBtn = edit;
            btnDatMon.Enabled = edit;
        }

        
        void SetBtnArray()
        {
            btnArray[0] = btnBan01;
            btnArray[1] = btnBan02;
            btnArray[2] = btnBan03;
            btnArray[3] = btnBan04;
            btnArray[4] = btnBan05;
            btnArray[5] = btnBan06;
            btnArray[6] = btnBan07;
            btnArray[7] = btnBan08;
            btnArray[8] = btnBan09;
            btnArray[9] = btnBan10;
            btnArray[10] = btnBan11;
            btnArray[11] = btnBan12;
            btnArray[12] = btnBan13;
            btnArray[13] = btnBan14;
            btnArray[14] = btnBan15;
            btnArray[15] = btnBan16;
        }
        private void ReSetVar()
        {
            IsActiveBtn = false;
            isOrderedBan1st = false;
            isOrderedBan2nd = false;      

        }


        private void SetEnabledBanSelected()
        {
            foreach(Button button in btnArray)
            {
                if (button.Name == btn.Name)
                    button.Enabled = true;   
                else
                    button.Enabled = false;                     
            }    
                
        }

        private void SetEnableBanNormal()
        {
            foreach (Button button in btnArray)
                button.Enabled = true;   
        }

        private void SetColorBan()
        {
            bool isSetting = false;
            if (btn.BackColor != Color.FromArgb(255, 255, 192))
            {
                btn.BackColor = Color.FromArgb(255, 255, 192);
                SetActiveBan(true);
                isSetting = true;
            }                  
            else 
            {                
                btn.BackColor = Color.FromArgb(192, 255, 255);
                SetActiveBan(false);
                SetEnableBanNormal();
            }
           

            if (isOrderedBan2nd==true && isSetting ==false)
            {
                btn.BackColor = Color.SaddleBrown;
                SetActiveBan(false);
                SetEnableBanNormal();
                ReSetVar();
            }                         
        }

        private string GetTrangThaiBan(string tenban)
        {
            string str = "select TrangThai from TbDanhSachBan where TenBan = '" + tenban + "'";
            DataTable dt = con.ViewData(str);
            return dt.Rows[0][0].ToString();
        }

        private bool IsDaDatMon(string tenban)
        {
            string str = "select * from TableTD where TenBan = '" + tenban + "'";
            DataTable dt = con.ViewData(str);
            return dt.Rows.Count > 0 ? true : false;
        }

        private void SetupBan(bool edit)
        {
            if(IsActiveBtn==false)
            {
                MessageBox.Show("Vui lòng chọn 1 bàn để setup!");
                return;
            }                         
            if (edit)
            {
                if (isOrderedBan1st)
                {
                    MessageBox.Show("Bàn đã kín");
                    return ;
                }
                DialogResult r = MessageBox.Show("Bạn có muốn đặt bàn?", "Đặt bàn", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    btn.BackColor = Color.SaddleBrown;
                    isOrderedBan1st = true;
                    SetTrangThaiBan(btn.Text, 1);
                }
                else
                {
                    SetColorBan();
                    ReSetVar();
                }                     
            }            
            else
            {
                if (!isOrderedBan1st)
                {
                    MessageBox.Show("Bàn rỗng");
                    return ;
                }
                DialogResult r = MessageBox.Show("Bạn muốn hủy bàn?", "Hủy bàn", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if(IsDaDatMon(btn.Text))
                    {
                        MessageBox.Show("Bàn này đã gọi món, vui lòng chuyển sang giao diện quản lý thực đơn để chỉnh sửa!");
                        return ;
                    }
                    btn.BackColor = Color.FromArgb(192, 255, 255);
                    isOrderedBan2nd = false;
                    SetTrangThaiBan(btn.Text, 0);
                }
                else
                {
                    SetColorBan();
                    ReSetVar();
                } 
                    
            }
            SetActiveBan(false);
            SetEnableBanNormal();
        }

        private void SetOrderedBan()
        {
            if (btn.BackColor == Color.SaddleBrown)
                isOrderedBan1st = true;
            else
                isOrderedBan1st = false;
            if(isOrderedBan1st && !isOrderedBan2nd)
                isOrderedBan2nd = true;         
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            btn = (Button)sender;         
            SetOrderedBan();          
            SetEnabledBanSelected();
            SetColorBan();
            if (isOrderedBan1st)
                btnXemThucDon.Enabled = btnDatMon.Enabled = true;
            else 
                btnXemThucDon.Enabled = btnDatMon.Enabled = false;
        }
        
        private void btnDatBan_Click(object sender, EventArgs e)
        {
            SetupBan(true);
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {          
              
            SetupBan(false);
        }

        private void btnDatMon_Click(object sender, EventArgs e)
        {

            Main mn = new Main();
            Panel panel = new Panel();
            panel = (Panel) this.Parent;

            Form frm = new Form();
            frm = (Form) panel.Parent;
            mn = (Main) frm;        
            mn.PerformClickMenu(btn.Text);
      
        }

        private void btnXemThucDon_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            Panel panel = new Panel();
            panel = (Panel)this.Parent;

            Form frm = new Form();
            frm = (Form)panel.Parent;
            mn = (Main)frm;
            mn.PerformClickThucDon(btn.Text);
        }

        private void SetTrangThaiBan(string tenban ,int edit)
        {
            string str = "update TbDanhSachBan set TrangThai =" + edit.ToString() + "where TenBan ='" + tenban + "'";
            con.Excute(str);
        }

        private void setTranThanBanSoDoQuan()
        {
            string str = "select TrangThai from TbDanhSachBan";
            DataTable dt = con.ViewData(str);
            for (int index = 0; index < 16; index++)
            {
                if (dt.Rows[index][0].ToString()=="1")
                {
                    btnArray[index].BackColor = Color.SaddleBrown;
                }
                else
                {
                    btnArray[index].BackColor = Color.FromArgb(192, 255, 255);
                }    
            }    
        }

        private void SoDoQuan_Load(object sender, EventArgs e)
        {

            setTranThanBanSoDoQuan();    
        }
    }
}
