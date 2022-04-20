<%@ Page language="c#" Codebehind="main.aspx.cs" AutoEventWireup="false" Inherits="business.visitors.main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML dir="rtl">
	<HEAD>
		<title>main</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE align=center width="486" height="385" background="../flashFiles/big01.jpg" id="Table2" cellSpacing="8"
				cellPadding="1" border="0">
				<TR height="30">
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colspan="2" vAlign="top"><%=textAbout%></TD>
					<TD></TD>
				</TR>
				<TR height="30">
					<TD></TD>
					<TD rowspan="2" align="center" valign="middle"><asp:Image id="Image1" runat="server" Width="180px" Height="140px"></asp:Image></TD>
				</TR>
				<TR height="150">
					<TD valign="top" width="200">
						<%=textAddress%>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
