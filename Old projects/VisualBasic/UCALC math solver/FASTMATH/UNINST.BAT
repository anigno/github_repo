@echo off
echo .
echo UCalc Fast Math Parser 2.0
echo Copyright (c) 1998-1999 by Daniel Corbier.  All Rights reserved.
echo Web site: http://www.ucalc.com/mathparser   E-mail: support@ucalc.com
echo .
echo This batch file will remove UCALC32.DLL from the \Windows\System
echo directory.  If it was copied to a different directory, you will
echo need to delete it manually.  To cancel this procedure, press Ctrl-C.
echo The DLL was not installed in the Windows registry, so no further
echo un-installation is required.
echo .
pause
del \Windows\System\ucalc32.dll
