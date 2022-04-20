<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<%
	username=Request.QueryString("username")
%>
<frameset cols=270,*>
<frame name=frameMain src=main.asp?username=<%=username%> scrolling=no>
<frame name=frameData>
</frameset>
</HEAD>
</HTML>
