<%@ Language=VBScript Codepage=1255 %>
<HTML dir="rtl">
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
</HEAD>
	<body>
		<P>פנקס כתובות:</P>
		<%=session("username")%>
		<P><A href="/myData/login/login.asp?returnPage=/myData/addressBook/show.asp&dataFile=/DB/addressBook.mdb&dataTable=tblUsernames">כניסה</A></P>
		<P><A href="/myData/newUser/newUser.asp?returnPage=/myData/addressBook/default.asp&dataFile=/db/addressBook.mdb&dataTable=tblUsernames">רישום 
				משתמש חדש</A></P>
		<P>&nbsp;</P>
	</body>
</HTML>
