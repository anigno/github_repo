Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents FileListBox1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetProjectLocalLocation As System.Windows.Forms.MenuItem
    Friend WithEvents menuAddNewFile As System.Windows.Forms.MenuItem
    Friend WithEvents menuAddExistingFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSaveCurrentFile As System.Windows.Forms.MenuItem
    Friend WithEvents rtfMain As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfTemp As System.Windows.Forms.RichTextBox
    Friend WithEvents lblLocalPath As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lstAction As System.Windows.Forms.ListBox
    Friend WithEvents menuEditCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MenuEditPast As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditCut As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetProjectRemoteParm As System.Windows.Forms.MenuItem
    Friend WithEvents FTP As AxEZFTPLib.AxEZFTP
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdEditRun As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOpenFtp As System.Windows.Forms.Button
    Friend WithEvents btnOpenTelnet As System.Windows.Forms.Button
    Friend WithEvents lstRunCommands As System.Windows.Forms.ListBox
    Friend WithEvents chkFTP As System.Windows.Forms.CheckBox
    Friend WithEvents menuRun As System.Windows.Forms.MenuItem
    Friend WithEvents menuViwTelnetWindow As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents menuDelFile As System.Windows.Forms.MenuItem
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents menuRefreshFiles As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.FileListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox()
        Me.rtfMain = New System.Windows.Forms.RichTextBox()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.menuAddNewFile = New System.Windows.Forms.MenuItem()
        Me.menuAddExistingFile = New System.Windows.Forms.MenuItem()
        Me.MenuSaveCurrentFile = New System.Windows.Forms.MenuItem()
        Me.menuDelFile = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.menuEditCopy = New System.Windows.Forms.MenuItem()
        Me.MenuEditPast = New System.Windows.Forms.MenuItem()
        Me.menuEditCut = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.menuViwTelnetWindow = New System.Windows.Forms.MenuItem()
        Me.menuRefreshFiles = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.menuSetProjectLocalLocation = New System.Windows.Forms.MenuItem()
        Me.menuSetProjectRemoteParm = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.menuRun = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.rtfTemp = New System.Windows.Forms.RichTextBox()
        Me.lblLocalPath = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lstAction = New System.Windows.Forms.ListBox()
        Me.FTP = New AxEZFTPLib.AxEZFTP()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.cmdEditRun = New System.Windows.Forms.Button()
        Me.btnOpenFtp = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOpenTelnet = New System.Windows.Forms.Button()
        Me.lstRunCommands = New System.Windows.Forms.ListBox()
        Me.chkFTP = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLine = New System.Windows.Forms.Label()
        CType(Me.FTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileListBox1
        '
        Me.FileListBox1.HorizontalScrollbar = True
        Me.FileListBox1.Location = New System.Drawing.Point(0, 16)
        Me.FileListBox1.Name = "FileListBox1"
        Me.FileListBox1.Pattern = "*.c;*.cpp;*.txt;*.h;*."
        Me.FileListBox1.Size = New System.Drawing.Size(248, 238)
        Me.FileListBox1.TabIndex = 0
        Me.FileListBox1.TabStop = False
        '
        'rtfMain
        '
        Me.rtfMain.AcceptsTab = True
        Me.rtfMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.rtfMain.Location = New System.Drawing.Point(248, 16)
        Me.rtfMain.Name = "rtfMain"
        Me.rtfMain.Size = New System.Drawing.Size(600, 600)
        Me.rtfMain.TabIndex = 1
        Me.rtfMain.Text = "No file! you must click on existing file first!"
        Me.rtfMain.WordWrap = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5, Me.MenuItem6})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAddNewFile, Me.menuAddExistingFile, Me.MenuSaveCurrentFile, Me.menuDelFile})
        Me.MenuItem1.Text = "&File"
        '
        'menuAddNewFile
        '
        Me.menuAddNewFile.Index = 0
        Me.menuAddNewFile.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.menuAddNewFile.Text = "Add new file"
        '
        'menuAddExistingFile
        '
        Me.menuAddExistingFile.Index = 1
        Me.menuAddExistingFile.Text = "Add existing file"
        '
        'MenuSaveCurrentFile
        '
        Me.MenuSaveCurrentFile.Index = 2
        Me.MenuSaveCurrentFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.MenuSaveCurrentFile.Text = "Save current file"
        '
        'menuDelFile
        '
        Me.menuDelFile.Index = 3
        Me.menuDelFile.Text = "Delete file"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuEditCopy, Me.MenuEditPast, Me.menuEditCut})
        Me.MenuItem2.Text = "&Edit"
        '
        'menuEditCopy
        '
        Me.menuEditCopy.Index = 0
        Me.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.menuEditCopy.Text = "Copy"
        '
        'MenuEditPast
        '
        Me.MenuEditPast.Index = 1
        Me.MenuEditPast.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.MenuEditPast.Text = "Past"
        '
        'menuEditCut
        '
        Me.menuEditCut.Index = 2
        Me.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.menuEditCut.Text = "Cut"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuViwTelnetWindow, Me.menuRefreshFiles})
        Me.MenuItem3.Text = "&View"
        '
        'menuViwTelnetWindow
        '
        Me.menuViwTelnetWindow.Index = 0
        Me.menuViwTelnetWindow.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.menuViwTelnetWindow.Text = "Telnet window"
        '
        'menuRefreshFiles
        '
        Me.menuRefreshFiles.Index = 1
        Me.menuRefreshFiles.Text = "Refresh files view "
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSetProjectLocalLocation, Me.menuSetProjectRemoteParm})
        Me.MenuItem4.Text = "&Project"
        '
        'menuSetProjectLocalLocation
        '
        Me.menuSetProjectLocalLocation.Index = 0
        Me.menuSetProjectLocalLocation.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.menuSetProjectLocalLocation.Text = "Set project local location"
        '
        'menuSetProjectRemoteParm
        '
        Me.menuSetProjectRemoteParm.Index = 1
        Me.menuSetProjectRemoteParm.Text = "Set project remote parm"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuRun})
        Me.MenuItem5.Text = "&Build"
        '
        'menuRun
        '
        Me.menuRun.Index = 0
        Me.menuRun.Shortcut = System.Windows.Forms.Shortcut.F9
        Me.menuRun.Text = "Run"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.Text = "&Help"
        '
        'rtfTemp
        '
        Me.rtfTemp.AcceptsTab = True
        Me.rtfTemp.Location = New System.Drawing.Point(312, 544)
        Me.rtfTemp.Name = "rtfTemp"
        Me.rtfTemp.Size = New System.Drawing.Size(64, 64)
        Me.rtfTemp.TabIndex = 2
        Me.rtfTemp.Text = ""
        Me.rtfTemp.Visible = False
        '
        'lblLocalPath
        '
        Me.lblLocalPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblLocalPath.Name = "lblLocalPath"
        Me.lblLocalPath.Size = New System.Drawing.Size(616, 16)
        Me.lblLocalPath.TabIndex = 3
        Me.lblLocalPath.Text = "Project dir"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "*.c|*.c|*.cpp|*.cpp|*.txt|*.txt"
        Me.OpenFileDialog1.Title = "Warning, add file name equal to existing one will dellete old file!"
        '
        'lstAction
        '
        Me.lstAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lstAction.HorizontalScrollbar = True
        Me.lstAction.ItemHeight = 16
        Me.lstAction.Location = New System.Drawing.Point(0, 264)
        Me.lstAction.Name = "lstAction"
        Me.lstAction.Size = New System.Drawing.Size(248, 100)
        Me.lstAction.TabIndex = 4
        Me.lstAction.TabStop = False
        '
        'FTP
        '
        Me.FTP.Enabled = True
        Me.FTP.Location = New System.Drawing.Point(264, 568)
        Me.FTP.Name = "FTP"
        Me.FTP.OcxState = CType(resources.GetObject("FTP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.FTP.Size = New System.Drawing.Size(38, 38)
        Me.FTP.TabIndex = 5
        '
        'cmdRun
        '
        Me.cmdRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmdRun.Location = New System.Drawing.Point(8, 192)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(40, 23)
        Me.cmdRun.TabIndex = 6
        Me.cmdRun.TabStop = False
        Me.cmdRun.Text = "Run"
        '
        'cmdEditRun
        '
        Me.cmdEditRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmdEditRun.Location = New System.Drawing.Point(56, 192)
        Me.cmdEditRun.Name = "cmdEditRun"
        Me.cmdEditRun.Size = New System.Drawing.Size(40, 23)
        Me.cmdEditRun.TabIndex = 9
        Me.cmdEditRun.TabStop = False
        Me.cmdEditRun.Text = "Edit"
        '
        'btnOpenFtp
        '
        Me.btnOpenFtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnOpenFtp.Location = New System.Drawing.Point(8, 224)
        Me.btnOpenFtp.Name = "btnOpenFtp"
        Me.btnOpenFtp.Size = New System.Drawing.Size(96, 23)
        Me.btnOpenFtp.TabIndex = 12
        Me.btnOpenFtp.TabStop = False
        Me.btnOpenFtp.Text = "Open FTP"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Command"
        '
        'btnOpenTelnet
        '
        Me.btnOpenTelnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenTelnet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnOpenTelnet.Location = New System.Drawing.Point(112, 224)
        Me.btnOpenTelnet.Name = "btnOpenTelnet"
        Me.btnOpenTelnet.Size = New System.Drawing.Size(96, 23)
        Me.btnOpenTelnet.TabIndex = 14
        Me.btnOpenTelnet.TabStop = False
        Me.btnOpenTelnet.Text = "Open Telnet"
        '
        'lstRunCommands
        '
        Me.lstRunCommands.HorizontalScrollbar = True
        Me.lstRunCommands.ItemHeight = 18
        Me.lstRunCommands.Location = New System.Drawing.Point(8, 24)
        Me.lstRunCommands.Name = "lstRunCommands"
        Me.lstRunCommands.Size = New System.Drawing.Size(232, 148)
        Me.lstRunCommands.TabIndex = 15
        '
        'chkFTP
        '
        Me.chkFTP.Checked = True
        Me.chkFTP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.chkFTP.Location = New System.Drawing.Point(160, 8)
        Me.chkFTP.Name = "chkFTP"
        Me.chkFTP.Size = New System.Drawing.Size(56, 16)
        Me.chkFTP.TabIndex = 16
        Me.chkFTP.Text = "FTP"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRun, Me.btnOpenFtp, Me.btnOpenTelnet, Me.cmdEditRun, Me.lstRunCommands, Me.Label2, Me.chkFTP})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(0, 360)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 256)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'lblLine
        '
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblLine.Location = New System.Drawing.Point(784, 0)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(64, 16)
        Me.lblLine.TabIndex = 19
        Me.lblLine.Text = "- -"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 17)
        Me.ClientSize = New System.Drawing.Size(848, 617)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLine, Me.GroupBox1, Me.FTP, Me.lstAction, Me.lblLocalPath, Me.rtfTemp, Me.rtfMain, Me.FileListBox1})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remote gcc"
        CType(Me.FTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '****** general function ******
    Private Function saveCurrentFile() As Boolean
        Dim a As Integer
        Dim ch As Char
        Dim iFilename As String
        If currentFile <> "no file" Then
            'rtfMain.SaveFile(FileListBox1.Path & "\" & currentFile, RichTextBoxStreamType.PlainText)
            iFilename = FileListBox1.Path & "\" & currentFile
            Dim dFile As New System.IO.FileInfo(iFilename)
            dFile.Delete()
            FileOpen(1, iFilename, OpenMode.Binary)
            For a = 1 To Len(rtfMain.Text)
                ch = Mid(rtfMain.Text, a, 1)
                FilePut(1, ch)
            Next a
            FileClose(1)
            saveCurrentFile = True
            addAction("saved: " & currentFile)
        Else
            saveCurrentFile = False
        End If
    End Function

    Private Sub setTitle()
        Me.Text = "Remote gcc - " & currentFile
    End Sub

    Private Function removechr13(ByVal sText As String) As String
        Dim a As Integer
        Dim ch As Char
        Dim sText2 As String
        For a = 1 To Len(sText)
            ch = Mid(sText, a, 1)
            If Asc(ch) <> 13 Then
                sText2 = sText2 & ch
            End If
        Next
        removechr13 = sText2
    End Function

    Public Sub addAction(ByVal textAction As String)
        lstAction.Items.Insert(0, lstAction.Items.Count & ":" & textAction)
    End Sub

    '****** end of general functions ******

    'this is the only form_load sub
    Public Sub frmMain_LoadForm()
        Dim a As Integer
        lblLocalPath.Text = FileListBox1.Path
        currentFile = "no file"
        setTitle()
        remoteHost = GetSetting("remoteGcc", "parms", "remoteHost")
        remotePassword = GetSetting("remoteGcc", "parms", "remotePassword")
        remoteUsername = GetSetting("remoteGcc", "parms", "remoteUsername")
        telnetProgram = GetSetting("remoteGcc", "parms", "telnetProgram")
        telnetId = GetSetting("remoteGcc", "parms", "telnetId", "0")
        For a = 1 To 10
            lstRunCommands.Items.Add(GetSetting("remoteGcc", "parms", "runCommand" & Str(a), "_"))
        Next
    End Sub

    Private Sub menuSetProjectLocalLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetProjectLocalLocation.Click
        Dim dirSel As New frmDirSelect()
        dirSel.ShowDialog()
        FileListBox1.Path = dirSel.selectedDir
        lblLocalPath.Text = FileListBox1.Path
    End Sub

    Private Sub menuAddNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAddNewFile.Click
        On Error GoTo errorInNewFile
        Dim newFile, rNewFile, rNewFile2 As String
        newFile = InputBox("Enter new file name and extention (*.c, *.cpp, *.txt)")
        newFile = Trim(newFile)
        rNewFile = Microsoft.VisualBasic.Right(newFile, 2)
        rNewFile2 = Microsoft.VisualBasic.Right(newFile, 4)
        If rNewFile <> ".c" And rNewFile2 <> ".cpp" And rNewFile2 <> ".txt" Then GoTo errorInNewFile
        rtfTemp.Text = ""
        rtfTemp.SaveFile(FileListBox1.Path & "\" & newFile, RichTextBoxStreamType.PlainText)
        FileListBox1.Refresh()
        Exit Sub
errorInNewFile:
        MsgBox("Error in new file name!", MsgBoxStyle.Critical)
    End Sub


    Private Sub menuAddExistingFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuAddExistingFile.Click
        On Error GoTo errorInAddNewFile
        Dim addFile, r, a As String
        OpenFileDialog1.ShowDialog()
        addFile = OpenFileDialog1.FileName
        If addFile <> "" Then
            rtfTemp.LoadFile(addFile, RichTextBoxStreamType.PlainText)
            a = InStrRev(addFile, "\") + 1
            r = Mid(addFile, a)
            rtfTemp.SaveFile(FileListBox1.Path & "\" & r, RichTextBoxStreamType.PlainText)
            FileListBox1.Refresh()
        End If
        Exit Sub
errorInAddNewFile:
        MsgBox("Error in adding new file!")
    End Sub

    Private Sub MenuSaveCurrentFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSaveCurrentFile.Click
        saveCurrentFile()
    End Sub

    Private Sub FileListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileListBox1.SelectedIndexChanged
        On Error GoTo errorSelectedFile
        saveCurrentFile()
        currentFile = FileListBox1.SelectedItem
        rtfMain.LoadFile(FileListBox1.Path & "\" & currentFile, RichTextBoxStreamType.PlainText)
        setTitle()
        rtfMain.Focus()
        Exit Sub
errorSelectedFile:
        MsgBox("Error!, file maybe not exist", MsgBoxStyle.Critical)
    End Sub

    Private Sub rtfMain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtfMain.TextChanged
        If currentFile = "no file" Then rtfMain.Text = "No file! you must click on existing file first!"
    End Sub

    Private Sub menuEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditCopy.Click
        Clipboard.SetDataObject(rtfMain.SelectedText)
    End Sub

    Private Sub MenuEditPast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEditPast.Click
        rtfMain.SelectedText = Clipboard.GetDataObject.GetData(DataFormats.Text)
    End Sub

    Private Sub menuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditCut.Click
        Clipboard.SetDataObject(rtfMain.SelectedText)
        rtfMain.SelectedText = ""
    End Sub

    Private Sub menuSetProjectRemoteParm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetProjectRemoteParm.Click
        Dim r As New frmRemoteParm()
        r.ShowDialog()
    End Sub

    Private Sub frmMain_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        FTP.Disconnect()
        saveCurrentFile()
    End Sub

    Private Sub btnOpenFtp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFtp.Click
        On Error GoTo errorInFtpConnect
        btnOpenFtp.Text = "Wait!"
        addAction("FTP connecting")
        Application.DoEvents()
        FTP.RemoteAddress = remoteHost
        FTP.Password = remotePassword
        FTP.UserName = remoteUsername
        FTP.Connect()
        addAction("FTP connected")
        btnOpenFtp.Text = "Open FTP"
        Exit Sub
errorInFtpConnect:
        MsgBox("Error in FTP connection!, Check project parms and net connection.", MsgBoxStyle.Critical)
        btnOpenFtp.Text = "Open FTP"
    End Sub

    Private Sub btnOpenTelnet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenTelnet.Click
        telnetId = Shell(telnetProgram & " " & remoteHost, AppWinStyle.NormalFocus, False)
        SaveSetting("remoteGcc", "parms", "telnetId", Str(telnetId))
    End Sub

    Private Sub cmdEditRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditRun.Click
        On Error Resume Next
        Dim newCommand As String
        newCommand = InputBox("Enter command", , lstRunCommands.SelectedItem)
        If newCommand <> "" Then
            lstRunCommands.Items.Item(lstRunCommands.SelectedIndex) = newCommand
            SaveSetting("remoteGcc", "parms", "runCommand" & Str(lstRunCommands.SelectedIndex + 1), newCommand)
            lstRunCommands.Refresh()
        End If
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        runCommand()
    End Sub

    Private Sub runCommand()
        On Error GoTo errorInRunCommand
        Dim a As Integer
        Dim sKeys As String
        saveCurrentFile()
        If chkFTP.Checked = True Then
            For a = 0 To FileListBox1.Items.Count - 1
                FTP.LocalFile = FileListBox1.Path & "\" & FileListBox1.Items.Item(a)
                FTP.RemoteFile = FileListBox1.Items.Item(a)
                FTP.PutFile()
                addAction("uploaded: " & FTP.RemoteFile)
            Next
        End If
        AppActivate(telnetId)
        sKeys = " " & lstRunCommands.Items.Item(lstRunCommands.SelectedIndex)
        SendKeys.Send(sKeys & "{enter}")
        Exit Sub
errorInRunCommand:
        MsgBox("Error in run command, check telnet is open and FTP is open.", MsgBoxStyle.Critical)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub menuViwTelnetWindow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViwTelnetWindow.Click
        On Error Resume Next
        AppActivate(telnetId)
    End Sub

    Private Sub menuDelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuDelFile.Click
        Dim iFilename As String
        Dim a As Integer
        If currentFile <> "no file" Then
            If MsgBox("Delete file " & currentFile & "?", MsgBoxStyle.OKCancel) = MsgBoxResult.OK Then
                iFilename = FileListBox1.Path & "\" & currentFile
                Dim dFile As New System.IO.FileInfo(iFilename)
                dFile.Delete()
                rtfMain.Text = ""
                currentFile = "no file"
                setTitle()
                FileListBox1.Refresh()
            End If
        End If
    End Sub

    Private Sub menuRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRun.Click
        runCommand()
    End Sub

    Private Sub lstRunCommands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRunCommands.SelectedIndexChanged

    End Sub

    Private Sub rtfMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles rtfMain.KeyUp
        lblLine.Text = "line: " & rtfMain.GetLineFromCharIndex(rtfMain.SelectionStart)
    End Sub

    Private Sub rtfMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtfMain.MouseUp
        lblLine.Text = rtfMain.GetLineFromCharIndex(rtfMain.SelectionStart)
    End Sub

    Private Sub menuRefreshFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRefreshFiles.Click
        FileListBox1.Refresh()
    End Sub

End Class
