using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Business
{
    public class QLHeThong
    {
        public static (bool,string) DangNhapTaiKhoan(string username, string password)
        {

            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");


                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "DangNhap";


                        cmd.Parameters.Add(new SqlParameter("@TenTaiKhoan", SqlDbType.Char, 30));
                        cmd.Parameters["@TenTaiKhoan"].Value = username;

                        cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.Char, 6));
                        cmd.Parameters["@MatKhau"].Value = password;


                        var res = cmd.ExecuteScalar().ToString();
                        bool IsSuccess = res != "0";
                        string LoginMsg = "";
                        if (res == "0")
                        {
                            LoginMsg = "Tên đăng nhập hoặc mật khẩu không đúng";
                            return (IsSuccess, LoginMsg);
                        }
                        else
                        {
                            // trả về Id khi đăng nhập thành công !
                            return (IsSuccess, res);
                        }
                        

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return (false, "Lỗi sql !");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi không xác định !");
            }
            finally
            {
                conObject.Close();
            }


            return (false, "Lỗi không xác định !");
        }
        
    }
}
