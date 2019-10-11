Module SetForm
    ' This module is to set form design depending on the selected Conditon or Action Type
    'Called from Click/change events to DGV or rule selection, Conditiong or Action ComboBox Changes/Selected Indexes
    Public SaveWork As Boolean = False

    Sub ResetAll()
        ResetAction()
        ResetCondition()
    End Sub

    'Condition Types
    Sub ResetCondition()
        frmMain.lblCData.Visible = True
        frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData2.Enabled = True
        frmMain.txtBoxCData.Visible = False
        frmMain.txtBoxCData2.Visible = False
        frmMain.txtBoxCData3.Visible = False
        frmMain.lblCData2.Visible = False
        frmMain.lblCData3.Visible = False
        'frmMain.ListBoxCTDataAnyAll.Visible = False
        frmMain.btnAddAnyAll.Visible = False
        'frmMain.cBoxCTAnyAll.Visible = False
        frmMain.btnDeleteAnyAll.Visible = False
        frmMain.btnEditAnyAll.Visible = False
        frmMain.dgvAnyAll.Visible = False
        frmMain.ProgressBar1.Visible = False
        frmMain.lblProgressBar.Visible = False
        'Making everyting blank
        frmMain.txtBoxCData.Text = ""
        frmMain.txtBoxCData2.Text = ""
        frmMain.lblCData.Text = ""
        frmMain.lblCData2.Text = ""
        frmMain.cBoxCTMetaState.Text = "Default"


    End Sub
    Sub CTSingle()
        frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTDouble()
        frmMain.txtBoxCData.Visible = True
        frmMain.txtBoxCData2.Visible = True
        frmMain.lblCData2.Visible = True
    End Sub
    Sub CTTriple()
        frmMain.txtBoxCData.Visible = True
        frmMain.txtBoxCData2.Visible = True
        frmMain.txtBoxCData3.Visible = True
        frmMain.lblCData2.Visible = True
        frmMain.lblCData3.Visible = True
    End Sub
    Sub CTAnyAll()

        frmMain.dgvAnyAll.Visible = True
        frmMain.btnAddAnyAll.Visible = True
        frmMain.btnDeleteAnyAll.Visible = True
        frmMain.btnEditAnyAll.Visible = True

    End Sub
    Sub BlankRow()
        frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = False
        frmMain.txtBoxCData2.Visible = False
        frmMain.txtBoxAData.Visible = False

    End Sub
    Sub CTNever()
        frmMain.lblCData.Text = "Never"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTAlways()
        frmMain.lblCData.Text = "Always"
        ' frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTAll()
        frmMain.lblCData.Text = "All"
        'frmMain.txtBoxCData.Enabled = True
        'frmMain.txtBoxCData.Visible = False
        'frmMain.ListBoxCTDataAnyAll.Visible = True
        frmMain.btnAddAnyAll.Visible = True
        'frmMain.cBoxCTAnyAll.Visible = True
        frmMain.btnEditAnyAll.Visible = True
        frmMain.btnDeleteAnyAll.Visible = True


        'add Listbox for All Conditons
    End Sub
    Sub CTAny()
        frmMain.lblCData.Text = "Any"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False
        'frmMain.ListBoxCTDataAnyAll.Visible = True
        frmMain.btnAddAnyAll.Visible = True
        frmMain.btnEditAnyAll.Visible = True
        frmMain.btnDeleteAnyAll.Visible = True
        'add Listbox for Any Conditons

    End Sub
    Sub CTChatMessage()
        frmMain.lblCData.Text = "Chat Message"
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTMainPackSlotsLE()
        frmMain.lblCData.Text = "Pack Slots <="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTSecondsinStateGE()
        frmMain.lblCData.Text = "Seconds in State >="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTNavRouteEmpty()
        frmMain.lblCData.Text = "Nav Route Empty"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False
    End Sub
    Sub CTDied()
        frmMain.lblCData.Text = "On Death"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False
    End Sub
    Sub CTVendorOpen()
        frmMain.lblCData.Text = "Vendor Open"
        'frmMain.txtBoxCData.Enabled = True
        'frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTVendorClosed()
        frmMain.lblCData.Text = "Vendor Closed"
        'frmMain.txtBoxCData.Enabled = True
        'frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTItemCountLE()
        frmMain.lblCData.Text = "Item Name"
        frmMain.lblCData2.Text = "Item Count"
        frmMain.lblCData2.Visible = True
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
        frmMain.txtBoxCData2.Visible = True
        '**DONE**Add More labels, and Another Text Entry Box (2 Values)
    End Sub
    Sub CTItemCountGE()
        frmMain.lblCData.Text = "Item Name"
        frmMain.lblCData2.Text = "Item Count"
        frmMain.lblCData2.Visible = True
        ' frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
        frmMain.txtBoxCData2.Visible = True
        '**DONE** Add More labels, and Another Text Entry Box (2 Values)
    End Sub
    Sub CTMonsterCountWithinDistance()
        frmMain.lblCData.Text = "Monster Count Within Distance"
        frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTMonsterWithPriorityWithinDistance()
        frmMain.lblCData.Text = "Monster Priority Within Distance"
        frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTNeedToBuff()
        frmMain.lblCData.Text = "Need to Buff"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTNoMonsterWithinDistance()
        frmMain.lblCData.Text = "No Monster Within Distance"
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTLandBlockE()
        frmMain.lblCData.Text = "Landblock ="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTLandColumnE()
        frmMain.lblCData.Text = "Landcell ="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
    End Sub
    Sub CTPortalSpaceEnter()
        frmMain.lblCData.Text = "Enter Portal Space"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTPortalSpaceExit()
        frmMain.lblCData.Text = "Exit Portal Space"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTNot()
        frmMain.lblCData.Text = "Not"
        'frmMain.txtBoxCData.Enabled = True
        'frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTSecondsInStatePersistGE()
        frmMain.lblCData.Text = "Seconds in State Persist >="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTTimeLeftOnSpellGE()
        frmMain.lblCData.Text = "Time left on spell >= (Seconds)"
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTBurdenPercentGE()
        frmMain.lblCData.Text = "Burden Percentage >="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTDistanceToAnyRoutePointGE()
        frmMain.lblCData.Text = "Distance to Route Point >="
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTExpression()
        frmMain.lblCData.Text = "Chat Expression"
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True

    End Sub
    Sub CTClientDialogPopup()
        frmMain.lblCData.Text = "Client Dialog PopUp - DISABLED, NOT IN GAME"
        'frmMain.txtBoxCData.Enabled = False
        'frmMain.txtBoxCData.Visible = False

    End Sub
    Sub CTChatMessageCapture()
        frmMain.lblCData.Text = "Chat Message Pattern"
        frmMain.lblCData2.Text = "Chat ColorID List (Leave Blank)"
        frmMain.lblCData2.Visible = True
        'frmMain.txtBoxCData.Enabled = True
        frmMain.txtBoxCData.Visible = True
        frmMain.txtBoxCData2.Visible = True

    End Sub

    'Action Types
    Sub ResetAction()
        'Label A Data is always visible
        frmMain.lblAData.Visible = True
        'Making sure Text boxes enabled
        frmMain.txtBoxAData.Enabled = True
        frmMain.txtBoxAData2.Enabled = True
        frmMain.txtBoxAData3.Enabled = True
        'Hiding everything Except Label A Data
        frmMain.txtBoxAData.Visible = False
        frmMain.txtBoxAData2.Visible = False
        frmMain.txtBoxAData3.Visible = False
        'Testing for making txtboxadata2 multiline for emedded navs
        frmMain.txtBoxAData.Multiline = False
        frmMain.cBoxATMetaState.Visible = False
        frmMain.cboxReturnMetaState.Visible = False
        frmMain.lblAdata2.Visible = False
        frmMain.lblAData3.Visible = False
        frmMain.lblATMetaState.Visible = False
        frmMain.lblATReturnToState.Visible = False
        frmMain.btnChooseNav.Visible = False
        frmMain.btnATCreateState.Visible = False
        frmMain.dgvATMultiple.Visible = False

        frmMain.btnAddATAnyAll.Visible = False
        frmMain.btnEditATAnyAll.Visible = False
        frmMain.btnDeleteATAnyAll.Visible = False
        frmMain.lstBoxCommonOptions.Visible = False
        frmMain.rdbTrue.Visible = False
        frmMain.rdbFalse.Visible = False

        'Clearing the fields.
        frmMain.lblAData.Text = ""
        frmMain.lblAdata2.Text = ""
        frmMain.lblAData3.Text = ""
        frmMain.txtBoxAData.Text = ""
        frmMain.txtBoxAData2.Text = ""
        frmMain.txtBoxAData3.Text = ""
        frmMain.cBoxATMetaState.Text = "Default"
        frmMain.cboxReturnMetaState.Text = "Default"
    End Sub

    Sub ATSingleRule()
        frmMain.txtBoxAData.Visible = True
    End Sub
    Sub ATDoubleRule()
        frmMain.txtBoxAData.Visible = True
        frmMain.txtBoxAData2.Visible = True
        frmMain.lblAdata2.Visible = True
    End Sub
    Sub ATSetOptionsRule()
        frmMain.txtBoxAData.Visible = True
        frmMain.txtBoxAData2.Visible = True
        frmMain.lblAdata2.Visible = True
        frmMain.lblATMetaState.Visible = True
        frmMain.lstBoxCommonOptions.Visible = True
        frmMain.rdbTrue.Visible = True
        frmMain.rdbFalse.Visible = True
    End Sub
    Sub ATTripleRule()
        frmMain.txtBoxAData.Visible = True
        frmMain.txtBoxAData2.Visible = True
        frmMain.txtBoxAData3.Visible = True

        frmMain.lblAData.Visible = True
        frmMain.lblAdata2.Visible = True
        frmMain.lblAData3.Visible = True
    End Sub
    Sub ATSetStateRule()
        frmMain.cBoxATMetaState.Visible = True
        'frmMain.cboxReturnMetaState.Visible = True
        frmMain.lblATMetaState.Visible = True
        frmMain.btnATCreateState.Visible = True
    End Sub
    Sub ATCallStateRule()
        frmMain.cBoxATMetaState.Visible = True
        frmMain.cboxReturnMetaState.Visible = True
        frmMain.lblATMetaState.Visible = True
        frmMain.lblATReturnToState.Visible = True
        frmMain.btnATCreateState.Visible = True

    End Sub
    Sub ATMultiple()
        ''frmMain.txtBoxAData.Enabled = True
        'frmMain.txtBoxAData.Visible = True
        'frmMain.cBoxATMetaState.Visible = False
        'frmMain.lblATMetaState.Visible = False
        'frmMain.lblAData.Visible = True
        'frmMain.lblAData.Text = "Multiple"
        frmMain.dgvATMultiple.Visible = True

        frmMain.btnAddATAnyAll.Visible = True
        frmMain.btnEditATAnyAll.Visible = True
        frmMain.btnDeleteATAnyAll.Visible = True
    End Sub
    Sub ATSet(ATString As String)
        Select Case ATString 'This now replaces all the crap code I had for reseting the form for ActionTypes.  Should fix issues.
            Case "0", "None"
                frmMain.txtBoxAData.Text = "0"
            Case "1", "SetState"
                SetForm.ATSetStateRule()
            Case "2", "ChatCommand"
                SetForm.ATSingleRule()
                frmMain.lblAData.Text = "Chat Command"
            Case "3", "Multiple"
                SetForm.ATMultiple()
            Case "4", "EmbeddedNavRoute"
                SetForm.ATSingleRule()
                frmMain.txtBoxAData.Multiline = True
                frmMain.btnChooseNav.Visible = True
                frmMain.lblAData.Text = "Embedded Nav - Choose File"
            Case "5", "CallState"
                SetForm.ATCallStateRule()
                frmMain.lblATMetaState.Text = "State To Call"
            Case "6", "ReturnFromCall"
                frmMain.lblAData.Text = "Return From Call"
                frmMain.txtBoxAData.Text = "0"
            Case "7", "ExpressionAct"
                SetForm.ATSingleRule()
                frmMain.lblAData.Text = "Expression Action"
            Case "8", "ChatWithExpression"
                SetForm.ATSingleRule()
                frmMain.lblAData.Text = "Chat with Expression"
            Case "9", "WatchdogSet"
                SetForm.ATTripleRule()
                frmMain.lblAData.Text = "State to Call:"
                frmMain.lblAdata2.Text = "Movement Range (Meters):"
                frmMain.lblAData3.Text = "Time Span (Seconds):"
            Case "10", "WatchdogClear"
                frmMain.lblAData.Text = "WatchDog Clear"
                frmMain.txtBoxAData.Text = "0"
            Case "11", "GetVTOption"
                SetForm.ATSetOptionsRule()
                frmMain.lblAData.Text = "Option to Get"
                frmMain.lblAdata2.Text = "Expression Variable Target"
                frmMain.lblATMetaState.Text = "Common Options"
            Case "12", "SetVTOption"
                SetForm.ATSetOptionsRule()
                frmMain.lblAData.Text = "Option to Set"
                frmMain.lblAdata2.Text = "Expresssion (True/False, Value)"
                frmMain.lblATMetaState.Text = "Common Options"
            Case "13", "CreateView"
                SetForm.ATDoubleRule()
                frmMain.lblAData.Text = "Name of View"
                frmMain.lblAdata2.Text = "Raw XML Data"
            Case "14", "DestroyView"
                SetForm.ATSingleRule()
                frmMain.lblAData.Text = "Name of View to Destroy"
            Case "15", "DestroyAllViews"
                'SetForm.ATDoubleRule()
                'frmMain.lblAData.Text = "Option to Set"

        End Select
    End Sub
    Sub CTSet(CTString As String)

        Select Case CTString
            Case "0", "Never"
                frmMain.lblCData.Text = "Never"
                frmMain.txtBoxCData.Text = "0"
            Case "1", "Always"
                frmMain.lblCData.Text = "Always"
                frmMain.txtBoxCData.Text = "0"
            Case "2", "All"
                SetForm.CTAnyAll()
                frmMain.lblCData.Text = "All"
            Case "3", "Any"
                SetForm.CTAnyAll()
                frmMain.lblCData.Text = "Any"

            Case "4", "ChatMessage"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Chat Message"

            Case "5", "MainPackSlotsLE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Main Pack Slots Less than or Equal To:"

            Case "6", "SecondsInStateGE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Seconds in State Greater than or Equal To:"

            Case "7", "NavrouteEmpty"
                frmMain.lblCData.Text = "Nav Route Empty"
                frmMain.txtBoxCData.Text = "0"


            Case "8", "Died"
                frmMain.txtBoxCData.Text = "0"
            Case "9", "VendorOpen"
                frmMain.txtBoxCData.Text = "0"
            Case "10", "VendorClosed"
                frmMain.txtBoxCData.Text = "0"
            Case "11", "ItemCountLE"
                SetForm.CTDouble()
                frmMain.lblCData.Text = "Item"
                frmMain.lblCData2.Text = "Number of items <="
            Case "12", "ItemCountGE"
                SetForm.CTDouble()
                frmMain.lblCData.Text = "Item"
                frmMain.lblCData2.Text = "Number of items >="
            Case "13", "MonsterCountWithinDistance"
                SetForm.CTTriple()
                frmMain.lblCData.Text = "Monster Name (regex):"
                frmMain.lblCData2.Text = "Monster Count Greater Than or Equal to (>=):"
                frmMain.lblCData3.Text = "Range (Meters):"
                'Defaults
                frmMain.txtBoxCData2.Text = "1"
                frmMain.txtBoxCData3.Text = "5"
            Case "14", "MonstersWithPriorityWithinDistance"
                SetForm.CTTriple()
                frmMain.lblCData.Text = "Monsters Priorty:"
                frmMain.lblCData2.Text = "Monster Count Greater Than or Equal to (>=):"
                frmMain.lblCData3.Text = "Range (Meters):"
                'Defaults
                frmMain.txtBoxCData.Text = "-1"
                frmMain.txtBoxCData2.Text = "1"
                frmMain.txtBoxCData3.Text = "5"

            Case "15", "NeedToBuff"
            Case "16", "NoMonstersWithinDistance"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "No Monsters within Distance:"
            Case "17", "LandBlockE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Land Block Equals:"
                frmMain.txtBoxCData.Text = "00000000"

            Case "18", "LandCellE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Land Cell Equals:"
                frmMain.txtBoxCData.Text = "00000000"

            Case "19", "PortalspaceEnter"
                frmMain.txtBoxCData.Text = "0"
            Case "20", "PortalspaceExit"
                frmMain.txtBoxCData.Text = "0"
            Case "21", "Not"
                SetForm.CTAnyAll()
                frmMain.lblCData.Text = "NOT"
            Case "22", "SecondsInStatePersietGE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Seconds in State Persist:"
            Case "23", "TimeLeftOnSpellGE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Time Left on Spell Greater than or Equal To:"
            Case "24", "BurdenPercentGE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Burden Percentage Greater than or Equal To:"
            Case "25", "DistanceToAnyRoutePointGE"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Distance to Any Route Point Greater than or Equal To:"
            Case "26", "Expression"
                SetForm.CTSingle()
                frmMain.lblCData.Text = "Expression:"

            Case "27", "ClientDialogPopup"
                frmMain.txtBoxCData.Text = "0"
                frmMain.lblCData.Text = "Client Dialog PopUp - DISABLED, NOT IN GAME:"
                MsgBox("Not yet Implemented")
            Case "28", "ChatMessageCapture"
                SetForm.CTDouble()
                frmMain.lblCData.Text = "Chat Message Pattern:"
                frmMain.lblCData2.Text = "Chat ColorID List: (Leave Blank)"

                frmMain.Refresh()

        End Select
    End Sub
End Module
