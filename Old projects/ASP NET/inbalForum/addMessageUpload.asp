<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	session("inbal_subject")=Request.Form("txtSubject")
	session("inbal_message")=Request.Form("txtMessage")
	Response.Write session("inbal_subject") & "<BR>"
	Response.Write session("inbal_message") & "<BR>"
%>
<%
Response.Redirect "http://www24.brinkster.com/inbalforum/filepost.htm"
'Response.Redirect "http://lala/inbalForum/filePost.htm"
%>
	
</BODY>
</HTML>
