<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
key=Request.QueryString("key")
conn=openDb(mdbFile)
set rs=getRs()
'get subject name
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
<td align=center>הוספת תמונה עבור: <%=SubjectName%></td>
</tr>
<tr>
<td><a href="vbscript:window.history.back">חזרה</a></td></td>
</tr>
</table>

<form method="post" action="pictureLoad01.asp" enctype="multipart/form-data" id="Form1">
<table align=center width=600 ID="Table3" border=1>
	<tr><td><INPUT id="File2" type="file" name="File1"></td></tr>
	<tr><td><INPUT type="button" value="הוסף" ID="Button5" NAME="Button1" onclick="buttonAdd(<%=key%>)">&nbsp&nbsp&nbsp
			<INPUT type="button" value="ביטול" ID="Button6" NAME="Button2" onclick=buttonCancel()>
	</td></tr>
</table>
</form>

</body>
</html>
<script language=vbscript>
sub buttonAdd(key)
	formOk=true
	if form1.File1.value="" then formOk=false
	if formOk=true then
		form1.action="pictureLoad01.asp?key=" & key
		form1.submit
	else
		MsgBox "בעיה בטופס!",vbOKOnly
	end if
end sub

sub buttonCancel()
	window.history.back
end sub

</script>