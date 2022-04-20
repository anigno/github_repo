<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY dir=rtl>
<form id=form1 name=form1>
	<INPUT id=txtSubject name=txtSubject >
	<a href="#" onclick="openIconList()">icons</a>
	<div id=iconList></div>
<INPUT id=text1 name=text1 style="HEIGHT: 25px; WIDTH: 615px">
</form>

<div id=qq>_</div>
</BODY>
</HTML>


<script language=vbscript>
	sub document_onkeyup()
		qq.innerHTML=showText(form1.txtSubject.value)
	end sub
</script>





<script language=vbscript>
'script to add animate-icons to input as [xx]
'must place:
'	<a href="#" onclick="openIconList()">icons</a>
'	<div id=iconList></div>
'must change:
'	sub addIcon()
'must use:
'	function showText(iText)	will return text with real images

	'change input names
	sub addIcon(a)
		'will add [xx] to text
		if lastTextBox="txtSubject" then
			form1.txtSubject.value= _
				form1.txtSubject.value & "[" & a & "]"
			form1.txtSubject.focus
		end if
	end sub

	'generic
	dim imgList(100)
		imglist(11)="<img src=images/i_clock.jpg onClick=addIcon(11)></img>"
		imgList(12)="<img src=images/i_cake.jpg onClick=addIcon(12)></img>"
		imgList(13)="<img src=images/i_cat.jpg onClick=addIcon(13)></img>"
		imgList(14)="<img src=images/i_coffie.jpg onClick=addIcon(14)></img>" 
		imgList(15)="<img src=images/i_dog.jpg onClick=addIcon(15)></img>" 
		imgList(16)="<img src=images/i_face_confused.jpg onClick=addIcon(16)></img>" 
		imgList(17)="<img src=images/i_face_cry.jpg onClick=addIcon(17)></img>" 
		imgList(18)="<img src=images/i_face_eye.jpg onClick=addIcon(18)></img>" 
		imgList(19)="<img src=images/i_face_ha.jpg onClick=addIcon(19)></img>" 
		imgList(20)="<img src=images/i_face_mad.jpg onClick=addIcon(20)></img>" 
		imgList(21)="<img src=images/i_face_sad.jpg onClick=addIcon(21)></img>" 
		imgList(22)="<img src=images/i_face_shy.jpg onClick=addIcon(22)></img>" 
		imgList(23)="<img src=images/i_face_smile.jpg onClick=addIcon(23)></img>" 
		imgList(24)="<img src=images/i_face_tung.jpg onClick=addIcon(24)></img>" 
		imgList(25)="<img src=images/i_gift.jpg onClick=addIcon(25)></img>" 
		imgList(26)="<img src=images/i_heart_b.jpg onClick=addIcon(26)></img>" 
		imgList(27)="<img src=images/i_heart_f.jpg onClick=addIcon(27)></img>" 
		imgList(28)="<img src=images/i_kiss.jpg onClick=addIcon(28)></img>" 
		imgList(29)="<img src=images/i_lamp.jpg onClick=addIcon(29)></img>" 
		imgList(30)="<img src=images/i_phone.jpg onClick=addIcon(30)></img>" 
		imgList(31)="<img src=images/i_rose_u.jpg onClick=addIcon(31)></img>" 
		imgList(32)="<img src=images/i_rosw_d.jpg onClick=addIcon(32)></img>" 
	sub openIconList()
		'create imgList and show the list
		dim iList
		iconList.innerHTML=""
		for iList=11 to UBOUND(imgList)
			iconList.innerHTML=iconList.innerHTML & imgList(iList)
			if iList mod 10=0 and imgList(iList)<>"" then iconList.innerHTML=iconList.innerHTML & "<BR>"
		next
	end sub

	'generic
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
				iText2=iText2 & MID(iText,a,1)
				a=a+1
			end if
		wend
	showText=iText2
	end function

	'generic
	dim lastTextBox
	sub document_onClick()
		'set the last input to add icons later
		if window.event.srcElement.tagName="INPUT" then 
			lastTextBox=window.event.srcElement.id
		end if
	end sub
</script>