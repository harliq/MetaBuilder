Public Class AnyAll

    Private CondType As String
    Private CondData As String

    ' Initialize the object.
    Public Sub New(ByVal new_CType As String, ByVal new_CData As String)
        CondType = new_CType
        CondData = new_CData
    End Sub

    ' Return the object's name.
    Public Overrides Function ToString() As String
        Return CondType
    End Function

    ' Return the object's Category.
    Public Function Category() As String
        Return CondData
    End Function

End Class
