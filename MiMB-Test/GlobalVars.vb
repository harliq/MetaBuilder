Module GlobalVars

    Public SetFormType As Integer = 0  'Default is 0 = None, 1 = Condition , 2 = Action  ** Used for setting up form since reusing
    Public SetFormIndex As Integer = 0
    Public FileName As String = ""
    Public FileNameAndPath As String = ""
    'Public TableSecondaryMultiple As New DataTable("TableSecondaryMultiple")
    'Public TableNestedMultiple As New DataTable("TableNestedMultiple")
    Public NestedTableForm As Boolean = False
End Module
