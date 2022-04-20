<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<html dir=rtl>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
	<LINK REL="stylesheet" TYPE="text/css" HREF="styles.css">
	<title>Page title</title>
</head>
<body>
<form id=form1 method=post action=adminSet.asp>
<table align=center width=600 ID="Table1">
<tr><td><INPUT type=password ID="Text1" NAME="Text1"></td></tr>
<tr><td><INPUT type="button" value="כניסה" ID="Button1" NAME="Button1" onclick=buttonOk()></td></tr>
</table>
</form>
</body>
</html>
<script language=vbscript>
	sub buttonOk()
		form1.submit
	end sub
</script>