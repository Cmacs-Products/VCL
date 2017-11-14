<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SinusoidalPulseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SinusoidalPulseForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sinAmpTBox = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.sinFreqTBox = New System.Windows.Forms.TextBox()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.ResetLatestBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(269, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Hertz"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(39, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Frequency"
        '
        'sinAmpTBox
        '
        Me.sinAmpTBox.Location = New System.Drawing.Point(104, 51)
        Me.sinAmpTBox.Name = "sinAmpTBox"
        Me.sinAmpTBox.Size = New System.Drawing.Size(155, 20)
        Me.sinAmpTBox.TabIndex = 1
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(265, 54)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(21, 14)
        Me.Label34.TabIndex = 49
        Me.Label34.Text = "psi"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label32.Location = New System.Drawing.Point(44, 54)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(54, 14)
        Me.Label32.TabIndex = 48
        Me.Label32.Text = "Amplitude"
        '
        'OkBtn
        '
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(104, 147)
        Me.OkBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 3
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'sinFreqTBox
        '
        Me.sinFreqTBox.Location = New System.Drawing.Point(104, 85)
        Me.sinFreqTBox.Name = "sinFreqTBox"
        Me.sinFreqTBox.Size = New System.Drawing.Size(155, 20)
        Me.sinFreqTBox.TabIndex = 2
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(184, 167)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 5
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'ResetLatestBtn
        '
        Me.ResetLatestBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatestBtn.Location = New System.Drawing.Point(184, 147)
        Me.ResetLatestBtn.Name = "ResetLatestBtn"
        Me.ResetLatestBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatestBtn.TabIndex = 4
        Me.ResetLatestBtn.Text = "Reset"
        Me.ResetLatestBtn.UseVisualStyleBackColor = True
        '
        'SinusoidalPulseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(331, 198)
        Me.Controls.Add(Me.ResetLatestBtn)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.sinFreqTBox)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.sinAmpTBox)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label32)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "SinusoidalPulseForm"
        Me.Text = "Sinusoidal Pulse Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents sinAmpTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents sinFreqTBox As System.Windows.Forms.TextBox
    Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents ResetLatestBtn As System.Windows.Forms.Button
End Class
