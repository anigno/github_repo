Imports System.Windows.Forms
Public Class c_board

    Private Const tmrRun_INTERVAL = 200
    Private Const tmrDisplay_interval = 1000
    Private minimax_depth = 2               'minimax recourse depth (harder is +2)
    Private square(8, 8) As Label           'labels to show board
    Private parentForm As Form              'reference to parentForm
    Public tmrRun As Timer                  'timer for AI use
    Private tmrDisplay As Timer             'timer for display

    Public table As c_table                 'table to hold data
    Public humanAI As c_AI                 'AI for human player use
    Public computerAI As c_AI              'AI for computer player use
    Public debugFlag = False
    Public currentPlayer As Integer        'the current player (1 or 2)
    Public player_1_score As Integer
    Public player_2_score As Integer
    Public player_1_is As Integer = 0       '0=humen,1=computer easy,2=computer hard
    Public player_2_is As Integer = 0       '0=humen,1=computer easy,2=computer hard
    Public pColor(3) As Color               'colors of squares
    Public heuristic1 As Integer            'heuristic for player1
    Public heuristic2 As Integer            'heuristic for player2
    Public gameRun As Boolean               'flag, is the game running
    Public prevTable As c_table             'previous tabel for display animating

    Public Event currentPlayerChanged(ByVal sender As Object, ByVal currentPlayer As Integer)
    Public Event gameEnd(ByVal sender As Object)

    'c_board constructor
    Public Sub New(ByVal frm As Form)
        humanAI = New c_AI
        computerAI = New c_AI
        initProperties()
        createTimers()
        parentForm = frm
        createSquares()
        newGame()
    End Sub

    'init all properties
    Private Sub initProperties()
        table = New c_table
        prevTable = New c_table
        pColor(0) = Color.Gray
        pColor(1) = Color.CornflowerBlue
        pColor(2) = Color.LightGreen
        calculateScore()
    End Sub

    'create new timer
    Private Sub createTimers()
        'create new timer and set properties
        tmrRun = New Timer
        tmrDisplay = New Timer
        tmrRun.Enabled = True
        tmrDisplay.Enabled = True
        tmrRun.Interval = tmrRun_INTERVAL
        tmrDisplay.Interval = tmrDisplay_interval
        'add event handler for timer tick
        AddHandler tmrRun.Tick, AddressOf tmrRun_Tick
        AddHandler tmrDisplay.Tick, AddressOf tmrDisplay_Tick
    End Sub

    'create the square labels and add them to a form
    Private Sub createSquares()
        Dim a, b
        For a = 1 To 8
            For b = 1 To 8
                square(a, b) = New Label
                'add to a form
                parentForm.Controls.Add(square(a, b))
                'set properties for the new label
                With square(a, b)
                    .Width = 40
                    .Height = 40
                    .Left = (a - 1) * 40
                    .Top = (b - 1) * 40
                    .TextAlign = ContentAlignment.MiddleCenter
                    .Text = ""
                    .BorderStyle = BorderStyle.FixedSingle
                    .Show()
                End With
                'add event handlers for the new labels
                AddHandler square(a, b).MouseMove, AddressOf square_MouseMoveEvent
                AddHandler square(a, b).Click, AddressOf square_MouseClickEvent
                AddHandler square(a, b).MouseLeave, AddressOf square_MouseLeaveEvent
            Next
        Next
    End Sub

    'setup for new game
    Public Sub newGame()
        clearTable()
        setSquare(4, 4, 1) : setSquare(5, 5, 1)
        setSquare(4, 5, 2) : setSquare(5, 4, 2)
        currentPlayer = 2
        nextPlayer()        'first time player is always player 1
        calculateScore()
    End Sub

    'clears the table and squares
    Private Sub clearTable()
        Dim a, b
        For a = 1 To 8
            For b = 1 To 8
                setSquare(a, b, 0)
            Next
        Next
    End Sub

    'set square color and table value - c at position x,y
    Private Sub setSquare(ByVal x As Integer, ByVal y As Integer, ByVal c As Integer)
        table.data(x, y) = c
    End Sub

    'event handler, call square_MouseMove with x,y position
    Private Sub square_MouseMoveEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim s As Label = sender
        square_MouseMove(s.Left / 40 + 1, s.Top / 40 + 1)
        'DO NOT ADD ANY CODE HERE
    End Sub

    'event handler, call square_MouseClick with x,y position
    Private Sub square_MouseClickEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim s As Label = sender
        square_MouseClick(s.Left / 40 + 1, s.Top / 40 + 1)
        'DO NOT ADD ANY CODE HERE
    End Sub

    'event handler, call square_MouseLeave with x,y position
    Private Sub square_MouseLeaveEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim s As Label = sender
        square_MouseLeave(s.Left / 40 + 1, s.Top / 40 + 1)
        'DO NOT ADD ANY CODE HERE
    End Sub

    'MouseMove at position x,y
    Private Sub square_MouseMove(ByVal x As Integer, ByVal y As Integer)
    End Sub
    'MouseLeave at position x,y
    Private Sub square_MouseLeave(ByVal x As Integer, ByVal y As Integer)

    End Sub

    'MouseClick at position x,y
    Private Sub square_MouseClick(ByVal x As Integer, ByVal y As Integer)
        Dim isHumanPlayer = False
        If currentPlayer = 1 And player_1_is = 0 Then isHumanPlayer = True
        If currentPlayer = 2 And player_2_is = 0 Then isHumanPlayer = True
        If isHumanPlayer = True Then
            If checkEnd() = False Then
                If humanAI.checkPosition(table, x, y, currentPlayer) > 0 Then
                    humanAI.flipPosition(table, x, y, currentPlayer)
                    nextPlayer()
                End If
            End If
        End If
    End Sub

    'event handler, timer, tmrDisplay
    Private Sub tmrDisplay_Tick(ByVal sender As Object, ByVal e As EventArgs)
        tmrRun.Enabled = False
        setSquaresColor()
        setLegalPositionText()
        tmrRun.Enabled = True
        tmrDisplay.Enabled = False
    End Sub

    'event handler, timer, tmrRun
    Private Sub tmrRun_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim done = False        'done=true if player already made a move
        Dim a, b As Integer
        'check if game not ended
        If checkEnd() = False And gameRun = True Then
            'call AI function to get next move
            If done = False And player_2_is = 1 And currentPlayer = 2 Then
                computerAI.makeEasyMove(table, 2)
                nextPlayer()
                done = True
            End If
            If done = False And player_1_is = 1 And currentPlayer = 1 Then
                computerAI.makeEasyMove(table, 1)
                nextPlayer()
                done = True
            End If
            If done = False And player_2_is = 2 And currentPlayer = 2 Then
                computerAI.runMiniMax(table, minimax_depth, 2, heuristic2)
                nextPlayer()
                done = True
            End If
            If done = False And player_1_is = 2 And currentPlayer = 1 Then
                computerAI.runMiniMax(table, minimax_depth, 1, heuristic1)
                nextPlayer()
                done = True
            End If
            If done = False And player_2_is = 3 And currentPlayer = 2 Then
                computerAI.runMiniMax(table, minimax_depth + 2, 2, heuristic2)
                nextPlayer()
                done = True
            End If
            If done = False And player_1_is = 3 And currentPlayer = 1 Then
                computerAI.runMiniMax(table, minimax_depth + 2, 1, heuristic1)
                nextPlayer()
                done = True
            End If
            tmrRun.Enabled = False
        End If
    End Sub

    'change currentPlayer to next one
    Private Sub nextPlayer()
        tmrDisplay.Enabled = True
        currentPlayer += 1 : If currentPlayer > 2 Then currentPlayer = 1
        calculateScore()
        setSquaresColor()
        'raise the event
        RaiseEvent currentPlayerChanged(Me, currentPlayer)
    End Sub

    'set board squares color according to table data
    Private Sub setSquaresColor()
        Dim a, b
        For a = 1 To 8
            For b = 1 To 8
                If prevTable.data(a, b) <> table.data(a, b) Then
                    'square color changed
                    square(a, b).BackColor = Color.LightGoldenrodYellow
                    prevTable.data(a, b) = table.data(a, b)
                Else
                    'set square's new color from game main table
                    square(a, b).BackColor = pColor(table.data(a, b))
                End If
            Next
        Next
    End Sub

    'set legal moves values as text, write them on board
    Private Sub setLegalPositionText()
        Dim a, b
        For a = 1 To 8
            For b = 1 To 8
                'check for legal position
                If humanAI.checkPosition(table, a, b, currentPlayer) > 0 Then
                    'write value to square
                    square(a, b).Text = humanAI.checkPosition(table, a, b, currentPlayer)
                Else
                    'write nothing to square
                    square(a, b).Text = ""
                End If
            Next
        Next
    End Sub

    'calculate game score
    Public Sub calculateScore()
        player_1_score = humanAI.getPlayerScore(table, 1)
        player_2_score = humanAI.getPlayerScore(table, 2)
    End Sub

    Public Function checkEnd() As Boolean
        checkEnd = False
        Dim other = currentPlayer + 1 : If other > 2 Then other = 1
        If humanAI.checkEnd(table, currentPlayer) = True And humanAI.checkEnd(table, other) = True Then
            checkEnd = True
            RaiseEvent gameEnd(Me)
            Exit Function
        End If
        If humanAI.checkEnd(table, currentPlayer) = True Then
            nextPlayer()
        End If

    End Function

End Class
