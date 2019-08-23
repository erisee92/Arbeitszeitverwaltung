Imports System.Data.SQLite

Public Class Eingabe


    Private Sub Eingabe_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim cmd As SQLiteCommand
        Dim con As New SQLiteConnection()
        con.ConnectionString = "Data Source=" & Form1.dbDateiPfad & ";"
        cmd = con.CreateCommand()
        Dim Querry = "SELECT * FROM Strassen"

        Dim DsStrassen As New DataSet

        Try
            con.Open()

            Dim da = New SQLiteDataAdapter(Querry, con)
            da.Fill(DsStrassen)

            For Each dr As DataRow In DsStrassen.Tables(0).Rows
                TBStrasse.AutoCompleteCustomSource.Add(dr.Item("Strasse").ToString)
            Next

            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        BtnHinzu.Text = "Hinzufügen"

        If Form1.neuerEintrag = False Then

            BtnHinzu.Text = "Ändern"

            With Form1.DataGridView1.SelectedRows.Item(0)
                DTPDatum.Value = .Cells(1).Value
                TBStrasse.Text = .Cells(2).Value
                DTPStart.Checked = False
                DTPEnde.Checked = False

                If .Cells(3).Value <> " " Then
                    Dim start As Date = .Cells(3).Value
                    DTPStart.Checked = True
                    DTPStart.Text = start.ToShortTimeString()
                End If

                If .Cells(4).Value <> " " Then
                    Dim ende As Date = .Cells(4).Value
                    DTPEnde.Checked = True
                    DTPEnde.Text = ende.ToShortTimeString()
                End If
            End With

        End If

    End Sub


    Private Sub BtnAbbrechen_Click(sender As Object, e As EventArgs) Handles BtnAbbrechen.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub BtnHinzu_Click(sender As Object, e As EventArgs) Handles BtnHinzu.Click

        Dim datum = DTPDatum.Value.ToString("yyyy-MM-dd")
        Dim strasse As String = TBStrasse.Text
        Dim startZeit = DTPStart.Value.ToString("HH:mm")
        Dim endZeit = DTPEnde.Value.ToString("HH:mm")


        If strasse = "" Or strasse = " " Then
            MessageBox.Show("Bitte eine Straße eintragen", "Straßenname leer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim cmd As SQLiteCommand
        Dim con As New SQLiteConnection()
        con.ConnectionString = "Data Source=" & Form1.dbDateiPfad & ";"
        cmd = con.CreateCommand()
        Dim Querry = "SELECT SId FROM Strassen WHERE Strasse=""" & TBStrasse.Text & """"

        cmd.CommandText = Querry

        Dim DsStrassen As New DataSet

        Dim SId

        'Try
        con.Open()

            SId = cmd.ExecuteScalar

            If SId = Nothing Then
                Querry = "INSERT INTO Strassen(Strasse) VALUES ('" & TBStrasse.Text & "');"
                cmd.CommandText = Querry
                cmd.ExecuteNonQuery()

                Querry = "SELECT max(SId) FROM Strassen"
                cmd.CommandText = Querry
                SId = cmd.ExecuteScalar
            End If

            If Form1.neuerEintrag = True Then

                If DTPStart.Checked = True And DTPEnde.Checked = True Then
                    Querry = "INSERT INTO Zeiten(datum, fkStrasse, startzeit, endzeit) VALUES ('" & datum & "', " & SId & ", '" & startZeit & "', '" & endZeit & "');"
                    DTPEnde.Checked = False

                ElseIf DTPStart.Checked = True And DTPEnde.Checked = False Then
                    Querry = "INSERT INTO Zeiten(datum, fkStrasse, startzeit) VALUES ('" & datum & "', " & SId & ", '" & startZeit & "');"
                    DTPStart.Checked = False

                ElseIf DTPStart.Checked = False And DTPEnde.Checked = True Then
                    Querry = "INSERT INTO Zeiten(datum, fkStrasse, endzeit) VALUES ('" & datum & "', " & SId & ", '" & endZeit & "');"
                    DTPStart.Checked = True
                    DTPEnde.Checked = False

                Else
                    Querry = "INSERT INTO Zeiten(datum, fkStrasse ) VALUES ('" & datum & "', " & SId & ");"
                End If

            Else

                Dim ZId = Form1.DataGridView1.SelectedRows.Item(0).Cells(0).Value


                If DTPStart.Checked = True And DTPEnde.Checked = True Then
                    Querry = "UPDATE Zeiten SET datum='" & datum & "', fkStrasse='" & SId & "', startzeit='" & startZeit & "', endzeit='" & endZeit & "' WHERE ZId='" & ZId & "';"
                    DTPEnde.Checked = False

                ElseIf DTPStart.Checked = True And DTPEnde.Checked = False Then

                    Querry = "UPDATE Zeiten SET datum='" & datum & "', fkStrasse='" & SId & "', startzeit='" & startZeit & "' WHERE ZId='" & ZId & "';"
                    DTPStart.Checked = False

                ElseIf DTPStart.Checked = False And DTPEnde.Checked = True Then
                    Querry = "UPDATE Zeiten SET datum='" & datum & "', fkStrasse='" & SId & "', endzeit='" & endZeit & "' WHERE ZId='" & ZId & "';"
                    DTPStart.Checked = True
                    DTPEnde.Checked = False

                Else
                    Querry = "UPDATE Zeiten SET datum='" & datum & "', fkStrasse='" & SId & "' WHERE ZId='" & ZId & "';"
                End If

            End If


            cmd.CommandText = Querry

            cmd.ExecuteNonQuery()

            con.Close()

            Form1.TabelleEinlesen()
            Form1.AktualisiereAbrechnung()

            TBStrasse.Text = ""


        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        If Form1.neuerEintrag = False Then
            Me.Hide()
            Form1.Show()
        End If

    End Sub

End Class