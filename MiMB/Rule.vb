Public Class Rule

    Public Property CondType As String
    Public Property ActType As String
    Public Property CondData As String
    Public Property ActData As String
    Public Property State As String

End Class
Public Enum MetaConditionTypeID
    Never = 0
    Always = 1
    All = 2
    Any = 3
    ChatMessage = 4
    MainPackSlotsLE = 5
    SecondsInStateGE = 6
    NavrouteEmpty = 7
    Died = 8
    VendorOpen = 9
    VendorClosed = 10
    ItemCountLE = 11
    ItemCountGE = 12
    MonsterCountWithinDistance = 13
    MonstersWithPriorityWithinDistance = 14
    NeedToBuff = 15
    NoMonstersWithinDistance = 16
    LandBlockE = 17
    LandCellE = 18
    PortalspaceEnter = 19
    PortalspaceExit = 20
    [Not] = 21
    SecondsInStatePersistGE = 22
    TimeLeftOnSpellGE = 23
    BurdenPercentGE = 24
    DistanceToAnyRoutePointGE = 25
    Expression = 26
    ClientDialogPopup = 27
    ChatMessageCapture = 28
End Enum

Public Enum MetaActionTypeID
    None = 0
    SetState = 1
    ChatCommand = 2
    Multiple = 3
    EmbeddedNavRoute = 4
    CallState = 5
    ReturnFromCall = 6
    ExpressionAct = 7
    ChatWithExpression = 8
    WatchdogSet = 9
    WatchdogClear = 10
    GetVTOption = 11
    SetVTOption = 12
    CreateView = 13
    DestroyView = 14
    DestroyAllViews = 15
End Enum