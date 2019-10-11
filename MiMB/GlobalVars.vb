Module GlobalVars

    Public SetFormType As Integer = 0  'Default is 0 = None, 1 = Condition , 2 = Action  ** Used for setting up form since reusing
    Public SetFormIndex As Integer = 0
    Public FileName As String = ""
    Public FileNameAndPath As String = ""
    Public RuleChange As Boolean = False
    Public XMLFileNameLoad As String = "" 'For CommandLine Arugments
    Public MetaFileNameExport As String = "" 'For CommandLine Arugments
    Public CommandArgument As Boolean = False 'Default is False - For a check when doing XML -> Meta conversions via Command Line
    Public ReadOnly RegXAnyAllNot As String = "(Any){(.*?}})|(Any: ){(.*?}})|(Any: ){(.*?})[A-Z]|" &
                                              "(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|" &
                                              "(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?})[A-Z]|" &
                                              "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                              "(ChatMessageCapture){(.*?)}|(ChatMessageCapture: ){(.*?)}|" &
                                              "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}"


    Public ReadOnly RegXMultiple As String = "(Multiple: ){(.*?})[A-Z]|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?})[A-Z]|(Multiple: ){(.*?}})|" &
                                             "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                             "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
                                             "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
                                             "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}"


    Public ReadOnly RegXNestedMultiple As String = "(Multiple: ){(.*?}})|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?}})|" &
                                                   "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                                   "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
                                                   "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
                                                   "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}"

    'Public ReadOnly RegXMultiple As String = "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?}})|(Multiple: ){(.*?})[A-Z]"

    'Public NestedTableForm As Boolean = False




    Sub rulechanged()
        'If RuleChange = False Then
        '    frmMain.dgvMetaRules.DefaultCellStyle.SelectionBackColor = Color.Blue
        'Else
        '    frmMain.dgvMetaRules.DefaultCellStyle.SelectionBackColor = Color.Red
        'End If


    End Sub
End Module
