<%@ Language=VBScript Codepage=1255 %>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<script language=vbscript>
'script to check for database and sql text problem
'input: iText,iSet=:1=all legal chars,2=english letters only ,3=only numbers, 4=phone
'output: return fixed text without illigle chars
function checkText(iText,iSet)
	dim a,iText2,textOk(4)
	textOk(1)="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" _
		& " !@#$%^&*()_-=+\|{}.,????????????????????????????[]" & chr(13)
	textOk(2)="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
	textOk(3)="01234567890"
	textOk(4)="0123456789-_ "
	for a=1 to len(iText)
		if instr(1,textOk(iSet),MID(iText,a,1))<>0 then
			itext2=iText2 & MID(iText,a,1)
		end if
	next
	if iSet=2 then iText2=ucase(iText2)
	checkText=iText2
end function
</script>

<%
'open DB and return the connection
'input:
'output: return connection
function openDb()
	dim mdbFile,conn
	mdbFile="productCatalog01.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	openDb=conn
end function

'open a new recordSet
'input:
'output: return recordSet (must be set XX=getRs on caller)
function getRs()
		set getRs=Server.Createobject("ADODB.RecordSet")
end function

%>