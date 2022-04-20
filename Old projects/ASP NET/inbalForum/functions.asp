<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<script language=vbscript>
'script to check for database and sql text problem
'input: iText
'output: return fixed text without illigle chars
function checkText(iText)
	dim a,iText2
	textOk="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" _
		& " !@#$%^&*()_-=+\|{}.,?אבגדהוזחטיכלמנסעפצקרשתףץםןך[]" & chr(13)
	for a=1 to len(iText)
		if instr(1,textOk,MID(iText,a,1))<>0 then
			itext2=iText2 & MID(iText,a,1)
		end if
	next
	checkText=iText2
end function

dim maxImage
dim imgList(100)
'user must write sub addIcon() with the inputs of the form
imglist(11)="<img border=0 src=images/i_clock.jpg onClick=addIcon(11)></img>"
imgList(12)="<img  border=0 src=images/i_cake.jpg onClick=addIcon(12)></img>"
imgList(13)="<img  border=0 src=images/i_cat.jpg onClick=addIcon(13)></img>"
imgList(14)="<img  border=0 src=images/i_coffie.jpg onClick=addIcon(14)></img>" 
imgList(15)="<img  border=0 src=images/i_dog.jpg onClick=addIcon(15)></img>" 
imgList(16)="<img  border=0 src=images/i_face_confused.jpg onClick=addIcon(16)></img>" 
imgList(17)="<img  border=0 src=images/i_face_cry.jpg onClick=addIcon(17)></img>" 
imgList(18)="<img  border=0 src=images/i_face_eye.jpg onClick=addIcon(18)></img>" 
imgList(19)="<img  border=0 src=images/i_face_ha.jpg onClick=addIcon(19)></img>" 
imgList(20)="<img  border=0 src=images/i_face_mad.jpg onClick=addIcon(20)></img>" 
imgList(21)="<img  border=0 src=images/i_face_sad.jpg onClick=addIcon(21)></img>" 
imgList(22)="<img  border=0 src=images/i_face_shy.jpg onClick=addIcon(22)></img>" 
imgList(23)="<img  border=0 src=images/i_face_smile.jpg onClick=addIcon(23)></img>" 
imgList(24)="<img  border=0 src=images/i_face_tung.jpg onClick=addIcon(24)></img>" 
imgList(25)="<img  border=0 src=images/i_gift.jpg onClick=addIcon(25)></img>" 
imgList(26)="<img  border=0 src=images/i_heart_b.jpg onClick=addIcon(26)></img>" 
imgList(27)="<img  border=0 src=images/i_heart_f.jpg onClick=addIcon(27)></img>" 
imgList(28)="<img  border=0 src=images/i_kiss.jpg onClick=addIcon(28)></img>" 
imgList(29)="<img  border=0 src=images/i_lamp.jpg onClick=addIcon(29)></img>" 
imgList(30)="<img  border=0 src=images/i_phone.jpg onClick=addIcon(30)></img>" 
imgList(31)="<img  border=0 src=images/i_rose_u.jpg onClick=addIcon(31)></img>" 
imgList(32)="<img  border=0 src=images/i_rosw_d.jpg onClick=addIcon(32)></img>" 

imgList(33)="<img  border=0 src=images/i_brendy.jpg onClick=addIcon(33)></img>" 
imgList(34)="<img  border=0 src=images/i_deamon.jpg onClick=addIcon(34)></img>" 
imgList(35)="<img  border=0 src=images/i_face_drank.jpg onClick=addIcon(35)></img>" 
imgList(36)="<img  border=0 src=images/i_hangcoft.jpg onClick=addIcon(36)></img>" 
imgList(37)="<img  border=0 src=images/i_hug.jpg onClick=addIcon(37)></img>" 
imgList(38)="<img  border=0 src=images/i_hug2.jpg onClick=addIcon(38)></img>" 
imgList(39)="<img  border=0 src=images/i_moon.jpg onClick=addIcon(39)></img>" 
imgList(40)="<img  border=0 src=images/i_right.jpg onClick=addIcon(40)></img>" 
imgList(41)="<img  border=0 src=images/i_sound.jpg onClick=addIcon(41)></img>" 
imgList(42)="<img  border=0 src=images/i_sun.jpg onClick=addIcon(42)></img>" 
imgList(43)="<img  border=0 src=images/i_wrong.jpg onClick=addIcon(43)></img>" 
maxImage=43

'translate iText to string contains images
function showText(iText)
	'merge text and icons
	dim a,b,c,iText2
	iText2=""
	a=1
	while a<=len(iText)
		if MID(iText,a,1)="[" and MID(iText,a+3,1)="]" then
			b=""
			c=MID(iText,a+1,2)
			iText2=iText2 & imgList(c)
			a=a+4
		else
			if MID(iText,a,1)=chr(13) then
				itext2=itext2 & "<BR>"
			else
				iText2=iText2 & MID(iText,a,1)
			end if
			a=a+1
		end if
	wend
showText=iText2
end function
</script>

<%
'open DB and return the connection
'input:
'output: return connection
function openDb()
	dim mdbFile,conn
	mdbFile="\db\inbalforum.mdb"
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

'place space(dots or anything) mul by i
'input: number of spaces and space string
function placeSpace(i,s)
	dim a
	for a=1 to i
		placeSpace=placeSpace & S
	next
end function

%>