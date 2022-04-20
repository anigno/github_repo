<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'recieving form data from main.asp
	'check if username exist and add new user name and passwd
	'write session("inbal_Username")

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
	iPasswd=Request.Form("txtPasswd")
	iAge=Request.Form("txtAge")
	iSex=Request.Form("txtSex")
	iRegion=Request.Form("txtRegion")
	if iPasswd="" then
		Response.Write "סיסמא ריקה אסורה" & "<BR>"
		Response.Write "חזור והשלם סיסמא"
		Response.End
	end if
%>
מוסיף את<br>
<%
	Response.Write iusername & "<BR>"
	Response.Write iage & "<BR>"
	Response.Write isex & "<BR>"
	Response.Write iregion & "<BR>"
%>

<%
	dim conn,SQL,RS
	conn=openDb()
	set rs=getRs()
	set rs1=getRs()
%>

<font color="red">
<%
	'check if username already exist
	sql="select * from users where txtUsername='" & iUsername & "'"
	rs1.Open sql,conn
	if not rs1.eof then
		Response.Write "שם משתמש תפוס" & "<br>"
		Response.Write "חזור ובחר שם משתמש אחר" & "<br>"
	else
%>
</font>
<%
	'add username to users table
	sql="insert into users(txtUsername,txtPasswd,txtAge,txtSex,txtRegion) values(" _
	& "'" & iUsername & "'," _
	& "'" & iPasswd & "'," _
	& "'" & iAge & "'," _
	& "'" & iSex & "'," _
	& "'" & iRegion & "')"
	rs.Open sql,conn
	Response.Redirect "forums.asp"
%>

<%
end if
%>

</body>
</html>
<%
	Set Conn = Nothing
%>