<%@ Language=VBScript Codepage=1255 %>

<%
mdbFile="pictureBrowser.mdb"	'picture browser file
addFile="addBoard.mdb"			'add board file
generalFile="general.mdb"		'general data file
dbPath="\db\"
picturesPath=dbPath & "pictures\"
uploadPath=dbPath & "pictures\uploads\"

'open DB and return the connection
'input:
'output: return connection
function openDb(s)
	dim mdbFile,conn
	mdbFile=dbPath + s	'all mdb files are in root\DB folder
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

'get hex value of number
'input: dec number (0-16777215)
'output: hex number (000000-ffffff)
function getHex(dec)
	dim a,b,c,d,e,f,hexs
	hexs="0123456789abcdef"
	a=int(dec/16^5):dec=dec-a*16^5
	b=int(dec/16^4):dec=dec-b*16^4
	c=int(dec/16^3):dec=dec-c*16^3
	d=int(dec/16^2):dec=dec-d*16^2
	e=int(dec/16^1):dec=dec-e*16^1
	f=int(dec/16^0):dec=dec-f*16^0
	a=MID(hexs,a+1,1)
	b=MID(hexs,b+1,1)
	c=MID(hexs,c+1,1)
	d=MID(hexs,d+1,1)
	e=MID(hexs,e+1,1)
	f=MID(hexs,f+1,1)
	getHex=a & b & c & d & e & f
end function

'return option for month (selected is equal to b)
function placeMonth(b)
	s=""
	for a=1 to 12
		if a=b then
			s=s & "<OPTION selected value=" & a & ">" & a & "</OPTION>"
		else
			s=s & "<OPTION value=" & a & ">" & a & "</OPTION>"
		end if		
	next
	placeMonth=s
end function

'return options for days (selected is equal to b)
function placeDays(b)
	s=""
	for a=1 to 31
		if a=b then
			s=s & "<OPTION selected value=" & a & ">" & a & "</OPTION>"
		else
			s=s & "<OPTION value=" & a & ">" & a & "</OPTION>"
		end if		
	next
	placeDays=s
end function

'return options for year (selected is equal to b)
function placeYears(b)
	for a=2004 to 2014
		if a=b then
			s=s & "<OPTION selected value=" & a & ">" & a & "</OPTION>"
		else
			s=s & "<OPTION value=" & a & ">" & a & "</OPTION>"
		end if		
	next
	placeYears=s
end function

'return string for y,m,d (date)
function getDateString(y,m,d)
	s=""
	s=s & y
	m=m+10
	d=d+10
	s=s & m & d
	getDateString=s
end function

'get day from date string
function getDay(s)
	a=right(s,2)
	b=a+0
	b=b-10
	getDay="" & b
end function

'get month from date string
function getMonth(s)
	a=mid(s,5,2)
	b=a+0
	b=b-10
	getMonth="" & b
end function

'get year from date string
function getYear(s)
	a=mid(s,1,4)
	b=a+0
	getYear="" & b
end function

'return print-like date from date string
function getDate(s)
	getDate=getDay(s) & "/" & getMonth(s) & "/" & getYear(s)
end function

function getFileNameU()
	getFileNameU="file" & year(now()) & (month(now())+10) & (day(now())+10) & (hour(now())+10) & (minute(now())+10) & (second(now())+10)
end function

adminCode="8702661"
function checkAdmin()
	checkAdmin=false
	if Session("administrator")=adminCode then checkAdmin=true
end function

sub runAdmin()
	if checkAdmin()=false then Response.End
end sub


%>
<script language="vbscript">
	txtAll=" abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_אבגדהוזחטיכלמנסעפצקרשתףךץןם"
	txtOnlyNumbers="0123456789"
	'check if txt include chars from txtAllow only
	'input: txt as string,txtAllow as string
	'output: 0 not OK, 1 OK
	function checkText(txt,txtAllow)
		dim txtOK
		txtOK=true
		for a=1 to len(txt)
			if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=false
		next
		checkText=txtOK
	end function

	function checkDate(y,m,d)
		dim l(12)
		l(1)=31:		l(2)=28:		l(3)=31:		l(4)=30
		l(5)=31:		l(6)=30:		l(7)=31:		l(8)=31
		l(9)=30:		l(10)=31:		l(11)=30:		l(12)=31
		if y mod 4 =0 then l(2)=29
		if y mod 100=0 then l(2)=28
		checkDate=true
		if d+0>l(m)+0 then checkDate=false
	end function
</script>

