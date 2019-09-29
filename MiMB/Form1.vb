Public Class frmMain
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub StateTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub StateLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        MessageBox.Show("Before Exit")
        Application.Exit()
        MessageBox.Show("after exit")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCreateState_Click(sender As Object, e As EventArgs) Handles btnCreateState.Click

        'Getting New Meta State from InputBox
        Dim iBoxPrompt As String = String.Empty 'Setting Variable for Input Box Prompt as Empty
        Dim iBoxTitle As String = String.Empty  'Setting Variable for Input Box Title as Empty
        Dim defaultResponse As String = String.Empty 'Setting Variable as empty for NewMetaState

        Dim iBoxNewMetaState As Object

        'Setting InputBox Format with above Variables
        iBoxPrompt = "Type in name of new state"
        iBoxTitle = "New Meta State"
        defaultResponse = "Put Meta Name Here"

        'Displaying InputBox for New Meta State
        iBoxNewMetaState = InputBox(iBoxPrompt, iBoxTitle, defaultResponse)

        'Testing data from new inputbox for New Meta State
        MessageBox.Show("You created a new MetaState Called: " & iBoxNewMetaState)

        'Adding New Meta State to list boxes
        'lstBoxCTMetaState.Items.Add(iBoxNewMetaState)
        cBoxCTMetaState.Items.Add(iBoxNewMetaState)
        cBoxATMetaState.Items.Add(iBoxNewMetaState)
    End Sub


End Class