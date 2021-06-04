Public Class frmSecondaryTable

    Public Property FormSelection As Integer
    Public Property TextOne As String
    Public Property TextTwo As String
    Public Property TextThree As String
    Public Property Nested As Boolean = False
    Public Property tableMultiple As DataTable
    Public Property TableSecondaryMultiple As New DataTable("TableSecondaryMultiple")
    Public Property EditTable As Boolean = False
    Public Property TableType As Integer


    Dim indexMultiple As Integer = 0
    'Define a new class member named NewDataTable as follows:



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
            Case 23
                TextBox2.Text = "0"
                TextBox3.Text = "0"
            Case 28 'Chat Message Capture
                TextBox2.Text = ""
                TextBox3.Text = ""


        End Select
    End Sub

    Private Sub frmSecondaryTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'dgvMultiple Rule Table

        'set data from datatable to datagridview

        'If NestedTableForm = True Then
        '    dgvMultiple.DataSource = TableNestedMultiple
        'Else
        '    TableSecondaryMultiple.Columns.Add("Type", Type.GetType("System.String"))
        '    TableSecondaryMultiple.Columns.Add("Data", Type.GetType("System.String"))
        '    dgvMultiple.DataSource = TableSecondaryMultiple
        'End If

        ''-------------------Need to Find this global and change it to class property instead of global var in function-------------
        'If NestedTableForm = False Then
        '    TableSecondaryMultiple.Columns.Add("Type", Type.GetType("System.String"))
        '    TableSecondaryMultiple.Columns.Add("Data", Type.GetType("System.String"))
        '    'dgvMultiple.DataSource = TableSecondaryMultiple
        'Else
        '    TableSecondaryMultiple = NewDataTable
        '    NestedTableForm = False
        'End If
        ''---------------------------------------------------------------------------------------------------------------------------

        Dim tNested As Boolean = Nested 'testing only

        If Nested = False Then
            'TableSecondaryMultiple = tableMultiple
            'TableSecondaryMultiple.Columns.Add("Type", Type.GetType("System.String"))
            'TableSecondaryMultiple.Columns.Add("Data", Type.GetType("System.String"))
            'dgvMultiple.DataSource = TableSecondaryMultiple
        Else
            'TableSecondaryMultiple = tableMultiple

            Nested = False

        End If

        If EditTable = True Then
            TableSecondaryMultiple = tableMultiple
        Else
            TableSecondaryMultiple.Columns.Add("Type", Type.GetType("System.String"))
            TableSecondaryMultiple.Columns.Add("Data", Type.GetType("System.String"))
        End If

        dgvMultiple.DataSource = TableSecondaryMultiple
        dgvMultiple.Columns("Type").DisplayIndex = 0
        dgvMultiple.Columns("Data").DisplayIndex = 1

        dgvMultiple.Columns(0).Width = dgvMultiple.Width * 0.35
        dgvMultiple.Columns(1).Width = dgvMultiple.Width * 0.65

        dgvMultiple.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMultiple.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        dgvMultiple.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMultiple.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable


        'dgvMultiple.Rows.Add("Stupid", "Real")
        dgvMultiple.RefreshEdit()
        ResetForm()
        FormConfig(SetFormIndex)
        dgvMultiple.Refresh()
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
        btnSaveNav.Visible = False

    End Sub

    Sub FormConfig(ItemIndex As Integer)

        If SetFormType = 1 Then

            Select Case cBoxType.SelectedIndex
                Case 0, 1        'Not using
                    TextBox1.Text = "0"
                Case 2, 3, 21
                    FormMultipleRule()
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
                Case 19, 20
                    TextBox1.Text = "0"
                Case 22
                    FormOneRule()
                    lblTextOne.Text = "Seconds in State Persistent Greater than or Equal to:"
                Case 23
                    FormTwoRule()
                    lblTextTwo.Text = "Spell ID"
                    lblTextThree.Text = "Time Left on Spell Greater than or Equal to:"
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
        btnSaveNav.Visible = True
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
        dgvMultiple.Visible = True
        btnAdd.Visible = True
        btnEdit.Visible = True
        btnDelete.Visible = True

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
                FormMultipleRule()
                'TextBox1.Text = "0"
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



        'NestedTableForm = False
        'ThirdTableDialog.Nested = False

        Select Case cBoxType.SelectedIndex
            Case 2, 3, 21
                TableType = 1
                GlobalVars.SetFormType = TableType
                ThirdTableDialog.cBoxAType.Visible = False

                ThirdTableDialog.Text = "ADD **NESTED** Condition Any/All/Not Dialog 2"
                ThirdTableDialog.lblCbox.Text = "Choose Condition Type:"
                ThirdTableDialog.TextBox1.Text = ""
                ThirdTableDialog.cBoxType.Items.AddRange([Enum].GetNames(GetType(MetaConditionTypeID)))
                ThirdTableDialog.cBoxType.SelectedIndex = 0
        End Select

        If cBoxAType.SelectedIndex = 3 Then
            TableType = 2
            GlobalVars.SetFormType = TableType
            ThirdTableDialog.cBoxType.Visible = False
            ThirdTableDialog.Text = "ADD **NESTED** Action Mulitiple Dialog 2"
            ThirdTableDialog.lblCbox.Text = "Choose Action Type:"
            ThirdTableDialog.TextBox1.Text = ""
            ThirdTableDialog.cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))
            ThirdTableDialog.cBoxAType.SelectedIndex = 0
        End If

        'GlobalVars.SetFormType = TableType


        If ThirdTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then


            If GlobalVars.SetFormType = 1 Then
                ''---------------------------------Condition Types--------------------------
                Select Case ThirdTableDialog.cBoxType.SelectedIndex
                    Case 0, 1, 7 To 10, 15, 19, 20 'Empty Values Set As a ZERO
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxType.Text & ": ", "0")
                    Case 2, 3, 21   'All/Any/NOT
                        ThirdTableDialog.Nested = True
                        Dim tempdata As String = ""
                        Dim tempRowCount As Integer = ThirdTableDialog.dgvMultiple.Rows.Count - 1
                        Dim RowCount As Integer = 0

                        For Each r As DataGridViewRow In ThirdTableDialog.dgvMultiple.Rows

                            If (r.Cells(0).Value IsNot Nothing) Then
                                RowCount = RowCount + 1
                                tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                            End If
                        Next
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxType.Text & ": ", tempdata)

                    Case 11, 12, 23, 28 'Double Values
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxType.Text & ": ", Parse.CombineTwoVal(ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text, "a"))
                    Case 13, 14     'Triple Values
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxType.Text & ": ", Parse.CombineThreeVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text))
                    Case Else       'Single Values
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxType.Text & ": ", ThirdTableDialog.TextBox1.Text)

                End Select



            Else
                ''---------------------------------Action Types------------------------------
                Select Case ThirdTableDialog.cBoxAType.SelectedIndex
                    Case 0, 6, 10, 15       'Zero Values -- Remove 3.  This is Temp till Nested Tables are in
                        ' TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & "0" & "}")
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & "0" & "}")
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "0")

                    Case 1, 5           'Meta States
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & ThirdTableDialog.cBoxMetaState.Text & "}")
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", ThirdTableDialog.cBoxMetaState.Text)


                    Case 2, 4, 7, 8, 14  'Single Values
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & ThirdTableDialog.TextBox1.Text & "}")
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", ThirdTableDialog.TextBox1.Text & "}")
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", ThirdTableDialog.TextBox1.Text)
                    Case 9              'Triple Value
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & Parse.CombineThreeVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text) & "}")
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", Parse.CombineThreeVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text))
                    Case 11, 12, 13         'Double Values
                        'TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", "{" & Parse.CombineTwoVal(ThirdTableDialog.TextBox1.Text, ThirdTableDialog.TextBox2.Text, "a") & "}")
                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", Parse.CombineTwoVal(ThirdTableDialog.TextBox2.Text, ThirdTableDialog.TextBox3.Text, "a"))
                    Case 3 '  Multiple -- Supposed to be 3.  This is Temp till Nested Tables are in
                        'Dim sTempDataA As String = ""

                        'NestedTableForm = True ' Setting to use new table to true for New Form SecondaryTable
                        ThirdTableDialog.Nested = True

                        Dim tempdata As String = ""
                        'DataGridViewRow
                        Dim tempRowCount As Integer = ThirdTableDialog.dgvMultiple.Rows.Count - 1
                        Dim RowCount As Integer = 0

                        For Each r As DataGridViewRow In ThirdTableDialog.dgvMultiple.Rows

                            'For Each r As DataTable In TableSecondaryMultiple.Rows
                            'MsgBox("number of Rows = " & ThirdTableDialog.dgvMultiple.Rows.Count)
                            If (r.Cells(0).Value IsNot Nothing) Then
                                RowCount = RowCount + 1
                                'If RowCount = tempRowCount Then
                                'If r.Cells(0).Value.ToString.Contains(": ") Then
                                tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                                '    Else
                                '        tempdata = tempdata & r.Cells(0).Value.ToString & "{" & ": " & r.Cells(1).Value.ToString
                                '    End If
                                'Else
                                '    If r.Cells(0).Value.ToString.Contains(": ") Then
                                '        tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString
                                '    Else
                                '        tempdata = tempdata & r.Cells(0).Value.ToString & ": " & r.Cells(1).Value.ToString
                                '    End If
                                '    'tempdata = tempdata & r.Cells(0).Value.ToString & ": " & "{" & r.Cells(1).Value.ToString
                                '    'tempdata = tempdata & "{"(r.Cells(0).Value.ToString) & (r.Cells(1).Value.ToString) & "}"
                                '    'tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                                '    'tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString & ", "
                                '    'tempdata = tempdata & (r.Rows.Item(0).ToString) & "{" & (r.Rows.Item(1).ToString) & "}"
                                'End If

                                'Else
                                'MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                            End If
                            'For Each r As DataTable In TableSecondaryMultiple.Rows
                            'r.Rows.Item(0).ToString()
                        Next


                        TableSecondaryMultiple.Rows.Add(ThirdTableDialog.cBoxAType.Text & ": ", tempdata)
                    Case Else           'Should not happen, but...
                        MsgBox("Out Of Range - btnAddATAnyAll_Click Case SecondTableDialog")

                End Select
            End If

        Else
            'MsgBox("Click Cancel")
        End If

        dgvMultiple.DataSource = TableSecondaryMultiple
        dgvMultiple.Refresh()
        ThirdTableDialog.Dispose()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim selectedRow As DataGridViewRow
        selectedRow = dgvMultiple.CurrentRow

        '------Opening new Window to edit Table Value---------
        Dim SecondTableDialog As New frmSecondaryTable()
        SecondTableDialog.TableType = GlobalVars.SetFormType
        'MsgBox("TABLETYPE= " & SecondTableDialog.TableType & "  Global = " & GlobalVars.SetFormType)

        If SecondTableDialog.TableType = 1 Then



            If selectedRow.Cells(0).Value IsNot Nothing Then
                '---Dialog config for Condition
                SecondTableDialog.cBoxAType.Visible = False
                SecondTableDialog.Text = "EDIT **NESTED** Any/All/Not Conditoon Dialog 2"
                SecondTableDialog.cBoxType.Items.AddRange([Enum].GetNames(GetType(MetaConditionTypeID)))
                SecondTableDialog.cBoxType.Text = selectedRow.Cells(0).Value.ToString.Replace(": ", "")
                SecondTableDialog.lblCbox.Text = "Choose Condition Type:"

                Select Case selectedRow.Cells(0).Value.ToString
                    Case "Never: ", "Always: " ' Not USING

                    Case "All: ", "Any: ", "Not: " ' For nested tables


                        Dim myNest As New RegX(selectedRow.Cells(1).Value.ToString(), RegXAnyAllNot, False)
                        SecondTableDialog.tableMultiple = myNest.MultiTable
                        SecondTableDialog.EditTable = True

                    Case "ChatMessage: ", "Expression: ", "LandBlockE: ", "LandCellE: "
                        SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                    Case "ItemCountLE: ", "ItemCountGE: ", "ChatMessageCapture: ", "TimeLeftOnSpellGE: "
                        Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(tempData, ";")
                        SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                        SecondTableDialog.TextBox3.Text = StringSplit(1).ToString
                    Case "MonsterCountWithinDistance: ", "MonstersWithPriorityWithinDistance: "
                        Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(tempData, ";")
                        SecondTableDialog.TextBox1.Text = StringSplit(0).ToString
                        SecondTableDialog.TextBox2.Text = StringSplit(1).ToString
                        SecondTableDialog.TextBox3.Text = StringSplit(2).ToString

                    Case Else
                        SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                End Select


            End If
        Else
            If selectedRow.Cells(0).Value IsNot Nothing Then
                SecondTableDialog.cBoxType.Visible = False
                SecondTableDialog.Text = "EDIT **NESTED** Action Mulitiple Dialog 2"
                SecondTableDialog.cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))
                'SecondTableDialog.cBoxAType.Text = selectedRow.Cells(0).Value.ToString
                SecondTableDialog.cBoxAType.Text = selectedRow.Cells(0).Value.ToString.Replace(": ", "")
                SecondTableDialog.lblCbox.Text = "Choose Action Type:"


                Select Case selectedRow.Cells(0).Value.ToString
                    Case "None: " ' Not USING
                    Case "ChatCommand: ", "EmbeddedNaveRoute: ", "ExpressionAct: ", "ChatWithExpression: ", "DestroyView: "
                        SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                    Case "SetState:", "Call State:"
                        SecondTableDialog.cBoxMetaState.Text = selectedRow.Cells(1).Value.ToString

                    Case "GetVTOption: ", "SetVTOption: ", "CreateView: "
                        Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(tempData, ";")
                        SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                        SecondTableDialog.TextBox3.Text = StringSplit(1).ToString
                        If StringSplit(1).ToString = "True" Then
                            SecondTableDialog.rdbTrue.Checked = True
                            SecondTableDialog.rdbFalse.Checked = False
                        End If
                    Case "CreateView: "
                        Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(tempData, ";")
                        SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                        SecondTableDialog.TextBox3.Text = StringSplit(1).ToString

                    Case "WatchdogSet: "
                        Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(tempData, ";")
                        SecondTableDialog.TextBox1.Text = StringSplit(0).ToString
                        SecondTableDialog.TextBox2.Text = StringSplit(1).ToString
                        SecondTableDialog.TextBox3.Text = StringSplit(2).ToString
                    Case "Multiple: " ' Needs Work to finish

                        'This Function Prepares the strings for adding into a Multiple Table - I need to figure out how to Pass Data Back, Thinking as a string array.
                        Dim tempDataString As String = selectedRow.Cells(1).Value.ToString() ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
                        'MsgBox("Row String for Regex = " & selectedRow.Cells(1).Value.ToString())
                        Dim myNest As New RegX(selectedRow.Cells(1).Value.ToString(), RegXMultiple, False)
                        SecondTableDialog.tableMultiple = myNest.MultiTable
                        SecondTableDialog.EditTable = True


                        ''---------------------OLD WAY-------------------------------
                        'If tempDataString.Contains("Multiple: ") = True Then
                        '    MsgBox("Has Multiple:")
                        '    tempDataString.Remove()
                        'Else
                        '    Dim sFirstSplit() As String
                        '    SecondTableDialog.Nested = True
                        '    'NestedTableForm = True 'Global Var so New Form uses Editing Table
                        '    'TableNestedMultiple.Reset()
                        '    Dim TableNestedMultiple As New DataTable("TableNestedMultiple")
                        '    TableNestedMultiple.Columns.Add("Type", Type.GetType("System.String"))
                        '    TableNestedMultiple.Columns.Add("Data", Type.GetType("System.String"))

                        '    sFirstSplit = Split(tempDataString, "}") 'First Split using "{" to give me first set of substrings to analize

                        '    For Each s As String In sFirstSplit
                        '        Dim i As Integer = 0
                        '        Dim sSecondSplit() As String

                        '        sSecondSplit = Split(s, "{") 'Second Split using "{" to give me second set of substrings to analize

                        '        If sFirstSplit(0) = "" Then
                        '            Exit For
                        '        Else
                        '            For x As Integer = 0 To sSecondSplit.Length - 1 'Second Split using the { to give me substrings
                        '                'Dim sThirdSplit() As String
                        '                'TableNestedMultiple.Rows.Add(sSecondSplit(0), sSecondSplit(1))
                        '                'sThirdSplit = Split(sSecondSplit(x), "{") 'Third and Final Split using "{" to give me final set of substrings to manipulate

                        '                If sSecondSplit(0) = "" Then
                        '                    Exit For
                        '                    'If sThirdSplit(0) = "" Then
                        '                    '    Exit For
                        '                Else ' Adding Data to Table 
                        '                    TableNestedMultiple.Rows.Add(sSecondSplit(0), sSecondSplit(1))
                        '                    'SecondTableDialog.dgvMultiple.Rows.Add(sThirdSplit(0).Replace(": ", ""), sThirdSplit(1))
                        '                    'TableNestedMultiple.Rows.Add(sThirdSplit(0), sThirdSplit(1))
                        '                    'TableNestedMultiple.Rows.Add(sThirdSplit(0).Replace(": ", "").ToString, sThirdSplit(1))
                        '                    'SecondTableDialog.tableMultiple = TableNestedMultiple
                        '                End If
                        '            Next
                        '        End If
                        '        i = i + 1
                        '        SecondTableDialog.tableMultiple = TableNestedMultiple
                        '    Next
                        'End If
                        ''--------------------------------------------------------------------
                    Case Else
                        SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                End Select
            Else
                MsgBox("Please select the row and try again - btnEditAnyAll SelectedRowIndex is Null")
                Exit Sub

            End If

        End If


        SecondTableDialog.Nested = False

        Try
            selectedRow = dgvMultiple.Rows(indexMultiple)
        Catch ex As Exception
            MsgBox("Exception! FrmMain.btnEdit_Click, dgvMultiple.Rows index = " & indexMultiple)

        End Try

        'selectedRow = dgvMultiple.Rows(indexMultiple)

        '-------After Window Closing updating Table Fields
        If SecondTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            SecondTableDialog.Nested = False
            'NestedTableForm = False ' Resetting Global Variable to use default add table

            Dim newDataRow As DataGridViewRow
            newDataRow = dgvMultiple.Rows(indexMultiple)


            Select Case GlobalVars.SetFormType
                Case 1

                    newDataRow.Cells(0).Value = SecondTableDialog.cBoxType.Text & ": "
                    Select Case SecondTableDialog.cBoxType.SelectedIndex
                        Case 0, 1, 7 To 10, 15, 19, 20 'Empty Values Set As a ZERO
                            newDataRow.Cells(1).Value = 0
                        Case 11, 12, 23, 28  'Double Values
                            newDataRow.Cells(1).Value = Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a")
                        Case 13, 14     'Triple Values
                            newDataRow.Cells(1).Value = Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text)
                        Case 2, 3, 21 ' Any/All/NOT
                            Dim tempdata As String = ""
                            For Each r As DataGridViewRow In SecondTableDialog.dgvMultiple.Rows
                                If r.Cells(0).Value IsNot Nothing Then
                                    'tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString
                                    tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                                Else
                                    'MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                                End If
                            Next
                            newDataRow.Cells(1).Value = tempdata
                        Case Else ' Single Values
                            newDataRow.Cells(1).Value = SecondTableDialog.TextBox1.Text ' Single Values
                    End Select

                Case 2
                    newDataRow.Cells(0).Value = SecondTableDialog.cBoxAType.Text & ": "
                    Select Case SecondTableDialog.cBoxAType.SelectedIndex
                        Case 0, 6, 10, 15               'ZeroValue
                            newDataRow.Cells(1).Value = "0"
                        Case 1, 5            ' SetState,CallState
                            newDataRow.Cells(1).Value = SecondTableDialog.cBoxMetaState.Text
                        Case 2, 4, 7, 8, 14      'Single Values - "ChatCommand", "EmbeddedNaveRoute", "ExpressionAct", "ChatWithExpression"
                            newDataRow.Cells(1).Value = SecondTableDialog.TextBox1.Text
                        Case 3         'Multiple  -- Supposed to be 3.  This is Temp till Nested Tables are in
                            Dim tempdata As String = ""
                            For Each r As DataGridViewRow In SecondTableDialog.dgvMultiple.Rows
                                If r.Cells(0).Value IsNot Nothing Then
                                    tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                                Else
                                    'MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                                End If
                            Next
                            newDataRow.Cells(1).Value = tempdata
                        Case 11, 12, 13     'Double Values - "GetVTOption", "SetVTOption"
                            newDataRow.Cells(1).Value = Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a")
                        Case 9          'Triple Values
                            newDataRow.Cells(1).Value = Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text)

                        Case Else           'Should not happen, but...
                            MsgBox("Out Of Range - btnAddATAnyAll_Click Case SecondTableDialog")
                    End Select


                Case Else
                    MsgBox("Case Else, frmSecondaryTable - Line 823)")
            End Select




        Else
            'MsgBox("Click Cancel")
        End If

        SecondTableDialog.Dispose()


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

    Private Sub dgvMultiple_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMultiple.CellClick
        indexMultiple = e.RowIndex
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvMultiple.CurrentRow.Index = Nothing Then

            MsgBox("You can not delete the top or bottom (blank) row... Yet")

        ElseIf dgvMultiple.CurrentRow.Index >= 0 Then
            Try
                dgvMultiple.Rows.RemoveAt(indexMultiple)
            Catch
                MsgBox("You Can't remove that row")
            End Try

        Else
            MsgBox("Rows out of range")

        End If
    End Sub

    Private Sub cBoxType_Format(sender As Object, e As ListControlConvertEventArgs) Handles cBoxType.Format

    End Sub

    Private Sub btnSaveNav_Click(sender As Object, e As EventArgs) Handles btnSaveNav.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "NAV Files|*.nav"
        sfd.InitialDirectory = My.Settings.MetaExportDir

        Dim navArray As String() = Split(TextBox1.Text, vbCrLf.ToCharArray)
        Dim navroute As String
        Dim line As Integer

        For line = 0 To UBound(navArray)
            If line = 2 Then
                navroute = navArray(line)
            ElseIf line > 2 Then
                navroute = navroute & vbCrLf & navArray(line)

            Else
            End If
        Next

        If sfd.ShowDialog = DialogResult.OK Then
            If TextBox1.Text = "" Then

                MsgBox("There is no embedded nav route to save")

            Else
                Try
                    Dim navWriter As New System.IO.StreamWriter(sfd.FileName)
                    navWriter.Write(navroute)
                    navWriter.Close()
                Catch ex As Exception
                    MsgBox("Not able to save Nav route " & FileName & ". Aborted")
                End Try

            End If
        Else
        End If
    End Sub
End Class