<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.mMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.miFile = New System.Windows.Forms.MenuItem()
        Me.miFileNew = New System.Windows.Forms.MenuItem()
        Me.miFileOpen = New System.Windows.Forms.MenuItem()
        Me.miFileSave = New System.Windows.Forms.MenuItem()
        Me.miFileSaveAs = New System.Windows.Forms.MenuItem()
        Me.miFileExit = New System.Windows.Forms.MenuItem()
        Me.miLanguage = New System.Windows.Forms.MenuItem()
        Me.miLanguageC = New System.Windows.Forms.MenuItem()
        Me.miLanguageJava = New System.Windows.Forms.MenuItem()
        Me.miLanguageSQL = New System.Windows.Forms.MenuItem()
        Me.miLanguageText = New System.Windows.Forms.MenuItem()
        Me.miSettings = New System.Windows.Forms.MenuItem()
        Me.miSettingsMode = New System.Windows.Forms.MenuItem()
        Me.miModeNote = New System.Windows.Forms.MenuItem()
        Me.miModeAssignment = New System.Windows.Forms.MenuItem()
        Me.statusBar = New System.Windows.Forms.StatusStrip()
        Me.iconList = New System.Windows.Forms.ImageList(Me.components)
        Me.miFileClose = New System.Windows.Forms.MenuItem()
        Me.statusVersion = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusBlank = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusAuthor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'mMenu
        '
        Me.mMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFile, Me.miLanguage, Me.miSettings})
        '
        'miFile
        '
        Me.miFile.Index = 0
        Me.miFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miFileNew, Me.miFileOpen, Me.miFileSave, Me.miFileSaveAs, Me.miFileClose, Me.miFileExit})
        Me.miFile.Text = "&File"
        '
        'miFileNew
        '
        Me.miFileNew.Index = 0
        Me.miFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.miFileNew.Text = "&New"
        '
        'miFileOpen
        '
        Me.miFileOpen.Index = 1
        Me.miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.miFileOpen.Text = "&Open"
        '
        'miFileSave
        '
        Me.miFileSave.Index = 2
        Me.miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.miFileSave.Text = "&Save"
        '
        'miFileSaveAs
        '
        Me.miFileSaveAs.Index = 3
        Me.miFileSaveAs.Text = "Save &As ..."
        '
        'miFileExit
        '
        Me.miFileExit.Index = 5
        Me.miFileExit.Text = "&Exit"
        '
        'miLanguage
        '
        Me.miLanguage.Index = 1
        Me.miLanguage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miLanguageC, Me.miLanguageJava, Me.miLanguageSQL, Me.miLanguageText})
        Me.miLanguage.Text = "&Language"
        '
        'miLanguageC
        '
        Me.miLanguageC.Index = 0
        Me.miLanguageC.RadioCheck = True
        Me.miLanguageC.Text = "&C"
        '
        'miLanguageJava
        '
        Me.miLanguageJava.Index = 1
        Me.miLanguageJava.RadioCheck = True
        Me.miLanguageJava.Text = "&Java"
        '
        'miLanguageSQL
        '
        Me.miLanguageSQL.Index = 2
        Me.miLanguageSQL.RadioCheck = True
        Me.miLanguageSQL.Text = "&Oracle SQL"
        '
        'miLanguageText
        '
        Me.miLanguageText.Index = 3
        Me.miLanguageText.RadioCheck = True
        Me.miLanguageText.Text = "&Text"
        '
        'miSettings
        '
        Me.miSettings.Index = 2
        Me.miSettings.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miSettingsMode})
        Me.miSettings.Text = "&Settings"
        '
        'miSettingsMode
        '
        Me.miSettingsMode.Index = 0
        Me.miSettingsMode.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miModeNote, Me.miModeAssignment})
        Me.miSettingsMode.Text = "&Mode"
        '
        'miModeNote
        '
        Me.miModeNote.Index = 0
        Me.miModeNote.RadioCheck = True
        Me.miModeNote.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftN
        Me.miModeNote.Text = "&Note Taking"
        '
        'miModeAssignment
        '
        Me.miModeAssignment.Index = 1
        Me.miModeAssignment.RadioCheck = True
        Me.miModeAssignment.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftA
        Me.miModeAssignment.Text = "&Assignment"
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusVersion, Me.statusBlank, Me.statusAuthor})
        Me.statusBar.Location = New System.Drawing.Point(0, 215)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(314, 22)
        Me.statusBar.TabIndex = 0
        Me.statusBar.Text = "StatusStrip1"
        '
        'iconList
        '
        Me.iconList.ImageStream = CType(resources.GetObject("iconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iconList.TransparentColor = System.Drawing.Color.Transparent
        Me.iconList.Images.SetKeyName(0, "iconC.png")
        Me.iconList.Images.SetKeyName(1, "iconJava.png")
        Me.iconList.Images.SetKeyName(2, "iconSQL.png")
        '
        'miFileClose
        '
        Me.miFileClose.Index = 4
        Me.miFileClose.Text = "&Close"
        '
        'statusVersion
        '
        Me.statusVersion.Name = "statusVersion"
        Me.statusVersion.Size = New System.Drawing.Size(45, 17)
        Me.statusVersion.Text = "Ver. 1.0"
        '
        'statusBlank
        '
        Me.statusBlank.Name = "statusBlank"
        Me.statusBlank.Size = New System.Drawing.Size(158, 17)
        Me.statusBlank.Spring = True
        '
        'statusAuthor
        '
        Me.statusAuthor.Name = "statusAuthor"
        Me.statusAuthor.Size = New System.Drawing.Size(65, 17)
        Me.statusAuthor.Text = "Carl Kuang"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 237)
        Me.Controls.Add(Me.statusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mMenu
        Me.Name = "Main"
        Me.Text = "The Story Here"
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mMenu As System.Windows.Forms.MainMenu
    Friend WithEvents miFile As System.Windows.Forms.MenuItem
    Friend WithEvents miFileNew As System.Windows.Forms.MenuItem
    Friend WithEvents miFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents miFileSave As System.Windows.Forms.MenuItem
    Friend WithEvents miFileSaveAs As System.Windows.Forms.MenuItem
    Friend WithEvents miFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents miLanguage As System.Windows.Forms.MenuItem
    Friend WithEvents miLanguageC As System.Windows.Forms.MenuItem
    Friend WithEvents miLanguageJava As System.Windows.Forms.MenuItem
    Friend WithEvents miLanguageSQL As System.Windows.Forms.MenuItem
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents miSettings As System.Windows.Forms.MenuItem
    Friend WithEvents miSettingsMode As System.Windows.Forms.MenuItem
    Friend WithEvents miModeNote As System.Windows.Forms.MenuItem
    Friend WithEvents miModeAssignment As System.Windows.Forms.MenuItem
    Friend WithEvents miLanguageText As System.Windows.Forms.MenuItem
    Friend WithEvents iconList As System.Windows.Forms.ImageList
    Friend WithEvents miFileClose As System.Windows.Forms.MenuItem
    Friend WithEvents statusVersion As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusBlank As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusAuthor As System.Windows.Forms.ToolStripStatusLabel

End Class
