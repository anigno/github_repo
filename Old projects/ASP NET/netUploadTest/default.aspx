<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="netUploadTest._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML dir="rtl">
	<HEAD>
		<title>default</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 488px; POSITION: absolute; TOP: 80px" runat="server"
				Text="שלח קובץ" Width="104px"></asp:Button><INPUT style="Z-INDEX: 102; LEFT: 16px; WIDTH: 576px; POSITION: absolute; TOP: 16px; HEIGHT: 25px"
				type="file" size="76" id="File1" name="File1" runat="server">
			<asp:TextBox id="TextBox1" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 48px" runat="server"
				Width="472px" Height="24px"></asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 496px; POSITION: absolute; TOP: 48px" runat="server"
				Width="88px" Height="16px">:שם לשמירה</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 128px" runat="server"
				Width="613px" Height="16px">Label</asp:Label>
		</form>
	</body>
</HTML>
