Public Class frmSecondaryTable
    Private Sub cBoxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxType.SelectedIndexChanged

        ResetForm()

        FormConfig(cBoxType.SelectedIndex)

    End Sub

    Private Sub frmSecondaryTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ResetForm()
        FormConfig(cBoxType.SelectedIndex)

    End Sub

    Sub ResetForm()

        lblTextOne.Visible = False
        lblTextTwo.Visible = False
        lblTextThree.Visible = False

        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False



    End Sub

    Sub FormConfig(ItemIndex As Integer)

        Select Case ItemIndex


            Case 4 ' Chat Message
                FormOneRule()
                lblTextOne.Text = "Chat Message"

            Case 5
                FormOneRule()
                lblTextOne.Text = "Slots Less or Equal To:"

            Case 6
                FormOneRule()
                lblTextOne.Text = "Seconds in State Greater than:"
            Case 7

            Case 8

            Case 9

            Case 10
            Case 11, 12
                FormTwoRule()
                lblTextOne.Text = "Item"
                lblTextTwo.Text = "Number"

            Case 12
            Case 13
            Case 14
            Case 26
                FormOneRule()
                lblTextOne.Text = "Expression"
            Case 28
                FormTwoRule()
                lblTextOne.Text = "Chat"
                lblTextTwo.Text = "Color ID"


        End Select

    End Sub

    Sub FormOneRule()

        lblTextOne.Visible = True
        TextBox1.Visible = True
        'TextBox1.Text = ""

    End Sub

    Sub FormTwoRule()

        lblTextOne.Visible = True
        TextBox1.Visible = True
        lblTextTwo.Visible = True
        TextBox2.Visible = True
        'TextBox1.Text = ""
        'TextBox2.Text = ""
    End Sub
End Class