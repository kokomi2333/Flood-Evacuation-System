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
using ESRI.ArcGIS.Carto;

namespace EngineWindowsApplication1
{
    public partial class 坡度分析 : Form
    {
        public 坡度分析()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ISceneGraph pSceneGraph = Scene窗体.axSceneControl1.SceneGraph;
            IScene pScene = pSceneGraph.Scene;
            IRasterLayer pRasterLayer = new RasterLayerClass();
            ILayer pLayer;

            this.openFileDialog1.Title = "加载DEM数据";
            this.openFileDialog1.DefaultExt = ".TIF";
            this.openFileDialog1.Filter = "(*.tif)|*.tif";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inPutPath = this.openFileDialog1.FileName;
                string pPath = inPutPath.Substring(0, inPutPath.LastIndexOf('\\'));
                string fileName = inPutPath.Substring(pPath.Length + 1, inPutPath.Length - pPath.Length - 1);
                IWorkspaceFactory pwsf = new RasterWorkspaceFactoryClass();
                IRasterWorkspace pRasterWorkspace;
                if (pwsf.IsWorkspace(pPath))
                {
                    pRasterWorkspace = pwsf.OpenFromFile(pPath, 0) as IRasterWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(fileName);
                    //pRasterDataset.OpenFromFile(pPath);
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    pLayer = pRasterLayer as ILayer;
                    cmbRasterInput.Text = inPutPath;
                    //pScene.AddLayer(pLayer);
                    pScene.ExaggerationFactor = 6;
                    //threed.axTOCControl1.Update();
                    //pSceneGraph.RefreshViewers();

                }
            }
        }
    }
}
