Public Class NestedConditionMetaExport


    Public Property InputString As String
    Public Property RegxMatch As String
    Public Property OutString As String


    Public Sub New(ByVal inString As String, ByVal regx As String)
        InputString = inString
        RegxMatch = regx

        OutString = GetMultiple(InputString, RegxMatch)

    End Sub

    Function GetMultiple(ByVal input As String, ByVal regx As String) As String

        Dim tData As String = ""
        Dim FinalEncode As String = ""
        Dim tPeekData As String = ""


        'Dim aData As String
        Dim tString1 As String
        Dim tString2 As String
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim varType As String = "" ' 2 = all, 3 = any, 21 = not
        'Dim aanTdata As String

        'Dim myExportActionNest As New RegX(input, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)

        Dim myExportConditionNest As New RegX(input, regx, False)
        Dim mytable As New DataTable
        mytable = myExportConditionNest.MultiTable

        Dim rc As Integer = 0 'for record counts
        Dim c As Integer = 0


        For Each row As DataRow In mytable.Rows
            tString1 = row.Item(0).ToString.Replace(": ", "")
            tString2 = row.Item(1).ToString

            If tString1.ToString.Contains("All") Then
                varType = "2"
            ElseIf tString1.ToString.Contains("Any") Then
                varType = "3"
            ElseIf tString1.ToString.Contains("Not") Then
                varType = "21"
            End If



            If tString1.ToString.Contains("Any") Or tString1.ToString.Contains("All") Or tString1.ToString.Contains("Not") Then
                Dim myMetaNest As New NestedConditionMetaExport(tString2, regx)
                'tData = tData & vbCrLf & myMetaNest.OutString
                tPeekData = myMetaNest.OutString
                'tData = tData & rc & vbCrLf & "i" & vbCrLf & varType & vbCrLf & Header & vbCrLf & myMetaNest.OutString
                tData = tData & vbCrLf & "i" & vbCrLf & varType & vbCrLf & Header & vbCrLf & myMetaNest.OutString
            Else
                If c = 0 Then
                    'Dim tConditionEncode = ConditionTypeEncode(tString1, tString2)
                    tData = tData & vbCrLf & ConditionTypeEncode(tString1, tString2).TrimEnd(vbCrLf.ToCharArray)
                    'tData = "i" & vbCrLf & varType & vbCrLf & tData & ConditionTypeEncode(tString1, tString2)
                    Dim x As Integer = 0
                Else
                    'tData = tData & rc & vbCrLf & ConditionTypeEncode(tString1, tString2)
                    tData = tData & vbCrLf & ConditionTypeEncode(tString1, tString2).TrimEnd(vbCrLf.ToCharArray)
                End If
                c = c + 1

            End If
            rc = rc + 1
        Next

        FinalEncode = rc & tData
        'FinalEncode = Header & vbCrLf & rc & tData
        'FinalEncode = Header & vbCrLf & rc & vbCrLf & tData
        'FinalEncode = Header & vbCrLf & rc & vbCrLf & tData
        'tData = tData

        Return FinalEncode

    End Function

End Class
