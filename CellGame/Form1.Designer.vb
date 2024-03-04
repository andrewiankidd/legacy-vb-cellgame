<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pbGame = New System.Windows.Forms.PictureBox
        Me.lbldebugdata = New System.Windows.Forms.Label
        Me.open = New System.Windows.Forms.OpenFileDialog
        Me.gshowtext = New System.Windows.Forms.GroupBox
        Me.lblshowtext = New System.Windows.Forms.Label
        Me.Inventory = New System.Windows.Forms.GroupBox
        Me.inventorylist = New System.Windows.Forms.ListView
        Me.Item = New System.Windows.Forms.ColumnHeader
        Me.Price = New System.Windows.Forms.ColumnHeader
        Me.CMDsave = New System.Windows.Forms.Button
        Me.CMDloadsave = New System.Windows.Forms.Button
        Me.cmdhelp = New System.Windows.Forms.Button
        Me.cmdopenworld = New System.Windows.Forms.Button
        CType(Me.pbGame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gshowtext.SuspendLayout()
        Me.Inventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbGame
        '
        Me.pbGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbGame.Location = New System.Drawing.Point(12, 12)
        Me.pbGame.Name = "pbGame"
        Me.pbGame.Size = New System.Drawing.Size(500, 500)
        Me.pbGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbGame.TabIndex = 0
        Me.pbGame.TabStop = False
        '
        'lbldebugdata
        '
        Me.lbldebugdata.AutoSize = True
        Me.lbldebugdata.Location = New System.Drawing.Point(9, 548)
        Me.lbldebugdata.Name = "lbldebugdata"
        Me.lbldebugdata.Size = New System.Drawing.Size(39, 13)
        Me.lbldebugdata.TabIndex = 2
        Me.lbldebugdata.Text = "Label1"
        '
        'open
        '
        Me.open.FileName = "OpenFileDialog1"
        '
        'gshowtext
        '
        Me.gshowtext.BackColor = System.Drawing.Color.White
        Me.gshowtext.Controls.Add(Me.lblshowtext)
        Me.gshowtext.Location = New System.Drawing.Point(12, 457)
        Me.gshowtext.Name = "gshowtext"
        Me.gshowtext.Size = New System.Drawing.Size(500, 55)
        Me.gshowtext.TabIndex = 3
        Me.gshowtext.TabStop = False
        '
        'lblshowtext
        '
        Me.lblshowtext.AutoSize = True
        Me.lblshowtext.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblshowtext.Location = New System.Drawing.Point(5, 10)
        Me.lblshowtext.Name = "lblshowtext"
        Me.lblshowtext.Size = New System.Drawing.Size(111, 37)
        Me.lblshowtext.TabIndex = 0
        Me.lblshowtext.Text = "Label1"
        '
        'Inventory
        '
        Me.Inventory.Controls.Add(Me.inventorylist)
        Me.Inventory.Location = New System.Drawing.Point(42, 44)
        Me.Inventory.Name = "Inventory"
        Me.Inventory.Size = New System.Drawing.Size(443, 333)
        Me.Inventory.TabIndex = 4
        Me.Inventory.TabStop = False
        Me.Inventory.Text = "Inventory"
        '
        'inventorylist
        '
        Me.inventorylist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Item, Me.Price})
        Me.inventorylist.Location = New System.Drawing.Point(6, 19)
        Me.inventorylist.Name = "inventorylist"
        Me.inventorylist.Size = New System.Drawing.Size(431, 308)
        Me.inventorylist.TabIndex = 1
        Me.inventorylist.UseCompatibleStateImageBehavior = False
        '
        'CMDsave
        '
        Me.CMDsave.Location = New System.Drawing.Point(437, 518)
        Me.CMDsave.Name = "CMDsave"
        Me.CMDsave.Size = New System.Drawing.Size(75, 23)
        Me.CMDsave.TabIndex = 5
        Me.CMDsave.Text = "Save"
        Me.CMDsave.UseVisualStyleBackColor = True
        '
        'CMDloadsave
        '
        Me.CMDloadsave.Location = New System.Drawing.Point(356, 518)
        Me.CMDloadsave.Name = "CMDloadsave"
        Me.CMDloadsave.Size = New System.Drawing.Size(75, 23)
        Me.CMDloadsave.TabIndex = 6
        Me.CMDloadsave.Text = "Load"
        Me.CMDloadsave.UseVisualStyleBackColor = True
        '
        'cmdhelp
        '
        Me.cmdhelp.Location = New System.Drawing.Point(275, 518)
        Me.cmdhelp.Name = "cmdhelp"
        Me.cmdhelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdhelp.TabIndex = 7
        Me.cmdhelp.Text = "help"
        Me.cmdhelp.UseVisualStyleBackColor = True
        '
        'cmdopenworld
        '
        Me.cmdopenworld.Location = New System.Drawing.Point(12, 518)
        Me.cmdopenworld.Name = "cmdopenworld"
        Me.cmdopenworld.Size = New System.Drawing.Size(75, 23)
        Me.cmdopenworld.TabIndex = 8
        Me.cmdopenworld.Text = "Open world"
        Me.cmdopenworld.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 570)
        Me.Controls.Add(Me.cmdopenworld)
        Me.Controls.Add(Me.cmdhelp)
        Me.Controls.Add(Me.CMDloadsave)
        Me.Controls.Add(Me.CMDsave)
        Me.Controls.Add(Me.Inventory)
        Me.Controls.Add(Me.gshowtext)
        Me.Controls.Add(Me.lbldebugdata)
        Me.Controls.Add(Me.pbGame)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(532, 600)
        Me.MinimumSize = New System.Drawing.Size(532, 575)
        Me.Name = "Form1"
        Me.Text = "Cell Game"
        CType(Me.pbGame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gshowtext.ResumeLayout(False)
        Me.gshowtext.PerformLayout()
        Me.Inventory.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbGame As System.Windows.Forms.PictureBox
    Friend WithEvents lbldebugdata As System.Windows.Forms.Label
    Friend WithEvents open As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gshowtext As System.Windows.Forms.GroupBox
    Friend WithEvents lblshowtext As System.Windows.Forms.Label
    Friend WithEvents Inventory As System.Windows.Forms.GroupBox
    Friend WithEvents CMDsave As System.Windows.Forms.Button
    Friend WithEvents CMDloadsave As System.Windows.Forms.Button
    Friend WithEvents inventorylist As System.Windows.Forms.ListView
    Friend WithEvents Item As System.Windows.Forms.ColumnHeader
    Friend WithEvents Price As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdhelp As System.Windows.Forms.Button
    Friend WithEvents cmdopenworld As System.Windows.Forms.Button

End Class
