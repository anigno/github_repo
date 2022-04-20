<%@ Page language="c#" Codebehind="userMessage.aspx.cs" AutoEventWireup="false" Inherits="pinukitafNet.userMessage.userMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML dir="rtl">
	<HEAD>
		<title>userMessage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="stylesheet" TYPE="text/css" HREF="../Styles.css">
	</HEAD>
	<body background="../pictures/bg/BD15131_.GIF">
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE align="center" id="Table1" cellSpacing="1" cellPadding="1" width="700" border="1">
					<TR>
						<TD align="center">
							<P align="center"><FONT size="5">יצירת קשר עם פינוקי טף</FONT></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P align="right">רשמו את הודעתכם ולחצו על - שליחת הודעה.&nbsp; (ההודעות חסויות!)
								<asp:TextBox id="txtMessage" runat="server" Width="687px" TextMode="MultiLine" Rows="5"></asp:TextBox>
								<asp:Button id="btnSend" runat="server" Text="שליחת הודעה"></asp:Button>&nbsp;&nbsp;
								<asp:Button id="btnCancel" runat="server" Text="ביטול"></asp:Button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P align="right">ניתן גם לפנות בדואר אלקטרוני: pinukitaf@gmail.com</P>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<P align="right">טלפון בגן: 04-8444992</P>
						</TD>
					</TR>
				</TABLE>
			</P>
			<asp:Repeater id="rptUserMessages" runat="server">
				<HeaderTemplate>
					<table border="1" width="700" align="center">
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<%if(Session["admin"]=="yes"){%>
						<td><%# DataBinder.Eval(Container.DataItem, "iDate") %></td>
						<td><%# DataBinder.Eval(Container.DataItem, "iMessage") %></td>
						<%}%>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
			<P></P>
		</form>
	</body>
</HTML>
