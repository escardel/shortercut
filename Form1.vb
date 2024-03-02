Imports System.IO
Imports Microsoft.Win32
Imports Newtonsoft.Json
Imports Shortcutter.Form1

Public Class Form1

    ' Declare imageListIcons at the class level
    Private imageListIcons As New ImageList()
    Private folderPath As String = "C:\Program Shortcuts"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Check if command-line arguments are passed to the application
        Dim args As String() = Environment.GetCommandLineArgs()

        If args.Length > 1 AndAlso args(1).ToLower().EndsWith(".stcrs") Then
            ' The second argument should be the path to the .stcrs file
            Dim filePath As String = args(1)
            ' Load settings from the .stcrs file
            LoadSettingsFromFile(filePath)
        End If

        Try
            ' Define the paths for the folders
            Dim shortcutsFolder As String = "C:\Program Shortcuts"
            Dim gamesFolder As String = Path.Combine(shortcutsFolder, "Games")
            Dim productivityFolder As String = Path.Combine(shortcutsFolder, "Productivity")
            Dim generalFolder As String = Path.Combine(shortcutsFolder, "General")

            ' Check if the folders exist, if not, create them
            If Not Directory.Exists(shortcutsFolder) Then
                Directory.CreateDirectory(shortcutsFolder)
            End If

            If Not Directory.Exists(gamesFolder) Then
                Directory.CreateDirectory(gamesFolder)
            End If

            If Not Directory.Exists(productivityFolder) Then
                Directory.CreateDirectory(productivityFolder)
            End If

            If Not Directory.Exists(generalFolder) Then
                Directory.CreateDirectory(generalFolder)
            End If

        Catch ex As Exception
            ' Inform the user if an error occurs during the folder creation process
            MessageBox.Show("Error creating default folders.  Try reinstalling the software. " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Set the size of the icons in the ImageList
        imageListIcons.ImageSize = New Size(32, 32)

        ' Assign the ImageList to the ListView control
        listViewFiles.LargeImageList = imageListIcons

        LoadFiles(folderPath)

    End Sub
    Private Sub LoadSettingsFromFile(filePath As String)
        Try
            If File.Exists(filePath) Then
                ' Read the JSON data from the file
                Dim json As String = File.ReadAllText(filePath)

                ' Deserialize the JSON data to your settings class
                Dim settings As Settings = JsonConvert.DeserializeObject(Of Settings)(json)

                ' Apply the settings to the application
                Me.Width = settings.WindowWidth
                Me.Height = settings.WindowHeight
                Me.BackColor = settings.BackColor
                ApplyColors(settings.BackColor)
                folderPath = settings.FolderPath ' Update folderPath with the value from settings
                UpdateSelectedFolderLabel()
                LoadFiles(folderPath)
                Me.Invalidate()

            Else
                MessageBox.Show("Settings file not found: " & filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub listViewFiles_MouseClick(sender As Object, e As MouseEventArgs) Handles listViewFiles.MouseClick
        ' Check if the user has clicked the item with the primary mouse button
        If e.Button = MouseButtons.Left AndAlso listViewFiles.SelectedItems.Count > 0 Then
            ' Get the selected item in the ListView
            Dim selectedItem As ListViewItem = listViewFiles.SelectedItems(0)

            ' Get the file name from the selected item
            Dim fileNameWithoutExtension As String = selectedItem.Text

            ' Get the original file extension from the item
            Dim originalExtension As String = Path.GetExtension(selectedItem.Tag.ToString())

            ' Re-add the original file extension to the file name
            Dim fileName As String = fileNameWithoutExtension & originalExtension

            ' Get the full path of the selected file
            Dim filePath As String = Path.Combine(folderPath, fileName)

            ' Check if the file exists before attempting to open it
            If File.Exists(filePath) Then
                Try
                    ' Open the file with the associated application
                    Process.Start(filePath)
                Catch ex As Exception
                    MessageBox.Show("Error opening file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("File not found: " & filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' Resize the ListView control to fill the client area of the form
        listViewFiles.Size = New Size(ClientSize.Width, ClientSize.Height)

        ' Save the window width and height settings
        My.Settings.WindowWidth = Me.Width
        My.Settings.WindowHeight = Me.Height
        My.Settings.Save()
    End Sub


    Private Sub btnChangeFolder_Click(sender As Object, e As EventArgs) Handles btnChangeFolder.Click
        Dim folderBrowserDialog As New FolderBrowserDialog()

        ' Set the initial selected folder to the current folder path, if available
        If Directory.Exists(folderPath) Then
            folderBrowserDialog.SelectedPath = folderPath
        End If

        ' Show the folder browser dialog
        If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
            ' Update the folderPath variable with the user's selection
            folderPath = folderBrowserDialog.SelectedPath

            ' Update the settings with the new folder path
            My.Settings.SelectedFolder = folderPath
            My.Settings.Save()

            ' Update the label to display the new folder path
            UpdateSelectedFolderLabel()

            ' Load files in the selected folder
            LoadFiles(folderPath)
        End If
    End Sub

    Private Sub LoadFiles(folderPath As String)
        ' Clear existing items from the ListView and image list
        listViewFiles.Items.Clear()
        imageListIcons.Images.Clear()
        imageListIcons.ColorDepth = ColorDepth.Depth32Bit

        Try
            ' Get all files in the selected folder
            Dim files As String() = Directory.GetFiles(folderPath)

            ' Add files to the ListView and image list
            For Each file As String In files
                ' Create a new ListViewItem with the file name (without extension)
                Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(file)
                Dim item As New ListViewItem(fileNameWithoutExtension)

                ' Set the Tag property to the file extension
                item.Tag = Path.GetExtension(file)

                ' Add the ListViewItem to the ListView
                listViewFiles.Items.Add(item)

                ' Add the image to the image list
                Dim icon As Icon = Icon.ExtractAssociatedIcon(file)
                imageListIcons.Images.Add(fileNameWithoutExtension, icon)
                item.ImageKey = fileNameWithoutExtension
            Next
        Catch ex As Exception
            ' Handle exceptions, if any
            MessageBox.Show("Error loading files: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateSelectedFolderLabel()
        Label1.Text = Path.GetFileName(folderPath)
    End Sub
    Private Sub ApplyColors(selectedColor As Color)
        ' Set the background color of listViewFiles to the selected color.
        listViewFiles.BackColor = selectedColor
        Me.BackColor = selectedColor

        ' Darken the selected color by 45%.
        Dim darkerColor As Color = ControlPaint.Dark(selectedColor, 0.45)

        ' Set the background color of Panel1 to the darker color.
        Panel1.BackColor = darkerColor
    End Sub
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Reset()
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        ' Create a new instance of the ColorDialog.
        Dim colorDialog As New ColorDialog()

        ' Show the color dialog and check if the user clicked OK.
        If colorDialog.ShowDialog() = DialogResult.OK Then
            ' Get the selected color.
            Dim selectedColor As Color = colorDialog.Color

            ' Save the selected color to settings
            My.Settings.BackColor = selectedColor
            My.Settings.Save()

            ' Apply colors to controls using a separate subroutine
            ApplyColors(selectedColor)
        End If
        ' Create a backup file with the ".stcrs" extension on the desktop
        CreateBackupFile()
        MessageBox.Show("View Settings Updated", "Saved")
    End Sub
    Private Sub CreateBackupFile()
        ' Create a settings object to store backup data
        Dim backupSettings As New Settings()
        backupSettings.WindowWidth = My.Settings.WindowWidth
        backupSettings.WindowHeight = My.Settings.WindowHeight
        backupSettings.SelectedFolder = My.Settings.SelectedFolder
        backupSettings.BackColor = My.Settings.BackColor
        backupSettings.FolderPath = folderPath ' Update to include the folderPath

        ' Convert the settings object to JSON format
        Dim jsonBackup As String = JsonConvert.SerializeObject(backupSettings)

        ' Get the text of Label1
        Dim label1Text As String = Label1.Text

        ' Replace invalid characters in the label text to ensure it's a valid filename
        Dim fileName As String = String.Join("_", label1Text.Split(Path.GetInvalidFileNameChars()))

        ' Save the JSON backup string to a file with the ".stcrs" extension in the Saved Views folder
        Dim savedViewsFolderPath As String = "C:\Program Shortcuts\Saved Views"
        Directory.CreateDirectory(savedViewsFolderPath)
        Dim filePath As String = Path.Combine(savedViewsFolderPath, fileName & ".stcrs")
        File.WriteAllText(filePath, jsonBackup)

        ' Create a shortcut to the backup file on the desktop
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        Dim shortcutPath As String = Path.Combine(desktopPath, fileName & ".lnk")
        Dim shell As Object = CreateObject("WScript.Shell")
        Dim shortcut As Object = shell.CreateShortcut(shortcutPath)
        shortcut.TargetPath = filePath
        shortcut.Save()
    End Sub
    ' Define a class to hold backup settings
    Private Class Settings
        Public Property WindowWidth As Integer
        Public Property WindowHeight As Integer
        Public Property FolderPath As String
        Public Property SelectedFolder As String
        Public Property BackColor As Color
    End Class

End Class
