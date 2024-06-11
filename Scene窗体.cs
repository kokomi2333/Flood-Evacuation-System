using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Animation;
using ESRI.ArcGIS.Carto;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace EngineWindowsApplication1
{

    public partial class Scene窗体 : Form
    {
        public Scene窗体()
        {
            InitializeComponent();
        }


        private void arcScene文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "加载ArcScene文档";
            pOpenFileDialog.Filter = "ArcScene文档(*.sxd)|*.sxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                    return;

                if (axSceneControl1.CheckSxFile(pFileName)) // 检查地图文档是否有效
                {
                    axSceneControl1.Scene.ClearLayers();
                    axSceneControl1.LoadSxFile(pFileName); // 加载地图文档
                }
                else
                {
                    MessageBox.Show(pFileName + "请加载有效的ArcScene文档！", "信息提示");
                    return;
                }
            }
        }

        private void DEM数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISceneGraph pSG = axSceneControl1.SceneGraph;
                IScene pS = pSG.Scene;
                IRasterLayer pRL = new RasterLayerClass();
                ILayer pLayer;

                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.Title = "加载DEM文档";
                pOpenFileDialog.Filter = "DEM文档(*.*)|*.tif;*.dem;*.gdb;*.jpg|TIF文档(*.tif)|*.tif|DEM文件(*.dem)|*.dem|栅格数据集(*.gdb)|*.gdb|JPEG文件(*.jpg)|*.jpg";

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                    string pPathName = pOpenFileDialog.FileName;
                    string pPath = pPathName.Substring(0, pPathName.LastIndexOf('\\'));
                    string fileName = pPathName.Substring(pPath.Length + 1, pPathName.Length - pPath.Length - 1);

                    IWorkspaceFactory pwsf = new RasterWorkspaceFactoryClass();
                    IRasterWorkspace pRasterWorkspace;
                if (pwsf.IsWorkspace(pPath))
                {
                        pRasterWorkspace = pwsf.OpenFromFile(pPath, 0) as IRasterWorkspace;
                        IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(fileName);
                        pRL.CreateFromDataset(pRasterDataset);
                        pLayer = pRL as ILayer;
                        pS.AddLayer(pLayer, true);
                        pSG.RefreshViewers();
                }

                else
                {
                        MessageBox.Show(pPath + "请加载有效的DEM文档！", "信息提示");
                        return;
                }
            }
        }

        private void tIN数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ISceneGraph pSceneGraph = this.axSceneControl1.SceneGraph;
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                IScene pScene = pSceneGraph.Scene;
                ITinLayer tinLayer = new TinLayerClass();
                FileInfo fileInfo;
                string tinPath;
                IWorkspaceFactory tinWorkspaceFactory = new TinWorkspaceFactoryClass();
                ITinWorkspace tinWorkspace;
                ITin tin;

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    tinPath = folderBrowserDialog1.SelectedPath;
                    fileInfo = new FileInfo(tinPath);
                    if (tinWorkspaceFactory.IsWorkspace(fileInfo.DirectoryName))
                    {
                        tinWorkspace = tinWorkspaceFactory.OpenFromFile(fileInfo.DirectoryName, 0) as ITinWorkspace;
                        //tinWorkspace.OpenTin(fileInfo.DirectoryName);
                        tin = tinWorkspace.OpenTin(fileInfo.Name);
                        tinLayer.Dataset = tin;
                        tinLayer.Visible = true;
                        tinLayer.Name = fileInfo.Name;
                        pScene.AddLayer(tinLayer as ILayer, true);
                        pSceneGraph.RefreshViewers();
                    }
                }

                else
                {
                MessageBox.Show( "请加载有效的TIN文档！", "信息提示");
                return;
                }


        }

        private void 地形渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Render render = new Render(this);
            //
            //render.Show();
            try
            {
                IScene scene = axSceneControl1.Scene;
                ILayer layer = scene.get_Layer(0);
                IRasterLayer pRasterLayer = layer as IRasterLayer;
                IRaster raster = (IRaster)pRasterLayer.Raster;
                IRasterBandCollection rasterbands = raster as IRasterBandCollection;
                IRasterBand rasterband = rasterbands.Item(0);
                IRasterStretchColorRampRenderer pRStretchRender = new RasterStretchColorRampRendererClass();
                //创建两个起始颜色
                IRgbColor pFromRgbColor = new RgbColorClass();
                pFromRgbColor.Red = 40;
                pFromRgbColor.Green = 30;
                pFromRgbColor.Blue = 250;
                IRgbColor pToRgbColor = new RgbColorClass();
                pToRgbColor.Red = 240;
                pToRgbColor.Green = 80;
                pToRgbColor.Blue = 40;
                //创建起始色带
                IAlgorithmicColorRamp pAlgorithmicColorRamp = new AlgorithmicColorRampClass();
                pAlgorithmicColorRamp.Size = 255;
                pAlgorithmicColorRamp.FromColor = pFromRgbColor as IColor;
                pAlgorithmicColorRamp.ToColor = pToRgbColor as IColor;
                bool btrue = true;
                pAlgorithmicColorRamp.CreateRamp(out btrue);
                //选择拉伸颜色带符号化的波段
                pRStretchRender.BandIndex = 1;
                //设置拉伸颜色带符号化所采用的颜色带
                pRStretchRender.ColorRamp = pAlgorithmicColorRamp as IColorRamp;
                IRasterRenderer pRasterRender = pRStretchRender as IRasterRenderer;
                pRasterLayer = scene.get_Layer(0) as IRasterLayer;
                pRasterRender.Raster = pRasterLayer as IRaster;
                pRasterRender.Update();
                //符号化RasterLayer
                pRasterLayer.Renderer = pRasterRender;
                //渲染的刷新
                axSceneControl1.Scene.SceneGraph.Invalidate(pRasterLayer, true, false);
                axSceneControl1.SceneViewer.Redraw(true);
                axSceneControl1.Scene.SceneGraph.RefreshViewers();
                axTOCControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, pRasterLayer, axSceneControl1.Scene.Extent);
                axTOCControl1.Update();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 坡度分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            坡度分析 nextForm = new 坡度分析();

            // 显示新窗体为模态对话框
            nextForm.ShowDialog();
        }

        private void 坐标转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPoint TransformCoordinate(IPoint point, ISpatialReference sourceSrs, ISpatialReference targetSrs)
            {
                // 创建空间参考转换工厂  
                SpatialReferenceTransformFactoryClass spatialReferenceTransformFactoryClass = new SpatialReferenceTransformFactoryClass();
                ISpatialReferenceTransformFactory transformFactory = (ISpatialReferenceTransformFactory)spatialReferenceTransformFactoryClass;

                // 尝试创建空间参考转换对象  
                ISpatialReferenceTransform transform = transformFactory.CreateTransform(sourceSrs, targetSrs);

                if (transform == null)
                {
                    // 转换对象创建失败，可能是因为源和目标空间参考不兼容  
                    // 这里可以抛出异常，记录错误，或者返回null等  
                    throw new InvalidOperationException("Unable to create spatial reference transform between the source and target spatial references.");
                }

                // 假设 point 是已经存在的 IPoint 对象  
                if (point != null)
                {
                    // 使用转换对象来转换点  
                    IPoint transformedPoint = (IPoint)transform.TransformPoint(point);

                    // 返回转换后的点  
                    return transformedPoint;
                }
                else
                {
                    // 点对象为null，抛出异常或返回null等  
                    throw new ArgumentNullException("The point to be transformed is null.");
                }
                // 转换点坐标  
                IGeometry transformedGeometry = transform.Transform2D(point as IGeometry);

                // 确保转换后的对象仍然是点  
                return transformedGeometry as IPoint;
            }
        }
    }
}
