Module Meta
    Private ActionDataType As String 'Using this to set Vars based on action data types in for Multiple Actions.   

    Sub MetaExport()

        Dim metafile As String

        Dim RecordCount As Integer = frmMain.dgvMetaRules.Rows.Count - 1 ' Record Count I think.  May need to add -1 for it to match 
        'rowcount = frmMain.dgvMetaRules.DisplayedRowCount(False)
        Dim tempmeta As String
        Dim cVarType As String = ""

        TestingStuff.TextBoxTest.Text = Nothing
        'Meta File Header
        tempmeta = "1" & vbNewLine & "CondAct" & vbNewLine & "5" & vbNewLine & "CType" & vbNewLine & "AType" & vbNewLine & "CData" & vbNewLine & "AData" & vbNewLine & "State" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & RecordCount & vbNewLine


        For Each r As DataGridViewRow In frmMain.dgvMetaRules.Rows

            Dim i As String = "i" + vbCrLf
            Dim s As String = "s" + vbCrLf
            Dim tCD As String = "i" 'temp var for setting the Condition Data Var type -Set when Condition Type is figured out.
            Dim tAD As String = "i"
            Dim tState As String = "s"
            Dim CTypeTable As Integer = 0  'This is to flag if Condition Type uses a Record Table. No record table=0, Single=1, Double=3, Multiple Table=3, Triple =4  Used to call correct Functions, Init as 0
            Dim ATypeTable As Integer = 6  'This is a flag if Action Type is a Zero=0, Single=1, Double=2 or Triple=3 Record Data Table. Used in Select Case to use Appropiate Export Function
            Dim sRecordOneAdataType As String = "" ' to determine the AdataType - Example e=Expression, n=Name
            Dim sCDataTableVarOne As String = "" ' For setting the proper Var Type for each subtable Variable
            Dim sADataTableVarOne As String = "" ' For setting the proper Var Type for each subtable Variable
            Dim sADataTableVarTwo As String = ""
            'Dim sADataTableVarThree As String = ""


            Select Case (r.Cells(0).Value) ' Condition Types
                Case Nothing ' To remove blank lines
                    Continue For
                Case "Never"
                    tempmeta = tempmeta + i + "0" + vbCrLf ' Never = 0
                Case "Always"
                    tempmeta = tempmeta + i + "1" + vbCrLf ' Always = 1
                Case "All"
                    CTypeTable = 3
                    cVarType = "2"
                    tempmeta = tempmeta + i + "2" + vbCrLf
                Case "Any"
                    CTypeTable = 3
                    cVarType = "3"
                    tempmeta = tempmeta + i + "3" + vbCrLf
                Case "ChatMessage"
                    tempmeta = tempmeta + i + "4" + vbCrLf
                    tCD = "s" ''  Sets Var as string for CData Exporting
                Case "MainPackSlotsLE"
                    tempmeta = tempmeta + i + "5" + vbCrLf
                Case "SecondsInStateGE"
                    tempmeta = tempmeta + i + "6" + vbCrLf
                Case "NavrouteEmpty"
                    tempmeta = tempmeta + i + "7" + vbCrLf
                Case "Died"
                    tempmeta = tempmeta + i + "8" + vbCrLf
                Case "VendorOpen"
                    tempmeta = tempmeta + i + "9" + vbCrLf
                Case "VendorClosed"
                    tempmeta = tempmeta + i + "10" + vbCrLf
                Case "ItemCountLE"
                    CTypeTable = 2 'Table records = 2
                    tempmeta = tempmeta + i + "11" + vbCrLf
                Case "ItemCountGE"
                    CTypeTable = 2 'Table records = 2
                    tempmeta = tempmeta + i + "12" + vbCrLf
                Case "MonsterCountWithinDistance"
                    CTypeTable = 4
                    tempmeta = tempmeta + i + "13" + vbCrLf
                    tCD = "s" ''  Sets Var as string for CData Exporting
                Case "MonstersWithPriorityWithinDistance"
                    CTypeTable = 4
                    tempmeta = tempmeta + i + "14" + vbCrLf
                    tCD = "s" ''  Sets Var as string for CData Exporting
                Case "NeedToBuff"
                    tempmeta = tempmeta + i + "15" + vbCrLf
                Case "NoMonstersWithinDistance"
                    tempmeta = tempmeta + i + "16" + vbCrLf
                Case "LandBlockE"
                    tempmeta = tempmeta + i + "17" + vbCrLf
                    'tCD = "s" ''  Sets Var as string for CData Exporting
                Case "LandCellE"
                    tempmeta = tempmeta + i + "18" + vbCrLf
                    'tCD = "s" ''  Sets Var as string for CData Exporting
                Case "PortalspaceEnter"
                    tempmeta = tempmeta + i + "19" + vbCrLf
                Case "PortalspaceExit"
                    tempmeta = tempmeta + i + "20" + vbCrLf
                Case "Not"
                    CTypeTable = 3
                    cVarType = "21"
                    tempmeta = tempmeta + i + "21" + vbCrLf
                Case "SecondsInStatePersistGE"
                    tempmeta = tempmeta + i + "22" + vbCrLf
                Case "TimeLeftOnSpellGE"
                    CTypeTable = 2
                    tempmeta = tempmeta + i + "23" + vbCrLf
                Case "BurdenPercentGE"
                    tempmeta = tempmeta + i + "24" + vbCrLf
                Case "DistanceToAnyRoutePointGE"
                    sCDataTableVarOne = "dist"
                    CTypeTable = 1 'Table records = 1
                    tCD = "d"
                    tempmeta = tempmeta + i + "25" + vbCrLf
                Case "Expression"
                    sCDataTableVarOne = "e"
                    CTypeTable = 1 'Table records = 1
                    tempmeta = tempmeta + i + "26" + vbCrLf
                    tCD = "s" ''  Sets Var as string for CData Exporting
                Case "ClientDialogPopup"
                    tempmeta = tempmeta + i + "27" + vbCrLf
                Case "ChatMessageCapture"
                    CTypeTable = 2 'Table records = 2
                    tempmeta = tempmeta + i + "28" + vbCrLf
                    tCD = "s" ''  Sets Var as string for CData Exporting
                Case Else
                    MessageBox.Show("Out of Range - Meta Export Condition Type")
            End Select

            Select Case (r.Cells(1).Value)  ' Action Types
                Case "None"
                    tempmeta = tempmeta + i + "0" + vbCrLf
                Case "SetState"
                    tempmeta = tempmeta + i + "1" + vbCrLf
                    tAD = "s"
                Case "ChatCommand"
                    tempmeta = tempmeta + i + "2" + vbCrLf
                    tAD = "s"
                Case "Multiple"
                    ATypeTable = 5
                    tempmeta = tempmeta + i + "3" + vbCrLf
                Case "EmbeddedNavRoute"
                    ATypeTable = 4
                    tempmeta = tempmeta + i + "4" + vbCrLf
                    tAD = "s"
                Case "CallState"
                    ATypeTable = 8
                    tempmeta = tempmeta + i + "5" + vbCrLf
                    tAD = "s"
                    sADataTableVarOne = "st"
                    sADataTableVarTwo = "ret"
                Case "ReturnFromCall"
                    tempmeta = tempmeta + i + "6" + vbCrLf
                    tAD = "s"
                Case "ExpressionAct"
                    ATypeTable = 1
                    tempmeta = tempmeta + i + "7" + vbCrLf
                    tAD = "s"
                    sRecordOneAdataType = "e"
                Case "ChatWithExpression"
                    ATypeTable = 1
                    tempmeta = tempmeta + i + "8" + vbCrLf
                    tAD = "s"
                    sRecordOneAdataType = "e"
                Case "WatchdogSet"
                    ATypeTable = 3
                    tempmeta = tempmeta + i + "9" + vbCrLf
                Case "WatchdogClear"
                    ATypeTable = 0
                    tempmeta = tempmeta + i + "10" + vbCrLf
                Case "GetVTOption"
                    ATypeTable = 2
                    tempmeta = tempmeta + i + "11" + vbCrLf
                    tAD = "s"
                Case "SetVTOption"
                    ATypeTable = 2
                    tempmeta = tempmeta + i + "12" + vbCrLf
                    tAD = "s"
                Case "CreateView"
                    ATypeTable = 7
                    tempmeta = tempmeta + i + "13" + vbCrLf
                    'tAD = "s"
                Case "DestroyView"
                    ATypeTable = 1
                    tempmeta = tempmeta + i + "14" + vbCrLf
                    sRecordOneAdataType = "n"
                Case "DestroyAllViews"
                    ATypeTable = 0
                    tempmeta = tempmeta + i + "15" + vbCrLf
                Case Else
                    MessageBox.Show("Out of Range - Meta Export Action Type")

            End Select


            Select Case CTypeTable 'To find the correct Export function for Exporting the Condition Type
                Case 0 ' No Table
                    If r.Cells(0).Value.ToString = "LandBlockE" Then 'Or "LandCellE" Then 
                        tempmeta = tempmeta & tCD & vbCrLf & Convert.ToInt32(r.Cells(2).Value, 16) & vbCrLf
                    ElseIf r.Cells(0).Value.ToString = "LandCellE" Then
                        tempmeta = tempmeta & tCD & vbCrLf & Convert.ToInt32(r.Cells(2).Value, 16) & vbCrLf
                    Else
                        tempmeta = tempmeta & tCD & vbCrLf & r.Cells(2).Value & vbCrLf
                    End If

                Case 1 ' Single Record Table
                    tempmeta = tempmeta & SingleExport(r.Cells(2).Value & vbCrLf, sCDataTableVarOne)
                Case 2 ' Double Record Table
                    tempmeta = tempmeta & CTypeDoubleExport(r.Cells(2).Value.ToString, r.Cells(0).Value.ToString) & vbCrLf
                Case 3 'Any/All/Not Sub Table
                    If r.Cells(2).Value = "" Then ' Find out if Any/All/Not Table is blank/zero records
                        tempmeta = tempmeta & "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "0" & vbCrLf
                        'tempmeta = tempmeta & "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "0" & vbCrLf & "i" & vbCrLf & "0" & vbCrLf
                    Else
                        tempmeta = tempmeta & CTAnyAllNot(r.Cells(2).Value.ToString, r.Cells(0).Value.ToString)
                    End If

                Case 4 'Triple Record Table
                    tempmeta = tempmeta & CTypeTripleExport(r.Cells(2).Value.ToString, r.Cells(0).Value.ToString) & vbCrLf
                Case Else
                    MsgBox("Out Of Range - Meta.MetaExport- Case CTypeTable")
            End Select

            '-------------------------This Should be able to be removed-----------------------
            'If CTypeTable = True Then
            '    tempmeta = tempmeta & CTypeDoubleExport(r.Cells(2).Value.ToString, r.Cells(0).Value.ToString) & vbCrLf
            'Else
            '    tempmeta = tempmeta & tCD & vbCrLf & r.Cells(2).Value & vbCrLf      'ConditionData
            'End If
            '---------------------------------------------------------------------------------

            Select Case ATypeTable 'To Find correct Meta Export Function for ActionData
                Case 0
                    tempmeta = tempmeta & ATypeZeroExport(r.Cells(3).Value & vbCrLf)      'Uses Table but zero records (Watchdog Clear)
                Case 1
                    tempmeta = tempmeta & SingleExport(r.Cells(3).Value & vbCrLf, sRecordOneAdataType)  'Table 1 record
                Case 2
                    tempmeta = tempmeta & ATypeDoubleExport(r.Cells(3).Value & vbCrLf)  'Table 2 records (Gets/Set VT Options
                Case 3
                    tempmeta = tempmeta & ATypeTripleExport(r.Cells(3).Value & vbCrLf)  'Table 3 records (WatchDog Set)
                Case 4  'Nav Routes 
                    tempmeta = tempmeta & NavRoute(r.Cells(3).Value, "a")
                Case 5 'Multiple
                    tempmeta = tempmeta & ATMultiple(r.Cells(3).Value.ToString, r.Cells(1).Value.ToString) '& vbCrLf
                    'tempmeta = tempmeta & ATMultiple(r.Cells(3).Value.ToString, r.Cells(1).Value.ToString) '& vbCrLf
                Case 6 'Normal Stuff
                    tempmeta = tempmeta & tAD & vbCrLf & r.Cells(3).Value & vbCrLf
                Case 7
                    tempmeta = tempmeta & ATypeCreateViewExport(r.Cells(3).Value & vbCrLf)  'Table 3 records (WatchDog Set)
                Case 8
                    tempmeta = tempmeta & ATypeDoubleExportVTwo(r.Cells(3).Value, sADataTableVarOne, sADataTableVarTwo)
                    'tempmeta = tempmeta & ATypeDoubleExportV2(r.Cells(3).Value, sADataTableVarOne, sADataTableVarTwo, & vbCrLf)
                Case Else
                    MsgBox("Out Of Range - Meta.MetaExport- Case ATypeTable")
            End Select


            tempmeta = tempmeta & tState & vbCrLf & r.Cells(4).Value & vbCrLf   'State



        Next
        metafile = tempmeta
        Dim FileNum As Integer = FreeFile()
        Dim FileWR As System.IO.StreamWriter
        'FileWR = My.Computer.FileSystem.OpenTextFileWriter("c:\test\streamwrite.met", True)

        If CommandArgument = True Then

            FileWR = My.Computer.FileSystem.OpenTextFileWriter(MetaFileNameExport, False)
            FileWR.Write(metafile)
            FileWR.Close()

        Else
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "Meta Files|*.met"
            sfd.InitialDirectory = My.Settings.MetaExportDir
            sfd.FileName = GlobalVars.FileName


            If (sfd.ShowDialog = DialogResult.OK) Then
                'FileOpen(FileNum, SaveFileDialogMeta.FileName, OpenMode.Output)
                FileWR = My.Computer.FileSystem.OpenTextFileWriter(sfd.FileName, False)
                FileWR.Write(metafile)
                FileWR.Close()
                MessageBox.Show("Meta Export Complete")
                'Write(FileNum, metafile)
                'FileClose(FileNum)
            End If
        End If

        '**** Used for testing******
        If My.Settings.MetaDebug = True Then
            TestingStuff.TextBoxTest.Text = tempmeta
            TestingStuff.Show()
        Else
        End If


    End Sub

    Function CTypeDoubleExport(Rule As String, CTypeVar As String) As String

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "2"
        Dim ExportData As String
        Dim StringSplit() As String

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")

        Select Case CTypeVar
            Case "ItemCountLE", "ItemCountGE"
                ExportData = ExportData & vbCrLf & "n" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "c" & vbCrLf & "i" & vbCrLf & StringSplit(1).ToString ' next part, n = name for of Item to count, and s = var type of name (string)

            Case "TimeLeftOnSpellGE"
                ExportData = ExportData & vbCrLf & "sid" & vbCrLf & "i" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "sec" & vbCrLf & "i" & vbCrLf & StringSplit(1).ToString

            Case "ChatMessageCapture"
                ExportData = ExportData & vbCrLf & "p" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "c" & vbCrLf & "s" & vbCrLf & StringSplit(1).ToString ' next part, p = pattern of text of chat capture, and s = var type of name (string)

            Case Else
                MsgBox("Out of range - Meta.CTypeDoubleExport - Case CTypeVar")
        End Select

        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)

    End Function
    Function CTypeTripleExport(Rule As String, CTypeVar As String) As String
        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "3"
        Dim ExportData As String
        Dim StringSplit() As String

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")

        Select Case CTypeVar
            Case "MonsterCountWithinDistance"
                ExportData = ExportData & vbCrLf & "n" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf &
                    "s" & vbCrLf & "c" & vbCrLf & "i" & vbCrLf & StringSplit(1).ToString & vbCrLf &
                    "s" & vbCrLf & "r" & vbCrLf & "d" & vbCrLf & StringSplit(2).ToString ' 
            Case "MonstersWithPriorityWithinDistance"
                ExportData = ExportData & vbCrLf & "p" & vbCrLf & "i" & vbCrLf & StringSplit(0).ToString & vbCrLf &
                    "s" & vbCrLf & "c" & vbCrLf & "i" & vbCrLf & StringSplit(1).ToString & vbCrLf &
                    "s" & vbCrLf & "r" & vbCrLf & "d" & vbCrLf & StringSplit(2).ToString ' 
            Case Else
                MsgBox("Out of range - Meta.CTypeTripleExport - Case CTypeVar")
        End Select

        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)
    End Function
    Function ATypeZeroExport(Rule As String) As String

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "0" & vbCrLf
        'Dim ExportData As String = "s"  'starting off with Variable as string 

        'ExportData = ExportData & vbCrLf & "e" & vbCrLf & "s" & vbCrLf & Rule  ' next part, e = expression, and s = var type of name (string)

        Rule = TableHeader
        Return (Rule)


    End Function

    Function SingleExport(Rule As String, RecordOneADataType As String) As String 'RecordOneAdataType - e=Expression, n=name

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "1"
        Dim ExportData As String = "s"  'starting off with Variable as string 
        Dim cDataVarTypeRecOne As String = "s"

        Select Case RecordOneADataType
            Case "dist"
                cDataVarTypeRecOne = "d"
        End Select

        ExportData = ExportData & vbCrLf & RecordOneADataType & vbCrLf & cDataVarTypeRecOne & vbCrLf & Rule  ' next part, e = expression, and s = var type of name (string)

        Rule = TableHeader & vbCrLf & ExportData
        Return (Rule)


    End Function

    Function ATypeDoubleExport(Rule As String) As String ' RecordOneAdataType - 

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "2"
        Dim ExportData As String
        Dim StringSplit() As String
        Dim ADataVarOne As String = "o"  'Defaults for Get Set VT Options
        Dim ADataVarTwo As String = "v"  'Defaults for Get Set VT Options


        If ActionDataType = "CallState" Then
            ADataVarOne = "st"
            ADataVarTwo = "ret"
        End If

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")
        ExportData = ExportData & vbCrLf & ADataVarOne & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & ADataVarTwo & vbCrLf & "s" & vbCrLf & StringSplit(1).ToString ' next part, o = option, and s = var type of name (string)
        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)

    End Function

    Function ATypeDoubleExportVTwo(Rule As String, ADataTableVarOne As String, ADataTableVarTwo As String) As String
        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "2"
        Dim ExportData As String
        Dim StringSplit() As String

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")
        ExportData = ExportData & vbCrLf & ADataTableVarOne & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & ADataTableVarTwo & vbCrLf & "s" & vbCrLf & StringSplit(1).ToString & vbCrLf ' next part, o = option, and s = var type of name (string)
        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)
    End Function

    Function ATypeTripleExport(Rule As String) As String ' For AT WatchDog Set Only
        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "3"
        Dim ExportData As String
        Dim StringSplit() As String

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")
        ExportData = ExportData & vbCrLf & "s" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "r" & vbCrLf & "d" & vbCrLf & StringSplit(1).ToString & vbCrLf & "s" & vbCrLf & "t" & vbCrLf & "d" & vbCrLf & StringSplit(2).ToString ' next part, o = option, and s = var type of name (string)
        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)

    End Function

    Function ATypeCreateViewExport(Rule As String) As String

        Dim CharCountAdjustment As Integer = 11
        Dim TestCharCountString As String = ""
        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "2"
        Dim ExportData As String
        Dim StringSplit() As String


        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")
        TestCharCountString = StringSplit(1).ToString
        ExportData = ExportData & vbCrLf & "n" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "x" & vbCrLf & "ba" & vbCrLf & (Len(TestCharCountString)) & vbCrLf & StringSplit(1).ToString ' next part, o = option, and s = var type of name (string)
        Rule = TableHeader & vbCrLf & ExportData

        Return (Rule)

    End Function

    Function NavRoute(filename As String, Result As String) As String

        Dim ofd As New OpenFileDialog()
        Dim navString As String = ""
        Dim TempL
        Dim FileNum As Integer = FreeFile()
        Dim LineCount As Integer = 0
        Dim Header As String
        Dim RecordCount As String = ""
        Dim CharCountNumRecords As Integer = 0 ' For figuring out how many chars to add for count of nav points
        Dim NavRouteName As String = "[None]"
        Dim CharCountAdjustment As Integer = 11
        Dim TestCharCountString As String = ""

        ofd.Filter = "Nav Files|*.nav"
        'ofd.InitialDirectory = My.Settings.XMLOpenSave

        If filename = "" Then
            RecordCount = "0"
            NavRouteName = ""
            CharCountAdjustment = 4
        Else
            Try
                FileOpen(FileNum, filename, OpenMode.Input)

                Do Until EOF(FileNum)

                    TempL = LineInput(FileNum)
                    navString = navString & TempL & vbCrLf
                    LineCount = LineCount + 1
                    If LineCount = 3 Then
                        RecordCount = TempL

                    End If

                Loop
                FileClose(FileNum)
                NavRouteName = System.IO.Path.GetFileName(filename)
            Catch e As Exception
                RecordCount = "0"
                NavRouteName = ""
                CharCountAdjustment = 4
                MsgBox("Nav File Not Found - " & filename & ". Skipped")

            End Try
        End If



        'Select Case RecordCount
        '    Case 0 To 9
        '        CharCountNumRecords = 1
        '    Case 10 To 99
        '        CharCountNumRecords = 2
        '    Case 100 To 999
        '        CharCountNumRecords = 3
        '    Case 1000 To 9999
        '        CharCountNumRecords = 4
        '    Case 10000 To 99999
        '        CharCountNumRecords = 5
        '    Case 100000 To 999999
        '        CharCountNumRecords = 6
        '    Case 1000000 To 9999999
        '        CharCountNumRecords = 7
        '    Case Else
        '        MsgBox("Out of Range - You have more than 10 Million Nav Points in your Nav File")
        'End Select

        TestCharCountString = navString & vbCrLf & NavRouteName & vbCrLf & RecordCount
        'MsgBox("Char Count = " & Len(TestCharCountString))

        Header = "ba" & vbCrLf & (Len(TestCharCountString)) & vbCrLf & NavRouteName & vbCrLf & RecordCount
        'Header = "ba" & vbCrLf & (Len(navString) + CharCountAdjustment + CharCountNumRecords) & vbCrLf & NavRouteName & vbCrLf & RecordCount
        Result = Header & vbCrLf & navString
        'MsgBox("Number of chars in Nav File = " & Len(navString) & "  Number of Lines= " & LineCount & "  Total = " & Len(navString) + 11) '11 = 6 chars for [None], 3 line returns for Name, # of records, and 
        'TestingStuff.TextBoxTest.Text = navString
        'TestingStuff.Show()

        Result = Header & vbCrLf & navString

        Return (Result)
        'Dim FileNum As Integer = FreeFile()

        'If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then
        '    FileOpen(FileNum, SaveFileDialog1.FileName, OpenMode.Output)
        '    FileSystem.Write(FileNum, rtboxMetaData.Text)
        '    FileClose(FileNum)
        'End If


    End Function

    Function CTAnyAllNot(ByVal ConditionData As String, ConditionType As String) As String

        Dim AnyAllNotEncode As String = ""
        ' Dim cData As String = ConditionData ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
        Dim AnyAllNotRecordCount As Integer = 0 ' to count how many records of Each Subtable - Needed in header

        'Header
        Dim AnyAllNotHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim ConditionEncode As String = ""
        Dim FinalConditionEncode As String = ""
        Dim tString1 As String = ""
        Dim tString2 As String = ""
        'Dim regX As String = RegXAnyAllNot
        'Dim regX As String = "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]"
        Dim myExportConditionNest As New RegX(ConditionData, RegXAnyAllNot, False)

        Dim mytable As New DataTable
        mytable = myExportConditionNest.MultiTable
        Dim rc As Integer = 1 'for record counts

        Dim conditionNestVarType As String

        Select Case ConditionType
            Case "All"
                conditionNestVarType = "2"
            Case "Any"
                conditionNestVarType = "3"
            Case "Not"
                conditionNestVarType = "21"
            Case Else
                conditionNestVarType = "Invalid Condition Type"
        End Select
        'AnyAllNotEncode = "i" & vbCrLf & conditionNestVarType
        'Dim NestedHeader As String = "i" & vbCrLf & conditionNestVarType & vbCrLf & AnyAllNotHeader

        For Each row As DataRow In mytable.Rows
            tString1 = row.Item(0).ToString.Replace(": ", "")
            tString2 = row.Item(1).ToString

            If tString1.ToString.Contains("Any") Or tString1.ToString.Contains("All") Or tString1.ToString.Contains("Not") Then

                Dim varType As String
                If tString1.ToString.Contains("All") Then
                    varType = "2"
                ElseIf tString1.ToString.Contains("Any") Then
                    varType = "3"
                ElseIf tString1.ToString.Contains("Not") Then
                    varType = "21"
                End If
                rc = rc + 1
                'Dim myExportActionNestMultiple As New RegX(tString1.ToString, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)
                Dim myMetaNest As New NestedConditionMetaExport(tString2, RegXAnyAllNot)

                'tdata = tdata & vbCrLf & Header & vbCrLf & rc & myMetaNest.OutString
                'Dim x As Integer = c + 1
                'tdata = tdata & "i" & vbCrLf & varType & vbCrLf & Header & vbCrLf & x & vbCrLf & "i" & vbCrLf & varType & vbCrLf & myMetaNest.OutString
                'AnyAllNotEncode = "i" & vbCrLf & varType & vbCrLf & AnyAllNotHeader & vbCrLf & rc & vbCrLf & myMetaNest.OutString
                AnyAllNotEncode = "i" & vbCrLf & varType & vbCrLf & AnyAllNotHeader & vbCrLf & myMetaNest.OutString
                'AnyAllNotEncode = AnyAllNotEncode & vbCrLf & myMetaNest.OutString
            Else
                'make table

                'Dim myTempTable As New RegX(tString2.ToString, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}", False)
                'Dim myNestedTable = myTempTable.MultiTable
                'For Each r As DataRow In myNestedTable.Rows

                'If c = 0 Then
                '        tempData = tempData & ConditionTypeEncode(r.Item(0).ToString.Replace(": ", ""), r.Item(1).ToString)
                '    Else
                '        tempData = tempData & ConditionTypeEncode(r.Item(0).ToString, r.Item(1).ToString)
                '    End If

                'Next
                If AnyAllNotRecordCount = 0 Then
                    ConditionEncode = ConditionEncode & ConditionTypeEncode(tString1.ToString.Replace(": ", ""), tString2.ToString)
                Else
                    'ConditionEncode = ConditionEncode & ConditionTypeEncode(tString1.ToString, tString2.ToString).TrimEnd(vbCrLf.ToCharArray)
                    ConditionEncode = ConditionEncode & ConditionTypeEncode(tString1.ToString, tString2.ToString)
                End If

            End If
            AnyAllNotRecordCount = AnyAllNotRecordCount + 1
        Next

        If AnyAllNotEncode = "" Then
            FinalConditionEncode = AnyAllNotHeader & vbCrLf & rc & vbCrLf & ConditionEncode
        Else
            FinalConditionEncode = AnyAllNotHeader & vbCrLf & rc & vbCrLf & ConditionEncode & AnyAllNotEncode & vbCrLf
        End If

        'FinalConditionEncode = AnyAllNotHeader & vbCrLf & rc & vbCrLf & ConditionEncode & AnyAllNotEncode & vbCrLf ' & AnyAllNotRecordCount  '& tdata
        'FinalConditionEncode = AnyAllNotRecordCount & vbCrLf & NestedHeader & vbCrLf & rc & vbCrLf & ConditionEncode & vbCrLf & AnyAllNotEncode & vbCrLf ' & AnyAllNotRecordCount  '& tdata

        Return FinalConditionEncode


    End Function
    Function ConditionTypeEncode(ByVal CTypeString As String, ByVal CTypeData As String) As String
        Dim tempmeta As String = ""
        Dim i As String = "i" + vbCrLf
        Dim s As String = "s" + vbCrLf
        Dim tCD As String = "i" 'temp var for setting the Condition Data Var type -Set when Condition Type is figured out.
        Dim CTypeTable As Integer = 0  'This is to flag if Condition Type uses a Record Table. No record table=0, Single=1, Double=3 or Multiple Table=3.  Used to call correct Functions, Init as 0
        Dim sCDataTableVarOne As String = "" ' For setting the proper Var Type for each subtable Variable
        'Dim sADataTableVarThree As String = ""

        'Dim ATypeTable As Integer = 6  'This is a flag if Action Type is a Zero=0, Single=1, Double=2 or Triple=3 Record Data Table. Used in Select Case to use Appropiate Export Function
        'Dim cdType As MetaConditionTypeID
        'Dim cdType As Condition
        'Dim never As String

        Select Case (CTypeString) ' Condition Types
            Case Nothing ' To remove blank lines

            Case "Never"
                tempmeta = tempmeta + i + "0" + vbCrLf ' Never = 0
            Case "Always"
                tempmeta = tempmeta + i + "1" + vbCrLf ' Always = 1
            Case "All"
                tempmeta = tempmeta + i + "2" + vbCrLf
            Case "Any"
                tempmeta = tempmeta + i + "3" + vbCrLf
            Case "ChatMessage"
                tempmeta = tempmeta + i + "4" + vbCrLf
                tCD = "s" ''  Sets Var as string for CData Exporting
            Case "MainPackSlotsLE"
                tempmeta = tempmeta + i + "5" + vbCrLf
            Case "SecondsInStateGE"
                tempmeta = tempmeta + i + "6" + vbCrLf
            Case "NavrouteEmpty"
                tempmeta = tempmeta + i + "7" + vbCrLf
            Case "Died"
                tempmeta = tempmeta + i + "8" + vbCrLf
            Case "VendorOpen"
                tempmeta = tempmeta + i + "9" + vbCrLf
            Case "VendorClosed"
                tempmeta = tempmeta + i + "10" + vbCrLf
            Case "ItemCountLE"
                CTypeTable = 2 'Table records = 2
                tempmeta = tempmeta + i + "11" + vbCrLf
            Case "ItemCountGE"
                CTypeTable = 2 'Table records = 2
                tempmeta = tempmeta + i + "12" + vbCrLf
            Case "MonsterCountWithinDistance"
                CTypeTable = 4
                tempmeta = tempmeta + i + "13" + vbCrLf
            Case "MonstersWithPriorityWithinDistance"
                CTypeTable = 4
                tempmeta = tempmeta + i + "14" + vbCrLf
            Case "NeedToBuff"
                tempmeta = tempmeta + i + "15" + vbCrLf
            Case "NoMonstersWithinDistance"
                tempmeta = tempmeta + i + "16" + vbCrLf
            Case "LandBlockE"
                tempmeta = tempmeta + i + "17" + vbCrLf
                'tCD = "s" ''  Sets Var as string for CData Exporting
            Case "LandCellE"
                tempmeta = tempmeta + i + "18" + vbCrLf
                'tCD = "s" ''  Sets Var as string for CData Exporting
            Case "PortalspaceEnter"
                tempmeta = tempmeta + i + "19" + vbCrLf
            Case "PortalspaceExit"
                tempmeta = tempmeta + i + "20" + vbCrLf
            Case "Not"
                tempmeta = tempmeta + i + "21" + vbCrLf
            Case "SecondsInStatePersistGE"
                tempmeta = tempmeta + i + "22" + vbCrLf
            Case "TimeLeftOnSpellGE"
                CTypeTable = 2 'Table records = 2
                tempmeta = tempmeta + i + "23" + vbCrLf
            Case "BurdenPercentGE"
                tempmeta = tempmeta + i + "24" + vbCrLf
            Case "DistanceToAnyRoutePointGE"
                CTypeTable = 1 'Table records = 1
                sCDataTableVarOne = "dist"
                tempmeta = tempmeta + i + "25" + vbCrLf
            Case "Expression"
                sCDataTableVarOne = "e"
                CTypeTable = 1 'Table records = 1
                tempmeta = tempmeta + i + "26" + vbCrLf
                tCD = "s" ''  Sets Var as string for CData Exporting
            Case "ClientDialogPopup"
                tempmeta = tempmeta + i + "27" + vbCrLf
            Case "ChatMessageCapture"
                CTypeTable = 2 'Table records = 2
                tempmeta = tempmeta + i + "28" + vbCrLf
                tCD = "s" ''  Sets Var as string for CData Exporting
            Case Else
                MessageBox.Show("Out of Range - Meta Export Condition Type")
        End Select



        Select Case CTypeTable 'To find the correct Export function for Exporting the Condition Type
            Case 0 ' No Table

                If CTypeString = "LandBlockE" Then 'Or "LandCellE" Then 
                    tempmeta = tempmeta & tCD & vbCrLf & Convert.ToInt32(CTypeData, 16) & vbCrLf
                ElseIf CTypeString = "LandCellE" Then
                    tempmeta = tempmeta & tCD & vbCrLf & Convert.ToInt32(CTypeData, 16) & vbCrLf
                Else
                    tempmeta = tempmeta & tCD & vbCrLf & CTypeData & vbCrLf
                End If

            Case 1 ' Single Record Table
                tempmeta = tempmeta & SingleExport(CTypeData & vbCrLf, sCDataTableVarOne)
            Case 2 ' Double Record Table
                tempmeta = tempmeta & CTypeDoubleExport(CTypeData, CTypeString) & vbCrLf
            Case 3 'Any/All/Not Sub Table
               ' tempmeta = tempmeta & vbCrLf & Header
            Case 4 'Triple Record
                tempmeta = tempmeta & CTypeTripleExport(CTypeData, CTypeString) & vbCrLf
            Case Else
                MsgBox("Out Of Range - Meta.MetaExport- Case CTypeTable")
        End Select

        CTypeString = tempmeta
        Return CTypeString
    End Function


    Function ATMultiple(ByVal ActionData As String, ActionType As String) As String

        'Dim tempstring() As String ' String to pass on to create records
        'Dim StringSplit() As String
        'Dim myExportActionNest As New RegX(aData, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)
        'Dim myMetaNest As New MetaNest(tString1, RegX)

        Dim tdata = ""
        Dim aData As String = ActionData ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
        Dim c As Integer = 0 ' to count how many records of Each Subtable - Needed in header

        'Header
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim tempData As String = ""
        Dim tString1 As String = ""
        Dim tString2 As String = ""
        'Dim regX As String = "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]"
        Dim regX As String = RegXMultiple 'RegXNestedMultiple
        Dim myExportActionNest As New RegX(aData, RegXMultiple, False)

        Dim mytable As New DataTable
        mytable = myExportActionNest.MultiTable
        Dim rc As Integer = 1 'for record counts


        For Each row As DataRow In mytable.Rows
            tString1 = row.Item(0).ToString.Replace(": ", "")
            tString2 = row.Item(1).ToString

            If tString1.ToString.Contains("Multiple") Then

                'Dim myExportActionNestMultiple As New RegX(tString1.ToString, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)
                Dim myMetaNest As New NestedActionMetaExport(tString2, regX)

                'tdata = tdata & vbCrLf & Header & vbCrLf & rc & myMetaNest.OutString
                tdata = tdata & "i" & vbCrLf & "3" & vbCrLf & Header & vbCrLf & myMetaNest.OutString
                Dim x As Integer = 4

            Else
                'make table
                '------- Not sure if this needs to stay commented out
                'Dim myTempTable As New RegX(tString2.ToString, regX, False)
                'Dim myNestedTable = myTempTable.MultiTable
                'For Each r As DataRow In myNestedTable.Rows

                'If c = 0 Then
                '        tempData = tempData & ActionTypeEncode(r.Item(0).ToString.Replace(": ", ""), r.Item(1).ToString)
                '    Else
                '        tempData = tempData & ActionTypeEncode(r.Item(0).ToString, r.Item(1).ToString)
                '    End If

                ' Next

                '----- Fix single Multiple ??? 1 nest deep
                If c = 0 Then
                    tempData = tempData & ActionTypeEncode(tString1.ToString.Replace(": ", ""), tString2.ToString)
                Else
                    tempData = tempData & ActionTypeEncode(tString1.ToString, tString2.ToString)
                End If

            End If
            c = c + 1
        Next

        ''-------- Fix for random 2 in exports??
        'If c > 1 Then
        '    tempData = Header & vbCrLf & tempData & tdata
        'Else
        tempData = Header & vbCrLf & c & vbCrLf & tempData & tdata
        'End If



        Return tempData

    End Function

    Function ActionTypeEncode(ByVal ATypeString As String, ByVal ATypeData As String) As String

        Dim i As String = "i" + vbCrLf
        Dim s As String = "s" + vbCrLf
        Dim tAD As String = "i"
        Dim tempmeta As String = ""
        Dim ATypeTable As Integer = 6  'This is a flag if Action Type is a Zero=0, Single=1, Double=2 or Triple=3 Record Data Table. Used in Select Case to use Appropiate Export Function
        Dim sADataVaribleType As String = ""
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"

        Select Case (ATypeString)  ' Action Types
            Case "None"
                tempmeta = tempmeta + i + "0" + vbCrLf
            Case "SetState"
                tempmeta = tempmeta + i + "1" + vbCrLf
                tAD = "s"
            Case "ChatCommand"
                tempmeta = tempmeta + i + "2" + vbCrLf
                tAD = "s"
            Case "Multiple"
                ATypeTable = 5
                tempmeta = tempmeta + i + "3" '+ vbCrLf
            Case "EmbeddedNavRoute"
                ATypeTable = 4
                tempmeta = tempmeta + i + "4" + vbCrLf
                tAD = "s"
            Case "CallState"

                ActionDataType = "CallState"
                ATypeTable = 2
                tempmeta = tempmeta + i + "5" + vbCrLf
                tAD = "s"
            Case "ReturnFromCall"
                tempmeta = tempmeta + i + "6" + vbCrLf
                tAD = "s"
            Case "ExpressionAct"
                ATypeTable = 1
                tempmeta = tempmeta + i + "7" + vbCrLf
                tAD = "s"
                sADataVaribleType = "e"
            Case "ChatWithExpression"
                ATypeTable = 1
                tempmeta = tempmeta + i + "8" + vbCrLf
                tAD = "s"
                sADataVaribleType = "e"
            Case "WatchdogSet"
                ATypeTable = 3
                tempmeta = tempmeta + i + "9" + vbCrLf
            Case "WatchdogClear"
                ATypeTable = 0
                tempmeta = tempmeta + i + "10" + vbCrLf
            Case "GetVTOption"
                ATypeTable = 2
                tempmeta = tempmeta + i + "11" + vbCrLf
                tAD = "s"
            Case "SetVTOption"
                ATypeTable = 2
                tempmeta = tempmeta + i + "12" + vbCrLf
                tAD = "s"
            Case "CreateView"
                ATypeTable = 7
                tempmeta = tempmeta + i + "13" + vbCrLf
                tAD = "s"
            Case "DestroyView"
                ATypeTable = 1
                tempmeta = tempmeta + i + "14" + vbCrLf
                tAD = "s"
                sADataVaribleType = "n"
            Case "DestroyAllViews"
                ATypeTable = 0
                tempmeta = tempmeta + i + "15" + vbCrLf
            Case Else
                MessageBox.Show("Out of Range - Function = Meta.ActionTypeEncode")

        End Select




        Select Case ATypeTable 'To Find correct Meta Export Function for ActionData
            Case 0
                tempmeta = tempmeta & ATypeZeroExport(ATypeData & vbCrLf)      'Uses Table but zero records (Watchdog Clear)
            Case 1
                tempmeta = tempmeta & SingleExport(ATypeData & vbCrLf, sADataVaribleType)  'Table 1 record
            Case 2
                tempmeta = tempmeta & ATypeDoubleExport(ATypeData & vbCrLf)  'Table 2 records (Gets/Set VT Options, Call State)
            Case 3
                tempmeta = tempmeta & ATypeTripleExport(ATypeData & vbCrLf)  'Table 3 records (WatchDog Set)
            Case 4  'Nav Routes
                tempmeta = tempmeta & NavRoute(ATypeData, "a")
            Case 5 'Multiple
                tempmeta = tempmeta & vbCrLf & Header

            Case 6 'Normal Stuff
                tempmeta = tempmeta & tAD & vbCrLf & ATypeData & vbCrLf
            Case 7
                tempmeta = tempmeta & ATypeCreateViewExport(ATypeData & vbCrLf)  'Table 3 records (WatchDog Set)
            Case Else
                MsgBox("Out Of Range - Meta.MetaExport- Case ATypeTable")
        End Select

        ATypeString = tempmeta
        ActionDataType = ""
        Return tempmeta

    End Function
End Module
