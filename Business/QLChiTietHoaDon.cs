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
    public class QLChiTietHoaDon
    {
        public static List<ChiTietHoaDon> GetList(string IdHD)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<ChiTietHoaDon> lst = new List<ChiTietHoaDon>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");
                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandText = "select * from db_QLBH.dbo.tbl_CTHD " +
                            "inner join db_QLBH.dbo.tbl_Chaucay " +
                            "on db_QLBH.dbo.tbl_CTHD.idChaucay = db_QLBH.dbo.tbl_Chaucay.idChauCay " +
                            "where idHoadon = " + IdHD+";";
                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            var ctHD = new ChiTietHoaDon()
                            {
                                IdHoaDon = rd["idHoadon"].ToString(),
                                IdChauCay = rd["idChauCay"].ToString(),
                                TenChauCay = rd["tenChauCay"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            };
                            lst.Add(ctHD);
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
        public static (bool, string) IsValid(ChiTietHoaDon ctHD)
        {
            var res = (true, "");
            if (String.IsNullOrEmpty(ctHD.IdChauCay))
            {
                return (false, "Không được để trống mã chậu cây!");
            }

            if (String.IsNullOrEmpty(ctHD.IdHoaDon))
            {
                return (false, "Không được để trống mã hóa đơn!");
            }

            if (String.IsNullOrEmpty(ctHD.GiaBan))
            {
                
                return (false, "Không được để trống giá bán!");
            }
            else
            {
                int tmp;
                if (!int.TryParse(ctHD.GiaBan, out tmp))
                {
                    return (false, "Giá bán là mộtsố!");
                }
            }
            if (String.IsNullOrEmpty(ctHD.SoLuong))
            {
                return (false, "Không được để trống số lượng!");
            }
            else
            {
                int tmp;
                if (!int.TryParse(ctHD.SoLuong, out tmp))
                {
                    return (false, "Số lượng là một số!");
                }
            }

            return res;
        }

        public static (bool, string) Add(ChiTietHoaDon ctHD)
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
                        cmd.CommandText = "ThemChiTietHoaDon";


                        cmd.Parameters.Add(new SqlParameter("@IdHD", SqlDbType.Char, 3));
                        cmd.Parameters["@IdHD"].Value = ctHD.IdHoaDon;

                        cmd.Parameters.Add(new SqlParameter("@IdChauCay", SqlDbType.Char, 30));
                        cmd.Parameters["@IdChauCay"].Value = ctHD.IdChauCay;

                        cmd.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Char, 9));
                        cmd.Parameters["@Gia"].Value = ctHD.GiaBan;

                        cmd.Parameters.Add(new SqlParameter("@KhuyenMai", SqlDbType.Char, 9));
                        cmd.Parameters["@KhuyenMai"].Value = ctHD.KhuyenMai;

                        cmd.Parameters.Add(new SqlParameter("@Soluong", SqlDbType.Char, 3));
                        cmd.Parameters["@Soluong"].Value = ctHD.SoLuong;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã đã tồn tại";
                        }
                        else
                        {
                            var chauCay = QLChauCay.GetById(ctHD.IdChauCay);
                            QLChauCay.UpdateSoLuongCay(new ChauCay()
                            {
                                Id = ctHD.IdChauCay,
                                SoLuong = (int.Parse(chauCay.SoLuong) - int.Parse(ctHD.SoLuong)).ToString()
                            }) ;
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
        public static (bool, string) Edit(ChiTietHoaDon ctHD)
        {
            var chauCay = QLChauCay.GetById(ctHD.IdChauCay);
            var chiTietHoaDon = QLChiTietHoaDon.GetById(ctHD.IdHoaDon, ctHD.IdChauCay);
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
                        cmd.CommandText = "SuaChiTietHoaDon";


                        cmd.Parameters.Add(new SqlParameter("@IdHD", SqlDbType.Char, 3));
                        cmd.Parameters["@IdHD"].Value = ctHD.IdHoaDon;

                        cmd.Parameters.Add(new SqlParameter("@IdChauCay", SqlDbType.Char, 30));
                        cmd.Parameters["@IdChauCay"].Value = ctHD.IdChauCay;

                        cmd.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Char, 9));
                        cmd.Parameters["@Gia"].Value = ctHD.GiaBan;

                        cmd.Parameters.Add(new SqlParameter("@KhuyenMai", SqlDbType.Char, 9));
                        cmd.Parameters["@KhuyenMai"].Value = ctHD.KhuyenMai;

                        cmd.Parameters.Add(new SqlParameter("@Soluong", SqlDbType.Char, 3));
                        cmd.Parameters["@Soluong"].Value = ctHD.SoLuong;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;


                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã không tồn tại";
                        }
                        else
                        {
                            conObject.Close();
                            int delta = chiTietHoaDon == null ? int.Parse(ctHD.SoLuong) : int.Parse(ctHD.SoLuong) - int.Parse(chiTietHoaDon.SoLuong);
                            int conLai = int.Parse(chauCay.SoLuong) - delta;
                            chauCay.SoLuong = conLai.ToString();
                            QLChauCay.UpdateSoLuongCay(chauCay);

                        }
                        conObject.Close();

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

        public static (bool, string) AddOrEdit(ChiTietHoaDon ctHD)
        {
            var chauCay = QLChauCay.GetById(ctHD.IdChauCay);

            var chiTietHoaDon = QLChiTietHoaDon.GetById(ctHD.IdHoaDon,ctHD.IdChauCay);

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
                        cmd.CommandText = "Them_hoac_SuaChiTietHoaDon";


                        cmd.Parameters.Add(new SqlParameter("@IdHD", SqlDbType.Char, 3));
                        cmd.Parameters["@IdHD"].Value = ctHD.IdHoaDon;

                        cmd.Parameters.Add(new SqlParameter("@IdChauCay", SqlDbType.Char, 30));
                        cmd.Parameters["@IdChauCay"].Value = ctHD.IdChauCay;

                        cmd.Parameters.Add(new SqlParameter("@Gia", SqlDbType.Char, 9));
                        cmd.Parameters["@Gia"].Value = ctHD.GiaBan;

                        cmd.Parameters.Add(new SqlParameter("@KhuyenMai", SqlDbType.Char, 9));
                        cmd.Parameters["@KhuyenMai"].Value = ctHD.KhuyenMai;

                        cmd.Parameters.Add(new SqlParameter("@Soluong", SqlDbType.Char, 3));
                        cmd.Parameters["@Soluong"].Value = ctHD.SoLuong;


                        cmd.UpdatedRowSource = UpdateRowSource.OutputParameters;

                        var res = cmd.ExecuteScalar().ToString();

                        bool IsSuccess = res != "0";
                        string CreateMsg = "";
                        if (!IsSuccess)
                        {
                            CreateMsg = "Mã hóa đơn hoặc mã chậu không tồn tại";
                        }
                        else
                        {
                            conObject.Close();

                            int delta = chiTietHoaDon == null ? int.Parse(ctHD.SoLuong) : int.Parse(ctHD.SoLuong) - int.Parse(chiTietHoaDon.SoLuong);
                            int conLai = int.Parse(chauCay.SoLuong) - delta;
                            chauCay.SoLuong = conLai.ToString();
                            QLChauCay.UpdateSoLuongCay(chauCay);

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

        public static void Delete(ChiTietHoaDon ctHD)
        {
            var chauCay = QLChauCay.GetById(ctHD.IdChauCay);

            var chiTietHoaDon = QLChiTietHoaDon.GetById(ctHD.IdHoaDon, ctHD.IdChauCay);

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
                        cmd.CommandText = "XoaChiTietHoaDon";

                        cmd.Parameters.Add(new SqlParameter("@IdHD", SqlDbType.Char, 3));
                        cmd.Parameters["@IdHD"].Value = ctHD.IdHoaDon;
                        cmd.Parameters.Add(new SqlParameter("@IdChauCay", SqlDbType.Char, 3));
                        cmd.Parameters["@IdChauCay"].Value = ctHD.IdChauCay;

                        var res = cmd.ExecuteNonQuery();

                        int delta = chiTietHoaDon == null ? 0 : int.Parse(ctHD.SoLuong);
                        int conLai = int.Parse(chauCay.SoLuong) + delta;
                        chauCay.SoLuong = conLai.ToString();
                        QLChauCay.UpdateSoLuongCay(chauCay);

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

        public static ChiTietHoaDon GetById(string IdHoaDon, string IdChauCay)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            ChiTietHoaDon cthd = null;

            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "GetChiTietHoaDon";

                        cmd.Parameters.Add(new SqlParameter("@IdHD", SqlDbType.Char, 3));
                        cmd.Parameters["@IdHD"].Value = IdHoaDon;
                        cmd.Parameters.Add(new SqlParameter("@IdChauCay", SqlDbType.Char, 3));
                        cmd.Parameters["@IdChauCay"].Value = IdChauCay;

                        var rd = cmd.ExecuteReader();

                        if (rd.Read())
                        {
                            cthd = new ChiTietHoaDon()
                            {
                                IdHoaDon = rd["idHoadon"].ToString(),
                                IdChauCay = rd["idChaucay"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            };

                        }

                        return cthd;
                    }



                }

            }
            catch (SqlException sqlexception)
            {
                return cthd;
            }
            catch (Exception ex)
            {
                return cthd;
            }
            finally
            {
                conObject.Close();
            }
            return cthd;
        }

        public static String TinhThanhTien(string SoLuong, string GiaBan, string KhuyenMai)
        {
            return (int.Parse(SoLuong) * int.Parse(GiaBan) * ((double)(100 - int.Parse(KhuyenMai)) / 100)).ToString(); ;
        }
    }
}
