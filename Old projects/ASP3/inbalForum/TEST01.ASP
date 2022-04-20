<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<INPUT type="text" id=text1 name=text1>
<INPUT type="text" id=text2 name=text2>
<TEXTAREA rows=2 cols=20 id=textarea1 name=textarea1>
</TEXTAREA>

</BODY>
</HTML>
<script language=vbscript>
'script to check for database and sql text problem
sub document_onkeyup()
	textarea1.value=checkText(textarea1.value)
end sub
function checkText(iText)
	dim a,iText2
	textOk="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" _
		& " !@#$%^&*()_-=+\|{}.,?אבגדהוזחטיכלמנסעפצקרשתףץםן"
	for a=1 to len(iText)
		if instr(1,textOk,MID(iText,a,1))<>0 then
			itext2=iText2 & MID(iText,a,1)
		end if
	next
	checkText=iText2
end function

</script>