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
'update records in database
	sql="update tblPersons set email='sharon@paster.com' where person='pasternak sharon'"
	rs.open sql,conn
%>


</BODY>
</HTML>
