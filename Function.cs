
using System;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Text;
using WindowsFormsApp1.Resources;
using System.Collections.Generic;
using NPOI.HSSF.Record.Chart;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.ObjectModel;
using System.Collections;

namespace WindowsFormsApp1
{

    static public class Function
    {
        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="isColumnName">第一行是否是列名</param>  
        /// <returns>返回datatable</returns>  
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)//把excel 文件转换成datatable格式的
        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;

            using (fs = File.OpenRead(filePath))
            {
                // 2007版本  
                if (filePath.IndexOf(".xlsx") > 0)
                    workbook = new XSSFWorkbook(fs);
                // 2003版本  
                else if (filePath.IndexOf(".xls") > 0)
                    workbook = new HSSFWorkbook(fs);

                if (workbook != null)
                {
                    sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet  
                    dataTable = new DataTable();
                    if (sheet != null)
                    {
                        int rowCount = sheet.LastRowNum;//总行数  
                        if (rowCount > 0)
                        {
                            IRow firstRow = sheet.GetRow(0);//第一行  
                            int cellCount = firstRow.LastCellNum;//列数  

                            //构建datatable的列  
                            if (isColumnName)
                            {
                                startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                {
                                    cell = firstRow.GetCell(i);
                                    if (cell != null)
                                    {
                                        if (cell.StringCellValue != null)
                                        {
                                            column = new DataColumn(cell.StringCellValue);
                                            dataTable.Columns.Add(column);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                {
                                    column = new DataColumn("column" + (i + 1));
                                    dataTable.Columns.Add(column);
                                }
                            }

                            //填充行  
                            for (int i = startRow; i <= rowCount; ++i)
                            {
                                row = sheet.GetRow(i);
                                if (row == null) continue;

                                dataRow = dataTable.NewRow();
                                for (int j = row.FirstCellNum; j < cellCount; ++j)
                                {
                                    cell = row.GetCell(j);
                                    if (cell == null)
                                    {
                                        dataRow[j] = "";
                                    }
                                    else
                                    {
                                        //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                        switch (cell.CellType)
                                        {
                                            case CellType.Blank:
                                                dataRow[j] = "";
                                                break;
                                            case CellType.Numeric:
                                                short format = cell.CellStyle.DataFormat;
                                                //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                if (format == 14 || format == 31 || format == 57 || format == 58)
                                                    dataRow[j] = cell.DateCellValue;
                                                else
                                                    dataRow[j] = cell.NumericCellValue;
                                                break;
                                            case CellType.String:
                                                dataRow[j] = cell.StringCellValue;
                                                break;
                                        }
                                    }
                                }
                                dataTable.Rows.Add(dataRow);
                            }
                        }
                    }

                }
                return dataTable;
            }
        }
        /// <summary>
        /// 把datatable格式进行每一列的读取 列名为字典的键,后面的行 为字典值（字典值为一个字符串列表）
        /// </summary>
        /// <param name="dt">从excel读取的datatable文件</param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> DataTableToString(DataTable dt)//，
        {
            Dictionary<string, List<string>> Read_File = new Dictionary<string, List<string>>();




            foreach (DataColumn column in dt.Columns)
            {
                List<string> ls = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    ls.Add(dr[column.ColumnName].ToString());
                }
                Read_File.Add(column.ColumnName, ls);

            }
            return Read_File;
        }
        /// <summary>
        /// 打印函数 ，把输入的字符串进行打印，并且进行换行操作。
        /// </summary>
        /// <param name="Soutput">输入的打印字符串</param>
        public static void output(string Soutput)
        {
            data.Output.AppendText(Soutput);
            data.Output.AppendText(Environment.NewLine);//换行
        }
        /// <summary>
        ///selenium 自动化程序 代码的唯一性特别强 网页进行改变就会导致代码错误的产生
        /// </summary>
        public static void Document_Selenium() 
        {

            data.web_path = @"https://www.singlewindow.cn/";//登录网站
            data.Drive_path = @"../../";//edge驱动的文件夹
            data.Login_password = "88888888";






            EdgeDriver driver = new EdgeDriver(data.Drive_path);
            driver.Manage().Window.Maximize();//浏览器最大化
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);
            driver.Navigate().GoToUrl(data.web_path);//跳转到指定网址
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(90);



            driver.FindElement(By.LinkText("好的，我知道了")).Click();//网站跳出来的提示，进行点击

            Xpath(driver, "//li[@data-name='fwzn']");//标准版应用
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//span[@title='舱单申报']")).Click();//主网页的舱单申报
            driver.FindElement(By.XPath("//ul[@id='pxdiv']/li[5]/div[1]/span[2]/a[1]")).Click();//点击空运，跳转到登陆页面。
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));
            driver.Close();//关闭主页面，减少句柄

            driver.SwitchTo().Window(driver.WindowHandles.Last());//跳转新开的页面（打开最后一个新建的网页）

            driver.FindElement(By.XPath("//div[@id='login']/div[1]/div[2]/a[1]")).Click();//点击卡介质
            //driver.findElement(By.name("password")).sendKeys("values to send");
            ID(driver, "password", false, data.Login_password);//登录密码8个八
            Xpath(driver, "//*[@id='loginbutton']");//卡介质 登录按钮


            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));//等待舱单页面加载成功
            Console.WriteLine(driver.Title);//显示的标题
            System.Threading.Thread.Sleep(3000);
            foreach (string winHandle in driver.WindowHandles)//循环个个页面的句柄

            {

                driver.SwitchTo().Window(winHandle);
                Console.WriteLine(driver.Title);
                if (driver.Title == "中国国际贸易单一窗口")//对比页面的标题 如果一致就进行跳转

                {
                    Console.WriteLine("跳转成功");
                    break;

                }
                else
                {
                    Console.WriteLine("跳转失败");
                }

            }
            Console.WriteLine(driver.Title);//打印新页面的标题

            System.Threading.Thread.Sleep(8000);
            try//进行错误判断 因为这个框有时会不进行弹窗
            {
                driver.FindElement(By.ClassName("layui-layer-btn0")).Click();//登录密码过低  提示框点击  
            }
            catch { }//没有找到就进行跳过 不进行点击
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));
            driver.FindElement(By.XPath("//a[@menuid='mft002th04']")).Click();//运抵报告            //driver.FindElement(By.XPath("(//li[@class='active']//a)[1]")).Click();
            driver.FindElement(By.XPath("//a[@data-href='https://swapp.singlewindow.cn:443/mftserver/sw/mft/water/arriveReport?msgType=MT3202&pageType=main&ngBasePath=https%3A%2F%2Fswapp.singlewindow.cn%3A443%2Fmftserver%2F']")).Click();
            //运抵报告下的，分流分拨运抵申报

            driver.SwitchTo().Frame("iframe13");//页面申报的页面装在一个frame   切换到 Frame

            ID(driver, "arriveReportArrRefreshBtn");//新增按钮
            ID(driver, "voyageNo", false, data.Flight_Number);//航次航班编号
            ID(driver, "shipId", false, data.Transport_Means_Number);//运输工具代码
            ID(driver, "shipName", false, data.Transport_Means_Name);//运输工具名称 
            ID(driver, "supervisionCode", false, data.Unloading_address_code);//卸货地址代码 

            IWebElement discharge_cargo = driver.FindElement(By.Id("cusCodeName"));//找到卸货地关区   下拉按钮
            try//尝试点击 选中3713代码
            {
                discharge_cargo.Click();
                System.Threading.Thread.Sleep(2000);
                Xpath(driver, "//*[@id='arrReportHeadForm']/div/table/tbody/tr[2]/td[4]/div/div/ul/table/tbody/tr[559]/td[2]");//3715机场海关
            }
            catch//不行进行输入3713  在进行尝试点击3713 不行选择第一个选择
            {
                ID(driver, "cusCodeName", false, "3");//一个一个输入才能选中正确的3713
                ID(driver, "cusCodeName", false, "7");
                ID(driver, "cusCodeName", false, "1");
                ID(driver, "cusCodeName", false, "3");

                System.Threading.Thread.Sleep(2000);
                try
                {
                    //3715机场海关
                    Xpath(driver, "//*[@id='arrReportHeadForm']/div/table/tbody/tr[2]/td[4]/div/div/ul/table/tbody/tr[559]/td[2]");

                }
                catch
                {
                    Xpath(driver, "/html/body/div[2]/div/form/div/table/tbody/tr[2]/td[4]/div/div/ul/table/tbody/tr/td[1]");
                }

            }


            ID(driver, "arrDischargePlaceDate");//时间
            ID(driver, "laydate_today");//今天按钮
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));

            IWebElement declare = driver.FindElement(By.Name("customsCodeText"));//申报地海关代码选择

            try
            {
                declare.Click();
                driver.FindElement(By.Name("customsCodeText")).Click();
                System.Threading.Thread.Sleep(2000);
                driver.FindElement(By.XPath("//td[text()='3724']/following-sibling::td")).Click();


            }
            catch
            {
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Name("customsCodeText")).SendKeys("3");
                driver.FindElement(By.Name("customsCodeText")).SendKeys("7");
                driver.FindElement(By.Name("customsCodeText")).SendKeys("1");
                driver.FindElement(By.Name("customsCodeText")).SendKeys("3");

                System.Threading.Thread.Sleep(1000);
                try
                {
                    Xpath(driver, "//*[@id='arrReportHeadForm']/div/table/tbody/tr[2]/td[8]/div/div/ul/table/tbody/tr[557]/td[1]");
                }
                catch
                {
                    driver.FindElement(By.XPath("//*[@id='arrReportHeadForm']/div/table/tbody/tr[2]/td[8]/div/div/ul/table/tbody/tr/td[2]")).Click();

                }
            }
            //driver.FindElement(By.XPath("")).SendKeys("3700303036799");
            Xpath(driver, "//input[@id='']", false, data.Identification_code);//识别人代码
            ID(driver, "arriveReportArrSaveBtn");//暂存按钮 
            ID(driver, "arriveReportLadingOpenBtn");//新建





            // 小页面
            for (int i= 0; i < (data.Classify_Number.Count-1) ; i++) {
                System.Threading.Thread.Sleep(2000);
                ID(driver, "billNo", false, data.Total_Number);//总单信息
                ID(driver, "assBillNo", false, data.Classify_Number[i]);//分单信息
                ID(driver, "totalPackNum", false, data.number[i]);//件数
                driver.FindElement(By.Name("totalGrossWt")).SendKeys(data.weight[i]);//重量


                ID(driver, "arriveReportLadingAddBtn");//保存


                System.Threading.Thread.Sleep(2000);
                ID(driver, "arriveReportLadingClearBtn");//新增
            }

        }
        /// <summary>
        /// 网站进行xpath 方式进行搜索网站元素
        /// </summary>
        /// <param name="driver">edge网站的主元素 </param> 
        /// <param name="SXpath">搜索的xpath语句</param>
        /// <param name="Input_Click">搜索的是点击还是输入框 默认为点击 false为输入框模式 </param>
        /// <param name="Inputstring">如果为输入框模式 输入框所输入的字符串是什么</param>
        static void Xpath(EdgeDriver driver, string SXpath, bool Input_Click = true, string Inputstring = "")
        {
            driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(90));
            IWebElement keyword = driver.FindElement(By.XPath(SXpath));

            if (Input_Click)//点击
            {
                keyword.Click();
            }
            else //输入
            {
                keyword.SendKeys(Inputstring);

            }
        }


        /// <summary>
        /// 应用id 进行搜索操作
        /// </summary>
        /// <param name="driver">输入的EdgeDriver</param>
        /// <param name="Sid">输入的id语句</param>
        /// <param name="Input_Click"> 是输入框还是点击  1是点击 0为输入 默认为点击</param>
        /// Inputstring 输入文本
        static void ID(EdgeDriver driver, string Sid, bool Input_Click = true, string Inputstring = "")
        {
            IWebElement keyword = driver.FindElement(By.Id(Sid));
            if (Input_Click)//点击
            {
                keyword.Click();
            }
            else //输入
            {
                keyword.SendKeys(Inputstring);

            }
        }
        /// <summary>
        /// 把字典转换成代码中的属性
        /// </summary>
        /// <param name="dict"></param>
        static public void dict_to_data(Dictionary<string, List<string>> dict) 
        {
            foreach (string Skey in dict.Keys) 
            {
                switch (Skey) 
                {
                    case "单号":
                        foreach (string value in dict[Skey])
                        {
                            if (value != "")
                            {
                                data.Total_Number = value;//这个单号是唯一的
                            }
                        }

                    break;

                    case "日期":
                        foreach (string value in dict[Skey])
                        {
                            if (value != "")
                            {
                                data.Transport_Time = value;//这个航班时间是唯一的
                            }
                        }

                        break;
                    case "航班号":
                        foreach (string value in dict[Skey])
                        {
                            if (value != "")
                            {
                                data.Flight_Number = value + ;//这个航班号是唯一的//加时间
                                data.Transport_Means_Name = value;
                                data.Transport_Means_Number = value;
                            }
                        }

                        break;
                        
                    case "分单号":
                        data.Classify_Number = dict[Skey];
                        break;

                    case "件数":
                        data.number = dict[Skey];
                        break;
                    case "毛重":
                        data.weight = dict[Skey];

                        break;
                }
            }
        }



    }
}

