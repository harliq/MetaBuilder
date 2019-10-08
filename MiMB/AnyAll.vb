Imports System.Text.RegularExpressions

Public Class AnyAll

    Public InputString As String
    Public RegexPattern As String
    Public MultipleNested As Boolean
    Public MultiTable As DataTable
    Public ReturnMultiple As String
    Public StringPattern As String
    Public Occurence As Integer


    Public Sub New(ByVal input As String, ByVal regex As String, ByVal multipleNested As Boolean)
        InputString = input
        RegexPattern = regex
        multipleNested = multipleNested
        MultiTable = regxMatch(input, regex, multipleNested)
    End Sub

    Public Sub New(ByVal input As String, ByVal regex As String)
        InputString = input
        RegexPattern = regex
        ReturnMultiple = regxStrip(input, regex)
    End Sub

    Public Sub New(ByVal input As String, ByVal stringpat As String, ByVal num As Integer)
        InputString = input
        StringPattern = stringpat
        Occurence = countString(input, stringpat)
    End Sub

    'Public Sub New(ByVal input As String, ByVal stringpat As String)
    '    InputString = input
    '    StringPattern = stringpat
    '    Occurence = regxStrip(input, stringpat)
    'End Sub

    Function countString(ByVal input As String, ByVal stringToBeSearchedInsideTheInputString As String) As Integer
        Return System.Text.RegularExpressions.Regex.Split(InputString, stringToBeSearchedInsideTheInputString).Length - 1

    End Function


    Function regxStrip(ByVal text As String, ByVal expr As String) As String

        Dim rmatch As String = ""
        Dim r As Regex = New Regex(expr, RegexOptions.IgnoreCase)

        'match the regex pattern against string
        Dim m As Match = r.Match(text)
        Dim matchcount As Integer = 0
        Dim i As Integer = matchcount
        Do While m.Success 'if there is a regex match
            matchcount += 1
            i = matchcount
            Dim tempC As Integer = 0
            'Dim myMod As Integer
            For i = 1 To 2 ' ******THIS MAY NEED TO BE CHANGED**********  - 1-20 is not correct, but not sure how to count, but it works, and ignoring the blanks
                Dim g As Group = m.Groups(i)
                Dim cc As CaptureCollection = g.Captures
                Dim myC As Integer
                For myC = 0 To cc.Count - 1
                    Dim c As Capture = cc(myC)

                    rmatch = c.ToString()


                    tempC = tempC + 1

                Next
            Next
            m = m.NextMatch()
        Loop
        'TextBox2.Text = TextBox2.Text & tData
        Return rmatch


    End Function


    Function regxMatch(ByVal text As String, ByVal expr As String, ByVal isMultiple As Boolean) As DataTable

        Dim multipleTable As New DataTable("MultipleTable")
        multipleTable.Columns.Add("Type", Type.GetType("System.String"))
        multipleTable.Columns.Add("Data", Type.GetType("System.String"))

        Dim tColOneData As String = ""
        Dim tColTwoData As String = ""
        Dim tData As String = ""


        'initiate the regex object
        Dim r As Regex = New Regex(expr, RegexOptions.IgnoreCase)

        'match the regex pattern against string
        Dim m As Match = r.Match(text)
        Dim matchcount As Integer = 0
        Dim i As Integer = matchcount
        Do While m.Success 'if there is a regex match
            matchcount += 1
            i = matchcount
            Dim tempC As Integer = 0
            Dim myMod As Integer
            For i = 1 To 500 ' ******THIS MAY NEED TO BE CHANGED**********  - 1-20 is not correct, but not sure how to count, but it works, and ignoring the blanks
                Dim g As Group = m.Groups(i)
                Dim cc As CaptureCollection = g.Captures
                Dim myC As Integer
                For myC = 0 To cc.Count - 1
                    Dim c As Capture = cc(myC)
                    myMod = tempC Mod 2
                    'If isMultiple = True Then 'This checks to see if there is another nested "Multiple:"
                    '    tData = tData & c.ToString() & vbCrLf
                    'Else 'If not another "Multiple:"  Formats info for display in new data table
                    '    If myMod = 0 Then
                    '        tColOneData = c.ToString()
                    '        tData = tData & c.ToString() & vbTab
                    '        tColTwoData = ""
                    '    Else
                    '        tColTwoData = c.ToString()
                    '        tData = tData & c.ToString() & vbCrLf
                    '    End If
                    'End If
                    If myMod = 0 Then
                        tColOneData = c.ToString()
                        tData = tData & c.ToString() & vbTab
                        tColTwoData = ""
                    Else
                        tColTwoData = c.ToString()
                        tData = tData & c.ToString() & vbCrLf
                    End If

                    tempC = tempC + 1
                    'Adding to data table
                    If tColTwoData = "" Then
                    Else
                        multipleTable.Rows.Add(tColOneData, tColTwoData)
                    End If
                Next
            Next
            m = m.NextMatch()
        Loop
        'TextBox2.Text = TextBox2.Text & tData
        Return multipleTable
    End Function

End Class
