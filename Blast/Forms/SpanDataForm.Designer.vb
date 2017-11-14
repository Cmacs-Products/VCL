<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpanDataForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpanDataForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.spanTypeCBox = New System.Windows.Forms.CheckBox()
        Me.spanTBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.spacingTBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.ResetLatest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(26, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Span"
        Me.ToolTip1.SetToolTip(Me.Label1, "Mullion Length,  for Double Span, Use the Larger Length")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Spacing"
        Me.ToolTip1.SetToolTip(Me.Label2, "Mullion Spacing")
        '
        'spanTypeCBox
        '
        Me.spanTypeCBox.AutoSize = True
        Me.spanTypeCBox.ForeColor = System.Drawing.Color.RoyalBlue
        Me.spanTypeCBox.Location = New System.Drawing.Point(64, 99)
        Me.spanTypeCBox.Name = "spanTypeCBox"
        Me.spanTypeCBox.Size = New System.Drawing.Size(88, 17)
        Me.spanTypeCBox.TabIndex = 3
        Me.spanTypeCBox.Text = "Double Span"
        Me.ToolTip1.SetToolTip(Me.spanTypeCBox, "Single / Double Span")
        Me.spanTypeCBox.UseVisualStyleBackColor = True
        '
        'spanTBox
        '
        Me.spanTBox.Location = New System.Drawing.Point(64, 33)
        Me.spanTBox.Name = "spanTBox"
        Me.spanTBox.Size = New System.Drawing.Size(154, 20)
        Me.spanTBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(224, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "ft"
        '
        'spacingTBox
        '
        Me.spacingTBox.Location = New System.Drawing.Point(64, 64)
        Me.spacingTBox.Name = "spacingTBox"
        Me.spacingTBox.Size = New System.Drawing.Size(153, 20)
        Me.spacingTBox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(223, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "ft"
        '
        'OkBtn
        '
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(64, 136)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 4
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(143, 156)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 6
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'ResetLatest
        '
        Me.ResetLatest.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatest.Location = New System.Drawing.Point(143, 136)
        Me.ResetLatest.Name = "ResetLatest"
        Me.ResetLatest.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatest.TabIndex = 5
        Me.ResetLatest.Text = "Reset"
        Me.ResetLatest.UseVisualStyleBackColor = True
        '
        'SpanDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(282, 188)
        Me.Controls.Add(Me.ResetLatest)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.spanTypeCBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.spacingTBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.spanTBox)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SpanDataForm"
        Me.Text = "Span Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents spanTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents spacingTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents spanTypeCBox As System.Windows.Forms.CheckBox
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents ResetLatest As System.Windows.Forms.Button
End Class
