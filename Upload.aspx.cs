using System;
using System.IO;
using System.Web;

namespace WebApplication1
{
    public partial class Upload : System.Web.UI.Page
    {
        public static string zplj = @"/tsmc/1/";
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine(222);
            Console.WriteLine(333);
            Console.WriteLine(4444);
        }

        private string randomFileName(string fileExtension)
        {
            //
            //根据日期和随机数生成随机的文件名
            //
            string saveName, fileName;
            Random objRand = new Random();
            System.DateTime date = DateTime.Now;
            //生成随机文件名
            saveName = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString()

                + date.Second.ToString() + Convert.ToString(objRand.Next(99) * 97 + 100);
            fileName = saveName + fileExtension;
            return fileName;
        }

        public void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.PostedFile.FileName == "")
                {
                    upload_result.Text = "要上传的文件不能为空！";
                    return;
                }
                else
                {
                    string ext = FileUpload1.PostedFile.FileName.Substring(FileUpload1.PostedFile.FileName.LastIndexOf("."));//初始值为.JPG格式
                    string filepath = FileUpload1.PostedFile.FileName;//全路径
                    string update_path = Server.MapPath("/Pic/" + zplj);//上传服务器路径
                    string sql_dt_path = @"/Pic" + zplj;//sqlserver 数据库中要写的路径

                    string AfileName = randomFileName(ext);
                    string filename = AfileName;//保存文件名以备其他页面调用
                    Session["wdtpzb_ScanRandomFileName"] = AfileName;//文件名
                    Session["wdtpzb_ScanRandomFileName_wjlj"] = sql_dt_path;//路径
                    Session["wdtpzb_ScanRandomFileName_ext"] = ext;//扩展名

                    //判断路径是否存在,若不存在则创建路径
                    DirectoryInfo upDir = new DirectoryInfo(update_path);
                    if (!upDir.Exists)
                    {
                        upDir.Create();
                    }
                    FileUpload1.PostedFile.SaveAs(update_path + filename);
                    upload_result.Text = "上传成功！";
                }
            }
            catch (Exception ex)
            {
                upload_result.Text = "处理发生错误！原因：" + ex.ToString();
            }
        }
        public void upload_btn_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string filename = Session["wdtpzb_ScanRandomFileName_wjlj"].ToString() + Session["wdtpzb_ScanRandomFileName"].ToString() + Session["wdtpzb_ScanRandomFileName_ext"].ToString();
            Console.WriteLine(username);
            Console.WriteLine(filename);

        }

      
    }
}