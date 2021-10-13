using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Models
{
    public class KhachHang
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime ThoiGianSua { get; set; }

    }
}
