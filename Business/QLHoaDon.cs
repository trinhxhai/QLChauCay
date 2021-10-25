using QuanLyChauCayCanh.Models;
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
    public class QLHoaDon 
    {
        public static List<HoaDon> GetList()
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<HoaDon> lst = new List<HoaDon>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");
                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText =
                            "Select idHoadon, tbl_hoadon.id_NV, tenNV, tbl_hoadon.id_KH, tenKH, dNgaymua, db_QLBH.dbo.tbl_hoadon.dThoigiantao, db_QLBH.dbo.tbl_hoadon.dThoigiansua, db_QLBH.dbo.tbl_hoadon.bDaIn from db_QLBH.dbo.tbl_hoadon "

                             + "INNER JOIN db_QLBH.dbo.tbl_khachhang ON db_QLBH.dbo.tbl_hoadon.id_KH = db_QLBH.dbo.tbl_khachhang.id_KH "

                                +"INNER JOIN db_QLBH.dbo.tbl_nhanvien ON db_QLBH.dbo.tbl_hoadon.id_NV = db_QLBH.dbo.tbl_nhanvien.id_NV; ";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var hd = new HoaDon()
                            {
                                Id = rd["idHoadon"].ToString(),
                                IdNhanVien = rd["id_NV"].ToString(),
                                TenNhanVien = rd["tenNV"].ToString(),
                                IdKhachHang = rd["id_KH"].ToString(),
                                TenKhachHang = rd["tenKH"].ToString(),
                                DaIn = rd["bDaIn"].ToString() == "1" ? true : false,
                                NgayMua = CommonTask.StrToDate(rd["dNgaymua"].ToString()),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoigiantao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoigiansua"].ToString()),
                            };
                            lst.Add(hd);
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
        public static (bool, string) IsValid(HoaDon hd)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(hd.Id))
            {
                return (false, "Không được để trống mã hóa đơn!");
            }

            if (String.IsNullOrEmpty(hd.IdKhachHang))
            {
                return (false, "Không được để trống mã khách hàng!");
            }

            if (String.IsNullOrEmpty(hd.IdNhanVien))
            {
                return (false, "Không được để trống mã nhân viên!");
            }


            return res;
        }

        public static (bool, string) Add(HoaDon hoadon)
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
                        cmd.CommandText = "ThemHoaDon";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = hoadon.Id;

                        cmd.Parameters.Add(new SqlParameter("@IdKH", SqlDbType.Char, 3));
                        cmd.Parameters["@IdKH"].Value = hoadon.IdKhachHang;

                        cmd.Parameters.Add(new SqlParameter("@IdNV", SqlDbType.Char, 3));
                        cmd.Parameters["@IdNV"].Value = hoadon.IdNhanVien;


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
        public static (bool, string) Edit(HoaDon hoadon)
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
                        cmd.CommandText = "SuaHoaDon";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = hoadon.Id;

                        cmd.Parameters.Add(new SqlParameter("@IdKH", SqlDbType.Char, 3));
                        cmd.Parameters["@IdKH"].Value = hoadon.IdKhachHang;

                        cmd.Parameters.Add(new SqlParameter("@IdNV", SqlDbType.Char, 3));
                        cmd.Parameters["@IdNV"].Value = hoadon.IdNhanVien;


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
        public static void Delete(HoaDon hoadon)
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
                        cmd.CommandText = "XoaHoaDon";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = hoadon.Id;

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

        public static HoaDon GetById(string Id)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            HoaDon hoaDon = null;

            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetLoaiChauCay";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = Id;

                        var rd = cmd.ExecuteReader();

                        if (rd.Read())
                        {
                            hoaDon = new HoaDon()
                            {
                                Id = rd["idHoadon"].ToString(),
                                IdNhanVien = rd["idHoadon"].ToString(),
                                IdKhachHang = rd["idKhachhang"].ToString(),
                            };

                        }

                        return hoaDon;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return hoaDon;
            }
            catch (Exception ex)
            {
                return hoaDon;
            }
            finally
            {
                conObject.Close();
            }
            return hoaDon;
        }

        public static void InHoaDon(string Id)
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
                        cmd.CommandText = "InHoaDon";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = Id;
                        cmd.ExecuteNonQuery();
                        return;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return;
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conObject.Close();
            }
            return;
        }
    }
}
