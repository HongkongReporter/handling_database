using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using Insus.NET;

public partial class _Default : System.Web.UI.Page
{
    Member objMember = new Member();
    InsusJsUtility objJs = new InsusJsUtility();
    bool isClicked = false;
    bool isMale = false;
    bool
        /*检测有没有完成照片采集*/
        upldpic = false;
    int ftrVtr;
    int picIndex;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonReg_Click1(object sender, EventArgs e)
    {
        try
        {
            /*
             * send msgs to SQL
             */
            objMember.UserName = this.TextBoxUserName.Text.Trim();
            objMember.Email = this.TextBoxEmail.Text.Trim();
            objMember.Age = this.TextBoxAge.Text.Trim();
            objMember.PhoneN = this.TextBoxPhoneCall.Text.Trim();
            objMember.Position = this.TextBoxPosition.Text.Trim();
            objMember.picIndex = picIndex;
            objMember.Face = ftrVtr;
            if (isMale)
                objMember.Sex = "Male";
            else
                objMember.Sex = "Female";

            if (upldpic||isClicked)
            {
                objMember.Insert();
                objJs.JsAlert("已经完成数据采集.");
            }
            else
                objJs.JsAlert("请完成表格填写！");
        }
        catch (Exception ex)
        {
            objJs.JsAlert(ex.Message);
        }
    }
    /*
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

        }
    }
*/


    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        isClicked = true;
        isMale = true;
    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        isClicked = true;
    }
    protected void TextBoxPhoneCall_TextChanged(object sender, EventArgs e)
    {

    }

    
    /*
     * Implementation of uploading files.
     */
    protected void Button1_Click1(object sender, EventArgs e)
    {
        
        #region 测试写入

        if (!FileUpload1.HasFile)
        {
            Response.Write("请选择图片");
        }

        string fileEx = System.IO.Path.GetExtension(this.FileUpload1.FileName);  //获取图片扩展名

        if (fileEx != ".jpg")
        {
            Response.Write("只能上传.jpg文件！");
        }

        else
        {
            /*fetch pic's  content, size, name, path and type*/
            int imgSize = this.FileUpload1.PostedFile.ContentLength;  
            string imgType =/* as much as we accept .jpg only at this point, 
                    leave imgType for future possible modifications*/ this.FileUpload1.PostedFile.ContentType;   
            string imgPath = this.FileUpload1.PostedFile.FileName;
            string imgName = this.FileUpload1.FileName; 
            int imgLength = this.FileUpload1.FileName.Length;
            if  /*if there is not image we will
                 * return and give warnings
                    */(imgLength <= 0)
            {
                Response.Write("没有上传照片！请重试");
                return;
            }
            /*use size to initialize an array*/
            Byte[] imgByte = new Byte[imgSize]; 
            /*establish stream; send them to the server;
             get the feature vector
             */
            Stream stream = this.FileUpload1.PostedFile.InputStream; 
            
            /*create index for the picture to be refered to
             * we send strings to bytes and send bytes to int
             * Compile at the same machine, same index would appeal
             */
            string name = this.TextBoxUserName.Text.Trim();
            if (string.IsNullOrEmpty(name)){
                Response.Write("请先输入姓名再进行之后的操作!");
                return;
            }
            Byte[] nameByte = System.Text.Encoding.Default.GetBytes(name);
            picIndex = BitConverter.ToInt32(nameByte, 0);




            /* The identification function will
             give feature vector after 
             feeding in .jpg stream
            */



            stream.Read(imgByte, 0, imgSize);/* 读取图片数据到临时存储体
            imgByte,0为数据指针位置,fileLength为
            数据长度*/
            //this.FileUpload1.FileBytes
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(connection);
                sqlconn.Open();
                string sqlcmd = "insert into Image values (@ImageType,@ImageData,@ImageTitle)";
                SqlCommand sqc = new SqlCommand(sqlcmd, sqlconn);
                sqc.Parameters.Add("@ImageType", SqlDbType.VarChar, 50).Value = imgType;
                sqc.Parameters.Add("@ImageData", SqlDbType.Image, imgSize).Value = this.FileUpload1.FileBytes;
                /*imgByte-将二进制的图片赋值给@ImageData */
                sqc.Parameters.Add("@ImageTitle", SqlDbType.VarChar, 50).Value = picIndex;
                int result = sqc.ExecuteNonQuery();
                sqlconn.Close();
                if (result != 0){
                    Response.Write("OK");
                    upldpic = true;
                }
                else{
                    Response.Write("NO");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.StackTrace);
            }
            finally{
            }
        }
        #endregion
    }
}
