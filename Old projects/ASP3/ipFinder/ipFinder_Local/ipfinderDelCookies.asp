<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<%
	Response.Cookies("ipFinder_username").expires=now()+100
	Response.Cookies("ipFinder_username")=""
	Response.Redirect "ipfinder.asp"
%>
</BODY>
</HTML>
