<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<html>
<head>
<meta http-equiv="Refresh" content="180;#">
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">

</head>
<body dir="rtl" stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">

<font size="4">הודעות אחרונות בפורום</font><br>
<font size="3">

<%	
	iUsername=session("inbal_username")
	Response.Write iUsername
	session.Timeout=30
%>

</font>

<%
	conn=openDb()
	set rs=getRs()
	set rs1=getRs()
%>

<table border="1" width="90%">
<tr><td><a href="forums.asp"><font size="2">חזרה</font></a>
</td></tr>
<%
	sql="select * from forumData order by iDate DESC,iTime DESC"
	RS1.Open sql,conn
	dim maxShow,a,iForumName
	maxShow=20:a=0
%>
<%
	while not RS1.EOF and a<maxShow
	'get forum name from table forums
	sql="select * from forums where key=" & rs1("forumId")
	rs.Open sql,conn
	iForumName=rs("forumName")
	rs.Close
%>
<tr>
<td><font size="2"><%=iForumName%></font></td>
<td><font size="2">
<a href="forumShow.asp?forumId=<%=rs1("forumId")%>" title="<%=rs1("txtMessage")%>">
<div id="iSub<%=a%>"><%=rs1("txtSubject")%></div></a></font></td>
<td><font size="1"><%=rs1("txtUsername")%></font></td>
<td><font size="1"><%=rs1("iDate")%></font></td>
<td><font size="1"><%=rs1("iTime")%></font></td>
</tr>

<%
	a=a+1
	RS1.MoveNext
	wend
%>

</body>
</html>

<%
	Set Conn = Nothing
%>

<%
'create script to change subject with showText
for b=0 to a-1
	Response.Write "<script language=vbscript>"
	Response.Write "iSub" & b & ".innerhtml=showText(isub" & b & ".innerhtml)"
	Response.Write "</script>"
next 
%>
