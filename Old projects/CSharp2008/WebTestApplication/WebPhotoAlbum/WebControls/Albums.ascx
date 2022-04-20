<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Albums.ascx.cs" Inherits="WebPhotoAlbum.WebControls.Albums" %>
<%@ Register assembly="WebPhotoAlbum" namespace="WebPhotoAlbum.WebControls" tagprefix="cc1" %>
<%@ Register assembly="WebLibrary" namespace="WebLibrary.UI.TableDynamicControl" tagprefix="cc2" %>
<style type="text/css">
    .style1
    {
        width: 100%;
        border: 1px solid #c0c0c0;
    }
    .style2
    {
    }
    .style3
    {
        width: 269px;
    }
    .style4
    {
        width: 552px;
    }
</style>

<cc1:TableAlbums ID="TableAlbums1" runat="server">
</cc1:TableAlbums>

<br />
<br />
<asp:ImageButton ID="ImageButtonAddAlbum" runat="server" BorderStyle="Solid" 
    BorderWidth="1px" Height="50px" 
    ImageUrl="~/ButtonsImages/edit_add.png" 
    onclick="ImageButtonAddAlbum_Click1"  />
&nbsp;<asp:ImageButton ID="ImageButtonRemoveAlbum" runat="server" 
    BorderStyle="Solid" BorderWidth="1px" Height="50px" 
    ImageUrl="~/ButtonsImages/edit_remove.png" />
<br />
<br />
<asp:Panel ID="PanelNewAlbum" runat="server" Visible="False" Width="330px" 
    BorderWidth="1px">
    <table class="style1">
        <tr>
            <td colspan="2">
                New album</td>
        </tr>
        <tr>
            <td class="style4">
                Name</td>
            <td class="style3">
                <asp:TextBox ID="TextBoxNewAlbumName" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" valign="top">
                Description</td>
            <td class="style3" valign="top">
                <asp:TextBox ID="TextBoxNewAlbumDescription" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" valign="top">
                Date</td>
            <td class="style3" valign="top">
                <asp:Calendar ID="CalendarNewAlbumDate" runat="server" DayNameFormat="Shortest" 
                    FirstDayOfWeek="Sunday" Width="222px"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="style2" colspan="2" valign="top">
                <asp:ImageButton ID="ImageButtonOkAddAlbum" runat="server" Height="50px" 
                    ImageUrl="~/ButtonsImages/button_ok.png" 
                    onclick="ImageButtonOkAddAlbum_Click" />
                <asp:ImageButton ID="ImageButtonCancelAddAlbum" runat="server" Height="50px" 
                    ImageUrl="~/ButtonsImages/button_cancel.png" 
                    onclick="ImageButtonCancelAddAlbum_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
