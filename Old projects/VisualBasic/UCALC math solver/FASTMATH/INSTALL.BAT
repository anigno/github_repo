@echo off
echo .
echo UCalc Fast Math Parser 2.0
echo Copyright (c) 1998-1999 by Daniel Corbier.  All Rights reserved.
echo Web site: http://www.ucalc.com/mathparser   E-mail: support@ucalc.com
echo .
echo This batch file will simply copy UCALC32.DLL to the \Windows\System
echo directory.  If you would like to manually copy this file to another
echo directory, you may do so after breaking out of this batch file with
echo Ctrl-C.  The DLL is ready to use as-is without having to be placed
echo in the Windows registry.
echo .
pause
copy ucalc32.dll \windows\system
