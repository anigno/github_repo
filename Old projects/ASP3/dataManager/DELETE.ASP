<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<%
	dim mdbFile,connString,conn,rs,sql
	'open DB
	mdbFile="..\db\dataManager.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
	
	'delete requested record
	sql="delete from tblData where subject='" & _
		Request.Form("txtSubject") & "'"
	rs.Open sql,conn
	Response.Redirect "main.asp"
%>




</BODY>
</HTML>
