<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
conn=openDb(addFile)
set rs=getRs()
d=day(date())
m=month(date())
y=year(date())
theDate=getDateString(y,m,d)
theMessage=Request.Form("Text1")
sql="insert into tblMessages (iDate,iText) values ("
sql=sql & "'" & theDate & "',"
sql=sql & "'" & theMessage & "')"
rs.open sql,conn

set rs=nothing
set conn=nothing
Response.Redirect "main.asp"
%>