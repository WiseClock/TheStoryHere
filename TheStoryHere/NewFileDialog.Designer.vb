<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewFileDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fileName = New System.Windows.Forms.TextBox()
        Me.radioNote = New System.Windows.Forms.RadioButton()
        Me.radioAssignment = New System.Windows.Forms.RadioButton()
        Me.fileType = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(18, 84)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name:"
        '
        'fileName
        '
        Me.fileName.Location = New System.Drawing.Point(56, 6)
        Me.fileName.Name = "fileName"
        Me.fileName.Size = New System.Drawing.Size(100, 20)
        Me.fileName.TabIndex = 2
        '
        'radioNote
        '
        Me.radioNote.AutoSize = True
        Me.radioNote.Checked = True
        Me.radioNote.Location = New System.Drawing.Point(15, 32)
        Me.radioNote.Name = "radioNote"
        Me.radioNote.Size = New System.Drawing.Size(80, 17)
        Me.radioNote.TabIndex = 3
        Me.radioNote.TabStop = True
        Me.radioNote.Text = "Note taking"
        Me.radioNote.UseVisualStyleBackColor = True
        '
        'radioAssignment
        '
        Me.radioAssignment.AutoSize = True
        Me.radioAssignment.Location = New System.Drawing.Point(101, 32)
        Me.radioAssignment.Name = "radioAssignment"
        Me.radioAssignment.Size = New System.Drawing.Size(79, 17)
        Me.radioAssignment.TabIndex = 4
        Me.radioAssignment.Text = "Assignment"
        Me.radioAssignment.UseVisualStyleBackColor = True
        '
        'fileType
        '
        Me.fileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fileType.FormattingEnabled = True
        Me.fileType.Items.AddRange(New Object() {"C", "Java", "SQL", "Plain Text"})
        Me.fileType.Location = New System.Drawing.Point(15, 55)
        Me.fileType.Name = "fileType"
        Me.fileType.Size = New System.Drawing.Size(161, 21)
        Me.fileType.TabIndex = 5
        '
        'NewFileDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(187, 125)
        Me.Controls.Add(Me.fileType)
        Me.Controls.Add(Me.radioAssignment)
        Me.Controls.Add(Me.radioNote)
        Me.Controls.Add(Me.fileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewFileDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fileName As System.Windows.Forms.TextBox
    Friend WithEvents radioNote As System.Windows.Forms.RadioButton
    Friend WithEvents radioAssignment As System.Windows.Forms.RadioButton
    Friend WithEvents fileType As System.Windows.Forms.ComboBox

End Class
