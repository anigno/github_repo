<%@ Page language="c#" Codebehind="pictureBrowser.aspx.cs" AutoEventWireup="false" Inherits="pinukitafNet.pictureBrowser.pictureBrowser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>pictureBrowser</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META HTTP-EQUIV="Content-Type" content="text/html; charset=windows-1255">
		<LINK REL="stylesheet" TYPE="text/css" HREF="../Styles.css">
	</HEAD>
	<body dir="rtl" background=../pictures/bg/BD15131_.GIF>
		<form id="Form1" method="post" runat="server">
			<table align="center" border="1" width="700">
				<%if(Session["admin"]=="yes"){%>
				<tr>
					<td>
						<asp:Button id="Button1" runat="server" Text="הוספת נושא חדש"></asp:Button>&nbsp;
						<asp:TextBox id="TextBox1" runat="server" Width="400px" Height="24px" TextMode="MultiLine" Rows="1"></asp:TextBox>
					</td>
				</tr>
				<%}%>
			</table>
			<table align="center" border="1" width="700">
				<asp:Repeater id="rptSubjects" runat="server">
					<HeaderTemplate>
					</HeaderTemplate>
					<ItemTemplate>
						<tr>
					<!-- subject ->
					<td><%# DataBinder.Eval(Container.DataItem, "iSubject") %></td>
					<td><a href=picturesView.aspx?key=<%# DataBinder.Eval(Container.DataItem, "iKey") %>>צפיה בתמונות</a></td>
				<%if(Session["admin"]=="yes"){%>
					<!-- del subject ->
					<td><a href=# onclick=subjectDel(<%# DataBinder.Eval(Container.DataItem, "iKey") %>)>מחק</a></td>
				<%}%>
						</tr>
					</ItemTemplate>
					<FooterTemplate>
					</FooterTemplate>
				</asp:Repeater>
			</table>
		</form>
		<script language="vbscript">
	sub subjectDel(k)
		ret=MsgBox("למחוק נושא?" ,vbOKCancel)
		if ret=vbOK then window.navigate "subjectDel.aspx?key=" & k
	end sub
		</script>
		</TBODY></TABLE>
	</body>
</HTML>
