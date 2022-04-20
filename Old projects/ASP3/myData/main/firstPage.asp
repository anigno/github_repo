<!--#INCLUDE virtual="myData/_templates/_functions.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
	</HEAD>
	<body>
<table align=center>
<tr><td><h2><%=day(now())%>/<%=month(now())%>/<%=year(now())%>&nbsp&nbsp&nbsp<%=time()%></h2></td></tr>
<tr><td><h1>הודעות אחרונות בפורומים</h1></td></tr>
<tr><td><h2></h2></td></tr>
<tr><td><h1>עדכונים אחרונים בבלוגים</h1></td></tr>
<tr><td><h2></h2></td></tr>
</table>
<%if session("username")="" then%>
		<table border="1" ID="Table1">
			<tr>
				<td><A target=_parent href="/myData/login/login.asp?returnPage=/myData/main/main.asp&dataFile=/DB/users.mdb&dataTable=tblUsers">כניסה למערכת</A>
				</td>
			</tr>
			<tr>
				<td><A target=_parent href="/myData/newUser/newUser.asp?returnPage=/myData/default.asp&dataFile=/db/users.mdb&dataTable=tblUsers">רישום משתמש חדש</A>
				</td>
			</tr>
		</table>
<%end if%>
	</body>
</HTML>
<script language=vbscript>
</script>
