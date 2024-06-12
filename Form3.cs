using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngineWindowsApplication1
{
    public partial class Form3 : Form
    {
        #region Class Numble
        //获取主窗体mapControl对象
        public ESRI.ArcGIS.Controls.AxMapControl m_mapControl;
        //查询方式
        public int mQueryModel;
        //图层索引
        public int mLayerIndex;
        //public IFeatureLayer comboBox1;
        public Form2 fm;

        #endregion

        public Form3()
        {
            InitializeComponent();
            fm = new Form2();
            this.m_mapControl = fm.mapControl;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //判断图层数量
            if (this.comboBox1.Items.Count <= 0)
            {
                MessageBox.Show("当前MapControl没有添加图层！", "提示");
                return;
            }
            //获取选中的查询方式和图层索引
            this.mLayerIndex = comboBox1.SelectedIndex;
            this.mQueryModel = comboBox2.SelectedIndex;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fm.panel1.Visible = false;
            fm.mapControl.ActiveView.FocusMap.ClearSelection();
            fm.mapControl.Refresh();
        }
    }
}
