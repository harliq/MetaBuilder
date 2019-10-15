Imports System.IO
Imports System.Text

Module ImportMeta



    Function Load(table As DataTable) As DataTable

        '---------- Make copy of file for back up directory

        'check for backup directory     
        If (Not System.IO.Directory.Exists(My.Settings.XMLOpenSave & "\backup")) Then
            Try
                System.IO.Directory.CreateDirectory(My.Settings.XMLOpenSave & "\backup")
            Catch ex As Exception
                MsgBox("Backup Directory can not be created - " & My.Settings.XMLOpenSave & "backup")
            End Try
        End If

        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Meta Files|*.met"
        ofd.InitialDirectory = My.Settings.MetaExportDir
        ofd.Title = "Import VT Meta"


        If ofd.ShowDialog = DialogResult.OK Then

            '--------------Copy File to backup
            Try
                My.Computer.FileSystem.CopyFile(ofd.FileName, My.Settings.XMLOpenSave & "\backup\" & ofd.SafeFileName, True)

            Catch ex As Exception
                MsgBox("Auto Backup File could not be created")
            End Try

            frmMain.Text = "Mission:Impossible - Meta Builder   FILE= " & ofd.FileName

            Dim converter As New MetToXML.Converter(ofd.FileName)

            If Not converter.Convert() Then
                ' show message box here
                MsgBox("Error, File Not Found")
                ' Alert("Error Converting: " & converter.LastError)

                ' return empty table
                Return table
            End If

            ' load converted xml into a memory stream
            Dim stream As New MemoryStream(Encoding.UTF8.GetBytes(converter.XML))

            ' load converted xml stream into the table
            table.Clear()
            table.ReadXml(stream)

            Dim items = table.AsEnumerable().Select(Function(d) DirectCast(d(4).ToString(), Object)).ToArray()

            'Populating State Boxes
            frmMain.cBoxCTMetaState.Items.Clear()
            frmMain.cBoxATMetaState.Items.Clear()
            frmMain.cboxReturnMetaState.Items.Clear()
            frmMain.cBoxCTMetaState.Items.AddRange(items)
            frmMain.cBoxATMetaState.Items.AddRange(items)
            frmMain.cboxReturnMetaState.Items.AddRange(items)

            'Populating Table from XML File
            Dim i As Long
            Dim j As Long
            With frmMain.cBoxATMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With
            With frmMain.cboxReturnMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With
            With frmMain.cBoxCTMetaState
                For i = 0 To .Items.Count - 2 Step 1
                    For j = .Items.Count - 1 To i + 1 Step -1
                        If .Items(i).ToString = .Items(j).ToString Then
                            .Items.RemoveAt(j)
                        End If
                    Next
                Next
            End With

        Else

        End If
        Return table


    End Function

End Module
