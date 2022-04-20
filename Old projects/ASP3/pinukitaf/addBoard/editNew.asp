<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
newMessage=Request.QueryString("new")
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
<td><a href="vbscript:window.history.back">חזרה</a></td></td>
</tr>
</table>

<form id=form1 method=post action=addNew.asp>
<table align=center width=600 ID="Table2" border=1>
<tr>
<td colspan=2 align=center><font size=6>הוספת הודעה חדשה</font></td>
</tr>
<tr>
<td><%=date()%></td>
<td><INPUT type="text" ID="Text1" NAME="Text1" size=60></td>
</tr>
<tr>
<td></td><td>
<INPUT type="button" value="הוסף" ID="Button1" NAME="Button1" onclick=buttonOk()>&nbsp&nbsp&nbsp
<INPUT type="button" value="ביטול" ID="Button2" NAME="Button2" onclick="vbscript:window.history.back">
</td>
</tr>

</table>
</form>
</body>
</html>

<script language=vbscript>
sub buttonOk()
	formok=true
	if checkText(form1.Text1.value,txtAll)=false then formok=false
	if form1.Text1.value="" then formok=false
	if formok=true then
		form1.submit
	else
	MsgBox "בעיה בטופס!",vbOKOnly
	end if
end sub

</script>