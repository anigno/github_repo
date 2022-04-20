Attribute VB_Name = "mdlFunctions"
Option Explicit

Public Function getRandom(a As Integer) As Integer
    getRandom = Int(Rnd * a)
End Function

Public Sub initcards(imgCard As Variant)
    Dim cNum As Integer, cType As Integer
    Dim cName As String, cReference As String, cFileName As String
    Dim a As Integer
    a = 1
    For cType = 1 To 4
        For cNum = 2 To 14
            Select Case cType
                Case 1
                    cName = "club"
                Case 2
                    cName = "diamond"
                Case 3
                    cName = "heart"
                Case 4
                    cName = "spade"
            End Select
            Select Case cNum
                Case 14
                    cReference = "A"
                Case 2 To 10
                    cReference = Trim(Str(cNum))
                Case 11
                    cReference = "J"
                Case 12
                    cReference = "Q"
                Case 13
                    cReference = "K"
            End Select
            cFileName = cName & cReference
            imgCard(a).Picture = LoadPicture(App.Path & "\cards pictures\" & cFileName & ".gif")
            cardData(a).cNum = cNum
            cardData(a).cType = cType
            cardData(a).cMark = False
            cardData(a).imageIndex = a
            cardData(a).grade = 0
            cardData(a).value = 0
            a = a + 1
            DoEvents
        Next cNum
    Next cType
    'load all cards to deck
    For a = 1 To 52
        deckCard(a) = cardData(a)
    Next a
    deckNextCard = 1
    deckNextLowerCard = 53
End Sub

Public Sub mixDeck()
    Dim r1 As Integer, r2 As Integer, a As Integer
    Dim tCard As cardType
    Randomize
    'mix the cards
    For a = 1 To 400
        r1 = Int(Rnd * 52) + 1
        r2 = Int(Rnd * 52) + 1
        'will switch cards places
        tCard = deckCard(r1)
        deckCard(r1) = deckCard(r2)
        deckCard(r2) = tCard
    Next a
End Sub

'will replace any marked card in player [iPlayer] cards (give or change)
Public Sub deckToPlayer(iPlayer As Integer)
    Dim a As Integer
    'will search for marked cards in player to put the card from deck
    For a = 1 To 5
        If player(iPlayer).card(a).cMark = True Then
            'give or change player card
            player(iPlayer).card(a) = deckCard(deckNextCard)
            'set the cMark flag to false
            player(iPlayer).card(a).cMark = False
            'inc deck index
            deckNextCard = deckNextCard + 1
            DoEvents
        End If
      Next a
End Sub

'will deal cards to all players
Public Sub dealCards()
    Dim a As Integer, b As Integer
    For a = 1 To 4
            deckToPlayer a
    Next a
End Sub

Public Sub initPlayers()
    Dim a As Integer, b As Integer
    For a = 1 To 4
        player(a).inGame = True
        player(a).bet = 0
        player(a).inGame = True
        For b = 1 To 5
            'set for card to be change
            player(a).card(b).cMark = True
            'set the players cards picture to 53, cardCover.gif
            player(a).card(b).imageIndex = 53
            'set marked cards counter to 0
            player(a).cardsMarked = 0
            'set the card grade to 0
            player(a).card(b).grade = 0
        Next b
    Next a
End Sub

Sub givePLayersMoney()
    Dim a As Integer
    For a = 1 To 4
        player(a).money = 200
    Next a
End Sub

'init cards,init players
Sub startGame(imgCard As Variant)
    Dim a As Integer
    initcards imgCard
    initPlayers
    timerCounter = 0
End Sub

'transfer money [fee] from player [iPlayer] .money to players .bet
Public Sub playerPay(iPlayer As Integer, ByVal fee As Integer)
    player(iPlayer).bet = player(iPlayer).bet + fee
    player(iPlayer).money = player(iPlayer).money - fee
End Sub

'computer players pay
Public Sub computerPlayersPay(ByVal fee As Integer)
    Dim a As Integer
    For a = 1 To 3
        playerPay a, fee
    Next a
End Sub

'set players totalGrade for the cards and mark cards for change
Public Sub setPlayerCardsGrade(cPlayer As Integer)
    Dim a As Integer, b As Integer
    Dim tCard As cardType
    Dim num(5) As Integer
    Dim foundHand As Boolean
    'sort cards
    For a = 1 To 5
        For b = 1 To a
            If player(cPlayer).card(a).cNum > player(cPlayer).card(b).cNum Then
                tCard = player(cPlayer).card(a)
                player(cPlayer).card(a) = player(cPlayer).card(b)
                player(cPlayer).card(b) = tCard
            End If
        Next b
    Next a
    'init player vars
    player(cPlayer).leadCard1 = 0
    player(cPlayer).leadCard2 = 0
    player(cPlayer).leadCard3 = 0
    player(cPlayer).totalGrade = 0
    For a = 1 To 5
        player(cPlayer).card(a).cMark = False
    Next a
    
    
'player(cPlayer).card(1).cNum = 14
'player(cPlayer).card(1).cType = 1
'player(cPlayer).card(2).cNum = 9
'player(cPlayer).card(2).cType = 1
'player(cPlayer).card(3).cNum = 8
'player(cPlayer).card(3).cType = 1
'player(cPlayer).card(4).cNum = 7
'player(cPlayer).card(4).cType = 1
'player(cPlayer).card(5).cNum = 6
'player(cPlayer).card(5).cType = 1
    
    
    'copy cards cNums
    For a = 1 To 5
        num(a) = player(cPlayer).card(a).cNum
    Next a

    
    'search for full poker
    If num(1) = num(2) + 1 And _
       num(1) = num(3) + 2 And _
       num(1) = num(4) + 3 And _
       num(1) = num(5) + 4 Then
       If player(cPlayer).card(1).cType = player(cPlayer).card(2).cType And _
          player(cPlayer).card(1).cType = player(cPlayer).card(3).cType And _
          player(cPlayer).card(1).cType = player(cPlayer).card(4).cType And _
          player(cPlayer).card(1).cType = player(cPlayer).card(5).cType _
          Then
        player(cPlayer).totalGrade = 120
        foundHand = True
        End If
    End If
    If foundHand = True Then GoTo haveHand
    
    'check for same shape
    If player(cPlayer).card(1).cType = player(cPlayer).card(2).cType And _
       player(cPlayer).card(1).cType = player(cPlayer).card(3).cType And _
       player(cPlayer).card(1).cType = player(cPlayer).card(4).cType And _
       player(cPlayer).card(1).cType = player(cPlayer).card(5).cType _
       Then
       player(cPlayer).totalGrade = 95
       foundHand = True
    End If
    If foundHand = True Then GoTo haveHand
    
    'check for inc seria
    If num(1) = num(2) + 1 And num(1) = num(3) + 2 And num(1) = num(4) + 3 And num(1) = num(5) + 4 Then
        player(cPlayer).totalGrade = 75
        foundHand = True
    End If
    If foundHand = True Then GoTo haveHand
    
        

    
    If foundHand = True Then GoTo haveHand
    'search for four
    If num(1) = num(2) And num(1) = num(3) And num(1) = num(4) Then
        player(cPlayer).totalGrade = 100
        player(cPlayer).leadCard1 = num(1)
        foundHand = True
        'card change set
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(5).cMark = True
        End If
    End If
    If num(2) = num(3) And num(2) = num(4) And num(2) = num(5) Then
        player(cPlayer).totalGrade = 100
        foundHand = True
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(1).cMark = True
        End If
    End If
    If foundHand = True Then GoTo haveHand
    
    'search for three
    For a = 1 To 3
        If num(a) = num(a + 1) And num(a) = num(a + 2) Then
            player(cPlayer).totalGrade = 80
            player(cPlayer).leadCard1 = num(a)
            b = a
            foundHand = True
        End If
    Next a
        'check for full house
        If b = 1 Then
            If getRandom(player(cPlayer).CheatFactor) <> 0 Then
                player(cPlayer).card(4).cMark = True
            End If
            If getRandom(player(cPlayer).CheatFactor) <> 0 Then
                player(cPlayer).card(5).cMark = True
            End If
            If num(4) = num(5) Then
                player(cPlayer).totalGrade = 90
                player(cPlayer).card(4).cMark = False
                player(cPlayer).card(5).cMark = False
            End If
        End If
        If b = 3 Then
            If getRandom(player(cPlayer).CheatFactor) <> 0 Then
                player(cPlayer).card(1).cMark = True
            End If
            If getRandom(player(cPlayer).CheatFactor) <> 0 Then
                player(cPlayer).card(2).cMark = True
            End If
            If num(1) = num(2) Then
                player(cPlayer).totalGrade = 90
                player(cPlayer).card(1).cMark = False
                player(cPlayer).card(2).cMark = False
            End If
        End If
    If foundHand = True Then GoTo haveHand
    
    'search for double two
    If num(1) = num(2) And num(3) = num(4) Then
        player(cPlayer).totalGrade = 70
        player(cPlayer).leadCard1 = num(1)
        player(cPlayer).leadCard2 = num(3)
        player(cPlayer).leadCard3 = num(5)
        foundHand = True
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(5).cMark = True
        End If
     End If
    If num(1) = num(2) And num(4) = num(5) Then
        player(cPlayer).totalGrade = 70
        player(cPlayer).leadCard1 = num(1)
        player(cPlayer).leadCard2 = num(4)
        player(cPlayer).leadCard3 = num(3)
        foundHand = True
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(3).cMark = True
        End If
    End If
    If num(2) = num(3) And num(4) = num(5) Then
        player(cPlayer).totalGrade = 70
        player(cPlayer).leadCard1 = num(2)
        player(cPlayer).leadCard2 = num(4)
        player(cPlayer).leadCard3 = num(1)
        foundHand = True
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(1).cMark = True
        End If
    End If
    If foundHand = True Then GoTo haveHand
    
    'search for two
    For a = 1 To 4
        If num(a) = num(a + 1) Then
            b = a
            player(cPlayer).totalGrade = 60
            player(cPlayer).leadCard1 = num(a)
            foundHand = True
        End If
    Next a
    If b = 1 Then
        player(cPlayer).leadCard2 = num(3)
        player(cPlayer).leadCard3 = num(4)
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(3).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(4).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(5).cMark = True
        End If
    End If
    If b = 2 Then
        player(cPlayer).leadCard2 = num(1)
        player(cPlayer).leadCard3 = num(4)
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(1).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(4).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(5).cMark = True
        End If
    End If
    If b = 3 Then
        player(cPlayer).leadCard2 = num(1)
        player(cPlayer).leadCard3 = num(2)
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(1).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(2).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(5).cMark = True
        End If
    End If
    If b = 4 Then
        player(cPlayer).leadCard2 = num(1)
        player(cPlayer).leadCard3 = num(2)
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(1).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(2).cMark = True
        End If
        If getRandom(player(cPlayer).CheatFactor) <> 0 Then
            player(cPlayer).card(3).cMark = True
        End If
    End If
    If foundHand = True Then GoTo haveHand
    'nothing at all
    player(cPlayer).card(3).cMark = True
    player(cPlayer).card(4).cMark = True
    player(cPlayer).card(5).cMark = True
haveHand:
    frmMain.List1.AddItem player(cPlayer).totalGrade & " " & _
        player(cPlayer).leadCard1 & " " & _
        player(cPlayer).leadCard2 & " " & _
        player(cPlayer).leadCard2
End Sub

Public Sub countMarkedCards(cPlayer As Integer, iLabel As Variant)
    Dim a As Integer
    Dim cnt As Integer
    For a = 1 To 5
        If player(cPlayer).card(a).cMark = True Then
            cnt = cnt + 1
        End If
    Next a
    iLabel(cPlayer).Caption = "Changed " & Str(cnt)
End Sub

Public Sub checkWinner(imgWinnerCard As Variant, lblWinner As Label, imgCard As Variant)
    Dim bestGradePlayer As Integer
    Dim a As Integer
    'zero players that out of game
    For a = 1 To 4
        If player(a).inGame = False Then player(a).totalGrade = 0
    Next a
    'check for bestHandPlayer
    bestGradePlayer = 1
    For a = 2 To 4
        If player(a).totalGrade * 1000 + player(a).leadCard1 * 100 + player(a).leadCard2 * 10 > _
         player(bestGradePlayer).totalGrade * 1000 + player(bestGradePlayer).leadCard1 * 100 + player(bestGradePlayer).leadCard2 * 10 Then
            bestGradePlayer = a
        End If
    Next a
    'give money to player
    For a = 1 To 4
            player(bestGradePlayer).money = player(bestGradePlayer).money + player(a).bet
    Next a
    'show results
    For a = 1 To 5
        imgWinnerCard(a).Picture = imgCard(player(bestGradePlayer).card(a).imageIndex)
    Next a
    lblWinner.Caption = "player " & bestGradePlayer
End Sub
