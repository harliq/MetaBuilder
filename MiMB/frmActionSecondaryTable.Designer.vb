<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecondaryTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSecondaryTable))
        Me.cBoxType = New System.Windows.Forms.ComboBox()
        Me.lblCbox = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblTextOne = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lblTextTwo = New System.Windows.Forms.Label()
        Me.lblTextThree = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cBoxType
        '
        Me.cBoxType.DropDownHeight = 150
        Me.cBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxType.FormattingEnabled = True
        Me.cBoxType.IntegralHeight = False
        Me.cBoxType.Location = New System.Drawing.Point(15, 42)
        Me.cBoxType.MaxDropDownItems = 30
        Me.cBoxType.Name = "cBoxType"
        Me.cBoxType.Size = New System.Drawing.Size(387, 28)
        Me.cBoxType.TabIndex = 21
        '
        'lblCbox
        '
        Me.lblCbox.AutoSize = True
        Me.lblCbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCbox.Location = New System.Drawing.Point(12, 23)
        Me.lblCbox.Name = "lblCbox"
        Me.lblCbox.Size = New System.Drawing.Size(64, 16)
        Me.lblCbox.TabIndex = 23
        Me.lblCbox.Text = "Condition"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(492, 42)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 25)
        Me.btnOk.TabIndex = 24
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(492, 73)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 25)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 113)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(577, 20)
        Me.TextBox1.TabIndex = 26
        '
        'lblTextOne
        '
        Me.lblTextOne.AutoSize = True
        Me.lblTextOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextOne.Location = New System.Drawing.Point(12, 94)
        Me.lblTextOne.Name = "lblTextOne"
        Me.lblTextOne.Size = New System.Drawing.Size(49, 16)
        Me.lblTextOne.TabIndex = 27
        Me.lblTextOne.Text = "Label1"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(15, 163)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(577, 20)
        Me.TextBox2.TabIndex = 28
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(15, 215)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(577, 20)
        Me.TextBox3.TabIndex = 29
        '
        'lblTextTwo
        '
        Me.lblTextTwo.AutoSize = True
        Me.lblTextTwo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextTwo.Location = New System.Drawing.Point(12, 144)
        Me.lblTextTwo.Name = "lblTextTwo"
        Me.lblTextTwo.Size = New System.Drawing.Size(49, 16)
        Me.lblTextTwo.TabIndex = 30
        Me.lblTextTwo.Text = "Label1"
        '
        'lblTextThree
        '
        Me.lblTextThree.AutoSize = True
        Me.lblTextThree.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextThree.Location = New System.Drawing.Point(12, 196)
        Me.lblTextThree.Name = "lblTextThree"
        Me.lblTextThree.Size = New System.Drawing.Size(49, 16)
        Me.lblTextThree.TabIndex = 31
        Me.lblTextThree.Text = "Label1"
        '
        'frmSecondaryTable
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(604, 262)
        Me.Controls.Add(Me.lblTextThree)
        Me.Controls.Add(Me.lblTextTwo)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblTextOne)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblCbox)
        Me.Controls.Add(Me.cBoxType)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSecondaryTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSecondaryTable"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cBoxType As ComboBox
    Friend WithEvents lblCbox As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblTextOne As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents lblTextTwo As Label
    Friend WithEvents lblTextThree As Label
End Class
