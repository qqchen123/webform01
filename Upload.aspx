<%@ Page Title="Upload" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="WebApplication1.Upload" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>员工图片上传.</h3>
    <div class="form-group">
        <label for="firstname" class="col-sm-2 control-label">员工NT</label>
        <div class="col-sm-10">
            <%--<input type="text" name="username" class="form-control" id="firstname" placeholder="请输入名字" runat="server">--%>
            <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="请输入名字" ></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="lastname" class="col-sm-2 control-label">照片</label>
        <div class="col-sm-10">
            <asp:FileUpload ID="FileUpload1" runat="server"  />
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="btnUpload_Click" />
            <asp:Literal ID="upload_result" runat="server"></asp:Literal>
        </div>
    </div>

    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="提交" OnClick="upload_btn_Click" />
        </div>
    </div>



</asp:Content>

