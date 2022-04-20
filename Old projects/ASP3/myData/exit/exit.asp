<%@ Language=VBScript %>
<%
'clear session("username") and go to return page
%>
<HTML dir=rtl>
	<HEAD>
		<title>exit</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body >
<%
	'getting data from calling page
	returnPage=Request.QueryString("returnPage")
	Session("username")=""
	Response.Redirect returnPage
%>	
	</body>
</HTML>

