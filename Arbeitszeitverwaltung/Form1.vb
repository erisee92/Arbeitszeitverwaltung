Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Public Class Form1

    Friend dbDateiPfad As String
    Dim ds As New DataSet

    ''' <summary>
    ''' structire to hold printed page details
    ''' </summary>
    ''' <remarks></remarks>
    Private Structure pageDetails
        Dim columns As Integer
        Dim rows As Integer
        Dim startCol As Integer
        Dim startRow As Integer
    End Structure
    ''' <summary>
    ''' dictionary to hold printed page details, with index key
    ''' </summary>
    ''' <remarks></remarks>
    Private pages As Dictionary(Of Integer, pageDetails)

    Dim maxPagesWide As Integer
    Dim maxPagesTall As Integer



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath
        SaveFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath

        If My.Settings.letzteDB <> "" Then
            dbDateiPfad = My.Settings.letzteDB
            TabelleEinlesen()
            BtnAdd.Enabled = True
        End If

    End Sub

    Private Sub DatenbankÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatenbankÖffnenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        dbDateiPfad = OpenFileDialog1.FileName
        My.Settings.letzteDB = dbDateiPfad
        TabelleEinlesen()
        BtnAdd.Enabled = True
    End Sub

    Private Sub NeueDatenbankToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NeueDatenbankToolStripMenuItem.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog1.FileOk
        Dim con As New SQLiteConnection()
        Dim cmd As SQLiteCommand

        If File.Exists(SaveFileDialog1.FileName) Then
            MsgBox("Geht nicht")
            Exit Sub

            ' Muss erst irgendwo freigegeben werden
            File.Delete(SaveFileDialog1.FileName)
        End If


        con.ConnectionString = "Data Source=" & SaveFileDialog1.FileName & ";"
        cmd = con.CreateCommand()

        Try
            con.Open()

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
        MessageBox.Show("Datenbank gespeichert", "Speichern Erfolgreich", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Eingabe.ShowDialog()
    End Sub

    Friend Sub TabelleEinlesen()
        Dim con As New SQLiteConnection()

        DataGridView1.Rows.Clear()
        ds.Clear()

        Dim cmdEintraege As SQLiteCommand
        con.ConnectionString = "Data Source=" & dbDateiPfad & ";"
        cmdEintraege = con.CreateCommand()
        Dim Querry = "SELECT * FROM Zeiten JOIN Strassen on Zeiten.fkStrasse = Strassen.SId"

        Dim LetzteZeit As Date
        Dim Tagessumme As TimeSpan = TimeSpan.Zero
        Dim NeuerTag As Boolean = True

        Dim Background1 As Color = Color.FromArgb(&HFF64B5F6)
        Dim Background2 As Color = Color.FromArgb(&HFF9BE7FF)
        Dim aktFarbe As Color = Background1


        Try
            con.Open()

            Dim da = New SQLiteDataAdapter(Querry, con)
            da.Fill(ds)

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                With ds.Tables(0)

                    Dim test = 0

                    If IsDBNull(.Rows(i).Item("endzeit")) = True Then
                        test += 1
                    End If

                    If IsDBNull(.Rows(i).Item("startzeit")) = True Then
                        test += 2
                    End If

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

                            If i < .Rows.Count - 1 Then
                                If .Rows(i + 1).Item("datum") = .Rows(i).Item("datum") Then

                                    If NeuerTag = False Then
                                        Tagessumme += duration
                                    End If
                                    NeuerTag = False
                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, " "})

                                Else
                                    If NeuerTag = False Then
                                        Tagessumme += duration
                                    End If
                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, Tagessumme})
                                    Tagessumme = TimeSpan.Zero

                                    NeuerTag = True


                                End If

                            Else
                                If NeuerTag = False Then
                                    Tagessumme += duration
                                End If
                                DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration, Tagessumme})
                            End If

                        Case 1
                            DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), " ", " ", " "})

                            LetzteZeit = .Rows(i).Item("startzeit")

                        Case 2
                            Dim stunden = DateDiff(DateInterval.Hour, LetzteZeit, .Rows(i).Item("endzeit"))
                            Dim minuten = DateDiff(DateInterval.Minute, LetzteZeit, .Rows(i).Item("endzeit")) Mod 60
                            Dim duration As TimeSpan
                            TimeSpan.TryParse(stunden & ":" & minuten, duration)

                            If NeuerTag = True Then
                                Tagessumme = duration

                                If aktFarbe.Equals(Background1) = True Then
                                    aktFarbe = Background2
                                Else
                                    aktFarbe = Background1
                                End If
                            End If

                            If i < .Rows.Count - 1 Then
                                If .Rows(i + 1).Item("datum") = .Rows(i).Item("datum") Then

                                    If NeuerTag = False Then
                                        Tagessumme += duration
                                    End If
                                    NeuerTag = False
                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, " "})

                                Else

                                    If NeuerTag = False Then
                                        Tagessumme += duration
                                    End If

                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, Tagessumme})
                                    Tagessumme = TimeSpan.Zero

                                    NeuerTag = True


                                End If

                            Else
                                If NeuerTag = False Then
                                    Tagessumme += duration
                                End If
                                DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), " ", .Rows(i).Item("endzeit"), duration, Tagessumme})
                            End If

                        Case 3
                            DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), " ", " ", " ", " "})

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
    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BtnDruck_Click(sender As Object, e As EventArgs) Handles BtnDruck.Click
        Dim ppd As New PrintPreviewDialog
        ppd.Document = PrintDocument1
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint

        PrintDocument1.OriginAtMargins = True
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(0, 0, 0, 0)

        pages = New Dictionary(Of Integer, pageDetails)

        Dim maxWidth As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Width) - 40
        Dim maxHeight As Integer = CInt(PrintDocument1.DefaultPageSettings.PrintableArea.Height) - 40

        Dim pageCounter As Integer = 0
        pages.Add(pageCounter, New pageDetails)

        Dim columnCounter As Integer = 0

        Dim columnSum As Integer = DataGridView1.RowHeadersWidth

        For c As Integer = 0 To DataGridView1.Columns.Count - 1
            If columnSum + DataGridView1.Columns(c).Width < maxWidth Then
                columnSum += DataGridView1.Columns(c).Width
                columnCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                columnSum = DataGridView1.RowHeadersWidth + DataGridView1.Columns(c).Width
                columnCounter = 1
                pageCounter += 1
                pages.Add(pageCounter, New pageDetails With {.startCol = c})
            End If
            If c = DataGridView1.Columns.Count - 1 Then
                If pages(pageCounter).columns = 0 Then
                    pages(pageCounter) = New pageDetails With {.columns = columnCounter, .rows = 0, .startCol = pages(pageCounter).startCol}
                End If
            End If
        Next

        maxPagesWide = pages.Keys.Max + 1

        pageCounter = 0

        Dim rowCounter As Integer = 0

        Dim rowSum As Integer = DataGridView1.ColumnHeadersHeight

        For r As Integer = 0 To DataGridView1.Rows.Count - 2
            If rowSum + DataGridView1.Rows(r).Height < maxHeight Then
                rowSum += DataGridView1.Rows(r).Height
                rowCounter += 1
            Else
                pages(pageCounter) = New pageDetails With {.columns = pages(pageCounter).columns, .rows = rowCounter, .startCol = pages(pageCounter).startCol, .startRow = pages(pageCounter).startRow}
                For x As Integer = 1 To maxPagesWide - 1
                    pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter).startRow}
                Next

                pageCounter += maxPagesWide
                For x As Integer = 0 To maxPagesWide - 1
                    pages.Add(pageCounter + x, New pageDetails With {.columns = pages(x).columns, .rows = 0, .startCol = pages(x).startCol, .startRow = r})
                Next

                rowSum = DataGridView1.ColumnHeadersHeight + DataGridView1.Rows(r).Height
                rowCounter = 1
            End If
            If r = DataGridView1.Rows.Count - 2 Then
                For x As Integer = 0 To maxPagesWide - 1
                    If pages(pageCounter + x).rows = 0 Then
                        pages(pageCounter + x) = New pageDetails With {.columns = pages(pageCounter + x).columns, .rows = rowCounter, .startCol = pages(pageCounter + x).startCol, .startRow = pages(pageCounter + x).startRow}
                    End If
                Next
            End If
        Next

        maxPagesTall = pages.Count \ maxPagesWide

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim g As Graphics = e.Graphics
        Dim pic As New Bitmap(DataGridView1.Width, DataGridView1.Height)
        Dim Quadrat As New Rectangle(10, 10, DataGridView1.Width, DataGridView1.Height + 50)
        DataGridView1.DrawToBitmap(pic, Quadrat)
        g.DrawImage(pic, 0, 0)

    End Sub


End Class
