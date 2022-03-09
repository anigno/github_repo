rem @echo off
assoc .logz=LogViewerZipFile
assoc .sum=LogViewerZipFile
assoc .lv=LogViewerZipFile
assoc .logsource=LogViewerZipFile
assoc .1=LogViewerZipFile
cd>temp.txt
SET/P CUR_DIR=<temp.txt
del temp.txt
SET EXE_PATH=%CUR_DIR%\LogViewer4Net.exe
ftype LogViewerZipFile="%EXE_PATH%" "%%1"
XXMKLink "%USERPROFILE%\SendTo\LogViewer" "%EXE_PATH%"
