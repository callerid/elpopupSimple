Imports System.Deployment.Application
Imports System.Diagnostics
Imports Microsoft.Build.Utilities
Imports System.Threading
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml

Public Class Form1
#Region "Dimensions"
    Private Broadcast As Broadcaster
    Private WithEvents UdpReceiver As New UdpReceiverClass
    Private UdpReceiveThread As New System.Threading.Thread(AddressOf UdpReceiver.UdpIdleReceive)
    Private myThread As New System.Threading.Thread(AddressOf EthernetLinkPing)
    Private LEthernetLink As New List(Of EthernetLinkDevice)
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public nListeningPort As Integer = My.Settings.ListenPort
    Private stNetworkInfo As String
    Private chkMutex As New myMutex
    Private devMode As Boolean = False
#End Region

#Region "Delegates"
    Delegate Sub setTextBox_Delegate(ByVal ELink As EthernetLinkDevice)
    Delegate Sub IncomingData_Delegate(ByVal [text] As String)
    Delegate Sub RunSub_Delegate() 'use to delegate a sub without passing anything
    Delegate Sub AddCBItem_Delegate(ByVal [text] As String)
#End Region

#Region "Events"

    Class myMutex
        Private oMutex As Mutex
        Public Function IdentafoneInstanceRunning(ByVal UserContex As Boolean) As Boolean
            'change the id for every app you deploy ( tools ,create guid )
            Dim progid As String = "MutTracs"
            oMutex = New Mutex(False, String.Concat(progid, CStr(IIf(UserContex, System.Environment.UserName, ""))))
            If oMutex.WaitOne(0, False) = False Then
                oMutex.Close()
                Return True
                End
            End If
            oMutex.Close()
        End Function

        Public Function InstanceRunning(ByVal UserContex As Boolean) As Boolean
            'change the id for every app you deploy ( tools ,create guid )
            Dim progid As String = "MutELConfig"
            oMutex = New Mutex(False, String.Concat(progid, CStr(IIf(UserContex, System.Environment.UserName, ""))))
            If oMutex.WaitOne(0, False) = False Then
                oMutex.Close()
                Return True
                End
            End If

        End Function
    End Class

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim chkMutex As myMutex = New myMutex
        'Check for FoneTracs, AKA "SmartCall"
        While chkMutex.IdentafoneInstanceRunning(False)
            Dim msgResult As MsgBoxResult
            msgResult = MsgBox("SmartCall must be closed" + vbCr + vbCr + "ABORT will cancel ELConfig" + vbCr + vbCr + "RETRY will attempt to start ELConfig again. Close SmartCall before selecting this option." + vbCr + vbCr + "IGNORE will run ELConfig even if SmartCall is still running. This may cause connection problems.", MsgBoxStyle.AbortRetryIgnore, "SmartCall is running")
            If msgResult = MsgBoxResult.Abort Then Me.Close() : Exit Sub
            If msgResult = MsgBoxResult.Ignore Then Exit While
        End While
        If chkMutex.InstanceRunning(False) Then
            Me.Close()
            Exit Sub
        End If

        Dim procList() As Process = Process.GetProcessesByName("elpopup")
        If procList.Length > 0 Then
            Dim strProcName As String = procList(0).ProcessName
            Dim iProcID As Integer = procList(0).Id
            If My.Computer.FileSystem.FileExists(procList(0).MainModule.FileName) Then
                Dim processProperties As New ProcessStartInfo
                processProperties.FileName = procList(0).MainModule.FileName
                processProperties.Arguments = "-pause"
                Dim myProcess As Process = Process.Start(processProperties)
            End If
        End If

        For Each arg As String In Environment.GetCommandLineArgs()
            'ApplicationEvents.vb responds to arguments that occur after the program is already loaded.
            If arg = "-devmode" Then
                devMode = True
                BTNChangeMacInt.Enabled = True
                BTNChangeMacInt.Text = "Change"
                tbLiteral.Visible = True
            End If
        Next

        UdpReceiveThread.IsBackground = True
        UdpReceiver.nListenPort = nListeningPort
        UdpReceiveThread.Start()
        infoBox() 'Clear the info text box
        TSPort.Text = nListeningPort.ToString

        Dim mc As New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim nics As System.Management.ManagementObjectCollection
        nics = mc.GetInstances
        For Each nic In nics
            If nic("ipEnabled") = True Then
                Dim stSub, stIP, stInfo As String
                stSub = nic("IPSubnet")(0)
                stIP = nic("IPAddress")(0)
                stInfo = String.Format("{2}" + vbCrLf + "  Your IP is {0}." + vbCrLf + "  Your Subnet mask is {1}", stIP, stSub, nic("Caption").ToString.Substring(11))
                stNetworkInfo += stInfo + vbCrLf + vbCrLf
            End If
        Next
        RefreshData()
        'EthernetLinkPing()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If chkMutex.InstanceRunning(False) Then
            Exit Sub 'Only resume ELPopup when this is the last instance closing.
        End If
        Dim procList() As Process = Process.GetProcessesByName("elpopup")
        If procList.Length > 0 Then
            Dim strProcName As String = procList(0).ProcessName
            Dim iProcID As Integer = procList(0).Id
            If My.Computer.FileSystem.FileExists(procList(0).MainModule.FileName) Then
                Dim processProperties As New ProcessStartInfo
                processProperties.FileName = procList(0).MainModule.FileName
                processProperties.Arguments = "-resume"
                Dim myProcess As Process = Process.Start(processProperties)
            End If
        End If
    End Sub


    Private Sub DataReceivedEventHandler() Handles UdpReceiver.DataReceived
        Dim sReceivedText As String
        sReceivedText = UdpReceiver.sReceivedMessage

        If InStr(sReceivedText, "IdX") > 1 Then ' don't accept ^^IdX echos
        ElseIf sReceivedText.Length = 90 Then 'only setup information totals exactly 90 chars
            Dim ELink As New EthernetLinkDevice
            ELink.ImportData(sReceivedText)

            'Add new setup information to list
            Dim FMcount As Integer = -1
            Dim ii As Integer = 0
            'check to see if a copy already exists
            If LEthernetLink.Count > 0 Then ' make sure we have something to compare it to.
                For Each ELSerial As EthernetLinkDevice In LEthernetLink
                    If ELSerial.Serial = ELink.Serial Then
                        FMcount = ii
                    End If
                    ii += 1
                Next
            End If
            'if not, add it.
            If FMcount = -1 Then
                LEthernetLink.Add(ELink)
                If CBDetectedUnits.InvokeRequired Then
                    Dim d As New AddCBItem_Delegate(AddressOf AddCBItem)
                    Me.Invoke(d, New Object() {ELink.Serial})
                Else
                    AddCBItem(ELink.Serial) ' Add ethernet link's seral number to list.
                End If
            Else
                'if it already exists, update it in case it changed.
                LEthernetLink(FMcount) = ELink
            End If
        Else

            AddPacketLine(sReceivedText)

        End If
        sReceivedText = sReceivedText.Replace(vbCr, "?")
        sReceivedText = sReceivedText.Replace(Chr(0), "?")
        Debug.WriteLine(sReceivedText)
    End Sub

    Private Sub CBDetectedUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBDetectedUnits.SelectedIndexChanged
        setTextBox(LEthernetLink(sender.SelectedIndex))
    End Sub

