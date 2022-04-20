<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF=../Styles.css>
	<title>Page title</title>
</head>
<body>
<form id=form1 method=post action=changeSubject.asp>
<table align=center width=600 ID="Table1" border=1>
<tr><td><font size=6>שינוי נושא השבוע</font></td></tr>
<tr><td><INPUT type="text" ID="Text1" NAME="Text1"></td></tr>
<tr><td>
<INPUT type="button" value="שנה" ID="Button1" NAME="Button1" onclick=buttonOk()>&nbsp&nbsp&nbsp
<INPUT type="button" value="בטל" ID="Button2" NAME="Button2" onclick="vbscript:window.history.back">
</td></tr>
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