<%@ Register src="../Library/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %>
<asp:Panel ID="Panel1" runat="server" Width="236px">
    <asp:Button ID="ButtonAddNewAlbum" runat="server" Text="Add new album" 
        Height="20px" Width="140px" />
    <br />
    <asp:Button ID="ButtonDeleteSelectedAlbum" runat="server" Height="20px" 
        Text="Delete current album" Width="140px" />
    <br />
    <asp:Button ID="ButtonUploadNewPicture" runat="server" Height="20px" 
        Text="Upload new picture" Width="140px" />
    <asp:Panel ID="PanelAddNewAlbum" runat="server" Visible="False" Width="270px">
        <asp:Label ID="Label1" runat="server" Text="Album name:" Width="132px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <uc1:DatePicker ID="DatePicker1" runat="server" />
    </asp:Panel>
</asp:Panel>
<br />
<br />
<br />
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlPanel.ascx.cs" Inherits="WebMainApplication.WebPhotoAlbum.ControlPanel" %>
