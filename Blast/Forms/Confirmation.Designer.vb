<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Confirmation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Confirmation))
        Me.cautionLabel = New System.Windows.Forms.Label()
        Me.saveChangesBtn = New System.Windows.Forms.Button()
        Me.ignoreChangesBtn = New System.Windows.Forms.Button()
        Me.cancelChangesBtn = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cautionLabel
        '
        Me.cautionLabel.AutoSize = True
        Me.cautionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cautionLabel.ForeColor = System.Drawing.Color.Black
        Me.cautionLabel.Location = New System.Drawing.Point(119, 20)
        Me.cautionLabel.Name = "cautionLabel"
        Me.cautionLabel.Size = New System.Drawing.Size(254, 16)
        Me.cautionLabel.TabIndex = 0
        Me.cautionLabel.Text = "Do you want to save the recent changes ?"
        '
        'saveChangesBtn
        '
        Me.saveChangesBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.saveChangesBtn.Location = New System.Drawing.Point(122, 63)
        Me.saveChangesBtn.Name = "saveChangesBtn"
        Me.saveChangesBtn.Size = New System.Drawing.Size(75, 40)
        Me.saveChangesBtn.TabIndex = 1
        Me.saveChangesBtn.Text = "Save"
        Me.saveChangesBtn.UseVisualStyleBackColor = True
        '
        'ignoreChangesBtn
        '
        Me.ignoreChangesBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ignoreChangesBtn.Location = New System.Drawing.Point(203, 63)
        Me.ignoreChangesBtn.Name = "ignoreChangesBtn"
        Me.ignoreChangesBtn.Size = New System.Drawing.Size(75, 40)
        Me.ignoreChangesBtn.TabIndex = 2
        Me.ignoreChangesBtn.Text = "Don't Save"
        Me.ignoreChangesBtn.UseVisualStyleBackColor = True
        '
        'cancelChangesBtn
        '
        Me.cancelChangesBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.cancelChangesBtn.Location = New System.Drawing.Point(284, 63)
        Me.cancelChangesBtn.Name = "cancelChangesBtn"
        Me.cancelChangesBtn.Size = New System.Drawing.Size(75, 40)
        Me.cancelChangesBtn.TabIndex = 3
        Me.cancelChangesBtn.Text = "Cancel"
        Me.cancelChangesBtn.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(43, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 28)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Confirmation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(465, 115)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cancelChangesBtn)
        Me.Controls.Add(Me.ignoreChangesBtn)
        Me.Controls.Add(Me.cautionLabel)
        Me.Controls.Add(Me.saveChangesBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Confirmation"
        Me.Text = "Mullion Blast Analysis"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cautionLabel As System.Windows.Forms.Label
    Friend WithEvents saveChangesBtn As System.Windows.Forms.Button
    Friend WithEvents ignoreChangesBtn As System.Windows.Forms.Button
    Friend WithEvents cancelChangesBtn As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
