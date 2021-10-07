using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Models
{
    public class LoaiChauCay
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public DateTime ThoiGianTao { get; set; }

        public DateTime ThoiGianSua { get; set; }
    }
}
