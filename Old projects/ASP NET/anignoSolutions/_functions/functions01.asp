<%@ Language=VBScript Codepage=1255 %>

<%
	'check for userId exist, else create one
	if Session("userId")="" then Session("userId")=Session.SessionID
%>

<%
	'Vars used in all pages
	'--------------------------
	'colors and images
	showBasket=true
	storeNameHeb="פתרונות המחשוב של אניגנו"
	aboutImage="aboutImage.jpg"
	catalogImage01="catalogImage01.jpg"
	catalogImage02="catalogImage02.jpg"
	backgroundImage="backgroundImage.jpg"
	tableBackgroundImage="tableBackgroundImage.jpg"
	firstPageImage="firstPageImage.jpg"
	storeLogo="anignoLogo.jpg"
	mainHeaderWithText="mainHeaderWithText.jpg"
	email="anigno@softhome.net"
	bgcolor="#993300"
	text="#330066"
	link="#ccffff"
	alink="#CCFF33"
	vlink="#ccffff"
%>

<%
'open DB and return the connection
'input:
'output: return connection
function openDb()
	dim mdbFile,conn
	mdbFile="\anignoSolutions\anignoSolutions.mdb"
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

'change chr(13) to <BR>
'input: string
'output: return fixed string
function fixBR(s)
	for a=1 to len(s)
		c=mid(s,a,1)
		if c=chr(13) then
			s2=s2 & "<br>"
		else
			s2=s2 & c
		end if
	next
	fixBR=s2
end function

function getText(iSubject)
	dim conn,rs
	conn=openDB()
	set rs=getRs()
	sql="select * from tblText where iSubject='" & iSubject & "'"
	rs.open sql,conn
	if not rs.eof then gettext=rs("iText")
	rs.close
end function
%>
<script language="vbscript">
	txtAll="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_אבגדהוזחטיכלמנסעפצקרשתףךץןם"
	txtOnlyNumbers="0123456789"
	'check if txt include chars from txtAllow only
	'input: txt as string,txtAllow as string
	'output: 0 not OK, 1 OK
	function checkText(txt,txtAllow)
		dim txtOK
		txtOK=1
		for a=1 to len(txt)
			if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=0
		next
		checkText=txtOK
	end function
</script>

