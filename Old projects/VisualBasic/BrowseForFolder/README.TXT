Browse for Folder Module for Visual Basic
cam@codearchive.com

=============================================================================

This is a Visual Basic module which will allow you to invoke the standard
Windows dialog used for browsing for a folder. It has been tested with
Visual Basic 4 (32-bit) and Visual Basic 6.

1) Call the SetDefaults sub.

2) (Optional) Set the boolean values as appropriate.
      bComputer True = allow browse for computer (def False)
      bPrinter True = allow browse for printer (def False)
      bFiles True = show files in tree (def False)
      bNotBelowDomain = ?? (def True)
      bEdit True = include an edit box to manually enter a path (def False)
      bAncestors True = allow browse for file system ancestors (def False)
      bDirectories True = allow only file system directories (def True)
      bValidate True = validate text in edit box before close (def True)

3) Call the Display sub
   It takes two parameters.
   hWnd As Long - The handle of the calling form, or zero
   windowTitle As String - The text that appears near the top of the dialog

4) When Display returns, check these members.
      successful As Boolean - Indicates if a folder was found or the
                              user canceled
      folderName As String - The name of the folder found
