<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.listViewFiles = New System.Windows.Forms.ListView()
        Me.btnChangeFolder = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'listViewFiles
        '
        Me.listViewFiles.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.listViewFiles.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.listViewFiles.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.listViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.listViewFiles.HideSelection = False
        Me.listViewFiles.Location = New System.Drawing.Point(0, 9)
        Me.listViewFiles.Margin = New System.Windows.Forms.Padding(15)
        Me.listViewFiles.MinimumSize = New System.Drawing.Size(20, 20)
        Me.listViewFiles.MultiSelect = False
        Me.listViewFiles.Name = "listViewFiles"
        Me.listViewFiles.Size = New System.Drawing.Size(450, 341)
        Me.listViewFiles.TabIndex = 0
        Me.listViewFiles.TileSize = New System.Drawing.Size(90, 30)
        Me.listViewFiles.UseCompatibleStateImageBehavior = False
        '
        'btnChangeFolder
        '
        Me.btnChangeFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnChangeFolder.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnChangeFolder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnChangeFolder.Location = New System.Drawing.Point(22, 11)
        Me.btnChangeFolder.Name = "btnChangeFolder"
        Me.btnChangeFolder.Size = New System.Drawing.Size(27, 24)
        Me.btnChangeFolder.TabIndex = 1
        Me.btnChangeFolder.Text = "...\"
        Me.ToolTip1.SetToolTip(Me.btnChangeFolder, "Select Path to Shortcut Folder")
        Me.btnChangeFolder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.5!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(317, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(11, 7, 18, 11)
        Me.Label1.Size = New System.Drawing.Size(176, 47)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Shortcutter"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSettings)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnChangeFolder)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Location = New System.Drawing.Point(-10, 350)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(493, 54)
        Me.Panel1.TabIndex = 4
        '
        'btnSettings
        '
        Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSettings.Location = New System.Drawing.Point(55, 11)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(20, 24)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "↓"
        Me.ToolTip1.SetToolTip(Me.btnSettings, "Save View State to Desktop")
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.Tag = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(471, 395)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.listViewFiles)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.MinimumSize = New System.Drawing.Size(300, 250)
        Me.Name = "Form1"
        Me.Text = "Shortcutter"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listViewFiles As ListView
    Friend WithEvents btnChangeFolder As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSettings As Button
    Friend WithEvents ToolTip1 As ToolTip
End Class
