<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<%
	'show selected message by key
	'write session("inbal_showMessage")
%>
	
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body stylesrc="main.asp" bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	forumId=Request.QueryString("forumId")
	iUsername=session("inbal_username")
	key=Request.QueryString("key")
	iRoot=Request.QueryString("iRoot")
%>

<%
	conn=openDb()
	set rs1=getRs()
%>	

<%
	'getting message data
	sql="select * from forumData where key=" & key
	RS1.Open sql,conn
	session("inbal_showMessage")=rs1("txtUsername") & " : " _
		& rs1("txtSubject") & " - " _
		& rs1("txtMessage")
%>

<table border="1" dir="rtl" align="center" width="75%">
<tr><td><%=rs1("iTime")%>&nbsp;</td><td><%=rs1("iDate")%>&nbsp;</td></tr>
<tr><td colspan="2"><%=rs1("txtUsername")%>&nbsp;</td></tr>
<tr><td colspan="2"><div id="tSubject"><%=rs1("txtSubject")%></div></td></tr>
<tr><td colspan="2"><div id="tMessage"><%=rs1("txtMessage")%></div></td></tr>
<tr><td><a href="forumshow.asp?forumId=<%=forumId%>">חזרה לפורום</a></td>
<td><a href="addMessage.asp?forumId=<%=forumId%>&amp;iParent=<%=key%>&amp;iText=התיחסות&amp;iRoot=<%=iRoot%>">הוסף התיחסות</a>
</td></tr>
</table>
</body>
</html>

<script language="vbscript">
	tSubject.innerHTML=showText(tSubject.innerHTML)
	tMessage.innerHTML=showText(tMessage.innerHTML)
</script>
<%
	Set Conn = Nothing
%>