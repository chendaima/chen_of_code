using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureBianhao
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int PictureNumber = 0;
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        List<string> imageFiles = new List<string>();
        private void button2_Click(object sender, EventArgs e)
        {
       
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please choose image path.";
            DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string folderPath = dialog.SelectedPath.Trim();
            DirectoryInfo theFolder = new DirectoryInfo(folderPath);
            if (theFolder.Exists)
            {
                getFiles(folderPath, "jpg", ref imageFiles, false);   
             }
            for (int i = 0; i < imageFiles.Count; i++)
            {
                PictureNumber += 1;
                Image img = Image.FromFile(imageFiles[i]);
                img.Save("D:\\Pictures\\image_5_7" + PictureNumber + ".jpg");
            }
          
        }

        /////param
        ///path：文件夹路径
        ///suffix：后缀格式， 如bmp，txt
        ///fileList:文件名存放
        ///isSubcatalog:true遍历子文件夹，否则不遍历
        void getFiles(string path, string suffix,ref List<string> fileList, bool isSubcatalog)
        {
            string filename;
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] file = dir.GetFiles();
            //DirectoryInfo[] dii = dir.GetDirectories();//如需遍历子文件夹时需要使用
            foreach (FileInfo f in file)
            {
                filename = f.FullName;
                if (filename.EndsWith(suffix))//判断文件后缀，并获取指定格式的文件全路径增添至fileList
                {
                     fileList.Add(filename);
                }
            }
          //  获取子文件夹内的文件列表，递归遍历
          //if (isSubcatalog)
          //  {
          //      foreach (DirectoryInfo d in dii)
          //      {
          //          getFiles(d.FullName, fileList);
          //      }
          //  }

            return;
        }
    }
}
