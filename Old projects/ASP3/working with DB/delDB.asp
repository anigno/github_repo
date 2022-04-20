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
'del from database
	'delete all records
	sql="delete from tblPersons"	
	'delete specific records (containing the word 'gina')
	sql="delete from tblPersons where person like '%gina%'"
	'(the % char meens any char or chars)
	rs.open sql,conn
%>


</BODY>
</HTML>
