<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<%
	iFriend=Request.QueryString("friend")
	iUsername=Request.Cookies("nifgashim")("username")
%>

<%
	'open DB
	mdbFile="\db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>

<%
	'write data to tblTalk
	sql="insert into tblTalk (username,friend,theText) values ('" &_
		iUsername & "','" &_
		iFriend & "','" &_
		iUsername & ": " & Request.Form("txtSend") & "')"
	rs.open sql,conn
%>

<%
	Response.Redirect "send.asp?friend=" & iFriend
%>
</BODY>
</HTML>
