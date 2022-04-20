<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
name=Request.Form("Text2")
text=Request.Form("Text3")
theDay=Request.Form("select3")
theMonth=Request.Form("select2")
theYear=Request.Form("select1")
conn=openDb(mdbFile)
set rs=getRs()
sql="insert into tblSubjects (iName,iText,iDate) values ("
sql=sql & "'" & name & "',"
sql=sql & "'" & text & "',"
sql=sql & "'" & getDateString(theYear,theMonth,theDay) & "')"
'Response.Write sql
rs.open sql,conn
%>

<%
'rs.close
set rs=nothing
set con=nothing
Response.Redirect "subjects.asp"
%>
