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

namespace EngineWindowsApplication1
{

    public partial class Scene窗体 : Form
    {
        public Scene窗体()
        {
            InitializeComponent();
        }

        private string GetDataPath()
        {
            string path = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开ArcScene文件";
            openFileDialog.Filter = "ArcScene文件(*.sxd)|*.sxd";
            openFileDialog.ShowDialog();
            path = openFileDialog.FileName;
            return path;
        }


        private void arcScene文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetDataPath();
            if (axSceneControl1.CheckSxFile(path))
            {
                axSceneControl1.LoadSxFile(path);
                axSceneControl1.SceneGraph.RefreshViewers();
            }
            else
            {
                MessageBox.Show("请加载正确的ArcScene文件！", "信息提示");
            }
        }

        private void DEM数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
               
        }

        private void tIN数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
