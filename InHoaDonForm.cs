using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyChauCayCanh.Models;
using QuanLyChauCayCanh.Business;

namespace QuanLyChauCayCanh
{
    public partial class InHoaDonForm : Form
    {
        public string HoaDonId;
        public string TenKhachHang;

        public InHoaDonForm()
        {
            InitializeComponent();
            

        }

        private void InHoaDonForm_Load(object sender, EventArgs e)
        {
            var lsCTHD = QLChiTietHoaDon.GetList(HoaDonId);
            rptHoaDon1.SetDataSource(lsCTHD);
            
            int total = 0;
            foreach(var cthd in lsCTHD)
            {
                total += int.Parse(cthd.ThanhTien);
            }
            rptHoaDon1.SetParameterValue("IdHoaDon", HoaDonId);
            rptHoaDon1.SetParameterValue("NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));
            rptHoaDon1.SetParameterValue("TongThanhTien", total.ToString());
            rptHoaDon1.SetParameterValue("TenKhachHang", TenKhachHang);

            crystalReportViewer1.ReportSource = rptHoaDon1;
            crystalReportViewer1.Refresh();


        }




        
    }
}
