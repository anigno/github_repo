unit DemoDlp;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, UCalc, ExtCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Image1: TImage;
    Label3: TLabel;
    Button2: TButton;
    Label4: TLabel;
    Edit2: TEdit;
    Edit7: TEdit;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Label13: TLabel;
    Edit8: TEdit;
    Edit9: TEdit;
    Edit10: TEdit;
    Label14: TLabel;
    Label15: TLabel;
    Label16: TLabel;
    Edit11: TEdit;
    Combo1: TComboBox;
    Combo2: TComboBox;
    Combo3: TComboBox;
    Combo4: TComboBox;
    Label1: TLabel;
    Label2: TLabel;
    Label5: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    Label12: TLabel;
    Label17: TLabel;
    Label8: TLabel;
    procedure CartesianLineTo(a: Variant; b: Variant);
    procedure PopulateComboBoxes;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  H, W: Variant; { Image1 Height and Width }

function InStr(start: Longint; text1, text2: string): Longint;
function PreParseInStr: Longint;
function ucalcAverage: Extended;
function ucalcInStr: Extended;
function ucalcLeft: Extended;
function ucalcLength: Extended;
function ucalcSum: Extended;

implementation

{$R *.DFM}

procedure TForm1.CartesianLineTo(a: Variant; b: Variant);
var
  x, y: Integer;
begin
  x := W * (a + 10) / 20;
  y := H * (2 - b) / 4;
  Image1.Canvas.LineTo(x, y);
end;

procedure TForm1.PopulateComboBoxes;
begin
  Combo1.Items.Add('3+4/5-8');
  Combo1.Items.Add('5*(((10+3)!-1) MOD 7)^2');
  Combo1.Items.Add('#b1101 OR #b1010');
  Combo1.Items.Add('#hAE.B1 * #b1110.1001');
  Combo1.Items.Add('');
  Combo1.Items.Add('// sum(), average(), InStr()');
  Combo1.Items.Add('// Left() and Length() are');
  Combo1.Items.Add('// defined in the source code.');
  Combo1.Items.Add('//See DEMODLPH.PAS');
  Combo1.Items.Add('');
  Combo1.Items.Add('sum(x^2+5,1,10)');
  Combo1.Items.Add('sum(2y-3,1,10,,y)');
  Combo1.Items.Add('sum(x+10,2,5,.5)');
  Combo1.Items.Add('average(5,min(2,5),8)-max(2,5,10,11)');
  Combo1.Items.Add('Length("String Length")');
  Combo1.Items.Add('Left("Hello there", 6) + "World"');
  Combo1.Items.Add('InStr("This is my string","my")');
  Combo1.Items.Add('InStr(10,"This is my string","i")');

  Combo2.Items.Add('MyVariable = 100');
  Combo2.Items.Add('MyString = "This is my string" ');

  Combo3.Items.Add('area(length,width)=length*width');
  Combo3.Items.Add('frac(x)=abs(abs(x)-int(abs(x)))');
  Combo3.Items.Add('shl[x,y] = x * 2^y');

  Combo4.Items.Add('MyVariable*area(5,10)+max(5,9,3)');
  Combo4.Items.Add('frac(150/17)');
  Combo4.Items.Add('#b01101 shl 1');
  Combo4.Items.Add('Length(MyString)');
  Combo4.Items.Add('InStr(MyString, "is")');
end;

// Demonstrates the use of the one-step ucEvalStr() function.
procedure TForm1.Button1Click(Sender: TObject);
begin
  try
    Edit1.Text := ucEvalStr(Combo1.Text);
    if ucError <> 0 then Application.MessageBox(ucErrorMessage, 'Error', IDOK);
  except
    on EOverflow do Application.MessageBox('Overflow', 'Error', IDOK);
  end;
end;

// Demonstrates the use of ucEvaluate() in a loop.
// An equation given by the user is plotted.
procedure TForm1.Button2Click(Sender: TObject);
var
  x: Extended;
  UserEq, VariableX: Longint;
begin
  Image1.Canvas.FillRect(ClientRect);
  VariableX := ucDefineVariable('x');
  UserEq := ucParse(Edit7.Text);

  W := Image1.Width;
  H := Image1.Height;
  x := -10;

  Image1.Canvas.MoveTo(0, H/2);

  while x <= 10 do
  begin
    ucSetVariableValue(VariableX, x);
    CartesianLineTo(x, ucEvaluate(UserEq));
    x := x + 0.5;
  end;

  ucReleaseExpr;
end;

// Defines a variable at runtime
procedure TForm1.Button3Click(Sender: TObject);
begin
  ucDefineVariable(Combo2.Text);
  if ucError <> 0 then Application.MessageBox(ucErrorMessage, 'Error', IDOK);
