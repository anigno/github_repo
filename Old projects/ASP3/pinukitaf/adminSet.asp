<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
Session("administrator")=Request.Form("Text1")
session.Timeout=30
if checkAdmin()=false then Response.Redirect "admin.asp"
Response.Redirect "adminStart.asp"
%>