using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DoAn
{
    public class ConnectSQL
    { 
        private DataSet myDataSet;
        public SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\DoAn\DoAn\DB_VinMart.mdf;Integrated Security=True");
        public void Connect()
        {
            try
            {
                if(connect.State == 0) connect.Open();
            }catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        public void Disconnect() 
        {
            if (connect.State != 0) 
            {
                connect.Close();
            }
        }
        public DataTable GetData(string sql, string tablename) //Lấy dữ liệu trả về bảng
        {
              Connect();
              SqlDataAdapter adap = new SqlDataAdapter(sql, connect);
              myDataSet = new DataSet();
              adap.Fill(myDataSet, tablename);
              DataTable dt = new DataTable();
              dt = myDataSet.Tables[tablename];
              return dt;
              Disconnect();
        }
        public DataTable ViewData(string sql) 
        {
            Connect();  //Kết nối tới cơ sở dữ liệu
            SqlDataAdapter adap = new SqlDataAdapter(sql, connect);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
            Disconnect(); 
        }
        public SqlCommand Excute(string sql) //Dùng lệnh sql cho các chức năng insert, delete, update
        {
            Connect();
            SqlCommand cmd = new SqlCommand(sql, connect);
            cmd.ExecuteNonQuery();
            return cmd;
            Disconnect(); // 
        }
    }
}
