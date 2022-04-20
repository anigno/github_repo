Public Class c_AI

    Public Shared c_AI_counter As Integer = 0   'static (shared) c_AI class counter
    Public leafCounter As Long = 0              'count total leafs
    Public cutOffCounter As Long = 0            'count total cutOffs

    'c_AI constructor
    Public Sub New()
        c_AI_counter += 1
        Randomize()
    End Sub

    'get seq value from x,y at one direction dy,dy (if none return 0)
    Private Function getSeq(ByVal table As c_table, ByVal x As Integer, ByVal y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal player As Integer) As Integer
        Dim other
        Dim rank = 0
        other = player + 1 : If other > 2 Then other = 1
        'count other squares at direction dx,dy
        Try
            While table.data(x + dx, y + dy) = other
                x = x + dx
                y = y + dy
                rank = rank + 1
            End While
            'check closing square
            If table.data(x + dx, y + dy) = player Then getSeq = rank
        Catch e As Exception
            getSeq = 0
            Exit Function
        End Try
    End Function

    'check position x,y for posible seq's
    Public Function checkPosition(ByVal table As c_table, ByVal x As Integer, ByVal y As Integer, ByVal player As Integer) As Integer
        Dim a, b
        Dim rank = 0
        'if position x,y is not empty, no seq posible
        If table.data(x, y) <> 0 Then
            checkPosition = 0
            Exit Function
        End If
        'go's around x,y and check seq at all directions
        For a = -1 To 1
            For b = -1 To 1
                If a <> 0 Or b <> 0 Then
                    'rank is sum of all seq's
                    rank += getSeq(table, x, y, a, b, player)
                End If
            Next
        Next
        checkPosition = rank
    End Function

    'flips other squares to be player squares at position x,y (if any)
    Public Sub flipPosition(ByVal table As c_table, ByVal x As Integer, ByVal y As Integer, ByVal player As Integer)
        Dim a, b
        Dim rank = 0
        Dim wasFlip As Boolean = False
        'check all directions
        For a = -1 To 1
            For b = -1 To 1
                'check not dx=0,dy=0 ,not a direction
                If a <> 0 Or b <> 0 Then
                    rank = getSeq(table, x, y, a, b, player)
                    If rank > 0 Then
                        'flip one direction
                        makeFlips(table, x, y, a, b, player)
                        'set flag that was a flip (any direction)
                        wasFlip = True
                    End If
                End If
            Next
        Next
        'if was a flip, add position to player's color
        If wasFlip = True Then table.data(x, y) = player
    End Sub

    'flips from position x,y at direction dx,dy (must be legal!)
    Private Sub makeFlips(ByVal table As c_table, ByVal x As Integer, ByVal y As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal player As Integer)
        Dim other
        Dim rank = 0
        other = player + 1 : If other > 2 Then other = 1
        While table.data(x + dx, y + dy) = other
            x = x + dx
            y = y + dy
            table.data(x, y) = player
        End While
    End Sub

    'return the player score
    Public Function getPlayerScore(ByVal table As c_table, ByVal player As Integer) As Integer
        Dim a, b
        For a = 1 To 8
            For b = 1 To 8
                If table.data(a, b) = player Then getPlayerScore += 1
            Next
        Next
    End Function

    'easy move for AI computer Easy
    Public Sub makeEasyMove(ByVal table As c_table, ByVal player As Integer)
        Dim a, b
        Dim bestRank = 0
        Dim tempRank, bestX, bestY
        Dim badRank = 64
        Dim badX, badY
        For a = 1 To 8
            For b = 1 To 8
                tempRank = checkPosition(table, a, b, player)
                'get the best rank
                If tempRank > bestRank Then
                    bestRank = tempRank
                    bestX = a
                    bestY = b
                End If
                'choose between best ranks randomly
                If tempRank = bestRank And Int(Rnd() * 2) = 0 Then
                    bestX = a
                    bestY = b
                End If
            Next
        Next
        'play best move
        flipPosition(table, bestX, bestY, player)
    End Sub

    'check if game ended, (no legal positions left)
    Public Function checkEnd(ByVal table As c_table, ByVal player As Integer) As Boolean
        Dim a, b
        checkEnd = True
        For a = 1 To 8
            For b = 1 To 8
                If checkPosition(table, a, b, player) > 0 Then checkEnd = False
            Next
        Next
    End Function

    'return the other player number
    Private Function otherPlayer(ByVal player As Integer) As Integer
        player += 1
        If player > 2 Then player = 1
        otherPlayer = player
    End Function

    'return value if next move legal, changes x,y to be next move position (=0 if no next move)
    Private Function nextMove(ByVal table As c_table, ByRef x As Integer, ByRef y As Integer, ByVal player As Integer) As Integer
        Dim nextMoveRank As Integer
        'start of next move run is always 0,0 ,change it so fist try will be 1,1
        If x = 0 Then x = 1
        While x <= 8
            While y < 8
                y += 1
                'check position x,y for legal move
                nextMoveRank = checkPosition(table, x, y, player)
                If nextMoveRank > 0 Then
                    nextMove = nextMoveRank
                    'exit function with next move
                    Exit Function
                End If
            End While
            'next coloumn
            y = 0 : x += 1
        End While
        'no next move, return 0
        nextMove = 0
    End Function

    Public Function runMiniMax(ByVal table As c_table, ByVal depth As Integer, ByVal player As Integer, ByVal heuristic As Integer) As Integer
        Dim maxScore, playMove As Integer
        Dim x As Integer = 0, y As Integer = 0
        Dim a As Integer
        playMove = 1
        maxScore = runMax2(table, depth, player, playMove, 65, heuristic)
        'for extra cousion, must never be 0
        If playMove = 0 Then playMove = 1
        'goto bestMove and play
        For a = 1 To playMove
            nextMove(table, x, y, player)
        Next
        'play the move
        flipPosition(table, x, y, player)
    End Function

    'return maximum value from all children, create recourse calls to runMin2()
    Private Function runMax2(ByVal table As c_table, ByVal depth As Integer, ByVal player As Integer, ByRef playMove As Integer, ByVal beta As Integer, ByVal heuristic As Integer) As Integer
        Dim tempMove As Integer = 0             'temp value of next legal move
        Dim bestMoveCounter As Integer = 0      'best move counter
        Dim bestMove As Integer = 0             'best move
        Dim tempRank As Integer = 0             'temp rank of child
        Dim bestRank As Integer = -65           'best rank for this instance
        Dim x As Integer = 0, y As Integer = 0  'position for this instance
        Dim alpha As Integer = -65
        Dim cutOff As Boolean = False
        'set default return value for runMax2()
        runMax2 = -65
        playMove = 1
        'check depth of recourse call
        If depth > 0 Then
            'get next move rank, legal move
            tempMove = nextMove(table, x, y, player)
            While tempMove > 0 And cutOff = False
                'check if nextMove() return with legal move, or none (=0)
                If tempMove > 0 Then
                    bestMoveCounter += 1
                    'create new table for next call
                    Dim newTable As New c_table(table)
                    'play this turn of player at position x,y
                    flipPosition(newTable, x, y, player)
                    'call runMin() for children
                    tempRank = runMin2(newTable, depth - 1, otherPlayer(player), bestRank, heuristic)
                    alpha = tempRank
                    If beta < alpha Then
                        cutOff = True
                        cutOffCounter += 1
                    End If
                    'cutOff = False
                    'return from recourse call, check rank value
                    If tempRank > bestRank Then
                        'better value then current,replace it and set the best move
                        bestMove = bestMoveCounter
                        playMove = bestMove
                        bestRank = tempRank
                    End If
                    'add random pick between equal values
                    If tempRank = bestRank And Int(Rnd() * 2) = 0 Then
                        bestMove = bestMoveCounter
                        playMove = bestMove
                        bestRank = tempRank
                    End If

                End If
                tempMove = nextMove(table, x, y, player)
            End While
        Else
            'leaf, get heuristic for up-recourse updates
            If heuristic = 0 Then
                bestRank = Heuristic1(table, player)
            Else
                bestRank = Heuristic2(table, player)
            End If
            leafCounter += 1
        End If
        'check if no legal move for this depth, set to be the first move back to previous call
        If playMove = 0 Then playMove = 1
        'set return value
        runMax2 = bestRank
    End Function

    'return minimum value from all children, create recourse calls to runMax2()
    Private Function runMin2(ByVal table As c_table, ByVal depth As Integer, ByVal player As Integer, ByVal alpha As Integer, ByVal heuristic As Integer) As Integer
        'writeTable("runMin2_" & Str(depth) & "_" & Str(player), table)
        Dim tempMove As Integer = 0             'temp value of next legal move
        Dim bestMoveCounter As Integer = 0      'best move counter
        Dim bestMove As Integer = 0             'best move
        Dim tempRank As Integer = 0             'temp rank of child
        Dim bestRank As Integer = 65             'best rank for this instance(small is good)
        Dim x As Integer = 0, y As Integer = 0  'position for this instance
        Dim beta As Integer = 65
        Dim cutOff As Boolean = False
        'set default return value for runMax2()
        runMin2 = 65
        'check depth of recourse call
        If depth > 0 Then
            'get next move rank, legal move
            tempMove = nextMove(table, x, y, player)
            If cutOff = True Then cutOffCounter += 1
            While tempMove > 0 And cutOff = False
                'check if nextMove() return with legal move, or none (=0)
                If tempMove > 0 Then
                    bestMoveCounter += 1
                    'create new table for next call
                    Dim newTable As New c_table(table)
                    'play this turn of player at position x,y
                    flipPosition(newTable, x, y, player)
                    'call runMin() for children
                    tempRank = runMax2(newTable, depth - 1, otherPlayer(player), 0, bestRank, heuristic)
                    beta = tempRank
                    If beta < alpha Then
                        cutOff = True
                        cutOffCounter += 1
                    End If
                    'cutOff = False
                    'return from recourse call, check rank value
                    If tempRank < bestRank Then
                        'better value then current,replace it and set the best move
                        bestMove = bestMoveCounter
                        bestRank = tempRank
                    End If
                    'add random pick between equal values
                    If tempRank = bestRank And Int(Rnd() * 2) = 0 Then
                        bestMove = bestMoveCounter
                        bestRank = tempRank
                    End If
                End If
                tempMove = nextMove(table, x, y, player)
            End While
        End If
        'set return value
        runMin2 = bestRank
    End Function


    Private Function Heuristic1(ByVal table As c_table, ByVal player As Integer) As Integer
        'dif between players score
        Heuristic1 = getPlayerScore(table, player) - getPlayerScore(table, otherPlayer(player))
    End Function

    Private Function Heuristic2(ByVal table As c_table, ByVal player As Integer) As Integer
        Dim a, b, heuristic_1_value As Integer
        heuristic_1_value = Heuristic1(table, player)
        For a = 1 To 8
            For b = 1 To 8
                If checkPosition(table, a, b, player) > 0 Then
                    'check for 4 far point on board
                    If (a = 1 And b = 1) Or (a = 8 And b = 1) Or (a = 1 And b = 8) Or (a = 8 And b = 8) Then
                        heuristic_1_value += 5
                    Else
                        'check for borders
                        If a = 1 Or a = 8 Or b = 1 Or b = 8 Then
                            Heuristic2 += 2
                        End If
                    End If
                End If
            Next
        Next
    End Function

End Class
