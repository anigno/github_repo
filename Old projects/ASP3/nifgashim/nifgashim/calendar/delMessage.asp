<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<%
	key=Request.QueryString("key")
	showDay=Request.QueryString("showDay")
	username=Request.QueryString("username")
%>

<%
	'open DB
	mdbFile="/db/calendar.mdb"
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
	Response.Redirect "data.asp?showDay=" & showDay & "&username=" & username
%>
</BODY>
</HTML>
