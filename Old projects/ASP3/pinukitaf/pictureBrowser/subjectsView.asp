<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
conn=openDB(mdbFile)
%>
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=../Styles.css>
</head>
<title>Page title</title>
<body>
<%
set rs=getRs()
sql="select * from tblSubjects order by iDate DESC"
rs.open sql,conn
%>
<table align=center width=600 ID="Table1" border=1>
<tr>
<td align=center colspan=3>רשימת נושאים</td>
</tr>

<tr><td>תאריך</td><td>נושא</td><td align=center height=30><img src=<%=picturesPath%>kpdrgnsmk16_e0.gif width=250 height=30></td></tr>
<%
while not rs.eof
%>
<%
t=rs("iDate")
%>
<tr><td><%=getDate(t)%></td><td><%=rs("iName")%></td>
<td>
<a href=picturesView.asp?key=<%=rs("iKey")%>>תמונות</a>
</td>
</tr>
<%
rs.moveNext
wend
%>
</tr>
</table>
</body>
</html>
<%
rs.close
set rs=nothing
set con=nothing
%>