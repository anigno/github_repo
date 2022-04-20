<%@ Page language="c#" Codebehind="fProductUpdate.aspx.cs" AutoEventWireup="false" Inherits="anignoEShop.admin.fProductUpdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>fProductUpdate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK REL="stylesheet" TYPE="text/css" HREF="..\style.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:button id="dummie" style="Z-INDEX: 109; LEFT: 760px; POSITION: absolute; TOP: 8px" runat="server"
				Text="." Height="8px" Width="8px"></asp:button><asp:panel id="pnlEditProduct" style="Z-INDEX: 115; LEFT: 40px; POSITION: absolute; TOP: 496px"
				runat="server" Height="64px" Width="360px" Visible="False">
<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD colSpan="4">
							<asp:Label id="Label14" runat="server" Width="120px">Edit product:</asp:Label>
							<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" Height="16px" Width="1px" ErrorMessage="!"
								ControlToValidate="txtEditProductName"></asp:RequiredFieldValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Height="16px" Width="1px" ErrorMessage="!"
								ControlToValidate="txtEditProductPrise"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" ErrorMessage="!" ControlToValidate="txtEditProductName"
								ValidationExpression="[^&quot;'<>]{1,}"></asp:RegularExpressionValidator>
							<asp:RangeValidator id="RangeValidator2" runat="server" Height="16px" Width="48px" ErrorMessage="NUM!"
								ControlToValidate="txtEditProductPrise" Type="Double" MinimumValue="0.01" MaximumValue="9999"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label13" runat="server" Width="60px">Name:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtEditProductName" runat="server" Width="164px"></asp:TextBox></TD>
						<TD>
							<asp:Label id="Label12" runat="server" Width="56px">Prise:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtEditProductPrise" runat="server" Width="164px"></asp:TextBox></TD>
					</TR>
				</TABLE>
<asp:Button id="btnEditProductOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnEditProductCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></asp:panel><asp:linkbutton id="lbtnAddProduct" style="Z-INDEX: 113; LEFT: 240px; POSITION: absolute; TOP: 136px"
				runat="server" CausesValidation="False">Add product</asp:linkbutton><asp:panel id="pnlRemoveProduct" style="Z-INDEX: 112; LEFT: 536px; POSITION: absolute; TOP: 392px"
				runat="server" Height="56px" Width="200px" Visible="False">
<TABLE id="Table4" style="WIDTH: 240px; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="240"
					border="1">
					<TR>
						<TD colSpan="2">
							<asp:Label id="Label9" runat="server" Width="160px">Remove product?</asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblRemoveProduct" runat="server" Width="216px">product</asp:Label></TD>
					</TR>
				</TABLE>
<asp:Button id="btnRemoveProductOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnRemoveProductCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></asp:panel><asp:label id="Label7" style="Z-INDEX: 111; LEFT: 152px; POSITION: absolute; TOP: 136px" runat="server">Products:</asp:label><asp:linkbutton id="lbtnRemoveSubject" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 328px"
				runat="server" CausesValidation="False">Remove subject</asp:linkbutton><asp:linkbutton id="lbtnEditSubject" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 304px"
				runat="server" CausesValidation="False">Edit subject</asp:linkbutton><asp:linkbutton id="lbtnAddSubject" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 280px"
				runat="server" CausesValidation="False">Add subject</asp:linkbutton><asp:label id="Label1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 16px" runat="server">List of subjects:</asp:label><asp:listbox id="lstSubjects" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px"
				runat="server" Height="240px" Width="128px" AutoPostBack="True"></asp:listbox><asp:panel id="pnlAddSubject" style="Z-INDEX: 106; LEFT: 800px; POSITION: absolute; TOP: 40px"
				runat="server" Height="56px" Width="248px" Visible="False">
				<P>
					<TABLE id="Table2" style="WIDTH: 208px; HEIGHT: 62px" cellSpacing="1" cellPadding="1" width="208"
						border="1" runat="server">
						<TR>
							<TD colSpan="2">
								<asp:Label id="Label2" runat="server" Width="104px">Add subject:</asp:Label>
								<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="!" ControlToValidate="txtAddSubject"
									ValidationExpression="[^&quot;'<>]{1,}"></asp:RegularExpressionValidator>
								<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Height="16px" Width="1px" ErrorMessage="!"
									ControlToValidate="txtAddSubject"></asp:RequiredFieldValidator></TD>
						</TR>
						<TR>
							<TD>
								<asp:Label id="Label3" runat="server" Width="60px">Name:</asp:Label></TD>
							<TD>
								<asp:TextBox id="txtAddSubject" runat="server" Width="164px"></asp:TextBox></TD>
						</TR>
					</TABLE>
					<asp:Button id="btnAddSubjectOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp;
					<asp:Button id="btnAddSubjectCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></P>
			</asp:panel><asp:panel id="pnlEditSubject" style="Z-INDEX: 107; LEFT: 800px; POSITION: absolute; TOP: 136px"
				runat="server" Height="40px" Width="248px" Visible="False">
