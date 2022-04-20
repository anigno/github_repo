Attribute VB_Name = "mdlFunctions"
Option Explicit

Public Sub ExpandLeaf(ByRef TV As TreeView, ByRef leaf As Node)
    Dim FSO As New FileSystemObject
    Dim FLDR As Folder
    Dim iFILE As File
    Dim tNode As Node
    Dim leafFullPath As String
    'fix for drive leter like c: only
    If Len(leaf.FullPath) = 2 Then
        leafFullPath = leaf.Text & "\"
    Else
        leafFullPath = leaf.FullPath
    End If
    If FSO.FolderExists(leafFullPath) = True Then
        'expand the leaf folders
        For Each FLDR In FSO.GetFolder(leafFullPath).SubFolders
            Set tNode = TV.Nodes.Add(leaf, tvwChild, , FLDR.Name, 2, 1)
            tNode.Tag = "FOLDER"
        Next FLDR
        'expand the leaf files
        For Each iFILE In FSO.GetFolder(leafFullPath).Files
            Set tNode = TV.Nodes.Add(leaf, tvwChild, , iFILE.Name, 3, 3)
            tNode.Tag = "FILE"
        Next iFILE
    End If
End Sub
