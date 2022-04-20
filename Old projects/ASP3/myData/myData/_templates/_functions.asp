<%@ Language=VBScript Codepage=1255 %>

<%
	'bloger subjects
	dim textSubject(6)
	textSubject(0)="�������"
	textSubject(1)="����"
	textSubject(2)="�������"
	textSubject(3)="������"
	textSubject(4)="����"
	textSubject(5)="�� �����"
	textSubject(6)="���� ����"
%>

<%
	'forum subjects
	dim forumSubject(3)
	forumSubject(0)="�� ����� ���� ������ ���� ����"
	forumSubject(1)="���������, �� �� ����� ��� �� ������ ��"
	forumSubject(2)="�����, �� ���� ��� ������ �� ��, ��� ������ �� ��"
	forumSubject(3)="��������, �� ��� ���, �� ��� �� ��� ��� ���� ����"
%>

<%
	sub RW(s)
		Response.Write s
	end sub
	
	sub RWln(s)
		RW(s) & "<br>"
	end sub
%>

<%
'open DB and return the connection
'input:
'output: return connection
function openDb(dbFile)
	dim mdbFile,conn
	mdbFile="\db\" & dbFile
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	openDb=conn
end function
%>

<%
'open a new recordSet
'input:
'output: return recordSet (must be set XX=getRs on caller)
function getRs()
		set getRs=Server.Createobject("ADODB.RecordSet")
end function
%>

<%
'change chr(13) to <BR>
'input: string
'output: return fixed string
function fixBR(s)
	dim a,c,s2
	for a=1 to len(s)
		c=mid(s,a,1)
		if c=chr(13) then
			s2=s2 & "<br>"
			a=a+1
		else
			s2=s2 & c
		end if
	next
	fixBR=s2
end function
%>

<%
	'fix illigle chars
	'input: string
	'output: return string without ' (DB fix)
	function fixText(txt)
		for a=1 to len(txt)
			c=mid(txt,a,1)
			if c="'" then
				fixText=fixText & "^"
			else
				fixText=fixText & c
			end if
		next
	end function
%>

<script language="vbscript">
	'check if txt include chars from txtAllow only
	'input: txt as string,txtAllow as string
	'output: 0 not OK, 1 OK
	txtAll="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-_���������������������������"
	txtOnlyNumbers="0123456789"
	function checkText(txt,txtAllow)
		dim txtOK
		txtOK=1
		for a=1 to len(txt)
			if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=0
		next
		checkText=txtOK
	end function

</script>

