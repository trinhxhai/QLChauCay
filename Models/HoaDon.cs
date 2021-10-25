using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Models
{
    public class HoaDon
    {
        public string Id { get; set; }
        
        public string IdNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayMua { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime ThoiGianSua { get; set; }

        public bool DaIn { get; set; }
    }
}
