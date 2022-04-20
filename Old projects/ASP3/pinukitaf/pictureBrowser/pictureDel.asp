<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<%
sKey=Request.QueryString("sKey")
key=Request.QueryString("key")
conn=openDb(mdbFile)
set rs=getRs()
sql="delete from tblPictures where iKey=" & key
rs.open sql,conn

set conn=nothing
set rs=nothing

Response.Redirect "pictures.asp?key=" & sKey
%>