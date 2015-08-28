using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace SchoolApp
{
    class DataProvider
    {
        private static SQLiteConnection sql_con;
        private static SQLiteCommand sql_cmd;
        private static SQLiteDataAdapter DB;
        private static DataSet DS = new DataSet();
        private static DataTable DT = new DataTable();
        public static void SetConnection()
        {
          
                
                sql_con = new SQLiteConnection
                   ("Data Source=SchoolDB.sqlite;Version=3;New=True;Compress=True;");
                sql_con.Open();

                string sql = "create table if not exists MonHoc (MaMH varchar(20), TenMH varchar(50), SoTC int, TileThi int)";
                SQLiteCommand command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists CTHocPhi (MaMH varchar(20), MaNhom varchar(5), HocPhi varchar(50), MienGiam varchar(20), PhaiDong varchar(20), NamHoc int, HocKy int)";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists HocPhi (TongSoTC varchar(20), TongTien varchar(5), TienDongTTLD varchar(20), TienDaDong varchar(20), TienConNo varchar(20), NamHoc int, HocKy int)";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();
                

                sql = "create table if not exists User (Id varchar(20), HoTen varchar(50), Password varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                string sql1 = "create table if not exists  LichThi (MaMH varchar(20), GhepThi varchar(20), ToThi varchar(20), SoLuong int, NgayThi varchar(20), GioBD varchar(20), SoPhut int, PhongThi varchar(10))";
                command = new SQLiteCommand(sql1, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists LichHoc(Id varchar(20),MaMH varchar(20),NhomMH varchar(20),MaLop varchar(20),ThoigianBD varchar(20),ThoigianKT varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists CHITIETLH (Id varchar(20),Thu varchar(20),TietBD varchar(20),SoTiet varchar(20),Phong varchar(20),CBGD varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists DiemThi (HocKy int,NamHoc int,DiemTB10 varchar(20),DiemTB4 varchar(20),DiemTBTL10 varchar(20),DiemTBTL4 varchar(20),SoTCDat varchar(20),SoTCTL varchar(20),DiemRL varchar(20),LoaiRL varchar(20))";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();

                sql = "create table if not exists DiemMon (MaMH varchar(20),DiemKT varchar(20),DiemThi varchar(20),DiemTK10 varchar(20),DiemChu varchar(5),HocKy int,NamHoc int)";
                command = new SQLiteCommand(sql, sql_con);
                command.ExecuteNonQuery();
            
        }

        public static void Insert(string sql)
        {
            ExecuteQuery(sql);
        }

        public static DataTable LoadData(string sql)
        {
            SetConnection();
            
            sql_cmd = sql_con.CreateCommand();
         
            DB = new SQLiteDataAdapter(sql, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            
            sql_con.Close();
            return DT;
        }

        public static void ExecuteQuery(string txtQuery)
        {
            SetConnection();
           
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

    }
}
