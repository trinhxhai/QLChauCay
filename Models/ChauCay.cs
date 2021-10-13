using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChauCayCanh.Models
{
    public class ChauCay
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string ChieuDai { get; set; }
        public string ChieuRong { get; set; }
        public string ChieuCao { get; set; }
        public string MauSac { get; set; }
        public string MoTa { get; set; }
        public byte[] HinhAnh { get; set; }

        public string SoLuong { get; set; }
        public string GiaBan { get; set; }
        public string IdLoaiChauCay { get; set; }

        public DateTime ThoiGianTao { get; set; }
        public DateTime ThoiGianSua { get; set; }
    }
}
