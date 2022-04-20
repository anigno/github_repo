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
<form id=form1 method=post action=pictureLoad.asp enctype="multipart/form-data">
<table align=center width=600 ID="Table2" border=1>
<tr>
<td>תאור התמונה</td><td><INPUT type="text" ID="Text1" NAME="Text1" size=50></td>
</tr>
<tr>
<td colspan=2><INPUT type="file" ID="File1" NAME="File1" size=52></td>
</tr>
<tr>
<td></td>
<td>
<INPUT type="button" value="הוסף" ID="Button1" NAME="Button1" onclick=buttonAdd(<%=key%>)>&nbsp&nbsp&nbsp
<INPUT type="button" value="ביטול" ID="Button2" NAME="Button2" onclick=buttonCancel()>
</td>
</tr>
</table>
</form>
</body>
</html>
<script language=vbscript>

sub buttonAdd(key)
	formOk=true
	if checkText(form1.Text1.value,txtAll)=false then formOk=false
	if form1.File1.value="" then formOk=false
	if formOk=true then
		form1.action="pictureLoad.asp?key=" & key
		form1.submit
	else
		MsgBox "בעיה בטופס!",vbOKOnly
	end if
end sub

sub buttonCancel()
	window.history.back
end sub

</script>