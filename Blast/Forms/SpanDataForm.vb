''' <summary>
''' Class to enter user input for span data
''' </summary>
Public Class SpanDataForm

#Region "Fields"
    Private spanValidationFailed As Boolean = False
    Private spacingValidationFailed As Boolean = False

    Private _spanOnLoad As Double
    Private _spacingOnLoad As Double
    Private _spanTypeOnLoad As Integer
#End Region
    
#Region "Private Call Backs"

    ''' <summary>
    ''' Handles the Load event of the SpanDataForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub SpanDataForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()
        _spanOnLoad = InputData.Span
        _spacingOnLoad = InputData.Spacing
        _spanTypeOnLoad = InputData.SpanType
    End Sub

    ''' <summary>
    ''' Handles the Leave event of the spacingTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub spacingTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spacingTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = spacingTBox.Text

            If value < 1 Or value > 20 Then
                spacingValidationFailed = True
            Else
                spacingValidationFailed = False
            End If
        Catch ex As Exception
            spacingValidationFailed = True
        End Try

        If spacingValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Spacing has to be between 1 and 20", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            spacingTBox.ForeColor = errTxtColor
        Else
            spacingTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the spanTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub spanTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spanTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = spanTBox.Text
            If value < 2 Or value > 40 Then
                spanValidationFailed = True
            Else
                spanValidationFailed = False
            End If
        Catch ex As Exception
            spanValidationFailed = True
        End Try

        If spanValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Span has to be between 2 and 40", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            spanTBox.ForeColor = errTxtColor
        Else
            spanTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Click event of the OkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click

        InputData.Span = Me.spanTBox.Text
        InputData.Spacing = Me.spacingTBox.Text

        If Me.spanTypeCBox.Checked Then
            'Double
            InputData.SpanType = 1
        Else
            'Single
            InputData.SpanType = 0
        End If

        'Saves the values
        InputData.FirstTimeSpanDataInput = False

        Me.Close()

        'Should Update the Panels

    End Sub

    ''' <summary>
    ''' Handles the Click event of the ResetBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResetDefaultBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click
        InputData.FirstTimeSpanDataInput = True
        PopulateData()
        spanValidationFailed = False
        spacingValidationFailed = False
        spacingTBox.ForeColor = Color.Black
        spanTBox.ForeColor = Color.Black
        UpdateValidation()
    End Sub

    Private Sub ResetLatest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatest.Click
        InputData.FirstTimeSpanDataInput = False
        spanValidationFailed = False
        spacingValidationFailed = False
        spacingTBox.ForeColor = Color.Black
        spanTBox.ForeColor = Color.Black
        UpdateValidation()
        Me.spacingTBox.Text = CStr(Format(_spacingOnLoad, "0.00"))
        Me.spanTBox.Text = CStr(Format(_spanOnLoad, "0.00"))
        If _spanTypeOnLoad = 1 Then
            Me.spanTypeCBox.Checked = True
        Else
            Me.spanTypeCBox.Checked = False
        End If

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeSpanDataInput Then
            Me.spacingTBox.Text = "5.00"
            Me.spanTBox.Text = "12.50"
            Me.spanTypeCBox.Checked = False
        Else
            Me.spacingTBox.Text = CStr(Format(InputData.Spacing, "0.00"))
            Me.spanTBox.Text = CStr(Format(InputData.Span, "0.00"))
            If InputData.SpanType = 1 Then
                Me.spanTypeCBox.Checked = True
            Else
                Me.spanTypeCBox.Checked = False
            End If
        End If

    End Sub

    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not spanValidationFailed And Not spacingValidationFailed Then
            Me.OkBtn.Enabled = True
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region


End Class