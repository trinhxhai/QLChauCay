using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChauCayCanh.Business;
namespace QuanLyChauCayCanh.Models
{
    public class BCTK_KhachHang
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string strNgaySinh {
                get {
                    return NgaySinh.ToString("dd/MM/yyy");
                }
        }
        public string Sdt { get; set; }
        public int SoLanMua { get; set; }
        public int SoLuong { get; set; }
        public int TongThanhTien { get; set; }
    }
    public class BCTK_KhachHangData
    {
        public string Id { get; set; }
        public string IdHoaDon { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Sdt { get; set; }

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