#End Region

#Region "ButtonClicks"
    Private Sub BTEthernetSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTEthernetSend.Click
        Dim suffix As String = ""
        If TBOutgoingMessage.Text.Length > 0 Then
            If TBOutgoingMessage.Text.Substring(0, 1) = "N" Or TBOutgoingMessage.Text.Substring(0, 1) = "Z" Then
                suffix = vbCrLf
            End If
            BrandValue("^^Id-" + TBOutgoingMessage.Text.Replace("§", vbCr) + suffix)
        End If
    End Sub

    Private Sub BTGenerateCID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TBOutgoingMessage.Text = CIDFunctions.FakeRecordGenerator

    End Sub

    Private Sub BTNRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRefresh.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        LEthernetLink.Clear()
        CBDetectedUnits.Items.Clear()
        TSConnectedUnits.Text = "Refreshing..."
        TBPort.Text = "????"
        TBSN.Text = "????????????"
        TBUN.Text = "????????????"
        IPDest.Text = "?.?.?.?"
        IPInternal.Text = "?.?.?.?"
        MACDest.Text = "??-??-??-??-??-??"
        MACInternal.Text = "??-??-??-??-??-??"
        Unlock_textbox(Nothing)

        Me.Update()
        Sleep(300)
        EthernetLinkPing()
    End Sub

    Private Sub BTNChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeUid.Click, BTNChangeIpDest.Click, BTNChangeIpInt.Click, BTNChangeMacDest.Click, BTNChangeMacInt.Click, BTNChangePort.Click

        If sender.Text = "Change" Then
            Unlock_textbox(sender)
        ElseIf sender.text = "Update" Then
            update_ELDevice(sender)
        ElseIf sender.text = "Locked" Then
            cmPassword.Show(MousePosition.X, MousePosition.Y)
        End If

    End Sub

    Private Sub BTNChange_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNChangeUid.MouseEnter, BTNChangeIpDest.MouseEnter, BTNChangeIpInt.MouseEnter, BTNChangeMacDest.MouseEnter, BTNChangeMacInt.MouseEnter, BTNChangePort.MouseEnter, _
    MACDest.MouseEnter, MACInternal.MouseEnter, IPDest.MouseEnter, IPInternal.MouseEnter, TBPort.MouseEnter, TBUN.MouseEnter, TBSN.MouseEnter, TSConnectedUnits.MouseEnter, CBDetectedUnits.MouseEnter, ResetNetworkToolStripMenuItem.MouseEnter, ResetUnitToolStripMenuItem.MouseEnter
        Select Case sender.Tag
            Case "ipdest"
                infoBox("Destination IP", "This is the address of the device that the Whozz Calling? will send data to." + vbCrLf + vbCrLf + "255.255.255.255 is a universal address that applies to every computer on the network.")
            Case "ipint"
                infoBox("Internal IP", "This is the address of the Whozz Calling? device itself." + vbCrLf + vbCrLf + "it is sometimes necessary for this address to be on the same subnet as the rest of your network.")
            Case "macdest"
                infoBox("Destination MAC", "This is the physical address of the device that the Whozz Calling? will send data to." + vbCrLf + vbCrLf + "FF-FF-FF-FF-FF-FF is a universal address that works when the physical address is unknown or not applicable.")
            Case "macint"
                infoBox("Internal MAC", "This is the physical address of the Whozz Calling? device itself." + vbCrLf + vbCrLf + "This should not be changed under normal conditions. If it must be changed, make certain the first digit remains '06' so that managed network switches will route the data correctly")
            Case "uid"
                infoBox("Unit ID Number", "The Unit Number helps differentiate between multiple units on the same network." + vbCrLf + vbCrLf + "ELPopup ignores this value, but it may be required for other third party applications.")
            Case "sn"
                infoBox("Serial Number", "The Serial Number is unique to each unit, and broadcasted with every unit packet. It cannot be changed.")
            Case "port"
                infoBox("Port", "This is the port number on which the Whozz Calling? sends data on." + vbCrLf + vbCrLf + "Warning: Changing the port will interrupt communication with the Ethernet Link device. Only change the port if it is necessary to do so." + vbCrLf + vbCrLf + "To change this program's listening port, select Configure > Listening Port, then change the port number.")
            Case "reseteth"
                infoBox("Network Reset", "Loads all the network defaults into the Whozz Calling? except MAC address and Serial Number.")
            Case "resetunit"
                infoBox("Unit Reset", "Loads non-network defaults into Whozz Calling? Full Featured units.")
            Case Else
                If CBDetectedUnits.Items.Count > 1 Then
                    infoBox("", "More than one Ethernet Link device has been detected. Any changes here will affect both devices at the same time. To set up only one device, disconnect all other devices first.")
                Else
                    infoBox()
                End If
        End Select
    End Sub

