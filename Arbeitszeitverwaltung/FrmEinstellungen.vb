Public Class FrmEinstellungen
    Private Sub FrmEinstellungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBgeplStd.Text = Format(My.Settings.geplStunden, "#0.0")
        TBStdLohn.Text = Format(My.Settings.stdLohn, "#0.00")
    End Sub

    Private Sub BtnAbbrechen_Click(sender As Object, e As EventArgs) Handles BtnAbbrechen.Click
        Me.Close()
    End Sub

    Private Sub BtnSpeichern_Click(sender As Object, e As EventArgs) Handles BtnSpeichern.Click
        My.Settings.geplStunden = TBgeplStd.Text
        My.Settings.stdLohn = TBStdLohn.Text
        Form1.AktualisiereAbbrechnung()
        Me.Close()
    End Sub
End Class