<%@ Import Namespace="System.Data.OleDb" %>
<script runat="server">
sub Page_Load
	dim dbconn,sql,dbcomm,dbread
	'create connection string for *.mdb and open it
	dbconn=New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;	data source=" & server.mappath("myData.mdb"))
	dbconn.Open()
	'create command from sql and run it
	sql="SELECT * FROM tblData"
	dbcomm=New OleDbCommand(sql,dbconn)
	'create reader
	dbread=dbcomm.ExecuteReader()
	'use repeater object, bind the reader to it
	names.DataSource=dbread
	names.DataBind()
	'close the connection and command
	dbread.Close()
	dbconn.Close()
end sub
</script>

<html>
<body>
<form runat="server" ID="Form1">
	<asp:Repeater id="names" runat="server">
		<HeaderTemplate>
			<table border="1" width="100%">
			<tr>
			<th>key</th>
			<th>name</th>
			<th>id</th>
			</tr>
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
</html>
