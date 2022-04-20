<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebEncryptedXmlDataManager._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 800px;
            border-style: solid;
            border-width: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td valign="top">
                    Subject:<br />
                    <asp:ListBox ID="ListBoxSubjects" runat="server" AutoPostBack="True" 
                        Height="212px" onselectedindexchanged="ListBoxSubjects_SelectedIndexChanged" 
                        Width="223px"></asp:ListBox>
                    <br />
                    <br />
                    <asp:Button ID="ButtonAddSubject" runat="server" 
                        onclick="ButtonAddSubject_Click" Text="Add subject" />
&nbsp;<asp:TextBox ID="TextBoxSubject" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonSave" runat="server" Text="Save" />
                </td>
                <td valign="top">
                    Data:<br />
                    <asp:TextBox ID="TextBoxData" runat="server" Height="348px" 
                        ontextchanged="TextBoxData_TextChanged" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
