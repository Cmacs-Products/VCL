<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResponseDataForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResponseDataForm))
        Me.responseDurationTBox = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.responseStepSizeTBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.ResetLatestBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'responseDurationTBox
        '
        Me.responseDurationTBox.Location = New System.Drawing.Point(86, 39)
        Me.responseDurationTBox.Name = "responseDurationTBox"
        Me.responseDurationTBox.Size = New System.Drawing.Size(155, 20)
        Me.responseDurationTBox.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(247, 42)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(49, 14)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "seconds"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label32.Location = New System.Drawing.Point(25, 42)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(47, 14)
        Me.Label32.TabIndex = 42
        Me.Label32.Text = "Duration"
        '
        'responseStepSizeTBox
        '
        Me.responseStepSizeTBox.Location = New System.Drawing.Point(86, 72)
        Me.responseStepSizeTBox.Name = "responseStepSizeTBox"
        Me.responseStepSizeTBox.Size = New System.Drawing.Size(155, 20)
        Me.responseStepSizeTBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(247, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "msec"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(25, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Step Size"
        '
        'OkBtn
        '
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(86, 124)
        Me.OkBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 3
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(166, 143)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 5
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'ResetLatestBtn
        '
        Me.ResetLatestBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatestBtn.Location = New System.Drawing.Point(166, 124)
        Me.ResetLatestBtn.Name = "ResetLatestBtn"
        Me.ResetLatestBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatestBtn.TabIndex = 4
        Me.ResetLatestBtn.Text = "Reset"
        Me.ResetLatestBtn.UseVisualStyleBackColor = True
        '
        'ResponseDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(311, 176)
        Me.Controls.Add(Me.ResetLatestBtn)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.responseStepSizeTBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.responseDurationTBox)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label32)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ResponseDataForm"
        Me.Text = "Response Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents responseDurationTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents responseStepSizeTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents ResetLatestBtn As System.Windows.Forms.Button
End Class
