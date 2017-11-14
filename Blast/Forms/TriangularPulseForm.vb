''' <summary>
''' Form to show the triangular pulse graphs
''' </summary>
Public Class TriangularPulseForm

#Region "Fields"
    Private pulseValidationFailed As Boolean = False
    Private riseValidationFailed As Boolean = False
    Private durationValidationFailed As Boolean = False
    Private negativePulseValidationFailed As Boolean = False
    Private negativeDurationValidationFailed As Boolean = False

    Private _pulseOnLoad As Double
    Private _riseOnLoad As Double
    Private _durationOnLoad As Double
    Private _negativePulseOnLoad As Double
    Private _negativeDurationOnLoad As Double

#End Region

#Region "Private Call backs"

    ''' <summary>
    ''' Handles the Load event of the TriangularPulseForm control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub TriangularPulseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateData()

        _pulseOnLoad = InputData.Pulse
        _riseOnLoad = InputData.Rise
        _durationOnLoad = InputData.Duration
        _negativePulseOnLoad = InputData.NegativePulse
        _negativeDurationOnLoad = InputData.NegativeDuration

        pulsePanel.Invalidate()
    End Sub

    ''' <summary>
    ''' Handles the Paint event of the pulsePanel control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub pulsePanel_Paint(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pulsePanel.Paint
        Plotter.GeneratePulseGraph(Me.pulsePanel)
    End Sub

    ''' <summary>
    ''' Handles the Click event of the TriFormOkBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub OkBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBtn.Click

        InputData.Pulse = CDbl(Me.pulseTBox.Text.Trim())
        InputData.Rise = CDbl(Me.riseTBox.Text.Trim())
        InputData.Duration = CDbl(Me.durationTBox.Text.Trim())

        InputData.NegativePulse = CDbl(Me.netagivePulseTBox.Text.Trim())
        InputData.NegativeDuration = CDbl(Me.negativeDurationTBox.Text.Trim())

        InputData.FirstTimeTriPulseInput = False

        Me.Close()
    End Sub


    ''' <summary>
    ''' Handles the Click event of the ResetDefaultBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResetDefaultBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultBtn.Click

        InputData.FirstTimeTriPulseInput = True

        PopulateData()

        pulseValidationFailed = False
        riseValidationFailed = False
        durationValidationFailed = False
        negativePulseValidationFailed = False
        negativeDurationValidationFailed = False


        pulseTBox.ForeColor = Color.Black
        riseTBox.ForeColor = Color.Black
        durationTBox.ForeColor = Color.Black
        negativeDurationTBox.ForeColor = Color.Black
        netagivePulseTBox.ForeColor = Color.Black

        UpdateValidation()

        InputData.Pulse = CDbl(Me.pulseTBox.Text.Trim())
        InputData.Rise = CDbl(Me.riseTBox.Text.Trim())
        InputData.Duration = CDbl(Me.durationTBox.Text.Trim())

        InputData.NegativePulse = CDbl(Me.netagivePulseTBox.Text.Trim())
        InputData.NegativeDuration = CDbl(Me.negativeDurationTBox.Text.Trim())

    End Sub

    ''' <summary>
    ''' Handles the Click event of the ResetLatestBtn control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub ResetLatestBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetLatestBtn.Click

        InputData.FirstTimeTriPulseInput = True

        pulseValidationFailed = False
        riseValidationFailed = False
        durationValidationFailed = False
        negativePulseValidationFailed = False
        negativeDurationValidationFailed = False
        pulseTBox.ForeColor = Color.Black
        riseTBox.ForeColor = Color.Black
        durationTBox.ForeColor = Color.Black
        negativeDurationTBox.ForeColor = Color.Black
        netagivePulseTBox.ForeColor = Color.Black

        Me.pulseTBox.Text = CStr(Format(_pulseOnLoad, "0.00"))
        Me.riseTBox.Text = CStr(Format(_riseOnLoad, "0.00"))
        Me.durationTBox.Text = CStr(Format(_durationOnLoad, "0.00"))

        Me.netagivePulseTBox.Text = CStr(Format(_negativePulseOnLoad, "0.00"))
        Me.negativeDurationTBox.Text = CStr(Format(_negativeDurationOnLoad, "0.00"))

        InputData.Pulse = CDbl(Me.pulseTBox.Text.Trim())
        InputData.Rise = CDbl(Me.riseTBox.Text.Trim())
        InputData.Duration = CDbl(Me.durationTBox.Text.Trim())

        InputData.NegativePulse = CDbl(Me.netagivePulseTBox.Text.Trim())
        InputData.NegativeDuration = CDbl(Me.negativeDurationTBox.Text.Trim())

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the pulseTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub pulseTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pulseTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.pulseTBox.Text.Trim())
            If value <= 0 Then
                pulseValidationFailed = True
            Else
                InputData.Pulse = value
                pulseValidationFailed = False
            End If

        Catch ex As Exception
            pulseValidationFailed = True
        End Try

        If pulseValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Peak Pulse has be a greater than zero", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pulseTBox.ForeColor = errTxtColor
        Else
            pulseTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the riseTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub riseTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles riseTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.riseTBox.Text.Trim())
            If value < 0 Then
                riseValidationFailed = True
            Else
                InputData.Rise = value
                riseValidationFailed = False
            End If

        Catch ex As Exception
            riseValidationFailed = True
        End Try

        If riseValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Rise has to be a zero or more", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            riseTBox.ForeColor = errTxtColor
        Else
            riseTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the durationTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub durationTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles durationTBox.Leave
        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.durationTBox.Text.Trim())
            If value <= 0 Then
                durationValidationFailed = True
            Else
                InputData.Duration = value
                durationValidationFailed = False
            End If

        Catch ex As Exception
            durationValidationFailed = True
        End Try

        If durationValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Duration has be a greater than zero", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            durationTBox.ForeColor = errTxtColor
        Else
            durationTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the netagivePulseTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub netagivePulseTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles netagivePulseTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.netagivePulseTBox.Text.Trim())
            InputData.NegativePulse = value
            negativePulseValidationFailed = False
        Catch ex As Exception
            negativePulseValidationFailed = True
        End Try

        If negativePulseValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Rebound Peak has to be zero or more", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            netagivePulseTBox.ForeColor = errTxtColor
        Else
            netagivePulseTBox.ForeColor = txtColor
        End If

        UpdateValidation()

    End Sub

    ''' <summary>
    ''' Handles the Leave event of the negativeDurationTBox control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub negativeDurationTBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles negativeDurationTBox.Leave

        Dim txtColor As Color = Color.Black
        Dim errTxtColor As Color = Color.Red

        Try
            Dim value As Double = CDbl(Me.negativeDurationTBox.Text.Trim())
            If value <= 0 Then
                negativeDurationValidationFailed = True
            Else
                InputData.NegativeDuration = value
                negativeDurationValidationFailed = False
            End If

        Catch ex As Exception
            negativeDurationValidationFailed = True
        End Try

        If negativeDurationValidationFailed Then
            System.Windows.Forms.MessageBox.Show("Rebound Duration has be a greater than zero", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            negativeDurationTBox.ForeColor = errTxtColor
        Else
            negativeDurationTBox.ForeColor = txtColor
        End If

        UpdateValidation()
    End Sub



#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Populates the default data.
    ''' </summary>
    Private Sub PopulateData()

        If InputData.FirstTimeTriPulseInput Then
            Me.pulseTBox.Text = "4.00"
            Me.riseTBox.Text = "0.00"
            Me.durationTBox.Text = "14.00"

            Me.netagivePulseTBox.Text = "0.00"
            Me.negativeDurationTBox.Text = "1.00"

        Else
            Me.pulseTBox.Text = CStr(Format(InputData.Pulse, "0.00"))
            Me.riseTBox.Text = CStr(Format(InputData.Rise, "0.00"))
            Me.durationTBox.Text = CStr(Format(InputData.Duration, "0.00"))

            Me.netagivePulseTBox.Text = CStr(Format(InputData.NegativePulse, "0.00"))
            Me.negativeDurationTBox.Text = CStr(Format(InputData.NegativeDuration, "0.00"))

        End If

    End Sub


    ''' <summary>
    ''' Updates the validation.
    ''' </summary>
    Private Sub UpdateValidation()

        If Not pulseValidationFailed And Not riseValidationFailed And Not durationValidationFailed And Not negativeDurationValidationFailed And Not negativePulseValidationFailed Then
            Me.OkBtn.Enabled = True
            pulsePanel.Invalidate()
        Else
            Me.OkBtn.Enabled = False
        End If

    End Sub

#End Region


End Class