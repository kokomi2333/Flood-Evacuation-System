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
                pOpenFileDialog.Filter = "DEM文档(*.tif)|*.tif";

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
    }
}
