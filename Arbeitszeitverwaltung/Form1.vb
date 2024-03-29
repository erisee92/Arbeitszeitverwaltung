﻿Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Public Class Form1

    Friend dbDateiPfad As String
    Private ds As New DataSet

    'Neuer Eintrag oder bearbeiten
    Friend neuerEintrag As Boolean = True

    ' Variablen für den Druck
    Private startZeile As Integer = 0
    Private neueSeite As Boolean = True
    Private seitenNummer As Integer = 1
    Private ueStunden As Boolean = False

    Private monatssumme As TimeSpan = TimeSpan.Zero

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        SaveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

        If My.Settings.letzteDB <> "" Then
            dbDateiPfad = My.Settings.letzteDB
            BtnAdd.Enabled = True
            BtnDruck.Enabled = True
            CBJahr.Enabled = True
            CBMonat.Enabled = True
        End If

        CBMonat.SelectedIndex = Date.Today.Month - 1
        For i = Date.Today.Year - 10 To Date.Today.Year
            CBJahr.Items.Add(i)
        Next
        CBJahr.SelectedIndex = 10

    End Sub

#Region "Datei öffnen/Schließen"
    Private Sub DatenbankÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatenbankÖffnenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        dbDateiPfad = OpenFileDialog1.FileName
        My.Settings.letzteDB = dbDateiPfad
        TabelleEinlesen()
        AktualisiereAbrechnung()
        BtnAdd.Enabled = True
        BtnDruck.Enabled = True
        CBJahr.Enabled = True
        CBMonat.Enabled = True
    End Sub

    Private Sub NeueDatenbankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueDatenbankToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk

        Dim alteDatei As Boolean = False
        If File.Exists(SaveFileDialog1.FileName) Then
            alteDatei = True
        End If

        Using con As New SQLiteConnection()
            Dim cmd As SQLiteCommand

            con.ConnectionString = "Data Source=" & SaveFileDialog1.FileName & ";"
            cmd = con.CreateCommand()

            Try
                con.Open()

                If alteDatei = True Then
                    cmd.CommandText = "DROP TABLE Strassen;"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "DROP TABLE Zeiten;"
                    cmd.ExecuteNonQuery()
                End If

                cmd.CommandText = "CREATE TABLE Strassen (SId INTEGER PRIMARY KEY AUTOINCREMENT, Strasse TEXT NOT NULL)"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "CREATE TABLE Zeiten (
	                                ZId	INTEGER PRIMARY KEY AUTOINCREMENT,
	                                datum	TEXT NOT NULL,
	                                fkStrasse	INTEGER NOT NULL,
	                                startzeit	TEXT,
	                                endzeit	TEXT,
                                    FOREIGN KEY(fkStrasse) REFERENCES Strassen(SId)
                                );"

                cmd.ExecuteNonQuery()

                con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Exit Sub
            End Try

        End Using

        My.Settings.letzteDB = SaveFileDialog1.FileName
        dbDateiPfad = SaveFileDialog1.FileName
        TabelleEinlesen()
        AktualisiereAbrechnung()
        BtnAdd.Enabled = True
        BtnDruck.Enabled = True
        CBJahr.Enabled = True
        CBMonat.Enabled = True

        MessageBox.Show("Datenbank gespeichert", "Speichern Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region 'Datei öffnen/Schließen

#Region "Toolstrip"
    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        My.Settings.Reset()
        DataGridView1.Rows.Clear()
        monatssumme = TimeSpan.Zero
        BtnAdd.Enabled = False
        BtnDruck.Enabled = False
        CBJahr.Enabled = False
        CBMonat.Enabled = False
        AktualisiereAbrechnung()

    End Sub

    Private Sub BearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BearbeitenToolStripMenuItem.Click
        FrmEinstellungen.Show()
    End Sub

#End Region 'Toolstrip

#Region "druck"
    Private Sub BtnDruck_Click(sender As Object, e As EventArgs) Handles BtnDruck.Click

        startZeile = 0
        neueSeite = True
        seitenNummer = 1
        ueStunden = False

        If MessageBox.Show("Drucke mit Überstunden?", "Druckausgabe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ueStunden = True
        End If

        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(20, 20, 20, 20)
        startZeile = 0
        neueSeite = True
    End Sub

    ' https://stackoverflow.com/questions/41015287/how-to-print-datagridview-table-with-its-header-in-vb-net
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' Langen Text mit ... abschneiden
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter

        Dim y As Integer = e.MarginBounds.Top
        Dim rc As Rectangle
        Dim x As Integer
        Dim h As Integer = 0
        Dim row As DataGridViewRow

        ' Drucke Überschrift
        Dim Schrift As New Font(FontFamily.GenericSansSerif, 14.0)
        x = e.MarginBounds.Left

        rc = New Rectangle(x, y, PrintDocument1.DefaultPageSettings.PrintableArea.Width, 25)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(My.Settings.mitarbeiter & ", " & CBMonat.SelectedItem & " " & CBJahr.SelectedItem, Schrift, Brushes.Black, rc, sf)

        y += 36

        '   Drucke Header
        If neueSeite Then
            row = DataGridView1.Rows(startZeile)
            x = e.MarginBounds.Left
            For Each cell As DataGridViewCell In row.Cells
                ' Überspringe ID Spalte
                If cell.Visible Then

                    rc = New Rectangle(x, y, cell.Size.Width + 10, cell.Size.Height)

                    Using br As New SolidBrush(Color.FromArgb(&HFF0069C0))
                        e.Graphics.FillRectangle(br, rc)
                    End Using

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, DataGridView1.Font, Brushes.White, rc, sf)
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If
            Next

            If seitenNummer = 1 Then
                ' Lohnrechnung
                x += 30
                y = e.MarginBounds.Top + h + 36

                e.Graphics.DrawString(Label1.Text, Label1.Font, Brushes.Black, x, y)
                x += 160
                e.Graphics.DrawString(TBSumme.Text, TBSumme.Font, Brushes.Black, x, y)
                y += Label1.Height + 5

                x -= 160
                e.Graphics.DrawString(Label2.Text, Label2.Font, Brushes.Black, x, y)
                x += 160
                e.Graphics.DrawString(TBLohn.Text, TBLohn.Font, Brushes.Black, x, y)
                y += Label1.Height + 5

                If ueStunden Then
                    x -= 160
                    e.Graphics.DrawString(Label3.Text, Label3.Font, Brushes.Black, x, y)
                    x += 160
                    e.Graphics.DrawString(TBUeberStd.Text, TBUeberStd.Font, Brushes.Black, x, y)
                    y += Label1.Height + 5

                    x -= 160
                    e.Graphics.DrawString(Label4.Text, Label4.Font, Brushes.Black, x, y)
                    x += 160
                    e.Graphics.DrawString(TBLohnGes.Text, TBLohnGes.Font, Brushes.Black, x, y)
                    y += Label1.Height + 5
                End If

                y = h + e.MarginBounds.Top + 36
            End If

        End If
            neueSeite = False

        ' Drucke Datenreihen
        Dim aktZeile As Integer
        For aktZeile = startZeile To DataGridView1.RowCount - 1

            row = DataGridView1.Rows(aktZeile)
            h = 0

            ' reset X um von links anzufangen
            x = e.MarginBounds.Left

            For Each cell As DataGridViewCell In row.Cells

                ' Überspringe ID Spalte
                If cell.Visible Then
                    rc = New Rectangle(x, y, cell.Size.Width + 10, cell.Size.Height)

                    Using br As New SolidBrush(cell.Style.BackColor)
                        e.Graphics.FillRectangle(br, rc)
                    End Using

                    e.Graphics.DrawRectangle(Pens.Black, rc)
                    e.Graphics.DrawString(cell.FormattedValue.ToString(), DataGridView1.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' nächste Zeile
            startZeile = aktZeile + 1

            ' Neue Seite, wenn nicht alles auf die aktuelle passt
            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                neueSeite = True


                y = e.MarginBounds.Bottom - 20
                x = e.MarginBounds.Right - 50
                e.Graphics.DrawString("Seite " + seitenNummer.ToString, Label1.Font, Brushes.Black, x, y)

                seitenNummer += 1

                Return
            End If
        Next

        y = e.MarginBounds.Bottom - 20
        x = e.MarginBounds.Right - 50
        e.Graphics.DrawString("Seite " + seitenNummer.ToString, Label1.Font, Brushes.Black, x, y)

        startZeile = 0
        neueSeite = True
        seitenNummer = 1
        ueStunden = False

    End Sub

#End Region  ' Druck

#Region "hinzufügen und bearbeiten"
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        neuerEintrag = True
        Eingabe.Show()
    End Sub
    Private Sub CBMonat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBMonat.SelectedIndexChanged
        If My.Settings.letzteDB <> "" Then
            TabelleEinlesen()
            AktualisiereAbrechnung()
        End If
    End Sub
    Private Sub CBJahr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBJahr.SelectedIndexChanged
        If My.Settings.letzteDB <> "" Then
            TabelleEinlesen()
            AktualisiereAbrechnung()
        End If
    End Sub
    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        neuerEintrag = False
        Eingabe.Show()
    End Sub
#End Region 'hinzufügen und bearbeiten

    Friend Sub AktualisiereAbrechnung()
        Dim lohn As Double
        Dim lohnUeber As Double
        Dim lohnGes As Double

        Label2.Text = "Lohn bis " & Format(My.Settings.geplStunden, "#0.00") & "h (" & FormatCurrency(My.Settings.stdLohn, 2, TriState.True) & "):"
        Label3.Text = "Lohn über " & Format(My.Settings.geplStunden, "#0.00") & "h:"

        TBSumme.Text = Format(monatssumme.TotalHours, "#0.00")

        If monatssumme.TotalHours <= My.Settings.geplStunden Then
            lohn = monatssumme.TotalHours * My.Settings.stdLohn
            lohnUeber = 0
        Else
            lohn = My.Settings.geplStunden * My.Settings.stdLohn
            lohnUeber = (monatssumme.TotalHours - My.Settings.geplStunden) * My.Settings.stdLohn
        End If

        lohnGes = lohn + lohnUeber

        TBLohn.Text = FormatCurrency(lohn, 2, TriState.True)
        TBUeberStd.Text = FormatCurrency(lohnUeber, 2, TriState.True)
        TBLohnGes.Text = FormatCurrency(lohnGes, 2, TriState.True)
    End Sub
    Friend Sub TabelleEinlesen()
        Using con As New SQLiteConnection()

            DataGridView1.Rows.Clear()
            ds.Clear()
            monatssumme = TimeSpan.Zero

            If Not File.Exists(dbDateiPfad) Then
                MsgBox("Alte Datei nicht gefunden. Bitte neue erstellen oder laden.")
                Exit Sub
            End If

            Dim cmdEintraege As SQLiteCommand
            con.ConnectionString = "Data Source=" & dbDateiPfad & ";"
            cmdEintraege = con.CreateCommand()

            ' Ausgewählter/s und nächster/s Monat/ Jahr
            Dim monat As String = ""
            Dim nmonat As String = ""
            Dim jahr As String = ""
            Dim njahr As String = ""

            monat = (CBMonat.SelectedIndex + 1).ToString("D2")
            nmonat = (CBMonat.SelectedIndex + 2).ToString("D2")


            jahr = CBJahr.SelectedItem
            If CBMonat.SelectedIndex >= 11 Then
                njahr = CBJahr.SelectedItem + 1
                nmonat = "01"
            Else
                njahr = jahr
            End If


            Dim Querry = "SELECT * FROM Zeiten JOIN Strassen on Zeiten.fkStrasse = Strassen.SId WHERE date(datum) >= date('" & jahr & "-" & monat & "-01') AND date(datum) < date('" & njahr & "-" & nmonat & "-01')"

            Dim LetzteZeit As Date
            Dim Tagessumme As TimeSpan = TimeSpan.Zero
            Dim NeuerTag As Boolean = True

            Dim Background1 As Color = Color.FromArgb(&HFF90CAF9)
            Dim Background2 As Color = Color.FromArgb(&HFFC3FDFF)
            Dim aktFarbe As Color = Background1

            Try
                con.Open()

                Dim da = New SQLiteDataAdapter(Querry, con)
                da.Fill(ds)

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0)

                        Dim datum As Date = .Rows(i).Item("datum")

                        Dim test = 0

                        If IsDBNull(.Rows(i).Item("endzeit")) = True Then
                            test += 1
                        End If

                        If IsDBNull(.Rows(i).Item("startzeit")) = True Then
                            test += 2
                        End If

                        ' Ändere Hintergundfarbe, wenn neuer Tag
                        If NeuerTag = True Then
                            If aktFarbe.Equals(Background1) = True Then
                                aktFarbe = Background2
                            Else
                                aktFarbe = Background1
                            End If
                        End If

                        Select Case test
                            Case 0
                                Dim stunden = DateDiff(DateInterval.Hour, .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"))
                                Dim minuten = DateDiff(DateInterval.Minute, .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit")) Mod 60
                                Dim duration As TimeSpan
                                TimeSpan.TryParse(stunden & ":" & minuten, duration)

                                If NeuerTag = True Then
                                    Tagessumme = duration
                                End If

                                If NeuerTag = False Then
                                    Tagessumme += duration
                                End If

                                If i < .Rows.Count - 1 Then
                                    If .Rows(i + 1).Item("datum") = .Rows(i).Item("datum") Then

                                        NeuerTag = False
                                        DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, " "})

                                    Else
                                        DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, Tagessumme})
                                        monatssumme += Tagessumme
                                        Tagessumme = TimeSpan.Zero

                                        NeuerTag = True

                                    End If

                                Else
                                    DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, Tagessumme})
                                    monatssumme += Tagessumme
                                End If

                            Case 1

                                ' Abfangen ob letzte Zeile
                                If i >= .Rows.Count - 1 Then
                                    NeuerTag = False
                                ElseIf .Rows(i + 1).Item("datum") = .Rows(i).Item("datum") Then
                                    NeuerTag = False
                                End If
                                DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), " ", " ", " "})

                                LetzteZeit = .Rows(i).Item("startzeit")

                            Case 2
                                Dim stunden = DateDiff(DateInterval.Hour, LetzteZeit, .Rows(i).Item("endzeit"))
                                Dim minuten = DateDiff(DateInterval.Minute, LetzteZeit, .Rows(i).Item("endzeit")) Mod 60
                                Dim duration As TimeSpan
                                TimeSpan.TryParse(stunden & ":" & minuten, duration)

                                If NeuerTag = True Then
                                    Tagessumme = duration
                                End If

                                If NeuerTag = False Then
                                    Tagessumme += duration
                                End If

                                If i < .Rows.Count - 1 Then
                                    If .Rows(i + 1).Item("datum") = .Rows(i).Item("datum") Then

                                        NeuerTag = False
                                        DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, " "})

                                    Else
                                        DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, Tagessumme})
                                        monatssumme += Tagessumme
                                        Tagessumme = TimeSpan.Zero

                                        NeuerTag = True

                                    End If

                                Else
                                    DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, Tagessumme})
                                    monatssumme += Tagessumme
                                End If

                            Case 3
                                DataGridView1.Rows.Add({ .Rows(i).Item("ZID"), datum.ToString("dd.MM.yyyy"), .Rows(i).Item("Strasse"), " ", " ", " ", " "})

                        End Select

                    End With

                    For Each cell In DataGridView1.Rows(i).Cells
                        cell.Style.BackColor = aktFarbe
                    Next
                Next

                con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
End Class
