<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
<BODY>

<%
	key=Request.QueryString("key")
	showDay=Request.QueryString("showDay")
%>

<%
	'open DB
	mdbFile="../../db/calendar.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>

<%
	sql="delete from tblCalendar where key=" & key
	rs.Open sql,conn
	Response.Redirect "data.asp?showDay=" & showDay
%>
</BODY>
</HTML>
