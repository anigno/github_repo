<!--#INCLUDE virtual="pinukitaf/functions.asp" -->
<HTML >
	<HEAD>
		<title>myData</title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body>

<%
'create upload object
Set Upload = Server.CreateObject("Persits.Upload")
'create save path (path must be valid!)
savePath=server.MapPath("\") & uploadPath
'upload file(s)
'Response.Write savePath
'Response.End
count=Upload.Save(savePath)
'write message
Response.Write Count & " file(s) uploaded to " & savepath & "<BR>"
'write files names
For Each Item in Upload.Files
	response.Write Item.fileName & "<BR>"
Next
'write all other form data items and values
'For Each Item in Upload.Form
'Response.Write Item.Name & "= " & Item.Value & "<BR>"
'Next

'get fields data
For Each Item in Upload.Files
	pictureName=Item.fileName
Next
key=Request.QueryString("key")

'clear object
set upload=nothing

'update tblPictures
conn=openDb(mdbFile)
set rs=getRs()
sql="insert into tblPictures (iSubject,iName,iFile) values ("
sql=sql & key & ","
sql=sql & "'" & pictureName & "',"
sql=sql & "'" & pictureName & "')"
rs.open sql,conn
set conn=nothing
set rs=nothing
	
Response.Redirect "pictures.asp?key=" & key
%>
</body>
</HTML>
