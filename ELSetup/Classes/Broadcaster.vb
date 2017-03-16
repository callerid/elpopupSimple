' We didn't design this class at CallerID.Com, I found it somewhere on the internet.
' Works fine though.


Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Broadcaster
#Region "Delegates"
    Delegate Sub MessageSuccess()
    Delegate Sub MessageFailure()
#End Region

#Region "Private Fields"
    Private _NetIPAddress As String
    Private _Port As Int16
    Private _BroadcastMessage As String
    Private myClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    Private _Info As Byte()
    'Points to MessageSuccess()
    Public Event MessageSent As MessageSuccess
    'Points to MessageFailure
    Public Event MessageFailed As MessageFailure
#End Region

#Region "Properties"
    Public nListenPort As Integer = 3520
    Public Property NetIPAddress() As String
        Get
            Return _NetIPAddress
        End Get
        Set(ByVal Value As String)
            _NetIPAddress = Value
        End Set
    End Property

    Public Property Port() As Int16
        Get
            Return _Port
        End Get
        Set(ByVal Value As Int16)
            _Port = Value
        End Set
    End Property
    Public Property BroadcastMessage() As String
        Get
            Return _BroadcastMessage
        End Get
        Set(ByVal Value As String)
            _BroadcastMessage = Value
        End Set
    End Property
#End Region

#Region "Methods"
    'If this constructor is used, all you need to do is call SendMessage
    Public Sub New(ByVal IP_Address As String, ByVal PortNumber As Int16, ByVal Msg As String)
        Me.NetIPAddress = IP_Address
        Me.Port = PortNumber
        Me.BroadcastMessage = Msg
    End Sub
    'If this constructor is used, make sure you set the BroadcastMessage
    Public Sub New(ByVal IP_Address As String, ByVal PortNumber As Int16)
        Me.NetIPAddress = IP_Address
        Me.Port = PortNumber
    End Sub

    Public Sub SendMessage()
        'To make this more robust, I should probably check
        'that there is in fact a message and respond accordingly..
        'but it's Sunday night so forgive me.

        myClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        myClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
        Dim mc2EndPoint As New IPEndPoint(IPAddress.Any, nListenPort)
        myClient.Bind(mc2EndPoint)

        _Info = System.Text.Encoding.UTF8.GetBytes(Me.BroadcastMessage)
        Dim EndPoint As New IPEndPoint(IPAddress.Parse(Me.NetIPAddress), Me.Port)
        Dim rcEndPoint As New IPEndPoint(IPAddress.Parse("255.255.255.255"), nListenPort)
        Try
            Debug.Write(Me.BroadcastMessage)
            myClient.SendTo(Me._Info, Me._Info.Length, System.Net.Sockets.SocketFlags.None, EndPoint)
            'Use a Success Event and raise it if things worked
            RaiseEvent MessageFailed()
        Catch ex As System.Net.Sockets.SocketException
            'Instead of using a return type, why not just create
            'a Failed Event?
            RaiseEvent MessageSent()
        End Try
        'Try
        'bytes = myClient.Receive(rcEndPoint)
        'sReceivedMessage = Encoding.Default.GetString(bytes)

        ' Dim ELink As New EthernetLinkDevice
        '  ELink.ImportData(sReceivedMessage)


        '   Form1.setTextBox(ELink)

        'Catch ex As Exception

        'End Try

        myClient.Close()
        'myclient2.Close()
    End Sub
#End Region
End Class


Public Class UdpReceiverClass
    Public sReceivedMessage As String
    Public bPause As Boolean = False
    Public Event DataReceived()
    Public nListenPort As Integer = 3520

    Sub UdpIdleReceive()

        Dim done As Boolean = False
        Dim udpClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim intEndPoint As New IPEndPoint(IPAddress.Any, nListenPort)
        'MsgBox(intEndPoint.Address.ToString)
        udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)

        udpClient.EnableBroadcast = True
        'udpClient.MulticastLoopback = False
        'MsgBox("Unable to bind to port " + nListenPort + ". Another application might be using this port already.", MsgBoxStyle.Information, Left(ex.ToString, 60) + "...")


        'Try
        udpClient.Bind(intEndPoint)
        'udpClient.Blocking = False
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'Exit Sub
        'End Try
        sReceivedMessage = ""

        While Not done

            Dim receiveBytes(8100) As [Byte]
            Dim nByteCount As Integer

            nByteCount = udpClient.ReceiveFrom(receiveBytes, 0, 200, SocketFlags.None, intEndPoint)
            Try
                sReceivedMessage = Encoding.UTF7.GetString(receiveBytes, 0, nByteCount)
            Catch ex As Exception
            End Try

            If nByteCount > 20 Then
                RaiseEvent DataReceived()
            End If

        End While
    End Sub

End Class

