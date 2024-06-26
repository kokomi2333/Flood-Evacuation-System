﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Geodatabase;

namespace EngineWindowsApplication1
{
    public partial class 坡度分析 : Form
    {
        Scene窗体 sfrm;

        private string inPutPath;
        private string outPutPath;

        public 坡度分析()
        {
            InitializeComponent();
            inPutPath = "";
            outPutPath = "";
            sfrm = new Scene窗体();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void axToolbarControl1_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {
            ISceneGraph pSceneGraph = sfrm.axSceneControl1.SceneGraph;
            IScene pScene = pSceneGraph.Scene;
            IRasterLayer pRasterLayer = new RasterLayerClass();
            ILayer pLayer;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "加载DEM数据";
            openFileDialog1.DefaultExt = ".TIF";
            openFileDialog1.Filter = "DEM数据(*.tif)|*.tif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inPutPath = openFileDialog1.FileName;
                string pPath = inPutPath.Substring(0, inPutPath.LastIndexOf('\\'));
                string fileName = inPutPath.Substring(pPath.Length + 1, inPutPath.Length - pPath.Length - 1);
                IWorkspaceFactory pwsf = new RasterWorkspaceFactoryClass();
                IRasterWorkspace pRasterWorkspace;
                if (pwsf.IsWorkspace(pPath))
                {
                    pRasterWorkspace = pwsf.OpenFromFile(pPath, 0) as IRasterWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(fileName);
                    
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    pLayer = pRasterLayer as ILayer;
                    comboBox1.Text = inPutPath;
                    pScene.AddLayer(pLayer);
                    pScene.ExaggerationFactor = 6;
                    comboBox1.Update();
                    pSceneGraph.RefreshViewers();
                }
            }
        }

        private void axToolbarControl2_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TIFF(*tif)|*.tif";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                outPutPath = sfd.FileName.ToString();
                string fileNameExt = outPutPath.Substring(outPutPath.LastIndexOf("\\") + 1);
            }
            comboBox2.Text = outPutPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //定义一个栅格工作空间工厂
            IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
            //FileInfo—提供创建、复制、删除、移动和打开文件的实力方法，获取进行坡度分析的文件名
            FileInfo fileInfo = new FileInfo(inPutPath);//字符串inPutPath是上文加载TIFF文件时传入的文件名
            FileInfo fileOut = new FileInfo(outPutPath);
            //定义获取目录的完整路径的字符串变量
            string filePath = fileInfo.DirectoryName;
            string filep = fileOut.DirectoryName;
            //定义获取文件名的字符串变量
            string fileName = fileInfo.Name;

            //打开指定工作空间工厂的文件名
            IRasterWorkspace workspace = workspaceFactory.OpenFromFile(filePath, 0) as IRasterWorkspace;
            IRasterWorkspace work = workspaceFactory.OpenFromFile(filep, 0) as IRasterWorkspace;
            //定义ILayer变量，获取SceneControl中第0层的影像
            ILayer layer = sfrm.axSceneControl1.Scene.get_Layer(0);
            //定义IRasterLayer变量，把layer强制转换成IRasterLayer
            IRasterLayer rasterLayer = layer as IRasterLayer;
            //在工作空间工厂内打开一个RasterDataset，并指定其名称
            IRasterDataset rasterDataset = workspace.OpenRasterDataset(fileName);
            //栅格表面分析
            ISurfaceOp surfaceOp = new RasterSurfaceOpClass();
            //定义了提供访问控制栅格分析环境的成员
            IRasterAnalysisEnvironment rasterAnalysisEnveronment;
            //栅格分析环境设置，设置为表面分析
            rasterAnalysisEnveronment = surfaceOp as IRasterAnalysisEnvironment;
            //设置输出的工作目录工作空间，目录
            rasterAnalysisEnveronment.OutWorkspace = work as IWorkspace;
            object zFactor = new object();
            //IGeoDtaaset—提供对成员的访问，提供有关地理数据集的信息
            IGeoDataset geoDataset, rasterGeoDataset;
            rasterGeoDataset = rasterDataset as IGeoDataset;
            //通过Slope方法，设置相应参数，获取坡度分析
            //得到坡度分析数据集

            geoDataset = surfaceOp.Slope(rasterGeoDataset, esriGeoAnalysisSlopeEnum.esriGeoAnalysisSlopeDegrees, Type.Missing);

            IRasterLayer pSARLayer = new RasterLayerClass();
            //当栅格数据为单个栅格数据时
            pSARLayer.CreateFromRaster(geoDataset as IRaster);
            //当栅格数据为栅格数据集时使用该代码显示
            //pSARLayer.CreateFromDataset((IRasterDataset)geoDataset);
            sfrm.axSceneControl1.Scene.AddLayer(pSARLayer);
            sfrm.axSceneControl1.Refresh();

            //一个栅格数据集由一个或者多个波段（RasterBand）的数据组成，一个波段就是一个数据矩阵
            IRasterBandCollection rasterBandCollection = geoDataset as IRasterBandCollection;
            //将坡度分析得到的数据存储于Workspace读取的工作目录中
            rasterBandCollection.SaveAs("outPutPath.tif", work as IWorkspace, "TIFF");

            MessageBox.Show("生成tif成功，请在主窗体中加载！", "提示");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sfrm.axSceneControl1.Visible = false;
            sfrm.axSceneControl1.Scene.ClearSelection();
            sfrm.axSceneControl1.Refresh();
            this.Close();
        }
    }
}