#End Region

#Region "ToolStrip Items"

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

#End Region

#Region "Subs"
    Public Overloads Sub infoBox(ByVal title As String, Optional ByVal info As String = "")
        If title.Length > 0 Then GBInfo.Text = "Info" + " (" + title + ")" Else GBInfo.Text = "Info"
        LBLinfo.Text = info
    End Sub
    Public Overloads Sub infoBox()
        If devMode Then
            infoBox("Dev Mode", "Dev mode active. Pressing ""Enter"" will send the above text ""^^Id{TEXT}"" as a broadcast packet")
        Else
            infoBox("", "")
        End If
    End Sub

    Public Sub AddCBItem(ByVal text As String)
        CBDetectedUnits.Items.Add(text)
        CBDetectedUnits.SelectedIndex = CBDetectedUnits.Items.Count - 1
        Select Case CBDetectedUnits.Items.Count
            Case 0
                TSConnectedUnits.Text = "No Units Detected"
            Case 1
                TSConnectedUnits.Text = "1 Unit Detected"
            Case Else
                TSConnectedUnits.Text = CBDetectedUnits.Items.Count.ToString + " Units Detected"
        End Select

    End Sub

    Public Sub setTextBox(ByVal eldFound As EthernetLinkDevice) ' populates the form with Ethernet Link data
        If TBSN.InvokeRequired Then
            Dim d As New setTextBox_Delegate(AddressOf setTextBox)
            Me.Invoke(d, New Object() {eldFound})
        Else
            Dim tmpSN As String = eldFound.Serial
            TBSN.Text = tmpSN.Substring(0, 2) + "-" + tmpSN.Substring(2, 2) + "-" + tmpSN.Substring(4, 6) + "-" + tmpSN.Substring(10)
            TBUN.Text = eldFound.UnitID
            TBPort.Text = eldFound.DestPort
            IPInternal.Text = eldFound.IntIP
            IPDest.Text = eldFound.DestIP
            MACInternal.Text = eldFound.IntMac
            MACDest.Text = eldFound.DestMac
            If (Val(MACInternal.Text.Substring(0, 2)) Mod 2) = 1 Then 'If the MAC address is bugged, allow it to be changed
                BTNChangeMacInt.Text = "Change"
                BTNChangeMacInt.Enabled = True
            End If
        End If

    End Sub

    Public Sub AddPacketLine(ByVal textString As String)
        If DGVCallData.InvokeRequired Then
            Dim d As New IncomingData_Delegate(AddressOf AddPacketLine)
            Me.Invoke(d, New Object() {textString})
        Else
            Dim uid As String
            Dim sn As String
            uid = textString.Substring(5, 6)
            sn = textString.Substring(14, 6)
            uid = CIDFunctions.UID_Decoder(uid)
            sn = CIDFunctions.UID_Decoder(sn)

            textString = textString.Replace(vbCr, "")
            textString = textString.Replace(vbLf, "")

            textString = textString.Replace(Chr(0), "?")
            DGVCallData.Rows.Add(sn, uid, textString.Substring(21))

            DGVCallData.FirstDisplayedCell() = DGVCallData.Item(0, DGVCallData.RowCount - 1)
        End If
    End Sub

    Private Sub EthernetLinkPing() ' search for Ethernet link via the ethernet.
        TSConnectedUnits.Text = "No units detected"
        BrandValue("^^IdX")
    End Sub


    Private Sub BrandValue(ByVal sValue As String)
        Debug.WriteLine(sValue)
        If sValue.Length = 0 Then Exit Sub
        If InStr(sValue, "?") > 0 And InStr(sValue, "Id-") = 0 Then Exit Sub
        Dim brBroadcast As New Broadcaster("255.255.255.255", nListeningPort, sValue)
        brBroadcast.nListenPort = nListeningPort
        brBroadcast.SendMessage()
    End Sub

    Private Overloads Sub Unlock_textbox(ByVal null As Nullable)
        IPDest.Enabled = False
        IPInternal.Enabled = False
        MACDest.Enabled = False
        MACInternal.Enabled = False
        TBPort.ReadOnly = True
        TBUN.ReadOnly = True
        Dim btnChangeText As String = "Change"
        BTNChangeIpDest.Text = btnChangeText
        BTNChangeIpInt.Text = btnChangeText
        BTNChangeMacDest.Text = btnChangeText
        'BTNChangeMacInt.Text = btnChangeText 'This one is special. It should remain locked.
        BTNChangePort.Text = btnChangeText
        BTNChangeUid.Text = btnChangeText
    End Sub


    Private Overloads Sub Unlock_textbox(ByVal Button As Object)
        Select Case Button.name
            Case "BTNChangeIpDest"
                IPDest.Enabled = True
            Case "BTNChangeIpInt"
                IPInternal.Enabled = True
            Case "BTNChangeMacDest"
                MACDest.Enabled = True
            Case "BTNChangeMacInt"
                MACInternal.Enabled = True
            Case "BTNChangePort"
                TBPort.ReadOnly = False
            Case "BTNChangeUid"
                TBUN.ReadOnly = False
        End Select
        Button.text = "Update"
    End Sub


    Private Sub update_ELDevice(ByVal Button As Object)
        Select Case Button.name
            Case "BTNChangeIpDest"
                BrandValue("^^IdD" + IPDest.HexIP)
                IPDest.Enabled = False
            Case "BTNChangeIpInt"
                BrandValue("^^IdI" + IPInternal.HexIP)
                IPInternal.Enabled = False
            Case "BTNChangeMacDest"
                BrandValue("^^IdC" + MACDest.Text.Replace("-", ""))
                MACDest.Enabled = False
            Case "BTNChangeMacInt"
                BrandValue("^^IdM" + MACInternal.Text.Replace("-", ""))
                MACInternal.Enabled = False
            Case "BTNChangePort"
                BrandValue("^^IdT" + Hex(Val(TBPort.Text)).PadLeft(4, "0"))
                TBPort.ReadOnly = True
                LBLinfo.Text = ""
            Case "BTNChangeUid"
                BrandValue("^^IdU" + TBUN.Text.PadLeft(12, "0"))
                TBUN.ReadOnly = True
        End Select
        Button.text = "Change"
    End Sub

