<%@ Language=VBScript %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<title>redirector</title>
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0">
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name=ProgId content=VisualStudio.HTML>
<meta name=Originator content="Microsoft Visual Studio .NET 7.1">
<meta http-equiv="refresh" content="20"> 
</head>
<body MS_POSITIONING="FlowLayout">
<%
	tLocal_addr=Request.ServerVariables("LOCAL_ADDR") 
	tRemote_addr=Request.ServerVariables("REMOTE_ADDR") 
	tRemote_host=Request.ServerVariables("REMOTE_HOST") 
	key=Request.QueryString("key")
	if key=1 then 
		Response.Write Date() & " " & Time() & "<BR>"
		Response.Write "tLocal_addr: " & tLocal_addr & "<br>"
		Response.Write "tRemote_addr: " & tRemote_addr & "<br>"
		Response.Write "tRemote_host: " & tRemote_host & "<br>"
		Application("addr")=tRemote_addr
		Response.Write("address set: " & tRemote_addr & "<br>")
	else
		s="http://" & Application("addr") & "/index.html"
		Response.Redirect s
	end if
		
%>


</body>
</html>
