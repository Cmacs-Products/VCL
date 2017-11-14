<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TriangularPulseForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TriangularPulseForm))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.riseTBox = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Rise = New System.Windows.Forms.Label()
        Me.durationTBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pulseTBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.negativeDurationTBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.netagivePulseTBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pulsePanel = New System.Windows.Forms.Panel()
        Me.ResetLatestBtn = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.riseTBox)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Rise)
        Me.GroupBox4.Controls.Add(Me.durationTBox)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.pulseTBox)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox4.Location = New System.Drawing.Point(22, 42)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(240, 138)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Pluse Data"
        '
        'riseTBox
        '
        Me.riseTBox.Location = New System.Drawing.Point(74, 59)
        Me.riseTBox.Name = "riseTBox"
        Me.riseTBox.Size = New System.Drawing.Size(59, 20)
        Me.riseTBox.TabIndex = 2
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(139, 60)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(33, 14)
        Me.Label50.TabIndex = 19
        Me.Label50.Text = "msec"
        '
        'Rise
        '
        Me.Rise.AutoSize = True
        Me.Rise.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rise.Location = New System.Drawing.Point(13, 66)
        Me.Rise.Name = "Rise"
        Me.Rise.Size = New System.Drawing.Size(28, 14)
        Me.Rise.TabIndex = 18
        Me.Rise.Text = "Rise"
        '
        'durationTBox
        '
        Me.durationTBox.Location = New System.Drawing.Point(74, 93)
        Me.durationTBox.Name = "durationTBox"
        Me.durationTBox.Size = New System.Drawing.Size(59, 20)
        Me.durationTBox.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(139, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(33, 14)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "msec"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 97)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 14)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Duration "
        '
        'pulseTBox
        '
        Me.pulseTBox.Location = New System.Drawing.Point(74, 25)
        Me.pulseTBox.Name = "pulseTBox"
        Me.pulseTBox.Size = New System.Drawing.Size(59, 20)
        Me.pulseTBox.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(139, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(21, 14)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "psi"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 14)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Peak"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.negativeDurationTBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.netagivePulseTBox)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox1.Location = New System.Drawing.Point(22, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 107)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rebound Data"
        '
        'negativeDurationTBox
        '
        Me.negativeDurationTBox.Location = New System.Drawing.Point(74, 62)
        Me.negativeDurationTBox.Name = "negativeDurationTBox"
        Me.negativeDurationTBox.Size = New System.Drawing.Size(59, 20)
        Me.negativeDurationTBox.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(139, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "msec"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Duration"
        '
        'netagivePulseTBox
        '
        Me.netagivePulseTBox.Location = New System.Drawing.Point(74, 25)
        Me.netagivePulseTBox.Name = "netagivePulseTBox"
        Me.netagivePulseTBox.Size = New System.Drawing.Size(59, 20)
        Me.netagivePulseTBox.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(139, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "psi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 14)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Peak "
        '
        'OkBtn
        '
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(500, 361)
        Me.OkBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 6
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(579, 381)
        Me.ResetDefaultBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 8
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(674, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Time (msec)"
        '
        'pulsePanel
        '
        Me.pulsePanel.Location = New System.Drawing.Point(293, 42)
        Me.pulsePanel.Name = "pulsePanel"
        Me.pulsePanel.Size = New System.Drawing.Size(376, 269)
        Me.pulsePanel.TabIndex = 40
        '
        'ResetLatestBtn
        '
        Me.ResetLatestBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatestBtn.Location = New System.Drawing.Point(579, 361)
        Me.ResetLatestBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetLatestBtn.Name = "ResetLatestBtn"
        Me.ResetLatestBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatestBtn.TabIndex = 7
        Me.ResetLatestBtn.Text = "Reset"
        Me.ResetLatestBtn.UseVisualStyleBackColor = True
        '
        'TriangularPulseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(752, 412)
        Me.Controls.Add(Me.ResetLatestBtn)
        Me.Controls.Add(Me.pulsePanel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TriangularPulseForm"
        Me.Text = "Triangular Pulse Information"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents riseTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Rise As System.Windows.Forms.Label
    Friend WithEvents durationTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pulseTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents negativeDurationTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents netagivePulseTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Protected Friend WithEvents OkBtn As System.Windows.Forms.Button
    Protected Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents pulsePanel As System.Windows.Forms.Panel
    Protected Friend WithEvents ResetLatestBtn As System.Windows.Forms.Button
End Class
