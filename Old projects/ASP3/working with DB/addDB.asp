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
'add to database
	sql="insert into tblPersons values('gina ami','ami@gina.com')"
	rs.open sql,conn
	sql="insert into tblPersons (person,email) values('berko meni','berko@meni.co.il')"
	rs.open sql,conn
	sql="insert into tblPersons (email) values('sarit@gina.com')"
	rs.open sql,conn
	sql="insert into tblPersons (person) values('pasternak sharon')"
	rs.open sql,conn
%>


</BODY>
</HTML>
