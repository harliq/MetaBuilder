<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MiMbTest = New MiMB_Test.MiMbTest()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NavRoutesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cBoxCType = New System.Windows.Forms.ComboBox()
        Me.cBoxCTMetaState = New System.Windows.Forms.ComboBox()
        Me.lblCData = New System.Windows.Forms.Label()
        Me.txtBoxCData = New System.Windows.Forms.TextBox()
        Me.btnCreateRule = New System.Windows.Forms.Button()
        Me.btnCreateState = New System.Windows.Forms.Button()
        Me.lblCTMetaState = New System.Windows.Forms.Label()
        Me.lblCType = New System.Windows.Forms.Label()
        Me.cBoxAType = New System.Windows.Forms.ComboBox()
        Me.cBoxATMetaState = New System.Windows.Forms.ComboBox()
        Me.lblATMetaState = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblAData = New System.Windows.Forms.Label()
        Me.lblAType = New System.Windows.Forms.Label()
        Me.lstBoxCTMetaState = New System.Windows.Forms.ListBox()
        Me.lstBoxCType = New System.Windows.Forms.ListBox()
        Me.lstBoxATMetaState = New System.Windows.Forms.ListBox()
        Me.lstBoxAData = New System.Windows.Forms.ListBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportMeta = New System.Windows.Forms.ToolStripButton()
        Me.StateValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StateVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTypeValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CTypeVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDataValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CDataVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ATypeValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ATypeVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADataValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADataVar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.MiMbTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MiMbTest
        '
        Me.MiMbTest.DataSetName = "MiMbTest"
        Me.MiMbTest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1264, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NavRoutesToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'NavRoutesToolStripMenuItem
        '
        Me.NavRoutesToolStripMenuItem.Name = "NavRoutesToolStripMenuItem"
        Me.NavRoutesToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NavRoutesToolStripMenuItem.Text = "Nav Routes"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DefaultsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'DefaultsToolStripMenuItem
        '
        Me.DefaultsToolStripMenuItem.Name = "DefaultsToolStripMenuItem"
        Me.DefaultsToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.DefaultsToolStripMenuItem.Text = "Defaults"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpFileToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpFileToolStripMenuItem
        '
        Me.HelpFileToolStripMenuItem.Name = "HelpFileToolStripMenuItem"
        Me.HelpFileToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.HelpFileToolStripMenuItem.Text = "Help File"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbOpen, Me.tsbSave, Me.ToolStripButton1, Me.ToolStripSeparator1, Me.tsbExportMeta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = CType(resources.GetObject("tsbNew.Image"), System.Drawing.Image)
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbNew.Text = "New"
        '
        'tsbOpen
        '
        Me.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOpen.Image = CType(resources.GetObject("tsbOpen.Image"), System.Drawing.Image)
        Me.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOpen.Name = "tsbOpen"
        Me.tsbOpen.Size = New System.Drawing.Size(23, 22)
        Me.tsbOpen.Text = "Open"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "Save"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.StateValue, Me.StateVar, Me.CTypeValue, Me.CTypeVar, Me.CDataValue, Me.CDataVar, Me.ATypeValue, Me.ATypeVar, Me.ADataValue, Me.ADataVar})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 57)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1240, 285)
        Me.DataGridView1.TabIndex = 2
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 348)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cBoxCType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cBoxCTMetaState)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtBoxCData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCreateRule)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCreateState)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCTMetaState)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCType)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cBoxAType)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cBoxATMetaState)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblATMetaState)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblAData)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblAType)
        Me.SplitContainer1.Size = New System.Drawing.Size(926, 379)
        Me.SplitContainer1.SplitterDistance = 196
        Me.SplitContainer1.TabIndex = 11
        '
        'cBoxCType
        '
        Me.cBoxCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxCType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxCType.FormattingEnabled = True
        Me.cBoxCType.Items.AddRange(New Object() {"Never", "Always", "All", "Any", "Chat Message"})
        Me.cBoxCType.Location = New System.Drawing.Point(15, 42)
        Me.cBoxCType.MaxDropDownItems = 22
        Me.cBoxCType.Name = "cBoxCType"
        Me.cBoxCType.Size = New System.Drawing.Size(162, 28)
        Me.cBoxCType.TabIndex = 20
        '
        'cBoxCTMetaState
        '
        Me.cBoxCTMetaState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxCTMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxCTMetaState.FormattingEnabled = True
        Me.cBoxCTMetaState.Location = New System.Drawing.Point(208, 42)
        Me.cBoxCTMetaState.MaxDropDownItems = 100
        Me.cBoxCTMetaState.Name = "cBoxCTMetaState"
        Me.cBoxCTMetaState.Size = New System.Drawing.Size(175, 28)
        Me.cBoxCTMetaState.Sorted = True
        Me.cBoxCTMetaState.TabIndex = 19
        '
        'lblCData
        '
        Me.lblCData.AutoSize = True
        Me.lblCData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCData.Location = New System.Drawing.Point(11, 80)
        Me.lblCData.Name = "lblCData"
        Me.lblCData.Size = New System.Drawing.Size(153, 20)
        Me.lblCData.TabIndex = 18
        Me.lblCData.Text = "Condition Type Data"
        '
        'txtBoxCData
        '
        Me.txtBoxCData.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxCData.Location = New System.Drawing.Point(14, 103)
        Me.txtBoxCData.Name = "txtBoxCData"
        Me.txtBoxCData.Size = New System.Drawing.Size(850, 23)
        Me.txtBoxCData.TabIndex = 17
        Me.txtBoxCData.Text = "Condition Type Data"
        '
        'btnCreateRule
        '
        Me.btnCreateRule.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateRule.Location = New System.Drawing.Point(753, 36)
        Me.btnCreateRule.Name = "btnCreateRule"
        Me.btnCreateRule.Size = New System.Drawing.Size(129, 32)
        Me.btnCreateRule.TabIndex = 16
        Me.btnCreateRule.Text = "Create Rule"
        Me.btnCreateRule.UseVisualStyleBackColor = True
        '
        'btnCreateState
        '
        Me.btnCreateState.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateState.Location = New System.Drawing.Point(411, 40)
        Me.btnCreateState.Name = "btnCreateState"
        Me.btnCreateState.Size = New System.Drawing.Size(92, 32)
        Me.btnCreateState.TabIndex = 15
        Me.btnCreateState.Text = "CreateState"
        Me.btnCreateState.UseVisualStyleBackColor = True
        '
        'lblCTMetaState
        '
        Me.lblCTMetaState.AutoSize = True
        Me.lblCTMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTMetaState.Location = New System.Drawing.Point(204, 19)
        Me.lblCTMetaState.Name = "lblCTMetaState"
        Me.lblCTMetaState.Size = New System.Drawing.Size(88, 20)
        Me.lblCTMetaState.TabIndex = 14
        Me.lblCTMetaState.Text = "Meta State"
        '
        'lblCType
        '
        Me.lblCType.AutoSize = True
        Me.lblCType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCType.Location = New System.Drawing.Point(11, 19)
        Me.lblCType.Name = "lblCType"
        Me.lblCType.Size = New System.Drawing.Size(114, 20)
        Me.lblCType.TabIndex = 12
        Me.lblCType.Text = "Condition Type"
        '
        'cBoxAType
        '
        Me.cBoxAType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxAType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxAType.FormattingEnabled = True
        Me.cBoxAType.Items.AddRange(New Object() {"None", "Set Meta State", "Chat Command"})
        Me.cBoxAType.Location = New System.Drawing.Point(15, 36)
        Me.cBoxAType.Name = "cBoxAType"
        Me.cBoxAType.Size = New System.Drawing.Size(162, 28)
        Me.cBoxAType.TabIndex = 7
        '
        'cBoxATMetaState
        '
        Me.cBoxATMetaState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cBoxATMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cBoxATMetaState.FormattingEnabled = True
        Me.cBoxATMetaState.Location = New System.Drawing.Point(208, 36)
        Me.cBoxATMetaState.MaxDropDownItems = 100
        Me.cBoxATMetaState.Name = "cBoxATMetaState"
        Me.cBoxATMetaState.Size = New System.Drawing.Size(175, 28)
        Me.cBoxATMetaState.Sorted = True
        Me.cBoxATMetaState.TabIndex = 6
        '
        'lblATMetaState
        '
        Me.lblATMetaState.AutoSize = True
        Me.lblATMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblATMetaState.Location = New System.Drawing.Point(204, 13)
        Me.lblATMetaState.Name = "lblATMetaState"
        Me.lblATMetaState.Size = New System.Drawing.Size(84, 20)
        Me.lblATMetaState.TabIndex = 5
        Me.lblATMetaState.Text = "MetaState"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(14, 92)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(850, 20)
        Me.TextBox1.TabIndex = 3
        '
        'lblAData
        '
        Me.lblAData.AutoSize = True
        Me.lblAData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAData.Location = New System.Drawing.Point(10, 69)
        Me.lblAData.Name = "lblAData"
        Me.lblAData.Size = New System.Drawing.Size(93, 20)
        Me.lblAData.TabIndex = 2
        Me.lblAData.Text = "Action Data"
        '
        'lblAType
        '
        Me.lblAType.AutoSize = True
        Me.lblAType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAType.Location = New System.Drawing.Point(10, 13)
        Me.lblAType.Name = "lblAType"
        Me.lblAType.Size = New System.Drawing.Size(92, 20)
        Me.lblAType.TabIndex = 1
        Me.lblAType.Text = "Action Type"
        '
        'lstBoxCTMetaState
        '
        Me.lstBoxCTMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBoxCTMetaState.FormattingEnabled = True
        Me.lstBoxCTMetaState.ItemHeight = 20
        Me.lstBoxCTMetaState.Location = New System.Drawing.Point(1036, 396)
        Me.lstBoxCTMetaState.Name = "lstBoxCTMetaState"
        Me.lstBoxCTMetaState.Size = New System.Drawing.Size(163, 24)
        Me.lstBoxCTMetaState.TabIndex = 13
        '
        'lstBoxCType
        '
        Me.lstBoxCType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBoxCType.FormattingEnabled = True
        Me.lstBoxCType.ItemHeight = 20
        Me.lstBoxCType.Items.AddRange(New Object() {"Never", "Always", "All", "Any", "Chat Message"})
        Me.lstBoxCType.Location = New System.Drawing.Point(1036, 450)
        Me.lstBoxCType.Name = "lstBoxCType"
        Me.lstBoxCType.Size = New System.Drawing.Size(163, 24)
        Me.lstBoxCType.TabIndex = 11
        '
        'lstBoxATMetaState
        '
        Me.lstBoxATMetaState.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBoxATMetaState.FormattingEnabled = True
        Me.lstBoxATMetaState.ItemHeight = 20
        Me.lstBoxATMetaState.Items.AddRange(New Object() {"lstBoxATMetaState"})
        Me.lstBoxATMetaState.Location = New System.Drawing.Point(1036, 584)
        Me.lstBoxATMetaState.Name = "lstBoxATMetaState"
        Me.lstBoxATMetaState.Size = New System.Drawing.Size(163, 24)
        Me.lstBoxATMetaState.TabIndex = 4
        '
        'lstBoxAData
        '
        Me.lstBoxAData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstBoxAData.FormattingEnabled = True
        Me.lstBoxAData.ItemHeight = 20
        Me.lstBoxAData.Items.AddRange(New Object() {"None", "Set Meta State", "Chat Command"})
        Me.lstBoxAData.Location = New System.Drawing.Point(1036, 617)
        Me.lstBoxAData.Name = "lstBoxAData"
        Me.lstBoxAData.Size = New System.Drawing.Size(163, 24)
        Me.lstBoxAData.TabIndex = 0
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExportMeta
        '
        Me.tsbExportMeta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExportMeta.Image = CType(resources.GetObject("tsbExportMeta.Image"), System.Drawing.Image)
        Me.tsbExportMeta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportMeta.Name = "tsbExportMeta"
        Me.tsbExportMeta.Size = New System.Drawing.Size(23, 22)
        Me.tsbExportMeta.Text = "Export Meta"
        '
        'StateValue
        '
        Me.StateValue.HeaderText = "State"
        Me.StateValue.Name = "StateValue"
        Me.StateValue.Width = 150
        '
        'StateVar
        '
        Me.StateVar.HeaderText = "StateVar"
        Me.StateVar.Name = "StateVar"
        Me.StateVar.Width = 50
        '
        'CTypeValue
        '
        Me.CTypeValue.HeaderText = "Condition Type"
        Me.CTypeValue.Name = "CTypeValue"
        Me.CTypeValue.Width = 170
        '
        'CTypeVar
        '
        Me.CTypeVar.HeaderText = "CTypeVar"
        Me.CTypeVar.Name = "CTypeVar"
        Me.CTypeVar.Width = 50
        '
        'CDataValue
        '
        Me.CDataValue.HeaderText = "Condition Data"
        Me.CDataValue.Name = "CDataValue"
        Me.CDataValue.Width = 220
        '
        'CDataVar
        '
        Me.CDataVar.HeaderText = "CDataVar"
        Me.CDataVar.Name = "CDataVar"
        Me.CDataVar.Width = 50
        '
        'ATypeValue
        '
        Me.ATypeValue.HeaderText = "Action Type"
        Me.ATypeValue.Name = "ATypeValue"
        Me.ATypeValue.Width = 150
        '
        'ATypeVar
        '
        Me.ATypeVar.HeaderText = "ATypeVar"
        Me.ATypeVar.Name = "ATypeVar"
        Me.ATypeVar.Width = 50
        '
        'ADataValue
        '
        Me.ADataValue.HeaderText = "Action Data"
        Me.ADataValue.Name = "ADataValue"
        Me.ADataValue.Width = 220
        '
        'ADataVar
        '
        Me.ADataVar.HeaderText = "ADataVar"
        Me.ADataVar.Name = "ADataVar"
        Me.ADataVar.Width = 50
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 730)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lstBoxATMetaState)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lstBoxAData)
        Me.Controls.Add(Me.lstBoxCTMetaState)
        Me.Controls.Add(Me.lstBoxCType)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "MImb"
        CType(Me.MiMbTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MiMbTest As MiMbTest
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NavRoutesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbNew As ToolStripButton
    Friend WithEvents tsbOpen As ToolStripButton
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblCData As Label
    Friend WithEvents txtBoxCData As TextBox
    Friend WithEvents btnCreateRule As Button
    Friend WithEvents btnCreateState As Button
    Friend WithEvents lblCTMetaState As Label
    Friend WithEvents lstBoxCTMetaState As ListBox
    Friend WithEvents lblCType As Label
    Friend WithEvents lstBoxCType As ListBox
    Friend WithEvents lblATMetaState As Label
    Friend WithEvents lstBoxATMetaState As ListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblAData As Label
    Friend WithEvents lblAType As Label
    Friend WithEvents lstBoxAData As ListBox
    Friend WithEvents cBoxCTMetaState As ComboBox
    Friend WithEvents cBoxATMetaState As ComboBox
    Friend WithEvents cBoxCType As ComboBox
    Friend WithEvents cBoxAType As ComboBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbExportMeta As ToolStripButton
    Friend WithEvents StateValue As DataGridViewTextBoxColumn
    Friend WithEvents StateVar As DataGridViewTextBoxColumn
    Friend WithEvents CTypeValue As DataGridViewTextBoxColumn
    Friend WithEvents CTypeVar As DataGridViewTextBoxColumn
    Friend WithEvents CDataValue As DataGridViewTextBoxColumn
    Friend WithEvents CDataVar As DataGridViewTextBoxColumn
    Friend WithEvents ATypeValue As DataGridViewTextBoxColumn
    Friend WithEvents ATypeVar As DataGridViewTextBoxColumn
    Friend WithEvents ADataValue As DataGridViewTextBoxColumn
    Friend WithEvents ADataVar As DataGridViewTextBoxColumn
End Class
