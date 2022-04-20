// democpp.cpp - UCalc Fast Math Parser 2.0 sample program.
// Designed to work with VC++ and Borland C++ Builder.
//
// Visual C++ Instructions:
// 1. Create a new project as a Win32 Console Application.
// 2. Name the project Test, and start it as an empty project.
// 3. Copy over the following files to the Test directory:
//    ucalc32.dll, ucalc.cpp, ucalc.h, and democpp.cpp.
// 4. Open the democpp.cpp file.
// 5. Place the cursor in the source code box, then click the
//    right mouse button, and select "Insert File Into Project".
// 6. Click on the Execute Program icon.
//
// Borland C++ Builder Instructions:
// 1. From the File menu, select "New...", and then "Console Wizard"
// 2. Click "Finish" (Window Type: Console, Execution Type: EXE).
// 3. Save the project in the directory which contains the sample program.
// 4. Open the file named "democpp.cpp".
// 5. Erase the auto-generated code, and paste in the demo code in its place.
// 6. Click on the Run icon.

#include <iostream>
#include <conio.h>
#include "ucalc.cpp"

using namespace std;

long PreParseInStr();
long double Average();
long double ucalcInStr();
long double ucalcLeft();
long double ucalcSum();
long double ucalcLen();

int main()
{
  char Expression[80];
  long ExpressionPtr;
  long VariableX;
  long double x = 1, Total = 0;

  ucDefineVariable("pi = atn(1) * 4");
  ucDefineVariable("MyVar = pi + 10");
  ucDefineVariable("MyString = 'This is my string' ");
  VariableX = ucDefineVariable("x");

  ucDefineFunction("area(length,width) = length*width");
  ucDefineFunction("shl[x,y] = x * 2^y");
  ucDefineFunction("Average()", reinterpret_cast<long>(Average));
  ucDefineFunction("InStr(start,text1$,text2$)", reinterpret_cast<long>(ucalcInStr));
  ucDefineFunction("Left$(text$,length)", reinterpret_cast<long>(ucalcLeft));
  ucDefineFunction("Sum(Expr&,start,finish,step=1,var@=x)", reinterpret_cast<long>(ucalcSum));
  ucDefineFunction("Len(text$)", reinterpret_cast<long>(ucalcLen));

  ucPreParse("InStr", reinterpret_cast<long>(PreParseInStr));

  ucAlias("StrLen", "Len");

  cout << "Functions defined in the source code: " << endl;
  cout << "  InStr, Left, Sum, Average, Area, and StrLen." << endl << endl;
  cout << "Variables defined in the source code:" << endl;
  cout << "  MyString = 'This is my string' " << endl;
  cout << "  pi = atn(1) * 4 " << endl;
  cout << "  MyVar = pi + 10 " << endl << endl;

  cout << "Enter an expression such as one of the following:" << endl;
  cout << "" << endl;

  cout << "3+4/5-8" << endl;
  cout << "5*(((10+3)!-1) MOD 7)^2 + average(3,4,max(3,5,1),6)" << endl;
  cout << "cos(pi)*10+MyVar-area(3,5)" << endl;
  cout << "#b1101 OR (#b1010 SHL 1) + #hAE.B1 * #b1110.1001" << endl;
  cout << "InStr('This is my string', 'is')" << endl;
  cout << "InStr(5, MyString, 'is')" << endl;
  cout << "Left('Hello there', 6) + 'World'" << endl;
  cout << "10*strlen('abcdef')" << endl;
  cout << "Sum(x^2+5, 1, 10)" << endl;
  cout << "Sum(x - 6, 2, 8, .5)" << endl;
  cout << "Sum(4q+3, 1, 100, , q)" << endl << endl;
 
  cout.precision(16);
  do
  {
    cout << "Enter an expression (or the word 'next' to continue):" << endl;
    cin.getline(Expression, 80, '\n');

    cout << "Answer: " << ucEvalStr(Expression) << endl << endl;

    if ((ucError() != 0) && strcmp(Expression, "next") !=0)    
      cout << ucErrorMessage() << endl << endl;
  } while (strcmp(Expression, "next") !=0);


  // Next example.
  cout << endl << endl;
  cout << "This example demonstrates ucParse, and ucEvaluate." << endl;
  cout << "See the source code." << endl << endl;
  cout << "Enter an expression such as: x^2+5*x+14" << endl;
  cin.getline(Expression, 80, '\n');
 
  ExpressionPtr = ucParse(Expression);
  ucReleaseExpr();

  for(x = 1; x <= 1000; x++)
  {
    ucSetVariableValue(VariableX, x);
    Total = Total + ucEvaluate(ExpressionPtr);
  }
  cout << "The summation from 1 to 1000 is: " << Total << endl << endl;

#if defined(__BORLANDC__)
  cout << "Press any key to continue...";
  getch();
#endif 

  return 0;
}

long PreParseInStr()
{
  char arglist[80];

  if (ucParamCount == 2)
  {
    strcpy(arglist, "1,");
    strcat(arglist, ucParamStr(0));
    ucSetParamStr(0, arglist);
  }

  if ((ucParamCount < 2) || (ucParamCount > 3))
  {
    ucSetError = 12;
    ucSetErrorData(0,"InStr");
  }

 return 0;
}

long double ucalcInStr()
{
  long StartPos;
  long double ReturnValue;
  char MainString[80], SubString[80];
  char *StrPosition;

  StartPos = ucParam[1];
  strcpy(MainString, ucParamStr(2));
  strcpy(SubString, ucParamStr(3));

  StrPosition = strstr(MainString+StartPos-1, SubString);
  if (StrPosition != NULL)
      ReturnValue = StrPosition - MainString + 1;
  else
      ReturnValue = 0;
 
  return ReturnValue;
}

long double ucalcLeft()
{
  char StringValue[80];
  long StringLength;

  strcpy(StringValue, ucGetParamStr(1));
  StringLength = ucParam[2];
  StringValue[StringLength] = '\0';
  ucSetParamStr(0, StringValue);

  return 0;
}

long double ucalcSum()
{
  long ExpressionPtr, VariablePtr;
  long double x, sstep, Start, Finish, Total;

  ExpressionPtr = ucParam[1];
  Start = ucParam[2];
  Finish = ucParam[3];
  sstep = ucParam[4];
  VariablePtr = ucParam[5];

  Total = 0;
  x = Start;

  while (x <= Finish)
  {
    ucSetVariableValue(VariablePtr, x);
    Total = Total + ucEvaluate(ExpressionPtr);
    x = x + sstep;
  }

  return Total;
}

long double Average()
{
  long x = 0;
  long double Total = 0;

  for(x = 1; x <= ucParamCount; x++)
    Total = Total + ucParam[x];

  return Total / ucParamCount;
}

long double ucalcLen()
{
  return strlen(ucParamStr(1));
}
