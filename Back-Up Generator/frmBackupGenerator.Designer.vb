<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupGenerator
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtMainFolder = New System.Windows.Forms.TextBox()
        Me.txtFolderBackup = New System.Windows.Forms.TextBox()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.cbNoOverwrite = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMainFolder
        '
        Me.txtMainFolder.Location = New System.Drawing.Point(6, 19)
        Me.txtMainFolder.Name = "txtMainFolder"
        Me.txtMainFolder.Size = New System.Drawing.Size(432, 20)
        Me.txtMainFolder.TabIndex = 0
        '
        'txtFolderBackup
        '
        Me.txtFolderBackup.Location = New System.Drawing.Point(6, 17)
        Me.txtFolderBackup.Name = "txtFolderBackup"
        Me.txtFolderBackup.Size = New System.Drawing.Size(432, 20)
        Me.txtFolderBackup.TabIndex = 1
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(326, 115)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(130, 23)
        Me.btnBackup.TabIndex = 2
        Me.btnBackup.Text = "Back Up"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'cbNoOverwrite
        '
        Me.cbNoOverwrite.AutoSize = True
        Me.cbNoOverwrite.Location = New System.Drawing.Point(6, 19)
        Me.cbNoOverwrite.Name = "cbNoOverwrite"
        Me.cbNoOverwrite.Size = New System.Drawing.Size(71, 17)
        Me.cbNoOverwrite.TabIndex = 3
        Me.cbNoOverwrite.Text = "Overwrite"
        Me.cbNoOverwrite.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMainFolder)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(444, 48)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main Folder:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFolderBackup)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(444, 43)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Back Up To:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbNoOverwrite)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(291, 56)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Settings:"
        '
        'frmBackupGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 184)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBackup)
        Me.Name = "frmBackupGenerator"
        Me.Text = "Back-Up Generator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtMainFolder As TextBox
    Friend WithEvents txtFolderBackup As TextBox
    Friend WithEvents btnBackup As Button
    Friend WithEvents cbNoOverwrite As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
