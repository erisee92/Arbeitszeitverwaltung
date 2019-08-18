<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Eingabe
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Eingabe))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPDatum = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.DTPEnde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBStrasse = New System.Windows.Forms.TextBox()
        Me.BtnHinzu = New System.Windows.Forms.Button()
        Me.BtnAbbrechen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datum"
        '
        'DTPDatum
        '
        Me.DTPDatum.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPDatum.Location = New System.Drawing.Point(88, 12)
        Me.DTPDatum.Name = "DTPDatum"
        Me.DTPDatum.Size = New System.Drawing.Size(148, 20)
        Me.DTPDatum.TabIndex = 1
        '
        'DTPStart
        '
        Me.DTPStart.Checked = False
        Me.DTPStart.CustomFormat = "HH:mm"
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPStart.Location = New System.Drawing.Point(88, 65)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.ShowCheckBox = True
        Me.DTPStart.ShowUpDown = True
        Me.DTPStart.Size = New System.Drawing.Size(148, 20)
        Me.DTPStart.TabIndex = 3
        '
        'DTPEnde
        '
        Me.DTPEnde.Checked = False
        Me.DTPEnde.CustomFormat = "HH:mm"
        Me.DTPEnde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPEnde.Location = New System.Drawing.Point(88, 91)
        Me.DTPEnde.Name = "DTPEnde"
        Me.DTPEnde.ShowCheckBox = True
        Me.DTPEnde.ShowUpDown = True
        Me.DTPEnde.Size = New System.Drawing.Size(148, 20)
        Me.DTPEnde.TabIndex = 4
        Me.DTPEnde.Value = New Date(2019, 8, 15, 21, 8, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Straße"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Start"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ende"
        '
        'TBStrasse
        '
        Me.TBStrasse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TBStrasse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TBStrasse.Location = New System.Drawing.Point(88, 39)
        Me.TBStrasse.Name = "TBStrasse"
        Me.TBStrasse.Size = New System.Drawing.Size(148, 20)
        Me.TBStrasse.TabIndex = 2
        '
        'BtnHinzu
        '
        Me.BtnHinzu.Location = New System.Drawing.Point(278, 32)
        Me.BtnHinzu.Name = "BtnHinzu"
        Me.BtnHinzu.Size = New System.Drawing.Size(75, 23)
        Me.BtnHinzu.TabIndex = 5
        Me.BtnHinzu.Text = "Hinzufügen"
        Me.BtnHinzu.UseVisualStyleBackColor = True
        '
        'BtnAbbrechen
        '
        Me.BtnAbbrechen.Location = New System.Drawing.Point(278, 65)
        Me.BtnAbbrechen.Name = "BtnAbbrechen"
        Me.BtnAbbrechen.Size = New System.Drawing.Size(75, 23)
        Me.BtnAbbrechen.TabIndex = 6
        Me.BtnAbbrechen.Text = "Schließen"
        Me.BtnAbbrechen.UseVisualStyleBackColor = True
        '
        'Eingabe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 134)
        Me.Controls.Add(Me.BtnAbbrechen)
        Me.Controls.Add(Me.BtnHinzu)
        Me.Controls.Add(Me.TBStrasse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPEnde)
        Me.Controls.Add(Me.DTPStart)
        Me.Controls.Add(Me.DTPDatum)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Eingabe"
        Me.Text = "Eingabe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DTPDatum As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents DTPEnde As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TBStrasse As TextBox
    Friend WithEvents BtnHinzu As Button
    Friend WithEvents BtnAbbrechen As Button
End Class
