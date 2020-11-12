using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Resources
{
    class data
    {
        static public string file_path { get; set; }//表格文件路径
        static public System.Windows.Forms.TextBox  Output{ get; set; }
        static public string web_path { get; set; }//登录网站
        static public string Drive_path { get; set; }//edge驱动地址
        static public string Login_password { get; set; }//登录密码




        static public string Flight_Number { get; set; }//航班编号
        static public string Total_Number { get; set; }//总单号
        static public List<string> Classify_Number { get; set; }//分单号

        static public string Identification_code { get; set; }//识别人代码
        static public List<string> number { get; set; }//件数
        static public string Transport_Time { get; set; }//航班时间
        static public string Transport_Means_Number { get; set; }//运输工具代码
        static public string Transport_Means_Name { get; set; }//运输工具名字

        static public string Unloading_address_code { get; set; }//卸货人地址代码
        static public List<string> weight{ get; set; }//货物重量 

    }
}
