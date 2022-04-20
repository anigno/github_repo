<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
name=Request.Form("Text2")
text=Request.Form("Text3")
theDay=Request.Form("select3")
theMonth=Request.Form("select2")
theYear=Request.Form("select1")
key=Request.QueryString("key")
sql="UPDATE tblSubjects SET "
sql=sql & "iName='" & name & "',"
sql=sql & "iText='" & text & "',"
sql=sql & "iDate='" & getDateString(theYear,theMonth,theDay) & "' "
sql=sql & "WHERE iKey=" & key


conn=openDb(mdbFile)
set rs=getRs()
'Response.Write sql
rs.open sql,conn
%>

<%
set rs=nothing
set con=nothing
Response.Redirect "subjects.asp"
%>
