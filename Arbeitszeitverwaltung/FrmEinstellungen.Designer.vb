﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEinstellungen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEinstellungen))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBgeplStd = New System.Windows.Forms.TextBox()
        Me.TBStdLohn = New System.Windows.Forms.TextBox()
        Me.BtnSpeichern = New System.Windows.Forms.Button()
        Me.BtnAbbrechen = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Stunden pro Monat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Stundenlohn in Euro"
        '
        'TBgeplStd
        '
        Me.TBgeplStd.Location = New System.Drawing.Point(158, 34)
        Me.TBgeplStd.Name = "TBgeplStd"
        Me.TBgeplStd.Size = New System.Drawing.Size(100, 20)
        Me.TBgeplStd.TabIndex = 2
        '
        'TBStdLohn
        '
        Me.TBStdLohn.Location = New System.Drawing.Point(158, 61)
        Me.TBStdLohn.Name = "TBStdLohn"
        Me.TBStdLohn.Size = New System.Drawing.Size(100, 20)
        Me.TBStdLohn.TabIndex = 3
        '
        'BtnSpeichern
        '
        Me.BtnSpeichern.Location = New System.Drawing.Point(44, 105)
        Me.BtnSpeichern.Name = "BtnSpeichern"
        Me.BtnSpeichern.Size = New System.Drawing.Size(75, 23)
        Me.BtnSpeichern.TabIndex = 4
        Me.BtnSpeichern.Text = "Speichern"
        Me.BtnSpeichern.UseVisualStyleBackColor = True
        '
        'BtnAbbrechen
        '
        Me.BtnAbbrechen.Location = New System.Drawing.Point(168, 105)
        Me.BtnAbbrechen.Name = "BtnAbbrechen"
        Me.BtnAbbrechen.Size = New System.Drawing.Size(75, 23)
        Me.BtnAbbrechen.TabIndex = 5
        Me.BtnAbbrechen.Text = "Abbrechen"
        Me.BtnAbbrechen.UseVisualStyleBackColor = True
        '
        'FrmEinstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 162)
        Me.Controls.Add(Me.BtnAbbrechen)
        Me.Controls.Add(Me.BtnSpeichern)
        Me.Controls.Add(Me.TBStdLohn)
        Me.Controls.Add(Me.TBgeplStd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmEinstellungen"
        Me.Text = "Einstellungen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TBgeplStd As TextBox
    Friend WithEvents TBStdLohn As TextBox
    Friend WithEvents BtnSpeichern As Button
    Friend WithEvents BtnAbbrechen As Button
End Class
