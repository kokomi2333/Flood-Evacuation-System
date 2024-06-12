
namespace EngineWindowsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLayerSel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLayerUnSel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开cadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开shp文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开地图文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(3, 62);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(315, 530);
            this.axTOCControl1.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(1060, 703);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            this.axLicenseControl1.Enter += new System.EventHandler(this.axLicenseControl1_Enter);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(310, 30);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(496, 28);
            this.axToolbarControl1.TabIndex = 4;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAttribute,
            this.btnLayerSel,
            this.btnLayerUnSel,
            this.btnZoomToLayer,
            this.btnRemoveLayer});
            this.ContextMenuStrip.Name = "contextMenuStrip1";
            this.ContextMenuStrip.Size = new System.Drawing.Size(154, 124);
            this.ContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // btnAttribute
            // 
            this.btnAttribute.Name = "btnAttribute";
            this.btnAttribute.Size = new System.Drawing.Size(153, 24);
            this.btnAttribute.Text = "属性表";
            this.btnAttribute.Click += new System.EventHandler(this.sjbszToolStripMenuItem_Click);
            // 
            // btnLayerSel
            // 
            this.btnLayerSel.Name = "btnLayerSel";
            this.btnLayerSel.Size = new System.Drawing.Size(153, 24);
            this.btnLayerSel.Text = "可选图层";
            this.btnLayerSel.Click += new System.EventHandler(this.btnLayerSel_Click);
            // 
            // btnLayerUnSel
            // 
            this.btnLayerUnSel.Name = "btnLayerUnSel";
            this.btnLayerUnSel.Size = new System.Drawing.Size(153, 24);
            this.btnLayerUnSel.Text = "不可选图层";
            this.btnLayerUnSel.Click += new System.EventHandler(this.btnLayerUnSel_Click);
            // 
            // btnZoomToLayer
            // 
            this.btnZoomToLayer.Name = "btnZoomToLayer";
            this.btnZoomToLayer.Size = new System.Drawing.Size(153, 24);
            this.btnZoomToLayer.Text = "移除图层";
            this.btnZoomToLayer.Click += new System.EventHandler(this.btnZoomToLayer_Click);
            // 
            // btnRemoveLayer
            // 
            this.btnRemoveLayer.Name = "btnRemoveLayer";
            this.btnRemoveLayer.Size = new System.Drawing.Size(153, 24);
            this.btnRemoveLayer.Text = "缩放到图层";
            this.btnRemoveLayer.Click += new System.EventHandler(this.btnRemoveLayer_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(278, 62);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(896, 527);
            this.axMapControl1.TabIndex = 7;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.查询菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1341, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开cadToolStripMenuItem,
            this.打开shp文件ToolStripMenuItem,
            this.打开栅格文件ToolStripMenuItem,
            this.打开地图文件ToolStripMenuItem});
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.打开ToolStripMenuItem.Text = "文件菜单";
            // 
            // 打开cadToolStripMenuItem
            // 
            this.打开cadToolStripMenuItem.Name = "打开cadToolStripMenuItem";
            this.打开cadToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.打开cadToolStripMenuItem.Text = "打开cad";
            this.打开cadToolStripMenuItem.Click += new System.EventHandler(this.打开cadToolStripMenuItem_Click);
            // 
            // 打开shp文件ToolStripMenuItem
            // 
            this.打开shp文件ToolStripMenuItem.Name = "打开shp文件ToolStripMenuItem";
            this.打开shp文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.打开shp文件ToolStripMenuItem.Text = "打开shp文件";
            this.打开shp文件ToolStripMenuItem.Click += new System.EventHandler(this.打开shp文件ToolStripMenuItem_Click);
            // 
            // 打开栅格文件ToolStripMenuItem
            // 
            this.打开栅格文件ToolStripMenuItem.Name = "打开栅格文件ToolStripMenuItem";
            this.打开栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.打开栅格文件ToolStripMenuItem.Text = "打开栅格文件";
            this.打开栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.打开栅格文件ToolStripMenuItem_Click);
            // 
            // 打开地图文件ToolStripMenuItem
            // 
            this.打开地图文件ToolStripMenuItem.Name = "打开地图文件ToolStripMenuItem";
            this.打开地图文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.打开地图文件ToolStripMenuItem.Text = "打开地图文件";
            this.打开地图文件ToolStripMenuItem.Click += new System.EventHandler(this.打开地图文件ToolStripMenuItem_Click);
            // 
            // 查询菜单ToolStripMenuItem
            // 
            this.查询菜单ToolStripMenuItem.Name = "查询菜单ToolStripMenuItem";
            this.查询菜单ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.查询菜单ToolStripMenuItem.Text = "查询菜单";
            this.查询菜单ToolStripMenuItem.Click += new System.EventHandler(this.查询菜单ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EngineWindowsApplication1.Properties.Resources._01b6a25baafaf7a801213dea5c9797_jpg_2o;
            this.ClientSize = new System.Drawing.Size(1341, 621);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axTOCControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem btnAttribute;
        private System.Windows.Forms.ToolStripMenuItem btnLayerSel;
        private System.Windows.Forms.ToolStripMenuItem btnLayerUnSel;
        private System.Windows.Forms.ToolStripMenuItem btnZoomToLayer;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveLayer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开cadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开shp文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开地图文件ToolStripMenuItem;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
    }
}

