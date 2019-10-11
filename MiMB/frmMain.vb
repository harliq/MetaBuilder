Imports System.ComponentModel
Imports System.Data.DataTable
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window

Public Class frmMain

    'Dim Datagridview1(Datasource) As DataTable
    Enum mode
        top = 0
        up = 1
        down = 2
        bottom = 3
    End Enum

    Dim table As New DataTable("table")
    Dim TableAnyAll As New DataTable("TableAnyAll")
    Dim TableATMultiple As New DataTable("TableATMultiple")
    Dim index As Integer 'dgvMetaTable index
    Dim tAnyAllIndex As Integer
    Dim tATMultipleIndex As Integer

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'MessageBox.Show("Before Exit")
        Application.Exit()
        'MessageBox.Show("after exit")
    End Sub



    Private Sub btnCreateState_Click(sender As Object, e As EventArgs) Handles btnCreateState.Click

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
                cBoxCTMetaState.Items.Add(iBoxNewMetaState)
                cBoxATMetaState.Items.Add(iBoxNewMetaState)
                cboxReturnMetaState.Items.Add(iBoxNewMetaState)
                cBoxCTMetaState.SelectedItem = iBoxNewMetaState

            End If
        Else
            'MessageBox.Show("You Clicked Cancel")
        End If

        metaDialog.Dispose()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If cBoxCTMetaState.Text = "" Then
            MessageBox.Show("Please Select Meta State for CondtionType")
        Else
            'LabelS.Text = cBoxCType.SelectedIndex
        End If

    End Sub

    Private Sub btnCreateRule_Click(sender As Object, e As EventArgs) Handles btnCreateRule.Click
        RuleChange = False
        GlobalVars.rulechanged()
        SaveWork = True ' Var for checking to save work.  Public in Setform Module

        Dim CData As String
        Dim AData As String

        Select Case cBoxCType.SelectedIndex
            Case 0
                CData = "0"
            Case 2, 3, 21
                Parse.CombineAnyAll()
                CData = AnyAllString
            Case 11, 12, 23, 28
                CData = Parse.CombineTwoVal(txtBoxCData.Text, txtBoxCData2.Text, "a")
            Case 13, 14
                CData = Parse.CombineThreeVal(txtBoxCData.Text, txtBoxCData2.Text, txtBoxCData3.Text)

            Case Else
                CData = txtBoxCData.Text
        End Select

        Select Case cBoxAType.SelectedIndex
            Case 0
                AData = "0"
            Case 1       'Set State or Call State
                AData = cBoxATMetaState.Text
            Case 3
                Parse.CombineMultiple()
                AData = MultipleString
            Case 5
                AData = Parse.CombineTwoVal(cBoxATMetaState.Text, cboxReturnMetaState.Text, "a")
            Case 9          'for Watch Dog Set - Triple 
                AData = Parse.CombineThreeVal(txtBoxAData.Text, txtBoxAData2.Text, txtBoxAData3.Text)
            Case 11, 12, 13
                AData = Parse.CombineTwoVal(txtBoxAData.Text, txtBoxAData2.Text, "a")
            Case Else
                AData = txtBoxAData.Text
        End Select

        table.Rows.Add(cBoxCType.Text, cBoxAType.Text, CData, AData, cBoxCTMetaState.Text) ' Used Case to Simplify What's under this


    End Sub

    Private Sub cBoxCType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxCType.SelectedIndexChanged
        TableAnyAll.Clear()
        dgvAnyAll.DataSource = TableAnyAll
        SetForm.ResetCondition()
        SetForm.CTSet(cBoxCType.SelectedIndex.ToString)
        'RuleChange = True
        'GlobalVars.rulechanged()

        'Defaults
        Select Case cBoxCType.SelectedIndex
            Case 5 'packslots
                txtBoxCData.Text = "0"
            Case 6 'Seconds in state
                txtBoxCData.Text = "99999"
            Case 11, 12 'item count
                txtBoxCData2.Text = "0"
            Case 15 'need to buff
                txtBoxCData.Text = "0"
            Case 16 'No Monsters within Distance
                txtBoxCData.Text = "5"
            Case 22 'SecondsInStatePersistGE 
                txtBoxCData.Text = "99999"
            Case 23 'TimeLeftOnSpellGE
                txtBoxCData.Text = "0"
                txtBoxCData2.Text = "0"
            Case 24 'BurdenPercentGE 
                txtBoxCData.Text = "100"
            Case 25 'DistanceToAnyRoutePointGE
                txtBoxCData.Text = "10"
            Case 26 'Expression
                txtBoxCData.Text = "False"
            Case 28 'Chat Message Capture
                txtBoxCData2.Text = ""

        End Select

    End Sub

    Private Sub tsbOpen_Click(sender As Object, e As EventArgs) Handles tsbOpen.Click

        dgvMetaRules.DataSource = LoadXML(table)

    End Sub

    Private Sub MetaDataDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub buttonTest_Click(sender As Object, e As EventArgs) Handles buttonTest.Click

        Me.Close()

    End Sub



    Private Sub Add_Update_Delete_DataGridView_Row_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add columns to your datatable, 
        ' with the name of the columns and their type 


        table.Columns.Add("Condition Type", Type.GetType("System.String"))
        table.Columns.Add("Action Type", Type.GetType("System.String"))
        table.Columns.Add("Condition Data", Type.GetType("System.String"))
        table.Columns.Add("Action Data", Type.GetType("System.String"))
        table.Columns.Add("State", Type.GetType("System.String"))

        ' Add rows to the datatable with some data
        table.Rows.Add("Never", "None", "0", "0", "Default")

        'Meta Rules Table  - set data from datatable to datagridview 

        dgvMetaRules.DataSource = table
        dgvMetaRules.Columns("State").DisplayIndex = 0
        dgvMetaRules.Columns("Condition Type").DisplayIndex = 1
        dgvMetaRules.Columns("Condition Data").DisplayIndex = 2
        dgvMetaRules.Columns("Action Type").DisplayIndex = 3
        dgvMetaRules.Columns("Action Data").DisplayIndex = 4
        dgvMetaRules.Columns(0).Width = dgvMetaRules.Width * 0.1
        dgvMetaRules.Columns(1).Width = dgvMetaRules.Width * 0.1
        dgvMetaRules.Columns(2).Width = dgvMetaRules.Width * 0.35
        dgvMetaRules.Columns(3).Width = dgvMetaRules.Width * 0.36
        dgvMetaRules.Columns(4).Width = dgvMetaRules.Width * 0.09

        dgvMetaRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMetaRules.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        dgvMetaRules.Sort(dgvMetaRules.Columns(4), ListSortDirection.Ascending)
        dgvMetaRules.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMetaRules.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMetaRules.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMetaRules.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvMetaRules.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable




        'AnyAll Rule Table
        TableAnyAll.Columns.Add("Type", Type.GetType("System.String"))
        TableAnyAll.Columns.Add("Data", Type.GetType("System.String"))
        'set data from datatable to datagridview
        dgvAnyAll.DataSource = TableAnyAll
        dgvAnyAll.Columns("Type").DisplayIndex = 0
        dgvAnyAll.Columns("Data").DisplayIndex = 1

        dgvAnyAll.Columns(0).Width = dgvAnyAll.Width * 0.2
        dgvAnyAll.Columns(1).Width = dgvAnyAll.Width * 0.8

        dgvAnyAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAnyAll.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        dgvAnyAll.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvAnyAll.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable


        'AT Multiple Rule Table
        TableATMultiple.Columns.Add("Type", Type.GetType("System.String"))
        TableATMultiple.Columns.Add("Data", Type.GetType("System.String"))
        'set data from datatable to datagridview
        dgvATMultiple.DataSource = TableATMultiple
        dgvATMultiple.Columns("Type").DisplayIndex = 0
        dgvATMultiple.Columns("Data").DisplayIndex = 1

        dgvATMultiple.Columns(0).Width = dgvATMultiple.Width * 0.2
        dgvATMultiple.Columns(1).Width = dgvATMultiple.Width * 0.8

        dgvATMultiple.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvATMultiple.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        dgvATMultiple.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvATMultiple.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

        'Load Condtion Type Combox with Enum
        cBoxCType.Items.AddRange([Enum].GetNames(GetType(MetaConditionTypeID)))
        cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))

        'Set Default for ComboBoxes
        cBoxCType.SelectedIndex = 0
        cBoxCTMetaState.SelectedIndex = 0
        cBoxAType.SelectedIndex = 0
        dgvMetaRules.Rows(0).Selected = True





        'Check if command line arguments were specified
        Dim CommandArgs() As String = Environment.GetCommandLineArgs()
        If CommandArgs.Length > 1 Then
            'Yes Arguments, set to read them and carry them out

            Select Case CommandArgs(1)
                'Loads File - This is a test to make sure I am getting the arguments right
                Case "-l" 'Load XML
                    XMLFileNameLoad = CommandArgs(2)
                    xml.ConvertXML(table)
                Case "-c" 'Load XML & Convert to Meta
                    CommandArgument = True
                    'MsgBox("Not Functioning Currently")
                    XMLFileNameLoad = CommandArgs(2)
                    xml.ConvertXML(table)
                    MetaFileNameExport = CommandArgs(3)
                    MetaExport()
                    'MsgBox("Did it work?")
                    Me.Close()
            End Select


            'If CommandArgs(1) = "-c" Then 'Convert XML to Meta
            '    'Convert XML to Meta

            'Else
            '    MsgBox("Incorrect Command Line Argument")
            'End If

        Else


            '--- Nope, run the normal Windows Forms startup code
            '    Application.EnableVisualStyles()
            'Application.SetCompatibleTextRenderingDefault(False)
            'Application.Run(MiMB_Test.frmMain())
            ' Dim args = Environment.GetCommandLineArgs()

            'If args.Length > 1 Then textBox1.Text = args(1)
            'If args.Length > 2 Then textBox2.Text = args(2)
        End If





    End Sub

    Private Sub btnDeleteRule_Click(sender As Object, e As EventArgs) Handles btnDeleteRule.Click

        'Delete Rule 'Need to add try statement to see if it is deleteing last row. If so, throw an error
        If dgvMetaRules.CurrentRow.Index = Nothing Then

            MsgBox("You can not delete the top row... Yet")

        ElseIf dgvMetaRules.CurrentRow.Index >= 0 Then
            Try
                dgvMetaRules.Rows.RemoveAt(index)
            Catch
                MsgBox("You Can't remove that row")
            End Try

        Else
            MsgBox("Rows out of range")

        End If
    End Sub




    Private Sub btnUpdateRule_Click(sender As Object, e As EventArgs) Handles btnUpdateRule.Click
        SaveWork = True
        ' update the datagridview selected row using textbox
        ' the new row
        Dim newDataRow As DataGridViewRow
        Dim CData As String
        Dim AData As String
        '

        newDataRow = dgvMetaRules.Rows(index)

        ' get data from textboxes to the row
        newDataRow.Cells(0).Value = cBoxCType.Text
        newDataRow.Cells(1).Value = cBoxAType.Text

        Select Case cBoxCType.SelectedIndex
            Case 2, 3, 21
                Parse.CombineAnyAll()
                CData = AnyAllString
            Case 11, 12, 23, 28
                CData = Parse.CombineTwoVal(txtBoxCData.Text, txtBoxCData2.Text, "a")
            Case 13, 14
                CData = Parse.CombineThreeVal(txtBoxCData.Text, txtBoxCData2.Text, txtBoxCData3.Text)
            Case Else
                CData = txtBoxCData.Text

        End Select

        Select Case cBoxAType.SelectedIndex
            Case 1
                AData = cBoxATMetaState.Text
            Case 3
                Parse.CombineMultiple()
                AData = MultipleString
            Case 5
                AData = Parse.CombineTwoVal(cBoxATMetaState.Text, cboxReturnMetaState.Text, "a")
            Case 9
                AData = Parse.CombineThreeVal(txtBoxAData.Text, txtBoxAData2.Text, txtBoxAData3.Text)
            Case 11, 12, 13
                AData = Parse.CombineTwoVal(txtBoxAData.Text, txtBoxAData2.Text, "a")
                ' Case 13
                '     AData = Parse.CombineTwoVal(txtBoxAData.Text, txtBoxAData2.Text, "a")
            Case Else
                AData = txtBoxAData.Text
        End Select

        newDataRow.Cells(0).Value = cBoxCType.Text
        newDataRow.Cells(1).Value = cBoxAType.Text
        newDataRow.Cells(2).Value = CData
        newDataRow.Cells(3).Value = AData
        newDataRow.Cells(4).Value = cBoxCTMetaState.Text

    End Sub

    Private Sub btnLoadXML_Click(sender As Object, e As EventArgs) Handles btnLoadXML.Click
        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved this file, save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    xml.SaveXML()
                    dgvMetaRules.DataSource = LoadXML(table)
                Case Windows.Forms.DialogResult.No
                    dgvMetaRules.DataSource = LoadXML(table)

            End Select
        Else
            dgvMetaRules.DataSource = LoadXML(table)
        End If
        'xml.LoadXML(table)
        dgvMetaRules.Rows(0).Selected = True
        cBoxCTMetaState.Text = "Default"


    End Sub

    Private Sub btnSaveXML_Click(sender As Object, e As EventArgs) Handles btnSaveXML.Click
        'Cursor = Cursors.WaitCursor
        xml.SaveXML()
        'Cursor = Cursors.Default
    End Sub

    Public Sub SaveXML()

        xml.SaveXML()

    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        xml.SaveXML()

    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click

        xml.SaveXML()

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        dgvMetaRules.DataSource = LoadXML(table)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDown.Click

        'If already on the bottom row, don’t try to move the row down
        If dgvMetaRules.CurrentCell.RowIndex = dgvMetaRules.RowCount - 1 Then
            Exit Sub
        End If

        'Calling SwapRows
        swapRows(mode.down)

    End Sub

    Private Sub btnExportMeta_Click(sender As Object, e As EventArgs) Handles btnExportMeta.Click

        MetaExport()

    End Sub

    Private Sub cBoxAType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cBoxAType.SelectedIndexChanged
        TableATMultiple.Clear()
        dgvATMultiple.DataSource = TableATMultiple
        SetForm.ResetAction()
        SetForm.ATSet(cBoxAType.SelectedIndex.ToString)
        'Select Case cBoxAType.SelectedIndex
        '    Case 0 'None
        '        'SetForm.ATNone()
        '        'lblAData.Text = "None"
        '        'txtBoxAData.Text = "0"
        '        'txtBoxAData.Enabled = False
        '    Case 1 'SetState
        '        SetForm.ATSetStateRule()
        '        'txtBoxAData.Enabled = False
        '        'cBoxATMetaState.Visible = True
        '        'lblATMetaState.Visible = True
        '    Case 2 'Chat Command
        '        SetForm.ATSingleRule()
        '        lblAData.Text = "Chat Command"
        '    Case 3 'Mulitple
        '        SetForm.ATMultiple()
        '        'lblAData.Text = "Multiple"
        '        txtBoxAData.Text = "0"
        '        'txtBoxAData.Enabled = False
        '        MsgBox("Not yet Implemented")
        '    Case 4 'Embedded Nav Route
        '        SetForm.ATSingleRule()
        '        btnChooseNav.Visible = True
        '        lblAData.Text = "Embedded Nav - Choose File"
        '    Case 5 'Call State
        '        SetForm.ATSetState()
        '        lblAData.Text = "Call State"
        '    Case 6 'Return from Call
        '        'SetForm.ATReturnFromCall()
        '        lblAData.Text = "Return From Call"
        '        txtBoxAData.Text = "0"
        '    Case 7 'Expression Action
        '        SetForm.ATSingleRule()
        '        lblAData.Text = "Expression Action"
        '    Case 8 'Chat With Expression
        '        SetForm.ATSingleRule()
        '        lblAData.Text = "Chat with Expression"
        '    Case 9 'Watchdog Set
        '        SetForm.ATTripleRule()
        '        lblAData.Text = "State to Call:"
        '        lblAdata2.Text = "Movement Range (Meters):"
        '        lblAData3.Text = "Time Span (Seconds):"
        '    Case 10 'Watchdog Clear
        '        'SetForm.ATWatchDogClear()
        '        lblAData.Text = "WatchDog Clear"
        '    Case 11 'Get VT Option
        '        SetForm.ATDoubleRule()
        '        lblAData.Text = "Option to Get"
        '        lblAdata2.Text = "Expression Variable Target"
        '    Case 12 'Set VT Option
        '        SetForm.ATDoubleRule()
        '        lblAData.Text = "Option to Set"
        '        lblAdata2.Text = "Expresssion (True/False, Value)"

        'End Select

    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click

        swapRows(mode.up)

    End Sub

    Private Sub MoveRow(ByVal i As Integer)

        Try

            If (dgvMetaRules.SelectedCells.Count > 0) Then

                Dim curr_index As Integer = dgvMetaRules.CurrentCell.RowIndex
                Dim curr_col_index As Integer = dgvMetaRules.CurrentCell.ColumnIndex
                Dim curr_row As DataGridViewRow = dgvMetaRules.CurrentRow

                dgvMetaRules.Rows.Remove(curr_row)
                dgvMetaRules.Rows.Insert(curr_index + i, curr_row)

            End If

        Catch ex As Exception

            ' do nothing if error encountered while trying to move the row up or down

        End Try

    End Sub

    Private Sub swapRows(ByVal range As mode)
        Dim iSelectedRow As Integer = -1
        For iTmp As Integer = 0 To dgvMetaRules.Rows.Count - 1 'Temp Row Index
            If dgvMetaRules.Rows(iTmp).Selected Then
                iSelectedRow = iTmp
                Exit For
            End If
        Next

        If iSelectedRow <> -1 Then
            Dim sTmp(4) As String 'Temp Row
            For iTmp As Integer = 0 To dgvMetaRules.Columns.Count - 1
                sTmp(iTmp) = dgvMetaRules.Rows(iSelectedRow).Cells(iTmp).Value.ToString
            Next

            Dim iNewRow As Integer
            If range = mode.down Then
                iNewRow = iSelectedRow + 1
            ElseIf range = mode.up Then
                iNewRow = iSelectedRow - 1
            End If
            If iNewRow < 0 Then
                MsgBox("You went to far")
                Exit Sub
            ElseIf iNewRow = dgvMetaRules.Rows.Count - 1 Then
                MsgBox("You went to far")
                Exit Sub
            End If


            If range = mode.up Or range = mode.down Then
                For iTmp As Integer = 0 To dgvMetaRules.Columns.Count - 1

                    If dgvMetaRules.CurrentRow.Index < 0 Then
                        MsgBox("Row out of range - #MovingRows")
                        Exit Sub
                    Else
                        Try
                            dgvMetaRules.Rows(iSelectedRow).Cells(iTmp).Value = dgvMetaRules.Rows(iNewRow).Cells(iTmp).Value
                            dgvMetaRules.Rows(iNewRow).Cells(iTmp).Value = sTmp(iTmp)
                        Catch
                            MsgBox("You went to far")
                        End Try
                    End If
                Next
                toSelect(iNewRow)
                dgvMetaRules.ClearSelection()
                dgvMetaRules.Rows(iNewRow).Selected = True
            ElseIf range = mode.top Or range = mode.bottom Then
                'Try
                reshuffleRows(sTmp, iSelectedRow, range)
                'Catch
                'MsgBox("You went to far")
                'End Try
            End If
            dgvMetaRules.ClearSelection()
            dgvMetaRules.Rows(iNewRow).Selected = True
            dgvMetaRules.Refresh()
            index = iNewRow
            'dgvMetaRules.CurrentCell = dgvMetaRules.Rows(iNewRow).Cells(0)
            'dgvMetaRules.Rows(1).Selected = False
        End If

    End Sub

    Private Sub toSelect(ByVal iNewRow As Integer)
        dgvMetaRules.Rows(iNewRow).Selected = True
    End Sub

    Private Sub reshuffleRows(ByVal sTmp() As String, ByVal iSelectedRow As Integer, ByVal Range As mode)
        If Range = mode.top Then
            Dim iFirstRow As Integer = 0
            If iSelectedRow > iFirstRow Then
                For iTmp As Integer = iSelectedRow To 1 Step -1
                    For iCol As Integer = 0 To dgvMetaRules.Columns.Count - 1
                        dgvMetaRules.Rows(iTmp).Cells(iCol).Value = dgvMetaRules.Rows(iTmp - 1).Cells(iCol).Value
                    Next
                Next
                For iCol As Integer = 0 To dgvMetaRules.Columns.Count - 1
                    dgvMetaRules.Rows(iFirstRow).Cells(iCol).Value = sTmp(iCol).ToString
                Next
                toSelect(iFirstRow)
            End If
        Else
            Dim iLastRow As Integer = dgvMetaRules.Rows.Count - 1
            If iSelectedRow < iLastRow Then
                For iTmp As Integer = iSelectedRow To iLastRow - 1
                    For iCol As Integer = 0 To dgvMetaRules.Columns.Count - 1
                        dgvMetaRules.Rows(iTmp).Cells(iCol).Value = dgvMetaRules.Rows(iTmp + 1).Cells(iCol).Value
                    Next
                Next
                For iCol As Integer = 0 To dgvMetaRules.Columns.Count - 1
                    dgvMetaRules.Rows(iLastRow).Cells(iCol).Value = sTmp(iCol).ToString
                Next
                toSelect(iLastRow)
            End If
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        HelpAbout()
    End Sub

    Private Sub HelpAbout()

        Dim aboutDialog As New About() 'Creating instance of About Form

        If aboutDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

        End If

        aboutDialog.Dispose()

    End Sub

    Private Sub OptionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem1.Click

        Dim optionsDialog As New Options()
        optionsDialog.txtXMLdir.Text = My.Settings.XMLOpenSave
        optionsDialog.txtMetaDir.Text = My.Settings.MetaExportDir
        optionsDialog.txtNavDir.text = My.Settings.NavDir
        If optionsDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            My.Settings.XMLOpenSave = optionsDialog.txtXMLdir.Text
            My.Settings.MetaExportDir = optionsDialog.txtMetaDir.Text
            My.Settings.NavDir = optionsDialog.txtNavDir.Text
            My.Settings.Save()
        Else

        End If
        optionsDialog.Dispose()
    End Sub

    Private Sub btnInsertRule_Click(sender As Object, e As EventArgs) Handles btnInsertRule.Click


        Dim allRow As DataRow = table.NewRow
        allRow(0) = cBoxCType.Text
        allRow(1) = cBoxAType.Text



        allRow(2) = txtBoxCData.Text
        allRow(3) = cBoxAType.Text
        allRow(4) = cBoxCTMetaState.Text
        table.Rows.InsertAt(allRow, (dgvMetaRules.CurrentRow.Index))




        '*************Dont think this is needed ************
        'If cBoxAType.SelectedIndex = 1 Then
        '    Dim allRow As DataRow = table.NewRow
        '    allRow(0) = cBoxCType.Text
        '    allRow(1) = cBoxAType.Text
        '    allRow(2) = txtBoxCData.Text
        '    allRow(3) = cBoxAType.Text
        '    allRow(4) = cBoxCTMetaState.Text
        '    table.Rows.InsertAt(allRow, (dgvMetaRules.CurrentRow.Index))

        '    'table.Rows.InsertAt()
        '    'table.Rows.InsertAt(cBoxCTMetaState.Text, cBoxCType.Text, txtBoxCData.Text, cBoxAType.Text, cBoxATMetaState.Text)
        'Else
        '    Dim allRow As DataRow = table.NewRow
        '    allRow(0) = cBoxCType.Text
        '    allRow(1) = cBoxAType.Text
        '    allRow(2) = txtBoxCData.Text
        '    allRow(3) = txtBoxAData.Text
        '    allRow(4) = cBoxCTMetaState.Text
        '    table.Rows.InsertAt(allRow, (dgvMetaRules.CurrentRow.Index))
        '    'table.Rows.Add(cBoxCTMetaState.Text, cBoxCType.Text, txtBoxCData.Text, cBoxAType.Text, txtBoxAData.Text)
        'End If

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        txtBoxAData.Width = Me.Width - 200
        txtBoxAData2.Width = Me.Width - 200
        txtBoxAData3.Width = Me.Width - 200
        txtBoxCData.Width = Me.Width - 200
        txtBoxCData2.Width = Me.Width - 200

        dgvMetaRules.Height = Me.Height - 600
        dgvMetaRules.Width = Me.Width - 35

    End Sub

    Private Sub tsbExportMeta_Click(sender As Object, e As EventArgs) Handles tsbExportMeta.Click
        MetaExport()
    End Sub

    Private Sub dgvMetaRules_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMetaRules.CellClick
        ' get the index of the selected datagridview row

        'table Display Index
        'Column(0) = State
        'Column(1) = Condition Type
        'Column(2) = Condition Data
        'Column(3) = Action Type
        'Column(4) = Action Data
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        Dim sMetaStateFlag As Boolean = False   'is Action Type a Set or Call Meta State - used to change where Data appears
        'Dim bDoubleValue As Boolean = False     '   To Flag if this is a double value for Data, and if so, parse (split) it and add to 2 textboxes
        Dim ATypeTable As Integer = 0           ' 0=no data (a zero 0), 1 = 1 value, 2 = 2 values, 3 = 3 values, 4 = Multiple Table
        Dim CAnyAllTable As Integer = 0         ' 0= single value, 1 = Double Value, 2 = Any/All Table, 3 = Triple Value
        'Dim AMultipleTable As Boolean = False   '  To Flag if it is Multiple table - If so, split contents and add to new table.

        selectedRow = dgvMetaRules.Rows(index)
        SetForm.ResetAll()
        SetForm.CTSet(selectedRow.Cells(0).Value.ToString())
        cBoxCType.Text = selectedRow.Cells(0).Value.ToString()



        'sMetaStateFlag = False

        ' show data from the selected row to textboxes

        If index >= 0 Then
            selectedRow = dgvMetaRules.Rows(index)
            'MessageBox.Show("index = " & index & vbCr & "(0).Value=" & selectedRow.Cells(0).Value.ToString & vbCr & "(1).Value=" & selectedRow.Cells(1).Value.ToString & vbCr & "(2).Value=" & selectedRow.Cells(2).Value.ToString & vbCr & "(3).Value=" & selectedRow.Cells(3).Value.ToString & vbCr & "(4).Value=" & selectedRow.Cells(4).Value.ToString)

            '-- CType Column 0
            Select Case selectedRow.Cells(0).Value.ToString()
                Case ""
                    SetForm.BlankRow()
                Case "Never"
                    'SetForm.CTNever()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "Always"

                    'SetForm.CTAlways()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "All"
                    CAnyAllTable = 2
                    'MsgBox("Not yet Implemented")
                    'SetForm.CTAlways()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                    'Need to add in more logic for changing look of the form.
                Case "Any"
                    CAnyAllTable = 2
                    'MsgBox("Not yet Implemented")
                    'SetForm.CTAny()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                    'Need to add in more logic for changing look of the form.
                Case "ChatMessage"
                    'SetForm.CTChatMessage()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "MainPackSlotesLE"
                    'SetForm.CTMainPackSlotsLE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "SecondsInStateGE"
                    'SetForm.CTSecondsinStateGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "NavrouteEmpty"
                    'SetForm.CTNavRouteEmpty()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "Died"
                    'SetForm.CTDied()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "VendorOpen"
                    'SetForm.CTVendorOpen()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "VendorClosed"
                    'SetForm.CTVendorClosed()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "ItemCountLE"
                    'SetForm.CTItemCountLE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                    CAnyAllTable = 1
                Case "ItemCountGE"
                    'SetForm.CTItemCountGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                    CAnyAllTable = 1
                Case "MonsterCountWithinDistance"
                    CAnyAllTable = 3
                    'SetForm.CTMonsterCountWithinDistance()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "MonstersWithPriorityWithinDistance"
                    CAnyAllTable = 3
                    'SetForm.CTMonsterWithPriorityWithinDistance()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "NeedToBuff"
                    'SetForm.CTNeedToBuff()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "NoMonstersWithinDistance"
                    'SetForm.CTNoMonsterWithinDistance()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "LandBlockE"
                    'SetForm.CTLandBlockE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "LandCellE"
                    'SetForm.CTLandColumnE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "PortalspaceEnter"
                    'SetForm.CTPortalSpaceEnter()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "PortalspaceExit"
                    'SetForm.CTPortalSpaceExit()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "Not"
                    CAnyAllTable = 2
                    'SetForm.CTNot()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "SecondsInStatePersistGE"
                    'MsgBox("Not yet Implemented")
                    'SetForm.CTSecondsInStatePersistGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "TimeLeftOnSpellGE"
                    'SetForm.CTTimeLeftOnSpellGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "BurdenPercentGE"
                    'SetForm.CTBurdenPercentGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "DistanceToAnyRoutePointGE"
                    'SetForm.CTDistanceToAnyRoutePointGE()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "Expression"
                    'SetForm.CTExpression()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "ClientDialogPopup"
                    MsgBox("Not yet Implemented")
                    'SetForm.CTClientDialogPopup()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                Case "ChatMessageCapture"
                    'SetForm.CTChatMessageCapture()
                    'cBoxCType.Text = selectedRow.Cells(0).Value.ToString()
                    CAnyAllTable = 1
                Case Else
                    'MessageBox.Show("Row.Cells(0).Value=" & selectedRow.Cells(0).Value.ToString)
            End Select

            '-- AType Column 1
            'removed excessive lines and simplified. 8/8/17  Should fix some problems when refreshing data.  Can simplify further if need be.  Tested and works 8/8
            SetForm.ATSet(selectedRow.Cells(1).Value.ToString())
            cBoxAType.Text = selectedRow.Cells(1).Value.ToString()

            Select Case selectedRow.Cells(1).Value.ToString()
                Case "None"
                Case "SetState"
                    sMetaStateFlag = True
                    cBoxATMetaState.Text = selectedRow.Cells(3).Value.ToString()
                Case "ChatCommand"
                Case "Multiple"
                    ATypeTable = 4
                 ' MsgBox("Not yet Implemented")
                 'Add Logice to change form for all conditon, and change form
                Case "EmbeddedNavRoute"
                Case "CallState"
                    ATypeTable = 5
                    'sMetaStateFlag = True
                Case "ReturnFromCall"
                Case "ExpressionAct"
                Case "ChatWithExpression"
                Case "WatchdogSet"
                    ATypeTable = 3
                Case "WatchdogClear"
                Case "GetVTOption"
                    ATypeTable = 2
                Case "SetVTOption"
                    ATypeTable = 6
                Case "CreateView"
                    ATypeTable = 2
                Case Else
                    'MessageBox.Show("Out of Range - Meta Export Action Type")

            End Select
            '-- CData Column 2
            Select Case CAnyAllTable
                Case 0 'single value
                    txtBoxCData.Text = selectedRow.Cells(2).Value.ToString()
                Case 1 'double value 
                    Dim cData As String = selectedRow.Cells(2).Value
                    Dim StringSplit() As String
                    StringSplit = Split(cData, ";")
                    txtBoxCData.Text = StringSplit(0).ToString
                    txtBoxCData2.Text = StringSplit(1).ToString
                Case 2 'table value
                    Dim cData As String = selectedRow.Cells(2).Value.ToString ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
                    'Dim StringSplit() As String
                    TableAnyAll.Clear()

                    '-------------------Add Regex-------------
                    Dim myAllNest As New RegX(cData, RegXAnyAllNot, False)

                    'Dim myAllNest As New AnyAll(cData, "(Any: ){(.*?}})|(Any){(.*?}})|(Any: ){(.*?})[A-Z]|(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?}})[A-Z]|(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)

                    '-------
                    'StringSplit = Split(cData, "}")
                    'For Each s As String In StringSplit
                    '    Dim tempstring() As String
                    '    tempstring = Split(s, "{")
                    '    If tempstring(0) = "" Then
                    '        Exit For
                    '    Else
                    '        TableAnyAll.Rows.Add(tempstring(0), tempstring(1))
                    '    End If
                    'Next

                    'For Each s As String In StringSplit
                    '    Dim tempstring() As String
                    '    tempstring = Split(s, "{")
                    '    ' Spliting Mulitples
                    '    If tempstring(0) = "Any" Then
                    '        's = s.Length - 1
                    '        TableAnyAll.Rows.Add("Any", cData.Remove(0, 4))
                    '        Exit For
                    '    ElseIf tempstring(0) = "All" Then
                    '        's = s.Length - 1
                    '        TableAnyAll.Rows.Add("All", cData.Remove(0, 4))
                    '        Exit For
                    '    ElseIf tempstring(0) = "Not" Then
                    '        's = s.Length - 1
                    '        TableAnyAll.Rows.Add("Not", cData)
                    '        'TableAnyAll.Rows.Add("Not", cData.Remove(0, 4))
                    '        Exit For
                    '    ElseIf tempstring(0) = "" Then
                    '        Exit For
                    '    Else
                    '        TableAnyAll.Rows.Add(tempstring(0), tempstring(1))
                    '    End If
                    'Next


                    dgvAnyAll.DataSource = myAllNest.MultiTable
                    dgvAnyAll.Refresh()
                Case 3
                    Dim cData As String = selectedRow.Cells(2).Value
                    Dim StringSplit() As String
                    StringSplit = Split(cData, ";")
                    txtBoxCData.Text = StringSplit(0).ToString
                    txtBoxCData2.Text = StringSplit(1).ToString
                    txtBoxCData3.Text = StringSplit(2).ToString
            End Select

            '-- AData Column 3
            If sMetaStateFlag = False Then
                Select Case ATypeTable
                    Case 0, 1   'single value
                        txtBoxAData.Text = selectedRow.Cells(3).Value.ToString()
                    Case 2      'double value
                        Dim Adata As String = selectedRow.Cells(3).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(Adata, ";")
                        txtBoxAData.Text = StringSplit(0).ToString
                        txtBoxAData2.Text = StringSplit(1).ToString
                    Case 3      'triple value
                        Dim Adata As String = selectedRow.Cells(3).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(Adata, ";")
                        txtBoxAData.Text = StringSplit(0).ToString
                        txtBoxAData2.Text = StringSplit(1).ToString
                        txtBoxAData3.Text = StringSplit(2).ToString
                    Case 4      'table value
                        Dim Adata As String = selectedRow.Cells(3).Value ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
                        Dim myMultipleNest As New RegX(Adata, RegXMultiple, False)

                        'Dim myMultipleNest As New AnyAll(Adata, RegXMultiple, False)

                        'Dim StringSplit() As String
                        'TableATMultiple.Clear()
                        'StringSplit = Split(Adata, "}")
                        'For Each s As String In StringSplit
                        '    Dim tempstring() As String
                        '    tempstring = Split(s, "{")
                        '    ' Spliting Mulitples
                        '    If tempstring(0) = "Multiple" Then
                        '        's = s.Length - 1
                        '        TableATMultiple.Rows.Add("Multiple", Adata.Remove(0, 9))
                        '        Exit For
                        '    ElseIf tempstring(0) = "" Then
                        '        Exit For
                        '    Else
                        '        TableATMultiple.Rows.Add(tempstring(0), tempstring(1))
                        '    End If
                        'Next
                        dgvATMultiple.DataSource = myMultipleNest.MultiTable
                        dgvATMultiple.Refresh()

                    Case 5
                        Dim Adata As String = selectedRow.Cells(3).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(Adata, ";")
                        cBoxATMetaState.Text = StringSplit(0).ToString
                        cboxReturnMetaState.Text = StringSplit(1).ToString
                    Case 6 'Set Options
                        Dim Adata As String = selectedRow.Cells(3).Value.ToString()
                        Dim StringSplit() As String
                        StringSplit = Split(Adata, ";")

                        txtBoxAData.Text = StringSplit(0).ToString
                        txtBoxAData2.Text = StringSplit(1).ToString
                        lstBoxCommonOptions.SetSelected(1, False)
                        lstBoxCommonOptions.SelectedItem = txtBoxAData.Text
                        If StringSplit(1).ToString = "True" Then
                            rdbTrue.Checked = True
                            rdbFalse.Checked = False
                        End If
                    Case Else
                        MsgBox("Out of Range - frmMain.dgvMetaRules.CellClick Case AtypeTable")
                End Select

            End If

            '-- Meta State Column 4
            cBoxCTMetaState.Text = selectedRow.Cells(4).Value.ToString()
        Else

        End If
    End Sub


    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved your work, are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
            'nothing to do here the form is already closing
                Case Windows.Forms.DialogResult.No
                    e.Cancel = True 'cancel the form closing event
                    'minimize to tray/hide etc here 

            End Select
        End If

    End Sub

    Private Sub btnCreateRule_ContextMenuChanged(sender As Object, e As EventArgs) Handles btnCreateRule.ContextMenuChanged

    End Sub

    Sub btnAddCdata_Click(sender As Object, e As EventArgs) Handles btnAddAnyAll.Click

        Dim SecondTableDialog As New frmSecondaryTable()
        SecondTableDialog.cBoxAType.Visible = False
        GlobalVars.SetFormType = 1
        SecondTableDialog.Text = "Any/All/NOT Dialog"
        SecondTableDialog.lblCbox.Text = "Choose Condition Type:"
        SecondTableDialog.TextBox1.Text = ""
        SecondTableDialog.cBoxType.Items.AddRange([Enum].GetNames(GetType(MetaConditionTypeID)))
        SecondTableDialog.cBoxType.SelectedIndex = 0
        SecondTableDialog.TableType = 1
        If SecondTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            Select Case SecondTableDialog.cBoxType.SelectedIndex
                Case 0, 1, 7 To 10, 15, 19, 20 'Empty Values Set As a ZERO
                    TableAnyAll.Rows.Add(SecondTableDialog.cBoxType.Text, "0")

                Case 11, 12, 28  'Double Values
                    TableAnyAll.Rows.Add(SecondTableDialog.cBoxType.Text, Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a"))
                Case 13, 14     'Triple Values
                    TableAnyAll.Rows.Add(SecondTableDialog.cBoxType.Text, Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text))
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
                    TableAnyAll.Rows.Add(SecondTableDialog.cBoxType.Text, tempdata)



                Case Else ' Single Values
                    TableAnyAll.Rows.Add(SecondTableDialog.cBoxType.Text, SecondTableDialog.TextBox1.Text) ' Single Values
            End Select

        Else
            'MsgBox("Click Cancel")
        End If

        dgvAnyAll.DataSource = TableAnyAll
        dgvAnyAll.Refresh()
        SecondTableDialog.Dispose()

    End Sub

    Private Sub btnDeleteAnyAll_Click(sender As Object, e As EventArgs) Handles btnDeleteAnyAll.Click

        If dgvAnyAll.CurrentRow.Index = Nothing Then

            MsgBox("You can not delete the top or bottom (blank) row... Yet")
        ElseIf dgvAnyAll.CurrentRow.Index >= 0 Then
            Try
                dgvAnyAll.Rows.RemoveAt(tAnyAllIndex)
            Catch
                MsgBox("You Can't remove that row - Index is: " + dgvAnyAll.CurrentRow.Index.ToString)
            End Try
        Else
            MsgBox("Rows out of range")
        End If

    End Sub

    Private Sub btnEditAnyAll_Click(sender As Object, e As EventArgs) Handles btnEditAnyAll.Click

        Dim selectedRow As DataGridViewRow

        '------Opening new Window to edit Table Value---------
        Dim SecondTableDialog As New frmSecondaryTable()
        selectedRow = dgvAnyAll.Rows(tAnyAllIndex)
        GlobalVars.SetFormType = 1

        If selectedRow.Cells(0).Value IsNot Nothing Then
            SecondTableDialog.cBoxAType.Visible = False
            SecondTableDialog.cBoxType.Items.AddRange([Enum].GetNames(GetType(MetaConditionTypeID)))
            SecondTableDialog.cBoxType.Text = selectedRow.Cells(0).Value.ToString
            SecondTableDialog.Text = "Any/All/NOT Dialog"
            SecondTableDialog.lblCbox.Text = "Choose Condition Type:"

            Select Case selectedRow.Cells(0).Value.ToString
                Case "Never", "Always" ' Not USING

                Case "All", "Any", "Not" ' For nested tables


                    Dim myNest As New RegX(selectedRow.Cells(1).Value.ToString(), RegXAnyAllNot, False)
                    SecondTableDialog.tableMultiple = myNest.MultiTable
                    SecondTableDialog.EditTable = True

                Case "ChatMessage", "Expression", "LandBlockE", "LandCellE"
                    SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                Case "ItemCountLE", "ItemCountGE", "ChatMessageCapture"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                    SecondTableDialog.TextBox3.Text = StringSplit(1).ToString
                Case "MonsterCountWithinDistance", "MonstersWithPriorityWithinDistance"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.TextBox1.Text = StringSplit(0).ToString
                    SecondTableDialog.TextBox2.Text = StringSplit(1).ToString
                    SecondTableDialog.TextBox3.Text = StringSplit(2).ToString

                Case Else
                    SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
            End Select
        Else
            MsgBox("Please select the row and try again - btnEditAnyAll SelectedRowIndex is Null")
            Exit Sub
        End If

        '-------After Window Closing updating Table Fields
        If SecondTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            Dim newDataRow As DataGridViewRow
            newDataRow = dgvAnyAll.Rows(tAnyAllIndex)

            newDataRow.Cells(0).Value = SecondTableDialog.cBoxType.Text

            Select Case SecondTableDialog.cBoxType.SelectedIndex
                Case 2, 3, 21 ' Not USING 'AnyAllNot

                    Dim tempdata As String = ""
                    For Each r As DataGridViewRow In SecondTableDialog.dgvMultiple.Rows
                        If r.Cells(0).Value IsNot Nothing Then
                            tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                        Else
                            'MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                        End If
                    Next
                    newDataRow.Cells(1).Value = tempdata

                Case 0, 1, 4 To 10, 15 To 20, 22 To 26          'Single Values - ChatMessage,
                    newDataRow.Cells(1).Value = SecondTableDialog.TextBox1.Text
                Case 11, 12, 28     'Double Values - ItemCountLE, ItemCountGE
                    newDataRow.Cells(1).Value = Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a")
                Case 13, 14
                    newDataRow.Cells(1).Value = Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text)
                Case Else
                    'newDataRow.Cells(1).Value = SecondTableDialog.TextBox1.Text
            End Select

            'MsgBox("Click OK")
        Else
            'MsgBox("Click Cancel")
        End If
        SecondTableDialog.Dispose()
        'ListBoxCTDataAnyAll.Items.Item()

        ' MsgBox("Ctype =" & cAnyAll.ToString() & "CData =" & cAnyAll.Category)

    End Sub

    Private Sub btnChooseNav_Click(sender As Object, e As EventArgs) Handles btnChooseNav.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Nav Files|*.nav"
        ofd.Title = "Select Nav File to Embed"
        ofd.InitialDirectory = My.Settings.MetaExportDir

        If ofd.ShowDialog = DialogResult.OK Then
            txtBoxAData.Text = ofd.FileName

        Else
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

        'Meta.NavRoute()
        Dim ofd As New OpenFileDialog()

        ofd.Filter = "Nav Files|*.nav"
        'ofd.InitialDirectory = My.Settings.XMLOpenSave
        If ofd.ShowDialog = DialogResult.OK Then
            txtBoxAData.Text = ofd.FileName

        End If

    End Sub



    Sub SetAnyAllTable()

        Dim TableAnyAll As New DataTable("TableAnyAll")
        TableAnyAll.Columns.Add("Type", Type.GetType("System.String"))
        TableAnyAll.Columns.Add("Data", Type.GetType("System.String"))

        ' Add row to the datatable with some data
        'TableAnyAll.Rows.Add("ChatWithExpression", "Hello Dereth")

        'set data from datatable to datagridview

        dgvAnyAll.DataSource = TableAnyAll
        dgvAnyAll.Columns("Type").DisplayIndex = 0
        dgvAnyAll.Columns("Data").DisplayIndex = 1

        dgvAnyAll.Columns(0).Width = dgvAnyAll.Width * 0.35
        dgvAnyAll.Columns(1).Width = dgvAnyAll.Width * 0.65


        dgvAnyAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAnyAll.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan
        'dgvAnyAll.Sort(dgvAnyAll.Columns(4), ListSortDirection.Ascending)
        dgvAnyAll.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgvAnyAll.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable


        'DataGridView1.Rows(0).Selected = True
        'swapRows(mode.down)
        'DataGridView1.Rows.RemoveAt(0)
        'dgvAnyAll.Rows(0).Selected = True
    End Sub



    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click


        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved current file, save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    xml.SaveXML()
                    dgvMetaRules.DataSource = NewXML(table)
                    xml.DefaultsXML()
                Case Windows.Forms.DialogResult.No
                    dgvMetaRules.DataSource = NewXML(table)
                    xml.DefaultsXML()
            End Select
        Else
            dgvMetaRules.DataSource = NewXML(table)
            xml.DefaultsXML()
        End If
        FileName = ""
        index = 0
        Text = "Mission:Impossible - Meta Builder   FILE= NOT SAVED!"
    End Sub

    Private Sub ToolStripButtonOpen_Click(sender As Object, e As EventArgs) Handles ToolStripButtonOpen.Click

        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved current file, save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    xml.SaveXML()
                    dgvMetaRules.DataSource = LoadXML(table)
                Case Windows.Forms.DialogResult.No
                    dgvMetaRules.DataSource = LoadXML(table)
            End Select
        Else
            dgvMetaRules.DataSource = LoadXML(table)

        End If


    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        xml.SaveXML()
    End Sub

    Private Sub ToolStripButtonExport_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExport.Click
        Meta.MetaExport()
    End Sub

    Private Sub OpenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem1.Click

        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved current file, save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    xml.SaveXML()
                    dgvMetaRules.DataSource = LoadXML(table)
                Case Windows.Forms.DialogResult.No
                    dgvMetaRules.DataSource = LoadXML(table)
            End Select
        Else
            dgvMetaRules.DataSource = LoadXML(table)

        End If

    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        xml.SaveXML()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

        Dim optionsDialog As New Options()
        optionsDialog.txtXMLdir.Text = My.Settings.XMLOpenSave
        optionsDialog.txtMetaDir.Text = My.Settings.MetaExportDir
        optionsDialog.txtNavDir.Text = My.Settings.NavDir
        optionsDialog.chkMetaExportDebug.Checked = My.Settings.MetaDebug
        If optionsDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            My.Settings.XMLOpenSave = optionsDialog.txtXMLdir.Text
            My.Settings.MetaExportDir = optionsDialog.txtMetaDir.Text
            My.Settings.NavDir = optionsDialog.txtNavDir.Text
            My.Settings.MetaDebug = optionsDialog.chkMetaExportDebug.Checked
            My.Settings.Save()
        Else

        End If
        optionsDialog.Dispose()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem1.Click

        If SaveWork = True Then
            Select Case MessageBox.Show("You have not saved current file, save changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    xml.SaveXML()
                    dgvMetaRules.DataSource = NewXML(table)
                    xml.DefaultsXML()

                Case Windows.Forms.DialogResult.No
                    dgvMetaRules.DataSource = NewXML(table)
                    xml.DefaultsXML()

            End Select
        Else
            dgvMetaRules.DataSource = NewXML(table)
            xml.DefaultsXML()

        End If
        FileName = ""
        index = 0
        Text = "Mission:Impossible - Meta Builder   FILE= NOT SAVED!"
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        About.Show()
    End Sub

    Private Sub dgvAnyAll_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnyAll.CellClick
        tAnyAllIndex = e.RowIndex
    End Sub

    Private Sub btnAddATAnyAll_Click(sender As Object, e As EventArgs) Handles btnAddATAnyAll.Click

        Dim SecondTableDialog As New frmSecondaryTable()
        GlobalVars.SetFormType = 2
        SecondTableDialog.cBoxType.Visible = False
        SecondTableDialog.Text = "Action Mulitiple Dialog"
        SecondTableDialog.lblCbox.Text = "Choose Action Type:"
        SecondTableDialog.TextBox1.Text = ""
        SecondTableDialog.cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))
        SecondTableDialog.cBoxAType.SelectedIndex = 0
        SecondTableDialog.TableType = 2

        If SecondTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then

            Select Case SecondTableDialog.cBoxAType.SelectedIndex
                Case 0, 6, 10, 15       'Zero Values - Remove 3 This is temp till Nested Tables are in
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, "0")
                Case 1           'Meta States
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, SecondTableDialog.cBoxMetaState.Text)
                Case 2, 4, 7, 8, 14  'Single Values
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, SecondTableDialog.TextBox1.Text)
                Case 5           'Meta States

                    'TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a"))

                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, Parse.CombineTwoVal(SecondTableDialog.cBoxMetaState.Text, SecondTableDialog.cBoxMetaStateTwo.Text, "a"))
                Case 9              'Triple Value
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text))
                Case 11, 12, 13         'Double Values
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a"))
                Case 3         'Multiple  -- Supposed to be 3.  This is Temp till Nested Tables are in
                    Dim tempdata As String = ""
                    For Each r As DataGridViewRow In SecondTableDialog.dgvMultiple.Rows
                        If r.Cells(0).Value IsNot Nothing Then
                            'tempdata = tempdata & r.Cells(0).Value.ToString & r.Cells(1).Value.ToString
                            tempdata = tempdata & r.Cells(0).Value.ToString & "{" & r.Cells(1).Value.ToString & "}"
                        Else
                            'MsgBox("Value is Nothing - frmSecondaryTable.CombineMultipleAction")
                        End If
                    Next
                    TableATMultiple.Rows.Add(SecondTableDialog.cBoxAType.Text, tempdata)
                Case Else           'Should not happen, but...
                    MsgBox("Out Of Range - btnAddATAnyAll_Click Case SecondTableDialog")

            End Select

        Else
            'MsgBox("Click Cancel")
        End If

        dgvATMultiple.DataSource = TableATMultiple
        dgvATMultiple.Refresh()
        SecondTableDialog.Dispose()


    End Sub

    Private Sub btnEditATAnyAll_Click(sender As Object, e As EventArgs) Handles btnEditATAnyAll.Click
        Dim selectedRow As DataGridViewRow

        '------Opening new Window to edit Table Value---------
        Dim SecondTableDialog As New frmSecondaryTable()
        selectedRow = dgvATMultiple.Rows(tATMultipleIndex)
        GlobalVars.SetFormType = 2

        If selectedRow.Cells(0).Value IsNot Nothing Then
            SecondTableDialog.cBoxType.Visible = False
            SecondTableDialog.Text = "EDIT Action Mulitiple Dialog"
            SecondTableDialog.cBoxAType.Items.AddRange([Enum].GetNames(GetType(MetaActionTypeID)))
            SecondTableDialog.cBoxAType.Text = selectedRow.Cells(0).Value.ToString
            SecondTableDialog.lblCbox.Text = "Choose Action Type:"


            Select Case selectedRow.Cells(0).Value.ToString
                Case "None" ' Not USING
                Case "ChatCommand", "EmbeddedNaveRoute", "ExpressionAct", "ChatWithExpression", "DestroyView"
                    SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
                Case "SetState"
                    'SecondTableDialog.cBoxMetaState.Text = selectedRow.Cells(1).Value.ToString
                    SecondTableDialog.FormSelection = 1
                    SecondTableDialog.TextOne = selectedRow.Cells(1).Value.ToString
                Case "CallState"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.FormSelection = 5
                    SecondTableDialog.TextOne = StringSplit(0).ToString
                    SecondTableDialog.TextTwo = StringSplit(1).ToString

                    'SecondTableDialog.cBoxMetaState.Text = StringSplit(0).ToString
                    'SecondTableDialog.cBoxMetaStateTwo.Text = StringSplit(1).ToString

                Case "GetVTOption", "SetVTOption", "CreateView"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                    SecondTableDialog.TextBox3.Text = StringSplit(1).ToString
                    If StringSplit(1).ToString = "True" Then
                        SecondTableDialog.rdbTrue.Checked = True
                        SecondTableDialog.rdbFalse.Checked = False
                    End If
                Case "CreateView"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()

                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.TextBox2.Text = StringSplit(0).ToString
                    SecondTableDialog.TextBox3.Text = StringSplit(1).ToString

                Case "WatchdogSet"
                    Dim tempData As String = selectedRow.Cells(1).Value.ToString()
                    Dim StringSplit() As String
                    StringSplit = Split(tempData, ";")
                    SecondTableDialog.TextBox1.Text = StringSplit(0).ToString
                    SecondTableDialog.TextBox2.Text = StringSplit(1).ToString
                    SecondTableDialog.TextBox3.Text = StringSplit(2).ToString
                Case "Multiple" ' Needs Work to finish
                    'This Function Prepares the strings for adding into a Multiple Table - I need to figure out how to Pass Data Back, Thinking as a string array.
                    'If selectedRow.Cells(1).Value.ToString().Contains("Multiple: ") Then

                    '    Dim myNest As New AnyAll(selectedRow.Cells(1).Value.ToString(), "(Multiple: ){(.*?})}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)
                    '    'If MultipleString.Contains("Multiple: ") Then
                    '    '     If MultipleString.Contains("Multiple: ") Then
                    '    'nested, need to write another parser I think

                    '    'TextBox2.Text = regxMatch(multipleString, "Multiple{(.*)", True)

                    'Else
                    '    'SecondTableDialog.TableSecondaryMultiple = AnyAll.regxMatch(MultipleString, selectedRow.Cells(1).Value.ToString(), False)
                    '    Dim myNest As New AnyAll(selectedRow.Cells(1).Value.ToString(), "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)
                    '    'Dim myNest As New AnyAll(selectedRow.Cells(1).Value.ToString(), "(\w+):\s{(\w+)}|(\w+):\s{(\w+;\w+)}|(\w+):\s{(\w+;\w+;\w+)}", False)
                    '    'With myNest
                    '    '    .InputString = selectedRow.Cells(1).Value.ToString()
                    '    '    .RegexPattern = "(\w+):\s{(\w+)}|(\w+):\s{(\w+;\w+)}|(\w+):\s{(\w+;\w+;\w+)}"
                    '    '    .MultipleNested = False
                    '    'End With
                    '    'Set secondform datatable
                    '    SecondTableDialog.tableMultiple = myNest.MultiTable
                    '    SecondTableDialog.EditTable = True

                    'End If

                    'Dim tTest As String = selectedRow.Cells(1).Value.ToString()
                    'Dim tMultiple() As String
                    'Dim ttTest As String = ""

                    'If selectedRow.Cells(1).Value.ToString().Contains("Multiple: ") Then
                    '    Dim Input As String = "Multiple: "
                    '    Dim Occurance As Integer = New AnyAll(selectedRow.Cells(1).Value.ToString(), Input, 1).Occurence
                    '    Dim teststring As String = ""

                    '    For c = 0 To Occurance
                    '        tMultiple(c) = New AnyAll(selectedRow.Cells(1).Value.ToString(), "(Multiple: ){(.*?})}|(Multiple: ){(.*?})M").ReturnMultiple.ToString
                    '        MsgBox(tMultiple(c))
                    '        teststring = tMultiple(c)
                    '        ttTest = tTest.Replace("Multiple:", " ")
                    '    Next
                    '    Dim myNest As New AnyAll(tTest, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)
                    '    For myC = 0 To tMultiple.Length()
                    '        myNest.MultiTable.Rows.Add("Multiple: ", tMultiple(myC))
                    '    Next

                    'Else
                    '    Dim myNest As New AnyAll(selectedRow.Cells(1).Value.ToString(), "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)
                    '    SecondTableDialog.tableMultiple = myNest.MultiTable
                    'End If






                    Dim myNestMultiple As New RegX(selectedRow.Cells(1).Value.ToString(), RegXNestedMultiple, False)
                    'Dim myNestMultiple As New AnyAll(selectedRow.Cells(1).Value.ToString(), "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)

                    SecondTableDialog.tableMultiple = myNestMultiple.MultiTable
                    SecondTableDialog.EditTable = True
                Case Else
                    SecondTableDialog.TextBox1.Text = selectedRow.Cells(1).Value.ToString
            End Select
        Else
            MsgBox("Please select the row and try again - btnEditAnyAll SelectedRowIndex is Null")
            Exit Sub
        End If



        '-------After Window Closing updating Table Fields
        If SecondTableDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            SecondTableDialog.Nested = True
            'NestedTableForm = False ' Resetting Global Variable to use default add table
            Dim newDataRow As DataGridViewRow
            newDataRow = dgvATMultiple.Rows(tATMultipleIndex)

            newDataRow.Cells(0).Value = SecondTableDialog.cBoxAType.Text

            Select Case SecondTableDialog.cBoxAType.SelectedIndex
                Case 0, 6, 10, 15               'ZeroValue
                    newDataRow.Cells(1).Value = "0"
                Case 1, 5            ' SetState,CallState
                    newDataRow.Cells(1).Value = SecondTableDialog.cBoxMetaState.Text
                Case 2, 4, 7, 8, 14      'Single Values - "ChatCommand", "EmbeddedNaveRoute", "ExpressionAct", "ChatWithExpression"
                    newDataRow.Cells(1).Value = SecondTableDialog.TextBox1.Text
                Case 11, 12, 13     'Double Values - "GetVTOption", "SetVTOption"
                    newDataRow.Cells(1).Value = Parse.CombineTwoVal(SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text, "a")
                Case 9
                    newDataRow.Cells(1).Value = Parse.CombineThreeVal(SecondTableDialog.TextBox1.Text, SecondTableDialog.TextBox2.Text, SecondTableDialog.TextBox3.Text)
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
                Case Else           'Should not happen, but...
                    MsgBox("Out Of Range - btnAddATAnyAll_Click Case SecondTableDialog")
            End Select

            'MsgBox("Click OK")
        Else
            'MsgBox("Click Cancel")
        End If

        SecondTableDialog.Dispose()

    End Sub

    Private Sub dgvATMultiple_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvATMultiple.CellContentClick

    End Sub

    Private Sub dgvAnyAll_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnyAll.CellContentClick

    End Sub

    Private Sub dgvATMultiple_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvATMultiple.CellClick
        tATMultipleIndex = e.RowIndex
    End Sub

    Private Sub btnDeleteATAnyAll_Click(sender As Object, e As EventArgs) Handles btnDeleteATAnyAll.Click
        If dgvATMultiple.CurrentRow.Index = Nothing Then

            MsgBox("You can not delete the top or bottom (blank) row... Yet")

        ElseIf dgvATMultiple.CurrentRow.Index >= 0 Then
            Try
                dgvATMultiple.Rows.RemoveAt(tATMultipleIndex)
            Catch
                MsgBox("You Can't remove that row")
            End Try

        Else
            MsgBox("Rows out of range")

        End If
    End Sub

    Private Sub btnATCreateState_Click(sender As Object, e As EventArgs) Handles btnATCreateState.Click
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
                cBoxCTMetaState.Items.Add(iBoxNewMetaState)
                cBoxATMetaState.Items.Add(iBoxNewMetaState)
                cboxReturnMetaState.Items.Add(iBoxNewMetaState)
                cBoxATMetaState.SelectedItem = iBoxNewMetaState

            End If
        Else
            'MessageBox.Show("You Clicked Cancel")
        End If

        metaDialog.Dispose()
    End Sub

    Private Sub ToolStripButtonImport_Click(sender As Object, e As EventArgs) Handles ToolStripButtonImport.Click

        'MessageBox.Show("Not Implemented")
        'dgvMetaRules.DataSource = ImportMeta.LoadMeta(table)
        ImportMeta.TempImport()
    End Sub


    Private Sub rdbTrue_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTrue.CheckedChanged
        txtBoxAData2.Text = "True"
    End Sub

    Private Sub rdbTrue_Click(sender As Object, e As EventArgs) Handles rdbTrue.Click
        rdbFalse.Checked = False
        rdbTrue.Checked = True
    End Sub

    Private Sub rdbFalse_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFalse.CheckedChanged
        txtBoxAData2.Text = "False"
    End Sub

    Private Sub rdbFalse_Click(sender As Object, e As EventArgs) Handles rdbFalse.Click
        rdbTrue.Checked = False
        rdbFalse.Checked = True
    End Sub

    Private Sub lstBoxCommonOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBoxCommonOptions.SelectedIndexChanged
        Try
            txtBoxAData.Text = lstBoxCommonOptions.SelectedItem.ToString
        Catch
        End Try

        rdbFalse.Checked = True
        txtBoxAData2.Text = False
    End Sub

    Private Sub SaveAsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem1.Click

        xml.SaveAsXML()

    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter

    End Sub
End Class