Module ImportMeta


    Function LoadMeta(table As DataTable) As DataTable

        Dim TempS As String = ""     'Rule Row
        Dim TempAL As String = ""    'Accrued Lines
        Dim TempL As String = ""        'Line
        Dim LineCount As Integer = 0    'Line Count
        Dim RecordCount As Integer = 0  'Record Count (if needed)
        Dim RuleCount As Integer = 0
        Dim RuleCountLine As Integer = 0
        Dim TempJunk As String = ""

        Dim vCType As String = ""            'Line 1 of Record - Condition Type Variable Code (Integer,String,etc… )
        Dim vCTypeValue As String = ""       'Line 2 of Record - Condition Type Variable Value (ex. 4=Chat Message)
        Dim vAType As String = ""            'Line 3 of Record - Action Type Variable Code (Double,Integer,String,etc… )
        Dim vATypeValue As String = ""       'Line 4 of Record - Action Type Variable Value (ex. 1=Set Meta State) 
        Dim vCData As String = ""            'Line 5 of Record - Condition Data Variable Code (Integer,String,etc… )
        Dim vCDataValue As String = ""       'Line 6 of Record - Condition Data Variable Value 
        Dim vAData As String = ""            'Line 7 of Record - Action Data Variable Code (Integer,String,etc… 
        Dim vADataValue As String = ""       'Line 8 of Record - Action Data Variable Value
        Dim vState As String = ""            'Line 9 of Record - State Variable Code (String, Haven’t seen it any other way yet)
        Dim vStateValue As String = ""       'Line 10 of Record - State Variable Value (Name of State)

        Dim vCTypeConv As String = ""       ' For Converting Condtion Type Variable to Associated Condtion Rule Type
        Dim vATypeConv As String = ""       ' For Converting Action Type Variable to Asscoiated Condtion Rule Type


        '-- New Vars
        Dim Rule As String = ""

        TempS = "State" + vbTab + vbTab + "Condition Type" + vbTab + vbTab + "Condition Value" + vbTab + vbTab + "Action Type" + vbTab + vbTab + "Action Value" + vbCrLf




        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Meta Files|*.met"
        ofd.InitialDirectory = My.Settings.MetaExportDir
        ofd.Title = "Import VT Meta"

        'If ofd.ShowDialog = DialogResult.OK Then
        'Dim loaddt As New DataTable
        table.Clear()

            'Start Reading MetaFile Here
            '---------------------------

            If (ofd.ShowDialog = DialogResult.OK) Then
                Dim reader As IO.StreamReader = New IO.StreamReader(ofd.FileName)
                Try
                    Do
                        'This Loop bypasses Meta File Header
                        Do
                            LineCount = LineCount + 1
                            TempL = reader.ReadLine
                        Loop Until LineCount > 13
                        'Rules Start at Line 14
                        Do
                            RuleCountLine = RuleCountLine + 1

                            'Start Here Creating Sub Functions for Basic Rule, 1 Table Rule, 2 Table Rule, And Nav File

                            Select Case TempL  '*** Reused Code - For Basic Rules (No Tables) - **Make own Function
                                Case 1
                                    vCType = TempL
                                Case 2
                                    vCTypeValue = TempL
                                Case 3
                                    vAType = TempL
                                Case 4
                                    vATypeValue = TempL
                                Case 5
                                    vCData = TempL
                                Case 6
                                    vCDataValue = TempL
                                Case 7
                                    vADataValue = TempL
                                Case 8
                                    vADataValue = TempL
                                Case 9
                                    vState = TempL
                                Case 10
                                    vStateValue = TempL

                                Case Else
                            End Select

                            '' **** -Might be able to reuse this code in a Function, Not sure
                            If vCTypeValue = "0" Then
                                vCTypeConv = "NONE"
                            ElseIf vCTypeValue = "1" Then
                                vCTypeConv = "ALWAYS"
                            ElseIf vCTypeValue = "2" Then
                                vCTypeConv = "MultipleALL"
                            ElseIf vCTypeValue = "3" Then
                                vCTypeConv = "MultipleANY"
                            ElseIf vCTypeValue = "4" Then
                                vCTypeConv = "ChatMessage"
                            Else
                            End If

                            If vATypeValue = "0" Then
                                vATypeConv = "NONE"
                            ElseIf vATypeValue = "1" Then
                                vATypeConv = "SetMetaState"
                            ElseIf vATypeValue = "2" Then
                                vATypeConv = "ChatCommand"
                            ElseIf vATypeValue = "3" Then
                                vATypeConv = "Multiple"
                            ElseIf vATypeValue = "4" Then
                                vATypeConv = "EmbeddedNavRoute"
                            End If
                            '' **** -Might be able to reuse this code in a Function, Not sure


                            'TempAL = TempL + vbCr
                            'TempS = "State" + vbTab + vbTab + "Condition Type" + vbTab + vbTab + "Condition Value" + vbTab + vbTab + "Action Type" + vbTab + vbTab + "Action Value" + vbCrLf
                            'TempS = TempS + TempAL
                        Loop Until RuleCountLine = 10
                        TempS = TempS + vStateValue + vbTab + vbTab + vCTypeConv + vbTab + vbTab + vCDataValue + vbTab + vbTab + vATypeConv + vbTab + vbTab + vADataValue + vbCrLf
                        RuleCountLine = 0
                        TempAL = TempAL + TempS
                    Loop Until reader.Peek = -1
                    'rtboxMetaData.Text = TempS
                    MessageBox.Show("Finished!", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch
                    MessageBox.Show("ERROR!", "ERROR File Empty!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    reader.Close()
                End Try


            Else
                MessageBox.Show("Canceled File Open", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        MessageBox.Show("You entered a blank Meta State Name " + TempAL)

        ''table.ReadXml(ofd.FileName)
        frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & ofd.FileName

            'Creating Table

            Dim items = table.AsEnumerable().Select(Function(d) DirectCast(d(4).ToString(), Object)).ToArray()
            frmMain.cBoxATMetaState.Items.Clear()
            frmMain.cBoxCTMetaState.Items.Clear()
            frmMain.cBoxCTMetaState.Items.AddRange(items)
            frmMain.cBoxATMetaState.Items.AddRange(items)

        'Populating Table from Meta File


        'Else

        'End If
        Return table
    End Function

    Function CTypeBasicImport(Rule As String, CTypeVar As String) As String
        Dim vCType As String = ""            'Line 1 of Record - Condition Type Variable Code (Integer,String,etc… )
        Dim vCTypeValue As String = ""       'Line 2 of Record - Condition Type Variable Value (ex. 4=Chat Message)
        Dim vAType As String = ""            'Line 3 of Record - Action Type Variable Code (Double,Integer,String,etc… )
        Dim vATypeValue As String = ""       'Line 4 of Record - Action Type Variable Value (ex. 1=Set Meta State) 
        Dim vCData As String = ""            'Line 5 of Record - Condition Data Variable Code (Integer,String,etc… )
        Dim vCDataValue As String = ""       'Line 6 of Record - Condition Data Variable Value 
        Dim vAData As String = ""            'Line 7 of Record - Action Data Variable Code (Integer,String,etc… 
        Dim vADataValue As String = ""       'Line 8 of Record - Action Data Variable Value
        Dim vState As String = ""            'Line 9 of Record - State Variable Code (String, Haven’t seen it any other way yet)
        Dim vStateValue As String = ""       'Line 10 of Record - State Variable Value (Name of State)
        Dim TempL As String

        Select Case CTypeVar  '*** Reused Code - For Basic Rules (No Tables) - **Make own Function

            '*** Need to figure this part out
            Case 1
                vCType = TempL
            Case 2
                vCTypeValue = TempL
            Case 3
                vAType = TempL
            Case 4
                vATypeValue = TempL
            Case 5
                vCData = TempL
            Case 6
                vCDataValue = TempL
            Case 7
                vADataValue = TempL
            Case 8
                vADataValue = TempL
            Case 9
                vState = TempL
            Case 10
                vStateValue = TempL

            Case Else
        End Select

        Return Rule
    End Function


    Function CTypeSingleTableImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function

    Function CTypeDoubleTableImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function

    Function ATypeBasicImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function


    Function ATypeSingleTableImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function

    Function ATypeDoubleTableImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function

    Function ATypeTripleTableImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function

    Function ATypeNavRouteImport(Rule As String, CTypeVar As String) As String

        Return Rule
    End Function
End Module
