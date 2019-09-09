<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.lblXMLdir = New System.Windows.Forms.Label()
        Me.txtXMLdir = New System.Windows.Forms.TextBox()
        Me.lblMetaDir = New System.Windows.Forms.Label()
        Me.txtMetaDir = New System.Windows.Forms.TextBox()
        Me.fbdXML = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbdMeta = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse1 = New System.Windows.Forms.Button()
        Me.btnBrowse2 = New System.Windows.Forms.Button()
        Me.txtNavDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBrowse3 = New System.Windows.Forms.Button()
        Me.chkMetaExportDebug = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblXMLdir
        '
        Me.lblXMLdir.AutoSize = True
        Me.lblXMLdir.Location = New System.Drawing.Point(12, 9)
        Me.lblXMLdir.Name = "lblXMLdir"
        Me.lblXMLdir.Size = New System.Drawing.Size(111, 13)
        Me.lblXMLdir.TabIndex = 0
        Me.lblXMLdir.Text = "XML Default Directory"
        '
        'txtXMLdir
        '
        Me.txtXMLdir.Location = New System.Drawing.Point(15, 25)
        Me.txtXMLdir.Name = "txtXMLdir"
        Me.txtXMLdir.Size = New System.Drawing.Size(165, 20)
        Me.txtXMLdir.TabIndex = 1
        '
        'lblMetaDir
        '
        Me.lblMetaDir.AutoSize = True
        Me.lblMetaDir.Location = New System.Drawing.Point(12, 52)
        Me.lblMetaDir.Name = "lblMetaDir"
        Me.lblMetaDir.Size = New System.Drawing.Size(146, 13)
        Me.lblMetaDir.TabIndex = 2
        Me.lblMetaDir.Text = "Meta Export Default Directory"
        '
        'txtMetaDir
        '
        Me.txtMetaDir.Location = New System.Drawing.Point(15, 67)
        Me.txtMetaDir.Name = "txtMetaDir"
        Me.txtMetaDir.Size = New System.Drawing.Size(165, 20)
        Me.txtMetaDir.TabIndex = 3
        '
        'fbdXML
        '
        Me.fbdXML.Description = "Select Directory For XML"
        Me.fbdXML.SelectedPath = "C:\"
        '
        'fbdMeta
        '
        Me.fbdMeta.Description = "Select Directory For Metas"
        Me.fbdMeta.SelectedPath = "C:\"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(15, 188)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(120, 30)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(155, 188)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBrowse1
        '
        Me.btnBrowse1.Location = New System.Drawing.Point(200, 25)
        Me.btnBrowse1.Name = "btnBrowse1"
        Me.btnBrowse1.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse1.TabIndex = 6
        Me.btnBrowse1.Text = "Browse"
        Me.btnBrowse1.UseVisualStyleBackColor = True
        '
        'btnBrowse2
        '
        Me.btnBrowse2.Location = New System.Drawing.Point(200, 65)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse2.TabIndex = 7
        Me.btnBrowse2.Text = "Browse"
        Me.btnBrowse2.UseVisualStyleBackColor = True
        '
        'txtNavDir
        '
        Me.txtNavDir.Location = New System.Drawing.Point(15, 110)
        Me.txtNavDir.Name = "txtNavDir"
        Me.txtNavDir.Size = New System.Drawing.Size(165, 20)
        Me.txtNavDir.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Embedded Navs Default Directory"
        '
        'btnBrowse3
        '
        Me.btnBrowse3.Location = New System.Drawing.Point(200, 107)
        Me.btnBrowse3.Name = "btnBrowse3"
        Me.btnBrowse3.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse3.TabIndex = 10
        Me.btnBrowse3.Text = "Browse"
        Me.btnBrowse3.UseVisualStyleBackColor = True
        '
        'chkMetaExportDebug
        '
        Me.chkMetaExportDebug.AutoSize = True
        Me.chkMetaExportDebug.Location = New System.Drawing.Point(15, 146)
        Me.chkMetaExportDebug.Name = "chkMetaExportDebug"
        Me.chkMetaExportDebug.Size = New System.Drawing.Size(115, 17)
        Me.chkMetaExportDebug.TabIndex = 12
        Me.chkMetaExportDebug.Text = "MetaExport Debug"
        Me.chkMetaExportDebug.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 228)
        Me.Controls.Add(Me.chkMetaExportDebug)
        Me.Controls.Add(Me.btnBrowse3)
        Me.Controls.Add(Me.txtNavDir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowse2)
        Me.Controls.Add(Me.btnBrowse1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtMetaDir)
        Me.Controls.Add(Me.lblMetaDir)
        Me.Controls.Add(Me.txtXMLdir)
        Me.Controls.Add(Me.lblXMLdir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Options"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblXMLdir As Label
    Friend WithEvents txtXMLdir As TextBox
    Friend WithEvents lblMetaDir As Label
    Friend WithEvents txtMetaDir As TextBox
    Friend WithEvents fbdXML As FolderBrowserDialog
    Friend WithEvents fbdMeta As FolderBrowserDialog
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnBrowse1 As Button
    Friend WithEvents btnBrowse2 As Button
    Friend WithEvents txtNavDir As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBrowse3 As Button
    Friend WithEvents chkMetaExportDebug As CheckBox
End Class
