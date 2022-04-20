<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
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

<form method=get name=form1 id=form1 action=chat01.asp>
	<INPUT type="text" id=txtName name=txtName value=<%=Request.QueryString("txtName")%>>
</form>
<script language=vbscript>
	form1.submit
</script>
</BODY>
</HTML>
