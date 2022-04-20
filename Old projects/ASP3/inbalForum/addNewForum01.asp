<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<BODY>

<%
	'open DB
	dim mdbFile,sql,RS,RS1,RS2
	mdbFile="\db\inbalforum.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs1=Server.Createobject("ADODB.RecordSet")
%>
<%
	sql="insert into forums (forumName,forumDescription)" & _
	" values('" & Request.Form("txtName") & "','" & Request.Form("txtDescription") & "')"
	RS1.Open sql,conn
%>

</BODY>
</HTML>
<%
	Set Conn = Nothing
%>