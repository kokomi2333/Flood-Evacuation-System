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
    public partial class 第一窗口 : Form
    {
        public 第一窗口()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scene窗体 nextForm = new Scene窗体();

            // 显示新窗体为模态对话框
            nextForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 nextForm = new Form1();

            // 显示新窗体为模态对话框
            nextForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form0 nextForm = new Form0();

            // 显示新窗体为模态对话框
            nextForm.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

