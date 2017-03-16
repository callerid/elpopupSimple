<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AutomaticSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetNetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetUnitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SetUnitToCurrentTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SetUnitLineCountTo1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ListeningPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TSPort = New System.Windows.Forms.ToolStripTextBox
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TMIManual = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.UploadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveDataLocallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BTEthernetSend = New System.Windows.Forms.Button
        Me.TBOutgoingMessage = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TSConnectedUnits = New System.Windows.Forms.ToolStripStatusLabel
        Me.CBDetectedUnits = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TBSN = New System.Windows.Forms.TextBox
        Me.TBUN = New System.Windows.Forms.TextBox
        Me.TBPort = New System.Windows.Forms.TextBox
        Me.BTNRefresh = New System.Windows.Forms.Button
        Me.DGVCallData = New System.Windows.Forms.DataGridView
        Me.DGVCSerialNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGVCUnitNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DGVCData = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTNChangeUid = New System.Windows.Forms.Button
        Me.BTNChangeIpInt = New System.Windows.Forms.Button
        Me.BTNChangeMacInt = New System.Windows.Forms.Button
        Me.BTNChangePort = New System.Windows.Forms.Button
        Me.BTNChangeIpDest = New System.Windows.Forms.Button
        Me.BTNChangeMacDest = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.MACInternal = New IPControlsClass.MACInput
        Me.IPInternal = New IPControlsClass.IPInput
        Me.IPDest = New IPControlsClass.IPInput
        Me.MACDest = New IPControlsClass.MACInput
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GBInfo = New System.Windows.Forms.GroupBox
        Me.LBLinfo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmPassword = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsPassword = New System.Windows.Forms.ToolStripTextBox
        Me.tbLiteral = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.DisplayComputersIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DGVCallData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GBInfo.SuspendLayout()
        Me.cmPassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomaticSetupToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(592, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AutomaticSetupToolStripMenuItem
        '
        Me.AutomaticSetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetNetworkToolStripMenuItem, Me.ResetUnitToolStripMenuItem, Me.ToolStripSeparator1, Me.DisplayComputersIPAddressToolStripMenuItem, Me.ToolStripSeparator2, Me.SetUnitToCurrentTimeToolStripMenuItem, Me.SetUnitLineCountTo1ToolStripMenuItem, Me.ToolStripSeparator4, Me.ListeningPortToolStripMenuItem})
        Me.AutomaticSetupToolStripMenuItem.Name = "AutomaticSetupToolStripMenuItem"
        Me.AutomaticSetupToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.AutomaticSetupToolStripMenuItem.Text = "&Configure"
        '
        'ResetNetworkToolStripMenuItem
        '
        Me.ResetNetworkToolStripMenuItem.Name = "ResetNetworkToolStripMenuItem"
        Me.ResetNetworkToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ResetNetworkToolStripMenuItem.Tag = "reseteth"
        Me.ResetNetworkToolStripMenuItem.Text = "Reset &Ethernet Defaults"
        '
        'ResetUnitToolStripMenuItem
        '
        Me.ResetUnitToolStripMenuItem.Name = "ResetUnitToolStripMenuItem"
        Me.ResetUnitToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ResetUnitToolStripMenuItem.Tag = "resetunit"
        Me.ResetUnitToolStripMenuItem.Text = "Reset &Unit Defaults (for full featured units)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(292, 6)
        '
        'SetUnitToCurrentTimeToolStripMenuItem
        '
        Me.SetUnitToCurrentTimeToolStripMenuItem.Name = "SetUnitToCurrentTimeToolStripMenuItem"
        Me.SetUnitToCurrentTimeToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.SetUnitToCurrentTimeToolStripMenuItem.Text = "Set Unit to Current Time"
        '
        'SetUnitLineCountTo1ToolStripMenuItem
        '
        Me.SetUnitLineCountTo1ToolStripMenuItem.Name = "SetUnitLineCountTo1ToolStripMenuItem"
        Me.SetUnitLineCountTo1ToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.SetUnitLineCountTo1ToolStripMenuItem.Text = "Set Unit Line Count to 1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(292, 6)
        '
        'ListeningPortToolStripMenuItem
        '
        Me.ListeningPortToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSPort})
        Me.ListeningPortToolStripMenuItem.Name = "ListeningPortToolStripMenuItem"
        Me.ListeningPortToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.ListeningPortToolStripMenuItem.Text = "Listening &Port"
        '
        'TSPort
        '
        Me.TSPort.CausesValidation = False
        Me.TSPort.MaxLength = 6
        Me.TSPort.Name = "TSPort"
        Me.TSPort.Size = New System.Drawing.Size(100, 23)
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.TMIManual, Me.ToolStripSeparator3, Me.UploadDataToolStripMenuItem, Me.SaveDataLocallyToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'TMIManual
        '
        Me.TMIManual.Name = "TMIManual"
        Me.TMIManual.Size = New System.Drawing.Size(223, 22)
        Me.TMIManual.Text = "User &Manual"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(220, 6)
        '
        'UploadDataToolStripMenuItem
        '
        Me.UploadDataToolStripMenuItem.Name = "UploadDataToolStripMenuItem"
        Me.UploadDataToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.UploadDataToolStripMenuItem.Text = "Upload data to CallerID.com"
        '
        'SaveDataLocallyToolStripMenuItem
        '
        Me.SaveDataLocallyToolStripMenuItem.Name = "SaveDataLocallyToolStripMenuItem"
        Me.SaveDataLocallyToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.SaveDataLocallyToolStripMenuItem.Text = "Save data locally"
        '
        'BTEthernetSend
        '
        Me.BTEthernetSend.Location = New System.Drawing.Point(270, 299)
        Me.BTEthernetSend.Name = "BTEthernetSend"
        Me.BTEthernetSend.Size = New System.Drawing.Size(104, 23)
        Me.BTEthernetSend.TabIndex = 3
        Me.BTEthernetSend.Text = "&Send Command"
        Me.BTEthernetSend.UseVisualStyleBackColor = True
        '
        'TBOutgoingMessage
        '
        Me.TBOutgoingMessage.Location = New System.Drawing.Point(137, 302)
        Me.TBOutgoingMessage.Name = "TBOutgoingMessage"
        Me.TBOutgoingMessage.Size = New System.Drawing.Size(127, 20)
        Me.TBOutgoingMessage.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSConnectedUnits})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(592, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSConnectedUnits
        '
        Me.TSConnectedUnits.Name = "TSConnectedUnits"
        Me.TSConnectedUnits.Size = New System.Drawing.Size(577, 17)
        Me.TSConnectedUnits.Spring = True
        Me.TSConnectedUnits.Tag = "units"
        Me.TSConnectedUnits.Text = "No Units Detected"
        Me.TSConnectedUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBDetectedUnits
        '
        Me.CBDetectedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDetectedUnits.FormattingEnabled = True
        Me.CBDetectedUnits.Location = New System.Drawing.Point(137, 37)
        Me.CBDetectedUnits.Name = "CBDetectedUnits"
        Me.CBDetectedUnits.Size = New System.Drawing.Size(176, 21)
        Me.CBDetectedUnits.TabIndex = 20
        Me.CBDetectedUnits.Tag = "units"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(38, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Detected Units"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 26)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Serial Number"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 29)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Unit Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 29)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Unit IP Address"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 29)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Unit MAC Address"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 29)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Destination IP"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 171)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 33)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Destination MAC"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 113)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 29)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Port"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBSN
        '
        Me.TBSN.Location = New System.Drawing.Point(102, 3)
        Me.TBSN.Name = "TBSN"
        Me.TBSN.ReadOnly = True
        Me.TBSN.Size = New System.Drawing.Size(176, 20)
        Me.TBSN.TabIndex = 23
        Me.TBSN.Tag = "sn"
        '
        'TBUN
        '
        Me.TBUN.Location = New System.Drawing.Point(102, 29)
        Me.TBUN.Name = "TBUN"
        Me.TBUN.ReadOnly = True
        Me.TBUN.Size = New System.Drawing.Size(176, 20)
        Me.TBUN.TabIndex = 23
        Me.TBUN.Tag = "uid"
        '
        'TBPort
        '
        Me.TBPort.Location = New System.Drawing.Point(102, 116)
        Me.TBPort.Name = "TBPort"
        Me.TBPort.ReadOnly = True
        Me.TBPort.Size = New System.Drawing.Size(176, 20)
        Me.TBPort.TabIndex = 23
        Me.TBPort.Tag = "port"
        '
        'BTNRefresh
        '
        Me.BTNRefresh.Location = New System.Drawing.Point(319, 37)
        Me.BTNRefresh.Name = "BTNRefresh"
        Me.BTNRefresh.Size = New System.Drawing.Size(75, 23)
        Me.BTNRefresh.TabIndex = 26
        Me.BTNRefresh.Text = "&Refresh"
        Me.BTNRefresh.UseVisualStyleBackColor = True
        '
        'DGVCallData
        '
        Me.DGVCallData.AllowUserToAddRows = False
        Me.DGVCallData.AllowUserToDeleteRows = False
        Me.DGVCallData.AllowUserToResizeRows = False
        Me.DGVCallData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVCallData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVCallData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCallData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVCallData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCallData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DGVCSerialNumber, Me.DGVCUnitNumber, Me.DGVCData})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVCallData.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVCallData.Location = New System.Drawing.Point(0, 337)
        Me.DGVCallData.Name = "DGVCallData"
        Me.DGVCallData.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVCallData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVCallData.RowHeadersVisible = False
        Me.DGVCallData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVCallData.Size = New System.Drawing.Size(595, 145)
        Me.DGVCallData.TabIndex = 27
        '
        'DGVCSerialNumber
        '
        Me.DGVCSerialNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DGVCSerialNumber.FillWeight = 32.46532!
        Me.DGVCSerialNumber.HeaderText = "Serial Number"
        Me.DGVCSerialNumber.Name = "DGVCSerialNumber"
        Me.DGVCSerialNumber.ReadOnly = True
        Me.DGVCSerialNumber.Width = 99
        '
        'DGVCUnitNumber
        '
        Me.DGVCUnitNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DGVCUnitNumber.FillWeight = 91.37056!
        Me.DGVCUnitNumber.HeaderText = "Unit Number"
        Me.DGVCUnitNumber.Name = "DGVCUnitNumber"
        Me.DGVCUnitNumber.ReadOnly = True
        Me.DGVCUnitNumber.Width = 90
        '
        'DGVCData
        '
        Me.DGVCData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DGVCData.FillWeight = 176.1641!
        Me.DGVCData.HeaderText = "Data"
        Me.DGVCData.Name = "DGVCData"
        Me.DGVCData.ReadOnly = True
        '
        'BTNChangeUid
        '
        Me.BTNChangeUid.Location = New System.Drawing.Point(284, 29)
        Me.BTNChangeUid.Name = "BTNChangeUid"
        Me.BTNChangeUid.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeUid.TabIndex = 28
        Me.BTNChangeUid.Tag = "uid"
        Me.BTNChangeUid.Text = "Change"
        Me.BTNChangeUid.UseVisualStyleBackColor = True
        '
        'BTNChangeIpInt
        '
        Me.BTNChangeIpInt.Location = New System.Drawing.Point(284, 58)
        Me.BTNChangeIpInt.Name = "BTNChangeIpInt"
        Me.BTNChangeIpInt.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeIpInt.TabIndex = 29
        Me.BTNChangeIpInt.Tag = "ipint"
        Me.BTNChangeIpInt.Text = "Change"
        Me.BTNChangeIpInt.UseVisualStyleBackColor = True
        '
        'BTNChangeMacInt
        '
        Me.BTNChangeMacInt.Location = New System.Drawing.Point(284, 87)
        Me.BTNChangeMacInt.Name = "BTNChangeMacInt"
        Me.BTNChangeMacInt.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeMacInt.TabIndex = 30
        Me.BTNChangeMacInt.Tag = "macint"
        Me.BTNChangeMacInt.Text = "Locked"
        Me.BTNChangeMacInt.UseVisualStyleBackColor = True
        '
        'BTNChangePort
        '
        Me.BTNChangePort.Location = New System.Drawing.Point(284, 116)
        Me.BTNChangePort.Name = "BTNChangePort"
        Me.BTNChangePort.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangePort.TabIndex = 31
        Me.BTNChangePort.Tag = "port"
        Me.BTNChangePort.Text = "Change"
        Me.BTNChangePort.UseVisualStyleBackColor = True
        '
        'BTNChangeIpDest
        '
        Me.BTNChangeIpDest.Location = New System.Drawing.Point(284, 145)
        Me.BTNChangeIpDest.Name = "BTNChangeIpDest"
        Me.BTNChangeIpDest.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeIpDest.TabIndex = 32
        Me.BTNChangeIpDest.Tag = "ipdest"
        Me.BTNChangeIpDest.Text = "Change"
        Me.BTNChangeIpDest.UseVisualStyleBackColor = True
        '
        'BTNChangeMacDest
        '
        Me.BTNChangeMacDest.Location = New System.Drawing.Point(284, 174)
        Me.BTNChangeMacDest.Name = "BTNChangeMacDest"
        Me.BTNChangeMacDest.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeMacDest.TabIndex = 33
        Me.BTNChangeMacDest.Tag = "macdest"
        Me.BTNChangeMacDest.Text = "Change"
        Me.BTNChangeMacDest.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.MACInternal, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeMacDest, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeIpDest, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.TBSN, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangePort, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeMacInt, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TBUN, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeIpInt, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeUid, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TBPort, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.IPInternal, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.IPDest, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.MACDest, 1, 6)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(361, 204)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'MACInternal
        '
        Me.MACInternal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MACInternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MACInternal.Enabled = False
        Me.MACInternal.Location = New System.Drawing.Point(102, 87)
        Me.MACInternal.Name = "MACInternal"
        Me.MACInternal.Size = New System.Drawing.Size(161, 20)
        Me.MACInternal.TabIndex = 37
        Me.MACInternal.Tag = "macint"
        '
        'IPInternal
        '
        Me.IPInternal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.IPInternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPInternal.Enabled = False
        Me.IPInternal.HexIP = "FFFFFFFF"
        Me.IPInternal.Location = New System.Drawing.Point(102, 58)
        Me.IPInternal.MinimumSize = New System.Drawing.Size(125, 20)
        Me.IPInternal.Name = "IPInternal"
        Me.IPInternal.Size = New System.Drawing.Size(125, 20)
        Me.IPInternal.TabIndex = 34
        Me.IPInternal.Tag = "ipint"
        '
        'IPDest
        '
        Me.IPDest.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.IPDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPDest.Enabled = False
        Me.IPDest.HexIP = "FFFFFFFF"
        Me.IPDest.Location = New System.Drawing.Point(102, 145)
        Me.IPDest.MinimumSize = New System.Drawing.Size(125, 20)
        Me.IPDest.Name = "IPDest"
        Me.IPDest.Size = New System.Drawing.Size(125, 20)
        Me.IPDest.TabIndex = 35
        Me.IPDest.Tag = "ipdest"
        '
        'MACDest
        '
        Me.MACDest.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MACDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MACDest.Enabled = False
        Me.MACDest.Location = New System.Drawing.Point(102, 174)
        Me.MACDest.Name = "MACDest"
        Me.MACDest.Size = New System.Drawing.Size(161, 20)
        Me.MACDest.TabIndex = 38
        Me.MACDest.Tag = "macdest"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 232)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'GBInfo
        '
        Me.GBInfo.Controls.Add(Me.LBLinfo)
        Me.GBInfo.Location = New System.Drawing.Point(417, 67)
        Me.GBInfo.Name = "GBInfo"
        Me.GBInfo.Size = New System.Drawing.Size(171, 229)
        Me.GBInfo.TabIndex = 37
        Me.GBInfo.TabStop = False
        Me.GBInfo.Text = "Info"
        '
        'LBLinfo
        '
        Me.LBLinfo.Location = New System.Drawing.Point(6, 19)
        Me.LBLinfo.Name = "LBLinfo"
        Me.LBLinfo.Size = New System.Drawing.Size(159, 207)
        Me.LBLinfo.TabIndex = 0
        Me.LBLinfo.Text = "Info"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(380, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 28)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "For use with Whozz Calling? " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """full featured"" series units."
        '
        'cmPassword
        '
        Me.cmPassword.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPassword})
        Me.cmPassword.Name = "cmPassword"
        Me.cmPassword.Size = New System.Drawing.Size(161, 29)
        '
        'tsPassword
        '
        Me.tsPassword.Name = "tsPassword"
        Me.tsPassword.Size = New System.Drawing.Size(100, 23)
        Me.tsPassword.Text = "Password"
        '
        'tbLiteral
        '
        Me.tbLiteral.Location = New System.Drawing.Point(417, 37)
        Me.tbLiteral.Name = "tbLiteral"
        Me.tbLiteral.Size = New System.Drawing.Size(100, 20)
        Me.tbLiteral.TabIndex = 39
        Me.tbLiteral.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(292, 6)
        '
        'DisplayComputersIPAddressToolStripMenuItem
        '
        Me.DisplayComputersIPAddressToolStripMenuItem.Name = "DisplayComputersIPAddressToolStripMenuItem"
        Me.DisplayComputersIPAddressToolStripMenuItem.Size = New System.Drawing.Size(295, 22)
        Me.DisplayComputersIPAddressToolStripMenuItem.Text = "Display Computer's &IP Address"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 504)
        Me.Controls.Add(Me.tbLiteral)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GBInfo)
        Me.Controls.Add(Me.BTEthernetSend)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGVCallData)
        Me.Controls.Add(Me.BTNRefresh)
        Me.Controls.Add(Me.TBOutgoingMessage)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CBDetectedUnits)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(600, 460)
        Me.Name = "Form1"
        Me.Text = "Ethernet Link Config"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DGVCallData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GBInfo.ResumeLayout(False)
        Me.cmPassword.ResumeLayout(False)
        Me.cmPassword.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BTEthernetSend As System.Windows.Forms.Button
    Friend WithEvents TBOutgoingMessage As System.Windows.Forms.TextBox
    Friend WithEvents TSConnectedUnits As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CBDetectedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TBSN As System.Windows.Forms.TextBox
    Friend WithEvents TBUN As System.Windows.Forms.TextBox
    Friend WithEvents TBPort As System.Windows.Forms.TextBox
    Friend WithEvents BTNRefresh As System.Windows.Forms.Button
    Friend WithEvents DGVCallData As System.Windows.Forms.DataGridView
    Friend WithEvents BTNChangeUid As System.Windows.Forms.Button
    Friend WithEvents BTNChangeIpInt As System.Windows.Forms.Button
    Friend WithEvents BTNChangeMacInt As System.Windows.Forms.Button
    Friend WithEvents BTNChangePort As System.Windows.Forms.Button
    Friend WithEvents BTNChangeIpDest As System.Windows.Forms.Button
    Friend WithEvents BTNChangeMacDest As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVCSerialNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCUnitNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGVCData As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IPInternal As IPControlsClass.IPInput
    Friend WithEvents IPDest As IPControlsClass.IPInput
    Friend WithEvents MACInternal As IPControlsClass.MACInput
    Friend WithEvents MACDest As IPControlsClass.MACInput
    Friend WithEvents GBInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LBLinfo As System.Windows.Forms.Label
    Friend WithEvents TMIManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AutomaticSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetNetworkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetUnitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListeningPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSPort As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmPassword As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsPassword As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents UploadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveDataLocallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetUnitToCurrentTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetUnitLineCountTo1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbLiteral As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DisplayComputersIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
