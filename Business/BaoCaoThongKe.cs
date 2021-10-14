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
    public class BaoCaoThongKe
    {
        public static List<BCTK_ChauCay> GetBCTKChauCay(DateTime from, DateTime to)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<BCTK_ChauCayData> lst = new List<BCTK_ChauCayData>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BCTK_ChauCay";

                        cmd.Parameters.Add(new SqlParameter("@From", SqlDbType.Date));
                        cmd.Parameters["@From"].Value = from;
                        cmd.Parameters.Add(new SqlParameter("@To", SqlDbType.Date));
                        cmd.Parameters["@To"].Value = to;

                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lst.Add(new BCTK_ChauCayData()
                            {
                                Id = rd["idChauCay"].ToString(),
                                Ten = rd["tenChauCay"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            });

                        }
                        return BaoCaoThongKe.ConvertDataToBCTKChauCay(lst);

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conObject.Close();
            }


            return null;
        }
        
        public static List<BCTK_ChauCay>  ConvertDataToBCTKChauCay(List<BCTK_ChauCayData> data)
        {
            var dir = new Dictionary<string, List<BCTK_ChauCayData>>();

            foreach(var d in data)
            {
                if( !dir.ContainsKey(d.Id) )
                {
                    dir.Add(d.Id, new List<BCTK_ChauCayData>());
                }

                dir[d.Id].Add(d);
            }


            var res = new List<BCTK_ChauCay>();
            foreach(var item in dir)
            {
                int TongSoLuong = 0;
                int TongThanhTien = 0;
                string TenChau = "";
                foreach(var d in item.Value)
                {
                    TongSoLuong += int.Parse(d.SoLuong);
                    TongThanhTien += int.Parse(d.ThanhTien);
                    TenChau = d.Ten;
                }

                res.Add(new BCTK_ChauCay
                {
                    Id = item.Key,
                    Ten = TenChau,
                    SoLuong = TongSoLuong,
                    TongThanhTien = TongThanhTien,
                    
                });
            }

            return res;
        }

        public static List<BCTK_LoaiChauCay> GetBCTKLoaiChauCay(DateTime from, DateTime to)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<BCTK_LoaiChauCayData> lst = new List<BCTK_LoaiChauCayData>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BCTK_LoaiChauCay";

                        cmd.Parameters.Add(new SqlParameter("@From", SqlDbType.Date));
                        cmd.Parameters["@From"].Value = from;
                        cmd.Parameters.Add(new SqlParameter("@To", SqlDbType.Date));
                        cmd.Parameters["@To"].Value = to;

                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lst.Add(new BCTK_LoaiChauCayData()
                            {
                                Id = rd["idLoaichauCay"].ToString(),
                                Ten = rd["tenLoaichaucay"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            });

                        }
                        return BaoCaoThongKe.ConvertDataToBCTKLoaiChauCay(lst);

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conObject.Close();
            }


            return null;
        }

        public static List<BCTK_LoaiChauCay> ConvertDataToBCTKLoaiChauCay(List<BCTK_LoaiChauCayData> data)
        {
            var dir = new Dictionary<string, List<BCTK_LoaiChauCayData>>();

            foreach (var d in data)
            {
                if (!dir.ContainsKey(d.Id))
                {
                    dir.Add(d.Id, new List<BCTK_LoaiChauCayData>());
                }

                dir[d.Id].Add(d);
            }


            var res = new List<BCTK_LoaiChauCay>();
            foreach (var item in dir)
            {
                int TongSoLuong = 0;
                int TongThanhTien = 0;
                string TenChau = "";
                foreach (var d in item.Value)
                {
                    TongSoLuong += int.Parse(d.SoLuong);
                    TongThanhTien += int.Parse(d.ThanhTien);
                    TenChau = d.Ten;
                }

                res.Add(new BCTK_LoaiChauCay
                {
                    Id = item.Key,
                    Ten = TenChau,
                    SoLuong = TongSoLuong,
                    TongThanhTien = TongThanhTien,

                });
            }

            return res;
        }

        public static List<BCTK_KhachHang> GetBCTKKhachHang(DateTime from, DateTime to)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<BCTK_KhachHangData> lst = new List<BCTK_KhachHangData>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BCTK_KhachHang";

                        cmd.Parameters.Add(new SqlParameter("@From", SqlDbType.Date));
                        cmd.Parameters["@From"].Value = from;
                        cmd.Parameters.Add(new SqlParameter("@To", SqlDbType.Date));
                        cmd.Parameters["@To"].Value = to;

                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lst.Add(new BCTK_KhachHangData()
                            {
                                Id = rd["id_KH"].ToString(),
                                IdHoaDon = rd["idHoadon"].ToString(),
                                Ten = rd["tenKh"].ToString(),
                                NgaySinh = CommonTask.StrToDate(rd["ngaySinh"].ToString()),
                                Sdt = rd["Sdt"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            });

                        }
                        return BaoCaoThongKe.ConvertDataToBCTKKhachHang(lst);

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conObject.Close();
            }


            return null;
        }

        public static List<BCTK_KhachHang> ConvertDataToBCTKKhachHang(List<BCTK_KhachHangData> data)
        {
            var dir = new Dictionary<string, List<BCTK_KhachHangData>>();

            foreach (var d in data)
            {
                if (!dir.ContainsKey(d.Id))
                {
                    dir.Add(d.Id, new List<BCTK_KhachHangData>());
                }

                dir[d.Id].Add(d);
            }


            var res = new List<BCTK_KhachHang>();
            foreach (var item in dir)
            {
                int TongSoLuong = 0;
                int TongThanhTien = 0;
                string TenChau = "";
                DateTime ngaySinh = new DateTime();
                string Sdt = "";
                HashSet<string> setHoaDonId = new HashSet<string>();
                foreach (var d in item.Value)
                {
                    setHoaDonId.Add(d.IdHoaDon);
                    TongSoLuong += int.Parse(d.SoLuong);
                    TongThanhTien += int.Parse(d.ThanhTien);
                    TenChau = d.Ten;
                    Sdt = d.Sdt;
                    ngaySinh = d.NgaySinh;
                }

                res.Add(new BCTK_KhachHang
                {
                    Id = item.Key,
                    Ten = TenChau,
                    NgaySinh = ngaySinh,
                    Sdt = Sdt,
                    SoLanMua = setHoaDonId.Count,
                    SoLuong = TongSoLuong,
                    TongThanhTien = TongThanhTien,

                });
            }

            return res;
        }
        
        
        public static List<BCTK_NhanVien> GetBCTKNhanVien(DateTime from, DateTime to)
        {
            DbConnection conObject = DataBaseConnection.GetDatabaseConnection();
            List<BCTK_NhanVienData> lst = new List<BCTK_NhanVienData>();
            try
            {
                conObject.Open();
                if (conObject.State == ConnectionState.Open)
                {
                    //Response.Write("Database Connection is Open");

                    using (var cmd = conObject.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BCTK_NhanVien";

                        cmd.Parameters.Add(new SqlParameter("@From", SqlDbType.Date));
                        cmd.Parameters["@From"].Value = from;
                        cmd.Parameters.Add(new SqlParameter("@To", SqlDbType.Date));
                        cmd.Parameters["@To"].Value = to;

                        var rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            lst.Add(new BCTK_NhanVienData()
                            {
                                Id = rd["id_NV"].ToString(),
                                HoaDonId = rd["idHoadon"].ToString(),
                                Ten = rd["tenNV"].ToString(),
                                TenTaiKhoan = rd["tenTaiKhoanNV"].ToString(),
                                SoLuong = rd["fSoluong"].ToString(),
                                GiaBan = rd["fgiaban"].ToString(),
                                KhuyenMai = rd["fKhuyenmai"].ToString(),
                            });

                        }
                        return BaoCaoThongKe.ConvertDataToBCTKLoaiChauCay(lst);

                    }

                }

            }
            catch (SqlException sqlexception)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conObject.Close();
            }


            return null;
        }

        public static List<BCTK_NhanVien> ConvertDataToBCTKLoaiChauCay(List<BCTK_NhanVienData> data)
        {
            var dir = new Dictionary<string, List<BCTK_NhanVienData>>();

            foreach (var d in data)
            {
                if (!dir.ContainsKey(d.Id))
                {
                    dir.Add(d.Id, new List<BCTK_NhanVienData>());
                }

                dir[d.Id].Add(d);
            }


            var res = new List<BCTK_NhanVien>();
            foreach (var item in dir)
            {
                int TongSoLuong = 0;
                int TongThanhTien = 0;
                string TenKH = "";
                string TenTaiKhoan = "";
                HashSet<string> Hd = new HashSet<string>();
                foreach (var d in item.Value)
                {
                    TongSoLuong += int.Parse(d.SoLuong);
                    TongThanhTien += int.Parse(d.ThanhTien);
                    TenKH = d.Ten;
                    TenTaiKhoan = d.TenTaiKhoan;
                    Hd.Add(d.HoaDonId);

                }

                res.Add(new BCTK_NhanVien
                {
                    Id = item.Key,
                    Ten = TenKH,
                    TenTaiKhoan = TenTaiKhoan,
                    SoLuong = TongSoLuong,
                    SoLuongHD = Hd.Count,
                    TongThanhTien = TongThanhTien,
                });
            }

            return res;
        }


    }
}
