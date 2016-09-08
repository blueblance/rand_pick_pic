using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace rand_pick_pic
{
    public partial class Form1 : Form
    {
        const int pick_pic_num = 4;
        private string pic_folder;
        private String[] FileCollection;
        int display_pic_num = 0;
        ArrayList myArray = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileInfo theFileInfo;
            int number;
            FolderBrowserDialog openpic = new FolderBrowserDialog();
            if(openpic.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            pic_folder = openpic.SelectedPath;
            FileCollection = Directory.GetFiles(pic_folder, "*.jpg");
            if (FileCollection.Length < pick_pic_num)
            {
                MessageBox.Show("圖片太少了!!");
                return;
            }
            System.Random num = new Random();
            for(int i = 0; i < pick_pic_num; i++)
            {
                do
                {
                    number = num.Next(0, FileCollection.Length);
                } while (myArray.IndexOf(FileCollection[number]) != -1);
                myArray.Add(FileCollection[number]);
            }
            Bitmap pic = new Bitmap(myArray[display_pic_num].ToString());
            pictureBox1.Image = pic;
            button2.Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (display_pic_num < pick_pic_num-1)
                display_pic_num++;
            else
                display_pic_num = 0;
            Bitmap pic = new Bitmap(myArray[display_pic_num].ToString());
            pictureBox1.Image = pic;
        }
    }
}
