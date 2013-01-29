Imports System.Windows.Forms

Public Class NewFileDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub NewFileDialog_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        fileName.Text = ""
        fileName.Focus()
    End Sub

    Private Sub NewFileDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fileType.SelectedIndex = 0
    End Sub
End Class
