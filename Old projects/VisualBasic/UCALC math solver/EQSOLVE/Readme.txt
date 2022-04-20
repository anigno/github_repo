     Equation Solver code for VB, Delphi, and C++ Builder.
           For use with UCalc Fast Math Parser 2.0

Simply open one of the project files for the compiler you are using, and run
the program.  Then analyze the source code to see how it works.

UCalc Fast Math Parser allows you to evaluate expressions.  But how about if
you want to actually solve an equation (find the roots, or zeros), not just
evaluate it?  For instance, let's say you wanted to solve:

x^2-3x-10 = 0

for x, in order to get -2 or 5 as the result.  There is no built-in SOLVE
function for the parser, but fortunately, one can easily be added.

One convenient way to do it would be to implement the Bisection Method
algorithm as a callback function for the parser.  The Bisection Method
algorithm is simple and straightforward.  A good calculus book, or an
Internet search may reveal an explanation of this method, and the special
case of the Intermediate Value Theorem.  The algorithm implemented in VB
code would look something like this:

If f(b) < f(a) Then swap a, b
Do While abs(b - a) > SmallNumber
    x = (a + b) / 2
    If f(x) < 0 Then a = (a + b) / 2 Else b = (a + b) / 2
Loop

where f(x) is your function, [a, b] is the interval in which to find a possible
solution, and SmallNumber is a number close enough to 0.

Now the next step is to implement this as a function that you can use with the
parser in an expression such as: 

5+SOLVE(x^2-3x-10)

There is a key feature in UCalc Fast Math Parser, without which this would seem
like an impossible task.  If you defined a function named SOLVE() using a
regular argument, then your callback function would receive a numeric value,
which wouldn't be of much use in this situation.  However, UCalc Fast Math
Parser allows you to pass an argument of expression type.  Instead of passing
the literal result of "x^2-3x-10" as a numeric value for instance, you can have
it parse the argument, and return the pointer to the expression that was
parsed.  This allows you to operate on the expression itself.

However, you would also need a way to manipulate the variable(s) in your
expressions.  So the parser allows you to pass arguments of variable type as
well.  The callback function would receive a variable pointer unique to the
callback routine.  A variable passed this way is local to the function call,
so it does not have to be defined beforehand, and it also does not affect the
value of variables of the same name, which may have already been defined.  If
you will generally be using "x" as the variable name, you can define the
argument as optional, by setting "x" as the default value.  In VB, you would
define your function with the following line (the actual callback function is
listed further down):

ucDefineFunction "SOLVE(Equation&, VariableName@=x)", AddressOf Solve

The & symbol indicates that the argument is passed as an expression pointer,
and @ indicates that the argument is passed as a variable pointer (an index
actually).

You can add other arguments to the SOLVE() function to make it more flexible.
For instance, SOLVE(x^2-3x-10) has two possible solutions, so you may want to
add two more arguments to mark the interval to search in, so that 

SOLVE(x^2-3x-10, 0, 50)

for instance, would search between 0 and 50, and it would find 5 as the result,

SOLVE(x^2-3x-10, -50, 0)

would search between -50 and 0, and return -2.  So the improved definition line
looks like this:

ucDefineFunction "Solve(Expr&, a=-100, b=100, var@=x)", AddressOf Solve

A simple preparser routine was added in a separate callback function, in order
to allow the equation to have an "=" sign.  The right side of the equation is
simply turned into a subtraction from the left side.  For instance,
"2x+5 = x+1" is changed to "2x+5 - (x+1)".  The preparsing routine is defined
with this line in VB:

ucPreParse "SOLVE", AddressOf ChangeEqualSign

Once implemented, the equation solver will allow you to evaluate expressions
such as the following:

"SOLVE(x^2 = 25)"
"SOLVE(x^2-3x-10, -50, 0)"
"Solve(2x-8 = x+6)"
"Solve(COS(x) = 0, pi, 2pi)"  ' Assuming pi is defined beforehand
"10*Solve(3y-54 = 6,,,y)"
"3+Solve(x^2 = Solve(x/2 = 128)) "

Here is the code for the routines that should be added to your module.  (From
the VB menu, select Project / Add Module / New , and place the following code
in the new module):

[CODE]
Sub swap(ByRef a As Double, ByRef b As Double)
    temp = a: a = b: b = temp
End Sub

Function Solve() As Double
    Dim ExpressionPtr As Long, VariablePtr As Long
    Dim a As Double, b As Double, Iterations As Long
    Dim fa As Double, fb As Double

    ExpressionPtr = ucParam(1)
    a = ucParam(2)
    b = ucParam(3)
    VariablePtr = ucParam(4)
    
    ucVariableValue(VariablePtr) = a: fa = ucEvaluate(ExpressionPtr)
    ucVariableValue(VariablePtr) = b: fb = ucEvaluate(ExpressionPtr)
    If fb < fa Then swap a, b
    
    Do While Abs(b - a) > 1E-15
        ucVariableValue(VariablePtr) = (a + b) / 2
        If ucEvaluate(ExpressionPtr) < 0 _
           Then a = (a + b) / 2 _
           Else b = (a + b) / 2
        Iterations = Iterations + 1
        If Iterations = 100 Then Exit Do
    Loop
    
    Solve = a
    
    If Abs(ucEvaluate(ExpressionPtr)) > 1E-10 Then
        ucError = 1
        ucErrorData(0) = "Solution Not Found"
    End If
End Function

Function ChangeEqualSign() As Long
    Dim Equation As String, Equal As Long
    
    Equation = ucParamStr(1)
    Equal = InStr(Equation, "=")
    If Equal Then Equation = Left$(Equation, Equal-1) + "-(" + Mid$(Equation, Equal+1) + ")"
    ucParamStr(1) = Equation
End Function
[/CODE]


Daniel Corbier, UCALC
http://www.ucalc.com
Dancorbier@aol.com