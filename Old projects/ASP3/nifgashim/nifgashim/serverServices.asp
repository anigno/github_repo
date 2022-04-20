<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<BODY bgcolor=darkslategray text="#66ff99" link="#00ffcc" vlink="#00ffcc" alink="#ffffff">

<%
	'open DB
	mdbFile="\db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
	set rs1=Server.Createobject("ADODB.RecordSet")
	set rs2=Server.Createobject("ADODB.RecordSet")
%>

<%
	sql="select * from tblUsers"
	rs.Open sql,conn
	sql="select * from tblRequests"
	rs1.Open sql,conn
%>
<table border=1>
<tr><td><FONT color=gold>username</FONT></td><td><FONT color=gold>family</FONT></td><td><FONT color=gold>name</FONT></td></tr>
<%
	do while not rs.EOF
		Response.Write "<tr><td>" & rs("username") & _
					   "</td><td>" & rs("family") & _
					   "</td><td>" & rs("name") & _
					   "</td></tr>"
		rs.MoveNext
	loop
%></table>
<table border=1>
<tr><td><FONT color=gold>username</FONT></td><td><FONT color=gold>friend</FONT></td><td><FONT color=gold>request</FONT></td></tr>
<%
	do while not rs1.EOF
		Response.Write "<tr><td>" & rs1("username") & _
					   "</td><td>" & rs1("friend") & _
					   "</td><td>" & rs1("request") & _
					   "</td></tr>"
		rs1.MoveNext
	loop
%></table>
</BODY>
</HTML>
