using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace EngineWindowsApplication1
{
    public partial class Form2 : Form
    {
        #region 空间查询变量
        //查询方式
        public int mQueryModel;
        //图层索引
        public int mLayerIndex;
        public string mTool;
        public Form2 fm1;


        #endregion


        public Form2()
        {
            InitializeComponent();
            //fm1 = F1;
            //this.m_mapControl = fm1.mapControl;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //初始化空间查询窗体
            Form2 pspatialQueryForm = new Form2();
            if (pspatialQueryForm.ShowDialog() == DialogResult.OK)
            {
                this.mTool = "SpatialQuery";
                //获取查询方式和图层信息
                this.mQueryModel = pspatialQueryForm.mQueryModel;
                this.mLayerIndex = pspatialQueryForm.mLayerIndex;
                //设置鼠标形状
                this.mapControl.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            }

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


        private void Form2_Load(object sender, EventArgs e)
        {
          

        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //清空上次选择的结果
            this.mapControl.Map.ClearSelection();

            switch (mTool)
            {
                case "SpatialQuery":
                    //获取当前视图
                    ESRI.ArcGIS.Carto.IActiveView pActiveView = this.mapControl.ActiveView;
                    //获取鼠标点
                    ESRI.ArcGIS.Geometry.IPoint pPoint = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                    panel1.Visible = true;
                    ESRI.ArcGIS.Geometry.IGeometry pGeometry = null;
                    switch (this.mQueryModel)
                    {
                        case 0:         //矩形查询
                            pGeometry = this.mapControl.TrackRectangle();
                            break;
                        case 1:         //线查询
                            pGeometry = this.mapControl.TrackLine();
                            break;
                        case 2:         //点查询
                            ESRI.ArcGIS.Geometry.ITopologicalOperator pTopo;
                            ESRI.ArcGIS.Geometry.IGeometry pBuffer;
                            pGeometry = pPoint;
                            pTopo = pGeometry as ESRI.ArcGIS.Geometry.ITopologicalOperator;
                            //根据点位创建缓冲区，缓冲半径设为0.1，可自行修改
                            pBuffer = pTopo.Buffer(0.1);
                            pGeometry = pBuffer.Envelope;
                            break;
                        case 3:         //圆查询
                            pGeometry = this.mapControl.TrackCircle();
                            break;
                    }
                    ESRI.ArcGIS.Carto.IFeatureLayer pFeatureLayer = this.mapControl.Map.get_Layer(this.mLayerIndex) as ESRI.ArcGIS.Carto.IFeatureLayer;
                    DataTable pDataTable = this.LoadQueryResult(mapControl, pFeatureLayer, pGeometry);
                    this.dataGridView1.DataSource = pDataTable.DefaultView;
                    this.dataGridView1.Refresh();
                    break;
                default:
                    break;
            }
        }
    }
}

