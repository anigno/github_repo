Option Strict Off
Option Explicit On
Module mdlMainFunctions
	
	Public Sub setCurrentFile(ByRef Form1 As System.Windows.Forms.Form, ByRef iFilename As String)
		Form1.Text = "Remote gcc - " & iFilename
		currentFile = iFilename
	End Sub
	
	Public Sub saveFile(ByRef iFile As Microsoft.VisualBasic.Compatibility.VB6.FileListBox, ByRef RTF As AxRichTextLib.AxRichTextBox, ByRef iFilename As String)
		If iFilename <> "no file" Then
			RTF.saveFile(iFile.Path & "\" & iFilename, 1)
			If iFilename <> "\_temp" Then frmMain.DefInstance.lstAction.Items.Insert(0, iFilename & " saved")
		End If
	End Sub
	
	Public Sub replaceFiles(ByRef iFile As Microsoft.VisualBasic.Compatibility.VB6.FileListBox, ByRef RTF As AxRichTextLib.AxRichTextBox, ByRef oldFile As String, ByRef newFile As String)
		saveFile(iFile, RTF, oldFile)
		RTF.LoadFile(iFile.Path & "\" & newFile, 1)
		setCurrentFile(frmMain.DefInstance, newFile)
	End Sub
	
	Public Sub createNewFile(ByRef Form1 As System.Windows.Forms.Form, ByRef iFile As Microsoft.VisualBasic.Compatibility.VB6.FileListBox, ByRef RTF As AxRichTextLib.AxRichTextBox)
		On Error GoTo error_creatingNewFile
		Dim newFile As String
		saveFile(iFile, RTF, currentFile)
		newFile = InputBox("Enter new file name")
		RTF.Text = ""
		saveFile(iFile, RTF, newFile)
		setCurrentFile(Form1, newFile)
		iFile.Refresh()
		Exit Sub
error_creatingNewFile: 
		MsgBox("Error creating new file!", MsgBoxStyle.Critical)
		If currentFile <> "no file" Then
			RTF.LoadFile(iFile.Path & "\" & currentFile, 1)
		End If
	End Sub
	
	Public Sub sendFiles(ByRef iFile As Microsoft.VisualBasic.Compatibility.VB6.FileListBox, ByRef FTP As AxEZFTPLib.AxEZFTP, ByRef list1 As System.Windows.Forms.ListBox, ByRef RTF1 As AxRichTextLib.AxRichTextBox, ByRef RTF2 As AxRichTextLib.AxRichTextBox)
		On Error GoTo errorSendfiles
		Dim a As Short
		Dim filename, S As String
		saveFile(iFile, RTF1, currentFile)
		For a = 0 To iFile.Items.Count - 1
			filename = iFile.Items(a)
			RTF2.LoadFile(iFile.Path & "\" & filename)
			RTF2.Text = removeChar13((RTF2.Text))
			saveFile(iFile, RTF2, "\_temp")
			FTP.LocalFile = iFile.Path & "\_temp"
			FTP.RemoteFile = iFile.Items(a)
			FTP.PutFile()
			If list1.Items.Count > 30000 Then list1.Items.Clear()
			list1.Items.Insert(0, FTP.RemoteFile & " loaded")
			System.Windows.Forms.Application.DoEvents()
		Next a
		list1.Items.Insert(0, "-send files end -")
		Exit Sub
errorSendfiles: 
		MsgBox("error, no FTP, restart program or open ftp.", MsgBoxStyle.Critical)
	End Sub
	
	Public Function removeChar13(ByRef s1 As String) As String
		Dim b As Short
		Dim s2 As String
		For b = 1 To Len(s1)
			If Asc(Mid(s1, b, 1)) <> 13 Then
				s2 = s2 & Mid(s1, b, 1)
			End If
		Next b
		removeChar13 = s2
	End Function
	
	Public Sub addToString(ByRef sInto As String, ByRef sWhat As String, ByRef iWhere As Short)
		
	End Sub
End Module