using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChauCayCanh.Models;
namespace QuanLyChauCayCanh.Business
{
    public class QLChauCay
    {
        public static List<ChauCay> GetList()
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<ChauCay> lst = new List<ChauCay>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    
                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText = "select * from db_QLBH.dbo.tbl_chaucay;";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var res = rd;
                            var sb = rd["hinhanh"].ToString();

                            var chauCay = new ChauCay()
                            {
                                Id = rd["idChauCay"].ToString(),
                                Ten = rd["tenChauCay"].ToString(),
                                ChieuDai = rd["schieudai"].ToString(),
                                ChieuRong = rd["schieurong"].ToString(),
                                ChieuCao = rd["schieucao"].ToString(),
                                HinhAnh = string.IsNullOrEmpty(sb) ? null : (byte[])rd["hinhanh"],
                                MauSac = rd["smausac"].ToString(),
                                MoTa = rd["mota"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fGiaban"].ToString(),
                                IdLoaiChauCay = rd["IdLoaichaucay"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoiGianTao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoiGianSua"].ToString()),
                            };
                            lst.Add(chauCay);
                        }

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                //Response.Write("ERROR ::" + sqlexception.Message);
                return new List<ChauCay>();
            }
            catch (Exception ex)
            {
                //Response.Write("ERROR ::" + ex.Message);
                return new List<ChauCay>();
            }
            finally
            {
                conObject.Close();
            }
            return lst;

        }
        public static ChauCay GetById(string Id)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            ChauCay chauCay = null;

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

