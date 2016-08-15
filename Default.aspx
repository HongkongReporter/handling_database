<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
            <br />
            <br />
            <br />
            <br />
            <br />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 341px">
            <strong><span class="auto-style1">人员登记表单</span></strong><br />

            <br />

            <br />

            姓名：<asp:TextBox ID="TextBoxUserName" runat="server" Width="109px"></asp:TextBox>
            
            <br />
            
            <br />
            
            年龄：<asp:TextBox ID="TextBoxAge" runat="server" Width="26px"></asp:TextBox>
            <br />
            <br />
            性别<asp:RadioButton 
                ID="RadioButton1" runat="server" oncheckedchanged="RadioButton1_CheckedChanged" 
                Text="男" />
                <asp:RadioButton ID="RadioButton2" runat="server" 
                oncheckedchanged="RadioButton2_CheckedChanged" Text="女" />
             
             <br />
             
             <br />
             
             岗位：<asp:TextBox ID="TextBoxPosition" runat="server"></asp:TextBox> 
             
             <br />
             
             <br />
             
             邮箱：<asp:TextBox ID="TextBoxEmail" 
                runat="server" Width="215px"></asp:TextBox> 
             <br />
             <br />
             联系方式：<asp:TextBox ID="TextBoxPhoneCall" runat="server" 
                Height="23px" Width="210px" ontextchanged="TextBoxPhoneCall_TextChanged"></asp:TextBox>
   
            <br />
            <br />
            <br />
            上传你的照片<br /> 
            <asp:FileUpload ID="FileUpload1" runat="server" Width="220px" />
            <br />
            <br /> 
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="立刻上传！" />
            <br /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="ButtonReg" runat="server" Height="34px" Text="录入" 
                Width="53px" 
                style="font-weight: 700; color: #FFFFFF; background-color: #666666" 
                onclick="ButtonReg_Click1" />
              <br />  <br /><br />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <br /> <br /> <br /> <br /> <br /> </div> </form> </body> </html>
