<%@ Language=VBScript Codepage=1255 %>
<%
'login user in database
'input: QueryString("returnPage"),QueryString("dataFile"),
'	QueryString("dataTable")
'write username value in session("username") if login ok
'navigate to returnPage
'(must enter all path from root)
'example:"/myData/newUser/newUser.asp?returnPage=/myData/addressBook/default.asp&dataFile=/myData/addressBook/addressBook.mdb&dataTable=tblUsernames"
%>
<HTML dir="rtl">
	<HEAD>
		<title>login</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
		<link rel="stylesheet" type="text/css" href="../css/style01.css" />
	</HEAD>
	<body>
		<%
	'getting data from calling page
	returnPage=Request.QueryString("returnPage")
	dataFile=Request.QueryString("dataFile")
	dataTable=Request.QueryString("dataTable")
%>
		<form id="formLogin" method="post">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="1">
				<TR>
					<TD>כניסה למערכת:</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>שם משתמש:</TD>
					<TD>
						<INPUT id="txtUsername" type="text" name="txtUsername"></TD>
				</TR>
				<TR>
					<TD>סיסמה:</TD>
					<TD>
						<INPUT id="txtPassword" type="password" name="txtPassword"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<INPUT id="btnOk" type="button" value="כניסה" name="btnOk"></TD>
					<TD>
						<INPUT id="btnCancel" type="button" value="ביטול" name="btnCancel"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
<script language="vbscript">
	private sub btnOk_onClick()
		'validate form
		dim formError
		formError=0
		if checkText(formLogin.txtUsername.value)=0 then formError=1
		if checkText(formLogin.txtPassword.value)=0 then formError=1
		if formError=1 then MsgBox "Error in username or password (alpha or numbers permited)",vbCritical

		'create form action string
		returnPage="<%=returnPage%>"
		dataFile="<%=dataFile%>"
		dataTable="<%=dataTable%>"
	
		formLogin.action="login01.asp?returnPage=" & returnPage & _
			"&dataFile=" & dataFile & _
			"&dataTable=" & dataTable
		if formerror=0 then formLogin.submit()
	end sub
	private sub btnCancel_onClick()
		window.history.back()
	end sub
</script>
<script language="vbscript">

'check txt for containing only txtAllow chars
'input: txt as string
'output: 0 not OK, 1 OK
function checkText(txt)
	txtAllow="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_אבגדהוזחטיכלמנסעפצקרשתףךץןם"
	dim txtOK
	txtOK=1
	for a=1 to len(txt)
		if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=0
	next
	checkText=txtOK
end function
</script>
