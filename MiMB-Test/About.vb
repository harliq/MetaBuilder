Public Class About
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click

    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "Version " & Me.GetType.Assembly.GetName.Version.ToString
    End Sub
End Class