Module Start

    Sub Main()
        'Check if command line arguments were specified
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length > 1 Then
            'Yes Arguments, set to read them and carry them out
            If args(1) = "-c" Then
                'Convert XML to Meta

            Else
                MsgBox("Incorrect Command Line Argument")
            End If

        Else



            frmMain.ShowDialog()

            '--- Nope, run the normal Windows Forms startup code
            '    Application.EnableVisualStyles()
            'Application.SetCompatibleTextRenderingDefault(False)
            'Application.Run(MiMB_Test.frmMain())
            ' Dim args = Environment.GetCommandLineArgs()

            'If args.Length > 1 Then textBox1.Text = args(1)
            'If args.Length > 2 Then textBox2.Text = args(2)
        End If
    End Sub

End Module
