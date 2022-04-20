<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebTestApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="ButtonGetDate" runat="server" onclick="ButtonGetDate_Click" 
            Text="Click to get date" Width="118px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Clicked dates:"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxDates" runat="server" AutoPostBack="True" 
            Height="266px" onselectedindexchanged="ListBoxDates_SelectedIndexChanged" 
            Width="283px"></asp:ListBox>
        <asp:Label ID="LabelSelectedDate" runat="server" Text="----------"></asp:Label>
        <br />
        <br />
        <asp:ListBox ID="ListBoxFiles" runat="server" AutoPostBack="True" 
            Height="167px" onselectedindexchanged="ListBoxFiles_SelectedIndexChanged" 
            Width="758px"></asp:ListBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Image ID="ImagePreview" runat="server" BorderStyle="Solid" 
            BorderWidth="1px" Height="137px" ImageUrl="~/Images/__9_0440.jpg" 
            Width="159px" />
        <br />
        <br />
        <asp:FileUpload ID="FileUploadImages" runat="server" />
        <br />
        <asp:Button ID="ButtonUpload" runat="server" onclick="ButtonUpload_Click" 
            Text="Upload" />
    
    </div>
    </form>
</body>
</html>
