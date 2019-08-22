<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeueDatenbankToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenbankÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnDruck = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBSumme = New System.Windows.Forms.TextBox()
        Me.TBLohn = New System.Windows.Forms.TextBox()
        Me.TBUeberStd = New System.Windows.Forms.TextBox()
        Me.TBLohnGes = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CBJahr = New System.Windows.Forms.ComboBox()
        Me.CBMonat = New System.Windows.Forms.ComboBox()
        Me.ColID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpStrasse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpEnde = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpDauer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SpDauerTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.NeueDatenbankToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.NeueDatenbankToolStripMenuItem.Text = "Neue Datenbank"
        '
        'DatenbankÖffnenToolStripMenuItem
        '
        Me.DatenbankÖffnenToolStripMenuItem.Name = "DatenbankÖffnenToolStripMenuItem"
        Me.DatenbankÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DatenbankÖffnenToolStripMenuItem.Text = "Datenbank öffnen"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BearbeitenToolStripMenuItem, Me.ResetToolStripMenuItem})
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.EinstellungenToolStripMenuItem.Text = "&Einstellungen"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ResetToolStripMenuItem.Text = "Reset"
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
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColID, Me.SpTag, Me.SpStrasse, Me.SpStart, Me.SpEnde, Me.SpDauer, Me.SpDauerTag})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(414, 426)
        Me.DataGridView1.TabIndex = 1
        '
        'BtnAdd
        '
        Me.BtnAdd.Enabled = False
        Me.BtnAdd.Location = New System.Drawing.Point(46, 6)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(111, 23)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "neue Einträge"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnDruck
        '
        Me.BtnDruck.Enabled = False
        Me.BtnDruck.Location = New System.Drawing.Point(46, 51)
        Me.BtnDruck.Name = "BtnDruck"
        Me.BtnDruck.Size = New System.Drawing.Size(111, 41)
        Me.BtnDruck.TabIndex = 3
        Me.BtnDruck.Text = "Drucke aktuelle Ansicht"
        Me.BtnDruck.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Summe h:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Lohn bis 0h (0,00€):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Über 0h:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(43, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Gesamt:"
        '
        'TBSumme
        '
        Me.TBSumme.Location = New System.Drawing.Point(193, 119)
        Me.TBSumme.Name = "TBSumme"
        Me.TBSumme.ReadOnly = True
        Me.TBSumme.Size = New System.Drawing.Size(100, 20)
        Me.TBSumme.TabIndex = 8
        '
        'TBLohn
        '
        Me.TBLohn.Location = New System.Drawing.Point(193, 142)
        Me.TBLohn.Name = "TBLohn"
        Me.TBLohn.ReadOnly = True
        Me.TBLohn.Size = New System.Drawing.Size(100, 20)
        Me.TBLohn.TabIndex = 8
        '
        'TBUeberStd
        '
        Me.TBUeberStd.Location = New System.Drawing.Point(193, 165)
        Me.TBUeberStd.Name = "TBUeberStd"
        Me.TBUeberStd.ReadOnly = True
        Me.TBUeberStd.Size = New System.Drawing.Size(100, 20)
        Me.TBUeberStd.TabIndex = 8
        '
        'TBLohnGes
        '
        Me.TBLohnGes.Location = New System.Drawing.Point(193, 188)
        Me.TBLohnGes.Name = "TBLohnGes"
        Me.TBLohnGes.ReadOnly = True
        Me.TBLohnGes.Size = New System.Drawing.Size(100, 20)
        Me.TBLohnGes.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CBJahr)
        Me.Panel1.Controls.Add(Me.CBMonat)
        Me.Panel1.Controls.Add(Me.TBLohnGes)
        Me.Panel1.Controls.Add(Me.TBUeberStd)
        Me.Panel1.Controls.Add(Me.TBLohn)
        Me.Panel1.Controls.Add(Me.TBSumme)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnDruck)
        Me.Panel1.Controls.Add(Me.BtnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(420, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 426)
        Me.Panel1.TabIndex = 9
        '
        'CBJahr
        '
        Me.CBJahr.Enabled = False
        Me.CBJahr.FormattingEnabled = True
        Me.CBJahr.Location = New System.Drawing.Point(193, 35)
        Me.CBJahr.Name = "CBJahr"
        Me.CBJahr.Size = New System.Drawing.Size(121, 21)
        Me.CBJahr.TabIndex = 11
        '
        'CBMonat
        '
        Me.CBMonat.Enabled = False
        Me.CBMonat.FormattingEnabled = True
        Me.CBMonat.Items.AddRange(New Object() {"Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"})
        Me.CBMonat.Location = New System.Drawing.Point(193, 62)
        Me.CBMonat.Name = "CBMonat"
        Me.CBMonat.Size = New System.Drawing.Size(121, 21)
        Me.CBMonat.TabIndex = 10
        '
        'ColID
        '
        Me.ColID.HeaderText = "ID"
        Me.ColID.Name = "ColID"
        Me.ColID.ReadOnly = True
        Me.ColID.Visible = False
        Me.ColID.Width = 24
        '
        'SpTag
        '
        Me.SpTag.HeaderText = "Tag"
        Me.SpTag.MinimumWidth = 50
        Me.SpTag.Name = "SpTag"
        Me.SpTag.ReadOnly = True
        Me.SpTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpTag.Width = 50
        '
        'SpStrasse
        '
        Me.SpStrasse.HeaderText = "Straße"
        Me.SpStrasse.MinimumWidth = 150
        Me.SpStrasse.Name = "SpStrasse"
        Me.SpStrasse.ReadOnly = True
        Me.SpStrasse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpStrasse.Width = 150
        '
        'SpStart
        '
        Me.SpStart.HeaderText = "Start"
        Me.SpStart.MinimumWidth = 40
        Me.SpStart.Name = "SpStart"
        Me.SpStart.ReadOnly = True
        Me.SpStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpStart.Width = 40
        '
        'SpEnde
        '
        Me.SpEnde.HeaderText = "Ende"
        Me.SpEnde.MinimumWidth = 40
        Me.SpEnde.Name = "SpEnde"
        Me.SpEnde.ReadOnly = True
        Me.SpEnde.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpEnde.Width = 40
        '
        'SpDauer
        '
        Me.SpDauer.HeaderText = "Dauer"
        Me.SpDauer.MinimumWidth = 40
        Me.SpDauer.Name = "SpDauer"
        Me.SpDauer.ReadOnly = True
        Me.SpDauer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpDauer.Width = 42
        '
        'SpDauerTag
        '
        Me.SpDauerTag.HeaderText = "Summe Tag"
        Me.SpDauerTag.MinimumWidth = 40
        Me.SpDauerTag.Name = "SpDauerTag"
        Me.SpDauerTag.ReadOnly = True
        Me.SpDauerTag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SpDauerTag.Width = 70
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Arbeitszeitverwaltung"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents BtnDruck As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TBSumme As TextBox
    Friend WithEvents TBLohn As TextBox
    Friend WithEvents TBUeberStd As TextBox
    Friend WithEvents TBLohnGes As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CBMonat As ComboBox
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CBJahr As ComboBox
    Friend WithEvents ColID As DataGridViewTextBoxColumn
    Friend WithEvents SpTag As DataGridViewTextBoxColumn
    Friend WithEvents SpStrasse As DataGridViewTextBoxColumn
    Friend WithEvents SpStart As DataGridViewTextBoxColumn
    Friend WithEvents SpEnde As DataGridViewTextBoxColumn
    Friend WithEvents SpDauer As DataGridViewTextBoxColumn
    Friend WithEvents SpDauerTag As DataGridViewTextBoxColumn
End Class
