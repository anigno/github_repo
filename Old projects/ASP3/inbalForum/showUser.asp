<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body stylesrc="main.asp" dir="rtl" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">


<%
	dim rUsername
	rUsername=Request.Form("txtUsername")
	if rUsername="" then rUsername="urjfhsjshdjdhdjshwudj"
%>

<%
	conn=openDb()
	set rs1=getRs()
%>

<%
	sql="select * from users where txtUsername='" & rUsername & "'"
	RS1.open sql,conn
%>
<table border="1" width="75%" align="center">
<tr><td>שם משתמש</td><td><%=rs1("txtUsername")%></td></tr>
<tr><td>גיל</td><td><%=rs1("txtAge")%></td></tr>
<tr><td>מין</td><td><%=rs1("txtSex")%></td></tr>
<tr><td>איזור מגורים</td><td><%=rs1("txtRegion")%></td></tr>
<tr><td></td><td></td></tr>
</body>
</html>
<%
	Set Conn = Nothing
%>