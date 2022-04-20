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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPlayer_1_score As System.Windows.Forms.Label
    Friend WithEvents lblPlayer_2_score As System.Windows.Forms.Label
    Friend WithEvents lblCurrentPlayer As System.Windows.Forms.Label
    Friend WithEvents btnNewGame As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbPlayer1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPlayer2 As System.Windows.Forms.ComboBox
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents cmbHset1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbHset2 As System.Windows.Forms.ComboBox
    Friend WithEvents btnStopGame As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblPlayer_1_score = New System.Windows.Forms.Label
        Me.lblPlayer_2_score = New System.Windows.Forms.Label
        Me.lblCurrentPlayer = New System.Windows.Forms.Label
        Me.btnNewGame = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbPlayer1 = New System.Windows.Forms.ComboBox
        Me.cmbPlayer2 = New System.Windows.Forms.ComboBox
        Me.lstResults = New System.Windows.Forms.ListBox
        Me.cmbHset1 = New System.Windows.Forms.ComboBox
        Me.cmbHset2 = New System.Windows.Forms.ComboBox
        Me.btnStopGame = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(320, 320)
        Me.Panel1.TabIndex = 0
        '
        'lblPlayer_1_score
        '
        Me.lblPlayer_1_score.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblPlayer_1_score.Location = New System.Drawing.Point(0, 320)
        Me.lblPlayer_1_score.Name = "lblPlayer_1_score"
        Me.lblPlayer_1_score.Size = New System.Drawing.Size(48, 24)
        Me.lblPlayer_1_score.TabIndex = 1
        Me.lblPlayer_1_score.Text = "2"
        Me.lblPlayer_1_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlayer_2_score
        '
        Me.lblPlayer_2_score.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblPlayer_2_score.Location = New System.Drawing.Point(272, 320)
        Me.lblPlayer_2_score.Name = "lblPlayer_2_score"
        Me.lblPlayer_2_score.Size = New System.Drawing.Size(48, 24)
        Me.lblPlayer_2_score.TabIndex = 2
        Me.lblPlayer_2_score.Text = "2"
        Me.lblPlayer_2_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCurrentPlayer
        '
        Me.lblCurrentPlayer.Location = New System.Drawing.Point(0, 320)
        Me.lblCurrentPlayer.Name = "lblCurrentPlayer"
        Me.lblCurrentPlayer.Size = New System.Drawing.Size(320, 32)
        Me.lblCurrentPlayer.TabIndex = 3
        Me.lblCurrentPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(336, 0)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(112, 24)
        Me.btnNewGame.TabIndex = 4
        Me.btnNewGame.Text = "Run new game"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(336, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Player 1:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(336, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Player 2:"
        '
        'cmbPlayer1
        '
        Me.cmbPlayer1.Items.AddRange(New Object() {"Human", "Computer easy (max flips)", "Computer (mini-max depth=3)", "Computer (mini-max depth=5)"})
        Me.cmbPlayer1.Location = New System.Drawing.Point(416, 32)
        Me.cmbPlayer1.Name = "cmbPlayer1"
        Me.cmbPlayer1.Size = New System.Drawing.Size(200, 24)
        Me.cmbPlayer1.TabIndex = 7
        Me.cmbPlayer1.Text = "Human"
        '
        'cmbPlayer2
        '
        Me.cmbPlayer2.Items.AddRange(New Object() {"Human", "Computer easy (max flips)", "Computer (mini-max depth=3)", "Computer (mini-max depth=5)"})
        Me.cmbPlayer2.Location = New System.Drawing.Point(416, 88)
        Me.cmbPlayer2.Name = "cmbPlayer2"
        Me.cmbPlayer2.Size = New System.Drawing.Size(200, 24)
        Me.cmbPlayer2.TabIndex = 8
        Me.cmbPlayer2.Text = "Human"
        '
        'lstResults
        '
        Me.lstResults.Enabled = False
        Me.lstResults.ItemHeight = 16
        Me.lstResults.Items.AddRange(New Object() {"    Game data", "~~~~~~~~~~~"})
        Me.lstResults.Location = New System.Drawing.Point(336, 168)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(160, 148)
        Me.lstResults.TabIndex = 9
        '
        'cmbHset1
        '
        Me.cmbHset1.Items.AddRange(New Object() {"Heuristic 1", "Heuristic 2"})
        Me.cmbHset1.Location = New System.Drawing.Point(416, 56)
        Me.cmbHset1.Name = "cmbHset1"
        Me.cmbHset1.Size = New System.Drawing.Size(200, 24)
        Me.cmbHset1.TabIndex = 10
        Me.cmbHset1.Text = "Heuristic1"
        '
        'cmbHset2
        '
        Me.cmbHset2.Items.AddRange(New Object() {"Heuristic 1", "Heuristic 2"})
        Me.cmbHset2.Location = New System.Drawing.Point(416, 112)
        Me.cmbHset2.Name = "cmbHset2"
        Me.cmbHset2.Size = New System.Drawing.Size(200, 24)
        Me.cmbHset2.TabIndex = 11
        Me.cmbHset2.Text = "Heuristic1"
        '
        'btnStopGame
        '
        Me.btnStopGame.Location = New System.Drawing.Point(456, 0)
        Me.btnStopGame.Name = "btnStopGame"
        Me.btnStopGame.Size = New System.Drawing.Size(112, 24)
        Me.btnStopGame.TabIndex = 12
        Me.btnStopGame.Text = "Quit game"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(688, 420)
        Me.Controls.Add(Me.btnStopGame)
        Me.Controls.Add(Me.cmbHset2)
        Me.Controls.Add(Me.cmbHset1)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.cmbPlayer2)
        Me.Controls.Add(Me.cmbPlayer1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.lblPlayer_2_score)
        Me.Controls.Add(Me.lblPlayer_1_score)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblCurrentPlayer)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Othello V1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents board As New c_board(Me)    'main game board
    Private gameEnded As Boolean = False

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set score label to players color from board settings
        lblPlayer_1_score.BackColor = board.pColor(1)
        lblPlayer_2_score.BackColor = board.pColor(2)
        'set current player label to first player color
        lblCurrentPlayer.BackColor = board.pColor(1)
    End Sub

    Private Sub board_currentPlayerChanged(ByVal sender As Object, ByVal currentPlayer As Integer) Handles board.currentPlayerChanged
        'change current player label's color
        lblCurrentPlayer.BackColor = board.pColor(currentPlayer)
        'change score
        lblPlayer_1_score.Text = board.player_1_score
        lblPlayer_2_score.Text = board.player_2_score
    End Sub

    Private Sub board_gameEnd(ByVal sender As Object) Handles board.gameEnd
        'check gameEnded flag, to display this only one for agame
        If gameEnded = False Then
            board.gameRun = False
            'write game details and results
            lblCurrentPlayer.Text = "END"
            lblCurrentPlayer.BackColor = board.pColor(0)
            lstResults.Items.Add("score: " & board.player_1_score & " - " & board.player_2_score)
            lstResults.Items.Add("cutOffs=" & board.computerAI.cutOffCounter)
            lstResults.Items.Add("Total leafs=" & board.computerAI.leafCounter)
            lstResults.Items.Add("-------------------------")
            lstResults.SelectedIndex = lstResults.Items.Count - 1
            gameEnded = True
        End If
    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        'start new game
        board.newGame()
        gameEnded = False
        board.computerAI.cutOffCounter = 0
        board.computerAI.leafCounter = 0
        lblCurrentPlayer.Text = ""
        lblPlayer_1_score.Text = board.player_1_score
        lblPlayer_2_score.Text = board.player_2_score
        board.gameRun = True
    End Sub

    Private Sub cmbPlayer1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlayer1.SelectedIndexChanged
        'set player 1 type
        board.player_1_is = cmbPlayer1.SelectedIndex
    End Sub

    Private Sub cmbPlayer2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlayer2.SelectedIndexChanged
        'set player 2 type
        board.player_2_is = cmbPlayer2.SelectedIndex
    End Sub

    Private Sub cmbHset1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHset1.SelectedIndexChanged
        'set heuristic for player 1
        board.heuristic1 = cmbHset1.SelectedIndex
    End Sub

    Private Sub cmbHset2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbHset2.SelectedIndexChanged
        'set heuristic for player 2
        board.heuristic2 = cmbHset2.SelectedIndex
    End Sub

    Private Sub btnStopGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopGame.Click
        'stop the current game
        board.gameRun = False
    End Sub
End Class
