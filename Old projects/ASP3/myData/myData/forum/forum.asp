<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
			<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
	<body>
		<table border="1" align="center" width="600" ID="Table1">
			<tr><td align=center>רשימת הפורומים</td></tr>
<%for a=0 to UBound(forumSubject)%>
			<tr><td><a href=forumShow.asp?forumNumber=<%=a%>><%=forumSubject(a)%></a></td></tr>
<%next%>
		</table>
	</body>
</HTML>
