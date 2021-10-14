using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyChauCayCanh.Business;
namespace QuanLyChauCayCanh.Models
{
    public class BCTK_NhanVien
    {
        public string Id { get; set; }
        public string Ten { get; set; }

        public string TenTaiKhoan { get; set; }

        public int SoLuongHD { get; set; }
        public int SoLuong { get; set; }
        public int TongThanhTien { get; set; }
    }
    public class BCTK_NhanVienData
    {
        public string Id { get; set; }
        public string HoaDonId { get; set; }
        public string Ten { get; set; }

        public string TenTaiKhoan { get; set; }

        public string SoLuong { get; set; }

        public string GiaBan { get; set; }

        public string KhuyenMai { get; set; }

        public string ThanhTien
        {
            get
            {
                return QLChiTietHoaDon.TinhThanhTien(SoLuong, GiaBan, KhuyenMai);
            }
        }
    }
}
