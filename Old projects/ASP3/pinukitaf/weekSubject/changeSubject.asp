<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%runAdmin()%>

<%
conn=openDb(generalFile)
set rs=getRs()
sql="update tblGeneral set iData='" & Request.Form("Text1") & "'"
sql=sql & " where iName='weekSubject'"
rs.open sql,conn

set conn=nothing
set rs=nothing
Response.Redirect "../adminStart.asp"
%>
<html>
<body>
שינוי בוצע בהצלחה
</body>
</html>