using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EngineWindowsApplication1
{
    public partial class Form1 : Form
    {
        
        //TOC�˵�
        IFeatureLayer pTocFeatureLayer = null;            //�����Ҫ��ͼ��
        private FormAtrribute frmAttribute = null;        //ͼ�����Դ���


        //#region TOC�Ҽ��˵�����Ӽ�����ʵ��
        private Point pMoveLayerPoint = new Point();  //�����TOC���������ʱ���λ��


        public Form1()
        {
            InitializeComponent();
        }

        private void axLicenseControl1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "��ArcMap�ĵ�";
            pOpenFileDialog.Filter = "ArcMap�ĵ�(*.mxd)|*.mxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                    return;

                if (axMapControl1.CheckMxFile(pFileName)) // ����ͼ�ĵ��Ƿ���Ч
                {
                    axMapControl1.Map.ClearLayers();
                    axMapControl1.LoadMxFile(pFileName); // ���ص�ͼ�ĵ�
                }
                else
                {
                    MessageBox.Show(pFileName + "�������ȷ��Ч��ArcScene�ĵ���", "��Ϣ��ʾ");
                    return;
                }
            }
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
            //���ŵ�ͼ��
           
                if (pTocFeatureLayer == null) return;
                (axMapControl1.Map as IActiveView).Extent = pTocFeatureLayer.AreaOfInterest;
                (axMapControl1.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }

        private void btnZoomToLayer_Click(object sender, EventArgs e)
        {
            if (pTocFeatureLayer == null) return;
            DialogResult result = MessageBox.Show("�Ƿ�ɾ��[" + pTocFeatureLayer.Name + "]ͼ��", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
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
    }
    }
