<%@ Import namespace="System.Data.OleDb"%>

<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm2.aspx.vb" Inherits="dbTest01.WebForm2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<script runat=server>
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbconn, sql, dbcomm, dbread
        'create connection string for *.mdb and open it
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;	data source=" & Server.MapPath("myData.mdb"))
        dbconn.Open()
        'create command from sql and run it
        sql = "SELECT * FROM tblData"
        dbcomm = New OleDbCommand(sql, dbconn)
        'create reader
        dbread = dbcomm.ExecuteReader()
        'use repeater object, bind the reader to it
        names.DataSource = dbread
        names.DataBind()
        'close the connection and command
        dbread.Close()
        dbconn.Close()
    End Sub
</script>
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Repeater id="names" runat="server">
				<HeaderTemplate>
				<table border=1>
				</HeaderTemplate>
				<ItemTemplate>
			<tr>
			<td><%#Container.DataItem("iKey")%></td>
			<td><%#Container.DataItem("iName")%></td>
			<td><%#Container.DataItem("iId")%></td>
			</tr>
			
				</ItemTemplate>
				<FooterTemplate>
				</table>
				</FooterTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
