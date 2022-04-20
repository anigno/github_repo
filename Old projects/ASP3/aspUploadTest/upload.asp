<html>
<head>
<title></title>
</head>
<body>
<%
'create upload object
Set Upload = Server.CreateObject("Persits.Upload")
'create save path (path must be valid!)
'savePath=server.MapPath("/") & "\aspUploadTest\uploads"
savePath=server.MapPath("\") & picturesPath
'upload file(s)
count=Upload.Save(savePath)
'write message
Response.Write Count & " file(s) uploaded to " & savepath & "<BR>"
'write files names
For Each Item in Upload.Files
Response.Write Item.fileName & "<BR>"
Next
'write all other form data items and values
For Each Item in Upload.Form
Response.Write Item.Name & "= " & Item.Value & "<BR>"
Next
'clear object
set upload=nothing
%>
</body>
</html>
