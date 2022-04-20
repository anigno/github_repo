<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
			<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
	<body>
		<table border="1" align="center" width="180" ID="Table1">
			<tr>
				<td align="middle">
				<A href="addText.asp?key=-1" target="frameData">הוספה</A>
				</td>
			</tr>
		</table>
		<br>
		<table border="1" align="center" width="180" ID="Table2">
			<tr>
				<td align="middle"><a href=data.asp?show=-1 target=frameData>הצג הכל</a></td>
			</tr>
<%for a=0 to ubound(textSubject)%>
	<tr><td></td></tr>
			<tr><td align="middle"><a href=data.asp?show=<%=a%> target=frameData><%=textSubject(a)%></a></td></tr>
<%next%>
		</table>
	</body>
</HTML>
