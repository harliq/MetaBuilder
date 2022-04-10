Module GlobalVars

    Public SetFormType As Integer = 0  'Default is 0 = None, 1 = Condition , 2 = Action  ** Used for setting up form since reusing
    Public SetFormIndex As Integer = 0
    Public FileName As String = ""
    Public FileNameAndPath As String = ""
    Public RuleChange As Boolean = False
    Public XMLFileNameLoad As String = "" 'For CommandLine Arugments
    Public MetaFileNameExport As String = "" 'For CommandLine Arugments
    Public CommandArgument As Boolean = False 'Default is False - For a check when doing XML -> Meta conversions via Command Line
    'Public ReadOnly RegXAnyAllNot As String = "(Any){(.*?}})|(Any: ){(.*?}})|(Any: ){(.*?})[A-Z]|" &
    '                                          "(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|" &
    '                                          "(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?})[A-Z]|" &
    '                                          "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
    '                                          "(ChatMessageCapture){(.*?)}|(ChatMessageCapture: ){(.*?)}|" &
    '                                          "(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}"

    'Public ReadOnly RegXNestOnly As String = "(Any){(.*?}}})|(All){(.*?}}})|(Not){(.*?}}})|(\w+){(.*?)}|(Any){(.*?}})|(All){(.*?}})|(Not){(.*?)}}|(Any){(.*?})|(All){(.*?)}}|(Not){(.*?})}"

    Public ReadOnly RegXNestOnly As String = "(Any)⸨(.*?}⸩)|(Any: )⸨(.*?}⸩)|(All)⸨(.*?}⸩)|(All: )⸨(.*?}⸩)|(Not)⸨(.*?}⸩)|(Not: )⸨(.*?}⸩)|" &
                                                "(Any){(.*?}})|(Any: ){(.*?}})|(Any: ){(.*?})[A-Z]|" &
                                                "(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|" &
                                                "(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?})[A-Z]"



    Public ReadOnly RegXSingleOnly As String = "(Never){(.*?)}|(Never: ){(.*?)}|" &
                                                "(Always){(.*?)}|(Always: ){(.*?)}|" &
                                                "(ChatMessage){(.*?)}|(ChatMessage: ){(.*?)}|" &
                                                "(MainPackSlotsLE){(.*?)}|(MainPackSlotsLE: ){(.*?)}|" &
                                                "(SecondsInStateGE){(.*?)}|(SecondsInStateGE: ){(.*?)}|" &
                                                "(NavrouteEmpty){(.*?)}|(NavrouteEmpty: ){(.*?)}|" &
                                                "(Died){(.*?)}|(Died: ){(.*?)}|" &
                                                "(VendorOpen){(.*?)}|(VendorOpen: ){(.*?)}|" &
                                                "(VendorClosed){(.*?)}|(VendorClosed: ){(.*?)}|" &
                                                "(ItemCountLE){(.*?)}|(ItemCountLE: ){(.*?)}|" &
                                                "(ItemCountGE){(.*?)}|(ItemCountGE: ){(.*?)}|" &
                                                "(MonsterCountWithinDistance){(.*?)}|(MonsterCountWithinDistance: ){(.*?)}|" &
                                                "(MonstersWithPriorityWithinDistance){(.*?)}|(MonstersWithPriorityWithinDistance: ){(.*?)}|" &
                                                "(NeedToBuff){(.*?)}|(NeedToBuff: ){(.*?)}|" &
                                                "(NoMonstersWithinDistance){(.*?)}|(NoMonstersWithinDistance: ){(.*?)}|" &
                                                "(LandBlockE){(.*?)}|(LandBlockE: ){(.*?)}|" &
                                                "(LandCellE){(.*?)}|(LandCellE: ){(.*?)}|" &
                                                "(PortalspaceEnter){(.*?)}|(PortalspaceEnter: ){(.*?)}|" &
                                                "(PortalspaceExit){(.*?)}|(PortalspaceExit: ){(.*?)}|" &
                                                "(SecondsInStatePersistGE){(.*?)}|(SecondsInStatePersistGE: ){(.*?)}|" &
                                                "(TimeLeftOnSpellGE){(.*?)}|(TimeLeftOnSpellGE: ){(.*?)}|" &
                                                "(BurdenPercentGE){(.*?)}|(BurdenPercentGE: ){(.*?)}|" &
                                                "(DistanceToAnyRoutePointGE){(.*?)}|(DistanceToAnyRoutePointGE: ){(.*?)}|" &
                                                "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                                "(ClientDialogPopup){(.*?)}|(ClientDialogPopup: ){(.*?)}|" &
                                                "(ChatMessageCapture){(.*?)}|(ChatMessageCapture: ){(.*?)}"


    Public ReadOnly RegXAnyAllNot As String = "(Any){(.*?}})|(Any: ){(.*?}})|(Any: ){(.*?})[A-Z]|" &
                                              "(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|" &
                                              "(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?})[A-Z]|" &
                                              "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                              "(ChatMessageCapture){(.*?)}|(ChatMessageCapture: ){(.*?)}|" &
                                              "(\w+){(.*?)}|" &
                                              "(\w+: ){(.*?)}|" &
                                              "(\w+: ){(.*?;\.*?)}|" &
                                              "(\w+){(.*?;.*?)}|" &
                                              "(\w+: ){(.*?;.*?;\.*?)}|" &
                                              "(\w+){(.*?;.*?;\.*?)}"

    Public ReadOnly RegXAnyAllNotSplitDataGridView As String = "(Any){(.*?}})|(Any: ){(.*?}})|(Any: ){(.*?})[A-Z]|" &
                                              "(All){(.*?}})|(All: ){(.*?}})|(All: ){(.*?})[A-Z]|" &
                                              "(Not){(.*?}})|(Not: ){(.*?}})|(Not: ){(.*?})[A-Z]|" &
                                              "(\w+){(.*?)}|" &
                                              "(\w+: ){(.*?)}|" &
                                              "(\w+: ){(.*?;\.*?)}|" &
                                              "(\w+){(.*?;.*?)}|" &
                                              "(\w+: ){(.*?;.*?;\.*?)}|" &
                                              "(\w+){(.*?;.*?;\.*?)}"


    '"(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}"

    'Public ReadOnly RegXMultiple As String = "(Multiple: ){(.*?})[A-Z]|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?})[A-Z]|(Multiple: ){(.*?}})|" &
    '                                         "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
    '                                         "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
    '                                         "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
    '                                         "(ChatCommand){(.*?)}|(ChatCommand: ){(.*?)}|" &
    '                                         "(EmbeddedNavRoute){([^}]*)}|(EmbeddedNavRoute: ){([^}]*)}|" &
    '                                         "(\w+){(.*?)}|" &
    '                                         "(\w+: ){(.*?)}|" &
    '                                         "(\w+: ){(.*?;\.*?)}|" &
    '                                         "(\w+){(.*?;.*?)}|" &
    '                                         "(\w+: ){(.*?;.*?;.*?)}|" &
    '                                         "(\w+){(.*?;.*?;.*?)}|" &
    '                                         "(\w+){(.*?;.*?;.*?)}"

    Public ReadOnly RegXActionMultiple As String = "(Multiple: ){(.*?})[A-Z]|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?})[A-Z]|(Multiple: ){(.*?}})|"

    Public ReadOnly RegXActionSingle As String = "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
                                             "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
                                             "(ChatCommand){(.*?)}|(ChatCommand: ){(.*?)}|" &
                                             "(EmbeddedNavRoute){([^}]*)}|(EmbeddedNavRoute: ){([^}]*)}|" &
                                             "(\w+){(.*?)}|" &
                                             "(\w+: ){(.*?)}|" &
                                             "(\w+: ){(.*?;\.*?)}|" &
                                             "(\w+){(.*?;.*?)}|" &
                                             "(\w+: ){(.*?;.*?;.*?)}|" &
                                             "(\w+){(.*?;.*?;.*?)}|" &
                                             "(\w+){(.*?;.*?;.*?)}"
    Public ReadOnly RegXMultiple As String = "(Multiple: ){(.*?})[A-Z]|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?})[A-Z]|(Multiple: ){(.*?}})|" &
                                             "(Expression){(.*?)}|(Expression: ){(.*?)}|" &
                                             "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
                                             "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
                                             "(ChatCommand){(.*?)}|(ChatCommand: ){(.*?)}|" &
                                             "(EmbeddedNavRoute){([^}]*)}|(EmbeddedNavRoute: ){([^}]*)}|" &
                                             "(\w+){(.*?)}|" &
                                             "(\w+: ){(.*?)}|" &
                                             "(\w+: ){(.*?;\.*?)}|" &
                                             "(\w+){(.*?;.*?)}|" &
                                             "(\w+: ){(.*?;.*?;.*?)}|" &
                                             "(\w+){(.*?;.*?;.*?)}|" &
                                             "(\w+){(.*?;.*?;.*?)}"
    '"(\w+){(\w+)}|(\w+: ){(\w+)}|(\w+: ){(\w+;\w+)}|(\w+: ){(\w+;\w+;\w+)}|" &
    '"(\w+){(.*?;.*?)}|(\w+){(\w+;.*?;.*?)}"


    Public ReadOnly RegXNestedMultiple As String = "(Multiple: ){(.*?}})|(Multiple){(.*?}})|(Multiple){(.*?})[A-Z]|(Multiple: ){(.*?}})|" &
                                                   "(ChatWithExpression){(.*?)}|(ChatWithExpression: ){(.*?)}|" &
                                                   "(ExpressionAct){(.*?)}|(ExpressionAct: ){(.*?)}|" &
                                                   "(ChatCommand){(.*?)}|(ChatCommand: ){(.*?)}|" &
                                                   "(\w+){(.*?)}|" &
                                                   "(\w+: ){(.*?)}|" &
                                                   "(\w+: ){(.*?;\.*?)}|" &
                                                   "(\w+){(.*?;.*?)}|" &
                                                   "(\w+: ){(.*?;.*?;.*?)}|" &
                                                   "(\w+){(.*?;.*?;.*?)}|"
    '"(Expression){(.*?)}|(Expression: ){(.*?)}|" &


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
