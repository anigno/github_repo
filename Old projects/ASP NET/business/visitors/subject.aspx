<%@ Page language="c#" Codebehind="subject.aspx.cs" AutoEventWireup="false" Inherits="business.visitors.subject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML dir="rtl">
	<HEAD>
		<title>subject</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="485" align="center" background="../flashFiles/subject01.jpg"
				border="0">
				<TR>
					<TD width="10" height="5"></TD>
					<TD width="465"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD vAlign="top" align="right" height="370"><%=val%></TD>
					<TD><asp:image id="Image1" runat="server" Width="240px" Height="253px"></asp:image></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD height="5"></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 472px" runat="server">
				<a href="mailto:anigno@hotmail.com">anigno</a></asp:Label></form>
	</body>
</HTML>
