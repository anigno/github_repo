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
	'check to add new address or data
	if Request.Form("radAddress")="on" then
		'address
		sql="insert into tblData (userName,dataType,subject,aAddress,aPhone1,aPhone2,aEmail) " _
			& "values ('" _
			& Session("userName") & "','" _
			& "address','" _
			& Request.Form("txtSubject") & "','" _
			& Request.Form("txtAddress") & "','" _
			& Request.Form("txtPhone1") & "','" _
			& Request.Form("txtPhone2") & "','" _
			& Request.Form("txtEmail") _
			& "')"
		Response.Write sql
		rs.Open sql,conn
	else
		'data
		'convert aData to protect from ",chr(13) and others
		temp=Request.Form("txtData")
		temp2=""
		for a=1 to len(temp)
			temp2=temp2 & chr((asc(mid(temp,a,1))+96))
		next

		sql="insert into tblData (userName,dataType,subject,aData) " _
			& "values ('" _
			& Session("userName") & "','" _
			& "general','" _
			& Request.Form("txtSubject") & "','" _
			& temp2 _
			& "')"
		Response.Write sql
		rs.Open sql,conn
	end if
	Response.Redirect "main.asp"
%>



</BODY>
</HTML>
