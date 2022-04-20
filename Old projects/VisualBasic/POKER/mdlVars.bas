Attribute VB_Name = "mdlVars"
Option Explicit

Type cardType
    cNum As Integer
    cType As Integer
    cMark As Boolean        'marked for change or give
    imageIndex  As Integer  'the imgCard index
    grade As Integer        'card grade for impostance, used for changing and betting
    value As Integer        'leading value of the grade
End Type

Type playerType
    name As String
    card(5) As cardType
    money As Long
    bet As Long
    cardsMarked As Integer  'counter for player marked cards
    totalGrade As Long
    leadCard1 As Integer
    leadCard2 As Integer
    leadCard3 As Integer
    maxBet As Long
    inGame As Boolean
    CheatFactor As Integer
End Type

Public deckNextCard As Integer          'an index for the upper card in the deck, start from 1 until 52+12
Public deckNextLowerCard As Integer     'an index for the lower card in the deck, start from 53 until 52+12
Public cardData(52) As cardType
Public deckCard(52) As cardType
Public player(4) As playerType          '1 to 3 is computer, 4 is humen player
Public playerCoin As Integer            'player use coin (inc,dec bet)
Public lastCardMoved As Integer         'used to keep the mark of acard if been moved
Public gameState As Integer             'game state: start,deal cards,change cards,bets,end
'Public currentPlayer As Integer         'current player(1 to 4) playing
Public bettingPlayer As Integer
Public lastRoundPlayerBetFirst
Public timerCounter As Integer          'used to count players bet for each round
