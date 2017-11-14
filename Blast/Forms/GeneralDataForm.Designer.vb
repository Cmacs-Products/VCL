<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneralDataForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralDataForm))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.general_load = New System.Windows.Forms.DataGridView()
        Me.xtime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xload = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.general_load, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Button1.Location = New System.Drawing.Point(65, 283)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'general_load
        '
        Me.general_load.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.general_load.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.xtime, Me.xload})
        Me.general_load.Location = New System.Drawing.Point(11, 20)
        Me.general_load.Margin = New System.Windows.Forms.Padding(2)
        Me.general_load.Name = "general_load"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.general_load.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.general_load.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.general_load.RowTemplate.Height = 24
        Me.general_load.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.general_load.Size = New System.Drawing.Size(185, 176)
        Me.general_load.TabIndex = 2
        '
        'xtime
        '
        Me.xtime.HeaderText = "Time (msec)"
        Me.xtime.Name = "xtime"
        '
        'xload
        '
        Me.xload.HeaderText = "Pressure (psi)"
        Me.xload.Name = "xload"
        '
        'GeneralDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(220, 334)
        Me.Controls.Add(Me.general_load)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "GeneralDataForm"
        Me.Text = "General Loading"
        CType(Me.general_load, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents general_load As System.Windows.Forms.DataGridView
    Friend WithEvents xtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xload As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
