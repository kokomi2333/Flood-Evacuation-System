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
        //public Form1 fm;
        Form2 fm;

        #endregion

        public Form3(Form2 mainfm)
        {
            InitializeComponent();
            fm = mainfm;
            this.m_mapControl = fm.mapControl;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //comboBox1 = m_mapControl.get_Layer(0) as IFeatureLayer;
            //MapControl没有图层返回
            if (m_mapControl.LayerCount <= 0)
                return;
            //获取MapControl中的全部图层名称，并加入ComboBox
            for (int i = 0; i < m_mapControl.LayerCount; ++i)
            {
                comboBox1.Items.Add(m_mapControl.get_Layer(i).Name);
            }
            //加载查询方式
            this.comboBox2.Items.Add("矩形查询");
            this.comboBox2.Items.Add("线查询");
            this.comboBox2.Items.Add("点查询");
            this.comboBox2.Items.Add("圆查询");
            //初始化ComboBox默认值
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            fm.panel1.Visible = false;
            fm.mapControl.ActiveView.FocusMap.ClearSelection();
            fm.mapControl.Refresh();
        }
    }
}
