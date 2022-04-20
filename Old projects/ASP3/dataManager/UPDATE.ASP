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
%>

<%
	'convert aData to protect from ",chr(13) and others
	temp=Request.Form("txtData")
	temp2=""
	for a=1 to len(temp)
		temp2=temp2 & chr((asc(mid(temp,a,1))+96))
	next
	'update data in DB
	sql="update tblData set " & _
	"aAddress='" & Request.Form("txtAddress") & "' " & _
	",aPhone1='" & Request.Form("txtPhone1") & "' " & _
	",aPhone2='" & Request.Form("txtPhone2") & "' " & _
	",aEmail='" & Request.Form("txtEmail") & "' " & _
	",aData='" & temp2 & "' " & _
	"where subject='" & Request.Form("txtSubject") & "'"
	rs.Open sql,conn
	Response.Redirect "main.asp"
%>
</BODY>
</HTML>