#End Region

    Private Sub TMIManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMIManual.Click
        Help.ShowHelp(Me, Application.StartupPath & "\ELConfig Manual.chm")
    End Sub

    Private Sub TSPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then ChangedPort()
    End Sub

    Private Sub ChangedPort() Handles TSPort.LostFocus
        AutomaticSetupToolStripMenuItem.HideDropDown()



        If Val(TSPort.Text) = 0 Or Val(TSPort.Text) > 65565 Then
            MsgBox("Port value must be a whole number between 0 and 65565.")
            ' ElseIf Val(TBPort.Text) = nListeningPort Then
        ElseIf Val(TSPort.Text = nListeningPort) Then
        Else
            Dim nOldPort As Integer = nListeningPort
            My.Settings.ListenPort = Val(TSPort.Text)
            nListeningPort = Val(TSPort.Text)
            Dim msResult As MsgBoxResult = MsgBox("Changing the port requires the program to restart. Restart now?", MsgBoxStyle.YesNo, "Restart Required")
            If msResult = MsgBoxResult.Yes Then
                Application.Restart()
            Else
                MsgBox("This program will use port " + TSPort.Text + " the next time it runs, but will continue to listen on port " + nOldPort.ToString + " for now")
            End If

        End If
    End Sub


    Private Sub ResetUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetUnitToolStripMenuItem.Click
        BrandValue("^^Id-N0000007701")
        Sleep(100)
        BrandValue("^^Id-R")
        'Dim CharStream As String = "ECXUdASobKT"
        'While CharStream.Length > 0
        ' BrandValue("^^Id-" + CharStream.Substring(0, 1))
        ' If CharStream.Length > 0 Then CharStream = CharStream.Substring(1) Else CharStream = ""
        ' Sleep(100)
        'End While
    End Sub

    Private Sub ChangedPort(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPort.LostFocus

    End Sub

    Private Sub DisplayComputersIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayComputersIPAddressToolStripMenuItem.Click
        MsgBox(stNetworkInfo)
    End Sub

    Private Sub ResetNetworkToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetNetworkToolStripMenuItem.Click
        'BrandValue("")
        BrandValue("^^IdDFFFFFFFF") 'External IP
        Sleep(400)
        BrandValue("^^IdU000000000001") 'Unit ID
        Sleep(400)
        BrandValue("^^IdIC0A8005A") 'Internal IP
        Sleep(400)
        BrandValue("^^IdCFFFFFFFFFFFF") ' Destination MAC address
        'Sleep(400)
        'BrandValue("^^IdM0620101332CC") 'Internal MAC address
        Sleep(400)
        BrandValue("^^IdT0DC0") 'Port Number
        Sleep(400)
        'BrandValue("^^Id-R")
    End Sub

    Private Sub tsPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsPassword.KeyUp
        If tsPassword.Text.Length >= 8 Then
            If tsPassword.Text.ToLower.Substring(0, 8) = "callerid" Then 'Super secret password on an open source project. Keep it between us programers. Don't tell the 'normals'. Or do. Whatever.
                cmPassword.Hide()
                BTNChangeMacInt.Enabled = True
                BTNChangeMacInt.Text = "Change"
                BTNChange_Click(BTNChangeMacInt, Nothing)
            End If
        End If
    End Sub

    Private Sub DGVCallData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGVCallData.KeyDown
        Dim activeRows = DGVCallData.SelectedRows
        My.Computer.Clipboard.SetText(activeRows.Item(0).Cells(2).ToString())
    End Sub


    Private Sub Upload_Debug_Data(Optional ByVal save As Boolean = False)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim address As Uri
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing

        address = New Uri("http://pastebin.com/api/api_post.php")

        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)

        ' Set type to POST  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Generate XML
        Dim settings As New XmlWriterSettings
        settings.Indent = True
        settings.IndentChars = "  "
        settings.NewLineOnAttributes = True
        Dim rows As DataGridViewRowCollection = DGVCallData.Rows
        Dim memStream As MemoryStream = New MemoryStream()
        Dim writer As XmlWriter = XmlWriter.Create(memStream, settings)
        writer.WriteStartDocument()
        writer.WriteStartElement("ELConfig")
        writer.WriteElementString("Time_Recorded", DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt"))
        writer.WriteElementString("PC_Name", My.Computer.Name)
        writer.WriteElementString("User", My.User.Name)
        writer.WriteElementString("Operating_System", My.Computer.Info.OSFullName)
        writer.WriteElementString("Ethernet_Links_Detected", LEthernetLink.Count.ToString)


        For Each eth As EthernetLinkDevice In LEthernetLink
            writer.WriteStartElement("Ethernet_Link")
            writer.WriteElementString("Serial_Number", eth.Serial)
            writer.WriteElementString("Unit_ID", eth.UnitID)
            writer.WriteElementString("Destination_IP", eth.DestIP)
            writer.WriteElementString("Destination_MAC", eth.DestMac)
            writer.WriteElementString("Destination_Port", eth.DestPort)
            writer.WriteElementString("Internal_IP", eth.IntIP)
            writer.WriteElementString("Internal_MAC", eth.IntMac)
            writer.WriteElementString("Internal_Port", eth.IntPort)
            writer.WriteEndElement()
        Next

        writer.WriteStartElement("Output")
        For Each row As DataGridViewRow In rows
            writer.WriteStartElement("Incoming_Data")
            writer.WriteAttributeString("serial", row.Cells.Item(0).Value)
            writer.WriteString(row.Cells.Item(2).Value)
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()

        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Flush()
        writer.Close()

        reader = New StreamReader(memStream)
        memStream.Position = 0
        Dim xmlString As String = reader.ReadToEnd
        If save Then
            Dim saveFile As SaveFileDialog = New SaveFileDialog
            saveFile.CreatePrompt = True
            saveFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            saveFile.FileName = "ELConfig_Debug"
            saveFile.Filter = "XML (*.xml) | *.xml| (*.txt) |*.txt"
            If saveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim outfile As New StreamWriter(saveFile.FileName)
                outfile.Write(xmlString)
                outfile.Flush()
                outfile.Close()
            End If

        End If

        If Not save Then
            ' Create the data we want to send  
            data = New StringBuilder()
            data.Append("api_option=" + HttpUtility.UrlEncode("paste"))
            data.Append("&api_dev_key=" + HttpUtility.UrlEncode("c0f83a93e6f40b94afe5eed045a0b0e7"))
            data.Append("&api_user_key=" + HttpUtility.UrlEncode("b8e36fab93a87994d81b674b6d772cd3"))
            data.Append("&api_paste_code=" + HttpUtility.UrlEncode(xmlString))
            data.Append("&api_paste_name=" + HttpUtility.UrlEncode("EC-" + My.Computer.Name))
            data.Append("&api_paste_expire_date=" + HttpUtility.UrlEncode("1H"))
            data.Append("&api_paste_private=" + HttpUtility.UrlEncode("1"))
            data.Append("&api_paste_format=" + HttpUtility.UrlEncode("xml"))

            ' Create a byte array of the data we want to send  
            byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

            ' Set the content length in the request headers  
            request.ContentLength = byteData.Length

            ' Write data  
            Try
                postStream = request.GetRequestStream()
                postStream.Write(byteData, 0, byteData.Length)
            Finally
                If Not postStream Is Nothing Then postStream.Close()
            End Try

            Try
                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())

                ' Console application output  
                MsgBox("Data has been sent to CallerID.com via " + reader.ReadToEnd + " and will be avaliable for 1 hour." + vbCrLf + "Contact CallerID.com Tech Support at 800.240.4637.", MsgBoxStyle.Information, "Uploaded")
                'Console.WriteLine(reader.ReadToEnd())
            Finally
                If Not response Is Nothing Then response.Close()
            End Try
        End If
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadDataToolStripMenuItem.Click
        Upload_Debug_Data()
    End Sub

    Private Sub SaveDataLocallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataLocallyToolStripMenuItem.Click
        Upload_Debug_Data(True)
    End Sub

    Private Sub SetUnitToCurrentTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetUnitToCurrentTimeToolStripMenuItem.Click
        BrandValue("^^Id-N0000007701")
        Sleep(100)
        Dim t As Date = Now
        Dim timeString As String
        timeString = t.Month.ToString.PadLeft(2, "0") + t.Day.ToString.PadLeft(2, "0") + t.Hour.ToString.PadLeft(2, "0") + t.Minute.ToString.PadLeft(2, "0")
        timeString = "Z" + timeString + vbCr
        BrandValue(timeString)
        Me.Focus()
        BrandValue("^^Id-V")

    End Sub

    Private Sub SetUnitLineCountTo1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetUnitLineCountTo1ToolStripMenuItem.Click
        BrandValue("^^Id-N0000007701")
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub tbLiteral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbLiteral.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BrandValue("^^Id" + tbLiteral.Text)
            e.Handled = True
        End If

    End Sub

End Class

