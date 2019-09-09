Public Class Options
    Private Sub btnBrowse1_Click(sender As Object, e As EventArgs) Handles btnBrowse1.Click
        If (fbdXML.ShowDialog() = DialogResult.OK) Then
            txtXMLdir.Text = fbdXML.SelectedPath
        End If
    End Sub

    Private Sub btnBrowse2_Click(sender As Object, e As EventArgs) Handles btnBrowse2.Click
        If (fbdMeta.ShowDialog() = DialogResult.OK) Then
            txtMetaDir.Text = fbdMeta.SelectedPath
        End If
    End Sub

    Private Sub btnBrowse3_Click(sender As Object, e As EventArgs) Handles btnBrowse3.Click
        If (fbdMeta.ShowDialog() = DialogResult.OK) Then
            txtNavDir.Text = fbdMeta.SelectedPath
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    End Sub

End Class