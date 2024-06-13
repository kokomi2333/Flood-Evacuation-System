
namespace EngineWindowsApplication1
{
    partial class Scene窗体
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scene窗体));
            this.axSceneControl1 = new ESRI.ArcGIS.Controls.AxSceneControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.加载数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arcScene文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIN数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DEM数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坡度分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地形渲染ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坐标转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在线平台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中国天气网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.国家水利部信息中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.国家减灾网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全国水雨信息平台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axSceneControl1
            // 
            this.axSceneControl1.Location = new System.Drawing.Point(250, 59);
            this.axSceneControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axSceneControl1.Name = "axSceneControl1";
            this.axSceneControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSceneControl1.OcxState")));
            this.axSceneControl1.Size = new System.Drawing.Size(512, 431);
            this.axSceneControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(741, 0);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 27);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(773, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(11, 59);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(235, 431);
            this.axTOCControl1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载数据ToolStripMenuItem,
            this.坡度分析ToolStripMenuItem,
            this.地形渲染ToolStripMenuItem,
            this.坐标转换ToolStripMenuItem,
            this.在线平台ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(773, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 加载数据ToolStripMenuItem
            // 
            this.加载数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arcScene文档ToolStripMenuItem,
            this.tIN数据ToolStripMenuItem,
            this.DEM数据ToolStripMenuItem});
            this.加载数据ToolStripMenuItem.Name = "加载数据ToolStripMenuItem";
            this.加载数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.加载数据ToolStripMenuItem.Text = "加载数据";
            // 
            // arcScene文档ToolStripMenuItem
            // 
            this.arcScene文档ToolStripMenuItem.Name = "arcScene文档ToolStripMenuItem";
            this.arcScene文档ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arcScene文档ToolStripMenuItem.Text = "ArcScene文档";
            this.arcScene文档ToolStripMenuItem.Click += new System.EventHandler(this.arcScene文档ToolStripMenuItem_Click);
            // 
            // tIN数据ToolStripMenuItem
            // 
            this.tIN数据ToolStripMenuItem.Name = "tIN数据ToolStripMenuItem";
            this.tIN数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tIN数据ToolStripMenuItem.Text = "TIN数据";
            this.tIN数据ToolStripMenuItem.Click += new System.EventHandler(this.tIN数据ToolStripMenuItem_Click);
            // 
            // DEM数据ToolStripMenuItem
            // 
            this.DEM数据ToolStripMenuItem.Name = "DEM数据ToolStripMenuItem";
            this.DEM数据ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DEM数据ToolStripMenuItem.Text = "DEM数据";
            this.DEM数据ToolStripMenuItem.Click += new System.EventHandler(this.DEM数据ToolStripMenuItem_Click);
            // 
            // 坡度分析ToolStripMenuItem
            // 
            this.坡度分析ToolStripMenuItem.Name = "坡度分析ToolStripMenuItem";
            this.坡度分析ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.坡度分析ToolStripMenuItem.Text = "坡度分析";
            this.坡度分析ToolStripMenuItem.Click += new System.EventHandler(this.坡度分析ToolStripMenuItem_Click);
            // 
            // 地形渲染ToolStripMenuItem
            // 
            this.地形渲染ToolStripMenuItem.Name = "地形渲染ToolStripMenuItem";
            this.地形渲染ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.地形渲染ToolStripMenuItem.Text = "地形渲染";
            this.地形渲染ToolStripMenuItem.Click += new System.EventHandler(this.地形渲染ToolStripMenuItem_Click);
            // 
            // 坐标转换ToolStripMenuItem
            // 
            this.坐标转换ToolStripMenuItem.Name = "坐标转换ToolStripMenuItem";
            this.坐标转换ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.坐标转换ToolStripMenuItem.Text = "坐标转换";
            this.坐标转换ToolStripMenuItem.Click += new System.EventHandler(this.坐标转换ToolStripMenuItem_Click);
            // 
            // 在线平台ToolStripMenuItem
            // 
            this.在线平台ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中国天气网ToolStripMenuItem,
            this.国家水利部信息中心ToolStripMenuItem,
            this.国家减灾网ToolStripMenuItem,
            this.全国水雨信息平台ToolStripMenuItem});
            this.在线平台ToolStripMenuItem.Name = "在线平台ToolStripMenuItem";
            this.在线平台ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.在线平台ToolStripMenuItem.Text = "在线平台";
            // 
            // 中国天气网ToolStripMenuItem
            // 
            this.中国天气网ToolStripMenuItem.Name = "中国天气网ToolStripMenuItem";
            this.中国天气网ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.中国天气网ToolStripMenuItem.Text = "中国天气网预警";
            this.中国天气网ToolStripMenuItem.Click += new System.EventHandler(this.中国天气网ToolStripMenuItem_Click);
            // 
            // 国家水利部信息中心ToolStripMenuItem
            // 
            this.国家水利部信息中心ToolStripMenuItem.Name = "国家水利部信息中心ToolStripMenuItem";
            this.国家水利部信息中心ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.国家水利部信息中心ToolStripMenuItem.Text = "国家水利部信息中心";
            this.国家水利部信息中心ToolStripMenuItem.Click += new System.EventHandler(this.国家水利部信息中心ToolStripMenuItem_Click);
            // 
            // 国家减灾网ToolStripMenuItem
            // 
            this.国家减灾网ToolStripMenuItem.Name = "国家减灾网ToolStripMenuItem";
            this.国家减灾网ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.国家减灾网ToolStripMenuItem.Text = "国家减灾网";
            this.国家减灾网ToolStripMenuItem.Click += new System.EventHandler(this.国家减灾网ToolStripMenuItem_Click);
            // 
            // 全国水雨信息平台ToolStripMenuItem
            // 
            this.全国水雨信息平台ToolStripMenuItem.Name = "全国水雨信息平台ToolStripMenuItem";
            this.全国水雨信息平台ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.全国水雨信息平台ToolStripMenuItem.Text = "全国水雨信息平台";
            this.全国水雨信息平台ToolStripMenuItem.Click += new System.EventHandler(this.全国水雨信息平台ToolStripMenuItem_Click);
            // 
            // Scene窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 501);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axSceneControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Scene窗体";
            this.Text = "Scene窗体";
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arcScene文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIN数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DEM数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坡度分析ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地形渲染ToolStripMenuItem;
        public ESRI.ArcGIS.Controls.AxSceneControl axSceneControl1;
        public ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripMenuItem 坐标转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在线平台ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中国天气网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 国家水利部信息中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 国家减灾网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全国水雨信息平台ToolStripMenuItem;
    }
}