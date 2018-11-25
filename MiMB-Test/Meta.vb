Module Meta

    Sub MetaExport()

        Dim metafile As String

        Dim RecordCount As Integer = frmMain.dgvMetaRules.Rows.Count - 1 ' Record Count I think.  May need to add -1 for it to match 
        'rowcount = frmMain.dgvMetaRules.DisplayedRowCount(False)
        Dim tempmeta As String


        TestingStuff.TextBoxTest.Text = Nothing
        'Meta File Header
        'TestingStuff.TextBoxTest.Text = "1" & vbNewLine & "CondAct" & vbNewLine & "5" & vbNewLine & "CType" & vbNewLine & "AType" & vbNewLine & "CData" & vbNewLine & "AData" & vbNewLine & "State" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & rowcount & vbNewLine
        tempmeta = "1" & vbNewLine & "CondAct" & vbNewLine & "5" & vbNewLine & "CType" & vbNewLine & "AType" & vbNewLine & "CData" & vbNewLine & "AData" & vbNewLine & "State" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & "n" & vbNewLine & RecordCount & vbNewLine


        For Each r As DataGridViewRow In frmMain.dgvMetaRules.Rows

            Dim i As String = "i" + vbCrLf
            Dim s As String = "s" + vbCrLf
            Dim tCD As String = "i" 'temp var for setting the Condition Data Var type -Set when Condition Type is figured out.
            Dim tAD As String = "i"
            Dim tState As String = "s"
            Dim CTypeTable As Integer = 0  'This is to flag if Condition Type uses a Record Table. No record table=0, Single=1, Double=3, Multiple Table=3, Triple =4  Used to call correct Functions, Init as 0
            Dim ATypeTable As Integer = 6  'This is a flag if Action Type is a Zero=0, Single=1, Double=2 or Triple=3 Record Data Table. Used in Select Case to use Appropiate Export Function
            'Dim cdType As MetaConditionTypeID
            'Dim cdType As Condition
            'Dim never As String

            Select Case (r.Cells(0).Value) ' Condition Types
                Case Nothing ' To remove blank lines
                    Continue For
                Case "Never"
                    tempmeta = tempmeta + i + "0" + vbCrLf ' Never = 0
                Case "Always"
                    tempmeta = tempmeta + i + "1" + vbCrLf ' Always = 1
                Case "All"
                    CTypeTable = 3
                    tempmeta = tempmeta + i + "2" + vbCrLf
                Case "Any"
                    CTypeTable = 3
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
                    tempmeta = tempmeta + i + "21" + vbCrLf
                Case "SecondsInStatePersistGE"
                    tempmeta = tempmeta + i + "22" + vbCrLf
                Case "TimeLeftOnSpellGE"
                    tempmeta = tempmeta + i + "23" + vbCrLf
                Case "BurdenPercentGE"
                    tempmeta = tempmeta + i + "24" + vbCrLf
                Case "DistanceToAnyRoutePointGE"
                    tempmeta = tempmeta + i + "25" + vbCrLf
                Case "Expression"
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
                    tempmeta = tempmeta + i + "5" + vbCrLf
                    tAD = "s"
                Case "ReturnFromCall"
                    tempmeta = tempmeta + i + "6" + vbCrLf
                    tAD = "s"
                Case "ExpressionAct"
                    ATypeTable = 1
                    tempmeta = tempmeta + i + "7" + vbCrLf
                    tAD = "s"
                Case "ChatWithExpression"
                    ATypeTable = 1
                    tempmeta = tempmeta + i + "8" + vbCrLf
                    tAD = "s"
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
                    tempmeta = tempmeta & SingleExport(r.Cells(2).Value & vbCrLf)
                Case 2 ' Double Record Table
                    tempmeta = tempmeta & CTypeDoubleExport(r.Cells(2).Value.ToString, r.Cells(0).Value.ToString) & vbCrLf
                Case 3 'Any/All/Not Sub Table
                    If r.Cells(2).Value = "" Then ' Find out if Any/All/Not Table is blank/zero records
                        tempmeta = tempmeta & "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "0" & vbCrLf & "i" & vbCrLf & "0" & vbCrLf
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
                    tempmeta = tempmeta & SingleExport(r.Cells(3).Value & vbCrLf)  'Table 1 record
                Case 2
                    tempmeta = tempmeta & ATypeDoubleExport(r.Cells(3).Value & vbCrLf)  'Table 2 records (Gets/Set VT Options
                Case 3
                    tempmeta = tempmeta & ATypeTripleExport(r.Cells(3).Value & vbCrLf)  'Table 3 records (WatchDog Set)
                Case 4  'Nav Routes
                    tempmeta = tempmeta & NavRoute(r.Cells(3).Value, "a")
                Case 5 'Multiple
                    tempmeta = tempmeta & ATMultiple(r.Cells(3).Value.ToString, r.Cells(1).Value.ToString) '& vbCrLf
                Case 6 'Normal Stuff
                    tempmeta = tempmeta & tAD & vbCrLf & r.Cells(3).Value & vbCrLf
                Case Else
                    MsgBox("Out Of Range - Meta.MetaExport- Case ATypeTable")
            End Select


            tempmeta = tempmeta & tState & vbCrLf & r.Cells(4).Value & vbCrLf   'State



        Next
        metafile = tempmeta
        Dim FileNum As Integer = FreeFile()
        Dim FileWR As System.IO.StreamWriter
        'FileWR = My.Computer.FileSystem.OpenTextFileWriter("c:\test\streamwrite.met", True)
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Meta Files|*.met"
        sfd.InitialDirectory = My.Settings.MetaExportDir



        If (sfd.ShowDialog = DialogResult.OK) Then
            'FileOpen(FileNum, SaveFileDialogMeta.FileName, OpenMode.Output)
            FileWR = My.Computer.FileSystem.OpenTextFileWriter(sfd.FileName, False)
            FileWR.Write(metafile)
            FileWR.Close()
            MessageBox.Show("Meta Export Complete")
            'Write(FileNum, metafile)
            'FileClose(FileNum)
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

    Function SingleExport(Rule As String) As String

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "1"
        Dim ExportData As String = "s"  'starting off with Variable as string 

        ExportData = ExportData & vbCrLf & "e" & vbCrLf & "s" & vbCrLf & Rule  ' next part, e = expression, and s = var type of name (string)

        Rule = TableHeader & vbCrLf & ExportData
        Return (Rule)


    End Function

    Function ATypeDoubleExport(Rule As String) As String

        Dim TableHeader As String = "TABLE" & vbCrLf & "2" & vbCrLf & "k" & vbCrLf & "v" & vbCrLf & "n" & vbCrLf & "n" & vbCrLf & "2"
        Dim ExportData As String
        Dim StringSplit() As String

        ExportData = "s" ' This is always a string

        StringSplit = Split(Rule, ";")
        ExportData = ExportData & vbCrLf & "o" & vbCrLf & "s" & vbCrLf & StringSplit(0).ToString & vbCrLf & "s" & vbCrLf & "v" & vbCrLf & "s" & vbCrLf & StringSplit(1).ToString ' next part, o = option, and s = var type of name (string)
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

        Dim cData As String = ConditionData ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
        Dim StringSplit() As String
        Dim c As Integer = 0 ' to count how many records of Each Subtable - Needed in header
        Dim tempstring() As String ' String to pass on to create records
        'Header
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim TempCData As String = ""
        Dim tString1 As String = ""
        Dim tString2 As String = ""

        'need a count of "{" to figure out number of records

        StringSplit = Split(cData, "}")
        For Each s As String In StringSplit

            tempstring = Split(s, "{")
            If tempstring(0) = "" Then
                Exit For
            Else
                tString1 = tempstring(0)
                tString2 = tempstring(1)
                If c = 0 Then
                    TempCData = TempCData & vbCrLf & ConditionTypeEncode(tString1, tString2)
                Else
                    TempCData = TempCData & ConditionTypeEncode(tString1, tString2)
                End If
                'TempCData = TempCData & ConditionTypeEncode(tString1, tString2)

            End If
            c = c + 1
        Next

        ' for Double Values

        'tString1 = tempstring(0)
        'tString2 = tempstring(1)
        'ConditionTypeEncode(tString1, tString2)
        'Header = Header & vbCrLf & c & vbCrLf & tString1


        ConditionData = Header & vbCrLf & c & TempCData

        Return (ConditionData)

    End Function
    Function ConditionTypeEncode(ByVal CTypeString As String, ByVal CTypeData As String) As String
        Dim tempmeta As String = ""
        Dim i As String = "i" + vbCrLf
        Dim s As String = "s" + vbCrLf
        Dim tCD As String = "i" 'temp var for setting the Condition Data Var type -Set when Condition Type is figured out.
        Dim CTypeTable As Integer = 0  'This is to flag if Condition Type uses a Record Table. No record table=0, Single=1, Double=3 or Multiple Table=3.  Used to call correct Functions, Init as 0
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
                tempmeta = tempmeta + i + "23" + vbCrLf
            Case "BurdenPercentGE"
                tempmeta = tempmeta + i + "24" + vbCrLf
            Case "DistanceToAnyRoutePointGE"
                tempmeta = tempmeta + i + "25" + vbCrLf
            Case "Expression"
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
                tempmeta = tempmeta & SingleExport(CTypeData & vbCrLf)
            Case 2 ' Double Record Table
                tempmeta = tempmeta & CTypeDoubleExport(CTypeData, CTypeString) & vbCrLf
            Case 3 'Any/All/Not Sub Table

            Case 4 'Triple Record
                tempmeta = tempmeta & CTypeTripleExport(CTypeData, CTypeString) & vbCrLf
            Case Else
                MsgBox("Out Of Range - Meta.MetaExport- Case CTypeTable")
        End Select

        CTypeString = tempmeta
        Return CTypeString
    End Function


    Function ATMultiple(ByVal ActionData As String, ActionType As String) As String


        Dim aData As String = ActionData ' Complitcated way of spliting strings from XML for each subtable Probably easier way of doing this.
        Dim StringSplit() As String
        Dim c As Integer = 0 ' to count how many records of Each Subtable - Needed in header
        Dim tempstring() As String ' String to pass on to create records
        'Header
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim TempCData As String = ""
        Dim tString1 As String = ""
        Dim tString2 As String = ""

        'need a count of "{" to figure out number of records

        StringSplit = Split(aData, "}")
        For Each s As String In StringSplit

            tempstring = Split(s, "{")
            If tempstring(0) = "" Then
                Exit For
            Else
                tString1 = tempstring(0)
                tString2 = tempstring(1)
                If c = 0 Then
                    TempCData = TempCData & vbCrLf & ActionTypeEncode(tString1, tString2)
                Else
                    TempCData = TempCData & ActionTypeEncode(tString1, tString2)
                End If
                'TempCData = TempCData & ConditionTypeEncode(tString1, tString2)

            End If
            c = c + 1
        Next

        ' for Double Values

        'tString1 = tempstring(0)
        'tString2 = tempstring(1)
        'ConditionTypeEncode(tString1, tString2)
        'Header = Header & vbCrLf & c & vbCrLf & tString1


        ActionData = Header & vbCrLf & c & TempCData


        Return (ActionData)

    End Function

    Function ActionTypeEncode(ByVal ATypeString As String, ByVal ATypeData As String) As String

        Dim i As String = "i" + vbCrLf
        Dim s As String = "s" + vbCrLf
        Dim tAD As String = "i"
        Dim tempmeta As String = ""
        Dim ATypeTable As Integer = 6  'This is a flag if Action Type is a Zero=0, Single=1, Double=2 or Triple=3 Record Data Table. Used in Select Case to use Appropiate Export Function

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
                tempmeta = tempmeta + i + "3" + vbCrLf
            Case "EmbeddedNavRoute"
                ATypeTable = 4
                tempmeta = tempmeta + i + "4" + vbCrLf
                tAD = "s"
            Case "CallState"
                tempmeta = tempmeta + i + "5" + vbCrLf
                tAD = "s"
            Case "ReturnFromCall"
                tempmeta = tempmeta + i + "6" + vbCrLf
                tAD = "s"
            Case "ExpressionAct"
                ATypeTable = 1
                tempmeta = tempmeta + i + "7" + vbCrLf
                tAD = "s"
            Case "ChatWithExpression"
                ATypeTable = 1
                tempmeta = tempmeta + i + "8" + vbCrLf
                tAD = "s"
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
            Case Else
                MessageBox.Show("Out of Range - Meta Export Action Type")

        End Select




        Select Case ATypeTable 'To Find correct Meta Export Function for ActionData
            Case 0
                tempmeta = tempmeta & ATypeZeroExport(ATypeData & vbCrLf)      'Uses Table but zero records (Watchdog Clear)
            Case 1
                tempmeta = tempmeta & SingleExport(ATypeData & vbCrLf)  'Table 1 record
            Case 2
                tempmeta = tempmeta & ATypeDoubleExport(ATypeData & vbCrLf)  'Table 2 records (Gets/Set VT Options
            Case 3
                tempmeta = tempmeta & ATypeTripleExport(ATypeData & vbCrLf)  'Table 3 records (WatchDog Set)
            Case 4  'Nav Routes
                tempmeta = tempmeta & NavRoute(ATypeData, "a")
            Case 5 'Multiple

            Case 6 'Normal Stuff
                tempmeta = tempmeta & tAD & vbCrLf & ATypeData & vbCrLf
            Case Else
                MsgBox("Out Of Range - Meta.MetaExport- Case ATypeTable")
        End Select

        ATypeString = tempmeta

        Return ATypeString
    End Function
End Module
