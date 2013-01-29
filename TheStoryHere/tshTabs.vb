Imports TheStoryHere.tshEditor.mode
Imports TheStoryHere.tshEditor.lang
Imports System.IO

Public Class tshTabs
    Inherits TabPage

    Friend editor As tshEditor = New tshEditor()
    Friend isSaved As Boolean = True
    Friend path As String = ""

    Friend Sub New(Optional ByVal fileName As String = "Untitled", Optional ByVal filePath As String = "")
        MyBase.New()
        Dock = DockStyle.Fill
        Text = If(fileName = "", "Untitled", fileName)
        ToolTipText = Text
        Controls.Add(editor)
        ImageIndex = -1
        If editor.modeUsing = Note Then
            Text = "N: " + Text
        Else
            Text = "A: " + Text
        End If
        path = filePath
        GC.Collect()
    End Sub

    Friend Function close() As Boolean
        If Not isSaved Then
            Dim result As DialogResult = MessageBox.Show("Do you want to save?", "Not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                Return save()
            ElseIf result = DialogResult.Cancel Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub tshTabs_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        GC.Collect()
    End Sub

    Friend Function save() As Boolean
        If path = "" Then
            Return saveAs()
        End If
        Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
        sw.Write(CType(Controls(0), tshEditor).Text)
        sw.Close()
        sw.Dispose()
        isSaved = True
        Parent.Refresh()
        Return True
    End Function

    Friend Function saveAs() As Boolean
        Dim fd As SaveFileDialog = New SaveFileDialog
        fd.FileName = Text.Substring(3, Text.Length - 3)
        fd.Filter = "C|*.c|Java|*.java|SQL|*.sql|Text|*.txt"
        fd.DefaultExt = "txt"
        Select Case editor.langUsing
            Case C
                fd.FilterIndex = 1
            Case Java
                fd.FilterIndex = 2
            Case SQL
                fd.FilterIndex = 3
            Case TXT
                fd.FilterIndex = 4
        End Select
        Dim result As DialogResult = fd.ShowDialog
        If result = DialogResult.OK Then
            path = fd.FileName
            Dim t As String = path.Substring(path.LastIndexOf("\") + 1)
            Dim splits As String() = t.Split(".")
            Dim ext As String = splits(splits.Length - 1).ToLower
            Select Case ext
                Case "txt"
                    editor.langUsing = TXT
                    editor.modeUsing = Note
                    t = "N: " + t
                Case "java"
                    editor.modeUsing = Assignment
                    editor.langUsing = Java
                    t = "A: " + t
                Case "c"
                    editor.modeUsing = Assignment
                    editor.langUsing = C
                    t = "A: " + t
                Case "sql"
                    editor.modeUsing = Assignment
                    editor.langUsing = SQL
                    t = "A: " + t
            End Select
            Text = t
            ToolTipText = Text
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            sw.Write(CType(Controls(0), tshEditor).Text)
            sw.Close()
            sw.Dispose()
            isSaved = True
            Parent.Refresh()
            Return True
        End If
        Return False
    End Function

End Class
