using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureBianhao
{
    public partial class Form1 : Form
    {
        public int PictureNumber = 0;
        public int CaptureInterval = 100;
        public Form1()
        {
            InitializeComponent();
        }
        string[] files;//选择文件的集合，此处声明数组是因为openFileDialog1.FileNames返回值为string[]
        FileInfo fi;//创建一个FileInfo对象，用于获取文件信息
        string[] lvFiles = new string[7];//向控件中添加的行信息
        Thread td;//处理批量更名方法的线程

        bool flag = true;


        bool IsOK = false;//判断是否应用了模板
            
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureNumber = 0;
            timer1.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CaptureInterval += 100;
            label2.Text = CaptureInterval.ToString();
            timer1.Interval = CaptureInterval;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CaptureInterval > 100)
            {
                CaptureInterval -= 100;
                label2.Text = CaptureInterval.ToString();
                timer1.Interval = CaptureInterval;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //截取屏幕，然后生成图片
            PictureNumber += 1;
            SendKeys.Send("{PRTSC}");
            Image img = Clipboard.GetImage();
            img.Save("D:\\Pictures\\image_5_7" + PictureNumber + ".jpg");
            pictureBox1.Image = img;

            //获取图片文件夹，生成新的图片编号
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fro = new Form2();
            fro.ShowDialog();
        }
    }
}
