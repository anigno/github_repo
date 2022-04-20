<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	dim mdbFile,connString,conn,conn2,rs,rs2,sql,sql2
	'open DB
	mdbFile="db\simpleForum.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")

	dim iSubject,iEmail,iMessage,iName
	iSubject=Request.Form("text3")
	iEmail=Request.Form("text2")
	iMessage=Request.Form("textarea1")
	iName=Request.Form("text1")
	sql="insert into table1 (subject,email,message,name,connected) values (" & _
		"'" & iSubject & "'," &_
		"'" & iEmail & "'," &_
		"'" & iMessage & "'," &_
		"'" & iName & "','root')"
	rs.Open sql,conn
	Response.Redirect "main01.asp"
%>

add new subject 01

</BODY>
</HTML>
