Imports System.IO

Module xml
    Public Property SaveFileDialog1 As Object
    'Dim loaddt As New DataTable("loaddt")

    Public Sub SaveXML()
        frmMain.ProgressBar1.Value = 0
        frmMain.lblProgressBar.Text = "Saving XML"
        frmMain.Refresh()
        frmMain.lblProgressBar.Visible = True
        frmMain.ProgressBar1.Visible = True
        frmMain.ProgressBar1.Increment(10)
        frmMain.Cursor = Cursors.WaitCursor
        Threading.Thread.Sleep(200)
        frmMain.ProgressBar1.Increment(20)

        If FileName = "" Then
            frmMain.ProgressBar1.Increment(40)
            frmMain.Refresh()
            Threading.Thread.Sleep(300)

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

            frmMain.ProgressBar1.Increment(40)
            frmMain.Refresh()
            Threading.Thread.Sleep(300)
            Dim savedt As DataTable = CType(frmMain.dgvMetaRules.DataSource, DataTable)
            savedt.AcceptChanges()
            savedt.WriteXml(GlobalVars.FileNameAndPath, System.Data.XmlWriteMode.WriteSchema, False)
            SetForm.SaveWork = False


        End If
        frmMain.ProgressBar1.Increment(30)
        frmMain.Refresh()
        Threading.Thread.Sleep(400)
        'frmMain.ProgressBar1.Increment(100)
        frmMain.ProgressBar1.Refresh()

        Threading.Thread.Sleep(200)
        'frmMain.ProgressBar1.Increment(80)
        frmMain.Cursor = Cursors.Default
        'MsgBox("ProgressBar = " & frmMain.ProgressBar1.Value)
        frmMain.ProgressBar1.Visible = False
        frmMain.lblProgressBar.Visible = False
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
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
                        End If
                    Next
                Next
            End With
            With frmMain.cboxReturnMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
                        End If
                    Next
                Next
            End With
            With frmMain.cBoxCTMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
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

    Function ConvertXML(table As DataTable) As DataTable

        'Dim loaddt As New DataTable
        table.Clear()
        Try
            table.ReadXml(XMLFileNameLoad)
            frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & XMLFileNameLoad
            GlobalVars.FileName = Path.GetFileNameWithoutExtension(XMLFileNameLoad)
            GlobalVars.FileNameAndPath = XMLFileNameLoad
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
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
                        End If
                    Next
                Next
            End With
            With frmMain.cboxReturnMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
                        End If
                    Next
                Next
            End With
            With frmMain.cBoxCTMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(CInt(i)).ToString = .Items(CInt(j)).ToString Then
                            .Items.RemoveAt(CInt(j))
                        End If
                    Next
                Next
            End With
        Catch
            MsgBox("Can not find file")

        End Try

        Return table
    End Function
End Module