                        if (rd.Read())
                        {
                            chauCay = new ChauCay()
                            {
                                Id = rd["idChauCay"].ToString(),
                                Ten = rd["tenChauCay"].ToString(),
                                ChieuDai = rd["schieudai"].ToString(),
                                ChieuRong = rd["schieurong"].ToString(),
                                ChieuCao = rd["schieucao"].ToString(),
                                HinhAnh = CommonTask.stringToBytes(rd["hinhanh"].ToString()),
                                MauSac = rd["smausac"].ToString(),
                                MoTa = rd["mota"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fGiaban"].ToString(),
                                IdLoaiChauCay = rd["IdLoaichaucay"].ToString(),
                                ThoiGianTao = CommonTask.StrToDate(rd["dThoiGianTao"].ToString()),
                                ThoiGianSua = CommonTask.StrToDate(rd["dThoiGianSua"].ToString()),
                            };

                        }

                        return chauCay;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return chauCay;
            }
            catch (Exception ex)
            {
                return chauCay;
            }
            finally
            {
                conObject.Close();
            }
            return chauCay;
        }

        public static (bool, string) IsValid(ChauCay chauCay)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(chauCay.Id))
            {
                return (false, "Không được để trống mã chậu cây !");
            }

            if (String.IsNullOrEmpty(chauCay.Ten))
            {
                return (false, "Không được để trống tên chậu cây!");
            }
            if (String.IsNullOrEmpty(chauCay.ChieuDai))
            {
                return (false, "Không được để trống chiều dài chậu cây!");
            }

            if (String.IsNullOrEmpty(chauCay.ChieuRong))
            {
                return (false, "Không được để trống chiều rộng chậu cây!");
            }

            if (String.IsNullOrEmpty(chauCay.ChieuCao))
            {
                return (false, "Không được để trống chiều cao chậu cây!");
            }

            if (String.IsNullOrEmpty(chauCay.MauSac))
            {
                return (false, "Không được để trống màu sắc chậu cây!");
            }

            if (String.IsNullOrEmpty(chauCay.SoLuong))
            {
                return (false, "Không được để trống số lượng chậu cây!");
            }
            else
            {
                int tmp;
                if (!int.TryParse(chauCay.SoLuong, out tmp))
                {
                    return (false, "Số lượng là mộtsố!");
                }
            }

            if (String.IsNullOrEmpty(chauCay.GiaBan))
            {
                return (false, "Không được để trống giá bán chậu cây!");
            }
            else
            {
                int tmp;
                if (!int.TryParse(chauCay.GiaBan, out tmp))
                {
                    return (false, "Giá bán là mộtsố!");
                }
            }
            if (String.IsNullOrEmpty(chauCay.IdLoaiChauCay))
            {
                return (false, "Không được để trống loại chậu chậu cây!");
            }

            return res;
        }

        public static (bool, string) Add(ChauCay chauCay)
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
                        cmd.CommandText = "ThemChauCay";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = chauCay.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = chauCay.Ten;

                        cmd.Parameters.Add(new SqlParameter("@ChieuDai", SqlDbType.Char, 9));
                        cmd.Parameters["@ChieuDai"].Value = chauCay.ChieuDai;

                        cmd.Parameters.Add(new SqlParameter("@ChieuRong", SqlDbType.Char, 9));
                        cmd.Parameters["@ChieuRong"].Value = chauCay.ChieuRong;

                        cmd.Parameters.Add(new SqlParameter("@ChieuCao", SqlDbType.Char,9));
                        cmd.Parameters["@ChieuCao"].Value = chauCay.ChieuCao;

                        cmd.Parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary, -1));
                        cmd.Parameters["@HinhAnh"].Value = chauCay.HinhAnh;

                        cmd.Parameters.Add(new SqlParameter("@MauSac", SqlDbType.NVarChar, 15));
                        cmd.Parameters["@MauSac"].Value = chauCay.MauSac;

                        cmd.Parameters.Add(new SqlParameter("@Mota", SqlDbType.NVarChar, 100));
                        cmd.Parameters["@Mota"].Value = chauCay.MoTa;

                        cmd.Parameters.Add(new SqlParameter("@SoLuong", SqlDbType.Char, 3));
                        cmd.Parameters["@SoLuong"].Value = chauCay.SoLuong;

                        cmd.Parameters.Add(new SqlParameter("@GiaBan", SqlDbType.Char, 9));
                        cmd.Parameters["@GiaBan"].Value = chauCay.GiaBan;

                        cmd.Parameters.Add(new SqlParameter("@IdLoaiChauCay", SqlDbType.Char, 3));
                        cmd.Parameters["@IdLoaiChauCay"].Value = chauCay.IdLoaiChauCay;

                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = res == "0" ? "Mã đã tồn tại" : "Tên tài khoản đã tồn tại";
                        }

                        return (IsSuccess, res);
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
        public static (bool, string) Edit(ChauCay chauCay)
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
                        cmd.CommandText = "SuaChauCay";


                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = chauCay.Id;

                        cmd.Parameters.Add(new SqlParameter("@Ten", SqlDbType.NVarChar, 30));
                        cmd.Parameters["@Ten"].Value = chauCay.Ten;

                        cmd.Parameters.Add(new SqlParameter("@ChieuDai", SqlDbType.Char, 9));
                        cmd.Parameters["@ChieuDai"].Value = chauCay.ChieuDai;

                        cmd.Parameters.Add(new SqlParameter("@ChieuRong", SqlDbType.Char, 9));
                        cmd.Parameters["@ChieuRong"].Value = chauCay.ChieuRong;

                        cmd.Parameters.Add(new SqlParameter("@ChieuCao", SqlDbType.Char, 9));
                        cmd.Parameters["@ChieuCao"].Value = chauCay.ChieuCao;

                        cmd.Parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary, -1));
                        cmd.Parameters["@HinhAnh"].Value = chauCay.HinhAnh;

                        cmd.Parameters.Add(new SqlParameter("@MauSac", SqlDbType.NVarChar, 15));
                        cmd.Parameters["@MauSac"].Value = chauCay.MauSac;

                        cmd.Parameters.Add(new SqlParameter("@Mota", SqlDbType.NVarChar, 100));
                        cmd.Parameters["@Mota"].Value = chauCay.MoTa;

                        cmd.Parameters.Add(new SqlParameter("@SoLuong", SqlDbType.Char, 3));
                        cmd.Parameters["@SoLuong"].Value = chauCay.SoLuong;

                        cmd.Parameters.Add(new SqlParameter("@GiaBan", SqlDbType.Char, 9));
                        cmd.Parameters["@GiaBan"].Value = chauCay.GiaBan;

                        cmd.Parameters.Add(new SqlParameter("@IdLoaiChauCay", SqlDbType.Char, 3));
                        cmd.Parameters["@IdLoaiChauCay"].Value = chauCay.IdLoaiChauCay;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;


                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0" && res != "-1";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = res == "0" ? "Mã không tồn tại" : "Tên tài khoản đã tồn tại";
                        }

                        return (IsSuccess, res);
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
        public static void Delete(ChauCay chauCay)
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
                        cmd.CommandText = "XoaChauCay";

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Char, 3));
                        cmd.Parameters["@Id"].Value = chauCay.Id;

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
