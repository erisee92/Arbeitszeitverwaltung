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
        PrintDocument1.DefaultPageSettings.Margins = New Drawing.Printing.Margins(20, 20, 20, 20)
        mRow = 0
        newpage = True


    End Sub


    Private mRow As Integer = 0
    Private newpage As Boolean = True
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        ' sets it to show '...' for long text
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
        fmt.LineAlignment = StringAlignment.Center
        fmt.Trimming = StringTrimming.EllipsisCharacter
        Dim y As Int32 = e.MarginBounds.Top
        Dim rc As Rectangle
        Dim x As Int32
        Dim h As Int32 = 0
        Dim row As DataGridViewRow

        ' print the header text for a new page
        '   use a grey bg just like the control
        If newpage Then
            row = DataGridView1.Rows(mRow)
            x = e.MarginBounds.Left
            For Each cell As DataGridViewCell In row.Cells
                ' since we are printing the control's view,
                ' skip invidible columns
                If cell.Visible Then

                    If cell.ColumnIndex = 0 Or cell.ColumnIndex = 1 Then
                        rc = New Rectangle(x, y, cell.Size.Width + 10, cell.Size.Height)
                    Else
                        rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)
                    End If


                    e.Graphics.FillRectangle(Brushes.LightGray, rc)
                        e.Graphics.DrawRectangle(Pens.Black, rc)

                        ' reused in the data pront - should be a function
                        Select Case DataGridView1.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                            Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                                fmt.Alignment = StringAlignment.Far
                                rc.Offset(-1, 0)
                            Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                                fmt.Alignment = StringAlignment.Center
                            Case Else
                                fmt.Alignment = StringAlignment.Near
                                rc.Offset(2, 0)
                        End Select

                        e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText,
                                                DataGridView1.Font, Brushes.Black, rc, fmt)
                        x += rc.Width
                        h = Math.Max(h, rc.Height)
                    End If
            Next
            y += h

        End If
        newpage = False

        ' now print the data for each row
        Dim thisNDX As Int32
        For thisNDX = mRow To DataGridView1.RowCount - 1
            ' no need to try to print the new row
            If DataGridView1.Rows(thisNDX).IsNewRow Then Exit For

            row = DataGridView1.Rows(thisNDX)
            x = e.MarginBounds.Left
            h = 0

            ' reset X for data
            x = e.MarginBounds.Left

            ' print the data
            For Each cell As DataGridViewCell In row.Cells
                If cell.Visible Then
                    If cell.ColumnIndex = 0 Or cell.ColumnIndex = 1 Then
                        rc = New Rectangle(x, y, cell.Size.Width + 10, cell.Size.Height)
                    Else
                        rc = New Rectangle(x, y, cell.Size.Width, cell.Size.Height)
                    End If


                    ' SAMPLE CODE: How To 
                    ' up a RowPrePaint rule
                    'If Convert.ToDecimal(row.Cells(5).Value) < 9.99 Then
                    '    Using br As New SolidBrush(Color.MistyRose)
                    '        e.Graphics.FillRectangle(br, rc)
                    '    End Using
                    'End If

                    e.Graphics.DrawRectangle(Pens.Black, rc)

                    Select Case DataGridView1.Columns(cell.ColumnIndex).DefaultCellStyle.Alignment
                        Case DataGridViewContentAlignment.BottomRight,
                             DataGridViewContentAlignment.MiddleRight
                            fmt.Alignment = StringAlignment.Far
                            rc.Offset(-1, 0)
                        Case DataGridViewContentAlignment.BottomCenter,
                            DataGridViewContentAlignment.MiddleCenter
                            fmt.Alignment = StringAlignment.Center
                        Case Else
                            fmt.Alignment = StringAlignment.Near
                            rc.Offset(2, 0)
                    End Select

                    e.Graphics.DrawString(cell.FormattedValue.ToString(),
                                          DataGridView1.Font, Brushes.Black, rc, fmt)

                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                End If

            Next
            y += h
            ' next row to print
            mRow = thisNDX + 1

            If y + h > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                ' mRow -= 1   causes last row to rePrint on next page
                newpage = True
                Return
            End If
        Next



    End Sub


End Class
