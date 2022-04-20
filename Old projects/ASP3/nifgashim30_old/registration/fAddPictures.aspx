<%@ Page language="c#" Codebehind="fAddPictures.aspx.cs" AutoEventWireup="false" Inherits="nifgashim30.registration.fAddPictures" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fAddPictures</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="filePicture1" style="Z-INDEX: 100; LEFT: 264px; WIDTH: 464px; POSITION: absolute; TOP: 72px; HEIGHT: 25px"
				type="file" size="58" runat="server">
			<asp:Button id="btnRemove2" style="Z-INDEX: 114; LEFT: 288px; POSITION: absolute; TOP: 240px"
				runat="server" Text="מחק תמונה" Width="65px" Font-Size="XX-Small"></asp:Button>
			<asp:Button id="btnRemove3" style="Z-INDEX: 113; LEFT: 288px; POSITION: absolute; TOP: 376px"
				runat="server" Text="מחק תמונה" Width="65px" Font-Size="XX-Small"></asp:Button>
			<asp:Button id="btnRemove1" style="Z-INDEX: 112; LEFT: 288px; POSITION: absolute; TOP: 104px"
				runat="server" Text="מחק תמונה" Width="65px" Font-Size="XX-Small"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 110; LEFT: 456px; POSITION: absolute; TOP: 8px" runat="server">תמונות של</asp:Label>
			<asp:Label id="lblHeader" style="Z-INDEX: 109; LEFT: 264px; POSITION: absolute; TOP: 8px" runat="server"
				Width="184px"></asp:Label>
			<asp:Button id="btnCancel" style="Z-INDEX: 108; LEFT: 384px; POSITION: absolute; TOP: 504px"
				runat="server" Width="104px" Text="חזרה"></asp:Button>
			<asp:Label id="lblMessage" style="Z-INDEX: 107; LEFT: 336px; POSITION: absolute; TOP: 40px"
				runat="server" Width="384px" ForeColor="Red" Visible="False">80k אחת או יותר מהתמונות גדולה מדי -גודל מירבי</asp:Label><INPUT id="filePicture3" style="Z-INDEX: 106; LEFT: 264px; WIDTH: 464px; POSITION: absolute; TOP: 344px; HEIGHT: 25px"
				type="file" size="58" runat="server"><INPUT id="filePicture2" style="Z-INDEX: 105; LEFT: 264px; WIDTH: 464px; POSITION: absolute; TOP: 208px; HEIGHT: 25px"
				type="file" size="58" runat="server">&nbsp;&nbsp;
			<asp:Image id="Image3" style="Z-INDEX: 104; LEFT: 360px; POSITION: absolute; TOP: 376px" runat="server"
				Width="104px" Height="96px"></asp:Image>
			<asp:Image id="Image2" style="Z-INDEX: 103; LEFT: 360px; POSITION: absolute; TOP: 240px" runat="server"
				Width="104px" Height="96px"></asp:Image>
			<asp:Image id="Image1" style="Z-INDEX: 102; LEFT: 360px; POSITION: absolute; TOP: 104px" runat="server"
				Width="104px" Height="96px"></asp:Image>
			<asp:Button id="btnUpload" style="Z-INDEX: 101; LEFT: 496px; POSITION: absolute; TOP: 504px"
				runat="server" Text="טען תמונות"></asp:Button>
		</form>
	</body>
</HTML>
