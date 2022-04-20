<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'show all forums and description
%>

<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">

</head>
<body stylesrc="main.asp" dir="rtl" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<font size="4">רשימת הפורומים באתר</font><br>
<%
	iUsername=session("inbal_username")
	Response.Write iUsername
	session.Timeout=30
%>

<%
	dim conn,rs1,SQL
	conn=openDb()
	set rs1=getrs()
	
%>
<table border="1">
<tr><td>
</td><td>
<a href="showLastMessages.asp">
<font size="2">הודעות אחרונות בפורומים</font></a></td>
</tr>
<%
	'write list of avalliable forums
	sql="select * from forums"
	RS1.Open sql,conn
	while not RS1.EOF
%>
<tr>
<td>
<a href="forumShow.asp?forumId=<%=rs1("key")%>">
<%=rs1("forumName")%></a>&nbsp;</td>
<td><%Response.Write rs1("forumDescription")%>&nbsp;</td>
</tr>
<%		RS1.MoveNext
	wend
%>
</table>
<input type="button" value="יציאה" id="button1" name="btnExit" style="BACKGROUND-COLOR: moccasin">
</body>
</html>
<script language="vbscript">
	sub btnExit_onClick()
		window.navigate "main.asp"
	end sub
</script>
<%
	Set Conn = Nothing
%>