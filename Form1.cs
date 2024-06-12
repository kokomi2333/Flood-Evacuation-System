using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using System;
using ESRI.ArcGIS.Controls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EngineWindowsApplication1
{
    public partial class Form1 : Form
    {
        #region 空间查询变量
        //查询方式
        public int mQueryModel;
        //图层索引
        public int mLayerIndex;
        public string mTool;
        public Form2 fm1;


        #endregion


        //TOC菜单
        IFeatureLayer pTocFeatureLayer = null;            //点击的要素图层
        private FormAtrribute frmAttribute = null;        //图层属性窗体


        //#region TOC右键菜单的添加及功能实现
        private Point pMoveLayerPoint = new Point();  //鼠标在TOC中左键按下时点的位置


        public Form1()
        {
            InitializeComponent();
        }

        private void axLicenseControl1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void axToolbarControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {


        }

        private void sjbszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAttribute == null || frmAttribute.IsDisposed)
            {
                frmAttribute = new FormAtrribute();
            }
            frmAttribute.CurFeatureLayer = pTocFeatureLayer;
            frmAttribute.InitUI();
            frmAttribute.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveLayer_Click(object sender, EventArgs e)
        {
            //缩放到图层

            if (pTocFeatureLayer == null) return;
            (axMapControl1.Map as IActiveView).Extent = pTocFeatureLayer.AreaOfInterest;
            (axMapControl1.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        private void btnZoomToLayer_Click(object sender, EventArgs e)
        {
            if (pTocFeatureLayer == null) return;
            DialogResult result = MessageBox.Show("是否删除[" + pTocFeatureLayer.Name + "]图层", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                axMapControl1.Map.DeleteLayer(pTocFeatureLayer);
            }
            axMapControl1.ActiveView.Refresh();

        }

        private void btnLayerSel_Click(object sender, EventArgs e)
        {

            pTocFeatureLayer.Selectable = true;
            btnLayerSel.Enabled = !btnLayerSel.Enabled;


        }

        private void btnLayerUnSel_Click(object sender, EventArgs e)
        {
            pTocFeatureLayer.Selectable = false;
            btnLayerUnSel.Enabled = !btnLayerUnSel.Enabled;

        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            
    }

        private void AxTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 2)
            {
                esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pMap = null;
                ILayer pLayer = null;
                object unk = null;
                object data = null;
            axTOCControl1.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                pTocFeatureLayer = pLayer as IFeatureLayer;
                if (pItem == esriTOCControlItem.esriTOCControlItemLayer && pTocFeatureLayer != null)
                {
                    btnLayerSel.Enabled = !pTocFeatureLayer.Selectable;
                    btnLayerUnSel.Enabled = pTocFeatureLayer.Selectable;
                    ContextMenuStrip.Show(Control.MousePosition);
                }
            }
        }

        private void 打开地图文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开ArcMap文档";
            pOpenFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                    return;

                if (axMapControl1.CheckMxFile(pFileName)) // 检查地图文档是否有效
                {
                    axMapControl1.Map.ClearLayers();
                    axMapControl1.LoadMxFile(pFileName); // 加载地图文档
                }
                else
                {
                    MessageBox.Show(pFileName + "请加载正确有效的ArcScene文档！", "信息提示");
                    return;
                }
            }
        }

        private void 打开cadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "打开 CAD 文件";
                openFileDialog.Filter = "CAD 文件 (*.dwg, *.dxf)|*.dwg;*.dxf";
                openFileDialog.Multiselect = false; // Allow only one file to be selected
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        IWorkspaceFactory pWorkspaceFactory;
                        IFeatureWorkspace pFeatureWorkspace;
                        IFeatureLayer pFeatureLayer;

                        // Initialize workspace factory and open CAD workspace
                        pWorkspaceFactory = new CadWorkspaceFactory();
                        pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(selectedFilePath, 0);

                        // Open feature class and create feature layer
                        IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass("FeatureClassName"); // Replace "FeatureClassName" with the name of the feature class in the CAD file
                        pFeatureLayer = new FeatureLayer();
                        pFeatureLayer.FeatureClass = pFeatureClass;
                        pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;


                        axMapControl1.Map.AddLayer(pFeatureLayer);
                        axMapControl1.ActiveView.Refresh();
                 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }

        private void 打开shp文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "打开Shape文件";
                openFileDialog.Filter = "Shape文件 (*.shp)|*.shp";
                openFileDialog.Multiselect = false; // Allow only one file to be selected
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        IWorkspaceFactory pWorkspaceFactory;
                        IFeatureWorkspace pFeatureWorkspace;
                        IFeatureLayer pFeatureLayer;

                        // Extract file path and file name
                        string pFilePath = Path.GetDirectoryName(selectedFilePath);
                        string pFileName = Path.GetFileName(selectedFilePath);

                        // Initialize workspace factory and open shapefile workspace
                        pWorkspaceFactory = new ShapefileWorkspaceFactory();
                        pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);

                        // Open feature class and create feature layer
                        IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                        pFeatureLayer = new FeatureLayer();
                        pFeatureLayer.FeatureClass = pFeatureClass;
                        pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;

                        // Clear all existing data

                        axMapControl1.Map.AddLayer(pFeatureLayer);
                        axMapControl1.ActiveView.Refresh();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }

        private void 打开栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.CheckFileExists = true;
                openFileDialog.Title = "打开栅格文件";
                openFileDialog.Filter = "栅格文件 (*.bmp;*.tif;*.jpg;*.img)|*.bmp;*.tif;*.jpg;*.img";
                openFileDialog.Multiselect = false; // Allow only one file to be selected
                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        IWorkspaceFactory pWorkspaceFactory;
                        IRasterWorkspace pRasterWorkspace;
                        IRasterLayer pRasterLayer;

                        // Extract file path and file name
                        string pFilePath = Path.GetDirectoryName(selectedFilePath);
                        string pFileName = Path.GetFileName(selectedFilePath);

                        // Initialize workspace factory and open raster workspace
                        pWorkspaceFactory = new RasterWorkspaceFactory();
                        pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);

                        // Open raster dataset and create raster layer
                        IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);
                        pRasterLayer = new RasterLayer();
                        pRasterLayer.CreateFromDataset((ESRI.ArcGIS.Geodatabase.IRasterDataset)pRasterDataset);

                        // Add raster layer to map control
                        axMapControl1.Map.AddLayer(pRasterLayer);
                        axMapControl1.ActiveView.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }

        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 空间查询ToolStripMenuItem_Click(object sender, EventArgs e)

        {
            Form1 pspatialQueryForm = new Form1();
            if (pspatialQueryForm.ShowDialog() == DialogResult.OK)
            {
                this.mTool = "SpatialQuery";
                //获取查询方式和图层信息
                this.mQueryModel = pspatialQueryForm.mQueryModel;
                this.mLayerIndex = pspatialQueryForm.mLayerIndex;
                //设置鼠标形状
                this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            }
            //初始化空间查询窗体

        }
        private DataTable LoadQueryResult(ESRI.ArcGIS.Controls.AxMapControl mapControl, ESRI.ArcGIS.Carto.IFeatureLayer featureLayer, ESRI.ArcGIS.Geometry.IGeometry geometry)
        {
            ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureClass = featureLayer.FeatureClass;
            //根据图层属性字段初始化DataTable
            ESRI.ArcGIS.Geodatabase.IFields pFields = pFeatureClass.Fields;
            DataTable pDataTable = new DataTable();
            for (int i = 0; i < pFields.FieldCount; ++i)
            {
                pDataTable.Columns.Add(pFields.get_Field(i).AliasName);
            }
            //空间过滤器
            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new ESRI.ArcGIS.Geodatabase.SpatialFilterClass();
            pSpatialFilter.Geometry = geometry;
            //根据图层类型选择缓冲方式
            switch (pFeatureClass.ShapeType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelContains;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    pSpatialFilter.SpatialRel = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
            }
            //定义空间过滤器的空间字段
            pSpatialFilter.GeometryField = pFeatureClass.ShapeFieldName;
            ESRI.ArcGIS.Geodatabase.IQueryFilter pQueryFilter;
            ESRI.ArcGIS.Geodatabase.IFeatureCursor pFeatureCursor;
            ESRI.ArcGIS.Geodatabase.IFeature pFeature;
            //利用要素过滤器查询要素
            pQueryFilter = pSpatialFilter as ESRI.ArcGIS.Geodatabase.IQueryFilter;
            pFeatureCursor = featureLayer.Search(pQueryFilter, true);
            pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string strFldValue = null;
                DataRow dr = pDataTable.NewRow();
                //遍历图层属性表字段值，并加入pDataTable
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    string strFldName = pFields.get_Field(i).Name;
                    if (strFldName == "Shape")
                    {
                        strFldValue = Convert.ToString(pFeature.Shape.GeometryType);
                    }
                    else
                        strFldValue = Convert.ToString(pFeature.get_Value(i));
                    dr[i] = strFldValue;
                }
                pDataTable.Rows.Add(dr);
                //高亮选择要素
                mapControl.Map.SelectFeature((ESRI.ArcGIS.Carto.ILayer)featureLayer, pFeature);
                mapControl.ActiveView.Refresh();
                pFeature = pFeatureCursor.NextFeature();
            }

            return pDataTable;

        }


        private void 查询菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }

 
