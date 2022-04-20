//---------------------------------------------------------------------------
#include <vcl.h>
#include <stdio.h>
#include <math.h>
#pragma hdrstop

#include "EqSolver.h"
#include "ucalc.cpp"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

long double Solve();
long ChangeEqualSign();
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------
void __fastcall TForm1::FormCreate(TObject *Sender)
{
  ucDefineFunction("Solve(Expr&, a=-1000, b=1000, var@=x)", reinterpret_cast<long>(Solve));
  ucPreParse("SOLVE", reinterpret_cast<long>(ChangeEqualSign));
  ucDefineVariable("pi = 3.14");

  ComboBox1->Items->Add("SOLVE(x^2 = 25)");
  ComboBox1->Items->Add("SOLVE(x^2-3x-10, -50, 0)");
  ComboBox1->Items->Add("Solve(2x-8 = x+6)");
  ComboBox1->Items->Add("Solve(COS(x) = 0, pi, 2pi)");
  ComboBox1->Items->Add("10*Solve(3y-54 = 6,,,y)");
  ComboBox1->Items->Add("3+Solve(x^2 = Solve(x/2 = 128))");
}

void __fastcall TForm1::Button1Click(TObject *Sender)
{
  Edit2->Text = ucEvalStr(ComboBox1->Text.c_str());
  if(ucError()) Application->MessageBox(ucErrorMessage(), "Error", 0);
}
//---------------------------------------------------------------------------
long double Solve()
{
  long double a, b, fa, fb, temp;
  long ExpressionPtr, VariablePtr, Iterations = 0;

  ExpressionPtr = ucParam[1];
  a = ucParam[2];
  b = ucParam[3];
  VariablePtr = ucParam[4];

  ucSetVariableValue(VariablePtr, a); fa = ucEvaluate(ExpressionPtr);
  ucSetVariableValue(VariablePtr, b); fb = ucEvaluate(ExpressionPtr);
  if (fb < fa) { temp = a; a = b; b = temp; } // Swap a, b

  while ((fabsl(b - a) > 1E-18) && (Iterations < 100))
  {
    ucSetVariableValue(VariablePtr, (a + b) / 2);
    if (ucEvaluate(ExpressionPtr) < 0)  a = (a + b) / 2;
    else b = (a + b) / 2;
    Iterations = Iterations + 1;
  }

  if (fabsl(ucEvaluate(ExpressionPtr)) > 1E-10)
  {
    ucSetError = 1;
    ucSetErrorData(0, "Solution Not Found");
  }

  return a;
}

/* The following PreParse function allows the equation to use the "=" sign.
 It basically changes the equation by subtracting the other side.  For
 instance, "2x+5 = x+1" is changed to "2x+5 - (x+1)" */
long ChangeEqualSign()
{
  char Equation[80], NewEquation[80];
  long Equal;

  strcpy(Equation, ucGetParamStr(1));

  if (strstr(Equation, "=") != NULL)
  {
    Equal = strstr(Equation, "=") - Equation+1;
    strcpy(NewEquation, Equation);
    NewEquation[Equal-1] = '\0';
    strcat(NewEquation, "-(");
    strcat(NewEquation, Equation+Equal);
    strcat(NewEquation, ")");

    ucSetParamStr(1, NewEquation);
  }
}
//---------------------------------------------------------------------------
