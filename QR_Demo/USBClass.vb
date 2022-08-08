Imports SATOPrinterAPI
Public Class USBClass

    Private txtUSB As String
    Public SATOPrinter As Printer = New Printer()
    Private sTextLabel As String
    Private Const C_POINT_V As Integer = 0
    Private Const C_POINT_H As Integer = 0

    Public Property TextLabel() As String
        Get
            TextLabel = sTextLabel
        End Get
        Set(ByVal Value As String)
            sTextLabel = Value
        End Set
    End Property
    Public Function Printtest() As Boolean


        Dim USBPorts As Generic.List(Of Printer.USBInfo) = SATOPrinter.GetUSBList()

        For Each item In USBPorts
            txtUSB = item.PortID
        Next

        testprint()
    End Function
    Private Sub testprint()

        Dim sEditWK As String

        sEditWK = Chr(&H2)

        sEditWK = sEditWK & Chr(&H1B) & "A"

        'Label 
        sEditWK = sEditWK & Chr(&H1B) & "H" & CStr(C_POINT_H + 70)
        sEditWK = sEditWK & Chr(&H1B) & "V" & CStr(C_POINT_V + 1490)
        sEditWK = sEditWK & Chr(&H1B) & "%1"
        sEditWK = sEditWK & Chr(&H1B) & "L0202"
        sEditWK = sEditWK & Chr(&H1B) & "S" & "Label Text"

        'Text Label
        sEditWK = sEditWK & Chr(&H1B) & "H" & CStr(C_POINT_H + 55)
        sEditWK = sEditWK & Chr(&H1B) & "V" & CStr(C_POINT_V + 1140)
        sEditWK = sEditWK & Chr(&H1B) & "%1"
        sEditWK = sEditWK & Chr(&H1B) & "P2"
        sEditWK = sEditWK & Chr(&H1B) & "$B,50,60,0"
        sEditWK = sEditWK & Chr(&H1B) & "$=" & TextLabel

        sEditWK = sEditWK & Chr(&H1B) & "Z"

        sEditWK = sEditWK & Chr(&H3)

        '  Try
        Dim LPTPorts As Generic.List(Of String) = SATOPrinter.GetLPTList()
        SATOPrinter.Interface = Printer.InterfaceType.USB
        SATOPrinter.USBPortID = txtUSB
        Dim cmddata1 As Byte() = Utils.StringToByteArray(sEditWK)
        SATOPrinter.Timeout = 10000
        SATOPrinter.Send(cmddata1)

    End Sub

End Class
