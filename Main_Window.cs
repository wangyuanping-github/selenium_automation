using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Resources;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class automation : Form
    {
        public automation()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data.Output = OutputBox;
        }

        private void automation_DragDrop(object sender, DragEventArgs e)//拖拽文件到窗口 得到文件路径
        {
            data.file_path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString(); //获得路径

            Function.output(data.file_path);
            DataTable i = Function.ExcelToDataTable(data.file_path,true);
            Dictionary<string, List<string>> my_dist = Function.DataTableToString(i);
            Function.dict_to_data(my_dist);//存入data 属性 


            foreach (string key in my_dist.Keys)
            {
                data.Output.AppendText(key);
                foreach (string zz in my_dist[key])
                {
                    data.Output.AppendText(zz);
                }
                data.Output.AppendText(Environment.NewLine);//换行
            }

            foreach (string key in my_dist.Keys)
            {            
                TreeNode tn = new TreeNode();
                tn.Text = key;
                data.Output.AppendText(key);
                foreach (string zz in my_dist[key])//字典值还是一个字符串列表  进行一个迭代取出里面的值
                {            
                   TreeNode tn2 = new TreeNode();
                    if (zz != "")
                    {
                        tn2.Text = zz;
                        tn.Nodes.Add(tn2);
                    }

                }

                File_treeView.Nodes.Add(tn);

            }
        }

        private void automation_DragEnter(object sender, DragEventArgs e)//和automation_DragDrop进行搭配，实现搭配拖拽活动
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;  //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_Click(object sender, EventArgs e)//确定按键
        {
            data.Identification_code = Identification_code.Text; //识别人代码
            data.Unloading_address_code = Unloading_address_code.Text;//卸货地代码
            Identification_code.Enabled = false;
            Unloading_address_code.Enabled = false;
            Function.Document_Selenium();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//退出按钮
        {
           
        }
    }
}
