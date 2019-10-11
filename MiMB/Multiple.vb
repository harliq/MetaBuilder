Public Class aMultiple
    Private _myString As String


    Public Property myString As String
        Get
            Return _myString
        End Get
        Set(ByVal myString As String)
            _myString = myString
        End Set
    End Property


    Function decodeMultiple(ByVal myMulti As String)



        Dim cnt As Integer = 0
        Dim ch As String = "{"
        For Each c As Char In myMulti
            If c = ch Then
                cnt += 1
            End If
        Next
        Select Case cnt
            Case 1

            Case 2

            Case Else

        End Select


        Return myMulti

    End Function
End Class
