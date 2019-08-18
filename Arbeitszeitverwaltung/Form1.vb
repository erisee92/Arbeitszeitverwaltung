Imports System.ComponentModel
Imports System.Data.SQLite
Imports System.IO

Public Class Form1

    Friend dbDateiPfad As String
    Dim ds As New DataSet



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath
        SaveFileDialog1.InitialDirectory = My.Application.Info.DirectoryPath

        If My.Settings.letzteDB <> "" Then
            dbDateiPfad = My.Settings.letzteDB
            TabelleEinlesen()
            CmdAdd.Enabled = True
        End If

    End Sub

    Private Sub DatenbankÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatenbankÖffnenToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        dbDateiPfad = OpenFileDialog1.FileName
        My.Settings.letzteDB = dbDateiPfad
        TabelleEinlesen()
        CmdAdd.Enabled = True
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

    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
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
                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit"), .Rows(i).Item("endzeit"), duration})

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
                            DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), .Rows(i).Item("startzeit")})

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
                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), Nothing, .Rows(i).Item("endzeit"), duration})

                                Else

                                    If NeuerTag = False Then
                                        Tagessumme += duration
                                    End If

                                    DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), Nothing, .Rows(i).Item("endzeit"), duration, Tagessumme})
                                    Tagessumme = TimeSpan.Zero

                                    NeuerTag = True


                                End If

                            Else
                                If NeuerTag = False Then
                                    Tagessumme += duration
                                End If
                                DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse"), Nothing, .Rows(i).Item("endzeit"), duration, Tagessumme})
                            End If

                        Case 3
                            DataGridView1.Rows.Add({ .Rows(i).Item("datum"), .Rows(i).Item("Strasse")})

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub


End Class
