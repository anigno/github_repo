<%@ Language=VBScript %>
<!--#INCLUDE FILE="functions.asp" -->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	iSubject=Request.Form("txtSubject")
	iMessage=Request.Form("txtMessage")
	iKey=Request.QueryString("key")
	iForumId=Request.QueryString("forumId")
	
	Response.Write isubject & "<BR>"  & "<BR>"
	Response.Write imessage & "<BR>"  & "<BR>"
	Response.Write iKey & " :message key<BR>"
	Response.Write iForumId & " :forumId<BR>"
%>
<%
	dim conn,SQL,RS
	conn=openDb()
	set RS=getRs()
	sql="UPDATE forumData SET " _
	& "txtSubject='" & iSubject & "'," _
	& "txtMessage='" & iMessage & "' " _
	& "where key=" & iKey
	'Response.Write sql
	rs.open sql,conn
	Response.Redirect "forumShow.asp?forumId=" & iForumId
%>

</BODY>
</HTML>
