<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%runAdmin()%>
<%
key=Request.QueryString("key")
conn=openDb(mdbFile)
set rs=getRs()
sql="select * from tblSubjects where iKey=" & key
rs.open sql,conn
subjectName=rs("iName")
set rs=nothing
set con=nothing
%>
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=../Styles.css>
	<title>Page title</title>
</head>
<body>
<table align=center width=600 ID="Table1">
<tr>
<td align=center colspan=2>תמונות עבור: <%=subjectName%></td>
</tr>
<tr>
<td><a href=subjects.asp>חזרה</a></td></td>
<td><a href=pictureAdd01.asp?key=<%=key%>>הוסף תמונה</a></td>
</tr>
</table>
<%
conn=openDb(mdbFile)
set rs=getRs()
sql="select * from tblPictures where iSubject=" & key
rs.open sql,conn
%>
<form id=form1 method=post>
<table align=center width=600 ID="Table2" border=1>
<%while not rs.eof%>
<tr>
<td align=center><img src=<%=uploadPath & rs("iFile")%> width=400><br><%=rs("iName")%></td>
<td align=center><INPUT type="button" value="מחק" ID="Button1" NAME="Button1" onclick=buttonDel(<%=rs("iKey")%>)></td>
</tr>
<%rs.moveNext%>
<%wend%>
</table>
</form>
<%
rs.close
set rs=nothing
set conn=nothing
%>
</body>
</html>
<script language=vbscript>
sub buttonDel(key)
	sKey=<%=key%>
	if MsgBox("האם למחוק תמונה?",vbOKCancel)=vbOK then
		form1.action="pictureDel.asp?key=" & key & "&sKey=" & sKey
		form1.submit
	end if
end sub
</script>