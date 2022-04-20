<%@ Page language="c#" Codebehind="fSubjects.aspx.cs" AutoEventWireup="false" Inherits="marko.fSubjects" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fSubjects</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="stylesheet" TYPE="text/css" HREF="style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnDummie" style="Z-INDEX: 113; LEFT: 16px; POSITION: absolute; TOP: 536px"
				runat="server" Height="16px" Width="16px" Text="Button"></asp:Button>
			<asp:Label id="lblProductPrise" style="Z-INDEX: 121; LEFT: 312px; POSITION: absolute; TOP: 408px"
				runat="server" Width="88px">0</asp:Label>
			<asp:ListBox id="lstSubjects" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 80px"
				runat="server" Width="192px" Height="120px" AutoPostBack="True"></asp:ListBox>
			<asp:Button id="btnProductAdd" style="Z-INDEX: 111; LEFT: 224px; POSITION: absolute; TOP: 304px"
				runat="server" Width="80px" Text="Add"></asp:Button>
			<asp:Button id="btnProductRemove" style="Z-INDEX: 110; LEFT: 224px; POSITION: absolute; TOP: 368px"
				runat="server" Width="80px" Text="Remove"></asp:Button>
			<asp:Button id="btnProductEdit" style="Z-INDEX: 109; LEFT: 224px; POSITION: absolute; TOP: 336px"
				runat="server" Width="80px" Text="Edit"></asp:Button>
			<asp:Button id="btnSubjectEdit" style="Z-INDEX: 108; LEFT: 16px; POSITION: absolute; TOP: 240px"
				runat="server" Width="80px" Text="Edit"></asp:Button>
			<asp:Button id="btnSubjectRemove" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 272px"
				runat="server" Width="80px" Text="Remove"></asp:Button>
			<asp:Button id="btnSubjectAdd" style="Z-INDEX: 106; LEFT: 16px; POSITION: absolute; TOP: 208px"
				runat="server" Width="80px" Text="Add"></asp:Button>
			<asp:Label id="Label3" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server"
				Font-Underline="True">Subjects and products edit</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 56px" runat="server">Products:</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 56px" runat="server">Subjects:</asp:Label>
			<asp:ListBox id="lstProducts" style="Z-INDEX: 102; LEFT: 224px; POSITION: absolute; TOP: 80px"
				runat="server" Width="192px" Height="216px" AutoPostBack="True"></asp:ListBox>
			<asp:Panel id="pnlAddNewSubject" style="Z-INDEX: 112; LEFT: 432px; POSITION: absolute; TOP: 80px"
				runat="server" Height="112px" Width="200px" Visible="False" BorderStyle="Solid">
				<P>Add new subject:</P>
				<P>
					<asp:TextBox id="txtAddNewSubjectName" runat="server"></asp:TextBox>
					<asp:Button id="btnAddNewSubjectOK" runat="server" Text="OK" Width="64px"></asp:Button>
					<asp:Button id="btnAddNewSubjectCancel" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="pnlEditSubject" style="Z-INDEX: 114; LEFT: 432px; POSITION: absolute; TOP: 192px"
				runat="server" Width="200px" Height="176px" BorderStyle="Solid" Visible="False">
				<P>Edit Subject:</P>
				<P>
					<asp:TextBox id="txtEditSubject" runat="server"></asp:TextBox>
					<asp:Button id="btnEditSubjectOk" runat="server" Text="OK" Width="64px"></asp:Button>&nbsp;
					<asp:Button id="pnlEditSubjectCancel" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
				<P><INPUT id="fileEditSubject" style="WIDTH: 200px; HEIGHT: 25px" type="file" size="14" name="File1"
						runat="server">
					<asp:Button id="btnEditSubjectUpload" runat="server" Text="Upload" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Image id="imageSubject" style="Z-INDEX: 115; LEFT: 104px; POSITION: absolute; TOP: 208px"
				runat="server" Width="96px" Height="96px"></asp:Image>
			<asp:Panel id="pnlRemoveSubject" style="Z-INDEX: 116; LEFT: 432px; POSITION: absolute; TOP: 376px"
				runat="server" Width="216px" Height="103px" BorderStyle="Solid" Visible="False">
				<P>Remove subject ?</P>
				<P>
					<asp:Button id="btnRemoveSubjectOK" runat="server" Text="OK" Width="64px"></asp:Button>
					<asp:Button id="btnRemoveSubjectCancel" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="pnlAddNewProduct" style="Z-INDEX: 117; LEFT: 496px; POSITION: absolute; TOP: 88px"
				runat="server" Width="213px" Height="40px" BorderStyle="Solid" Visible="False">
				<P>Add new product:</P>
				<P>
					<asp:TextBox id="txtAddNewProduct" runat="server"></asp:TextBox>
					<asp:Button id="btnAddNewProductOK" runat="server" Text="OK" Width="64px"></asp:Button>
					<asp:Button id="btnAddNewProductCancel" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:Panel>
			<asp:Image id="imageProduct" style="Z-INDEX: 118; LEFT: 312px; POSITION: absolute; TOP: 304px"
				runat="server" Width="96px" Height="96px"></asp:Image>
			<asp:Panel id="pnlEditProduct" style="Z-INDEX: 119; LEFT: 496px; POSITION: absolute; TOP: 192px"
				runat="server" Width="280px" Height="234px" BorderStyle="Solid" Visible="False">
				<P>Edit product:</P>
				<P>
					<asp:Label id="Label4" runat="server" Width="56px">Name:</asp:Label>
					<asp:TextBox id="txtEditProductName" runat="server" Width="192px"></asp:TextBox>
					<asp:Label id="Label5" runat="server" Width="56px">Prise:</asp:Label>
					<asp:TextBox id="txtEditProductPrise" runat="server" Width="192px"></asp:TextBox>
					<asp:Button id="btnEditProductOK" runat="server" Text="OK" Width="66px"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnEditProductCancel" runat="server" Text="Cancel" Width="66px"></asp:Button></P>
				<P><INPUT id="fileEditProduct" style="WIDTH: 248px; HEIGHT: 25px" type="file" size="22" name="File1"
						runat="server">
					<asp:Button id="btnEditProductUpload" runat="server" Text="Upload"></asp:Button></P>
			</asp:Panel>
			<asp:Panel id="pnlRemoveProduct" style="Z-INDEX: 120; LEFT: 496px; POSITION: absolute; TOP: 424px"
				runat="server" Width="216px" Height="88px" BorderStyle="Solid">
				<P>Remove product?</P>
				<P>
					<asp:Button id="btnRemoveProductOK" runat="server" Text="OK" Width="64px"></asp:Button>
					<asp:Button id="btnRemoveProductCancel" runat="server" Text="Cancel" Width="64px"></asp:Button></P>
			</asp:Panel>
		</form>
	</body>
</HTML>
