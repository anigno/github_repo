<%@ Page language="c#" Codebehind="main.aspx.cs" AutoEventWireup="false" Inherits="pinukitafNet.main" codepage="1255" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>main</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK REL="stylesheet" TYPE="text/css" HREF="Styles.css">
	</HEAD>
	<body dir="rtl" background="pictures/bg/BD15131_.GIF">
		<p align="center">
			<OBJECT id="pinukitaf_main" codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
				height="200" width="600" align="middle" classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000">
				<PARAM NAME="_cx" VALUE="12700">
				<PARAM NAME="_cy" VALUE="4233">
				<PARAM NAME="FlashVars" VALUE="">
				<PARAM NAME="Movie" VALUE="pinukitaf_main.swf?weekSubject=<%=weekSubject%>">
				<PARAM NAME="Src" VALUE="pinukitaf_main.swf?weekSubject=<%=weekSubject%>">
				<PARAM NAME="WMode" VALUE="Transparent">
				<PARAM NAME="Play" VALUE="-1">
				<PARAM NAME="Loop" VALUE="-1">
				<PARAM NAME="Quality" VALUE="High">
				<PARAM NAME="SAlign" VALUE="">
				<PARAM NAME="Menu" VALUE="-1">
				<PARAM NAME="Base" VALUE="">
				<PARAM NAME="AllowScriptAccess" VALUE="sameDomain">
				<PARAM NAME="Scale" VALUE="ShowAll">
				<PARAM NAME="DeviceFont" VALUE="0">
				<PARAM NAME="EmbedMovie" VALUE="0">
				<PARAM NAME="BGColor" VALUE="333333">
				<PARAM NAME="SWRemote" VALUE="">
				<PARAM NAME="MovieData" VALUE="">
				<PARAM NAME="SeamlessTabbing" VALUE="1">
				<embed src="pinukitaf_main.swf" quality="high" wmode="transparent" bgcolor="#333333" width="600"
					height="200" name="pinukitaf_main" align="middle" allowScriptAccess="sameDomain" type="application/x-shockwave-flash"
					pluginspage="http://www.macromedia.com/go/getflashplayer" />
			</OBJECT>
		</p>
		<%if(Session["admin"]=="yes"){%>
		<form id="Form1" method="post" runat="server">
			<table border="1" align="center" width="700">
				<tr>
					<td>
						<P align="right"><a href="admin/admin.aspx"><FONT size="4">צפייה בסטטיסטיקת משתמשים</FONT></a>
						</P>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Button id="btnNewSubject" runat="server" Text="רישום נושא שבועי חדש"></asp:Button>&nbsp;
						<asp:TextBox id="txtNewSubject" runat="server" Width="447px" TextMode="MultiLine" Rows="1"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Button id="btnNewMessage" runat="server" Text="הוספת הודעה להורים"></asp:Button>&nbsp;
						<asp:TextBox id="txtNewMessage" runat="server" Width="467px" TextMode="MultiLine" Rows="1"></asp:TextBox>
					</td>
				</tr>
			</table>
		</form>
		<%}%>
		<asp:Repeater id="rptMessages2" runat="server">
			<HeaderTemplate>
				<table border="1" align="center" width="700">
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><%# DataBinder.Eval(Container.DataItem, "iDate") %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "iText") %></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
		<P>&nbsp;</P>
		<P>&nbsp;</P>
		<P>&nbsp;</P>
		<P>&nbsp;</P>
		<P>
			<a href="admin/setAdmin.aspx"><font size="1" color="blue">anigno</font></a>
		</P>
	</body>
</HTML>
