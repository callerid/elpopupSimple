Imports System.Windows.Forms

Public Class DialogSettings
    Private annoying As Boolean = False
    Private annoyanceCount As Integer = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        My.Settings.URL = tbURL.Text
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbURL.Text = My.Settings.URL
    End Sub

    Private Sub tbURL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbURL.Enter, tbURL.Click
        If Not annoying Then
            annoyanceCount = annoyanceCount + 1
            If annoyanceCount > 4 Then annoying = True
            tbURL.SelectionStart = 0
            tbURL.SelectionLength = tbURL.Text.Length
        End If
    End Sub
End Class
