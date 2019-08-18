<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeueDatenbankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenbankÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SpTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpStrasse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpEnde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpDauer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpDauerTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDruck = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.EinstellungenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeueDatenbankToolStripMenuItem, Me.DatenbankÖffnenToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'NeueDatenbankToolStripMenuItem
        '
        Me.NeueDatenbankToolStripMenuItem.Name = "NeueDatenbankToolStripMenuItem"
        Me.NeueDatenbankToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.NeueDatenbankToolStripMenuItem.Text = "Neue Datenbank"
        '
        'DatenbankÖffnenToolStripMenuItem
        '
        Me.DatenbankÖffnenToolStripMenuItem.Name = "DatenbankÖffnenToolStripMenuItem"
        Me.DatenbankÖffnenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DatenbankÖffnenToolStripMenuItem.Text = "Datenbank öffnen"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "db"
        Me.OpenFileDialog1.FileName = "arbeitszeit.db"
        Me.OpenFileDialog1.Filter = "SQLite-Datei|*.db|Alle Dateien|*.*"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "db"
        Me.SaveFileDialog1.FileName = "arbeitszeit.db"
        Me.SaveFileDialog1.Filter = "SQLite-Datei|*.db|Alle Dateien|*.*"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SpTag, Me.SpStrasse, Me.SpStart, Me.SpEnde, Me.SpDauer, Me.SpDauerTag})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(429, 426)
        Me.DataGridView1.TabIndex = 1
        '
        'SpTag
        '
        Me.SpTag.HeaderText = "Tag"
        Me.SpTag.Name = "SpTag"
        Me.SpTag.ReadOnly = True
        Me.SpTag.Width = 51
        '
        'SpStrasse
        '
        Me.SpStrasse.HeaderText = "Straße"
        Me.SpStrasse.Name = "SpStrasse"
        Me.SpStrasse.ReadOnly = True
        Me.SpStrasse.Width = 63
        '
        'SpStart
        '
        Me.SpStart.HeaderText = "Start"
        Me.SpStart.Name = "SpStart"
        Me.SpStart.ReadOnly = True
        Me.SpStart.Width = 54
        '
        'SpEnde
        '
        Me.SpEnde.HeaderText = "Ende"
        Me.SpEnde.Name = "SpEnde"
        Me.SpEnde.ReadOnly = True
        Me.SpEnde.Width = 57
        '
        'SpDauer
        '
        Me.SpDauer.HeaderText = "Dauer"
        Me.SpDauer.Name = "SpDauer"
        Me.SpDauer.ReadOnly = True
        Me.SpDauer.Width = 61
        '
        'SpDauerTag
        '
        Me.SpDauerTag.HeaderText = "Summe Tag"
        Me.SpDauerTag.Name = "SpDauerTag"
        Me.SpDauerTag.ReadOnly = True
        Me.SpDauerTag.Width = 89
        '
        'BtnAdd
        '
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.Location = New System.Drawing.Point(549, 39)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(111, 23)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "neue Einträge"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDruck
        '
        Me.BtnDruck.Location = New System.Drawing.Point(549, 84)
        Me.BtnDruck.Name = "BtnDruck"
        Me.BtnDruck.Size = New System.Drawing.Size(111, 41)
        Me.BtnDruck.TabIndex = 3
        Me.BtnDruck.Text = "Druck aktuelle Ansicht"
        Me.BtnDruck.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.EinstellungenToolStripMenuItem.Text = "&Einstellungen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(486, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Summe h:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(486, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lohn bis 110h (9,50€):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(486, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Über 110h:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(486, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Gesamt:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(610, 151)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 8
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(610, 174)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 8
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(610, 197)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 8
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(610, 220)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 20)
        Me.TextBox4.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnDruck)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Arbeitszeitverwaltung"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatenbankÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents NeueDatenbankToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnAdd As Button
    Friend WithEvents SpTag As DataGridViewTextBoxColumn
    Friend WithEvents SpStrasse As DataGridViewTextBoxColumn
    Friend WithEvents SpStart As DataGridViewTextBoxColumn
    Friend WithEvents SpEnde As DataGridViewTextBoxColumn
    Friend WithEvents SpDauer As DataGridViewTextBoxColumn
    Friend WithEvents SpDauerTag As DataGridViewTextBoxColumn
    Friend WithEvents BtnDruck As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
End Class