end;

// Defines a function or operator at runtime
procedure TForm1.Button4Click(Sender: TObject);
begin
  ucDefineFunction(Combo3.Text);
  if ucError <> 0 then Application.MessageBox(ucErrorMessage, 'Error', IDOK);
end;

// Example using the one-step ucEvalStr() function.
procedure TForm1.Button5Click(Sender: TObject);
begin
  try
    Edit2.Text := ucEvalStr(Combo4.Text);
    if ucError <> 0 then Application.MessageBox(ucErrorMessage, 'Error', IDOK);
  except
    on EOverflow do Application.MessageBox('Overflow', 'Error', IDOK);
  end;
end;

// This example demonstrates the speed of the parser
// by calculating the summation of a user-given expression.
procedure TForm1.Button6Click(Sender: TObject);
var
  x, Sum: Extended;
  Code: Integer;
  UserEq, VariableX, finalValue: Longint;
  TimerStart, Elapsed: TDateTime;
  HourStr, MSecStr: string;
  Hour, Min, Sec, MSec: Word;
begin
  Edit10.Text := '';
  Edit10.Refresh;

  TimerStart := Time;
  val(Edit9.Text, finalValue, Code);

  VariableX := ucDefineVariable('x');
  UserEq := ucParse(Edit8.Text);

  x := 1;
  Sum := 0;
  while x <= finalValue do
  begin
    ucSetVariableValue(VariableX, x);
    Sum := Sum + ucEvaluate(UserEq);
    x := x + 1;
  end;

  Elapsed := Time - TimerStart;
  DecodeTime(Elapsed, Hour, Min, Sec, MSec);
  Str(Sec, HourStr);
  Str(MSec, MSecStr);

  Edit10.Text := HourStr + '.' + MSecStr + ' sec / ' + FormatFloat('#', Sum);
  ucReleaseExpr;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Image1.Canvas.Rectangle(0, 0, Image1.Width, Image1.Height);
  PopulateComboBoxes;

  ucDefineFunction('Average()', Longword( @ucalcAverage ));
  ucDefineFunction('InStr(start,text1$,text2$)', Longword( @ucalcInStr ));
  ucDefineFunction('Left$(text$,length)', Longword( @ucalcLeft ));
  ucDefineFunction('Length(text$)', Longword( @ucalcLength ));
  ucDefineFunction('Sum(Expr&,start,finish,step=1,var@=x)', Longword( @ucalcSum ));

  ucPreParse('InStr', Longword( @PreParseInStr ));
end;

// InStr is a function familiar to BASIC programmers which
// returns the position of one string within another.
function InStr(start: Longint; text1, text2: string): Longint;
var
  TmpString: string;
begin
  TmpString := copy(text1,Start,Length(text1)-Start+1);
  InStr := Pos(text2, TmpString)+Start-1;
end;

function PreParseInStr: Longint;
var
  string1, string2: string;
begin
  if ucParamCount = 2 then
  begin
    string1 := ucGetParamStr(1);
    string2 := ucGetParamStr(2);

    ucSetParamStr(1, '1');
    ucSetParamStr(2, string1);
    ucSetParamStr(3, string2);
  end;

  if (ucParamCount < 2) or (ucParamCount > 3) then
  begin
    ucSetError := 12;
    ucSetErrorData(0,'InStr');
  end;
end;

function ucalcInStr: Extended;
begin
  ucalcInStr := InStr(Trunc(ucParam[1]), ucParamStr(2), ucParamStr(3));
end;

function ucalcLeft: Extended;
begin
  ucSetParamStr(0, copy(ucParamStr(1), 1, Trunc(ucParam[2])));
end;

function ucalcLength: Extended;
begin
    ucalcLength := Length(ucParamStr(1));
end;

function ucalcSum: Extended;
var
  ExpressionPtr, VariablePtr: Longint;
  x, sstep, Start, Finish, Total: Extended;
begin
  ExpressionPtr := Trunc(ucParam[1]);
  Start := ucParam[2];
  Finish := ucParam[3];
  sstep := ucParam[4];
  VariablePtr := Trunc(ucParam[5]);

  Total := 0;
  x := Start;

  while x <= Finish do
  begin
    ucSetVariableValue(VariablePtr, x);
    Total := Total + ucEvaluate(ExpressionPtr);
    x := x + sstep;
  end;

  ucalcSum := Total;
end;

function ucalcAverage: Extended;
var
  x: Longint;
  Total: Extended;
begin
  Total := 0;
  for x := 1 to ucParamCount do Total := Total + ucParam[x];
  ucalcAverage := Total / ucParamCount;
end;

end.
