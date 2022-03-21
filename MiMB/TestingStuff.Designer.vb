<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestingStuff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxTest = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxTest
        '
        Me.TextBoxTest.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTest.Location = New System.Drawing.Point(13, 13)
        Me.TextBoxTest.MaxLength = 1000000000
        Me.TextBoxTest.Multiline = True
        Me.TextBoxTest.Name = "TextBoxTest"
        Me.TextBoxTest.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxTest.Size = New System.Drawing.Size(807, 506)
        Me.TextBoxTest.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(712, 538)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 41)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Close Window"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TestingStuff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 591)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBoxTest)
        Me.Name = "TestingStuff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meta DEBUG Window"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxTest As TextBox
    Friend WithEvents Button1 As Button
End Class
