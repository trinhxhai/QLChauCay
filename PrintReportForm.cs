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
        public PrintReportForm(string type, object list_data, DateTime dFrom, DateTime dTo)
        {
            InitializeComponent();
            this.type = type;
            this.list_data = list_data;
            this.dFrom = dFrom;
            this.dTo = dTo;
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
                    crystalReportStaticViewer.ReportSource = rptLoaiChauCayBanDuoc;
                    break;

                case "KhachHang":

                    break;

                case "NhanVien":

                    break;
            }
            crystalReportStaticViewer.Refresh();
        }
    }
}
