using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuanLyChauCayCanh.Models;
namespace QuanLyChauCayCanh.Business
{
    public class QLNhanVien
    {
        public static List<NhanVien> GetList()
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<NhanVien> lst = new List<NhanVien>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText = "select * from db_QLBH.dbo.tbl_nhanvien;";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var res = rd;
                            var nv = new NhanVien()
                            {
                                Id = rd["id_NV"].ToString(),
                                Ten = rd["tenNV"].ToString(),
                                TenTaiKhoan = rd["tenTaiKhoanNV"].ToString(),
                                MatKhau = rd["matKhau"].ToString(),
                                NgaySinh = CommonTask.StrToDate(rd["ngaySinh"].ToString()),
                                GioiTinh = rd["gioiTinh"].ToString(),
                                Sdt  = rd["Sdt"].ToString(),
                                DiaChi = rd["diaChi"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoiGianTao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoiGianSua"].ToString()),
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
        public static NhanVien GetById(string Id)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            NhanVien nv = null;

            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetNhanVien";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = Id;

                        var rd = cmd.ExecuteReader();

                        if(rd.Read())
                        {
                            nv = new NhanVien()
                            {
                                Id = rd["id_NV"].ToString(),
                                Ten = rd["tenNV"].ToString(),
                                TenTaiKhoan = rd["tenTaiKhoanNV"].ToString(),
                                MatKhau = rd["matKhau"].ToString(),
                                NgaySinh = CommonTask.StrToDate(rd["ngaySinh"].ToString()),
                                GioiTinh = rd["gioiTinh"].ToString(),
                                Sdt = rd["Sdt"].ToString(),
                                DiaChi = rd["diaChi"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoiGianTao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoiGianSua"].ToString()),
                            };

                        }

                        return nv;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return nv;
            }
            catch (Exception ex)
            {
                return nv;
            }
            finally
            {
                conObject.Close();
            }
            return nv;
        }

        public static (bool,string) IsValid(NhanVien nv)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(nv.Id))
            {
                return (false, "Không được để trống mã nhân viên!");
            }
            
            if (!Regex.IsMatch(nv.TenTaiKhoan, @"^(?![\d])[a-zA-Z0-9]{6,30}$"))
            {
                return (false, "Tên tài khoản gồm từ 6 đến 30 kí tự, không bắt đầu bằng số và không chứa kí tự đặc biệt!");
            }
            if (!Regex.IsMatch(nv.MatKhau, @"^(?=.{6}$)(?=.*[0-9])(?=.*[A-Z])[a-zA-Z0-9]*"))
            {
                return (false, "Mật khẩu gồm 6 kí tự, chứa ít nhất 1 kí tự hoa và một số !");
            }

            if (String.IsNullOrEmpty(nv.Ten))
            {
                return (false, "Không được để trống tên nhân viên!");
            }

            if (String.IsNullOrEmpty(nv.GioiTinh))
            {
                return (false, "Không được để trống giới tính nhân viên!");
            }

            if (nv.NgaySinh == null)
            {
                return (false, "Không được để trống ngày sinh nhân viên!");
            }

            if (!Regex.IsMatch(nv.Sdt, @"[0-9]{10}"))
            {
                return (false, "Số điện thoại có đúng 10 số!");
            }
            if (String.IsNullOrEmpty(nv.DiaChi))
            {
                return (false, "Không được để trống địa chỉ nhân viên!");
            }
            
            return res;
        }
        public static (bool,string) Add(NhanVien nv)
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
                        cmd.CommandText = "ThemNhanVien";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = nv.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = nv.Ten;

                        cmd.Parameters.Add(new SqlParameter("@TenTaiKhoan", SqlDbType.Char, 30));
                        cmd.Parameters["@TenTaiKhoan"].Value = nv.TenTaiKhoan;

                        cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.Char, 6));
                        cmd.Parameters["@MatKhau"].Value = nv.MatKhau;

                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date));
                        cmd.Parameters["@NgaySinh"].Value = nv.NgaySinh;

                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 5));
                        cmd.Parameters["@GioiTinh"].Value = nv.GioiTinh;

                        cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@DiaChi"].Value = nv.DiaChi;

                        cmd.Parameters.Add(new SqlParameter("@Sdt", SqlDbType.Char, 10));
                        cmd.Parameters["@Sdt"].Value = nv.Sdt;

                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res.Trim() != "0" && res.Trim() != "-1" && res.Trim() != "-2";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = res == "0" ? "Mã đã tồn tại" : (res == "-1" ? "Tên tài khoản đã tồn tại" : "Đã tồn tại tên nhân viên, thêm vào hãy vào tên các kí tự để phân biệt.");
                            return (IsSuccess, CreateMsg);
                        }

                        return (IsSuccess, res);
                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return (false,"Lỗi sql !");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi không xác định !");
            }
            finally
            {
                conObject.Close();
            }
            return (false,"Lỗi Không xác định !");
        }
        public static (bool,string) Edit(NhanVien nv)
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
                        cmd.CommandText = "SuaNhanVien";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = nv.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = nv.Ten;

                        cmd.Parameters.Add(new SqlParameter("@TenTaiKhoan", SqlDbType.Char, 30));
                        cmd.Parameters["@TenTaiKhoan"].Value = nv.TenTaiKhoan;

                        cmd.Parameters.Add(new SqlParameter("@MatKhau", SqlDbType.Char, 6));
                        cmd.Parameters["@MatKhau"].Value = nv.MatKhau;

                        cmd.Parameters.Add(new SqlParameter("@NgaySinh", SqlDbType.Date));
                        cmd.Parameters["@NgaySinh"].Value = nv.NgaySinh;

                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", SqlDbType.NVarChar, 5));
                        cmd.Parameters["@GioiTinh"].Value = nv.GioiTinh;

                        cmd.Parameters.Add(new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50));
                        cmd.Parameters["@DiaChi"].Value = nv.DiaChi;

                        cmd.Parameters.Add(new SqlParameter("@Sdt", SqlDbType.Char, 10));
                        cmd.Parameters["@Sdt"].Value = nv.Sdt;

                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;


                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0" && res != "1" && res != "-2";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = res == "0" ? "Mã không tồn tại" : (res == "-1" ? "Tên tài khoản đã tồn tại" : "Đã tồn tại tên nhân viên, thêm vào hãy vào tên các kí tự để phân biệt.");
                        }

                        return (IsSuccess, CreateMsg);
                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return (false,"Lỗi sql !");
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
        public static void Delete(NhanVien nv)
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
                        cmd.CommandText = "XoaNhanVien";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = nv.Id;

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
    
    }
}
