Public Class frmSecondaryTable


    Private Sub cBoxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxType.SelectedIndexChanged
        ResetForm()
        FormConfig(SetFormIndex)
        'set defaults for certain items
        Select Case cBoxType.SelectedIndex
            Case 13
                TextBox1.Text = ""
                TextBox2.Text = "1"
                TextBox3.Text = "5"
            Case 14
                TextBox1.Text = "-1"
                TextBox2.Text = "1"
                TextBox3.Text = "5"
        End Select
    End Sub

    Private Sub frmSecondaryTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetForm()
        FormConfig(SetFormIndex)
    End Sub

    Sub ResetForm()
        lblTextOne.Visible = False
        lblTextTwo.Visible = False
        lblTextThree.Visible = False
        lblState.Visible = False
        cBoxMetaState.Visible = False
        btnEmbedNav.Visible = False
        btnCreateMetaState.Visible = False
        dgvMultiple.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
    End Sub

    Sub FormConfig(ItemIndex As Integer)

        If SetFormType = 1 Then

            Select Case cBoxType.SelectedIndex
                Case 0, 1, 2, 3        'Not using
                    TextBox1.Text = "0"
                Case 4                 'Chat Message
                    FormOneRule()
                    lblTextOne.Text = "Chat Message"

                Case 5
                    FormOneRule()
                    lblTextOne.Text = "Slots Less or Equal To:"

                Case 6
                    FormOneRule()
                    lblTextOne.Text = "Seconds in State Greater than:"
                Case 7
                    TextBox1.Text = "0"
                Case 8
                    TextBox1.Text = "0"
                Case 9
                    TextBox1.Text = "0"
                Case 10
                    TextBox1.Text = "0"
                Case 11, 12
                    FormTwoRule()
                    lblTextOne.Text = "Item"
                    lblTextTwo.Text = "Number"
                Case 13
                    FormThreeRule()
                    lblTextOne.Text = "Monster Name (regex):"
                    lblTextTwo.Text = "Monster Count Greater Than or Equal to (>=):"
                    lblTextThree.Text = "Range (Meters):"

                Case 14
                    FormThreeRule()
                    lblTextOne.Text = "Monsters Priorty:"
                    lblTextTwo.Text = "Monster Count Greater Than or Equal to (>=):"
                    lblTextThree.Text = "Range (Meters):"

                Case 14
                    TextBox1.Text = "0"
                Case 16
                    FormOneRule()
                    lblTextOne.Text = "No Monsters Within Distance:"
                Case 17
                    FormOneRule()
                    lblTextOne.Text = "LandBlock ="
                    TextBox1.Text = "00000000"
                Case 18
                    FormOneRule()
                    lblTextOne.Text = "LandCell ="
                    TextBox1.Text = "00000000"
                Case 19, 20, 21
                    TextBox1.Text = "0"
                Case 22
                    FormOneRule()
                    lblTextOne.Text = "Seconds in State Persistent Greater than or Equal to:"
                Case 23
                    FormOneRule()
                    lblTextOne.Text = "Time Left on Spell Greater than or Equal to:"
                Case 24
                    FormOneRule()
                    lblTextOne.Text = "Burden Percent is Great than or Equal to:"
                Case 25
                    FormOneRule()
                    lblTextOne.Text = "Distance to Any Route Point is Greater than or Equal to:"
                Case 26
                    FormOneRule()
                    lblTextOne.Text = "Expression"
                Case 27
                    TextBox1.Text = "0"
                Case 28
                    FormTwoRule()
                    lblTextOne.Text = "Chat"
                    lblTextTwo.Text = "Color ID"
            End Select
        ElseIf SetFormType = 2 Then
            Select Case cBoxAType.SelectedIndex
                Case 1
                    FormMetaRule()
                    lblTextOne.Text = "Select State"
                Case 2
                    FormOneRule()
                    lblTextOne.Text = "Chat Command"
                Case 3
                Case 4
                    FormNavRule()
                    lblTextOne.Text = "Nav File to Embed"
                Case 5
                    FormMetaRule()
                    lblTextOne.Text = "Select Call State:"
                Case 6
                Case 7
                    FormOneRule()
                    lblTextOne.Text = "Expression Action:"
                Case 8
                    FormOneRule()
                    lblTextOne.Text = "Chat with Expression:"
                Case 9
                    FormThreeRule()
                    lblTextOne.Text = "State to Call:"
                    lblTextTwo.Text = "Movement Range: (Meters)"
                    lblTextThree.Text = "Time Span: (Seconds)"
                Case 10
                Case 11, 12
                    FormTwoRule()
                    lblTextOne.Text = "Item"
                    lblTextTwo.Text = "Number"
                Case 13
                    FormTwoRule()
                    lblTextOne.Text = "Name of View"
                    lblTextTwo.Text = "Raw XML Data"
                Case 14
                    FormOneRule()
                    lblTextOne.Text = "Name of View to Destroy"
                Case 15

            End Select

        Else
            MsgBox("Out of Range - SetFormType.Value frmSecodaryTable.FormConfig")
        End If

    End Sub

    Sub FormOneRule()

        lblTextOne.Visible = True
        TextBox1.Visible = True
    End Sub

    Sub FormTwoRule()

        lblTextOne.Visible = True
        TextBox1.Visible = True
        lblTextTwo.Visible = True
        TextBox2.Visible = True

    End Sub

    Sub FormThreeRule()
        lblTextOne.Visible = True
        TextBox1.Visible = True
        lblTextTwo.Visible = True
        TextBox2.Visible = True
        lblTextThree.Visible = True
        TextBox3.Visible = True

    End Sub
    Sub FormMetaRule()

        cBoxMetaState.Visible = True
        lblState.Visible = True
        cBoxMetaState.Items.Clear()
        btnCreateMetaState.Visible = True

        For Each mstate As Object In frmMain.cBoxATMetaState.Items
            cBoxMetaState.Items.Add(mstate)
        Next
        cBoxMetaState.Text = "Default"

    End Sub
    Sub FormNavRule()
        lblTextOne.Visible = True
        TextBox1.Visible = True
        btnEmbedNav.Visible = True
    End Sub
    Private Sub cBoxAType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxAType.SelectedIndexChanged

        ResetForm()
        ATFormConfig(cBoxAType.SelectedIndex)

    End Sub
    Sub ATFormConfig(ATItemIndex)
        TextBox1.Text = ""
        Select Case ATItemIndex
            Case 0
                TextBox1.Text = "0"
            Case 1
                FormMetaRule()
                lblTextOne.Text = "Select State"
            Case 2
                FormOneRule()
                lblTextOne.Text = "Chat Command"
            Case 3
                TextBox1.Text = "0"
            Case 4
                FormNavRule()
                lblTextOne.Text = "Nav File to Embed"
            Case 5
                FormMetaRule()
                lblTextOne.Text = "Select Call State:"
            Case 6
            Case 7
                FormOneRule()
                lblTextOne.Text = "Expression Action:"
            Case 8
                FormOneRule()
                lblTextOne.Text = "Chat with Expression:"
            Case 9
                FormThreeRule()
                lblTextOne.Text = "State to Call:"
                lblTextTwo.Text = "Movement Range: (Meters)"
                lblTextThree.Text = "Time Span: (Seconds)"
            Case 10
            Case 11, 12
                FormTwoRule()
                lblTextOne.Text = "Item"
                lblTextTwo.Text = "Number"
            Case 13
                FormTwoRule()
                lblTextOne.Text = "Name of View"
                lblTextTwo.Text = "Raw XML Data"
            Case 14
                FormOneRule()
                lblTextOne.Text = "Name of View to Destroy"
            Case 15


        End Select
    End Sub

    Private Sub btnEmbedNav_Click(sender As Object, e As EventArgs) Handles btnEmbedNav.Click
        'Dim ofd As New OpenFileDialog()
        'ofd.Filter = "Nav Files|*.nav"
        'ofd.Title = "Select Nav File to Embed"
        'ofd.InitialDirectory = My.Settings.MetaExportDir

        If (ofdSecondaryTable.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = ofdSecondaryTable.FileName
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCreateMetaState.Click
        Dim MetaList As New ArrayList()

        Dim iBoxPrompt As String = String.Empty 'Setting Variable for Input Box Prompt as Empty
        Dim iBoxTitle As String = String.Empty  'Setting Variable for Input Box Title as Empty
        Dim defaultResponse As String = String.Empty 'Setting Variable as empty for NewMetaState

        Dim iBoxNewMetaState As String
        Dim metaDialog As New MetaState() 'Creating instance of MetaStateForm

        metaDialog.txtBoxStateName.Select()
        'Show metaDialog as a Modal Dialog/see if result was OK
        If metaDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            iBoxNewMetaState = metaDialog.txtBoxStateName.Text
            If iBoxNewMetaState = "" Then
                'Show Message Box Error
                MessageBox.Show("You entered a blank Meta State Name")
            Else
                'Adding New Meta State to list boxes
                MetaList.Add(iBoxNewMetaState)
                frmMain.cBoxCTMetaState.Items.Add(iBoxNewMetaState)
                frmMain.cBoxATMetaState.Items.Add(iBoxNewMetaState)
                cBoxMetaState.Items.Add(iBoxNewMetaState)
                cBoxMetaState.SelectedItem = iBoxNewMetaState

            End If
        Else
            'MessageBox.Show("You Clicked Cancel")
        End If

        metaDialog.Dispose()
    End Sub


End Class