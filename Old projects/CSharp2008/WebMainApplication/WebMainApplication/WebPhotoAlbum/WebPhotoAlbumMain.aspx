<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebPhotoAlbumMain.aspx.cs" Inherits="WebMainApplication.WebPhotoAlbum.WebPhotoAlbumMain" %>

<%@ Register src="../Library/DatePicker.ascx" tagname="DatePicker" tagprefix="uc1" %>

<%@ Register assembly="WebMainApplication" namespace="WebMainApplication.WebPhotoAlbum" tagprefix="cc1" %>
<%@ Register assembly="WebLibrary" namespace="WebLibrary.UI.TableDynamicControl" tagprefix="cc2" %>

<%@ Register src="ControlPanel.ascx" tagname="ControlPanel" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            border: 1px solid #c0c0c0;
        }
        .style2
        {
            width: 436px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style2">
                    <uc2:ControlPanel ID="ControlPanel1" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
    
        <cc1:TableAlbums ID="TableAlbums1" runat="server">
        </cc1:TableAlbums>
    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
