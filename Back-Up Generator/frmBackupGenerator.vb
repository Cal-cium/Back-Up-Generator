Imports System.IO
Public Class frmBackupGenerator
    Dim FolderDirectory As New Hashtable
    Dim MainFolder As String
    Dim lstAllFiles As New List(Of String)
    Dim lstDirectories As New List(Of String)
    Dim CountMarker As Integer = 0

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        'Check textboxes aren't empty
        If txtFolderBackup.Text = "" OrElse txtMainFolder.Text = "" Then
            MessageBox.Show("Please fill in all boxes!", "User Error ")
        Else
            MainFolder = txtMainFolder.Text
            Dim count As Integer = 0
            FolderDirectory.Add(count, txtFolderBackup.Text)

            lstAllFiles.AddRange(Directory.GetFiles(MainFolder))

            'copy files that are in the primary folder
            CopyFiles(count)

            'Add directories
            lstDirectories.AddRange(Directory.GetDirectories(MainFolder))

            'start the loop to search through all the folders and back up them
            'foldermarker is used to keep track of folder locations, especially useful as this uses recursion, as the foldermarker keeps track of folder layout
            Dim FolderMarker As Integer = 0
            For Each folder In lstDirectories
                CopyDirectories(folder, count, FolderMarker)
            Next

            'Clear all lists and count, so program is ok to run again
            lstAllFiles.Clear()
            lstDirectories.Clear()
            FolderDirectory.Clear()
            count = 0
            CountMarker = 0
            txtFolderBackup.Text = ""
            txtMainFolder.Text = ""
            cbNoOverwrite.Checked = False

            MessageBox.Show("All files are backed up!", "Completed")

        End If

    End Sub

#Region "Methods"
    ''' <summary>
    ''' This is a method that copies files in the chosen directory into the backup location
    ''' </summary>
    ''' <param name="count">This parameter is used to pick the correct folder directory when copying files over</param>
    ''' <remarks></remarks>
    Sub CopyFiles(ByVal count As Integer)
        Try
            'For each file in folder grab information about that file.
            For Each File In lstAllFiles
                Dim FileInfo As New FileInfo(File)
                Dim Filename As String = FileInfo.Name
                Dim FileLocation As String = FileInfo.FullName
                Dim FileDate As Date = FileInfo.LastWriteTime

                'If the backup folder contains the file already, compare dates on file and if newer overwrite
                If System.IO.File.Exists(Path.Combine(CStr(FolderDirectory(count)), Filename)) Then
                    Dim TempFileinfo As New FileInfo(Path.Combine(CStr(FolderDirectory(count)), Filename))
                    Dim TempFileDate As Date = TempFileinfo.LastWriteTime
                    Dim result As Integer = DateTime.Compare(FileDate, TempFileDate)
                    'if result is less than 0 then the file is earlier than the backed up file, if result equals 0 then they are the same, 
                    'if result is more than 0 then the file newer than the backuped file, so file needs to be copied over if newer
                    'Only overwrite file over if checkbox is not ticked, this way only files that are not previously there will get copied across
                    If result > 0 AndAlso cbNoOverwrite.Checked = False Then
                        System.IO.File.Copy(FileLocation, Path.Combine(CStr(FolderDirectory(count)), Filename), True)
                    End If
                Else
                    'file does not already exist so copy over
                    System.IO.File.Copy(FileLocation, Path.Combine(CStr(FolderDirectory(count)), Filename))
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Something went wrong. " & ex.ToString, "Data error ")
        End Try
    End Sub
    ''' <summary>
    ''' This sub copies folder directories over to the backup location and uses recursion to call itself so that it looks at directories in itself and also calls CopyFiles to copy the files over in those directories
    ''' </summary>
    ''' <param name="Folder">This parameter holds the folder location</param>
    ''' <param name="count">This parameter holds the count used to add more directories into the hashtable and used so that it creates a unique ID for each folder</param>
    ''' <param name="FolderMarker">this parameter is used a marker so that it adds the correct folder directory path</param>
    ''' <remarks></remarks>
    Sub CopyDirectories(ByVal Folder As String, ByVal count As Integer, ByVal FolderMarker As Integer)
        Try
            'Check if folder exists in backup and if it doesnt copy entire folder over
            'if folder exists then go through each folder and copy files/folders over
            'use recursion to call 
            Dim FolderInfo As New DirectoryInfo(Folder)
            Dim Folderlocation As String = FolderInfo.FullName
            Dim FolderName As String = FolderInfo.Name
            Dim lstTempFolderDirectories As New List(Of String)
            lstTempFolderDirectories.AddRange(Directory.GetDirectories(Folderlocation))

            'if the folder does not exist then copy folder and contents over otherwise read through contents and update if necassary
            If Directory.Exists(Path.Combine(CStr(FolderDirectory(count)), FolderName)) Then
                lstAllFiles.Clear()
                lstAllFiles.AddRange(Directory.GetFiles(Folderlocation))

                'Loop until the count is higher than the countmarker so that the count is a new number and that the FolderDirectory doesnt try to add a directory in a used key
                Do Until count > CountMarker
                    count += 1
                Loop
                CountMarker = count

                'Add directory to hashtable
                FolderDirectory.Add((count), (Path.Combine(CStr(FolderDirectory(FolderMarker)), FolderName)))

                'Add 1 to the foldermarker here
                FolderMarker += 1

                'Copy files in this directory over
                CopyFiles(count)

                If lstTempFolderDirectories.Contains(Nothing) Then
                Else
                    'Use recursion to call this same subroutine so that it can go through each subfolders
                    For Each Folder In lstTempFolderDirectories
                        CopyDirectories(Folder, count, FolderMarker)
                    Next
                End If
            Else
                'if folder does not exist then copy over whole of the directory including everything inside it
                My.Computer.FileSystem.CopyDirectory(Folderlocation, Path.Combine(CStr(FolderDirectory(FolderMarker)), FolderName))
            End If

        Catch ex As Exception
            MessageBox.Show("Something went wrong. " & ex.ToString, "Data error ")
        End Try
    End Sub
#End Region
End Class
