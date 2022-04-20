<!--#INCLUDE FILE="functions.asp" -->
<html>
<head>
</head>
<body dir="rtl" stylesrc="../data.htm" background="../../bg01.jpg" text="#440000" link="#800000" vlink="#800000" alink="#CC0000">
<%
	dim conn,rs,sql
	conn=openDB()
	set rs=getrs()
	set rs2=getrs()
	sql="select * from tblSubjects order by iSubject ASC"
	rs.open sql,conn
%>
<table border="1" align="center">
<%while not rs.eof%>
<tr><td align="center">
<a href="showOneSubject.asp?iKey=<%=rs("iKey")%>">
<font size="4"><%=rs("iSubject")%></font>
</a>
<%rs.movenext%> &nbsp;</td></tr>
<%wend%>
</table>

<p align="center"><font size="5">מבצעים חמים</font></p>
<%
	'special offers
	sql="select * from tblProducts order by iSubject ASC"
	rs2.open sql,conn
%>
<table border="1" align="center">
<%while not rs2.eof%>
<%if rs2("iSpecial")<>"" then%>
<tr>
<td><%=rs2("iSpecial")%></td><td><%=rs2("iProduct")%></td><td><%=rs2("iPrise")%> ש&quot;ח</td>
</tr>
<%end if%>
<%rs2.movenext%>
<%wend%>
</table>
</body>
<%set rs=nothing%>
<%set rs2=nothing%>
</html>