<%@ Page language="c#" Codebehind="fMain.aspx.cs" AutoEventWireup="false" Inherits="nifgashim30.main.fMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fMain</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="btnEdit" style="Z-INDEX: 103; LEFT: 272px; POSITION: absolute; TOP: 72px" runat="server"
				Text="עדכון פרטים" Width="112px"></asp:button>
			<asp:Button id="btnEditPictures" style="Z-INDEX: 106; LEFT: 272px; POSITION: absolute; TOP: 104px"
				runat="server" Text="עדכון תמונות" Width="112px"></asp:Button><asp:button id="btnNewUser" style="Z-INDEX: 105; LEFT: 272px; POSITION: absolute; TOP: 40px"
				runat="server" Text="רישום" Width="112px"></asp:button><asp:panel id="pnlLogin" style="Z-INDEX: 101; LEFT: 480px; POSITION: absolute; TOP: 80px" runat="server"
				Width="224px" Height="128px">
				<P>
					<asp:Label id="Label3" runat="server">כניסת משתמשים רשומים</asp:Label></P>
				<P>
					<asp:TextBox id="txtUserName" runat="server" Width="168px"></asp:TextBox>
					<asp:Label id="Label1" runat="server">כינוי</asp:Label>
					<asp:TextBox id="txtPassword" runat="server" Width="168px" TextMode="Password"></asp:TextBox>
					<asp:Label id="Label2" runat="server">סיסמה</asp:Label>
					<asp:Button id="btnLogin" runat="server" Text="כניסה"></asp:Button></P>
			</asp:panel><asp:button id="btnExit" style="Z-INDEX: 100; LEFT: 272px; POSITION: absolute; TOP: 136px" runat="server"
				Text="יציאה" Width="112px"></asp:button>&nbsp;
			<asp:label id="lblMessage" style="Z-INDEX: 102; LEFT: 216px; POSITION: absolute; TOP: 8px"
				runat="server" Width="393px" ForeColor="Red"></asp:label></form>
	</body>
</HTML>
