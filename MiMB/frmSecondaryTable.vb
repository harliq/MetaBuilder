Public Class frmSecondaryTable

    Public Property FormSelection As Integer
    Public Property TextOne As String
    Public Property TextTwo As String
    Public Property TextThree As String


    Dim TableSecondaryMultiple As New DataTable("TableSecondaryMultiple")


    Private Sub Add_Update_Delete_DataGridView_Row_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cBoxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxType.SelectedIndexChanged
        ResetForm()
        FormConfig(SetFormIndex)
        'set defaults for certain items
        Select Case cBoxType.SelectedIndex
            Case 11, 12 ' Item Count LE & GE
                TextBox3.Text = "0"

            Case 13 ' Monster Count Within Distance
                TextBox1.Text = ""
                TextBox2.Text = "1"
                TextBox3.Text = "5"
            Case 14 ' Monsters with Priority within distance
                TextBox1.Text = "-1"
                TextBox2.Text = "1"
                TextBox3.Text = "5"
            Case 17, 18 ' Landblock & LandCell
                TextBox1.Text = "00000000"
            Case 28 'Chat Message Capture
                TextBox2.Text = ""
                TextBox3.Text = ""


        End Select
    End Sub

    Private Sub frmSecondaryTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'dgvMultiple Rule Table
        TableSecondaryMultiple.Columns.Add("Type", Type.GetType("System.String"))
        TableSecondaryMultiple.Columns.Add("Data", Type.GetType("System.String"))
        'set data from datatable to datagridview

        dgvMultiple.DataSource = TableSecondaryMultiple

        dgvMultiple.Columns("Type").DisplayIndex = 0
        dgvMultiple.Columns("Data").DisplayIndex = 1

        dgvMultiple.Columns(0).Width = dgvMultiple.Width * 0.35
        dgvMultiple.Columns(1).Width = dgvMultiple.Width * 0.65

        dgvMultiple.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMultiple.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        dgvMultiple.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMultiple.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

        ResetForm()
        FormConfig(SetFormIndex)
    End Sub

    Sub ResetForm()
        lblTextOne.Visible = False
        lblTextTwo.Visible = False
        lblTextThree.Visible = False
        lblState.Visible = False
        cBoxMetaState.Visible = False
        cBoxMetaStateTwo.Visible = False
        btnEmbedNav.Visible = False
        btnCreateMetaState.Visible = False
        dgvMultiple.Visible = False
        btnAdd.Visible = False
        btnEdit.Visible = False
        btnDelete.Visible = False
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        rdbTrue.Visible = False
        rdbFalse.Visible = False
        lstBoxCommonOptions.Visible = False

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
                Case 11
                    FormTwoRule()
                    lblTextTwo.Text = "Item"
                    lblTextThree.Text = "Number of items <="
                Case 12
                    FormTwoRule()
                    lblTextTwo.Text = "Item"
                    lblTextThree.Text = "Number of items >="
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
                    'TextBox1.Text = "00000000"
                Case 18
                    FormOneRule()
                    lblTextOne.Text = "LandCell ="
                    'TextBox1.Text = "00000000"
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
                    lblTextTwo.Text = "Chat"
                    lblTextThree.Text = "Color ID (Leave Blank)"
            End Select
        ElseIf SetFormType = 2 Then
            Select Case cBoxAType.SelectedIndex
                Case 1
                    FormMetaRule()
                    lblTextOne.Text = "Select State"
                    If FormSelection = 1 Then
                        cBoxMetaState.Text = TextOne
                    End If
                Case 2
                    FormOneRule()
                    lblTextOne.Text = "Chat Command"
                Case 3 ' Multiple
                    FormMultipleRule()
                Case 4
                    FormNavRule()
                    lblTextOne.Text = "Nav File to Embed"
                Case 5
                    FormTwoStateRule()
                    lblState.Text = "Select Call State:"
                    lblTextOne.Text = "Select Return State:"

                    If FormSelection = 5 Then
                        cBoxMetaState.Text = TextOne
                        cBoxMetaStateTwo.Text = TextTwo
                    End If
                    'lblTextTwo.Text =
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
                    FormSetOptRule()
                    lblTextTwo.Text = "Item"
                    lblTextThree.Text = "Value"
                    lblState.Text = "Common Options"
                Case 13
                    FormTwoRule()
                    lblTextTwo.Text = "Name of View"
                    lblTextThree.Text = "Raw XML Data"
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

        lblTextTwo.Visible = True
        TextBox2.Visible = True
        lblTextThree.Visible = True
        TextBox3.Visible = True


    End Sub

    Sub FormThreeRule()
        lblTextOne.Visible = True
        TextBox1.Visible = True
        lblTextTwo.Visible = True
        TextBox2.Visible = True
        lblTextThree.Visible = True
        TextBox3.Visible = True
        TextBox2.Text = ""
        TextBox3.Text = ""


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
    Sub FormTwoStateRule()

        cBoxMetaState.Visible = True
        cBoxMetaStateTwo.Visible = True
        lblState.Visible = True
        lblTextOne.Visible = True
        cBoxMetaState.Items.Clear()
        cBoxMetaStateTwo.Items.Clear()

        btnCreateMetaState.Visible = True

        For Each mstate As Object In frmMain.cBoxATMetaState.Items
            cBoxMetaState.Items.Add(mstate)
            cBoxMetaStateTwo.Items.Add(mstate)
        Next
        cBoxMetaState.Text = "Default"
        cBoxMetaStateTwo.Text = "Default"

    End Sub
    Sub FormNavRule()
        lblTextOne.Visible = True
        TextBox1.Visible = True
        btnEmbedNav.Visible = True
    End Sub
    Sub FormSetOptRule()

        lblTextTwo.Visible = True
        TextBox2.Visible = True
        lblTextThree.Visible = True
        TextBox3.Visible = True
        rdbTrue.Visible = True
        rdbFalse.Visible = True
        lstBoxCommonOptions.Visible = True
        lblState.Visible = True

    End Sub
    Sub FormMultipleRule()

        '-- This is Temp till Nested Tables are in
        'dgvMultiple.Visible = True
        'btnAdd.Visible = True
        'btnEdit.Visible = True
        'btnDelete.Visible = True

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
                'This is Temp till Nested Tables are in

                TextBox1.Text = "0"
            Case 4
                FormNavRule()
                lblTextOne.Text = "Nav File to Embed"
            Case 5
                FormTwoStateRule()
                lblState.Text = "Select Call State:"
                lblTextOne.Text = "Select Return State:"
                cBoxMetaState.Text = TextOne
                cBoxMetaStateTwo.Text = TextTwo
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
                FormSetOptRule()
                lblTextTwo.Text = "Item"
                lblTextThree.Text = "Value"
                lblState.Text = "Common Options"
            Case 13
                FormTwoRule()
                lblTextTwo.Text = "Name of View"
                lblTextThree.Text = "Raw XML Data"
            Case 14
                FormOneRule()
                lblTextOne.Text = "Name of View to Destroy"
            Case 15


        End Select
    End Sub

    Private Sub btnEmbedNav_Click(sender As Object, e As EventArgs) Handles btnEmbedNav.Click

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
                cBoxMetaStateTwo.Items.Add(iBoxNewMetaState)
                If cBoxAType.SelectedIndex = 1 Then
                    cBoxMetaState.SelectedItem = iBoxNewMetaState
                End If
                'cBoxMetaState.SelectedItem = iBoxNewMetaState

            End If
        Else
            'MessageBox.Show("You Clicked Cancel")
        End If

        metaDialog.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ThirdTableDialog As New frmSecondaryTable()


        GlobalVars.SetFormType = 2
        ThirdTableDialog.cBoxType.Visible = False
        ThirdTableDialog.Text = "Action Mulitiple Dialog 2"
        ThirdTableDialog.lblCbox.Text = "Choose Action Type:"
        ThirdTableDialog.TextBox1.Text = ""
        ThirdTableDialog.cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))
        ThirdTableDialog.cBoxAType.SelectedIndex = 0

        If ThirdTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            Select Case ThirdTableDialog.cBoxAType.SelectedIndex
                Case 0, 3, 6, 10, 15       'Zero Values -- Remove 3.  This is Temp till Nested Tables are in
                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "0")
                Case 1, 5           'Meta States
                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", ThirdTableDialog.cBoxMetaState.Text)
                Case 2, 4, 7, 8, 14  'Single Values
                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", ThirdTableDialog.TextBox1.Text)
                Case 9              'Triple Value
                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", Parse.CombineThreeVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text))
                Case 11, 12, 13         'Double Values
                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", Parse.CombineTwoVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, "a"))
                Case 13 '  Multiple -- Supposed to be 3.  This is Temp till Nested Tables are in
                    'Dim sTempDataA As String = ""

                    Dim tempdata As String = ""
                    'DataGridViewRow
                    Dim tempRowCount As Integer = ThirdTableDialog.dgvMultiple.Rows.Count - 1
                    Dim RowCount As Integer = 0

                    For Each r As DataGridViewRow In ThirdTableDialog.dgvMultiple.Rows

                        'For Each r As DataTable In TableSecondaryMultiple.Rows
                        'MsgBox("number of Rows = " & ThirdTableDialog.dgvMultiple.Rows.Count)
                        If (r.Cells(0).Value IsNot Nothing) Then
                            RowCount = RowCount + 1
                            If RowCount = tempRowCount Then
                                tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString
                            Else
                                'tempdata = tempdata & "{"(r.Cells(0).Value.ToString) & (r.Cells(1).Value.ToString) & "}"
                                'tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                                tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString & ", "
                                'tempdata = tempdata & (r.Rows.Item(0).ToString) & "{" & (r.Rows.Item(1).ToString) & "}"
                            End If

                        Else
                            MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                        End If
                        'For Each r As DataTable In TableSecondaryMultiple.Rows
                        'r.Rows.Item(0).ToString()
                    Next


                    TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", tempdata)
                Case Else           'Should not happen, but...
                    MsgBox("Out Of Range - btnAddATAnyAll_Click Case SecondTableDialog")

            End Select

        Else
            'MsgBox("Click Cancel")
        End If

        dgvMultiple.DataSource = TableSecondaryMultiple
        dgvMultiple.Refresh()
        ThirdTableDialog.Dispose()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub

    Function CombineMultipleAction(sMultipleData As String, tMultipleData As DataGridView)
        Dim tempdata As String = ""
        'DataGridViewRow
        For Each r As DataGridViewRow In tMultipleData.Rows
            'For Each r As DataTable In TableSecondaryMultiple.Rows
            If (r.Cells(0).Value IsNot Nothing) Then
                tempdata = tempdata & (r.Cells(0).ToString) & "{" & (r.Cells(1).ToString) & "}"
                'tempdata = tempdata & (r.Rows.Item(0).ToString) & "{" & (r.Rows.Item(1).ToString) & "}"
            Else
                MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
            End If
            'For Each r As DataTable In TableSecondaryMultiple.Rows
            'r.Rows.Item(0).ToString()
        Next
        sMultipleData = tempdata
        Return (sMultipleData)
    End Function

    Private Sub rdbFalse_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFalse.CheckedChanged
        TextBox3.Text = "False"

    End Sub

    Private Sub rdbTrue_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTrue.CheckedChanged
        TextBox3.Text = "True"

    End Sub

    Private Sub lstBoxCommonOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBoxCommonOptions.SelectedIndexChanged
        TextBox2.Text = lstBoxCommonOptions.SelectedItem.ToString
        rdbFalse.Checked = True
        TextBox3.Text = False
    End Sub

    Private Sub rdbFalse_Click(sender As Object, e As EventArgs) Handles rdbFalse.Click
        rdbTrue.Checked = False
        rdbFalse.Checked = True
    End Sub

    Private Sub rdbTrue_Click(sender As Object, e As EventArgs) Handles rdbTrue.Click
        rdbFalse.Checked = False
        rdbTrue.Checked = True
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

    End Sub
End Class