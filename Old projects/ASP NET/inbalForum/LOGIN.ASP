<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'recieving form data from main.asp
	'check username and passwd in users table
	'writing session("inbal_Username")
	'redirect to forums.asp
	
%>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">


<%
	iUsername=Request.Form("txtUsername")
	session("inbal_Username")=iUsername
	session.Timeout=30
	iPasswd=Request.Form("txtPasswd")
%>

<%
	dim conn,rs1,SQL
	conn=openDb()
	set rs1=getRs()
%>

<%
	SQL="select * from users where txtUsername='" & iUsername & "'" _
		& "and txtPasswd='" & iPasswd & "'"
	rs1.Open sql,conn
	
	if rs1.eof then
		'username not exist with this passwd
		Response.Write "שם משתמש לא קיים או סיסמא שגויה" & "<br>"
		Response.Write "חזור ונסה שוב" & "<br>"
	else
		'redirect to forum.asp
		Response.Redirect "forums.asp"
	end if
%>	
</body>
</html>
<%
	Set Conn = Nothing
%>