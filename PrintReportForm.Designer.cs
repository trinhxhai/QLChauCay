
namespace QuanLyChauCayCanh
{
    partial class PrintReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportStaticViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptChauCayBanDuoc = new QuanLyChauCayCanh.rpt.rptChauCayBanDuoc();
            this.rptLoaiChauCayBanDuoc = new QuanLyChauCayCanh.rpt.rptLoaiChauCayBanDuoc();
            this.SuspendLayout();
            // 
            // crystalReportStaticViewer
            // 
            this.crystalReportStaticViewer.ActiveViewIndex = -1;
            this.crystalReportStaticViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportStaticViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportStaticViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportStaticViewer.Location = new System.Drawing.Point(0, 0);
            this.crystalReportStaticViewer.Name = "crystalReportStaticViewer";
            this.crystalReportStaticViewer.Size = new System.Drawing.Size(800, 450);
            this.crystalReportStaticViewer.TabIndex = 0;
            // 
            // PrintReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportStaticViewer);
            this.Name = "PrintReportForm";
            this.Text = "PrintReportForm";
            this.Load += new System.EventHandler(this.PrintReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportStaticViewer;
        private rpt.rptChauCayBanDuoc rptChauCayBanDuoc;
        private rpt.rptLoaiChauCayBanDuoc rptLoaiChauCayBanDuoc;
    }
}