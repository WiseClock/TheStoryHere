Imports TheStoryHere.tshEditor.lang
Imports TheStoryHere.tshEditor.mode
Imports System.IO

Public Class Main

    Private editorTabs As tshTabControl

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        For Each t As tshTabs In editorTabs.TabPages
            editorTabs.SelectTab(t)
            If Not t.close Then
                e.Cancel = True
            End If
        Next
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each mi As MenuItem In miLanguage.MenuItems
            Dim m As MenuItem = mi
            AddHandler mi.Click, Sub() selectLang(m)
        Next
        editorTabs = New tshTabControl
        Controls.Add(editorTabs)
        editorTabs.BringToFront()
        AddHandler editorTabs.Selected, AddressOf tabpageChanged
        tabpageChanged()
        Me.Width = 600
        Me.Height = 700
        CenterToScreen()
    End Sub

    Private Sub miModeNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModeNote.Click
        miModeNote.Checked = True
        miModeAssignment.Checked = False
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).modeUsing = Note
    End Sub

    Private Sub miModeAssignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miModeAssignment.Click
        miModeNote.Checked = False
        miModeAssignment.Checked = True
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).modeUsing = Assignment
    End Sub

    Private Sub tabpageChanged()
        miModeNote.Checked = (CType(editorTabs.SelectedTab.Controls(0), tshEditor).modeUsing = Note)
        miModeAssignment.Checked = (CType(editorTabs.SelectedTab.Controls(0), tshEditor).modeUsing = Assignment)
        For Each item As MenuItem In miLanguage.MenuItems
            item.Checked = False
        Next
        Select Case (CType(editorTabs.SelectedTab.Controls(0), tshEditor).langUsing)
            Case C
                miLanguageC.Checked = True
            Case Java
                miLanguageJava.Checked = True
            Case SQL
                miLanguageSQL.Checked = True
            Case TXT
                miLanguageText.Checked = True
        End Select
    End Sub

    Private Sub selectLang(ByRef mi As MenuItem)
        For Each item As MenuItem In miLanguage.MenuItems
            item.Checked = False
        Next
        mi.Checked = True
    End Sub

    Private Sub miLanguageC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLanguageC.Click
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).langUsing = C
    End Sub

    Private Sub miLanguageJava_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLanguageJava.Click
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).langUsing = Java
    End Sub

    Private Sub miLanguageSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLanguageSQL.Click
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).langUsing = SQL
    End Sub

    Private Sub miLanguageText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLanguageText.Click
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).langUsing = TXT
    End Sub

    Private Sub miFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileExit.Click
        Close()
    End Sub

    Private Sub miFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileNew.Click
        Dim result As DialogResult = NewFileDialog.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            Dim tab As tshTabs = New tshTabs(NewFileDialog.fileName.Text)
            If NewFileDialog.radioNote.Checked Then
                CType(tab.Controls(0), tshEditor).modeUsing = Note
            Else
                CType(tab.Controls(0), tshEditor).modeUsing = Assignment
            End If
            CType(tab.Controls(0), tshEditor).langUsing = NewFileDialog.fileType.SelectedIndex
            editorTabs.TabPages.Add(tab)
            editorTabs.SelectTab(tab)
            If editorTabs.TabPages.Count = 2 AndAlso
               CType(editorTabs.TabPages(0), tshTabs).isSaved AndAlso
               CType(editorTabs.TabPages(0), tshTabs).path = "" Then
                editorTabs.TabPages.RemoveAt(0)
            End If
        End If
    End Sub

    Private Sub miFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileSave.Click
        CType(editorTabs.SelectedTab, tshTabs).save()
    End Sub

    Private Sub miFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileSaveAs.Click
        CType(editorTabs.SelectedTab, tshTabs).saveAs()
    End Sub

    Private Sub miFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileOpen.Click
        Dim fd As OpenFileDialog = New OpenFileDialog
        fd.Filter = "All supported extensions|*.c;*.java;*.sql;*.txt|C|*.c|Java|*.java|SQL|*.sql|Text|*.txt|*.*|*.*"
        fd.Multiselect = True
        fd.DefaultExt = "txt"
        Dim result As DialogResult = fd.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            For i = 0 To fd.FileNames.Length - 1
                Dim fileName As String = fd.SafeFileNames(i)
                Dim filePath As String = fd.FileNames(i)
                Dim sr As StreamReader = New StreamReader(filePath, System.Text.Encoding.Default)
                Dim fileContent As String = sr.ReadToEnd
                sr.Close()
                sr.Dispose()
                Dim t As tshTabs = New tshTabs(fileName, filePath)
                CType(t.Controls(0), tshEditor).Text = fileContent
                Dim splits As String() = fileName.Split(".")
                Dim ext As String = splits(splits.Length - 1).ToLower
                If ext = "txt" Then
                    CType(t.Controls(0), tshEditor).modeUsing = Note
                Else
                    If ext = "c" Then
                        CType(t.Controls(0), tshEditor).langUsing = C
                    ElseIf ext = "java" Then
                        CType(t.Controls(0), tshEditor).langUsing = Java
                    ElseIf ext = "sql" Then
                        CType(t.Controls(0), tshEditor).langUsing = SQL
                    End If
                    CType(t.Controls(0), tshEditor).modeUsing = Assignment
                End If
                editorTabs.TabPages.Add(t)
                editorTabs.SelectTab(t)
                If editorTabs.TabPages.Count = 2 AndAlso
                   CType(editorTabs.TabPages(0), tshTabs).isSaved AndAlso
                   CType(editorTabs.TabPages(0), tshTabs).path = "" Then
                    editorTabs.TabPages.RemoveAt(0)
                End If
            Next
        End If
    End Sub

    Private Sub miFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFileClose.Click
        Dim result As Boolean = CType(editorTabs.SelectedTab, tshTabs).close()
        If result Then
            If editorTabs.TabPages.Count = 1 Then
                editorTabs.TabPages.Add(New tshTabs)
            End If
        End If
        editorTabs.TabPages.RemoveAt(editorTabs.SelectedIndex)
        CType(editorTabs.SelectedTab.Controls(0), tshEditor).Focus()
    End Sub
End Class
