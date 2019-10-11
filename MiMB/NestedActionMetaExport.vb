Public Class NestedActionMetaExport

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
        'Dim aData As String
        Dim tString1 As String
        Dim tString2 As String
        Dim Header As String = "TABLE" & vbCrLf & "2" & vbCrLf & "K" & vbCrLf & "V" & vbCrLf & "n" & vbCrLf & "n"
        Dim varType As String = "3" ' 3 = Multiple (this will need to be changed


        'Dim myExportActionNest As New RegX(input, "(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]", False)

        Dim myExportActionNest As New RegX(input, regx, False)
        Dim mytable As New DataTable
        mytable = myExportActionNest.MultiTable

        Dim rc As Integer = 1 'for record counts
        Dim c As Integer = 0


        For Each row As DataRow In mytable.Rows
            tString1 = row.Item(0).ToString.Replace(": ", "")
            tString2 = row.Item(1).ToString

            If tString1.ToString.Contains("Multiple") Then
                Dim myMetaNest As New NestedActionMetaExport(tString2, regx)
                tData = tData & myMetaNest.OutString
            Else
                If c = 0 Then
                    Dim tActionEncode = ActionTypeEncode(tString1, tString2)
                    tData = tData & rc & vbCrLf & ActionTypeEncode(tString1, tString2)
                    Dim x As Integer = 0
                Else
                    tData = tData & rc & ActionTypeEncode(tString1, tString2)

                End If

            End If
            rc = rc + 1
        Next

        Return tData

    End Function

End Class
