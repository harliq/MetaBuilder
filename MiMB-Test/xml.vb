Imports System.IO

Module xml
    Public Property SaveFileDialog1 As Object
    'Dim loaddt As New DataTable("loaddt")

    Public Sub SaveXML()

        If FileName = "" Then
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "XML Files|*.xml"
            sfd.InitialDirectory = My.Settings.XMLOpenSave
            GlobalVars.FileName = sfd.FileName
            If sfd.ShowDialog = DialogResult.OK Then
                Dim savedt As DataTable = CType(frmMain.dgvMetaRules.DataSource, DataTable)
                savedt.AcceptChanges()
                savedt.WriteXml(sfd.FileName, System.Data.XmlWriteMode.WriteSchema, False)
                SetForm.SaveWork = False
                frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & sfd.FileName
                GlobalVars.FileName = Path.GetFileNameWithoutExtension(sfd.FileName)
                GlobalVars.FileNameAndPath = sfd.FileName
            Else


            End If

        Else
            Dim savedt As DataTable = CType(frmMain.dgvMetaRules.DataSource, DataTable)
            savedt.AcceptChanges()
            savedt.WriteXml(GlobalVars.FileNameAndPath, System.Data.XmlWriteMode.WriteSchema, False)
            SetForm.SaveWork = False
            'MsgBox("XML Saved")
            frmMain.Cursor = Cursors.WaitCursor
            Threading.Thread.Sleep(500)
            frmMain.Cursor = Cursors.Default

            'frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & sfd.FileName
            'GlobalVars.FileName = Path.GetFileNameWithoutExtension(sfd.FileName)
            'GlobalVars.FileNameAndPath = sfd.FileName
        End If
    End Sub

    Public Sub SaveAsXML()
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "XML Files|*.xml"
        sfd.InitialDirectory = My.Settings.XMLOpenSave
        GlobalVars.FileName = sfd.FileName
        If sfd.ShowDialog = DialogResult.OK Then
            Dim savedt As DataTable = CType(frmMain.dgvMetaRules.DataSource, DataTable)
            savedt.AcceptChanges()
            savedt.WriteXml(sfd.FileName, System.Data.XmlWriteMode.WriteSchema, False)
            SetForm.SaveWork = False
            frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & sfd.FileName
            GlobalVars.FileName = Path.GetFileNameWithoutExtension(sfd.FileName)
            GlobalVars.FileNameAndPath = sfd.FileName
        Else


        End If
    End Sub

    Function LoadXML(table As DataTable) As DataTable
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "XML Files|*.xml"
        ofd.InitialDirectory = My.Settings.XMLOpenSave

        If ofd.ShowDialog = DialogResult.OK Then
            'Dim loaddt As New DataTable
            table.Clear()
            table.ReadXml(ofd.FileName)
            frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & ofd.FileName
            GlobalVars.FileName = Path.GetFileNameWithoutExtension(ofd.FileName)
            GlobalVars.FileNameAndPath = ofd.FileName
            'MsgBox("Path= " & GlobalVars.FileNameAndPath)
            'Creating Table
            Dim items = table.AsEnumerable().Select(Function(d) DirectCast(d(4).ToString(), Object)).ToArray()

            'Populating State Boxes
            frmMain.cBoxCTMetaState.Items.Clear()
            frmMain.cBoxATMetaState.Items.Clear()
            frmMain.cboxReturnMetaState.Items.Clear()
            frmMain.cBoxCTMetaState.Items.AddRange(items)
            frmMain.cBoxATMetaState.Items.AddRange(items)
            frmMain.cboxReturnMetaState.Items.AddRange(items)

            'Populating Table from XML File
            Dim i As Long
            Dim j As Long
            With frmMain.cBoxATMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With
            With frmMain.cboxReturnMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With
            With frmMain.cBoxCTMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With

        Else

        End If
        Return table
    End Function

    Function NewXML(table As DataTable) As DataTable
        table.Clear()
        frmMain.cBoxCTMetaState.Items.Clear()
        frmMain.cBoxATMetaState.Items.Clear()
        frmMain.cboxReturnMetaState.Items.Clear()

        'table.Columns.Add("Condition Type", Type.GetType("System.String"))
        'table.Columns.Add("Action Type", Type.GetType("System.String"))
        'table.Columns.Add("Condition Data", Type.GetType("System.String"))
        'table.Columns.Add("Action Data", Type.GetType("System.String"))
        'table.Columns.Add("State", Type.GetType("System.String"))

        ' Add rows to the datatable with some data
        table.Rows.Add("Never", "None", "0", "0", "Default")
        frmMain.cBoxCTMetaState.Items.Add("Default")
        frmMain.cBoxATMetaState.Items.Add("Default")
        frmMain.cboxReturnMetaState.Items.Add("Default")

        Return table
    End Function

    Sub DefaultsXML()

        frmMain.cBoxCType.SelectedIndex = 0
        frmMain.cBoxCTMetaState.SelectedIndex = 0
        frmMain.cBoxAType.SelectedIndex = 0
        frmMain.cboxReturnMetaState.SelectedIndex = 0
        frmMain.dgvMetaRules.Rows(0).Selected = True
        frmMain.Refresh()

    End Sub
End Module
