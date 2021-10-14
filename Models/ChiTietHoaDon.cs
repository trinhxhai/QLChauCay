using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChauCayCanh.Business;
namespace QuanLyChauCayCanh.Models
{
    public class ChiTietHoaDon
    {
        public string IdHoaDon { get; set; }
        public string IdChauCay { get; set; }
        public string TenChauCay { get; set; }
        public string GiaBan { get; set; }
        public string SoLuong { get; set; }
        public string KhuyenMai { get; set; }

        public string ThanhTien { 
            get {
                return QLChiTietHoaDon.TinhThanhTien(SoLuong, GiaBan, KhuyenMai);
            }
            
        }

    }
}
