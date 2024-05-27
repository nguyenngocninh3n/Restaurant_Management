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
    public partial class Menu : Form
    {      
        PictureBox[] PicBoxArray = new PictureBox[6];
        Label[] LabelNameArray = new Label[6];
        Label[] LabelPriceArray = new Label[6];
        Panel[] PanelSelectedMonArray = new Panel[100];
        Label[] LabelChildOfGrBox = new Label[6];
        int i = 0;
        DataTable dataTable  = new DataTable();
        SqlConnection cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\PC\source\repos\DoAn\DoAn\DB_VinMart.mdf;Integrated Security = True");
        ConnectSQL conn = new ConnectSQL();
        public Menu()
        {
            InitializeComponent();
            cbBoxBan.Text = "";
           
        }
        public Menu(string tenban)
        {
            InitializeComponent();
            cbBoxBan.Text = tenban;

        }
        private void SetPicBoxArray()
        {
            PicBoxArray[0] = picBox1;
            PicBoxArray[1] = picBox2;
            PicBoxArray[2] = picBox3;
            PicBoxArray[3] = picBox4;
            PicBoxArray[4] = picBox5;
            PicBoxArray[5] = picBox6;
        }

        private void SetTexBoxNameArray()
        {
            LabelNameArray[0] = lblName1;
            LabelNameArray[1] = lblName2;
            LabelNameArray[2] = lblName3;
            LabelNameArray[3] = lblName4;
            LabelNameArray[4] = lblName5;
            LabelNameArray[5] = lblName6;
        }

        private void SetTexBoxPriceArray()
        {
            LabelPriceArray[0] = lblPrice1;
            LabelPriceArray[1] = lblPrice2;
            LabelPriceArray[2] = lblPrice3;
            LabelPriceArray[3] = lblPrice4;
            LabelPriceArray[4] = lblPrice5;
            LabelPriceArray[5] = lblPrice6;
        }

        private void SetLabelChildOfGrBox()
        {
            LabelChildOfGrBox[0] = lblName1;
            LabelChildOfGrBox[1] = lblName2;
            LabelChildOfGrBox[2] = lblName3;
            LabelChildOfGrBox[3] = lblName4;
            LabelChildOfGrBox[4] = lblName5;
            LabelChildOfGrBox[5] = lblName6;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            SetPicBoxArray();
            SetTexBoxPriceArray();
            SetTexBoxNameArray();
            SetLabelChildOfGrBox(); 
            btnCombo_Click(sender, e);
        }

        private void AddNewLabel(Panel panel,Label newlabel, Label label,int num)
        {
            newlabel.Parent = panel;
            newlabel.Location = label.Location;
            newlabel.Size = label.Size;
            newlabel.Text = "0";
            newlabel.TabIndex = num;
            newlabel.Font = new Font(newlabel.Font, FontStyle.Bold);
            newlabel.AutoSize = true;
            panel.Controls.Add(newlabel);             
        }

        private void AddNewButton(Panel panel, Button newbutton, Button button, int num)
        {            
            newbutton.Parent = panel;
            newbutton.Location = button.Location;
            newbutton.Size = button.Size;
            newbutton.BackgroundImage = button.BackgroundImage;
            newbutton.BackgroundImageLayout = ImageLayout.Stretch;
            newbutton.TabIndex = num;
            newbutton.Font = new Font(newbutton.Font, FontStyle.Bold);
            panel.Controls.Add(newbutton);
        }

        private void SetPanelLocation(Panel panel, int num)
        {
            panel.Location = new System.Drawing.Point(0, panelSelectedMon.Location.Y + (panelSelectedMon.Size.Height + 5) * num);
            panel.TabIndex = num;
        }
        private void CreatePanelSelectedMon(DataRow datarow ,int num)
        {
                Panel newpanelSelectedMon = new Panel();
                Label newlblName = new Label();
                Label newlblNorPrice = new Label();
                Label newlblSoLuong1 = new Label();
                Label newlblSoLuong2 = new Label();
                Label newlblSubPrice = new Label();
                Button newbtnDelete = new Button();
                Button newbtnThem = new Button();
                Button newbtnBot = new Button();        

            //Tạo new panel
            newpanelSelectedMon.Size = panelSelectedMon.Size;
            SetPanelLocation(newpanelSelectedMon, num);
            newpanelSelectedMon.TabIndex = num;       
            newpanelSelectedMon.BackColor = Color.FromArgb(255, 255, 192);
            this.panelSelectedMonList.Controls.Add(newpanelSelectedMon);
        
            
            AddNewLabel(newpanelSelectedMon,newlblName, lblName,num*10);
            AddNewLabel(newpanelSelectedMon,newlblNorPrice,lblNorPrice,num*10+1);
            AddNewLabel(newpanelSelectedMon,newlblSoLuong1,lblSoLuong1,num*10+2);
            AddNewLabel(newpanelSelectedMon, newlblSoLuong2,lblSoLuong2,num*10+3);
            AddNewLabel(newpanelSelectedMon,newlblSubPrice,lblSubPrice,num*10+4);


            AddNewButton(newpanelSelectedMon, newbtnThem, btnThem, num*10);             
            AddNewButton(newpanelSelectedMon, newbtnBot, btnBot, num*10+1);
            AddNewButton(newpanelSelectedMon, newbtnDelete, btnDelete, num*10+2);

            newbtnThem.Click += new EventHandler(btnThem_Click);
            newbtnBot.Click += new EventHandler(btnBot_Click);
            newbtnDelete.Click += new EventHandler(btnDelete_Click);



            SetSelectedValueMon(datarow, newlblName, newlblNorPrice, newlblSoLuong1, newlblSoLuong2, newlblSubPrice, newbtnBot);
            PanelSelectedMonArray[i] = newpanelSelectedMon;
            i++;
        }

        private void SetMenuSelected(string strSql)
        {
            //cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strSql, cnn);        
            adapter.Fill(dataTable);
           
            int index = 0;
            foreach (DataRow row in dataTable.Rows)
            {              
                LabelNameArray[index].Text = row[2].ToString();
                LabelNameArray[index].Location = new System.Drawing.Point((PicBoxArray[index].Size.Width - LabelNameArray[index].Size.Width) / 2, LabelNameArray[index].Location.Y);
                LabelPriceArray[index].Text = row[3].ToString();             
                PicBoxArray[index].ImageLocation = row[4].ToString();
                index++;
                if (index == 6) return;
            }
           //cnn.Close();
        }

        private void SetSubPrice(Label soluong1, Label soluong2, Label norprice, Label subprice,Button btnbot, bool value)
        {
            lblSumPrice.Text = (Convert.ToDouble(lblSumPrice.Text) - Convert.ToDouble(subprice.Text)).ToString();       
            int soluong = 0;        
            double gia = 0.0;
            if(value)
                soluong = Convert.ToInt32(soluong1.Text)+1;
            else
                soluong = Convert.ToInt32(soluong1.Text) -1;
            soluong1.Text = soluong2.Text = soluong.ToString();
            gia = Convert.ToDouble(norprice.Text);
            subprice.Text = ( (double) soluong*gia).ToString();
            lblSumPrice.Text = (Convert.ToDouble(lblSumPrice.Text) + Convert.ToDouble(subprice.Text)).ToString();
            subprice.ForeColor = Color.SaddleBrown;
            if (soluong==0) btnbot.Enabled = false;
            else btnbot.Enabled = true;
        }

        private void SetSelectedValueMon(DataRow datarow, Label name, Label norprice, Label soluong1, Label soluong2, Label subprice,Button bot)
        {
            name.Text = datarow[2].ToString();
            norprice.Text = datarow[3].ToString();
            soluong1.Text = soluong2.Text = "0";
            SetSubPrice(soluong1, soluong2, norprice, subprice,bot, true);
        }

        private void picBox1_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;
            
            foreach (PictureBox index in PicBoxArray)
            {
                if (index.Name == picBox.Name)
                { 
                    DataRow datarow = dataTable.NewRow();
                    foreach(DataRow dt in dataTable.Rows)
                        if(dt[4].ToString()==picBox.ImageLocation.ToString())
                        {
                            datarow = dt;
                            break;
                        }    
                    if (!panelSelectedMon.Visible)
                    {
                        lblSubPrice.Text = lblSumPrice.Text = datarow[3].ToString();                       
                        panelSelectedMon.Visible = true;
                        SetSelectedValueMon(datarow, lblName,lblNorPrice,lblSoLuong1,lblSoLuong2,lblSubPrice,btnBot);
                        lblSumPrice.Visible = true;                      
                        PanelSelectedMonArray[i] = panelSelectedMon;
                        i++;                       
                    }
                    else
                    {
                        if (ControlSeletedImageLocation(picBox))
                            return;
                        int count = 0;
                        foreach (Control cont in panelSelectedMonList.Controls)
                            if (cont is Panel)
                                count++;                      
                        CreatePanelSelectedMon(datarow,count);
                    } 
                }    
            }    
        }

        

        private Label GetLable(Panel panel, Label lable)
        {
            Point pointA = new Point();
            pointA.X = lable.Location.X;
            pointA.Y = lable.Location.Y;
            return (Label) panel.GetChildAtPoint(pointA);
        }

        private Label GetLableGroupBox(GroupBox grBox, Label lable)
        {
            Point pointA = new Point();
            pointA.X = lable.Location.X;
            pointA.Y = lable.Location.Y;
            return (Label) grBox.GetChildAtPoint(pointA);
        }

        private Button GetButton(Panel panel, Button button)
        {
            Point pointA = new Point();
            pointA.X = button.Location.X;
            pointA.Y = button.Location.Y;
            return (Button)panel.GetChildAtPoint(pointA);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Button buttonThem = (Button)sender;
            Panel panel = (Panel)buttonThem.Parent;

            Label soluong1 = GetLable(panel, lblSoLuong1);
            Label soluong2 = GetLable(panel, lblSoLuong2);
            Label norprice = GetLable(panel, lblNorPrice);
            Label subprice = GetLable(panel, lblSubPrice);
            Button bot = GetButton(panel, btnBot);
            SetSubPrice(soluong1, soluong2, norprice, subprice,bot, true);
        }

        private void btnBot_Click(object sender, EventArgs e)
        {
            Button buttonThem = (Button)sender;
            Panel panel = (Panel)buttonThem.Parent;

            Label soluong1 = GetLable(panel, lblSoLuong1);
            Label soluong2 = GetLable(panel, lblSoLuong2);
            Label norprice = GetLable(panel, lblNorPrice);
            Label subprice = GetLable(panel, lblSubPrice);
            Button bot = GetButton(panel, btnBot);
            SetSubPrice(soluong1, soluong2, norprice, subprice, bot, false);
        }

        private int GetIndex(Panel[] a, Panel b, int n)
        {
            for(int i=0;i<n;i++)
            {
                if(a[i] == b) return i;
            }
            return -1;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Button buttonThem = (Button)sender;
            Panel panel = (Panel)buttonThem.Parent;       
            for (int index = 0; index < i; index++)
            {
                if (index == panel.TabIndex)
                {
                    panelSelectedMonList.Controls.Remove(panel);
                    lblSumPrice.Text = (Convert.ToDouble(lblSumPrice.Text) - Convert.ToDouble(GetLable(panel,lblSubPrice).Text)).ToString();
                    for (int ind = index; ind < i-1 ; ind++)
                    {
                        SetPanelLocation(PanelSelectedMonArray[ind + 1], ind);
                        PanelSelectedMonArray[ind] = PanelSelectedMonArray[ind + 1];                      
                    }                                    
                    i =i-1;
                    break;
                }
            }
            
        }

        private bool ControlSeletedImageLocation(PictureBox picBox)
        {
            bool isSelectedMonExist = false;
            foreach(Control ctrl in panelSelectedMonList.Controls)
            {
                if(ctrl is Panel)
                {
                    Label labelname = GetLable((Panel)ctrl,lblName);
                    GroupBox grBox = (GroupBox)picBox.Parent;
                    Label lbl1 = new Label();
                    for(int index =0; index < 6; index++)
                    {
                        if(grBox.TabIndex == index)
                        {
                            lbl1 = LabelChildOfGrBox[index];
                            if (labelname.Text == lbl1.Text)
                            {
                                SetSubPrice(GetLable((Panel)ctrl, lblSoLuong1), GetLable((Panel)ctrl, lblSoLuong2), GetLable((Panel)ctrl, lblNorPrice), GetLable((Panel)ctrl, lblSubPrice), GetButton((Panel)ctrl, btnBot), true);
                                isSelectedMonExist = true;
                                break;
                            }
                        }    
                    }                     
                }
                if (isSelectedMonExist) break;
            }
            return isSelectedMonExist;
        }

        private void btnKhaiVi_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_KV'";
            SetMenuSelected(strSql);
        }
        private void btnSup_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_MS'";
            SetMenuSelected(strSql);
        }

        private void btnMonChay_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_DC'";
            SetMenuSelected(strSql);
        }

        private void btnDoUong_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_DU'";
            SetMenuSelected(strSql);
        }

        private void btnRuouAndThuoc_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_RB'";
            SetMenuSelected(strSql);
        }

        private void btnTrangMieng_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_TM'";
            SetMenuSelected(strSql);
        }

        private void btnMonChinh_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            string strSql = "Select * From TbChiTietMon Where MaLoaiMon = 'PL_MC'";
            SetMenuSelected(strSql);
        }

        private void setCapPhatID(string loaiID, int num)
        {
            string sqls = "Update [dbo].[CapPhatID] SET " + loaiID + " = " + (num+1).ToString() ;                
            conn.Excute(sqls);
        }

        private string GetMaHD()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter("Select IDHD from CapPhatID", cnn);
            adt.Fill(dt);
            string mahd;
            int num = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (num < 10) mahd = "HD00" + num.ToString();
            else if (num < 100) mahd = "HD0" + num.ToString();
            else mahd = "HD" + num.ToString();
            setCapPhatID("IDHD",num);
            return mahd;
        }

        private string GetMaCTHD()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter("Select IDCTHD from CapPhatID", cnn);
            adt.Fill(dt);
            string macthd;
            int num = Convert.ToInt32(dt.Rows[0][0].ToString());
            if (num < 10) macthd = "CT00" + num.ToString();
            else if (num < 100) macthd = "CT0" + num.ToString();
            else macthd = "CT" + num.ToString();
            setCapPhatID("IDCTHD", num);
            return macthd;           
        }

        private string GetMaMon(string text)
        {
            string sqlStr1 = "SELECT MaMon FROM TbChiTietMon WHERE(TenMon = N'" + text + "')";
            DataTable dt1 = conn.ViewData(sqlStr1);
            string mamon = dt1.Rows[0][0].ToString();
            return mamon;
        }

        private void SetTrangThaiBan(string tenban, int edit)
        {
            string str = "update TbDanhSachBan set TrangThai =" + edit.ToString() + "where TenBan ='" + tenban + "'";
            conn.Excute(str);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {      
            
            if(i==0)
            {
                MessageBox.Show("Vui lòng đặt món!");
                return ;
            }
            if (cbBoxBan.Text == "")
            {
                MessageBox.Show("Chọn bàn cần đặt món!");
                return;
            }
            string mahd = GetMaHD();
            string insertHD = "insert into TableTD(MaHD,MaNV,TenBan,TongTien,NgayXuatHD) Values('" +
                 mahd + "','" +
                 Main.manhanvien + "', N'" +
                 cbBoxBan.Text + "', " +
                 lblSumPrice.Text + ",'" +
                 DateTime.Now + "')";
            conn.Excute(insertHD);

            SetTrangThaiBan(cbBoxBan.Text, 1);
            foreach (Control ctrol in panelSelectedMonList.Controls)
            {
                if(ctrol is Panel)
                {                  
                    Panel panel = (Panel)ctrol;
                    Label lbTenMon = GetLable(panel, lblName);
                    Label lbDonGia = GetLable(panel, lblNorPrice);
                    Label lbSoLuong = GetLable(panel, lblSoLuong1);
                    Label lbThanhTien = GetLable(panel, lblSubPrice);
                    conn.Disconnect();
                    conn.Connect();
                    string macthd = GetMaCTHD();
                    string insertCTHD = "insert into TableCTTD(MaCTHD,MaHD,MaMon,TenMon,DonGia,SoLuong,ThanhTien) Values('" +
                         macthd + "', '" +
                         mahd + "', '" +
                         GetMaMon(lbTenMon.Text).ToString() + "', N'" +
                         lbTenMon.Text + "', " +
                         lbDonGia.Text + ", " +
                         lbSoLuong.Text + ", " +
                         lbThanhTien.Text + ")";
                    conn.Excute(insertCTHD);
                }    
            }

            MessageBox.Show("Đặt món thành công!");
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            btnMonChinh_Click(sender, e);
        }
    }
}
