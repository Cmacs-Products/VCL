<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectInfoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectInfoForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.projectTBox = New System.Windows.Forms.TextBox()
        Me.subjectTBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pDateTBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.engineerTBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PrintBtn = New System.Windows.Forms.Button()
        Me.CnclBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(32, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project"
        '
        'projectTBox
        '
        Me.projectTBox.Location = New System.Drawing.Point(78, 34)
        Me.projectTBox.Name = "projectTBox"
        Me.projectTBox.Size = New System.Drawing.Size(439, 20)
        Me.projectTBox.TabIndex = 1
        '
        'subjectTBox
        '
        Me.subjectTBox.Location = New System.Drawing.Point(78, 79)
        Me.subjectTBox.Name = "subjectTBox"
        Me.subjectTBox.Size = New System.Drawing.Size(439, 20)
        Me.subjectTBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(29, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Subject"
        '
        'pDateTBox
        '
        Me.pDateTBox.BackColor = System.Drawing.Color.LightGray
        Me.pDateTBox.Location = New System.Drawing.Point(363, 121)
        Me.pDateTBox.Name = "pDateTBox"
        Me.pDateTBox.Size = New System.Drawing.Size(154, 20)
        Me.pDateTBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(328, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date"
        '
        'engineerTBox
        '
        Me.engineerTBox.BackColor = System.Drawing.Color.LightGray
        Me.engineerTBox.Location = New System.Drawing.Point(78, 121)
        Me.engineerTBox.Name = "engineerTBox"
        Me.engineerTBox.Size = New System.Drawing.Size(163, 20)
        Me.engineerTBox.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(23, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Engineer"
        '
        'PrintBtn
        '
        Me.PrintBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.PrintBtn.Location = New System.Drawing.Point(363, 178)
        Me.PrintBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(75, 40)
        Me.PrintBtn.TabIndex = 3
        Me.PrintBtn.Text = "OK"
        Me.PrintBtn.UseVisualStyleBackColor = True
        '
        'CnclBtn
        '
        Me.CnclBtn.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CnclBtn.Location = New System.Drawing.Point(442, 178)
        Me.CnclBtn.Margin = New System.Windows.Forms.Padding(2)
        Me.CnclBtn.Name = "CnclBtn"
        Me.CnclBtn.Size = New System.Drawing.Size(75, 40)
        Me.CnclBtn.TabIndex = 4
        Me.CnclBtn.Text = "Cancel"
        Me.CnclBtn.UseVisualStyleBackColor = True
        '
        'ProjectInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(535, 229)
        Me.Controls.Add(Me.CnclBtn)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.engineerTBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pDateTBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.subjectTBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.projectTBox)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProjectInfoForm"
        Me.Text = "Project Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents projectTBox As System.Windows.Forms.TextBox
    Friend WithEvents subjectTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pDateTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents engineerTBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Protected Friend WithEvents PrintBtn As System.Windows.Forms.Button
    Protected Friend WithEvents CnclBtn As System.Windows.Forms.Button
End Class
