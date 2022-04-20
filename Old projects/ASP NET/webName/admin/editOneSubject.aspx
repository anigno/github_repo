<%@ Page language="c#" Codebehind="editOneSubject.aspx.cs" AutoEventWireup="false" Inherits="webName.admin.editOneSubject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>editOneSubject</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDummie" style="Z-INDEX: 112; LEFT: 384px; POSITION: absolute; TOP: 432px"
				runat="server" Width="6px" Height="8px" Text="_"></asp:Button>
			<asp:Label id="lblMessage" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="448px"></asp:Label>
			<asp:Panel id="panelAddNew" style="Z-INDEX: 110; LEFT: 264px; POSITION: absolute; TOP: 96px"
				runat="server" Width="192px" Height="80px" Visible="False">
				<P>Add new product:</P>
				<P>
					<asp:TextBox id="txtAddNew" tabIndex="5" runat="server"></asp:TextBox>
					<asp:Button id="btnAddNewProduct" tabIndex="6" runat="server" Text="Add" Width="72px"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnCancelAddNew" tabIndex="7" runat="server" Text="Cancel" Width="72px"></asp:Button></P>
			</asp:Panel>
			<asp:Button id="btnReturn" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 416px" runat="server"
				Width="80px" Text="< Return" tabIndex="2"></asp:Button>
			<asp:Button id="btnRemove" style="Z-INDEX: 108; LEFT: 184px; POSITION: absolute; TOP: 416px"
				runat="server" Width="80px" Text="Remove" tabIndex="4"></asp:Button>
			<asp:Button id="btnAdd" style="Z-INDEX: 107; LEFT: 96px; POSITION: absolute; TOP: 416px" runat="server"
				Width="80px" Text="Add new" tabIndex="3"></asp:Button>
			<asp:Label id="Label2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server">webName:</asp:Label>
			<asp:Label id="lblWebName" style="Z-INDEX: 105; LEFT: 112px; POSITION: absolute; TOP: 40px"
				runat="server" Width="200px"></asp:Label>
			<asp:Label id="lblSubject" style="Z-INDEX: 104; LEFT: 328px; POSITION: absolute; TOP: 40px"
				runat="server" Width="216px"></asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 72px" runat="server">Products:</asp:Label>
			<asp:ListBox id="lstProducts" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 96px"
				runat="server" Width="248px" Height="312px" AutoPostBack="True" tabIndex="1"></asp:ListBox>
			<asp:Panel id="panelRemove" style="Z-INDEX: 111; LEFT: 264px; POSITION: absolute; TOP: 200px"
				runat="server" Width="208px" Height="56px" Visible="False">
<P>Remove selected product?</P>
<asp:Button id="btnRemoveYes" tabIndex="8" runat="server" Text="Yes" Width="40px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnRemoveNo" tabIndex="9" runat="server" Text="No" Width="40px"></asp:Button></asp:Panel>
			<P>
			</P>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
			<asp:Panel id="panelEdit" style="Z-INDEX: 113; LEFT: 480px; POSITION: absolute; TOP: 96px"
				runat="server" Width="272px" Height="320px">&nbsp; 
<asp:TextBox id="txtText" tabIndex="10" runat="server" Height="136px" Width="240px" TextMode="MultiLine"></asp:TextBox>
<asp:Button id="btnUpdate" tabIndex="11" runat="server" Text="Update"></asp:Button>
<P></P><INPUT id="File1" style="WIDTH: 264px; HEIGHT: 25px" tabIndex="15" type="file" size="24"
					name="File1" runat="server"> 
<P>
					<asp:Image id="imgProduct" runat="server" Height="100px" Width="100px"></asp:Image>
					<asp:Button id="btnUpload" tabIndex="18" runat="server" Text="Upload"></asp:Button></asp:Panel></P>
		</form>
		<P></P>
	</body>
</HTML>
