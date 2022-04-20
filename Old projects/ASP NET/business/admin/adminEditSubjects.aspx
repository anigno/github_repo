<%@ Page language="c#" Codebehind="adminEditSubjects.aspx.cs" AutoEventWireup="false" Inherits="business.admin.adminEditSubjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>adminEditSubjects</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="btnUpdate" style="Z-INDEX: 108; LEFT: 16px; POSITION: absolute; TOP: 264px"
				runat="server" Width="136px" Text="Update subject" Font-Bold="True"></asp:button><asp:button id="btnUploadPicture" style="Z-INDEX: 114; LEFT: 600px; POSITION: absolute; TOP: 296px"
				runat="server" Width="120px" Text="Upload picture"></asp:button><INPUT id="File1" style="Z-INDEX: 113; LEFT: 376px; WIDTH: 344px; POSITION: absolute; TOP: 264px; HEIGHT: 25px"
				type="file" size="38" name="File1" runat="server">
			<asp:image id="Image1" style="Z-INDEX: 112; LEFT: 376px; POSITION: absolute; TOP: 296px" runat="server"
				Width="100px" Height="100px"></asp:image><asp:label id="lblMessage" style="Z-INDEX: 101; LEFT: 264px; POSITION: absolute; TOP: 8px"
				runat="server" Width="472px"></asp:label><asp:panel id="pnlAddNew" style="Z-INDEX: 110; LEFT: 160px; POSITION: absolute; TOP: 264px"
				runat="server" Width="136px" Height="88px" Visible="False">
				<P>New Subject:l</P>
				<P>
					<asp:TextBox id="txtAddNewSubject" runat="server" TextMode="MultiLine" Rows="1"></asp:TextBox>
					<asp:Button id="btnAddNewSubject" runat="server" Text="Add"></asp:Button>&nbsp;
					<asp:Button id="btnCancelAddNew" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:panel><asp:button id="btnReturn" style="Z-INDEX: 109; LEFT: 16px; POSITION: absolute; TOP: 360px"
				runat="server" Width="128px" Text="Return"></asp:button><asp:button id="btnRemove" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 328px"
				runat="server" Width="128px" Text="Remove subject"></asp:button><asp:button id="btnNew" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 296px" runat="server"
				Width="128px" Text="New subject"></asp:button><asp:textbox id="txtText" style="Z-INDEX: 105; LEFT: 280px; POSITION: absolute; TOP: 40px" runat="server"
				Width="432px" Height="208px" TextMode="MultiLine"></asp:textbox><asp:listbox id="lstSubjects" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 40px"
				runat="server" Width="256px" Height="216px" AutoPostBack="True"></asp:listbox>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">webName:</asp:Label>
			<asp:Label id="lblWebName" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 8px" runat="server"
				Width="152px"></asp:Label>
			<asp:Panel id="pnlRemove" style="Z-INDEX: 111; LEFT: 160px; POSITION: absolute; TOP: 360px"
				runat="server" Width="176px" Height="64px" Visible="False">
				<P>Remove selected subject?</P>
				<P>
					<asp:Button id="btnRemoveSelected" runat="server" Text="Yes"></asp:Button>&nbsp;
					<asp:Button id="btnRemoveCancel" runat="server" Text="No" Width="48px"></asp:Button></P>
			</asp:Panel></form>
	</body>
</HTML>
