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
using System.Reflection;

namespace rand_pick_pic
{
    public partial class Form1 : Form
    {
        const int pick_pic_num = 4;
        int[] pick_pic_num_A = {11 ,6 ,19, 4 ,5 , 5};
        private string pic_folder;
        private String[] FileCollection;
        int display_pic_num = 0;
        string now_pic_path;
        bool check_ans = false;
        int correct_number = 0;
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
            FileCollection = Directory.GetFiles(pic_folder, "*.png");
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
            myArray[display_pic_num].ToString();
            pictureBox1.Image = pic;
            button2.Visible = true;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!check_ans)
            {
                MessageBox.Show("忘記填答案了");
                return;
            }
            label1.Text = "";
            next_pic_inarray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int number;
            FolderBrowserDialog openpic = new FolderBrowserDialog();
            if (openpic.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            panel1.Visible = true;
            pic_folder = openpic.SelectedPath;
            string[] dirs = Directory.GetDirectories(pic_folder);
            for(int i = 0; i < dirs.Length; i++)
            {
                FileCollection = Directory.GetFiles(dirs[i], "*.png");
                System.Random num = new Random();
                for (int k = 0; k < pick_pic_num_A[i]; k++)
                {
                    do
                    {
                        number = num.Next(0, FileCollection.Length);
                    } while (myArray.IndexOf(FileCollection[number]) != -1);
                    myArray.Add(FileCollection[number]);
                }
            }
            if (myArray.Count < 1)
                return;
            Bitmap pic = new Bitmap(myArray[display_pic_num].ToString());
            now_pic_path = myArray[display_pic_num].ToString();
            pictureBox1.Image = pic;
            button2.Visible = true;            
        }

        private int consider_answer(string ans , string trueans)
        {
            string a = ans.Substring(ans.Length - 5, 1);            
            if (a == trueans)
                return 1;
            else
                return 0;
        }

        private void btn_A_Click(object sender, EventArgs e)
        {
            btn_default_color();            
            if (consider_answer(now_pic_path, "A") == 1)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "正確";
                next_pic_inarray();
                if (!check_ans)
                    correct_number++;
            }
            else
            {
                record_wrong_ans(now_pic_path);
                label1.ForeColor = Color.Red;
                label1.Text = "答錯了,正確答案是";
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "A")
                {
                    btn_A.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "B")
                {
                    btn_B.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "C")
                {
                    btn_c.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "D")
                {
                    btn_D.BackColor = Color.Green;
                }
            }
            check_ans = true;
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            btn_default_color();
            if (consider_answer(now_pic_path, "B") == 1)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "正確";
                next_pic_inarray();
                if (!check_ans)
                    correct_number++;
            }
            else
            {
                record_wrong_ans(now_pic_path);
                label1.ForeColor = Color.Red;
                label1.Text = "答錯了,正確答案是";
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "A")
                {
                    btn_A.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "B")
                {
                    btn_B.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "C")
                {
                    btn_c.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "D")
                {
                    btn_D.BackColor = Color.Green;
                }
            }
            check_ans = true;
        }

        private void btn_c_Click(object sender, EventArgs e)
        {
            btn_default_color();
            if (consider_answer(now_pic_path, "C") == 1)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "正確";
                next_pic_inarray();
                if (!check_ans)
                    correct_number++;
            }
            else
            {
                record_wrong_ans(now_pic_path);
                label1.ForeColor = Color.Red;
                label1.Text = "答錯了,正確答案是";
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "A")
                {
                    btn_A.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "B")
                {
                    btn_B.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "C")
                {
                    btn_c.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "D")
                {
                    btn_D.BackColor = Color.Green;
                }
            }
            check_ans = true;
        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            btn_default_color();
            if (consider_answer(now_pic_path, "D") == 1)
            {
                label1.ForeColor = Color.Green;
                label1.Text = "正確";
                next_pic_inarray();
                if (!check_ans)
                    correct_number++;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "答錯了,正確答案是";
                record_wrong_ans(now_pic_path);
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "A")
                {
                    btn_A.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "B")
                {
                    btn_B.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "C")
                {
                    btn_c.BackColor = Color.Green;
                }
                if (now_pic_path.Substring(now_pic_path.Length - 5, 1) == "D")
                {
                    btn_D.BackColor = Color.Green;
                }
            }
            check_ans = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            record_wrong_ans("hahaha");
        }

        private void btn_default_color()
        {
            btn_A.BackColor = Color.FromKnownColor(KnownColor.Control);
            btn_B.BackColor = Color.FromKnownColor(KnownColor.Control);
            btn_c.BackColor = Color.FromKnownColor(KnownColor.Control);
            btn_D.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        private void record_wrong_ans(string wrong_path)
        {
            string str = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sw = File.AppendText(str + @"\wrong_ans\wrong_ans.txt");
            sw.WriteLine(wrong_path);
            sw.Flush();
            sw.Close();              
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button2.Visible = true;
            string wrong_path;
            string str = System.IO.Directory.GetCurrentDirectory();
            StreamReader sw = new StreamReader(str+@"\wrong_ans\wrong_ans.txt");
            myArray.Clear();
            while ((wrong_path = sw.ReadLine()) != null)
            {
                myArray.Add(wrong_path);

            }
            if (myArray.Count < 1)
                return;
            Bitmap pic = new Bitmap(myArray[0].ToString());
            now_pic_path = myArray[0].ToString();
            pictureBox1.Image = pic;
            sw.Close();
            
        }

        private void next_pic_inarray()
        {
            check_ans = false;
            btn_default_color();
            int total_pick_num = 0;
            for (int i = 0; i < pick_pic_num_A.Length; i++)
            {
                total_pick_num += pick_pic_num_A[i];
            }
            //if (display_pic_num < total_pick_num - 1)
            if (display_pic_num < myArray.Count - 1)
                display_pic_num++;
            else
            {
                display_pic_num = 0;
                label2.Text = "你得到了" + ((correct_number * 2).ToString()) + " 分 ";
                label2.Visible = true;
            }
                


            Bitmap pic = new Bitmap(myArray[display_pic_num].ToString());
            now_pic_path = myArray[display_pic_num].ToString();
            pictureBox1.Image = pic;
            GC.Collect();
            check_ans = false;
        }

        private void btn_simple_test_Click(object sender, EventArgs e)
        {
            string str = System.IO.Directory.GetCurrentDirectory();

            int number;
            panel1.Visible = true;
            pic_folder = str + @"\pic";
            string[] dirs = Directory.GetDirectories(pic_folder);
            for (int i = 0; i < dirs.Length; i++)
            {
                FileCollection = Directory.GetFiles(dirs[i], "*.png");
                System.Random num = new Random();
                for (int k = 0; k < pick_pic_num_A[i]; k++)
                {
                    do
                    {
                        number = num.Next(0, FileCollection.Length);
                    } while (myArray.IndexOf(FileCollection[number]) != -1);
                    myArray.Add(FileCollection[number]);
                }
            }
            if (myArray.Count < 1)
                return;
            Bitmap pic = new Bitmap(myArray[display_pic_num].ToString());
            now_pic_path = myArray[display_pic_num].ToString();
            pictureBox1.Image = pic;
            button2.Visible = true;
        }
    }
}
