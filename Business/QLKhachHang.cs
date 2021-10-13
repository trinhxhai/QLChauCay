using QuanLyChauCayCanh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Business
{
    public class QLKhachHang
    {
        public static List<KhachHang> GetList()
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<KhachHang> lst = new List<KhachHang>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");
                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText = "select * from db_QLBH.dbo.tbl_khachhang;";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var nv = new KhachHang()
                            {
                                Id = rd["id_KH"].ToString(),
                                Ten = rd["tenKH"].ToString(),
                                NgaySinh = CommonTask.StrToDate(rd["ngaySinh"].ToString()),
                                DiaChi = rd["diaChi"].ToString(),
                                SDT = rd["Sdt"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoigiantao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoigiansua"].ToString()),
                            };
                            lst.Add(nv);
                        }

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                //Response.Write("ERROR ::" + sqlexception.Message);
            }
            catch (Exception ex)
            {
                //Response.Write("ERROR ::" + ex.Message);
            }
            finally
            {
                conObject.Close();
            }
            return lst;

        }
        public static (bool, string) IsValid(KhachHang khachHang)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(khachHang.Id))
            {
                return (false, "Không được để trống mã khách hàng!");
            }

            if (!Regex.IsMatch(khachHang.SDT, @"[0-9]{10}"))
            {
                return (false, "Số điện thoại có đúng 10 số!");
            }

            if (String.IsNullOrEmpty(khachHang.SDT))
            {
                return (false, "Không được để trống số điện thoại khách hàng!");
            }


            return res;
        }

        public static (bool, string) Add(KhachHang khachHang)
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
                        cmd.CommandText = "ThemKhachHang";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = khachHang.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = khachHang.Ten;

                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date));
                        cmd.Parameters["@NgaySinh"].Value = khachHang.NgaySinh;

                        cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@DiaChi"].Value = khachHang.DiaChi;

                        cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Char, 10));
                        cmd.Parameters["@SDT"].Value = khachHang.SDT;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã đã tồn tại";
                        }

                        return (IsSuccess, CreateMsg);
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
            return (false, "Lỗi Không xác định !");
        }
        public static (bool, string) Edit(KhachHang khachHang)
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
                        cmd.CommandText = "SuaKhachHang";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = khachHang.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = khachHang.Ten;

                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date));
                        cmd.Parameters["@NgaySinh"].Value = khachHang.NgaySinh;

                        cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar,50));
                        cmd.Parameters["@DiaChi"].Value = khachHang.DiaChi;

                        cmd.Parameters.Add(new SqlParameter("@SDT", SqlDbType.Char,10));
                        cmd.Parameters["@SDT"].Value = khachHang.SDT;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;


                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã không tồn tại";
                        }

                        return (IsSuccess, CreateMsg);
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
        public static void Delete(KhachHang khachHang)
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
                        cmd.CommandText = "XoaKhachHang";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = khachHang.Id;

                        var res = cmd.ExecuteNonQuery();

                    }

                }

            }
            catch (SqlException sqlexception)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conObject.Close();
            }
        }

        public static KhachHang GetById(string Id)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            KhachHang khachHang = null;

            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetKhachHang";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = Id;

                        var rd = cmd.ExecuteReader();

                        if (rd.Read())
                        {
                            khachHang = new KhachHang()
                            {
                                Id = rd["id_KH"].ToString(),
                                Ten = rd["tenKH"].ToString(),
                                NgaySinh = CommonTask.StrToDate(rd["ngaySinh"].ToString()),
                                DiaChi = rd["diaChi"].ToString(),
                                SDT = rd["Sdt"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoigiantao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoigiansua"].ToString()),
                            };

                        }

                        return khachHang;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return khachHang;
            }
            catch (Exception ex)
            {
                return khachHang;
            }
            finally
            {
                conObject.Close();
            }
            return khachHang;
        }

    }
}
