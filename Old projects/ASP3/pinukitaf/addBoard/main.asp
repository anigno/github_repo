<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%runAdmin()%>

<%
conn=openDb(addFile)
set rs=getRs()
sql="select * from tblMessages order by iDate DESC"
rs.open sql,conn
%>
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=../Styles.css>
	<title>Page title</title>
</head>
<body>
<table align=center width=600 ID="Table1" border=1>
<tr>
<td><a href="vbscript:window.history.back()">חזרה</a>
&nbsp&nbsp&nbsp<a href=editNew.asp?new=yes>הוספת הודעה חדשה</a></td>
</tr>
</table>
<table align=center width=600 ID="Table2" border=1>
<tr>
<td align=center colspan=2><font size=6>הודעות</font></td>
</tr>
<%while not rs.eof%>
<tr>
<%
theDate=rs("iDate")
d=getDay(theDate)
m=getMonth(theDate)
y=getYear(theDate)
%>
<td><%=d & "/" & m & "/" & y%></td><td><%=rs("iText")%></td>
</tr>
<%rs.moveNext%>
<%wend%>

</table>

</body>
</html>
<%
set rs=nothing
set conn=nothing
%>