<TABLE id="Table1" style="WIDTH: 241px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="241"
					border="1">
					<TR>
						<TD colSpan="2">
							<asp:Label id="Label5" runat="server" Width="104px">Edit subject:</asp:Label>
							<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ErrorMessage="!" ControlToValidate="txtEditSubject"
								ValidationExpression="[^&quot;'<>]{1,}"></asp:RegularExpressionValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Height="16px" Width="1px" ErrorMessage="!"
								ControlToValidate="txtEditSubject"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label4" runat="server" Width="60px">Name:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtEditSubject" runat="server" Width="164px"></asp:TextBox></TD>
					</TR>
				</TABLE>
<asp:Button id="btnEditSubjectOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnEditSubjectCancel" runat="server" Text="Cancel" Width="60px"></asp:Button></asp:panel><asp:panel id="pnlRemoveSubject" style="Z-INDEX: 108; LEFT: 800px; POSITION: absolute; TOP: 232px"
				runat="server" Height="56px" Width="200px" Visible="False">
<TABLE id="Table3" style="WIDTH: 240px; HEIGHT: 40px" cellSpacing="1" cellPadding="1" width="240"
					border="1">
					<TR>
						<TD colSpan="2">
							<asp:Label id="Label6" runat="server" Width="136px">Remove subject?</asp:Label></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="lblRemoveSubject" runat="server" Width="224px">subject</asp:Label></TD>
					</TR>
				</TABLE>
<asp:Button id="btnRemoveSubjectOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnRemoveSubjectCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></asp:panel><asp:datagrid id="dgProducts" style="Z-INDEX: 110; LEFT: 152px; POSITION: absolute; TOP: 160px"
				runat="server" Height="16px" Width="624px" AutoGenerateColumns="False">
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="fldKey" HeaderText="key"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="fldSubjectKey" HeaderText="subjectKey"></asp:BoundColumn>
					<asp:BoundColumn DataField="fldName" HeaderText="Product">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="fldPrise" HeaderText="Prise"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<IMG src='<%=anignoEShop.classes.cUtil.UPLOAD_PATH_HTML+"/"%><%# DataBinder.Eval(Container.DataItem, "fldImage") %>' height=30>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:ButtonColumn Text="Edit" CommandName="edit"></asp:ButtonColumn>
					<asp:ButtonColumn Text="Remove" CommandName="remove"></asp:ButtonColumn>
					<asp:ButtonColumn Text="Upload image" CommandName="upload"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid><asp:panel id="pnlAddProduct" style="Z-INDEX: 114; LEFT: 40px; POSITION: absolute; TOP: 392px"
				runat="server" Height="64px" Width="360px" Visible="False">
<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="300" border="1">
					<TR>
						<TD colSpan="4">
							<asp:Label id="Label8" runat="server" Width="120px">Add product:</asp:Label>
							<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Height="16px" Width="1px" ErrorMessage="!"
								ControlToValidate="txtAddProductName"></asp:RequiredFieldValidator>
							<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Height="16px" Width="1px" ErrorMessage="!"
								ControlToValidate="txtAddProductPrise"></asp:RequiredFieldValidator>
							<asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" ErrorMessage="!" ControlToValidate="txtAddProductName"
								ValidationExpression="[^&quot;'<>]{1,}"></asp:RegularExpressionValidator>
							<asp:RangeValidator id="RangeValidator1" runat="server" Height="16px" Width="48px" ErrorMessage="NUM!"
								ControlToValidate="txtAddProductPrise" Type="Double" MinimumValue="0.01" MaximumValue="9999"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:Label id="Label10" runat="server" Width="60px">Name:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtAddProductName" runat="server" Width="164px"></asp:TextBox></TD>
						<TD>
							<asp:Label id="Label11" runat="server" Width="56px">Prise:</asp:Label></TD>
						<TD>
							<asp:TextBox id="txtAddProductPrise" runat="server" Width="164px"></asp:TextBox></TD>
					</TR>
				</TABLE>
<asp:Button id="btnAddProductOK" runat="server" Text="OK" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnAddProductCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></asp:panel><asp:panel id="pnlUploadProductImage" style="Z-INDEX: 116; LEFT: 536px; POSITION: absolute; TOP: 496px"
				runat="server" Height="78px" Width="464px">
<TABLE id="Table7" style="WIDTH: 464px; HEIGHT: 57px" cellSpacing="1" cellPadding="1" width="464"
					border="1">
					<TR>
						<TD colSpan="2">
							<asp:Label id="Label15" runat="server" Width="152px">Upload image for:</asp:Label>
							<asp:Label id="lblUploadProductImage" runat="server" Width="288px">product</asp:Label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 269px" colSpan="2"><INPUT id="fileUploadProductImage" style="WIDTH: 448px; HEIGHT: 25px" type="file" size="55"
								name="File1" runat="server"></TD>
					</TR>
				</TABLE>
<asp:Button id="btnUploadProductImageOK" runat="server" Text="Upload" Width="60px"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnUploadProductImageCancel" runat="server" Text="Cancel" Width="60px" CausesValidation="False"></asp:Button></asp:panel></form>
	</body>
</HTML>
