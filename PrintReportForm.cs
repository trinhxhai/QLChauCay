using QuanLyChauCayCanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChauCayCanh
{
    public partial class PrintReportForm : Form
    {
        public string type = "";
        public object list_data;
        public DateTime dFrom;
        public DateTime dTo;
        public int TongThanhTien;
        public PrintReportForm(string type, object list_data, DateTime dFrom, DateTime dTo, int TongThanhTien)
        {
            InitializeComponent();
            this.type = type;
            this.list_data = list_data;
            this.dFrom = dFrom;
            this.dTo = dTo;
            this.TongThanhTien = TongThanhTien;
        }

        private void PrintReportForm_Load(object sender, EventArgs e)
        {
            switch (this.type)
            {
                case "ChauCay":
                    var list = (List<BCTK_ChauCay>)this.list_data;
                    rptChauCayBanDuoc.SetDataSource(list);
                    rptChauCayBanDuoc.SetParameterValue("NVId", ApplicationState.loginUser.Id);
                    rptChauCayBanDuoc.SetParameterValue("NVTen", ApplicationState.loginUser.Ten);
                    rptChauCayBanDuoc.SetParameterValue("dFrom", dFrom.ToString("dd/MM/yyyy"));
                    rptChauCayBanDuoc.SetParameterValue("dTo", dTo.ToString("dd/MM/yyyy"));
                    rptChauCayBanDuoc.SetParameterValue("printDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    rptChauCayBanDuoc.SetParameterValue("TongThanhTien", TongThanhTien.ToString());

                    crystalReportStaticViewer.ReportSource = rptChauCayBanDuoc;
                    break;

                case "LoaiChauCay":
                    var list2 = (List<BCTK_LoaiChauCay>)this.list_data;
                    rptLoaiChauCayBanDuoc.SetDataSource(list2);
                    rptLoaiChauCayBanDuoc.SetParameterValue("NVId", ApplicationState.loginUser.Id);
                    rptLoaiChauCayBanDuoc.SetParameterValue("NVTen", ApplicationState.loginUser.Ten);
                    rptLoaiChauCayBanDuoc.SetParameterValue("dFrom", dFrom.ToString("dd/MM/yyyy"));
                    rptLoaiChauCayBanDuoc.SetParameterValue("dTo", dTo.ToString("dd/MM/yyyy"));
                    rptLoaiChauCayBanDuoc.SetParameterValue("printDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    rptLoaiChauCayBanDuoc.SetParameterValue("TongThanhTien", TongThanhTien.ToString());
                    crystalReportStaticViewer.ReportSource = rptLoaiChauCayBanDuoc;
                    break;

                case "KhachHang":
                    var list3 = (List<BCTK_KhachHang>)this.list_data;
                    rptKhachHangMua.SetDataSource(list3);
                    rptKhachHangMua.SetParameterValue("NVId", ApplicationState.loginUser.Id);
                    rptKhachHangMua.SetParameterValue("NVTen", ApplicationState.loginUser.Ten);
                    rptKhachHangMua.SetParameterValue("dFrom", dFrom.ToString("dd/MM/yyyy"));
                    rptKhachHangMua.SetParameterValue("dTo", dTo.ToString("dd/MM/yyyy"));
                    rptKhachHangMua.SetParameterValue("printDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    rptKhachHangMua.SetParameterValue("TongThanhTien", TongThanhTien.ToString());
                    crystalReportStaticViewer.ReportSource = rptKhachHangMua;
                    break;

                case "NhanVien":
                    var list4 = (List<BCTK_NhanVien>)this.list_data;
                    rptNhanVienBan.SetDataSource(list4);
                    rptNhanVienBan.SetParameterValue("NVId", ApplicationState.loginUser.Id);
                    rptNhanVienBan.SetParameterValue("NVTen", ApplicationState.loginUser.Ten);
                    rptNhanVienBan.SetParameterValue("dFrom", dFrom.ToString("dd/MM/yyyy"));
                    rptNhanVienBan.SetParameterValue("dTo", dTo.ToString("dd/MM/yyyy"));
                    rptNhanVienBan.SetParameterValue("printDate", DateTime.Now.ToString("dd/MM/yyyy"));
                    rptNhanVienBan.SetParameterValue("TongThanhTien", TongThanhTien.ToString());
                    crystalReportStaticViewer.ReportSource = rptNhanVienBan;
                    break;
            }
            crystalReportStaticViewer.Refresh();
        }
    }
}
