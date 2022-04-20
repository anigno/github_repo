Module main
    Public Sub main()
        'open the main program window
        Dim theMainForm As New frmMain()
        theMainForm.frmMain_LoadForm()
        theMainForm.ShowDialog()
    End Sub


    'vars
    Public currentFile As String
    Public remoteHost As String
    Public remoteUsername As String
    Public remotePassword As String
    Public telnetProgram As String
    Public telnetId As Integer

End Module
