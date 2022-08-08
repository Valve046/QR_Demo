Public Class Form1

    Private cisUSB As New USBClass

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLabel.KeyDown


    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        cisUSB.TextLabel = txtLabel.Text
        cisUSB.Printtest()

    End Sub
End Class
