Module Parse
    'Module is for parsing data.  Combining and seperating strings

    'Public Vars for passing data for Any/All DataTable
    Public AnyAllString As String
    Public MultipleString As String


    Function CombineTwoVal(ByVal String1 As String, ByVal String2 As String, ByVal Result As String) As String
        Result = String1 + ";" + String2
        Return (Result)
    End Function
    Function SplitTwoVal(ByVal TwoValues As Array) As Array

        'Cant get this to work, and easy to do in code

        Dim String1 As String = TwoValues(0)
        'Dim cData As String = selectedRow.Cells(2).Value
        'Dim StringSplit() As String
        TwoValues = Split(String1, ";")
        'txtBoxCData.Text = StringSplit(0)
        'txtBoxCData2.Text = StringSplit(1)
        'Result1 = ""
        'result2 = ""
        Return (TwoValues)
    End Function

    Function CombineThreeVal(ByVal String1 As String, ByVal String2 As String, ByVal Result As String) As String
        Result = String1 + ";" + String2 + ";" + Result
        Return (Result)
    End Function

    Sub CombineAnyAll()
        Dim tempdata As String = ""

        For Each r As DataGridViewRow In frmMain.dgvAnyAll.Rows

            If (r.Cells(0).Value IsNot Nothing) Then
                tempdata = tempdata & (r.Cells(0).Value.ToString) & "{" & (r.Cells(1).Value.ToString) & "}"
            Else
                'MsgBox("Value is Nothing - Parse.CombineAnyAll")
            End If

        Next
        AnyAllString = tempdata
    End Sub
    Sub CombineMultiple()
        Dim tempdata As String = ""

        For Each r As DataGridViewRow In frmMain.dgvATMultiple.Rows

            If (r.Cells(0).Value IsNot Nothing) Then
                tempdata = tempdata & (r.Cells(0).Value.ToString) & "{" & (r.Cells(1).Value.ToString) & "}"
            Else
                'MsgBox("Value is Nothing - Parse.CombineAnyAll")
            End If

        Next
        MultipleString = tempdata
    End Sub
End Module
