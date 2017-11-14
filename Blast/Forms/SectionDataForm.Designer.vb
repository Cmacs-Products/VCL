<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SectionDataForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SectionDataForm))
        Me.Label41 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.inertiaTBox = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.plasticModulsTBox = New System.Windows.Forms.TextBox()
        Me.areaTBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OkBtn = New System.Windows.Forms.Button()
        Me.ResetDefaultBtn = New System.Windows.Forms.Button()
        Me.ResetLatestBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("RomanT", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label41.Location = New System.Drawing.Point(31, 25)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(14, 17)
        Me.Label41.TabIndex = 7
        Me.Label41.Text = "I"
        Me.ToolTip1.SetToolTip(Me.Label41, "Moment of Inertia")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(17, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Area"
        Me.ToolTip1.SetToolTip(Me.Label3, "Mullion Area")
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("RomanT", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label54.Location = New System.Drawing.Point(29, 60)
        Me.Label54.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(17, 17)
        Me.Label54.TabIndex = 44
        Me.Label54.Text = "Z"
        Me.ToolTip1.SetToolTip(Me.Label54, "Plastic Section Modulus")
        '
        'inertiaTBox
        '
        Me.inertiaTBox.Location = New System.Drawing.Point(50, 23)
        Me.inertiaTBox.Margin = New System.Windows.Forms.Padding(2)
        Me.inertiaTBox.Name = "inertiaTBox"
        Me.inertiaTBox.Size = New System.Drawing.Size(154, 20)
        Me.inertiaTBox.TabIndex = 1
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(216, 26)
        Me.Label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(21, 13)
        Me.Label40.TabIndex = 46
        Me.Label40.Text = "in4"
        '
        'plasticModulsTBox
        '
        Me.plasticModulsTBox.Location = New System.Drawing.Point(50, 57)
        Me.plasticModulsTBox.Margin = New System.Windows.Forms.Padding(2)
        Me.plasticModulsTBox.Name = "plasticModulsTBox"
        Me.plasticModulsTBox.Size = New System.Drawing.Size(154, 20)
        Me.plasticModulsTBox.TabIndex = 2
        '
        'areaTBox
        '
        Me.areaTBox.Location = New System.Drawing.Point(50, 91)
        Me.areaTBox.Margin = New System.Windows.Forms.Padding(2)
        Me.areaTBox.Name = "areaTBox"
        Me.areaTBox.Size = New System.Drawing.Size(154, 20)
        Me.areaTBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(216, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "in3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(216, 94)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "in2"
        '
        'OkBtn
        '
        Me.OkBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OkBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.OkBtn.Location = New System.Drawing.Point(50, 139)
        Me.OkBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.OkBtn.Name = "OkBtn"
        Me.OkBtn.Size = New System.Drawing.Size(75, 40)
        Me.OkBtn.TabIndex = 4
        Me.OkBtn.Text = "OK"
        Me.OkBtn.UseVisualStyleBackColor = True
        '
        'ResetDefaultBtn
        '
        Me.ResetDefaultBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetDefaultBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetDefaultBtn.Location = New System.Drawing.Point(129, 159)
        Me.ResetDefaultBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetDefaultBtn.Name = "ResetDefaultBtn"
        Me.ResetDefaultBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetDefaultBtn.TabIndex = 6
        Me.ResetDefaultBtn.Text = "Default"
        Me.ResetDefaultBtn.UseVisualStyleBackColor = True
        '
        'ResetLatestBtn
        '
        Me.ResetLatestBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetLatestBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ResetLatestBtn.Location = New System.Drawing.Point(129, 139)
        Me.ResetLatestBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.ResetLatestBtn.Name = "ResetLatestBtn"
        Me.ResetLatestBtn.Size = New System.Drawing.Size(75, 20)
        Me.ResetLatestBtn.TabIndex = 5
        Me.ResetLatestBtn.Text = "Reset"
        Me.ResetLatestBtn.UseVisualStyleBackColor = True
        '
        'SectionDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(271, 190)
        Me.Controls.Add(Me.ResetLatestBtn)
        Me.Controls.Add(Me.ResetDefaultBtn)
        Me.Controls.Add(Me.OkBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.areaTBox)
        Me.Controls.Add(Me.plasticModulsTBox)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.inertiaTBox)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label41)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SectionDataForm"
        Me.Text = "Section Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents inertiaTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents plasticModulsTBox As System.Windows.Forms.TextBox
    Friend WithEvents areaTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OkBtn As System.Windows.Forms.Button
    Friend WithEvents ResetDefaultBtn As System.Windows.Forms.Button
    Friend WithEvents ResetLatestBtn As System.Windows.Forms.Button
End Class
