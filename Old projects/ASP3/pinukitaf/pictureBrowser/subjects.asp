<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%runAdmin()%>
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
<table align=center width=600>
<tr>
<td align=center colspan=2>����� ������</td>
</tr>
<tr>
<td><a href=../adminStart.asp>����</a></td><td><a href=subjectEditNew.asp?new=yes>����� ����</a></td>
</tr>
</table>

<table align=center width=600 border=1>
<tr><td>�����</td><td>����</td><td></td></tr>
<%
while not rs.eof
%>
<%
t=rs("iDate")
%>
<tr><td><%=getDate(t)%></td><td><%=rs("iName")%></td>
<td>
<a href=subjectEditNew.asp?new=no&key=<%=rs("iKey")%>>����/���</a>
&nbsp&nbsp&nbsp<a href=pictures.asp?key=<%=rs("iKey")%>>������</a>
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