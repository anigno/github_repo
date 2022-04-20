<%@ Language=VBScript %>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE"></head>
<body>
<%
	Application.Lock
	Application("line01")=Application("line02")
	Application("line02")=Application("line03")
	Application("line03")=Application("line04")
	Application("line04")=Application("line05")
	Application("line05")=Application("line06")
	Application("line06")=Application("line07")
	Application("line07")=Application("line08")
	Application("line08")=Application("line09")
	Application("line09")=Application("line10")
	Application("line10")=Request.QueryString("txtName")& ": " & Request.QueryString("txtLine")
	Application.UnLock
'	response.Redirect "main01.asp"
%>

<form method="get" name="form1" id="form1" action="chat01.asp">
	<input type="text" id="txtName" name="txtName" value="<%=Request.QueryString("txtName")%>">
</form>
<script language="vbscript">
	form1.submit
</script>
</body>
</html>
