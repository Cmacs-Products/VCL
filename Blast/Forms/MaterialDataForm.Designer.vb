<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaterialDataForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialDataForm))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.glassWeightTBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.materialLBox = New System.Windows.Forms.ListBox()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ResetLatestBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(12, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Glass Weight"
        Me.ToolTip1.SetToolTip(Me.Label5, "Glass Weight")
        '
        'glassWeightTBox
        '
        Me.glassWeightTBox.Location = New System.Drawing.Point(88, 32)
        Me.glassWeightTBox.Name = "glassWeightTBox"
        Me.glassWeightTBox.Size = New System.Drawing.Size(156, 20)
        Me.glassWeightTBox.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(250, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "psf"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(38, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Material"
        Me.ToolTip1.SetToolTip(Me.Label1, "Mullion Material Type")
        '
        'materialLBox
        '
        Me.materialLBox.FormattingEnabled = True
        Me.materialLBox.Items.AddRange(New Object() {"Aluminum 6061-T6", "Aluminum 6063-T5", "Steel A36", "Steel A572", "Stainless 304"})
        Me.materialLBox.Location = New System.Drawing.Point(88, 79)
        Me.materialLBox.Name = "materialLBox"
        Me.materialLBox.Size = New System.Drawing.Size(156, 69)
        Me.materialLBox.TabIndex = 2
        '
        'OkBtn
        '
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(88, 176)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 3
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(169, 196)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 5
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'ResetLatestBtn
        '
        Me.ResetLatestBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatestBtn.Location = New System.Drawing.Point(169, 176)
        Me.ResetLatestBtn.Name = "ResetLatestBtn"
        Me.ResetLatestBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatestBtn.TabIndex = 4
        Me.ResetLatestBtn.Text = "Reset"
        Me.ResetLatestBtn.UseVisualStyleBackColor = True
        '
        'MaterialDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(279, 228)
        Me.Controls.Add(Me.ResetLatestBtn)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.materialLBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.glassWeightTBox)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MaterialDataForm"
        Me.Text = "Material Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents glassWeightTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents materialLBox As System.Windows.Forms.ListBox
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ResetLatestBtn As System.Windows.Forms.Button
End Class
