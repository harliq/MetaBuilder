Module GlobalVars

    Public SetFormType As Integer = 0  'Default is 0 = None, 1 = Condition , 2 = Action  ** Used for setting up form since reusing
    Public SetFormIndex As Integer = 0
    Public FileName As String = ""
    Public FileNameAndPath As String = ""
    Public RuleChange As Boolean = False

    Sub rulechanged()
        If RuleChange = False Then
            frmMain.dgvMetaRules.DefaultCellStyle.SelectionBackColor = Color.Blue
        Else
            frmMain.dgvMetaRules.DefaultCellStyle.SelectionBackColor = Color.Red
        End If


    End Sub
End Module
