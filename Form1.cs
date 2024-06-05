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

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "��ArcScene�ĵ�";
            pOpenFileDialog.Filter = "ArcScene�ĵ�(*.sxd)|*.sxd";
            pOpenFileDialog.Multiselect = false;
            pOpenFileDialog.RestoreDirectory = true;

            if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pFileName = pOpenFileDialog.FileName;
                if (pFileName == "")
                    return;

                if (axSceneControl1.CheckSxFile(pFileName)) // ����ͼ�ĵ��Ƿ���Ч
                {
                    axSceneControl1.Scene.ClearLayers();
                    axSceneControl1.LoadSxFile(pFileName); // ���ص�ͼ�ĵ�
                }
                else
                {
                    MessageBox.Show(pFileName + "�������ȷ��Ч��ArcScene�ĵ���", "��Ϣ��ʾ");
                    return;
                }
            }
        }
    }
}