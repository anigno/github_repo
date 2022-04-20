<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<%
	dim mdbFile,connString,conn,rs,sql
'open DB
	mdbFile="db\testDB.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>

<%
'read from database
	sql="select * from tblPersons"
	rs.open sql,conn
	if not rs.EOF then rs.MoveFirst
	while not rs.EOF
		Response.Write rs("person") & " " & rs("email") & "<BR>"
		rs.MoveNext
	wend
%>


</BODY>
</HTML>
