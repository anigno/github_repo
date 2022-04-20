unit EqSolve;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, UCalc;

type
  TForm1 = class(TForm)
    ComboBox1: TComboBox;
    Button1: TButton;
    Edit2: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

procedure swap(var a: Extended; var b: Extended);
function Solve: Extended;
function ChangeEqualSign: Longint;

implementation

{$R *.DFM}

procedure TForm1.FormCreate(Sender: TObject);
begin
  ucDefineFunction('Solve(Expr&, a=-1000, b=1000, var@=x)', Longword(@Solve));
  ucPreParse('SOLVE', Longword(@ChangeEqualSign));
  ucDefineVariable('pi = 3.14');

  ComboBox1.Items.Add('SOLVE(x^2 = 25)');
  ComboBox1.Items.Add('SOLVE(x^2-3x-10, -50, 0)');
  ComboBox1.Items.Add('Solve(2x-8 = x+6)');
  ComboBox1.Items.Add('Solve(COS(x) = 0, pi, 2pi)');
  ComboBox1.Items.Add('10*Solve(3y-54 = 6,,,y)');
  ComboBox1.Items.Add('3+Solve(x^2 = Solve(x/2 = 128))');
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  Edit2.Text := ucEvalStr(ComboBox1.Text);
  if ucError <> 0 then Application.MessageBox(ucErrorMessage, 'Error', MB_OK);
end;

procedure swap(var a: Extended; var b: Extended);
var
  temp: Extended;
begin
  temp := a;
  a := b;
  b := temp;
end;

function Solve: Extended;
var
  a, b, fa, fb: Extended;
  ExpressionPtr, VariablePtr, Iterations: Longint;
begin
  Iterations := 0;
  ExpressionPtr := Trunc(ucParam[1]);
  a := ucParam[2];
  b := ucParam[3];
  VariablePtr := Trunc(ucParam[4]);

  ucSetVariableValue(VariablePtr, a); fa := ucEvaluate(ExpressionPtr);
  ucSetVariableValue(VariablePtr, b); fb := ucEvaluate(ExpressionPtr);
  if fb < fa Then swap(a, b);

  while (Abs(b - a) > 1E-18) and (Iterations < 100) do
  begin
    ucSetVariableValue(VariablePtr, (a + b) / 2);
    if ucEvaluate(ExpressionPtr) < 0
       then a := (a + b) / 2
       else b := (a + b) / 2;
    Iterations := Iterations + 1;
  end;

  Solve := a;

  if Abs(ucEvaluate(ExpressionPtr)) > 1E-10 then
  begin
    ucSetError := 1;
    ucSetErrorData(0, 'Solution Not Found');
  end;
end;

{ The following PreParse function allows the equation to use the "=" sign.
 It basically changes the equation by subtracting the other side.  For
 instance, "2x+5 = x+1" is changed to "2x+5 - (x+1)" }
function ChangeEqualSign: Longint;
var
  Equation: string;
  Equal, L: Longint;
begin
  Equation := ucGetParamStr(1);
  Equal := Pos('=', Equation);
  L := Length(Equation);
  if Equal <> 0 then Equation := Copy(Equation, 1, Equal - 1) + '-(' + Copy(Equation, Equal + 1, L) + ')';
  ucSetParamStr(1, Equation);
end;

end.
