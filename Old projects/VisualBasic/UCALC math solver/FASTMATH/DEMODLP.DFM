�
 TFORM1 0�  TPF0TForm1Form1Left?TopEWidth6HeightzCaption(UCalc Fast Math Parser 2.0 demonstrationColor	clBtnFaceFont.CharsetDEFAULT_CHARSET
Font.ColorclWindowTextFont.Height�	Font.NameMS Sans Serif
Font.Style OldCreateOrderOnCreate
FormCreatePixelsPerInch`
TextHeight TImageImage1Left Top0Width� HeightY  TLabelLabel3Left TopWidth� HeightCaption"Example using ucEvaluate in a loopFont.CharsetDEFAULT_CHARSET
Font.ColorclWindowTextFont.Height�	Font.NameMS Sans Serif
Font.StylefsUnderline 
ParentFont  TLabelLabel4Left8Top� Width� HeightCaption2Examples with user-defined variables and functionsFont.CharsetDEFAULT_CHARSET
Font.ColorclWindowTextFont.Height�	Font.NameMS Sans Serif
Font.StylefsUnderline 
ParentFont  TLabelLabel13LeftTop Width�HeightCaption�-------------------------------------------------------------------------------------------------------------------------------------------------------------------------  TLabelLabel14Left� Top0WidthNHeightCaptionUser expression:  TLabelLabel15Left� TopHWidthmHeightCaptionElapsed time / Answer:  TLabelLabel16LeftTopHWidthcHeightCaptionSummation from 1 to:  TLabelLabel1LeftTopWidth*HeightCaptionCombo1:  TLabelLabel2LeftTop� Width*HeightCaptionCombo2:  TLabelLabel5LeftTop� Width*HeightCaptionCombo3:  TLabelLabel6LeftTop� Width*HeightCaptionCombo4:  TLabelLabel7LeftTopWidthHeightCaptionEdit2:  TLabelLabel9LeftTop0WidthHeightCaptionEdit1:  TLabelLabel10LeftToppWidthHeightCaption8Source code ---->  Edit1.Text := ucEvalStr(Combo1.Text);  TLabelLabel11LeftpTop� Width� HeightCaptionucDefineVariable(Combo2.Text);  TLabelLabel12LeftpTop� Width� HeightCaptionucDefineFunction(Combo3.Text);  TLabelLabel17LeftpTop� Width� HeightCaption%Edit2.Text := ucEvalStr(Combo4.Text);  TLabelLabel8Left8TopWidth� HeightCaption&Example using the one-step ucEvalStr()Font.CharsetDEFAULT_CHARSET
Font.ColorclWindowTextFont.Height�	Font.NameMS Sans Serif
Font.StylefsUnderline 
ParentFont  TEditEdit1Left8Top0Width� HeightTabOrder Text(result)  TButtonButton1Left8TopPWidthIHeightCaption	CalculateTabOrderOnClickButton1Click  TButtonButton2Left�TopWidth)HeightCaptionPlotTabOrderOnClickButton2Click  TEditEdit2Left8TopWidth� HeightTabOrderText(result)  TEditEdit7Left TopWidth� HeightTabOrderText	-sin(x)/2  TButtonButton3LeftTop� WidthYHeightCaptionDefine VariableTabOrderOnClickButton3Click  TButtonButton4LeftTop� WidthYHeightCaptionDefine FunctionTabOrderOnClickButton4Click  TButtonButton5LeftTop� WidthYHeightCaption	CalculateTabOrderOnClickButton5Click  TButtonButton6Left� Top0Width+HeightCaptionStartTabOrderOnClickButton6Click  TEditEdit8LeftHTop0Width� HeightTabOrder	Text	x^2+5x-10  TEditEdit9LeftxTopHWidthAHeightTabOrder
Text100000  TEditEdit10LeftHTopHWidth� HeightTabOrder  TEditEdit11LeftTop0Width� HeightBiDiModebdLeftToRightColorclAquaCtl3DEnabledFont.CharsetDEFAULT_CHARSET
Font.ColorclWindowTextFont.Height�	Font.NameMS Sans Serif
Font.StylefsBold ParentBiDiModeParentCtl3D
ParentFontReadOnly	TabOrderText           Speed Test  	TComboBoxCombo1Left8TopWidth� Height
ItemHeightTabOrderText3+4/5-8  	TComboBoxCombo2Left8Top� Width� Height
ItemHeightTabOrderTextMyVariable = 100  	TComboBoxCombo3Left8Top� Width� Height
ItemHeightTabOrderTextarea(length,width)=length*width  	TComboBoxCombo4Left8Top� Width� Height
ItemHeightTabOrderText MyVariable*area(5,10)+max(5,9,3)   