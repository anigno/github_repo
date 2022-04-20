<%@ Page language="c#" Codebehind="picturesView.aspx.cs" AutoEventWireup="false" Inherits="pinukitafNet.pictureBrowser.picturesView" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>picturesView</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body dir="rtl" background=../pictures/bg/BD15131_.GIF>
		<form id="Form1" method="post" runat="server">
<%if(Session["admin"]=="yes"){%>
			<table width="700" align="center">
				<tr>
					<td align="center"><INPUT id="File1" style="WIDTH: 663px; HEIGHT: 25px" type="file" size="91" name="File1"
							runat="server">&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center">
					<asp:label id="Label1" runat="server" Font-Size="Small">תאור התמונה:</asp:label>
					<asp:textbox id="TextBox1" runat="server" Width="447px" TextMode=MultiLine Rows=1></asp:textbox>&nbsp;
					<asp:button id="Button1" runat="server" Text="הוספת קובץ"></asp:button></td>
				</tr>
			</table>
<%}%>
			<table width="700" align="center" border="1">
				<asp:Repeater id="rptPictures" runat="server">
					<HeaderTemplate></HeaderTemplate>
					<ItemTemplate>
						<tr>
							<td>
								<p align=center>
									<!--picture name ->
									<%# DataBinder.Eval(Container.DataItem, "iPictureName")%>
									<br>
									<!--picture with full size link ->
									<a href=# onclick=vbscript:window.open("<%# DataBinder.Eval(Container.DataItem, "iFileName")%>")>
										<img width=500 src="<%# DataBinder.Eval(Container.DataItem, "iFileName")%>">
									</a>
								</p>
							<%if(Session["admin"]=="yes"){%>
								<!-- מחיקת התמונה ->
								<p align=left>
								<a href=pictureDel.aspx?subject=<%=subjectKey%>&key=<%# DataBinder.Eval(Container.DataItem, "iKey")%>>מחיקת התמונה</a>
								</p>
							</td>
							<%}%>
						</tr>
					</ItemTemplate>
					<FooterTemplate></FooterTemplate>
				</asp:Repeater>
			</table>
		</form>
	</body>
</HTML>
